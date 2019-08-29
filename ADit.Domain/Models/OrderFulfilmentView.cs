using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Domain.Models
{
  public   class OrderFulfilmentView :IOrderFulfilment
    {

        /// <summary>
        /// Gets or sets the fufilment status description.
        /// </summary>
        /// <value>
        /// The fufilment status description.
        /// </value>
        public string FufilmentStatusDescription { get; set; }
        /// <summary>
       /// Gets or sets the order status code.
        /// </summary>
        /// <value>
        /// The order status code.
        /// </value>
        public string OrderStatusCode { get; set; }
        /// <summary>
        /// Gets or sets the order fufilment identifier.
        /// </summary>
        /// <value>
        /// The order fufilment identifier.
        /// </value>
        public int OrderFulfilmentId { get; set; }
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the service transaction identifier.
        /// </summary>
        /// <value>
        /// The service transaction identifier.
        /// </value>
        public int ServiceTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the service code.
        /// </summary>
        /// <value>
        /// The service code.
        /// </value>
        public string ServiceCode { get; set; }
        /// <summary>
        /// Gets or sets the fufilment status code.
        /// </summary>
        /// <value>
        /// The fufilment status code.
        /// </value>
        public string FufilmentStatusCode { get; set; }

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
        /// 
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ServiceTypeDescription { get; set; }
    }
}
