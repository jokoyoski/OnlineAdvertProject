using ADit.Interfaces;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IYesNoQuestion" />
    public class YesNoQuestionModel:IYesNoQuestion
    {

        /// <summary>
        /// Gets or sets the yes no question code.
        /// </summary>
        /// <value>
        /// The yes no question code.
        /// </value>
        public bool YesNoQuestionCode { get; set; }


        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}