using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Domain.Models
{
   public class FufilmentPaymentView : IFulfilmentPaymentView
    {


        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
       public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }
     
        /// Gets or sets the fulfilment scripting payment identifier.
        /// </summary>
        /// <value>
        /// The fulfilment scripting payment identifier.
        /// </value>
        public int FulfilmentScriptingPaymentId { get; set; }
        /// <summary>
        /// Gets or sets the order fulfilment identifier.
        /// </summary>
        /// <value>
        /// The order fulfilment identifier.
        /// </value>
       public int OrderFulfilmentId { get; set; }
        /// <summary>
        /// Gets or sets the fulfilment payment status.
        /// </summary>
        /// <value>
        /// The fulfilment payment status.
        /// </value>
      public  string FulfilmentPaymentStatus { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
     public   System.DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the date paid.
        /// </summary>
        /// <value>
        /// The date paid.
        /// </value>
     public   Nullable<System.DateTime> DatePaid { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
      public  bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>
        /// The transaction identifier.
        /// </value>
        public int transactionId { get; set; }
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string URL { get; set; }
        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        public string OrderTitle { get; set; }
        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        public int OrderNumber { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; set; }
    }
}
