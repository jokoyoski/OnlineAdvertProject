using ADit.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ADit.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.ITvTransactionMaterialListView" />
    public class TvTransactionMaterialListView : ITvTransactionMaterialListView
    {
        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        /// 
        [Required]
      public  string Subject { get; set; }

        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        /// <value>
        /// The messages.
        /// </value>
        public  IList<IMessage> messages { get; set; }
        /// <summary>
        /// Gets or sets the replies.
        /// </summary>
        /// <value>
        /// The replies.
        /// </value>
       public  IList<IReplies> replies { get; set; }
        /// <summary>
        /// </summary>
        public int RepliesId { get; set; }
        /// <summary>
        /// </summary>
        public int SentToId { get; set; }
        /// <summary>
        /// Gets or sets the message identifier.
        /// </summary>
        /// <value>
        /// The message identifier.
        /// </value>
        public int? MessageId { get; set; }
        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        public string OrderTitle { get; set; }
        /// <summary>
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// </summary>
        public int SentBy { get; set; }
        /// <summary>
        /// </summary>
        public string AdditionalInfo { get; set; }
        /// <summary>
        /// </summary>
        public int userId { get; set; }
        /// <summary>
        /// </summary>
        public int transactionId { get; set; }
        /// <summary>
        /// </summary>
        /// 
        [Required]
        public string MaterialDetails { get; set; }
        /// <summary>
        /// </summary>
        public int digitalMaterialFileId { get; set; }
        /// <summary>
        /// </summary>
        public int? UploadedMaterialDetail { get; set; }
        /// <summary>
        /// </summary>
        public IList<ITvMaterialTransactionModel> TvMaterialTransaction { get; set; }
        /// <summary>
        /// Gets or sets the digital file list.
        /// </summary>
        /// <value>
        /// The digital file list.
        /// </value>
        public IList<IDigitalFile> digitalFileList { get; set; }

        /// <summary>
        /// </summary>
        public int? DigitalFileId { get; set; }

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
            var messageExist = messages.SingleOrDefault(x => x.SentToId == sentToId && x.TransactionId == transactionId && x.MaterialType == materialType && x.ServiceCode == ServiceCode);
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
                var RepliesApproval = replies.Where(x => x.MessageId == messageExist.Id).ToList();
                if (RepliesApproval == null)
                {
                    return false;
                }
                foreach (var j in RepliesApproval)
                {
                    if (j.IsApproved == true)
                    {
                        return true;
                    }
                    //if it was approved in the reply table, return true
                   
                }


            }
            return false;

            /// <summary>
        }
    }
}

