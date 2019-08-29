﻿namespace ADit.Interfaces
{
   public interface ITiming
    {
        /// <summary>
        /// Gets or sets the timing identifier.
        /// </summary>
        /// <value>
        /// The timing identifier.
        /// </value>
        int TimingId { get; set; }
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
    }
}
