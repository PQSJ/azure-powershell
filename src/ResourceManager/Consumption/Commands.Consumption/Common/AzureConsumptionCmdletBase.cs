﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Consumption;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Consumption.Common
{
    /// <summary>
    /// Base class of Azure Consumption Cmdlet.
    /// </summary>
    public abstract class AzureConsumptionCmdletBase : AzureRMCmdlet
    {
        private IConsumptionManagementClient _consumptionManagementClient;

        private Dictionary<string, List<string>> _defaultRequestHeaders;

        /// <summary>
        /// Gets or sets the Consumption management client.
        /// </summary>
        public IConsumptionManagementClient ConsumptionManagementClient
        {
            get
            {
                return _consumptionManagementClient ??
                       (_consumptionManagementClient =
                           AzureSession.ClientFactory.CreateArmClient<ConsumptionManagementClient>(DefaultProfile.Context,
                               AzureEnvironment.Endpoint.ResourceManager));
            }
            set { _consumptionManagementClient = value; }
        }
    }
}
