using System.Collections.Generic;
using ADit.Interfaces;

namespace ADit.Domain.Models
{
    public class OrderSummaryListView : IOrderSummaryListView
    {
        /// <summary>
        /// Gets or sets the payment purpose.
        /// </summary>
        /// <value>
        /// The payment purpose.
        /// </value>
        public string paymentPurpose { get; set; }
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the tv order model.
        /// </summary>
        /// <value>
        /// The tv order model.
        /// </value>
        public IList<ITvTransaction> TvOrderModel { get; set; }

        /// <summary>
        /// Gets or sets the print order model.
        /// </summary>
        /// <value>
        /// The print order model.
        /// </value>
        public IList<IPrintTransaction> PrintOrderModel { get; set; }

        /// <summary>
        /// Gets or sets the brand order.
        /// </summary>
        /// <value>
        /// The brand order.
        /// </value>
        public IList<IBrandingTransaction> BrandOrder { get; set; }

        /// <summary>
        /// Gets or sets the online order model.
        /// </summary>
        /// <value>
        /// The online order model.
        /// </value>
        public IList<IOnlineTransaction> OnlineOrderModel { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the refcode.
        /// </summary>
        /// <value>
        /// The refcode.
        /// </value>
        public string Refcode { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public System.DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the amount paid.
        /// </summary>
        /// <value>
        /// The amount paid.
        /// </value>
        public decimal AmountPaid { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string processingMessage { get; set; }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>
        /// The orders.
        /// </value>
        public IOrder Order { get; set; }

        /// <summary>
        /// Gets or sets the radio order model.
        /// </summary>
        /// <value>
        /// The radio order model.
        /// </value>
        public IList<IRadioTransaction> RadioOrderModel { get; set; }
        

        //public IList<IRadioTransactionUICartView> RadioTransactions { get; set; }





    }
}