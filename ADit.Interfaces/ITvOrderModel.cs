using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITvOrderModel
    {
        /// <summary>
        /// Gets or sets the tv transaction.
        /// </summary>
        /// <value>
        /// The tv transaction.
        /// </value>
        IList<ITvTransaction> TvTransaction { get; set; }
    }
}