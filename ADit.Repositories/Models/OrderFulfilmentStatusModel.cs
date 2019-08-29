using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Repositories.Models
{
    public class OrderFulfilmentStatusModel : IOrderFulfilmentStatus
    {
        public string URL { get; set; }
        /// <summary>
        /// Gets or sets the fulfilment status code.
        /// </summary>
        /// <value>
        /// The fulfilment status code.
        /// </value>
       public string FulfilmentStatusCode { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
      public  string Description { get; set; }

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
    }
}
