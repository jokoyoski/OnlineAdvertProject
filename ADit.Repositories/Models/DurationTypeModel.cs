using ADit.Interfaces;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IDurationType" />
    public class DurationTypeModel : IDurationType
    {
        /// <summary>
        /// Gets or sets the duration type code.
        /// </summary>
        /// <value>
        /// The duration type code.
        /// </value>
        public string DurationTypeCode { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public bool IsActive { get; set; }
    }
}
