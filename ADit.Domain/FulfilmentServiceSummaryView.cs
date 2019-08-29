using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Domain
{
   public class FulfilmentServiceSummaryView : IFulfilmentServiceSummaryView
    {

        /// <summary>
        /// Gets or sets the fulfilment service summaries.
        /// </summary>
        /// <value>
        /// The fulfilment service summaries.
        /// </value>
        public IList<IFulfilmentServiceSummaryModel> FulfilmentServiceSummaries { get; set; }
    }
}

