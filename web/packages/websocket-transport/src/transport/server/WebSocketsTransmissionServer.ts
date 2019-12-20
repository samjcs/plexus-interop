import { TransportConnection } from '@plexus-interop/transport-common';
import { Observer, Subscription, LoggerFactory } from '@plexus-interop/common';
import WebSocket, { AddressInfo } from 'ws';
import { WebSocketConnectionFactory } from '../WebSocketConnectionFactory';

export interface TransmissionServer {
    start(port: number, connectionsObserver: Observer<TransportConnection>): Promise<ServerStartupDescriptor>;
}

export interface ServerStartupDescriptor {
    connectionsSubscription: Subscription;
    instance: ActiveTransmissionServer;
}

export interface ActiveTransmissionServer {
    stop(): Promise<void>;
}

const logger = LoggerFactory.getLogger('WebSocketsTransmissionServer');

export class WebSocketsTransmissionServer implements TransmissionServer {
    
    async start(
        port: number, 
        connectionsObserver: Observer<TransportConnection>): Promise<ServerStartupDescriptor> {
        
        const wss = new WebSocket.Server({ port });
        
        return new Promise((resolve, reject) => {
            
            wss.on('listening', () => {
                logger.info(`Started ${addressToString(wss.address())}`)
            });
            
            wss.on('connection', (socket: WebSocket) => {
                logger.debug('Accepted new ws connection');
                new WebSocketConnectionFactory(socket).connect()
                    .then(transportConnection => connectionsObserver.next(transportConnection))
                    .catch(e => logger.error('Error during Web Socket Transport connection initialization', e));
            });

            wss.on('error', e => {
                logger.error('Server failure', e);
                connectionsObserver.error(e);
                reject(e);
            });

            const serverDescriptor: ServerStartupDescriptor = {
                connectionsSubscription: {
                    unsubscribe: () => {
                        logger.info('Connections subscription stopped, closing active ');
                    }
                },
                instance: {
                    stop: this._stopHandler(wss)
                }
            };

            resolve(serverDescriptor);

        });
    }

    private _stopHandler(wss: WebSocket.Server): () => Promise<void> {
        return () => {
            return new Promise((resolve, reject) => {
                logger.info('Stop requested');
                wss.close(e => {
                    logger.info('Underlying server stopped', e);
                    if (e) {
                        reject(e);
                    } else {
                        resolve();
                    }
                });
            });
        };
    }

}

function addressToString(addressOrString: AddressInfo | string): string {
    if ((addressOrString as AddressInfo).address) {
        const { address, family, port } = addressOrString as AddressInfo;
        return `${family}/${address}:${port}`;
    } else {
        return addressOrString as string;
    }
}