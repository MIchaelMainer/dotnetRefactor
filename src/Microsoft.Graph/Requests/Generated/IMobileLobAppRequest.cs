// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// **NOTE** This file was generated by a tool and any changes will be overwritten.

// Template Source: Templates\CSharp\Requests\IEntityRequest.cs.tt

namespace Microsoft.Graph
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading;
    using System.Linq.Expressions;

    /// <summary>
    /// The interface IMobileLobAppRequest.
    /// </summary>
    public partial interface IMobileLobAppRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified MobileLobApp using PUT.
        /// </summary>
        /// <param name="mobileLobAppToCreate">The MobileLobApp to create.</param>
        /// <returns>The created MobileLobApp.</returns>
        System.Threading.Tasks.Task<MobileLobApp> CreateAsync(MobileLobApp mobileLobAppToCreate);        /// <summary>
        /// Creates the specified MobileLobApp using PUT.
        /// </summary>
        /// <param name="mobileLobAppToCreate">The MobileLobApp to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created MobileLobApp.</returns>
        System.Threading.Tasks.Task<MobileLobApp> CreateAsync(MobileLobApp mobileLobAppToCreate, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the specified MobileLobApp.
        /// </summary>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync();

        /// <summary>
        /// Deletes the specified MobileLobApp.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified MobileLobApp.
        /// </summary>
        /// <returns>The MobileLobApp.</returns>
        System.Threading.Tasks.Task<MobileLobApp> GetAsync();

        /// <summary>
        /// Gets the specified MobileLobApp.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The MobileLobApp.</returns>
        System.Threading.Tasks.Task<MobileLobApp> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Updates the specified MobileLobApp using PATCH.
        /// </summary>
        /// <param name="mobileLobAppToUpdate">The MobileLobApp to update.</param>
        /// <returns>The updated MobileLobApp.</returns>
        System.Threading.Tasks.Task<MobileLobApp> UpdateAsync(MobileLobApp mobileLobAppToUpdate);

        /// <summary>
        /// Updates the specified MobileLobApp using PATCH.
        /// </summary>
        /// <param name="mobileLobAppToUpdate">The MobileLobApp to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The updated MobileLobApp.</returns>
        System.Threading.Tasks.Task<MobileLobApp> UpdateAsync(MobileLobApp mobileLobAppToUpdate, CancellationToken cancellationToken);

        /// <summary>
        /// Adds the specified expand value to the request.
        /// </summary>
        /// <param name="value">The expand value.</param>
        /// <returns>The request object to send.</returns>
        IMobileLobAppRequest Expand(string value);

        /// <summary>
        /// Adds the specified expand value to the request.
        /// </summary>
        /// <param name="expandExpression">The expression from which to calculate the expand value.</param>
        /// <returns>The request object to send.</returns>
        IMobileLobAppRequest Expand(Expression<Func<MobileLobApp, object>> expandExpression);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        IMobileLobAppRequest Select(string value);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="selectExpression">The expression from which to calculate the select value.</param>
        /// <returns>The request object to send.</returns>
        IMobileLobAppRequest Select(Expression<Func<MobileLobApp, object>> selectExpression);

    }
}
