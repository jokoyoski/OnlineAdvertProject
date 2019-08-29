using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IScriptingPriceListView
    {
        /// <summary>
        /// Gets or sets the selected material scripting price identifier.
        /// </summary>
        /// <value>
        /// The selected material scripting price identifier.
        /// </value>
        int SelectedMaterialScriptingPriceId { get; set; }

        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        string selectedDescription { get; set; }

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
        /// Gets or sets the material scripting price collection.
        /// </summary>
        /// <value>
        /// The material scripting price collection.
        /// </value>
        IList<IMaterialScriptingPrice> MaterialScriptingPriceCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
