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
    /// The type DeviceAppManagementMobileAppConfigurationsCollectionRequestBuilder.
    /// </summary>
    public partial class DeviceAppManagementMobileAppConfigurationsCollectionRequestBuilder : BaseRequestBuilder, IDeviceAppManagementMobileAppConfigurationsCollectionRequestBuilder
    {
        /// <summary>
        /// Constructs a new DeviceAppManagementMobileAppConfigurationsCollectionRequestBuilder.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        public DeviceAppManagementMobileAppConfigurationsCollectionRequestBuilder(
            string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public IDeviceAppManagementMobileAppConfigurationsCollectionRequest Request()
        {
            return this.Request(null);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public IDeviceAppManagementMobileAppConfigurationsCollectionRequest Request(IEnumerable<Option> options)
        {
            return new DeviceAppManagementMobileAppConfigurationsCollectionRequest(this.RequestUrl, this.Client, options);
        }

        /// <summary>
        /// Gets an <see cref="IManagedDeviceMobileAppConfigurationRequestBuilder"/> for the specified DeviceAppManagementManagedDeviceMobileAppConfiguration.
        /// </summary>
        /// <param name="id">The ID for the DeviceAppManagementManagedDeviceMobileAppConfiguration.</param>
        /// <returns>The <see cref="IManagedDeviceMobileAppConfigurationRequestBuilder"/>.</returns>
        public IManagedDeviceMobileAppConfigurationRequestBuilder this[string id]
        {
            get
            {
                return new ManagedDeviceMobileAppConfigurationRequestBuilder(this.AppendSegmentToRequestUrl(id), this.Client);
            }
        }

        
    }
}
