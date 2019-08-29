namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IContact
    {
        /// <summary>
        /// Gets or sets the contact identifier.
        /// </summary>
        /// <value>
        /// The contact identifier.
        /// </value>
        int ContactId { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        string Email { get; set; }
        /// <summary>
        /// Gets or sets the decsription.
        /// </summary>
        /// <value>
        /// The decsription.
        /// </value>
        string Decsription { get; set; }
    }
}
