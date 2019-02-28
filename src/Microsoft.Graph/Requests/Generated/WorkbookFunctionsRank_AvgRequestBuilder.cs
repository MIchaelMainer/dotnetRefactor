// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// **NOTE** This file was generated by a tool and any changes will be overwritten.

// Template Source: Templates\CSharp\Requests\MethodRequestBuilder.cs.tt

namespace Microsoft.Graph
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// The type WorkbookFunctionsRank_AvgRequestBuilder.
    /// </summary>
    public partial class WorkbookFunctionsRank_AvgRequestBuilder : BaseActionMethodRequestBuilder<IWorkbookFunctionsRank_AvgRequest>, IWorkbookFunctionsRank_AvgRequestBuilder
    {
        /// <summary>
        /// Constructs a new <see cref="WorkbookFunctionsRank_AvgRequestBuilder"/>.
        /// </summary>
        /// <param name="requestUrl">The URL for the request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="number">A number parameter for the OData method call.</param>
        /// <param name="@ref">A @ref parameter for the OData method call.</param>
        /// <param name="order">A order parameter for the OData method call.</param>
        public WorkbookFunctionsRank_AvgRequestBuilder(
            string requestUrl,
            IBaseClient client,
            Newtonsoft.Json.Linq.JToken number,
            Newtonsoft.Json.Linq.JToken @ref,
            Newtonsoft.Json.Linq.JToken order)
            : base(requestUrl, client)
        {
            this.SetParameter("number", number, true);
            this.SetParameter("ref", @ref, true);
            this.SetParameter("order", order, true);
        }

        /// <summary>
        /// A method used by the base class to construct a request class instance.
        /// </summary>
        /// <param name="functionUrl">The request URL to </param>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>An instance of a specific request class.</returns>
        protected override IWorkbookFunctionsRank_AvgRequest CreateRequest(string functionUrl, IEnumerable<Option> options)
        {
            var request = new WorkbookFunctionsRank_AvgRequest(functionUrl, this.Client, options);

            if (this.HasParameter("number"))
            {
                request.RequestBody.Number = this.GetParameter<Newtonsoft.Json.Linq.JToken>("number");
            }

            if (this.HasParameter("ref"))
            {
                request.RequestBody.Ref = this.GetParameter<Newtonsoft.Json.Linq.JToken>("ref");
            }

            if (this.HasParameter("order"))
            {
                request.RequestBody.Order = this.GetParameter<Newtonsoft.Json.Linq.JToken>("order");
            }

            return request;
        }
    }
}
