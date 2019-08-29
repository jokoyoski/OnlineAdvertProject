using System;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBrandingTransactionDesignElement
    {
        /// <summary>
        /// Gets or sets the design element.
        /// </summary>
        /// <value>
        /// The design element.
        /// </value>
        string DesignElement { get; set; }
        /// <summary>
        /// Gets or sets the branding transaction design element identifier.
        /// </summary>
        /// <value>
        /// The branding transaction design element identifier.
        /// </value>
        int BrandingTransactionDesignElementId { get; set; }
        /// <summary>
        /// Gets or sets the branding transaction identifier.
        /// </summary>
        /// <value>
        /// The branding transaction identifier.
        /// </value>
        int BrandingTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the design element identifier.
        /// </summary>
        /// <value>
        /// The design element identifier.
        /// </value>
        int DesignElementId { get; set; }
        /// <summary>
        /// Gets or sets the design element price identifier.
        /// </summary>
        /// <value>
        /// The design element price identifier.
        /// </value>
        int DesignElementPriceId { get; set; }
        /// <summary>
        /// Gets or sets the design element amount.
        /// </summary>
        /// <value>
        /// The design element amount.
        /// </value>
        decimal DesignElementAmount { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        Nullable<bool> IsActive { get; set; }
    }
}
