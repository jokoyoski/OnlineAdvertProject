using ADit.Interfaces;
using System.Collections.Generic;

namespace ADit.Domain.Models
{
    public class ScriptingPriceListView : IScriptingPriceListView
    {

        /// <summary>
        /// Gets or sets the selected material scripting price identifier.
        /// </summary>
        /// <value>
        /// The selected material scripting price identifier.
        /// </value>
        public int SelectedMaterialScriptingPriceId { get; set; }
        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        public string selectedDescription { get; set; }
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
        /// Gets or sets the material scripting price collection.
        /// </summary>
        /// <value>
        /// The material scripting price collection.
        /// </value>
        public IList<IMaterialScriptingPrice> MaterialScriptingPriceCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
