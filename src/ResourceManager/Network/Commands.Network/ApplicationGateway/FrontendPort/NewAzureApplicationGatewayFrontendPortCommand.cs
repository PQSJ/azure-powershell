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

using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureApplicationGatewayFrontendPort"), OutputType(typeof(PSApplicationGatewayFrontendPort))]
    public class NewAzureApplicationGatewayFrontendPortCommand : NetworkBaseCmdlet
    {
        [Parameter(
                Mandatory = true,
               HelpMessage = "The name of the frontend port")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
               Mandatory = true,
               HelpMessage = "Frontend port")]
        [ValidateNotNullOrEmpty]
        public int Port { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var frontendPort = new PSApplicationGatewayFrontendPort();
            frontendPort.Name = this.Name;
            frontendPort.Port = this.Port;

            frontendPort.Id =
                ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                    this.NetworkClient.NetworkResourceProviderClient.Credentials.SubscriptionId,
                    Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayFrontendPortName,
                    this.Name);

            WriteObject(frontendPort);
        }
    }
}