using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Domain.Models
{
    public class FulfilmentPaymentListView : IfulfilmentPaymentListView
    {
        /// <summary>
        /// Gets or sets the scripting fulfilment.
        /// </summary>
        /// <value>
        /// The scripting fulfilment.
        /// </value>
        public IList<IFulfilmentPayment> ScriptingFulfilment { get; set; }

        /// <summary>
        /// Gets or sets the production fulfilment.
        /// </summary>
        /// <value>
        /// The production fulfilment.
        /// </value>
        public IList<IFulfilmentPayment> ProductionFulfilment { get; set; }

        /// <summary>
        /// Gets or sets the procesing message.
        /// </summary>
        /// <value>
        /// The procesing message.
        /// </value>
        public string procesingMessage { get; set; }
    }
}