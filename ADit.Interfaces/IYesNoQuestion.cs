namespace ADit.Interfaces
{
    public interface IYesNoQuestion
    {
        /// <summary>
        /// Gets or sets the yes no question code.
        /// </summary>
        /// <value>
        /// The yes no question code.
        /// </value>
        bool YesNoQuestionCode { get; set; }


        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }
    }
}