using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBrandingTransactionListVew
    {/// <summary>
     /// 
     /// </summary>
     /// <param name="SentToId"></param>
     /// <param name="transactionId"></param>
     /// <param name="ServiceCode"></param>
     /// <returns></returns>
        bool getInitalMessage(int SentToId, int transactionId, string ServiceCode);
        /// <summary>
        /// Gets if script is approved.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="ServiceCode">The service code.</param>
        /// <returns></returns>
        bool getIfScriptIsApproved(int SentToId, int transactionId, string ServiceCode);
        /// <summary>
        /// Gets or sets the get branding transactions.
        /// </summary>
        /// <value>
        /// The get branding transactions.
        /// </value>
        IList<IBrandingTransaction> GetBrandingTransactions { get; set; }

        /// <summary>
        /// Gets or sets the replies lists.
        /// </summary>
        /// <value>
        /// The replies lists.
        /// </value>
        IList<IReplies> repliesLists { get; set; }
        /// <summary>
        /// Gets or sets the message list.
        /// </summary>
        /// <value>
        /// The message list.
        /// </value>
        IList<IMessage> messagesLists { get; set; }
    }


        
}
