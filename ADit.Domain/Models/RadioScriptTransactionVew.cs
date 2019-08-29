using System;

namespace ADit.Domain.Models
{
   public  class RadioScriptTransactionVew
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
        public string ScriptName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TransactionId { get; set; }
    }
}
