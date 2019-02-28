// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// **NOTE** This file was generated by a tool and any changes will be overwritten.

// Template Source: Templates\CSharp\Model\ComplexType.cs.tt

namespace Microsoft.Graph
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// The type MicrosoftStoreForBusinessAppAssignmentSettings.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class MicrosoftStoreForBusinessAppAssignmentSettings : MobileAppAssignmentSettings
    {
        public MicrosoftStoreForBusinessAppAssignmentSettings()
        {
            this.ODataType = "microsoft.graph.microsoftStoreForBusinessAppAssignmentSettings";
        }
        /// <summary>
        /// Gets or sets useDeviceContext.
        /// Whether or not to use device execution context for Microsoft Store for Business mobile app.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "useDeviceContext", Required = Newtonsoft.Json.Required.Default)]
        public bool? UseDeviceContext { get; set; }
    
    }
}
