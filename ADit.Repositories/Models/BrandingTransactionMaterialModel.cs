using ADit.Interfaces;
using System;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IBrandingTransactionMaterial" />
    public class BrandingTransactionMaterialModel : IBrandingTransactionMaterial
    {
        /// <summary>
        /// Gets or sets the branding material.
        /// </summary>
        /// <value>
        /// The branding material.
        /// </value>
        public string BrandingMaterial { get; set; }
        /// <summary>
        /// Gets or sets the branding transaction material identifier.
        /// </summary>
        /// <value>
        /// The branding transaction material identifier.
        /// </value>
        public int BrandingTransactionMaterialId { get; set; }
        /// <summary>
        /// Gets or sets the branding transaction identifier.
        /// </summary>
        /// <value>
        /// The branding transaction identifier.
        /// </value>
        public int BrandingTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the branding material identifier.
        /// </summary>
        /// <value>
        /// The branding material identifier.
        /// </value>
        public int BrandingMaterialId { get; set; }
        /// <summary>
        /// Gets or sets the branding material price identifier.
        /// </summary>
        /// <value>
        /// The branding material price identifier.
        /// </value>
        public int BrandingMaterialPriceId { get; set; }
        /// <summary>
        /// Gets or sets the branding material amount.
        /// </summary>
        /// <value>
        /// The branding material amount.
        /// </value>
        public decimal BrandingMaterialAmount { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public Nullable<bool> IsActive { get; set; }
    }
}

