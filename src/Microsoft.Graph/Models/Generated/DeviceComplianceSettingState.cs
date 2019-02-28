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
    /// The type Device Compliance Setting State.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class DeviceComplianceSettingState : Entity
    {
    
        /// <summary>
        /// Gets or sets setting.
        /// The setting class name and property name.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "setting", Required = Newtonsoft.Json.Required.Default)]
        public string Setting { get; set; }
    
        /// <summary>
        /// Gets or sets setting name.
        /// The Setting Name that is being reported
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "settingName", Required = Newtonsoft.Json.Required.Default)]
        public string SettingName { get; set; }
    
        /// <summary>
        /// Gets or sets device id.
        /// The Device Id that is being reported
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "deviceId", Required = Newtonsoft.Json.Required.Default)]
        public string DeviceId { get; set; }
    
        /// <summary>
        /// Gets or sets device name.
        /// The Device Name that is being reported
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "deviceName", Required = Newtonsoft.Json.Required.Default)]
        public string DeviceName { get; set; }
    
        /// <summary>
        /// Gets or sets user id.
        /// The user Id that is being reported
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "userId", Required = Newtonsoft.Json.Required.Default)]
        public string UserId { get; set; }
    
        /// <summary>
        /// Gets or sets user email.
        /// The User email address that is being reported
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "userEmail", Required = Newtonsoft.Json.Required.Default)]
        public string UserEmail { get; set; }
    
        /// <summary>
        /// Gets or sets user name.
        /// The User Name that is being reported
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "userName", Required = Newtonsoft.Json.Required.Default)]
        public string UserName { get; set; }
    
        /// <summary>
        /// Gets or sets user principal name.
        /// The User PrincipalName that is being reported
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "userPrincipalName", Required = Newtonsoft.Json.Required.Default)]
        public string UserPrincipalName { get; set; }
    
        /// <summary>
        /// Gets or sets device model.
        /// The device model that is being reported
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "deviceModel", Required = Newtonsoft.Json.Required.Default)]
        public string DeviceModel { get; set; }
    
        /// <summary>
        /// Gets or sets state.
        /// The compliance state of the setting. Possible values are: unknown, notApplicable, compliant, remediated, nonCompliant, error, conflict, notAssigned.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "state", Required = Newtonsoft.Json.Required.Default)]
        public ComplianceStatus? State { get; set; }
    
        /// <summary>
        /// Gets or sets compliance grace period expiration date time.
        /// The DateTime when device compliance grace period expires
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "complianceGracePeriodExpirationDateTime", Required = Newtonsoft.Json.Required.Default)]
        public DateTimeOffset? ComplianceGracePeriodExpirationDateTime { get; set; }
    
    }
}

