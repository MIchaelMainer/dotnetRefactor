// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// **NOTE** This file was generated by a tool and any changes will be overwritten.

// Template Source: Templates\CSharp\Model\EnumType.cs.tt


namespace Microsoft.Graph
{
    using Newtonsoft.Json;

    /// <summary>
    /// The enum OnenoteUserRole.
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum OnenoteUserRole
    {
    
        /// <summary>
        /// Owner
        /// </summary>
        Owner = 0,
	
        /// <summary>
        /// Contributor
        /// </summary>
        Contributor = 1,
	
        /// <summary>
        /// Reader
        /// </summary>
        Reader = 2,
	
        /// <summary>
        /// None
        /// </summary>
        None = -1,
	
    }
}
