using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IApconApprovalTypePriceListView
    {
        /// <summary>
        /// Gets or sets the selected apcon approval type price identifier.
        /// </summary>
        /// <value>
        /// The selected apcon approval type price identifier.
        /// </value>
        int SelectedApconApprovalTypePriceId { get; set; }
        /// <summary>
        /// Gets or sets the selected apcon approval identifier.
        /// </summary>
        /// <value>
        /// The selected apcon approval identifier.
        /// </value>
        int SelectedApconApprovalId { get; set; }
        /// <summary>
        /// Gets or sets the apcon approval type price collection.
        /// </summary>
        /// <value>
        /// The apcon approval type price collection.
        /// </value>
        IList<IApconApprovalTypePrice> ApconApprovalTypePriceCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
