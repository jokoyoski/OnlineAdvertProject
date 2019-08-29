using ADit.Interfaces;
using System.Collections.Generic;

namespace ADit.Domain.Models
{
    public class ScriptingViewList : IScriptingViewList
    {
        /// <summary>
        /// Gets or sets the selected topic.
        /// </summary>
        /// <value>
        /// The selected topic.
        /// </value>
        public string SelectedTopic { get; set; }
        /// <summary>
        /// Gets or sets the scripting detail collection.
        /// </summary>
        /// <value>
        /// The scripting detail collection.
        /// </value>
        public IList<IScriptingDetailModel> ScriptingDetailCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
