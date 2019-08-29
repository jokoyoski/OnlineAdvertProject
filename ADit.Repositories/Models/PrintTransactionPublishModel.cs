using System;
using ADit.Interfaces;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IPrintTransactionPublish" />
    public class PrintTransactionPublishModel : IPrintTransactionPublish
    {
        /// <summary>
        /// Gets or sets the print transaction publish identifier.
        /// </summary>
        /// <value>
        /// The print transaction publish identifier.
        /// </value>
        public int PrintTransactionPublishId { get; set; }
        /// <summary>
        /// Gets or sets the print transaction identifier.
        /// </summary>
        /// <value>
        /// The print transaction identifier.
        /// </value>
        public int PrintTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the print service type price identifier.
        /// </summary>
        /// <value>
        /// The print service type price identifier.
        /// </value>
        public Nullable<int> PrintServiceTypePriceId { get; set; }
        /// <summary>
        /// Gets or sets the print service amount.
        /// </summary>
        /// <value>
        /// The print service amount.
        /// </value>
        public decimal PrintServiceAmount { get; set; }
    }
}
