using System.Collections.Generic;

namespace ADit.Interfaces
{


    /// <summary>
    /// 
    /// </summary>
    public interface IPlatformPackagePriceListView
    {

        /// <summary>
        /// Gets or sets the selected online platform price identifier.
        /// </summary>
        /// <value>
        /// The selected online platform price identifier.
        /// </value>
        int SelectedOnlinePlatformPriceId { get; set; }

        /// <summary>
        /// Gets or sets the selected online platform identifier.
        /// </summary>
        /// <value>
        /// The selected online platform identifier.
        /// </value>
        int SelectedOnlinePlatformId { get; set; }

        /// <summary>
        /// Gets or sets the selected duration type code.
        /// </summary>
        /// <value>
        /// The selected duration type code.
        /// </value>
        string SelectedDurationTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the selected online description.
        /// </summary>
        /// <value>
        /// The selected online description.
        /// </value>
        string SelectedOnlineDescription { get; set; }

        /// <summary>
        /// Gets or sets the selected duration description.
        /// </summary>
        /// <value>
        /// The selected duration description.
        /// </value>
        string SelectedDurationDescription { get; set; }

        /// <summary>
        /// Gets or sets the online platform price collection.
        /// </summary>
        /// <value>
        /// The online platform price collection.
        /// </value>
        IList<IOnlinePlatformPrice> OnlinePlatformPriceCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
