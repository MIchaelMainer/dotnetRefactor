// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// **NOTE** This file was generated by a tool and any changes will be overwritten.

// Template Source: Templates\CSharp\Model\EnumType.cs.tt


namespace Microsoft.Graph
{
    using Newtonsoft.Json;

    /// <summary>
    /// The enum IosUpdatesInstallStatus.
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum IosUpdatesInstallStatus
    {
    
        /// <summary>
        /// success
        /// </summary>
        Success = 0,
	
        /// <summary>
        /// available
        /// </summary>
        Available = 1,
	
        /// <summary>
        /// idle
        /// </summary>
        Idle = 2,
	
        /// <summary>
        /// unknown
        /// </summary>
        Unknown = 3,
	
        /// <summary>
        /// downloading
        /// </summary>
        Downloading = -2016330712,
	
        /// <summary>
        /// download Failed
        /// </summary>
        DownloadFailed = -2016330711,
	
        /// <summary>
        /// download Requires Computer
        /// </summary>
        DownloadRequiresComputer = -2016330710,
	
        /// <summary>
        /// download Insufficient Space
        /// </summary>
        DownloadInsufficientSpace = -2016330709,
	
        /// <summary>
        /// download Insufficient Power
        /// </summary>
        DownloadInsufficientPower = -2016330708,
	
        /// <summary>
        /// download Insufficient Network
        /// </summary>
        DownloadInsufficientNetwork = -2016330707,
	
        /// <summary>
        /// installing
        /// </summary>
        Installing = -2016330706,
	
        /// <summary>
        /// install Insufficient Space
        /// </summary>
        InstallInsufficientSpace = -2016330705,
	
        /// <summary>
        /// install Insufficient Power
        /// </summary>
        InstallInsufficientPower = -2016330704,
	
        /// <summary>
        /// install Phone Call In Progress
        /// </summary>
        InstallPhoneCallInProgress = -2016330703,
	
        /// <summary>
        /// install Failed
        /// </summary>
        InstallFailed = -2016330702,
	
        /// <summary>
        /// not Supported Operation
        /// </summary>
        NotSupportedOperation = -2016330701,
	
        /// <summary>
        /// shared Device User Logged In Error
        /// </summary>
        SharedDeviceUserLoggedInError = -2016330699,
	
    }
}
