namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITimeBelt
    {
        /// <summary>
        /// Gets or sets the time belt identifier.
        /// </summary>
        /// <value>
        /// The time belt identifier.
        /// </value>
        int TimeBeltId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string name { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool isActive { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }
    }
}
