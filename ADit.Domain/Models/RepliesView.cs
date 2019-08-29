using ADit.Interfaces;
using System;

namespace ADit.Domain.Models
{
   public  class RepliesView:IRepliesView
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is approved.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is approved; otherwise, <c>false</c>.
        /// </value>
        public bool IsApproved { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime dateCreated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public   int ReplyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
      public   int MessageId { get; set; }
        /// <summary>
        /// 
        /// </summary>
       public  int UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
     public    int Sento { get; set; }
        /// <summary>
        /// 
        /// </summary>
     public    string Message { get; set; }
        /// <summary>
        /// 
        /// </summary>
     public    int DigitalFileId { get; set; }
        /// <summary>
        /// 
        /// </summary>
    public     bool IsRead { get; set; }
        /// <summary>
        /// 
        /// </summary>
    public     bool IsActive { get; set; }
    }
}
