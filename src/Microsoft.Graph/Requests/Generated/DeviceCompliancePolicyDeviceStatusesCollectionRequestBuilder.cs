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
    /// The type DeviceCompliancePolicyDeviceStatusesCollectionRequestBuilder.
    /// </summary>
    public partial class DeviceCompliancePolicyDeviceStatusesCollectionRequestBuilder : BaseRequestBuilder, IDeviceCompliancePolicyDeviceStatusesCollectionRequestBuilder
    {
        /// <summary>
        /// Constructs a new DeviceCompliancePolicyDeviceStatusesCollectionRequestBuilder.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        public DeviceCompliancePolicyDeviceStatusesCollectionRequestBuilder(
            string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public IDeviceCompliancePolicyDeviceStatusesCollectionRequest Request()
        {
            return this.Request(null);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public IDeviceCompliancePolicyDeviceStatusesCollectionRequest Request(IEnumerable<Option> options)
        {
            return new DeviceCompliancePolicyDeviceStatusesCollectionRequest(this.RequestUrl, this.Client, options);
        }

        /// <summary>
        /// Gets an <see cref="IDeviceComplianceDeviceStatusRequestBuilder"/> for the specified DeviceCompliancePolicyDeviceComplianceDeviceStatus.
        /// </summary>
        /// <param name="id">The ID for the DeviceCompliancePolicyDeviceComplianceDeviceStatus.</param>
        /// <returns>The <see cref="IDeviceComplianceDeviceStatusRequestBuilder"/>.</returns>
        public IDeviceComplianceDeviceStatusRequestBuilder this[string id]
        {
            get
            {
                return new DeviceComplianceDeviceStatusRequestBuilder(this.AppendSegmentToRequestUrl(id), this.Client);
            }
        }

        
    }
}
