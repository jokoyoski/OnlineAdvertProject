using ADit.Interfaces;
using System.Collections.Generic;

namespace ADit.Domain.Models
{
    public class PlatformPackagePriceListView : IPlatformPackagePriceListView
    {
        /// <summary>
        /// Gets or sets the selected online platform price identifier.
        /// </summary>
        /// <value>
        /// The selected online platform price identifier.
        /// </value>
        public int SelectedOnlinePlatformPriceId { get; set; }
        /// <summary>
        /// Gets or sets the selected online platform identifier.
        /// </summary>
        /// <value>
        /// The selected online platform identifier.
        /// </value>
        public int SelectedOnlinePlatformId { get; set; }
        /// <summary>
        /// Gets or sets the selected online description.
        /// </summary>
        /// <value>
        /// The selected online description.
        /// </value>
        public string SelectedOnlineDescription { get; set; }
        /// <summary>
        /// Gets or sets the selected duration type code.
        /// </summary>
        /// <value>
        /// The selected duration type code.
        /// </value>
        public string SelectedDurationTypeCode { get; set; }
        /// <summary>
        /// Gets or sets the selected duration description.
        /// </summary>
        /// <value>
        /// The selected duration description.
        /// </value>
        public string SelectedDurationDescription { get; set; }
        /// <summary>
        /// Gets or sets the online platform price collection.
        /// </summary>
        /// <value>
        /// The online platform price collection.
        /// </value>
        public IList<IOnlinePlatformPrice> OnlinePlatformPriceCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
