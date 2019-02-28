// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// **NOTE** This file was generated by a tool and any changes will be overwritten.

// Template Source: Templates\CSharp\Requests\EntityCollectionPage.cs.tt

namespace Microsoft.Graph
{
    using System;

    /// <summary>
    /// The type PostExtensionsCollectionPage.
    /// </summary>
    public partial class PostExtensionsCollectionPage : CollectionPage<Extension>, IPostExtensionsCollectionPage
    {
        /// <summary>
        /// Gets the next page <see cref="IPostExtensionsCollectionRequest"/> instance.
        /// </summary>
        public IPostExtensionsCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                this.NextPageRequest = new PostExtensionsCollectionRequest(
                    nextPageLinkString,
                    client,
                    null);
            }
        }
    }
}
