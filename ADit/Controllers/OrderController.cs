using System.Web;
using System.Web.Mvc;
using AA.Infrastructure.Interfaces;
using ADit.Domain.Models;
using ADit.Interfaces;
using ADit.Interfaces.ValueTypes;
using System;
using System.Threading.Tasks;
using ADit.Domain.Attributes;

namespace ADit.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ITransactionService transactionService;
        private readonly ISessionStateService session;
        private readonly IOrderServices orderServices;
        private readonly IFulfilmentService fulfilmentService;


        public OrderController(ITransactionService transactionService, ISessionStateService session,
            IOrderServices orderServices, IFulfilmentService fulfilmentService)
        {
            this.transactionService = transactionService;
            this.session = session;
            this.orderServices = orderServices;
            this.fulfilmentService = fulfilmentService;
        }


        #region Order Summary Page

        /// <summary>
        /// Summaries the redirect.
        /// To Help Redirect to the Summar Page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult SummaryRedirect()
        {
            //Get The Currently Logged User Id
            var userId = (int) session.GetSessionValue(SessionKey.UserId);

            //Get The Pending Order For the user.

            // There can only be one pending order at a time
            var order = this.transactionService.GetPendingOrderByUserId(userId);
            if (order != null)
            {
                return this.RedirectToAction("Summary", "Order", new {orderId = order.OrderId});
            }

            return this.RedirectToAction("ViewOrder", "Order");
        }


        /// <summary>
        /// Summaries this instance.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">orderId</exception>
        /// <exception cref="ArgumentNullException">order</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult Summary(int orderId, string message)
        {
            if (orderId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(orderId));
            }

            //Get The Currently Logged User Id
            var userId = (int) session.GetSessionValue(SessionKey.UserId);

            //var Order Information this  Order so that i can check that the order Belongs to this user
            var order = this.transactionService.GetOrderNumberInfo(userId, orderId);

            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            var model = this.transactionService.GetCartSummary(order, message);
            return View("Summary", model);
        }


        /// <summary>
        /// Summaries the specified view.
        /// </summary>
        /// <param name="orderSummary">The view.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public async Task Summary(OrderSummaryListView orderSummary)
        {
            var email = (string) session.GetSessionValue(SessionKey.UserName);

            await MakePayment(email, (int) orderSummary.TotalAmount, orderSummary.OrderId);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [CheckUserLogin()]
        public ActionResult DeleteOrder(int orderId)
        {
            if (orderId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(orderId));
            }

            var result = this.transactionService.DeleteOrder(orderId);

            return RedirectToAction("SummaryRedirect", "Order");
        }


        #region Payment

        /// <summary>
        /// Makes the payment.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="totalAmount">The total amount.</param>
        /// <param name="orderNumber">The order number.</param>
        /// <returns></returns>
        protected async Task MakePayment(string email, int totalAmount, int orderId)
        {
            var response =
                await this.transactionService.InitializeTransaction(email, totalAmount, orderId);


            if (response.status)
            {
                Response.AddHeader("Access-Control-Allow-Origin", "*");
                Response.AppendHeader("Access-Control-Allow-Origin", "*");

                Response.Redirect(response.data.authorization_url); //Redirects your browser to the secure URL
            }
            else //not successful
            {
            }
        }
        

        /// <summary>
        /// Transactions the completed.
        /// </summary>
        /// <param name="orderId">The order number.</param>
        /// <param name="reference">The reference.</param>
        /// <returns></returns>
        [CheckUserLogin()]
        public async Task<ActionResult> TransactionCompleted(int orderId, string reference)
        {
            //Get The Currently Logged User Id
            var userId = (int) this.session.GetSessionValue(SessionKey.UserId);
            var response = await this.transactionService.VerifyTransaction(reference);
            //Store User Payment Information
            var processingMessage = this.transactionService.ProcessPayment(reference, orderId, userId, response);
            var order = this.orderServices.GetOrderNumberByOrderId(orderId);


            //TODO: Generate and Send Invoice to User


            //Send Message of the Transaction to the Administrator
            this.orderServices.SendNewOrderEmail(response.data.customer.email, response.data.amount, order.OrderNumber);
            //Remove Cart Number
            this.session.RemoveSessionValue(SessionKey.CartNumber);

            return this.RedirectToAction("Summary", "Order", new {orderId = orderId, processingMessage});
        }

        #endregion


        /// <summary>
        /// Removes the specified service.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="remove">The remove.</param>
        /// <returns></returns>
        /// sss
        public ActionResult Remove(string service, int remove)
        {
            return RedirectToAction("Summary");
        }


        /// <summary>
        /// Views the order.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult ViewOrder()
        {
            var userId = (int) this.session.GetSessionValue(SessionKey.UserId);
            var order = this.orderServices.GetOrders(userId);

            return View("ViewOrder", order);
        }


        /// <summary>
        /// Edits the tv order.
        /// </summary>
        /// <param name="tvView">The tv view.</param>
        /// <param name="scriptingMaterial">The scripting material.</param>
        /// <param name="productionMaterial">The production material.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditTvOrder(TvView tvView, HttpPostedFileBase scriptingMaterial,
            HttpPostedFileBase productionMaterial)
        {
            return RedirectToAction("Summary");
        }


      
    }
}