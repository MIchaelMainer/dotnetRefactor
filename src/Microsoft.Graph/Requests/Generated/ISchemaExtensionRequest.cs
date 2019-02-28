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
    /// The interface ISchemaExtensionRequest.
    /// </summary>
    public partial interface ISchemaExtensionRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified SchemaExtension using PUT.
        /// </summary>
        /// <param name="schemaExtensionToCreate">The SchemaExtension to create.</param>
        /// <returns>The created SchemaExtension.</returns>
        System.Threading.Tasks.Task<SchemaExtension> CreateAsync(SchemaExtension schemaExtensionToCreate);        /// <summary>
        /// Creates the specified SchemaExtension using PUT.
        /// </summary>
        /// <param name="schemaExtensionToCreate">The SchemaExtension to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created SchemaExtension.</returns>
        System.Threading.Tasks.Task<SchemaExtension> CreateAsync(SchemaExtension schemaExtensionToCreate, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the specified SchemaExtension.
        /// </summary>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync();

        /// <summary>
        /// Deletes the specified SchemaExtension.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified SchemaExtension.
        /// </summary>
        /// <returns>The SchemaExtension.</returns>
        System.Threading.Tasks.Task<SchemaExtension> GetAsync();

        /// <summary>
        /// Gets the specified SchemaExtension.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The SchemaExtension.</returns>
        System.Threading.Tasks.Task<SchemaExtension> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Updates the specified SchemaExtension using PATCH.
        /// </summary>
        /// <param name="schemaExtensionToUpdate">The SchemaExtension to update.</param>
        /// <returns>The updated SchemaExtension.</returns>
        System.Threading.Tasks.Task<SchemaExtension> UpdateAsync(SchemaExtension schemaExtensionToUpdate);

        /// <summary>
        /// Updates the specified SchemaExtension using PATCH.
        /// </summary>
        /// <param name="schemaExtensionToUpdate">The SchemaExtension to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The updated SchemaExtension.</returns>
        System.Threading.Tasks.Task<SchemaExtension> UpdateAsync(SchemaExtension schemaExtensionToUpdate, CancellationToken cancellationToken);

        /// <summary>
        /// Adds the specified expand value to the request.
        /// </summary>
        /// <param name="value">The expand value.</param>
        /// <returns>The request object to send.</returns>
        ISchemaExtensionRequest Expand(string value);

        /// <summary>
        /// Adds the specified expand value to the request.
        /// </summary>
        /// <param name="expandExpression">The expression from which to calculate the expand value.</param>
        /// <returns>The request object to send.</returns>
        ISchemaExtensionRequest Expand(Expression<Func<SchemaExtension, object>> expandExpression);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        ISchemaExtensionRequest Select(string value);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="selectExpression">The expression from which to calculate the select value.</param>
        /// <returns>The request object to send.</returns>
        ISchemaExtensionRequest Select(Expression<Func<SchemaExtension, object>> selectExpression);

    }
}
