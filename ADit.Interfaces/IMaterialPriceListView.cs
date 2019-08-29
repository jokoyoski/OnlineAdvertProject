using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMaterialPriceListView
    {
        /// <summary>
        /// Gets or sets the selected branding material price identifier.
        /// </summary>
        /// <value>
        /// The selected branding material price identifier.
        /// </value>
        int SelectedBrandingMaterialPriceId { get; set; }

        /// <summary>
        /// Gets or sets the selected branding material.
        /// </summary>
        /// <value>
        /// The selected branding material.
        /// </value>
        string SelectedBrandingMaterial { get; set; }

        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        string SelectedDescription { get; set; }

        /// <summary>
        /// Gets or sets the branding material price collection.
        /// </summary>
        /// <value>
        /// The branding material price collection.
        /// </value>
        IList<IBrandingMaterialPrice> BrandingMaterialPriceCollection { get; set; }


        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
