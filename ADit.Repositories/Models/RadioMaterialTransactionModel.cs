using ADit.Interfaces;
using System;

namespace ADit.Repositories.Models
{
   public  class RadioMaterialTransactionModel : IRadioMaterialTransaction 
    {
        /// <summary>
        /// 
        /// </summary>
        /// 
      public   int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
      public   Nullable<DateTime> dateUpdated { get; set; }


        /// <summary>
        /// 
        /// </summary>
     public    string Details { get; set; }
        /// <summary>
        /// 
        /// </summary>
      public   Nullable<int> MaterialFileId { get; set; }

        /// <summary>
        /// 
        /// </summary>
       public  Nullable<int> UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
      public   Nullable<int> TransactionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
       public  string sentBY { get; set; }

        public int SentToId { get; set; }
    }
}
