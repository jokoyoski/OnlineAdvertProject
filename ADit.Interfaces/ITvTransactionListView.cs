using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITvTransactionListView
    {


        /// <summary>
        /// Gets or sets the messages lists.
        /// </summary>
        /// <value>
        /// The messages lists.
        /// </value>
        IList<IMessage> messagesLists { get; set; }

        /// <summary>
        /// Gets or sets the replies lists.
        /// </summary>
        /// <value>
        /// The replies lists.
        /// </value>
        IList<IReplies> repliesLists { get; set; }
        /// <summary>
        /// Gets the inital message.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        bool getInitalMessage(int SentToId, int transactionId, string ServiceType);

        /// <summary>
        /// Gets if script is approved.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        bool getIfScriptIsApproved(int SentToId, int transactionId, string ServiceType);
        
        /// <summary>
        /// Gets or sets the selected tv transaction identifier.
        /// </summary>
        /// <value>
        /// The selected tv transaction identifier.
        /// </value>
        int selectedTvTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the selected user identifier.
        /// </summary>
        /// <value>
        /// The selected user identifier.
        /// </value>
        int selectedUserId { get; set; }
        /// <summary>
        /// Gets or sets the tv collection.
        /// </summary>
        /// <value>
        /// The tv collection.
        /// </value>
        IList<ITvTransaction> TvCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
