using ADit.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace ADit.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IOnlineTransactionListView" />
    public class OnlineTransactionListView:IOnlineTransactionListView
    {
        public bool getIfScriptIsApproved(int SentToId, int transactionId, string ServiceCode)
        {
            //checks the messags if it was approved 
            var Approval = messagesLists.FirstOrDefault(x => x.SentToId == SentToId && x.TransactionId == transactionId && x.ServiceCode == "online");

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
            var initMessage = messagesLists.FirstOrDefault(x => x.SentToId == SentToId && x.TransactionId == transactionId && x.ServiceCode == ServiceCode);

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
        /// Gets or sets the online transactions.
        /// </summary>
        /// <value>
        /// The online transactions.
        /// </value>
        public IList<IOnlineTransaction> onlineTransactions { get; set; }


        /// <summary>
        /// Gets or sets the replies lists.
        /// </summary>
        /// <value>
        /// The replies lists.
        /// </value>
       public  IList<IReplies> repliesLists { get; set; }
        /// <summary>
        /// Gets or sets the message list.
        /// </summary>
        /// <value>
        /// The message list.
        /// </value>
      public   IList<IMessage> messagesLists { get; set; }
    }
}
