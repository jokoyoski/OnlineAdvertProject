using ADit.Domain.Models;
using ADit.Interfaces;
using System;
using System.Collections.Generic;

namespace ADit.Domain.Factories
{
    public class MessageFactory : IMessageFactory
    {

        public IMessagesListView GetActiveMessageListByIdForAdmin(IList<IMessage>messages)
        {
            var message = new MessagesListView
            {
                Messages = messages,
            };
            return message;
        }

        public  IMessagesListView GetMessagesList(IList<IMessage>messages,IList<int>repliesId)
        {
            if(messages==null)
            {
                throw new ArgumentNullException(nameof(messages));
            }
            var view = new MessagesListView
            {
                Messages = messages,
                replies = repliesId
            };
            return view;
        }

        /// <summary>
        /// Gets the messages list.
        /// </summary>
        /// <param name="messages">The messages.</param>
        /// <param name="repliesId">The replies identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">messages</exception>
        public IMessagesListView GetMessagesList(IList<IMessage> messages)
        {
            if (messages == null)
            {
                throw new ArgumentNullException(nameof(messages));
            }

            var view = new MessagesListView
            {
                Messages = messages,
               
                
            };
            return view;


        }


        /// <summary>
        /// Gets the message replies ListView.
        /// </summary>
        /// <param name="replies">The replies.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">message</exception>
        public IMessageRepliesListView GetMessageRepliesListView(IList<IReplies> replies, IMessage message,string Subject)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");

            }

            var view = new MessageRepliesListView
            {
                IsApproved=message.IsApproved,
                InitialMessage = message.Message,
                InitialDate=message.Date,
                MessageId = message.Id,
                SentToId = message.UserId,
                transactionId = message.TransactionId,
                OrderId=message.OrderId,
                Replies = replies,
                DigitalFileId=message.DigitalFileId,
                ServiceCode=message.ServiceCode,
                Subject=Subject,
                


            };
            return view;
        }


        /// <summary>
        /// Gets the material message replies ListView.
        /// </summary>
        /// <param name="replies">The replies.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">message</exception>
        public IMessageRepliesListView GetMaterialMessageRepliesListView(IList<IReplies> replies, 
            IMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");

            }

            var view = new MessageRepliesListView
            {
                InitialMessage = message.Message,
                MessageId = message.Id,
                
                transactionId = message.TransactionId,

                Replies = replies

            };
            return view;
        }







        /// Gets the script message replies ListView.
        /// </summary>
        /// <param name="replies">The replies.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">message</exception>
        public IMessageRepliesListView GetScriptMessageRepliesListView(IList<IReplies> replies, IMessage message, int SentToId, int transactionId, int OrderId,string MaterialType,string ServiceCode)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");

            }

            var view = new MessageRepliesListView
            {
                UserId = message.UserId,
                InitialMessage = message.Message,
                MessageId = message.Id,
                SentToId = SentToId,
                transactionId = transactionId,
                DigitalFileId = message.DigitalFileId,
                Replies = replies,
                IsApproved = message.IsApproved,
                OrderId = OrderId,
                ServiceCode=ServiceCode,
                MaterialType=MaterialType,

            };
            return view;
        }


    }
}
