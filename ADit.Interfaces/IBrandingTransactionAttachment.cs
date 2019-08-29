using System;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface  IBrandingTransactionAttachment
    {





        /// <summary>
        /// Gets or sets the branding transaction attachment identifier.
        /// </summary>
        /// <value>
        /// The branding transaction attachment identifier.
        /// </value>
        int BrandingTransactionAttachmentId { get; set; }
        /// <summary>
        /// Gets or sets the branding transaction identifier.
        /// </summary>
        /// <value>
        /// The branding transaction identifier.
        /// </value>
        int BrandingTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the digital file identifier.
        /// </summary>
        /// <value>
        /// The digital file identifier.
        /// </value>
        int DigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        Nullable<bool> IsActive { get; set; }
    }
}
