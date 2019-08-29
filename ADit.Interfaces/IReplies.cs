using System;

namespace ADit.Interfaces
{
   public  interface IReplies
    {

        bool IsApproved { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int SentToId { get; set; }
        /// <summary>

        int userId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        DateTime dateCreated { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int ReplyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int MessageId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string Sento { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string Message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int? DigitalFileId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        Nullable<bool> IsRead { get; set; }
        /// <summary>
        /// 
        /// </summary>
        bool IsActive{get;set;}
    }
}
