using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ADit.Domain.Attributes;
using ADit.Interfaces;
using ADit.Interfaces.ValueTypes;

namespace ADit.Controllers
{
    public class ScriptingController : Controller
    {

        private readonly IFulfilmentService fulfilmentService;
        private readonly IScriptingService scriptingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptingController" /> class.
        /// </summary>
        /// <param name="fulfilmentService">The fulfilment service.</param>
        /// <param name="scriptingService">The scripting service.</param>
        public ScriptingController(IFulfilmentService fulfilmentService, IScriptingService scriptingService)
        {
            this.fulfilmentService = fulfilmentService;
            this.scriptingService = scriptingService;
        }

        /// <summary>
        /// Scripting listings.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [CheckUserLogin()]
        public ActionResult Index()
        {
            // Get All Scripting status orders
            var scriptingStatusList = new List<string>
            {
                FulfilmentStatus.Scripting,
                FulfilmentStatus.ScriptingCustomerApproval,
                FulfilmentStatus.ScriptingCustomerComments,
                FulfilmentStatus.ScriptingCustomerReview,
                FulfilmentStatus.ScriptingPaymentPending
            };

            var orderListView = fulfilmentService.GetFulfilmentOrders(scriptingStatusList);
            return View("Index", orderListView);
        }
        
        /// <summary>
        /// Scripts the radio order.
        /// </summary>
        /// <param name="orderFulfilmentId">The order fulfilment identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns>ActionResult.</returns>
        [CheckUserLogin()]
        public ActionResult ScriptRadioOrder(int orderFulfilmentId, string message)
        {
            if (orderFulfilmentId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(orderFulfilmentId));
            }
            
            var viewModel = this.scriptingService.GetScriptRadioOrderView(orderFulfilmentId, message);

            return View("ScriptRadioOrder", viewModel);
        }








    }
}
