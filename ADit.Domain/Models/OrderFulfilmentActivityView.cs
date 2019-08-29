using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Domain.Models
{
    public class OrderFulfilmentActivityView : IOrderFulfilmentActivityView
    {
        /// Gets or sets the peoduction price.
        /// </summary>
        /// <value>
        /// The peoduction price.
        /// </value>
        public decimal PeoductionPrice { get; set; }

        /// <summary>
        /// Gets or sets the scripting price.
        /// </summary>
        /// <value>
        /// The scripting price.
        /// </value>
        public decimal ScriptingPrice { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string URL { get; set; }

        /// <summary>
        /// Gets or sets the current status code.
        /// </summary>
        /// <value>
        /// The current status code.
        /// </value>
        public string currentStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
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

        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>
        /// The transaction identifier.
        /// </value>
        public int transactionId { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public int OrderId { get; set; }

        /// <summary>
        /// <summary>
        /// Gets or sets the fulfilment status code.
        /// </summary>
        /// <value>
        /// The fulfilment status code.
        /// </value>
        public string FulfilmentStatusCode { get; set; }
    }
}