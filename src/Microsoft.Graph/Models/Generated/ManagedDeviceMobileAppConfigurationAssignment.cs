// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// **NOTE** This file was generated by a tool and any changes will be overwritten.

// Template Source: Templates\CSharp\Model\EntityType.cs.tt

namespace Microsoft.Graph
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// The type Managed Device Mobile App Configuration Assignment.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class ManagedDeviceMobileAppConfigurationAssignment : Entity
    {
    
        /// <summary>
        /// Gets or sets target.
        /// Assignment target that the T&amp;C policy is assigned to.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "target", Required = Newtonsoft.Json.Required.Default)]
        public DeviceAndAppManagementAssignmentTarget Target { get; set; }
    
    }
}

