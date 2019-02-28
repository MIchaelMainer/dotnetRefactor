// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// **NOTE** This file was generated by a tool and any changes will be overwritten.

// Template Source: Templates\CSharp\Model\EnumType.cs.tt


namespace Microsoft.Graph
{
    using Newtonsoft.Json;

    /// <summary>
    /// The enum PhoneType.
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum PhoneType
    {
    
        /// <summary>
        /// home
        /// </summary>
        Home = 0,
	
        /// <summary>
        /// business
        /// </summary>
        Business = 1,
	
        /// <summary>
        /// mobile
        /// </summary>
        Mobile = 2,
	
        /// <summary>
        /// other
        /// </summary>
        Other = 3,
	
        /// <summary>
        /// assistant
        /// </summary>
        Assistant = 4,
	
        /// <summary>
        /// home Fax
        /// </summary>
        HomeFax = 5,
	
        /// <summary>
        /// business Fax
        /// </summary>
        BusinessFax = 6,
	
        /// <summary>
        /// other Fax
        /// </summary>
        OtherFax = 7,
	
        /// <summary>
        /// pager
        /// </summary>
        Pager = 8,
	
        /// <summary>
        /// radio
        /// </summary>
        Radio = 9,
	
    }
}
