using System;

namespace ADit.Interfaces
{
    public interface IOrderFulfilment
    {
        /// <summary>
        /// Gets or sets the order fufilment identifier.
        /// </summary>
        /// <value>
        /// The order fufilment identifier.
        /// </value>
        int OrderFulfilmentId { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the order status code.
        /// </summary>
        /// <value>
        /// The order status code.
        /// </value>
        string OrderStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the service transaction identifier.
        /// </summary>
        /// <value>
        /// The service transaction identifier.
        /// </value>
        int ServiceTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the service code.
        /// </summary>
        /// <value>
        /// The service code.
        /// </value>
        string ServiceCode { get; set; }
        /// <summary>
        /// Gets or sets the fufilment status code.
        /// </summary>
        /// <value>
        /// The fufilment status code.
        /// </value>
        string FufilmentStatusCode { get; set; }

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
        /// Gets or sets the fufilment status description.
        /// </summary>
        /// <value>
        /// The fufilment status description.
        /// </value>
        string FufilmentStatusDescription { get; set; }



        /// <summary>
        /// 
        /// </summary>
        string OrderNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string ServiceTypeDescription { get; set; }
    }
}
