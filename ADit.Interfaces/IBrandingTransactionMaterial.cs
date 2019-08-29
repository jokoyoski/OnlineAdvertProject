using System;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBrandingTransactionMaterial
    {
        /// <summary>
        /// Gets or sets the branding material.
        /// </summary>
        /// <value>
        /// The branding material.
        /// </value>
        string BrandingMaterial { get; set; }
        /// <summary>
        /// Gets or sets the branding transaction material identifier.
        /// </summary>
        /// <value>
        /// The branding transaction material identifier.
        /// </value>
        int BrandingTransactionMaterialId { get; set; }
        /// <summary>
        /// Gets or sets the branding transaction identifier.
        /// </summary>
        /// <value>
        /// The branding transaction identifier.
        /// </value>
        int BrandingTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the branding material identifier.
        /// </summary>
        /// <value>
        /// The branding material identifier.
        /// </value>
        int BrandingMaterialId { get; set; }
        /// <summary>
        /// Gets or sets the branding material price identifier.
        /// </summary>
        /// <value>
        /// The branding material price identifier.
        /// </value>
        int BrandingMaterialPriceId { get; set; }
        /// <summary>
        /// Gets or sets the branding material amount.
        /// </summary>
        /// <value>
        /// The branding material amount.
        /// </value>
        decimal BrandingMaterialAmount { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        Nullable<bool> IsActive { get; set; }
    }
}

