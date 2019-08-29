using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Interfaces
{
  public  interface IFulfilmentServiceSummaryView
    {

        /// <summary>
        /// Gets or sets the fulfilment service summaries.
        /// </summary>
        /// <value>
        /// The fulfilment service summaries.
        /// </value>
        IList<IFulfilmentServiceSummaryModel> FulfilmentServiceSummaries { get; set; }
    }
}

