using ADit.Interfaces;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IScriptMaterialQuestion" />
    public class ScriptMaterialQuestionModel : IScriptMaterialQuestion
    {
        /// <summary>
        /// Gets or sets the script material question code.
        /// </summary>
        /// <value>
        /// The script material question code.
        /// </value>
        public string ScriptMaterialQuestionCode { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}
