using ADit.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Domain.Models
{
    public class PrintTransactionAiringView : IPrintTransactionAiringView
    {
        /// <summary>
        /// Gets or sets the print transaction airing identifier.
        /// </summary>
        /// <value>
        /// The print transaction airing identifier.
        /// </value>
        public int PrintTransactionAiringId { get; set; }
        /// <summary>
        /// Gets or sets the print transaction identifier.
        /// </summary>
        /// <value>
        /// The print transaction identifier.
        /// </value>
        public int PrintTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the news paper identifier.
        /// </summary>
        /// <value>
        /// The news paper identifier.
        /// </value>
        public int NewsPaperId { get; set; }
        /// <summary>
        /// Gets or sets the newspaper list.
        /// </summary>
        /// <value>
        /// The newspaper list.
        /// </value>
        public IList<SelectListItem> NewspaperList { get; set; }
        /// <summary>
        /// Gets or sets the service type code.
        /// </summary>
        /// <value>
        /// The service type code.
        /// </value>
        public string ServiceTypeCode { get; set; }
        /// <summary>
        /// Gets or sets the service type code list.
        /// </summary>
        /// <value>
        /// The service type code list.
        /// </value>
        public IList<SelectListItem> ServiceTypeCodeList { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the cart identifier.
        /// </summary>
        /// <value>
        /// The cart identifier.
        /// </value>
        public int CartId { get; set; }
    }
}
