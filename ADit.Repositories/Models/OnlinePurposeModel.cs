using ADit.Interfaces;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IOnlinePurpose" />
    public class OnlinePurposeModel :IOnlinePurpose
    {
        /// <summary>
        /// Gets or sets the online purpose identifier.
        /// </summary>
        /// <value>
        /// The online purpose identifier.
        /// </value>
        public int OnlinePurposeId { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
