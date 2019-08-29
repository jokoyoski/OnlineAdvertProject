using System;

namespace ADit.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Domain.Models.IBrandingAttachmentTransactionView" />
    public class BrandingAttachmmentTransactionView :IBrandingAttachmentTransactionView
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
        public int MaterialFileId { get; set; }

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
