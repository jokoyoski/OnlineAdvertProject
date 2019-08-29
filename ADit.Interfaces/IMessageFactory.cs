using System;
using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMessageFactory
    {

        /// <summary>
        /// Gets the script message replies ListView.
        /// </summary>
        /// <param name="replies">The replies.</param>
        /// <param name="message">The message.</param>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="OrderId">The order identifier.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <param name="ServiceCode">The service code.</param>
        /// <returns></returns>
        IMessageRepliesListView GetScriptMessageRepliesListView(IList<IReplies> replies, IMessage message, int SentToId, int transactionId, int OrderId,string MaterialType,string ServiceCode);
        /// <summary>
        /// Gets the active message list by identifier for admin.
        /// </summary>
        /// <param name="messages">The messages.</param>
        /// <returns></returns>
        IMessagesListView GetActiveMessageListByIdForAdmin(IList<IMessage> messages);
        /// <summary>
        /// Gets the messages list.
        /// </summary>
        /// <param name="messages">The messages.</param>
        /// <param name="repliesId">The replies identifier.</param>
        /// <returns></returns>
        IMessagesListView GetMessagesList(IList<IMessage> messages, IList<int> repliesId);

        /// <summary>
        /// Gets the material message replies ListView.
        /// </summary>
        /// <param name="replies">The replies.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IMessageRepliesListView GetMaterialMessageRepliesListView(IList<IReplies> replies,
            IMessage message
            );
        /// <summary>
        /// Gets the messages list.
        /// </summary>
        /// <param name="messages">The messages.</param>
        /// <param name="replies">The replies.</param>
        /// <returns></returns>
        IMessagesListView GetMessagesList(IList<IMessage>messages);
        /// <summary>
        /// Gets the message replies ListView.
        /// </summary>
        /// <param name="replies">The replies.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IMessageRepliesListView GetMessageRepliesListView(IList<IReplies> replies, IMessage message,string Subject);


    }
}
