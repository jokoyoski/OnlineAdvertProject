using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOnlineExtraServiceListView
    {

        /// <summary>
        /// Gets or sets the select online extra service identifier.
        /// </summary>
        /// <value>
        /// The select online extra service identifier.
        /// </value>
        int SelectOnlineExtraServiceId { get; set; }

        /// <summary>
        /// Gets or sets the select description.
        /// </summary>
        /// <value>
        /// The select description.
        /// </value>
        string SelectDescription { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }


        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }


        /// <summary>
        /// Gets or sets the online extra service collection.
        /// </summary>
        /// <value>
        /// The online extra service collection.
        /// </value>
        IList<IOnlineExtraService> OnlineExtraServiceCollection { get; set; }

    }
}
