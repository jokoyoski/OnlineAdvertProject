using ADit.Interfaces;
using ADit.Repositories.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADit.Domain.Models
{
  public   class MessagesListView:IMessagesListView
    {
        

        /// <summary>
        /// Gets or sets all unread replies date.
        /// </summary>
        /// <value>
        /// All unread replies date.
        /// </value>
        public IList<DateTime> allUnreadRepliesDate { get; set; }
        /// <summary>
        /// Gets or sets the date times.
        /// </summary>
        /// <value>
        /// The date times.
        /// </value>
        public IList<DateTime> allRepliesDates { get; set; }
        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        /// <value>
        /// The messages.
        /// </value>
        public IList<IMessage> Messages { get; set; }
        /// <summary>
        /// Gets or sets the replies.
        /// </summary>
        /// <value>
        /// The replies.
        /// </value>
        public IList<int> replies { get; set; }

        /// <summary>
        /// Times the ago.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public string TimeAgo(DateTime dt)
        {
            
                if (dt > DateTime.Now)
                    return "about sometime from now";
                TimeSpan span = DateTime.Now - dt;

                if (span.Days > 365)
                {
                    int years = (span.Days / 365);
                    if (span.Days % 365 != 0)
                        years += 1;
                    return String.Format("about {0} {1} ago", years, years == 1 ? "year" : "years");
                }

                if (span.Days > 30)
                {
                    int months = (span.Days / 30);
                    if (span.Days % 31 != 0)
                        months += 1;
                    return String.Format("about {0} {1} ago", months, months == 1 ? "month" : "months");
                }

                if (span.Days > 0)
                    return String.Format("about {0} {1} ago", span.Days, span.Days == 1 ? "day" : "days");

                if (span.Hours > 0)
                    return String.Format("about {0} {1} ago", span.Hours, span.Hours == 1 ? "hour" : "hours");

                if (span.Minutes > 0)
                    return String.Format("about {0} {1} ago", span.Minutes, span.Minutes == 1 ? "minute" : "minutes");

                if (span.Seconds > 5)
                    return String.Format("about {0} seconds ago", span.Seconds);

                if (span.Seconds <= 5)
                    return "just now";

                return string.Empty;
            
          
        }


    }
}
