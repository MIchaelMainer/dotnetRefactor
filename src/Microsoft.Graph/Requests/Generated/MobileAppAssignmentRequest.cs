// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// **NOTE** This file was generated by a tool and any changes will be overwritten.

// Template Source: Templates\CSharp\Requests\EntityRequest.cs.tt

namespace Microsoft.Graph
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Threading;
    using System.Linq.Expressions;

    /// <summary>
    /// The type MobileAppAssignmentRequest.
    /// </summary>
    public partial class MobileAppAssignmentRequest : BaseRequest, IMobileAppAssignmentRequest
    {
        /// <summary>
        /// Constructs a new MobileAppAssignmentRequest.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="options">Query and header option name value pairs for the request.</param>
        public MobileAppAssignmentRequest(
            string requestUrl,
            IBaseClient client,
            IEnumerable<Option> options)
            : base(requestUrl, client, options)
        {
        }

        /// <summary>
        /// Creates the specified MobileAppAssignment using POST.
        /// </summary>
        /// <param name="mobileAppAssignmentToCreate">The MobileAppAssignment to create.</param>
        /// <returns>The created MobileAppAssignment.</returns>
        public System.Threading.Tasks.Task<MobileAppAssignment> CreateAsync(MobileAppAssignment mobileAppAssignmentToCreate)
        {
            return this.CreateAsync(mobileAppAssignmentToCreate, CancellationToken.None);
        }

        /// <summary>
        /// Creates the specified MobileAppAssignment using POST.
        /// </summary>
        /// <param name="mobileAppAssignmentToCreate">The MobileAppAssignment to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created MobileAppAssignment.</returns>
        public async System.Threading.Tasks.Task<MobileAppAssignment> CreateAsync(MobileAppAssignment mobileAppAssignmentToCreate, CancellationToken cancellationToken)
        {
            this.ContentType = "application/json";
            this.Method = "POST";
            var newEntity = await this.SendAsync<MobileAppAssignment>(mobileAppAssignmentToCreate, cancellationToken).ConfigureAwait(false);
            this.InitializeCollectionProperties(newEntity);
            return newEntity;
        }

        /// <summary>
        /// Deletes the specified MobileAppAssignment.
        /// </summary>
        /// <returns>The task to await.</returns>
        public System.Threading.Tasks.Task DeleteAsync()
        {
            return this.DeleteAsync(CancellationToken.None);
        }

        /// <summary>
        /// Deletes the specified MobileAppAssignment.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        public async System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken)
        {
            this.Method = "DELETE";
            await this.SendAsync<MobileAppAssignment>(null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified MobileAppAssignment.
        /// </summary>
        /// <returns>The MobileAppAssignment.</returns>
        public System.Threading.Tasks.Task<MobileAppAssignment> GetAsync()
        {
            return this.GetAsync(CancellationToken.None);
        }

        /// <summary>
        /// Gets the specified MobileAppAssignment.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The MobileAppAssignment.</returns>
        public async System.Threading.Tasks.Task<MobileAppAssignment> GetAsync(CancellationToken cancellationToken)
        {
            this.Method = "GET";
            var retrievedEntity = await this.SendAsync<MobileAppAssignment>(null, cancellationToken).ConfigureAwait(false);
            this.InitializeCollectionProperties(retrievedEntity);
            return retrievedEntity;
        }

        /// <summary>
        /// Updates the specified MobileAppAssignment using PATCH.
        /// </summary>
        /// <param name="mobileAppAssignmentToUpdate">The MobileAppAssignment to update.</param>
        /// <returns>The updated MobileAppAssignment.</returns>
        public System.Threading.Tasks.Task<MobileAppAssignment> UpdateAsync(MobileAppAssignment mobileAppAssignmentToUpdate)
        {
            return this.UpdateAsync(mobileAppAssignmentToUpdate, CancellationToken.None);
        }

        /// <summary>
        /// Updates the specified MobileAppAssignment using PATCH.
        /// </summary>
        /// <param name="mobileAppAssignmentToUpdate">The MobileAppAssignment to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The updated MobileAppAssignment.</returns>
        public async System.Threading.Tasks.Task<MobileAppAssignment> UpdateAsync(MobileAppAssignment mobileAppAssignmentToUpdate, CancellationToken cancellationToken)
        {
            this.ContentType = "application/json";
            this.Method = "PATCH";
            var updatedEntity = await this.SendAsync<MobileAppAssignment>(mobileAppAssignmentToUpdate, cancellationToken).ConfigureAwait(false);
            this.InitializeCollectionProperties(updatedEntity);
            return updatedEntity;
        }

        /// <summary>
        /// Adds the specified expand value to the request.
        /// </summary>
        /// <param name="value">The expand value.</param>
        /// <returns>The request object to send.</returns>
        public IMobileAppAssignmentRequest Expand(string value)
        {
            this.QueryOptions.Add(new QueryOption("$expand", value));
            return this;
        }

        /// <summary>
        /// Adds the specified expand value to the request.
        /// </summary>
        /// <param name="expandExpression">The expression from which to calculate the expand value.</param>
        /// <returns>The request object to send.</returns>
        public IMobileAppAssignmentRequest Expand(Expression<Func<MobileAppAssignment, object>> expandExpression)
        {
		    if (expandExpression == null)
            {
                throw new ArgumentNullException(nameof(expandExpression));
            }
            string error;
            string value = ExpressionExtractHelper.ExtractMembers(expandExpression, out error);
            if (value == null)
            {
                throw new ArgumentException(error, nameof(expandExpression));
            }
            else
            {
                this.QueryOptions.Add(new QueryOption("$expand", value));
            }
            return this;
        }

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        public IMobileAppAssignmentRequest Select(string value)
        {
            this.QueryOptions.Add(new QueryOption("$select", value));
            return this;
        }

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="selectExpression">The expression from which to calculate the select value.</param>
        /// <returns>The request object to send.</returns>
        public IMobileAppAssignmentRequest Select(Expression<Func<MobileAppAssignment, object>> selectExpression)
        {
            if (selectExpression == null)
            {
                throw new ArgumentNullException(nameof(selectExpression));
            }
            string error;
            string value = ExpressionExtractHelper.ExtractMembers(selectExpression, out error);
            if (value == null)
            {
                throw new ArgumentException(error, nameof(selectExpression));
            }
            else
            {
                this.QueryOptions.Add(new QueryOption("$select", value));
            }
            return this;
        }

        /// <summary>
        /// Initializes any collection properties after deserialization, like next requests for paging.
        /// </summary>
        /// <param name="mobileAppAssignmentToInitialize">The <see cref="MobileAppAssignment"/> with the collection properties to initialize.</param>
        private void InitializeCollectionProperties(MobileAppAssignment mobileAppAssignmentToInitialize)
        {

        }
    }
}
