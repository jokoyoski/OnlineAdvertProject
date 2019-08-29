using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Interfaces
{
   public interface IFulfilmentServiceSummaryModel
    {
        /// <summary>
        /// Gets or sets the order by service code count.
        /// </summary>
        /// <value>
        /// The order by service code count.
        /// </value>
        int OrderByServiceCodeCount { get; set; }

        /// <summary>
        /// Gets or sets the service code description.
        /// </summary>
        /// <value>
        /// The service code description.
        /// </value>
        string ServiceCodeDescription { get; set; }
    }
}
