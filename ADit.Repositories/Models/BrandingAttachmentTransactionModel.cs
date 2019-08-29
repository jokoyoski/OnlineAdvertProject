using ADit.Interfaces;
using System;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IBrandingAttachmentTransaction" />
    public class BrandingAttachmentTransactionModel:IBrandingAttachmentTransaction
    {
        /// <summary>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// </summary>
        public DateTime dateUpdated { get; set; }


        /// <summary>
        /// </summary>
        public string Details { get; set; }
        /// <summary>
        /// </summary>
        public Nullable<int> MaterialFileId { get; set; }

        /// <summary>
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// </summary>
        public int TransactionId { get; set; }

        /// <summary>
        /// </summary>
        public string sentBY { get; set; }
    }
}
