using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IScriptingViewList
    {
        /// <summary>
        /// Gets or sets the selected topic.
        /// </summary>
        /// <value>
        /// The selected topic.
        /// </value>
        string SelectedTopic { get; set; }
        /// <summary>
        /// Gets or sets the scripting detail collection.
        /// </summary>
        /// <value>
        /// The scripting detail collection.
        /// </value>
        IList<IScriptingDetailModel> ScriptingDetailCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
