using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IApconApprovalTypeListView
    {
        /// <summary>
        /// Gets or sets the selected apcon approval type identifier.
        /// </summary>
        /// <value>
        /// The selected apcon approval type identifier.
        /// </value>
        int SelectedApconApprovalTypeId { get; set; }

        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        string SelectedDescription { get; set; }


        /// <summary>
        /// Gets or sets the apcon approval type collection.
        /// </summary>
        /// <value>
        /// The apcon approval type collection.
        /// </value>
        IList<IApconApprovalType> ApconApprovalTypeCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
