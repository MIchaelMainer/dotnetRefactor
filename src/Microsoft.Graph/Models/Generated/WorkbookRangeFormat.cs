// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// **NOTE** This file was generated by a tool and any changes will be overwritten.

// Template Source: Templates\CSharp\Model\EntityType.cs.tt

namespace Microsoft.Graph
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// The type Workbook Range Format.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class WorkbookRangeFormat : Entity
    {
    
        /// <summary>
        /// Gets or sets column width.
        /// Gets or sets the width of all colums within the range. If the column widths are not uniform, null will be returned.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "columnWidth", Required = Newtonsoft.Json.Required.Default)]
        public double? ColumnWidth { get; set; }
    
        /// <summary>
        /// Gets or sets horizontal alignment.
        /// Represents the horizontal alignment for the specified object. The possible values are: General, Left, Center, Right, Fill, Justify, CenterAcrossSelection, Distributed.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "horizontalAlignment", Required = Newtonsoft.Json.Required.Default)]
        public string HorizontalAlignment { get; set; }
    
        /// <summary>
        /// Gets or sets row height.
        /// Gets or sets the height of all rows in the range. If the row heights are not uniform null will be returned.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "rowHeight", Required = Newtonsoft.Json.Required.Default)]
        public double? RowHeight { get; set; }
    
        /// <summary>
        /// Gets or sets vertical alignment.
        /// Represents the vertical alignment for the specified object. The possible values are: Top, Center, Bottom, Justify, Distributed.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "verticalAlignment", Required = Newtonsoft.Json.Required.Default)]
        public string VerticalAlignment { get; set; }
    
        /// <summary>
        /// Gets or sets wrap text.
        /// Indicates if Excel wraps the text in the object. A null value indicates that the entire range doesn't have uniform wrap setting
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "wrapText", Required = Newtonsoft.Json.Required.Default)]
        public bool? WrapText { get; set; }
    
        /// <summary>
        /// Gets or sets borders.
        /// Collection of border objects that apply to the overall range selected Read-only.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "borders", Required = Newtonsoft.Json.Required.Default)]
        public IWorkbookRangeFormatBordersCollectionPage Borders { get; set; }
    
        /// <summary>
        /// Gets or sets fill.
        /// Returns the fill object defined on the overall range. Read-only.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "fill", Required = Newtonsoft.Json.Required.Default)]
        public WorkbookRangeFill Fill { get; set; }
    
        /// <summary>
        /// Gets or sets font.
        /// Returns the font object defined on the overall range selected Read-only.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "font", Required = Newtonsoft.Json.Required.Default)]
        public WorkbookRangeFont Font { get; set; }
    
        /// <summary>
        /// Gets or sets protection.
        /// Returns the format protection object for a range. Read-only.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "protection", Required = Newtonsoft.Json.Required.Default)]
        public WorkbookFormatProtection Protection { get; set; }
    
    }
}
