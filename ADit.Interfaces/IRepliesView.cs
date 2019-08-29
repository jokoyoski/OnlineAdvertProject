using System;

namespace ADit.Interfaces
{
  public   interface IRepliesView
    {

        bool IsApproved { get; set; }
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
        int UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int Sento { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string Message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int DigitalFileId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        bool IsRead { get; set; }
        /// <summary>
        /// 
        /// </summary>
        bool IsActive { get; set; }
    }
}
