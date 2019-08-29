using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRadioServicePriceListView
    {
        /// <summary>
        /// Gets or sets the selected radio service identifier.
        /// </summary>
        /// <value>
        /// The selected radio service identifier.
        /// </value>
        int SelectedRadioServiceId { get; set; }
        /// <summary>
        /// Gets or sets the selected radio identifier.
        /// </summary>
        /// <value>
        /// The selected radio identifier.
        /// </value>
        int SelectedRadioId { get; set; }
        /// <summary>
        /// Gets or sets the selected timing identifier.
        /// </summary>
        /// <value>
        /// The selected timing identifier.
        /// </value>
        int SelectedTimingId { get; set; }
        /// <summary>
        /// Gets or sets the selected material type identifier.
        /// </summary>
        /// <value>
        /// The selected material type identifier.
        /// </value>
        int SelectedMaterialTypeId { get; set; }
        /// <summary>
        /// Gets or sets the radio service price collection.
        /// </summary>
        /// <value>
        /// The radio service price collection.
        /// </value>
        IList<IRadioServicePriceListModel> RadioServicePriceCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
