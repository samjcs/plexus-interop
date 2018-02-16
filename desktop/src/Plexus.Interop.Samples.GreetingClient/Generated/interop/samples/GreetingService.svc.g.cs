// <auto-generated>
// 	Generated by the Plexus Interop compiler.  DO NOT EDIT!
// 	source: interop\samples\GreetingService.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code
namespace Plexus.Interop.Samples.GreetingClient.Generated {
	
	using System;
	using global::Plexus;
	using global::Plexus.Channels;
	using global::Plexus.Interop;
	using global::System.Threading.Tasks;
					
	internal static partial class GreetingService {
		
		public const string Id = "interop.samples.GreetingService";			
		public const string UnaryMethodId = "Unary";
		public const string ServerStreamingMethodId = "ServerStreaming";
		public const string ClientStreamingMethodId = "ClientStreaming";
		public const string DuplexStreamingMethodId = "DuplexStreaming";
		
		public static readonly GreetingService.Descriptor DefaultDescriptor = CreateDescriptor();
		
		public static GreetingService.Descriptor CreateDescriptor() {
			return new GreetingService.Descriptor();
		} 
		
		public static GreetingService.Descriptor CreateDescriptor(string alias) {
			return new GreetingService.Descriptor(alias);
		}				
	
		public partial interface IUnaryProxy {
			IUnaryMethodCall<global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingResponse> Unary(global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingRequest request);
		}
		
		public partial interface IServerStreamingProxy {
			IServerStreamingMethodCall<global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingResponse> ServerStreaming(global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingRequest request);
		}
		
		public partial interface IClientStreamingProxy {
			IClientStreamingMethodCall<global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingRequest, global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingResponse> ClientStreaming();
		}
		
		public partial interface IDuplexStreamingProxy {
			IDuplexStreamingMethodCall<global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingRequest, global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingResponse> DuplexStreaming();
		}
		
		public partial interface IUnaryImpl {
			Task<global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingResponse> Unary(global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingRequest request, MethodCallContext context);
		}
		
		public partial interface IServerStreamingImpl {
			Task ServerStreaming(global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingRequest request, IWritableChannel<global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingResponse> responseStream, MethodCallContext context);
		}
		
		public partial interface IClientStreamingImpl {
			Task<global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingResponse> ClientStreaming(IReadableChannel<global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingRequest> requestStream, MethodCallContext context);
		}
		
		public partial interface IDuplexStreamingImpl {
			Task DuplexStreaming(IReadableChannel<global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingRequest> requestStream, IWritableChannel<global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingResponse> responseStream, MethodCallContext context);
		}
		
		public sealed partial class Descriptor {
		
			public UnaryMethod<global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingRequest, global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingResponse> UnaryMethod {get; private set; }
			public ServerStreamingMethod<global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingRequest, global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingResponse> ServerStreamingMethod {get; private set; }
			public ClientStreamingMethod<global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingRequest, global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingResponse> ClientStreamingMethod {get; private set; }
			public DuplexStreamingMethod<global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingRequest, global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingResponse> DuplexStreamingMethod {get; private set; }
			
			public Descriptor() {				
				UnaryMethod = Method.Unary<global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingRequest, global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingResponse>(Id, UnaryMethodId);
				ServerStreamingMethod = Method.ServerStreaming<global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingRequest, global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingResponse>(Id, ServerStreamingMethodId);
				ClientStreamingMethod = Method.ClientStreaming<global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingRequest, global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingResponse>(Id, ClientStreamingMethodId);
				DuplexStreamingMethod = Method.DuplexStreaming<global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingRequest, global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingResponse>(Id, DuplexStreamingMethodId);
			}
		
			public Descriptor(string alias) {
				UnaryMethod = Method.Unary<global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingRequest, global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingResponse>(Id, alias, UnaryMethodId);
				ServerStreamingMethod = Method.ServerStreaming<global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingRequest, global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingResponse>(Id, alias, ServerStreamingMethodId);
				ClientStreamingMethod = Method.ClientStreaming<global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingRequest, global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingResponse>(Id, alias, ClientStreamingMethodId);
				DuplexStreamingMethod = Method.DuplexStreaming<global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingRequest, global::Plexus.Interop.Samples.GreetingClient.Generated.GreetingResponse>(Id, alias, DuplexStreamingMethodId);
			}
		}
	}
					
}
#endregion Designer generated code
