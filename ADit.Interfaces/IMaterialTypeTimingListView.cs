using System;
using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMaterialTypeTimingListView
    {
        /// <summary>
        /// Gets or sets the selected material type timing identifier.
        /// </summary>
        /// <value>
        /// The selected material type timing identifier.
        /// </value>
        int SelectedMaterialTypeTimingId { get; set; }
        /// <summary>
        /// Gets or sets the selected service type code.
        /// </summary>
        /// <value>
        /// The selected service type code.
        /// </value>
        string SelectedServiceTypeCode { get; set; }
        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        string selectedDescription { get; set; }
        /// <summary>
        /// Gets or sets the selected timing identifier.
        /// </summary>
        /// <value>
        /// The selected timing identifier.
        /// </value>
        int SelectedTimingId { get; set; }
        /// <summary>
        /// Gets or sets the selected timing description.
        /// </summary>
        /// <value>
        /// The selected timing description.
        /// </value>
        string SelectedTimingDescription { get; set; }
        /// <summary>
        /// Gets or sets the material type timing collection.
        /// </summary>
        /// <value>
        /// The material type timing collection.
        /// </value>
        IList<IMaterialTypeTimingDetail> MaterialTypeTimingCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing messages.
        /// </summary>
        /// <value>
        /// The processing messages.
        /// </value>
        string ProcessingMessages { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        Nullable<bool> IsActive { get; set; }
    }
}
