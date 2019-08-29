using System;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBrandingTransactionColor
    {
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        string Color { get; set; }
        /// <summary>
        /// Gets or sets the branding transaction color identifier.
        /// </summary>
        /// <value>
        /// The branding transaction color identifier.
        /// </value>
        int BrandingTransactionColorId { get; set; }
        /// <summary>
        /// Gets or sets the branding transaction identifier.
        /// </summary>
        /// <value>
        /// The branding transaction identifier.
        /// </value>
        int BrandingTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the color identifier.
        /// </summary>
        /// <value>
        /// The color identifier.
        /// </value>
        int ColorId { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        Nullable<bool> IsActive { get; set; }
    }
}

