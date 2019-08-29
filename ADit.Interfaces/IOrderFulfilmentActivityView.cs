using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOrderFulfilmentActivityView
    {

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        string URL { get; set; }

        /// <summary>
        /// Gets or sets the current status code.
        /// </summary>
        /// <value>
        /// The current status code.
        /// </value>
        string currentStatusCode { get; set; }
        /// <summary>
        /// Gets or sets the fulfilment status code.
        /// </summary>
        /// <value>
        /// The fulfilment status code.
        /// </value>
       string FulfilmentStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>
        /// The transaction identifier.
        /// </value>
        int transactionId { get; set; }
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        int OrderId { get; set; }
        /// <summary>
     
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int UserId { get; set; }
        /// <summary>
        /// Gets or sets the order fulfilment identifier.
        /// </summary>
        /// <value>
        /// The order fulfilment identifier.
        /// </value>
        int OrderFulfilmentId { get; set; }
        /// <summary>
        /// Gets or sets the peoduction price.
        /// </summary>
        /// <value>
        /// The peoduction price.
        /// </value>
        decimal PeoductionPrice { get; set; }
        /// <summary>
        /// Gets or sets the scripting price.
        /// </summary>
        /// <value>
        /// The scripting price.
        /// </value>
        decimal ScriptingPrice { get; set; }
        /// <summary>
        /// Gets or sets the order fulfilment activity identifier.
        /// </summary>
        /// <value>
        /// The order fulfilment activity identifier.
        /// </value>
        int OrderFulfilmentActivityId { get; set; }
        /// <summary>
        /// Gets or sets the activityescription.
        /// </summary>
        /// <value>
        /// The activityescription.
        /// </value>
        string Activityescription { get; set; }
        /// <summary>
        /// Gets or sets from status.
        /// </summary>
        /// <value>
        /// From status.
        /// </value>
        string FromStatus { get; set; }

        /// <summary>
        /// Gets or sets to status.
        /// </summary>
        /// <value>
        /// To status.
        /// </value>
        string ToStatus { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is send mail.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is send mail; otherwise, <c>false</c>.
        /// </value>
        bool IsSendMail { get; set; }
        /// <summary>
        /// Gets or sets the mail message.
        /// </summary>
        /// <value>
        /// The mail message.
        /// </value>
        string MailMessage { get; set; }
        /// <summary>
        /// Gets or sets the created by user identifier.
        /// </summary>
        /// <value>
        /// The created by user identifier.
        /// </value>
        int CreatedByUserId { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is treated.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is treated; otherwise, <c>false</c>.
        /// </value>
        bool IsTreated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is response required.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is response required; otherwise, <c>false</c>.
        /// </value>
        bool IsResponseRequired { get; set; }
    }
}
