using ADit.Interfaces;
using System;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IOnlineTransactionAttachment" />
    public class OnlineTransactionAttachmentModel : IOnlineTransactionAttachment
    {
        /// <summary>
        /// Gets or sets the online transaction attachment identifier.
        /// </summary>
        /// <value>
        /// The online transaction attachment identifier.
        /// </value>
        public int OnlineTransactionAttachmentId { get; set; }
        /// <summary>
        /// Gets or sets the online transaction identifier.
        /// </summary>
        /// <value>
        /// The online transaction identifier.
        /// </value>
        public int OnlineTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the digital file identifier.
        /// </summary>
        /// <value>
        /// The digital file identifier.
        /// </value>
        public int DigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public Nullable<bool> IsActive { get; set; }
    }
}
