using ADit.Interfaces;
using System.Collections.Generic;

namespace ADit.Domain.Models
{
    public class BrandingMaterialListView: IBrandingMaterialListView
    {
        /// <summary>
        /// Gets or sets the selected branding material identifier.
        /// </summary>
        /// <value>
        /// The selected branding material identifier.
        /// </value>
        public int? SelectedBrandingMaterialId { get; set; }

        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        public string SelectedDescription { get; set; }

        /// <summary>
        /// Gets or sets the branding material collection.
        /// </summary>
        /// <value>
        /// The branding material collection.
        /// </value>
        public IList<IBrandingMaterial> BrandingMaterialCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>The processing message.</value>
        public string ProcessingMessage { get; set; }
    }
}
