using ADit.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ADit.Domain.Models
{
    public class PrintTransactionListView : IPrintTransactionListView
    {
        /// <summary>
        /// Gets or sets the replies list.
        /// </summary>
        /// <value>
        /// The replies list.
        /// </value>
        public IList<IReplies> repliesLists { get; set; }
        /// <summary>
        /// Gets or sets the messages list.
        /// </summary>
        /// <value>
        /// The messages list.
        /// </value>
        public IList<IMessage> messagesLists{ get; set; }
        /// <summary>
        /// Gets if script is approved.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool getIfScriptIsApproved(int SentToId, int transactionId, string ServiceCode)
        {
            //checks the messags if it was approved 
            var Approval = messagesLists.FirstOrDefault(x => x.SentToId == SentToId && x.TransactionId == transactionId && x.ServiceCode == "Print");

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
        public bool getInitalMessage(int SentToId, int transactionId, string ServiceCode)
        {
            var initMessage = messagesLists.FirstOrDefault(x => x.SentToId == SentToId && x.TransactionId == transactionId  && x.ServiceCode == ServiceCode);

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
        /// <summary>
        /// Gets or sets the selected print transaction identifier.
        /// </summary>
        /// <value>
        /// The selected print transaction identifier.
        /// </value>
        public int selectedPrintTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the selected user identifier.
        /// </summary>
        /// <value>
        /// The selected user identifier.
        /// </value>
        public int selectedUserId { get; set; }
        /// <summary>
        /// Gets or sets the print collection.
        /// </summary>
        /// <value>
        /// The print collection.
        /// </value>
        public IList<IPrintTransaction> PrintCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
