﻿// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections;

    /// <summary>
    /// Represents the order hints for each assignee's column in "assigned to" task board for the containing <see cref="PlannerTask"/>. 
    /// </summary>
    public partial class PlannerOrderHintsByAssignee : IEnumerable<KeyValuePair<string, string>>
    {
        /// <summary>
        /// Creates a new instance of PlannerOrderHintsByAssignee.
        /// </summary>
        public PlannerOrderHintsByAssignee()
        {
            this.AdditionalData = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or sets the order hint of an assignee.
        /// </summary>
        /// <param name="userId">User id of the assignee.</param>
        /// <returns>The order hint.</returns>
        public string this[string userId]
        {
            get
            {
                return this.AdditionalData.TryGetValue(userId, out object orderHint) ? orderHint as string : null;
            }

            set
            {
                this.AdditionalData[userId] = value;
            }
        }

        /// <summary>
        /// Returns pairs of assignee user ids and the corresponding order hint for the assignee's column.
        /// </summary>
        /// <returns>Enumeration of user id, order hint pairs.</returns>
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return this.AdditionalData
                .Where(kvp => kvp.Value is string && kvp.Key != CoreConstants.Serialization.ODataType)
                .Select(kvp => new KeyValuePair<string, string>(kvp.Key, (string)kvp.Value))
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
