using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDesignElementPriceListView
    {
        /// <summary>
        /// Gets or sets the selected design element price identifier.
        /// </summary>
        /// <value>
        /// The selected design element price identifier.
        /// </value>
        int SelectedDesignElementPriceId { get; set; }

        /// <summary>
        /// Gets or sets the selected design element identifier.
        /// </summary>
        /// <value>
        /// The selected design element identifier.
        /// </value>
        int SelectedDesignElementId { get; set; }

        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        string SelectedDescription { get; set; }

        /// <summary>
        /// Gets or sets the selected service type code.
        /// </summary>
        /// <value>
        /// The selected service type code.
        /// </value>
        string SelectedServiceTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the selected short description.
        /// </summary>
        /// <value>
        /// The selected short description.
        /// </value>
        string SelectedShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the design element price collection.
        /// </summary>
        /// <value>
        /// The design element price collection.
        /// </value>
        IList<IDesignElementPrice> DesignElementPriceCollection { get; set; }


        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
