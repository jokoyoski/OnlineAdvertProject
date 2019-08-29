using ADit.Interfaces;
using System.Collections.Generic;

namespace ADit.Domain.Models
{
    public class RadioServicePriceListView : IRadioServicePriceListView
    {
        /// <summary>
        /// Gets or sets the selected radio service identifier.
        /// </summary>
        /// <value>
        /// The selected radio service identifier.
        /// </value>
        public int SelectedRadioServiceId { get; set; }
        /// <summary>
        /// Gets or sets the selected radio identifier.
        /// </summary>
        /// <value>
        /// The selected radio identifier.
        /// </value>
        public int SelectedRadioId { get; set; }
        /// <summary>
        /// Gets or sets the selected timing identifier.
        /// </summary>
        /// <value>
        /// The selected timing identifier.
        /// </value>
        public int SelectedTimingId { get; set; }
        /// <summary>
        /// Gets or sets the selected material type identifier.
        /// </summary>
        /// <value>
        /// The selected material type identifier.
        /// </value>
        public int SelectedMaterialTypeId { get; set; }
        /// <summary>
        /// Gets or sets the radio service price collection.
        /// </summary>
        /// <value>
        /// The radio service price collection.
        /// </value>
        public IList<IRadioServicePriceListModel> RadioServicePriceCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

    }
}
