using ADit.Interfaces;
using System.Collections.Generic;

namespace ADit.Domain.Models
{
  public   class RadioProductionListView :IRadioProductionListView
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// </summary>
        public int RadioTransactionId { get; set; }


        /// <summary>
        /// Gets or sets the uploaded production material detail.
        /// </summary>
        /// <value>
        /// The uploaded production material detail.
        /// </value>
        public IDigitalFile UploadedProductionMaterialDetail { get; set; }
        /// <summary>
        /// Gets or sets the new uploaded production material detail.
        /// </summary>
        /// <value>
        /// The new uploaded production material detail.
        /// </value>
        public IDigitalFile NewUploadedProductionMaterialDetail { get; set; }


        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        public string OrderTitle { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string processingMessage { get; set; }
        /// <summary>
        /// </summary>
        public IList<IRadioProduction> radioProductionCollection { get; set; }
    }
}
