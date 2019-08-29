using ADit.Interfaces;
using System;
using System.Collections.Generic;

namespace ADit.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IMaterialTypeTimingListView" />
    public class MaterialTypeTimingListView  : IMaterialTypeTimingListView
    {
        /// <summary>
        /// Gets or sets the selected material type identifier.
        /// </summary>
        /// <value>
        /// The selected material type identifier.
        /// </value>
        public int SelectedMaterialTypeId { get; set; }
        /// <summary>
        /// Gets or sets the selected material type timing identifier.
        /// </summary>
        /// <value>
        /// The selected material type timing identifier.
        /// </value>
        public int SelectedMaterialTypeTimingId { get; set; }
        /// <summary>
        /// Gets or sets the selected service type code.
        /// </summary>
        /// <value>
        /// The selected service type code.
        /// </value>
        public string SelectedServiceTypeCode { get; set; }
        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        public string selectedDescription { get; set; }
        /// <summary>
        /// Gets or sets the selected timing identifier.
        /// </summary>
        /// <value>
        /// The selected timing identifier.
        /// </value>
        public int SelectedTimingId { get; set; }
        /// <summary>
        /// Gets or sets the selected timing description.
        /// </summary>
        /// <value>
        /// The selected timing description.
        /// </value>
        public string SelectedTimingDescription { get; set; }
        /// <summary>
        /// Gets or sets the material type timing collection.
        /// </summary>
        /// <value>
        /// The material type timing collection.
        /// </value>
        public IList<IMaterialTypeTimingDetail> MaterialTypeTimingCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing messages.
        /// </summary>
        /// <value>
        /// The processing messages.
        /// </value>
        public string ProcessingMessages { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public Nullable<bool> IsActive { get; set; }
    }
}
