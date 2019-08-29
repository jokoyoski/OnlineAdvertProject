using ADit.Interfaces;
using System.Collections.Generic;

namespace ADit.Domain.Models
{
    public class MaterialPriceListView : IMaterialPriceListView
    {
        /// <summary>
        /// Gets or sets the selected branding material price identifier.
        /// </summary>
        /// <value>
        /// The selected branding material price identifier.
        /// </value>
        public int SelectedBrandingMaterialPriceId { get; set; }
        /// <summary>
        /// Gets or sets the selected branding material.
        /// </summary>
        /// <value>
        /// The selected branding material.
        /// </value>
        public string SelectedBrandingMaterial { get; set; }
        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        public string SelectedDescription { get; set; }
        /// <summary>
        /// Gets or sets the branding material price collection.
        /// </summary>
        /// <value>
        /// The branding material price collection.
        /// </value>
        public IList<IBrandingMaterialPrice> BrandingMaterialPriceCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
