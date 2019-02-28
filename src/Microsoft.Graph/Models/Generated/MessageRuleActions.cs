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
    /// The type MessageRuleActions.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    [JsonConverter(typeof(DerivedTypeConverter))]
    public partial class MessageRuleActions
    {

        /// <summary>
        /// Gets or sets moveToFolder.
        /// The ID of the folder that a message will be moved to.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "moveToFolder", Required = Newtonsoft.Json.Required.Default)]
        public string MoveToFolder { get; set; }
    
        /// <summary>
        /// Gets or sets copyToFolder.
        /// The ID of a folder that a message is to be copied to.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "copyToFolder", Required = Newtonsoft.Json.Required.Default)]
        public string CopyToFolder { get; set; }
    
        /// <summary>
        /// Gets or sets delete.
        /// Indicates whether a message should be moved to the Deleted Items folder.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "delete", Required = Newtonsoft.Json.Required.Default)]
        public bool? Delete { get; set; }
    
        /// <summary>
        /// Gets or sets permanentDelete.
        /// Indicates whether a message should be permanently deleted and not saved to the Deleted Items folder.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "permanentDelete", Required = Newtonsoft.Json.Required.Default)]
        public bool? PermanentDelete { get; set; }
    
        /// <summary>
        /// Gets or sets markAsRead.
        /// Indicates whether a message should be marked as read.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "markAsRead", Required = Newtonsoft.Json.Required.Default)]
        public bool? MarkAsRead { get; set; }
    
        /// <summary>
        /// Gets or sets markImportance.
        /// Sets the importance of the message, which can be: low, normal, high.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "markImportance", Required = Newtonsoft.Json.Required.Default)]
        public Importance? MarkImportance { get; set; }
    
        /// <summary>
        /// Gets or sets forwardTo.
        /// The email addresses of the recipients to which a message should be forwarded.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "forwardTo", Required = Newtonsoft.Json.Required.Default)]
        public IEnumerable<Recipient> ForwardTo { get; set; }
    
        /// <summary>
        /// Gets or sets forwardAsAttachmentTo.
        /// The email addresses of the recipients to which a message should be forwarded as an attachment.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "forwardAsAttachmentTo", Required = Newtonsoft.Json.Required.Default)]
        public IEnumerable<Recipient> ForwardAsAttachmentTo { get; set; }
    
        /// <summary>
        /// Gets or sets redirectTo.
        /// The email addresses to which a message should be redirected.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "redirectTo", Required = Newtonsoft.Json.Required.Default)]
        public IEnumerable<Recipient> RedirectTo { get; set; }
    
        /// <summary>
        /// Gets or sets assignCategories.
        /// A list of categories to be assigned to a message.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "assignCategories", Required = Newtonsoft.Json.Required.Default)]
        public IEnumerable<string> AssignCategories { get; set; }
    
        /// <summary>
        /// Gets or sets stopProcessingRules.
        /// Indicates whether subsequent rules should be evaluated.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "stopProcessingRules", Required = Newtonsoft.Json.Required.Default)]
        public bool? StopProcessingRules { get; set; }
    
        /// <summary>
        /// Gets or sets additional data.
        /// </summary>
        [JsonExtensionData(ReadData = true)]
        public IDictionary<string, object> AdditionalData { get; set; }

        /// <summary>
        /// Gets or sets @odata.type.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "@odata.type", Required = Newtonsoft.Json.Required.Default)]
        public string ODataType { get; set; }
    
    }
}
