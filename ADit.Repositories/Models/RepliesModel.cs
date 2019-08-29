using ADit.Interfaces;
using System;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IReplies" />
    public class RepliesModel :IReplies



    
   {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is approved.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is approved; otherwise, <c>false</c>.
        /// </value>
        public bool IsApproved { get; set; }

        /// <summary>
        /// </summary>
        public int SentToId { get; set; }
        /// <summary>
        /// </summary>
        /// <!-- Badly formed XML comment ignored for member "P:ADit.Interfaces.IReplies.userId" -->
        public int userId { get; set; }


        /// <summary>
        /// </summary>
        public DateTime dateCreated { get; set; }
        /// <summary>
        /// </summary>
        public int ReplyId { get; set; }
        /// <summary>
        /// </summary>
        public int MessageId { get; set; }
        /// <summary>
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// </summary>
        public string Sento { get; set; }
        /// <summary>
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// </summary>
        public int? DigitalFileId { get; set; }
        /// <summary>
        /// </summary>
        public Nullable<bool> IsRead { get; set; }
        /// <summary>
        /// </summary>
        public bool IsActive { get; set; }
    }
}
