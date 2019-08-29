using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Repositories.Models
{
  public  class OrderFulfilmentActivityModel :IOrderFulfilmentActivity
    { /// <summary>
      /// Gets or sets the order fulfilment identifier.
      /// </summary>
      /// <value>
      /// The order fulfilment identifier.
      /// </value>
        public int OrderFulfilmentId { get; set; }

        /// <summary>
        /// Gets or sets the order fulfilment activity identifier.
        /// </summary>
        /// <value>
        /// The order fulfilment activity identifier.
        /// </value>
        public int OrderFulfilmentActivityId { get; set; }
        /// <summary>
        /// Gets or sets the activityescription.
        /// </summary>
        /// <value>
        /// The activityescription.
        /// </value>
        public string Activityescription { get; set; }
        /// <summary>
        /// Gets or sets from status.
        /// </summary>
        /// <value>
        /// From status.
        /// </value>
        public string FromStatus { get; set; }

        /// <summary>
        /// Gets or sets to status.
        /// </summary>
        /// <value>
        /// To status.
        /// </value>
        public string ToStatus { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is send mail.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is send mail; otherwise, <c>false</c>.
        /// </value>
        public bool IsSendMail { get; set; }
        /// <summary>
        /// Gets or sets the mail message.
        /// </summary>
        /// <value>
        /// The mail message.
        /// </value>
        public string MailMessage { get; set; }
        /// <summary>
        /// Gets or sets the created by user identifier.
        /// </summary>
        /// <value>
        /// The created by user identifier.
        /// </value>
        public int CreatedByUserId { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is treated.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is treated; otherwise, <c>false</c>.
        /// </value>
        public bool IsTreated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is response required.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is response required; otherwise, <c>false</c>.
        /// </value>
        public bool IsResponseRequired { get; set; }
    }
}
