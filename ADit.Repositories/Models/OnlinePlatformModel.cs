﻿using ADit.Interfaces;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IOnlinePlatform" />
    public class OnlinePlatformModel : IOnlinePlatform
    {
        /// <summary>
        /// Gets or sets the online platform identifier.
        /// </summary>
        /// <value>
        /// The online platform identifier.
        /// </value>
        public int OnlinePlatformId { get; set; }
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
