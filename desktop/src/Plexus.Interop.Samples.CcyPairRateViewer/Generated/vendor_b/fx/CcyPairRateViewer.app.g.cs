/**
 * Copyright 2017-2020 Plexus Interop Deutsche Bank AG
 * SPDX-License-Identifier: Apache-2.0
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
// <auto-generated>
// 	Generated by the Plexus Interop compiler.  DO NOT EDIT!
// 	source: vendor_b\fx\ccy_pair_rate_viewer.interop
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code
namespace Plexus.Interop.Samples.CcyPairRateViewer.Generated {
	
	using System;
	using global::Plexus;
	using global::Plexus.Channels;
	using global::Plexus.Interop;
	using global::System.Threading.Tasks;
					
					
	public partial interface ICcyPairRateViewerClient: IClient {
		CcyPairRateViewerClient.ICcyPairRateServiceProxy CcyPairRateService { get; }
	}
	
	public sealed partial class CcyPairRateViewerClient: ClientBase, ICcyPairRateViewerClient {
		
		public const string Id = "vendor_b.fx.CcyPairRateViewer";
		
		private static ClientOptions CreateClientOptions(Func<ClientOptionsBuilder, ClientOptionsBuilder> setup = null) {
			ClientOptionsBuilder builder = new ClientOptionsBuilder().WithApplicationId(Id).WithDefaultConfiguration();
			if (setup != null) {
				builder = setup(builder);
			}									
			return builder.Build();					
		}
		
		public CcyPairRateViewerClient(Func<ClientOptionsBuilder, ClientOptionsBuilder> setup = null): base(CreateClientOptions(setup)) 
		{ 
			CcyPairRateService = new CcyPairRateViewerClient.CcyPairRateServiceProxy(this.CallInvoker);
		}
		
		public partial interface ICcyPairRateServiceProxy:
			global::Plexus.Interop.Samples.CcyPairRateViewer.Generated.CcyPairRateService.IGetRateProxy
		{ }
		
		public sealed partial class CcyPairRateServiceProxy: ICcyPairRateServiceProxy {
			
			public static global::Plexus.Interop.Samples.CcyPairRateViewer.Generated.CcyPairRateService.Descriptor Descriptor = global::Plexus.Interop.Samples.CcyPairRateViewer.Generated.CcyPairRateService.DefaultDescriptor;
			
			private readonly IClientCallInvoker _callInvoker;
									
			public CcyPairRateServiceProxy(IClientCallInvoker callInvoker) {
				_callInvoker = callInvoker;
			}						
			
			public IUnaryMethodCall<global::Plexus.Interop.Samples.CcyPairRateViewer.Generated.CcyPairRate> GetRate(global::Plexus.Interop.Samples.CcyPairRateViewer.Generated.CcyPair request) {
				return _callInvoker.Call(Descriptor.GetRateMethod, request);
			}
		}
		
		public ICcyPairRateServiceProxy CcyPairRateService { get; private set; }
	}
}
#endregion Designer generated code