using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRadioProductionListView
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the radio transaction identifier.
        /// </summary>
        /// <value>
        /// The radio transaction identifier.
        /// </value>
        int RadioTransactionId { get; set; }






        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        string OrderTitle { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string processingMessage { get; set; }
        /// <summary>
        /// Gets or sets the radio production collection.
        /// </summary>
        /// <value>
        /// The radio production collection.
        /// </value>
        IList<IRadioProduction> radioProductionCollection { get; set; }

        /// <summary>
        /// Gets or sets the uploaded production material detail.
        /// </summary>
        /// <value>
        /// The uploaded production material detail.
        /// </value>
        IDigitalFile UploadedProductionMaterialDetail { get; set; }

        /// <summary>
        /// Gets or sets the new uploaded production material detail.
        /// </summary>
        /// <value>
        /// The new uploaded production material detail.
        /// </value>
        IDigitalFile NewUploadedProductionMaterialDetail { get; set; }
    }
}