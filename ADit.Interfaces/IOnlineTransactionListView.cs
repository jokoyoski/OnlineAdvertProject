using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOnlineTransactionListView
    {
        /// <summary>
        /// Gets or sets the online transactions.
        /// </summary>
        /// <value>
        /// The online transactions.
        /// </value>
        IList<IOnlineTransaction> onlineTransactions { get; set; }

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
        /// <summary>
        /// Gets if script is approved.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <returns></returns>
        bool getIfScriptIsApproved(int SentToId, int transactionId, string MaterialType);


        /// <summary>
        /// Gets the inital message.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <returns></returns>
        bool getInitalMessage(int SentToId, int transactionId, string MaterialType);
    }
}
