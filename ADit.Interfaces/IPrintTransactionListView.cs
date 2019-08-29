using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPrintTransactionListView
    {/// <summary>
    /// 
    /// </summary>
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
        /// Gets or sets the selected print transaction identifier.
        /// </summary>
        /// <value>
        /// The selected print transaction identifier.
        /// </value>
        int selectedPrintTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the selected user identifier.
        /// </summary>
        /// <value>
        /// The selected user identifier.
        /// </value>
        int selectedUserId { get; set; }
        /// <summary>
        /// Gets or sets the print collection.
        /// </summary>
        /// <value>
        /// The print collection.
        /// </value>
        IList<IPrintTransaction> PrintCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
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
