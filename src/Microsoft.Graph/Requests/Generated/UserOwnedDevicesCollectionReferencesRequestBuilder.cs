// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// **NOTE** This file was generated by a tool and any changes will be overwritten.

// Template Source: Templates\CSharp\Requests\EntityCollectionReferencesRequestBuilder.cs.tt
namespace Microsoft.Graph
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The type UserOwnedDevicesCollectionReferencesRequestBuilder.
    /// </summary>
    public partial class UserOwnedDevicesCollectionReferencesRequestBuilder : BaseRequestBuilder, IUserOwnedDevicesCollectionReferencesRequestBuilder
    {

        /// <summary>
        /// Constructs a new UserOwnedDevicesCollectionReferencesRequestBuilder.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        public UserOwnedDevicesCollectionReferencesRequestBuilder(
            string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public IUserOwnedDevicesCollectionReferencesRequest Request()
        {
            return this.Request(null);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public IUserOwnedDevicesCollectionReferencesRequest Request(IEnumerable<Option> options)
        {
            return new UserOwnedDevicesCollectionReferencesRequest(this.RequestUrl, this.Client, options);
        }
    }
}
