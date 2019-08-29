using ADit.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ADit.Domain.Models
{
   public  class RadioTransactionListView :IRadioTransactionListView
    {
        /// <summary>
        /// Gets or sets the message identifier.
        /// </summary>
        /// <value>
        /// The message identifier.
        /// </value>
        public int MessageId { get; set; }
        /// <summary>
        /// Gets or sets the radio transaction identifier.
        /// </summary>
        /// <value>
        /// The radio transaction identifier.
        /// </value>
        public int radioTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the sen t to identifier.
        /// </summary>
        /// <value>
        /// The sen t to identifier.
        /// </value>
        public int SenTToId { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int userId { get; set; }
        /// <summary>
        /// Gets or sets the type of the material.
        /// </summary>
        /// <value>
        /// The type of the material.
        /// </value>
        public string MaterialType { get; set; }

        /// <summary>
        /// Gets or sets the service code.
        /// </summary>
        /// <value>
        /// The service code.
        /// </value>
       public  string ServiceCode { get; set; }
        /// <summary>
        /// Gets or sets the digital script file identifier.
        /// </summary>
        /// <value>
        /// The digital script file identifier.
        /// </value>
        public int digitalScriptFileId { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the radio transaction.
        /// </summary>
        /// <value>
        /// The radio transaction.
        /// </value>
        public IList<IRadioTransaction> radioTransaction { get; set; }


        /// <summary>
        /// Gets or sets the messages lists.
        /// </summary>
        /// <value>
        /// The messages lists.
        /// </value>
       public IList<IMessage> messagesLists { get; set; }

        /// <summary>
        /// Gets or sets the replies lists.
        /// </summary>
        /// <value>
        /// The replies lists.
        /// </value>
       public  IList<IReplies> repliesLists { get; set; }
        /// <summary>
        /// Gets if material is approved.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactonId">The transacton identifier.</param>
        /// <returns></returns>

        /// <summary>
        /// Gets if script is approved.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool getIfScriptIsApproved(int SentToId, int transactionId, string MaterialType)
        {
            //checks the messags if it was approved 
            var Approval = messagesLists.FirstOrDefault(x => x.SentToId == SentToId && x.TransactionId == transactionId && x.MaterialType == MaterialType && x.ServiceCode == "Radio");

            if (Approval == null)
            {
                return false;
            }


            if (Approval.IsApproved == true)
            {
                return true;
            }
            else  //if it hasnr been approved the message table , we then proceed to chceck from the reply table to see if it was approved 
            {
                var RepliesApproval = repliesLists.Where(x => x.MessageId == Approval.Id).ToList();
                if (RepliesApproval == null)
                {
                    return false;
                }
                foreach (var j in RepliesApproval)
                {
                    if (j.IsApproved == true)
                    {
                        return true;
                    }; //if it was approved in the reply table, return true
                    
                }
            }


            return false; //return false if it dosent



        }
        /// <summary>
        /// Gets the inital message.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="ServiceType"></param>
        /// <returns></returns>
        public bool getInitalMessage(int SentToId, int transactionId, string MaterialType)
        {
            var initMessage = messagesLists.FirstOrDefault(x => x.SentToId == SentToId && x.TransactionId == transactionId && x.MaterialType == MaterialType && x.ServiceCode == "Radio");

            if (initMessage == null)
            {
                return false;
            }
            if (initMessage.Message != null)
            {
                return true;
            }
            return false;
        }


    }
}
