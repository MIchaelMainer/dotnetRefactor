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
    /// The interface IWorkbookTableRowRequest.
    /// </summary>
    public partial interface IWorkbookTableRowRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified WorkbookTableRow using PUT.
        /// </summary>
        /// <param name="workbookTableRowToCreate">The WorkbookTableRow to create.</param>
        /// <returns>The created WorkbookTableRow.</returns>
        System.Threading.Tasks.Task<WorkbookTableRow> CreateAsync(WorkbookTableRow workbookTableRowToCreate);        /// <summary>
        /// Creates the specified WorkbookTableRow using PUT.
        /// </summary>
        /// <param name="workbookTableRowToCreate">The WorkbookTableRow to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created WorkbookTableRow.</returns>
        System.Threading.Tasks.Task<WorkbookTableRow> CreateAsync(WorkbookTableRow workbookTableRowToCreate, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the specified WorkbookTableRow.
        /// </summary>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync();

        /// <summary>
        /// Deletes the specified WorkbookTableRow.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified WorkbookTableRow.
        /// </summary>
        /// <returns>The WorkbookTableRow.</returns>
        System.Threading.Tasks.Task<WorkbookTableRow> GetAsync();

        /// <summary>
        /// Gets the specified WorkbookTableRow.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The WorkbookTableRow.</returns>
        System.Threading.Tasks.Task<WorkbookTableRow> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Updates the specified WorkbookTableRow using PATCH.
        /// </summary>
        /// <param name="workbookTableRowToUpdate">The WorkbookTableRow to update.</param>
        /// <returns>The updated WorkbookTableRow.</returns>
        System.Threading.Tasks.Task<WorkbookTableRow> UpdateAsync(WorkbookTableRow workbookTableRowToUpdate);

        /// <summary>
        /// Updates the specified WorkbookTableRow using PATCH.
        /// </summary>
        /// <param name="workbookTableRowToUpdate">The WorkbookTableRow to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The updated WorkbookTableRow.</returns>
        System.Threading.Tasks.Task<WorkbookTableRow> UpdateAsync(WorkbookTableRow workbookTableRowToUpdate, CancellationToken cancellationToken);

        /// <summary>
        /// Adds the specified expand value to the request.
        /// </summary>
        /// <param name="value">The expand value.</param>
        /// <returns>The request object to send.</returns>
        IWorkbookTableRowRequest Expand(string value);

        /// <summary>
        /// Adds the specified expand value to the request.
        /// </summary>
        /// <param name="expandExpression">The expression from which to calculate the expand value.</param>
        /// <returns>The request object to send.</returns>
        IWorkbookTableRowRequest Expand(Expression<Func<WorkbookTableRow, object>> expandExpression);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        IWorkbookTableRowRequest Select(string value);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="selectExpression">The expression from which to calculate the select value.</param>
        /// <returns>The request object to send.</returns>
        IWorkbookTableRowRequest Select(Expression<Func<WorkbookTableRow, object>> selectExpression);

    }
}
