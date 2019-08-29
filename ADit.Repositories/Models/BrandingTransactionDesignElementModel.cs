using ADit.Interfaces;
using System;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IBrandingTransactionDesignElement" />
    public class BrandingTransactionDesignElementModel : IBrandingTransactionDesignElement
    {
        /// <summary>
        /// Gets or sets the design element.
        /// </summary>
        /// <value>
        /// The design element.
        /// </value>
        public string DesignElement { get; set; }
        /// <summary>
        /// Gets or sets the branding transaction design element identifier.
        /// </summary>
        /// <value>
        /// The branding transaction design element identifier.
        /// </value>
        public int BrandingTransactionDesignElementId { get; set; }
        /// <summary>
        /// Gets or sets the branding transaction identifier.
        /// </summary>
        /// <value>
        /// The branding transaction identifier.
        /// </value>
        public int BrandingTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the design element identifier.
        /// </summary>
        /// <value>
        /// The design element identifier.
        /// </value>
        public int DesignElementId { get; set; }
        /// <summary>
        /// Gets or sets the design element price identifier.
        /// </summary>
        /// <value>
        /// The design element price identifier.
        /// </value>
        public int DesignElementPriceId { get; set; }
        /// <summary>
        /// Gets or sets the design element amount.
        /// </summary>
        /// <value>
        /// The design element amount.
        /// </value>
        public decimal DesignElementAmount { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public Nullable<bool> IsActive { get; set; }
    }
}


