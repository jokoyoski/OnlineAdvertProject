﻿namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IApconApprovalView
    {
        /// <summary>
        /// Gets or sets the apcon approval type identifier.
        /// </summary>
        /// <value>
        /// The apcon approval type identifier.
        /// </value>
        int ApconApprovalTypeId { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }
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
    }
}
