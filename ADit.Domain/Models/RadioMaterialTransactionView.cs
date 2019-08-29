using ADit.Interfaces;
using System;

namespace ADit.Domain.Models
{
  public   class RadioMaterialTransactionView :IRadioMaterialTransactionView
    {

        /// <summary>
        /// 
        /// </summary>
        /// 
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime dateUpdated { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Details { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MaterialFileId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TransactionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string sentBY { get; set; }
    }
}
