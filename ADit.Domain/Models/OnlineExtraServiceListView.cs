using ADit.Interfaces;
using System.Collections.Generic;

namespace ADit.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IOnlineExtraServiceListView" />
    public class OnlineExtraServiceListView : IOnlineExtraServiceListView
    {
        /// <summary>
        /// Gets or sets the online extra service identifier.
        /// </summary>
        /// <value>
        /// The online extra service identifier.
        /// </value>
        public int SelectOnlineExtraServiceId { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string SelectDescription { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the online extra service collection.
        /// </summary>
        /// <value>
        /// The online extra service collection.
        /// </value>
        public IList<IOnlineExtraService> OnlineExtraServiceCollection { get; set; }
    }
}
