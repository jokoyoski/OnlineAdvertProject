using System.Collections.Generic;
using ADit.Interfaces;

namespace ADit.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.ITvOrderModel" />
    public class TvOrderModel : ITvOrderModel
    {
        /// <summary>
        /// Gets or sets the tvtransaction order.
        /// </summary>
        /// <value>
        /// The tvtransaction order.
        /// </value>
        public IList<ITvTransaction> TvTransaction { get; set; }
    }
}