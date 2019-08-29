using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRadioTransactionListView
    {
        /// <summary>
        /// Gets or sets the message identifier.
        /// </summary>
        /// <value>
        /// The message identifier.
        /// </value>
        int MessageId { get; set; }
        /// <summary>
        /// Gets or sets the sen t to identifier.
        /// </summary>
        /// <value>
        /// The sen t to identifier.
        /// </value>
        int SenTToId { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
         int userId { get; set; }
        /// <summary>
        /// Gets or sets the radio transaction identifier.
        /// </summary>
        /// <value>
        /// The radio transaction identifier.
        /// </value>
        int radioTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the digital script file identifier.
        /// </summary>
        /// <value>
        /// The digital script file identifier.
        /// </value>
        int digitalScriptFileId { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
        /// <summary>
        /// <summary>
        /// Gets or sets the radio transaction.
        /// </summary>
        /// <value>
        /// The radio transaction.
        /// </value>
        IList<IRadioTransaction> radioTransaction { get; set; }
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
        bool getInitalMessage(int SentToId, int transactionId,string ServiceType);
       
        /// <summary>
        /// Gets if script is approved.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        bool getIfScriptIsApproved(int SentToId, int transactionId,string ServiceType);
        /// <summary>
        /// Gets or sets the type of the material.
        /// </summary>
        /// <value>
        /// The type of the material.
        /// </value>
        string MaterialType { get; set; } 
                       
        /// <summary>
    /// Gets or sets the service code.
    /// </summary>
    /// <value>
     /// The service code.
     /// </value>
string ServiceCode { get; set; }


    }
}
