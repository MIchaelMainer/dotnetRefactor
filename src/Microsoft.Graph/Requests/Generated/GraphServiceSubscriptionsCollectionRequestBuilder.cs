// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// **NOTE** This file was generated by a tool and any changes will be overwritten.

// Template Source: Templates\CSharp\Requests\EntityCollectionRequestBuilder.cs.tt
namespace Microsoft.Graph
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The type GraphServiceSubscriptionsCollectionRequestBuilder.
    /// </summary>
    public partial class GraphServiceSubscriptionsCollectionRequestBuilder : BaseRequestBuilder, IGraphServiceSubscriptionsCollectionRequestBuilder
    {
        /// <summary>
        /// Constructs a new GraphServiceSubscriptionsCollectionRequestBuilder.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        public GraphServiceSubscriptionsCollectionRequestBuilder(
            string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public IGraphServiceSubscriptionsCollectionRequest Request()
        {
            return this.Request(null);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public IGraphServiceSubscriptionsCollectionRequest Request(IEnumerable<Option> options)
        {
            return new GraphServiceSubscriptionsCollectionRequest(this.RequestUrl, this.Client, options);
        }

        /// <summary>
        /// Gets an <see cref="ISubscriptionRequestBuilder"/> for the specified GraphServiceSubscription.
        /// </summary>
        /// <param name="id">The ID for the GraphServiceSubscription.</param>
        /// <returns>The <see cref="ISubscriptionRequestBuilder"/>.</returns>
        public ISubscriptionRequestBuilder this[string id]
        {
            get
            {
                return new SubscriptionRequestBuilder(this.AppendSegmentToRequestUrl(id), this.Client);
            }
        }

        
    }
}
