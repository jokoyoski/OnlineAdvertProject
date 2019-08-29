using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Interfaces
{
  public  interface IOrderFulfilmentActivityDocument
    {
        /// <summary>
        /// Gets or sets the order fulfilment activity document identifier.
        /// </summary>
        /// <value>
        /// The order fulfilment activity document identifier.
        /// </value>
        int OrderFulfilmentActivityDocumentId { get; set; }
        /// <summary>
        /// Gets or sets the order fulfilment identifier.
        /// </summary>
        /// <value>
        /// The order fulfilment identifier.
        /// </value>
        int OrderFulfilmentId { get; set; }

        /// <summary>
        /// Gets or sets the digital file identifier.
        /// </summary>
        /// <value>
        /// The digital file identifier.
        /// </value>
        int DigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is attach with mail.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is attach with mail; otherwise, <c>false</c>.
        /// </value>
        bool IsAttachWithMail { get; set; }
    }
}
