using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ADit.Domain.Attributes;
using ADit.Interfaces;
using ADit.Interfaces.ValueTypes;

namespace ADit.Controllers
{
    public class ProductionController : Controller
    {

        private readonly IFulfilmentService fulfilmentService;
        private readonly IProductionService productionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptingController" /> class.
        /// </summary>
        /// <param name="fulfilmentService">The fulfilment service.</param>
        /// <param name="scriptingService">The scripting service.</param>
        public ProductionController(IFulfilmentService fulfilmentService, IProductionService productionService)
        {
            this.fulfilmentService = fulfilmentService;
            this.productionService = productionService;
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
                FulfilmentStatus.Production,
                FulfilmentStatus.ProductionCustomerApproval,
                FulfilmentStatus.ProductionCustomerComments,
                FulfilmentStatus.ProductionCustomerApproval,
                FulfilmentStatus.ProductionPaymentPending
            };

            var orderListView = fulfilmentService.GetFulfilmentOrders(scriptingStatusList);
            return View("Index", orderListView);
        }


        /// <summary>
        /// Produces the radio order.
        /// </summary>
        /// <param name="orderFulfilmentId">The order fulfilment identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns>ActionResult.</returns>
        /// <exception cref="ArgumentOutOfRangeException">orderFulfilmentId</exception>
        [CheckUserLogin()]
        public ActionResult ProduceRadioOrder(int orderFulfilmentId, string message)
        {
            if (orderFulfilmentId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(orderFulfilmentId));
            }

            throw new NotImplementedException();
        }








    }
}
