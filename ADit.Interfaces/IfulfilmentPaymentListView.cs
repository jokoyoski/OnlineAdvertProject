using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Interfaces
{
    public interface IfulfilmentPaymentListView
    {
        

        /// <summary>
        /// Gets or sets the scripting fulfilment.
        /// </summary>
        /// <value>
        /// The scripting fulfilment.
        /// </value>
        IList<IFulfilmentPayment> ScriptingFulfilment { get; set; }

        /// <summary>
        /// Gets or sets the production fulfilment.
        /// </summary>
        /// <value>
        /// The production fulfilment.
        /// </value>
        IList<IFulfilmentPayment> ProductionFulfilment { get; set; }
        /// <summary>
        /// Gets or sets the procesing message.
        /// </summary>
        /// <value>
        /// The procesing message.
        /// </value>
        string procesingMessage { get; set; }
    }
}