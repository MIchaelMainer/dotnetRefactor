// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// **NOTE** This file was generated by a tool and any changes will be overwritten.

// Template Source: Templates\CSharp\Requests\IEntityCollectionRequestBuilder.cs.tt
namespace Microsoft.Graph
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The interface ITermsAndConditionsAssignmentsCollectionRequestBuilder.
    /// </summary>
    public partial interface ITermsAndConditionsAssignmentsCollectionRequestBuilder
    {
        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        ITermsAndConditionsAssignmentsCollectionRequest Request();

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        ITermsAndConditionsAssignmentsCollectionRequest Request(IEnumerable<Option> options);

        /// <summary>
        /// Gets an <see cref="ITermsAndConditionsAssignmentRequestBuilder"/> for the specified TermsAndConditionsAssignment.
        /// </summary>
        /// <param name="id">The ID for the TermsAndConditionsAssignment.</param>
        /// <returns>The <see cref="ITermsAndConditionsAssignmentRequestBuilder"/>.</returns>
        ITermsAndConditionsAssignmentRequestBuilder this[string id] { get; }

        
    }
}
