using ADit.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ADit.Domain.Models
{
   public  class RadioScriptTransactionListView : IRadioScriptTransactionListView
    { /// <summary>
      /// Gets or sets the subject.
      /// </summary>
      /// <value>
      /// The subject.
      /// 
      /// </value>
      /// 
      [Required]
       public string Subject { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int? DigitalFileId { get; set; }


        public int? MessageId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RepliesId { get; set; }
        /// <summary>
        /// Gets or sets the digital file list.
        /// </summary>
        /// <value>
        /// The digital file list.
        /// </value>
        public IList<IDigitalFile> digitalFileList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  int SentToId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OrderTitle { get; set; }
        /// <summary>
        /// 
        /// </summary>
       public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ServiceCode { get; set; }
        /// <summary>
        /// Gets or sets the type of the material.
        /// </summary>
        /// <value>
        /// The type of the material.
        /// </value>
        public string MaterialType { get; set; }
        /// <summary>
        /// Gets or sets the additional information.
        /// </summary>
        /// <value>
        /// The additional information.
        /// </value>
        public string AdditionalInfo { get; set; }
        /// <summary>
        /// Gets or sets the script details.
        /// </summary>
        /// <value>
        /// The script details.
        /// </value>
        /// 
        [Required]
        public string ScriptDetails { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int userId { get; set; }
        /// <summary>
        /// Gets or sets the digital script file identifier.
        /// </summary>
        /// <value>
        /// The digital script file identifier.
        /// </value>
        public int digitalScriptFileId { get; set; }
        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>
        /// The transaction identifier.
        /// </value>
        public int transactionId { get; set; }
        /// <summary>
        /// Gets or sets the uploaded script detail.
        /// </summary>
        /// <value>
        /// The uploaded script detail.
        /// </value>
        public IDigitalFile UploadedScriptDetail { get; set; }
        /// <summary>
        /// Gets or sets the radio script transaction.
        /// </summary>
        /// <value>
        /// The radio script transaction.
        /// </value>
        public IList<IRadioScriptTransaction> radioScriptTransaction { get; set; }
        /// <summary>
        /// Gets or sets the message list.
        /// </summary>
        /// <value>
        /// The message list.
        /// </value>
        public IList<IMessage> messageList { get; set; }
        /// <summary>
        /// Gets or sets the replies list.
        /// </summary>
        /// <value>
        /// The replies list.
        /// </value>
        public IList<IReplies> repliesList { get; set; }

        /// <summary>
        /// Checks if approved.
        /// </summary>
        /// <param name="sentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="materialType">Type of the material.</param>
        /// <param name="ServiceCode">The service code.</param>
        /// <returns></returns>
        public bool CheckIfApproved(int sentToId, int transactionId, string materialType, string ServiceCode)
        {
            var messageExist = messageList.SingleOrDefault(x => x.SentToId == sentToId && x.TransactionId == transactionId && x.MaterialType == materialType && x.ServiceCode == ServiceCode);
            if (messageExist == null)
            {
                return false;
            }
            if (messageExist.IsApproved == true)
            {
                return true;
            }

            else  //if it hasnr been approved the message table , we then proceed to chceck from the reply table to see if it was approved 
            {
                var RepliesApproval = repliesList.Where(x => x.MessageId == messageExist.Id).ToList();
                if (RepliesApproval == null)
                {
                    return false;
                }
                foreach (var j in RepliesApproval)
                {
                    if (j.IsApproved == true) ; //if it was approved in the reply table, return true
                    return true;
                }


            }
            return false;

            /// <summary>
        }
    }
}
