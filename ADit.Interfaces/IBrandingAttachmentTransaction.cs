using System;

namespace ADit.Interfaces
{
   public  interface IBrandingAttachmentTransaction
    {

        /// <summary>
        /// 
        /// </summary>
        /// 
        int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
         DateTime dateUpdated { get; set; }


        /// <summary>
        /// 
        /// </summary>
         string Details { get; set; }
        /// <summary>
        /// 
        /// </summary>
        Nullable<int> MaterialFileId { get; set; }

        /// <summary>
        /// 
        /// </summary>
         int UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
         int TransactionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string sentBY { get; set; }
    }
}
