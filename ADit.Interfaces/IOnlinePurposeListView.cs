using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOnlinePurposeListView
    {

        /// <summary>
        /// Gets or sets the select online purpose identifier.
        /// </summary>
        /// <value>
        /// The select online purpose identifier.
        /// </value>
        int SelectOnlinePurposeId { get; set; }

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
        /// Gets or sets the online purpose collection.
        /// </summary>
        /// <value>
        /// The online purpose collection.
        /// </value>
        IList<IOnlinePurpose> OnlinePurposeCollection { get; set; }


        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
