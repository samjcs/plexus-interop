import { InteropClient } from './InteropClient';
import { TransportConnectionProvider } from './TransportConnectionProvider';
import { Application } from '@plexus-interop/broker/dist/main/src/metadata/apps/model/Application';
import { InteropRegistryService } from '@plexus-interop/broker';
import { TransportConnection } from "@plexus-interop/transport-common";

export interface ServicesSnapshot {
    interopRegistryService: InteropRegistryService,
    сonnectionProvider: TransportConnectionProvider,
    interopClient: InteropClient
}

export interface StudioState {
    loading: boolean,
    connected: boolean;
    metadataUrl: string;
    connectedApp: Application;
    apps: Application[],
    services: ServicesSnapshot
}

export interface PlexusConnectedActionParams {
    apps: Application[],
    interopRegistryService: InteropRegistryService,
    сonnectionProvider: TransportConnectionProvider
}

export interface AppConnectedActionParams {
    interopClient: InteropClient
}

export interface Alert {
    message: string,
    type: AlertType
}

export enum AlertType {
    INFO, SUCCESS, USER_FAIL, ERROR
}
