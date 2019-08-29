using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOrderSummaryListView
    {
        /// <summary>
        /// Gets or sets the payment purpose.
        /// </summary>
        /// <value>
        /// The payment purpose.
        /// </value>
        string paymentPurpose { get; set; }
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the tv order model.
        /// </summary>
        /// <value>
        /// The tv order model.
        /// </value>
        IList<ITvTransaction> TvOrderModel { get; set; }

        /// <summary>
        /// Gets or sets the radio order model.
        /// </summary>
        /// <value>
        /// The radio order model.
        /// </value>
        IList<IRadioTransaction> RadioOrderModel { get; set; }

        /// <summary>
        /// Gets or sets the print order model.
        /// </summary>
        /// <value>
        /// The print order model.
        /// </value>
        IList<IPrintTransaction> PrintOrderModel { get; set; }

        /// <summary>
        /// Gets or sets the brand order.
        /// </summary>
        /// <value>
        /// The brand order.
        /// </value>
        IList<IBrandingTransaction> BrandOrder { get; set; }

        /// <summary>
        /// Gets or sets the online order model.
        /// </summary>
        /// <value>
        /// The online order model.
        /// </value>
        IList<IOnlineTransaction> OnlineOrderModel { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        IOrder Order { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string processingMessage { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int UserId { get; set; }


        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the amount paid.
        /// </summary>
        /// <value>
        /// The amount paid.
        /// </value>
        decimal AmountPaid { get; set; }

        /// <summary>
        /// Gets or sets the refcode.
        /// </summary>
        /// <value>
        /// The refcode.
        /// </value>
        string Refcode { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        System.DateTime DateCreated { get; set; }
    }
}