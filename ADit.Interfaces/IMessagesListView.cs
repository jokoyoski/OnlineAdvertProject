using System;
using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMessagesListView
    {

      

        
        /// <summary>
        /// Times the ago.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        string TimeAgo(DateTime dt);
        /// <summary>
        /// Gets or sets all unread replies date.
        /// </summary>
        /// <value>
        /// All unread replies date.
        /// </value>
        IList<DateTime> allUnreadRepliesDate { get; set; }
        /// <summary>
        /// Gets or sets the date times.
        /// </summary>
        /// <value>
        /// The date times.
        /// </value>
         IList<DateTime> allRepliesDates { get; set; }
        /// <summary>
        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        /// <value>
        /// The messages.
        /// </value>
        IList<IMessage> Messages { get; set; }
        /// <summary>
        /// Gets or sets the replies.
        /// </summary>
        /// <value>
        /// The replies.
        /// </value>
        IList<int> replies { get; set; }


    }
}
