// <auto-generated>
// 	Generated by the Plexus Interop compiler.  DO NOT EDIT!
// 	source: interop\app_lifecycle_service.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code
namespace Plexus.Interop.Apps.Internal.Generated {
	
	using System;
	using global::Plexus;
	using global::Plexus.Channels;
	using global::Plexus.Interop;
	using global::System.Threading.Tasks;
					
	internal static partial class AppLifecycleService {
		
		public const string Id = "interop.AppLifecycleService";			
		public const string ResolveAppMethodId = "ResolveApp";
		public const string GetLifecycleEventStreamMethodId = "GetLifecycleEventStream";
		
		public static readonly AppLifecycleService.Descriptor DefaultDescriptor = CreateDescriptor();
		
		public static AppLifecycleService.Descriptor CreateDescriptor() {
			return new AppLifecycleService.Descriptor();
		} 
		
		public static AppLifecycleService.Descriptor CreateDescriptor(string alias) {
			return new AppLifecycleService.Descriptor(alias);
		}				
	
		public partial interface IResolveAppProxy {
			IUnaryMethodCall<global::Plexus.Interop.Apps.Internal.Generated.ResolveAppResponse> ResolveApp(global::Plexus.Interop.Apps.Internal.Generated.ResolveAppRequest request);
		}
		
		public partial interface IGetLifecycleEventStreamProxy {
			IServerStreamingMethodCall<global::Plexus.Interop.Apps.Internal.Generated.AppLifecycleEvent> GetLifecycleEventStream(global::Google.Protobuf.WellKnownTypes.Empty request);
		}
		
		public partial interface IResolveAppImpl {
			Task<global::Plexus.Interop.Apps.Internal.Generated.ResolveAppResponse> ResolveApp(global::Plexus.Interop.Apps.Internal.Generated.ResolveAppRequest request, MethodCallContext context);
		}
		
		public partial interface IGetLifecycleEventStreamImpl {
			Task GetLifecycleEventStream(global::Google.Protobuf.WellKnownTypes.Empty request, IWritableChannel<global::Plexus.Interop.Apps.Internal.Generated.AppLifecycleEvent> responseStream, MethodCallContext context);
		}
		
		public sealed partial class Descriptor {
		
			public UnaryMethod<global::Plexus.Interop.Apps.Internal.Generated.ResolveAppRequest, global::Plexus.Interop.Apps.Internal.Generated.ResolveAppResponse> ResolveAppMethod {get; private set; }
			public ServerStreamingMethod<global::Google.Protobuf.WellKnownTypes.Empty, global::Plexus.Interop.Apps.Internal.Generated.AppLifecycleEvent> GetLifecycleEventStreamMethod {get; private set; }
			
			public Descriptor() {				
				ResolveAppMethod = Method.Unary<global::Plexus.Interop.Apps.Internal.Generated.ResolveAppRequest, global::Plexus.Interop.Apps.Internal.Generated.ResolveAppResponse>(Id, ResolveAppMethodId);
				GetLifecycleEventStreamMethod = Method.ServerStreaming<global::Google.Protobuf.WellKnownTypes.Empty, global::Plexus.Interop.Apps.Internal.Generated.AppLifecycleEvent>(Id, GetLifecycleEventStreamMethodId);
			}
		
			public Descriptor(string alias) {
				ResolveAppMethod = Method.Unary<global::Plexus.Interop.Apps.Internal.Generated.ResolveAppRequest, global::Plexus.Interop.Apps.Internal.Generated.ResolveAppResponse>(Id, alias, ResolveAppMethodId);
				GetLifecycleEventStreamMethod = Method.ServerStreaming<global::Google.Protobuf.WellKnownTypes.Empty, global::Plexus.Interop.Apps.Internal.Generated.AppLifecycleEvent>(Id, alias, GetLifecycleEventStreamMethodId);
			}
		}
	}
					
}
#endregion Designer generated code
