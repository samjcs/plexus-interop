/**
 * Copyright 2017-2018 Plexus Interop Deutsche Bank AG
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
﻿using Plexus.Pools;
using Plexus.Interop.Protocol.Connect;
using System.Collections.Generic;

namespace Plexus.Interop.Protocol.Internal.Connect
{
    internal sealed class ConnectResponse : PooledObject<ConnectResponse>, IConnectResponse
    {
        public UniqueId ConnectionId { get; set; }

        public override bool Equals(object obj)
        {
            var response = obj as ConnectResponse;
            return response != null &&
                   ConnectionId.Equals(response.ConnectionId);
        }

        public override int GetHashCode()
        {
            return -463474436 + EqualityComparer<UniqueId>.Default.GetHashCode(ConnectionId);
        }

        public override string ToString()
        {
            return $"{{{nameof(ConnectionId)}: {ConnectionId}}}";
        }

        protected override void Cleanup()
        {
            ConnectionId = default;
        }
    }
}