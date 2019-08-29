namespace ADit.Interfaces
{
    public interface IDurationType
    {
        /// <summary>
        /// Gets or sets the duration type code.
        /// </summary>
        /// <value>
        /// The duration type code.
        /// </value>
        string DurationTypeCode { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        bool  IsActive { get; set; }
    }
}
