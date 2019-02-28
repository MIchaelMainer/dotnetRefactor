﻿// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Core.Test.TestModels
{
    using Newtonsoft.Json;
    using System.Runtime.Serialization;

    /// <summary>
    /// Test class for testing serialization of an IEnumerable of Date.
    /// </summary>
    [JsonObject]
    public class CollectionPageInstance : CollectionPage<DerivedTypeClass>, ICollectionPageInstance
    {
    }
}
