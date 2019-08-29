using ADit.Interfaces;
using System.Collections.Generic;

namespace ADit.Domain.Models
{
    public class DesignElementPriceListView : IDesignElementPriceListView
    {
        /// <summary>
        /// Gets or sets the selected design element price identifier.
        /// </summary>
        /// <value>
        /// The selected design element price identifier.
        /// </value>
        public int SelectedDesignElementPriceId { get; set; }
        /// <summary>
        /// Gets or sets the selected design element identifier.
        /// </summary>
        /// <value>
        /// The selected design element identifier.
        /// </value>
        public int SelectedDesignElementId { get; set; }
        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        public string SelectedDescription { get; set; }
        /// <summary>
        /// Gets or sets the selected service type code.
        /// </summary>
        /// <value>
        /// The selected service type code.
        /// </value>
        public string SelectedServiceTypeCode { get; set; }
        /// <summary>
        /// Gets or sets the selected short description.
        /// </summary>
        /// <value>
        /// The selected short description.
        /// </value>
        public string SelectedShortDescription { get; set; }
        /// <summary>
        /// Gets or sets the design element price collection.
        /// </summary>
        /// <value>
        /// The design element price collection.
        /// </value>
        public IList<IDesignElementPrice> DesignElementPriceCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
