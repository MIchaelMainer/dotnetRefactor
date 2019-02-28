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
    /// The interface IListItemRequest.
    /// </summary>
    public partial interface IListItemRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified ListItem using PUT.
        /// </summary>
        /// <param name="listItemToCreate">The ListItem to create.</param>
        /// <returns>The created ListItem.</returns>
        System.Threading.Tasks.Task<ListItem> CreateAsync(ListItem listItemToCreate);        /// <summary>
        /// Creates the specified ListItem using PUT.
        /// </summary>
        /// <param name="listItemToCreate">The ListItem to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created ListItem.</returns>
        System.Threading.Tasks.Task<ListItem> CreateAsync(ListItem listItemToCreate, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the specified ListItem.
        /// </summary>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync();

        /// <summary>
        /// Deletes the specified ListItem.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified ListItem.
        /// </summary>
        /// <returns>The ListItem.</returns>
        System.Threading.Tasks.Task<ListItem> GetAsync();

        /// <summary>
        /// Gets the specified ListItem.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The ListItem.</returns>
        System.Threading.Tasks.Task<ListItem> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Updates the specified ListItem using PATCH.
        /// </summary>
        /// <param name="listItemToUpdate">The ListItem to update.</param>
        /// <returns>The updated ListItem.</returns>
        System.Threading.Tasks.Task<ListItem> UpdateAsync(ListItem listItemToUpdate);

        /// <summary>
        /// Updates the specified ListItem using PATCH.
        /// </summary>
        /// <param name="listItemToUpdate">The ListItem to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The updated ListItem.</returns>
        System.Threading.Tasks.Task<ListItem> UpdateAsync(ListItem listItemToUpdate, CancellationToken cancellationToken);

        /// <summary>
        /// Adds the specified expand value to the request.
        /// </summary>
        /// <param name="value">The expand value.</param>
        /// <returns>The request object to send.</returns>
        IListItemRequest Expand(string value);

        /// <summary>
        /// Adds the specified expand value to the request.
        /// </summary>
        /// <param name="expandExpression">The expression from which to calculate the expand value.</param>
        /// <returns>The request object to send.</returns>
        IListItemRequest Expand(Expression<Func<ListItem, object>> expandExpression);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        IListItemRequest Select(string value);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="selectExpression">The expression from which to calculate the select value.</param>
        /// <returns>The request object to send.</returns>
        IListItemRequest Select(Expression<Func<ListItem, object>> selectExpression);

    }
}
