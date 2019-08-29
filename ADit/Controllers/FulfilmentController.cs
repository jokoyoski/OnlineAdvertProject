using AA.Infrastructure.Interfaces;
using ADit.Domain.Attributes;
using ADit.Domain.Models;
using ADit.Interfaces;
using ADit.Interfaces.ValueTypes;
using ADit.Interfaces.ValueTypes.Jobs4Moi.Interfaces.ValueTypes;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ADit.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class FulfilmentController : Controller
    {
        private readonly IOrderServices orderServices;
        private readonly IFulfilmentService fulfilmentService;
        private readonly IPrintService printService;
        private readonly IRadioServices radioServices;
        private readonly ISessionStateService session;
        private readonly ITransactionService transactionService;
        private readonly IBrandingService brandingServices;
        private readonly IOnlineServices onlineServices;
        private readonly ILookupService lookupServices;
        private readonly ITvServices tvServices;


        public FulfilmentController(IRadioServices radioServices, ISessionStateService session,
            IFulfilmentService fulfilmentService,
            IPrintService printService, ITransactionService transactionService, IBrandingService brandingServices,
            IOnlineServices onlineServices, ILookupService lookupServices, ITvServices tvServices,
            IOrderServices orderServices)
        {
            this.printService = printService;
            this.radioServices = radioServices;
            this.session = session;
            this.lookupServices = lookupServices;
            this.transactionService = transactionService;
            this.brandingServices = brandingServices;
            this.onlineServices = onlineServices;
            this.tvServices = tvServices;
            this.orderServices = orderServices;
            this.fulfilmentService = fulfilmentService;
        }

        [HttpGet]
        [CheckUserLogin()]
        [AccessAuthorize(Roles = new[]
        {
            AppAction.Administration, AppAction.FulfilmentAdmin, AppAction.FulfilmentViewOnly, AppAction.Scripting,
            AppAction.Scheduling, AppAction.Transmission, AppAction.Production, AppAction.Closure
        })]
        public ActionResult Index()
        {
            var summary = fulfilmentService.GetFulfilmentSummary();
            return View("Index", summary);
        }

        /// <summary>
        /// Dashboards the detail popup.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult DashboardDetailPopup(string status)
        {
            var serviceInfo = fulfilmentService.GetFulfilmentServiceSummary(status);
            return PartialView("DashboardDetailPopup", serviceInfo);
        }

        #region FulfilmentList

        /// <summary>
        /// Fulfilments' the list.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        [CheckUserLogin()]
        [AccessAuthorize(Roles = new[]
        {
            AppAction.Administration, AppAction.FulfilmentAdmin, AppAction.FulfilmentViewOnly, AppAction.Scripting,
            AppAction.Scheduling, AppAction.Transmission, AppAction.Production, AppAction.Closure
        })]
        public ActionResult FulfilmentList(string status)
        {
            var orders = fulfilmentService.GetFulfilmentOrders(status);
            return View("FulfilmentList", orders);
        }
        #endregion

        // GET: Producer

        #region Radio Transaction


        /// <summary>
        /// Orders the fulfilemt.
        /// </summary>
        /// <param name="orderFulfilmentActivityView">The order fulfilment activity view.</param>
        /// <param name="fileBase">The file base.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="OrderId">The order identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult OrderFulfilment(OrderFulfilmentActivityView orderFulfilmentActivityView,
            HttpPostedFileBase fileBase)
        {
            if (orderFulfilmentActivityView == null)
            {
                throw new ArgumentNullException(nameof(orderFulfilmentActivityView));
            }

            var order = fulfilmentService.SaveOrderFulfilment(orderFulfilmentActivityView, fileBase);

            return RedirectToAction(orderFulfilmentActivityView.URL,
                new
                {
                    orderFulfilmentId = orderFulfilmentActivityView.OrderFulfilmentId,
                    processingMessage = "Order Status updated"
                });
        }

        #endregion


        #region Scripting Payment

        /// <summary>
        /// Orders the fulfilemt.
        /// </summary>
        /// <param name="orderFulfilmentActivityView">The order fulfilment activity view.</param>
        /// <param name="fileBase">The file base.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="OrderId">The order identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult ScriptingFulfilmentPayment(FufilmentPaymentView fulfilmentPaymentView)
        {
            if (fulfilmentPaymentView == null)
            {
                throw new ArgumentNullException(nameof(fulfilmentPaymentView));
            }


            var order = fulfilmentService.SaveScriptingFulfilmentPayment(fulfilmentPaymentView);

            if (!string.IsNullOrEmpty(order))
            {
                return View("ScriptingFulfilmentPayment", order);
            }

            ;


            return RedirectToAction(fulfilmentPaymentView.URL,
                new
                {
                    userId = fulfilmentPaymentView.UserId,
                    orderFulfilmentId = fulfilmentPaymentView.OrderFulfilmentId,
                    processingMessage = "Scripting Payment Updated"
                });
        }

        #endregion


        #region Production Payment

        /// <summary>
        /// Orders the fulfilemt.
        /// </summary>
        /// <param name="orderFulfilmentActivityView">The order fulfilment activity view.</param>
        /// <param name="fileBase">The file base.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="OrderId">The order identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult ProductionFulfilmentPayment(FufilmentPaymentView fulfilmentPaymentView)
        {
            var order = fulfilmentService.SaveProductionFulfilmentPayment(fulfilmentPaymentView);

            if (!string.IsNullOrEmpty(order))
            {
                return View("FulfilmentList", order);
            }

            ;


            return RedirectToAction(fulfilmentPaymentView.URL,
                new
                {
                    transactionId = fulfilmentPaymentView.transactionId,
                    orderFulfilmentId = fulfilmentPaymentView.OrderFulfilmentId,
                    processingMessage = "Production Payment Updated"
                });
        }

        #endregion

        /// <summary>
        /// Files the result.
        /// </summary>
        /// <param name="fileId">The file identifier.</param>
        /// <returns></returns>
        public FileResult FileResult(int fileId)
        {
            var scriptFile = radioServices.GetScriptFileForDownload(fileId);


            return File(scriptFile.FileContent, scriptFile.ContentType);
        }


        #region Online Services

        /// <summary>
        /// Called when [transactions].
        /// </summary>
        /// <returns></returns>

        [CheckUserLogin()]
        public ActionResult OnlineTransactions(int orderFulfilmentId, string processingMessage)
        {
            if (orderFulfilmentId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(orderFulfilmentId));
            }



            var onlineTransactionList = fulfilmentService.GetFulfilmentOnlineTransaction(orderFulfilmentId, processingMessage);
            return View("OnlineTransactions", onlineTransactionList);
        }

        #endregion


        #region Branding Services

        //gets all branding transactions for the producer
        /// <summary>
        /// Brandings the transactions.
        /// </summary>
        /// <returns></returns>

        [CheckUserLogin()]
        public ActionResult BrandingTransactions(int orderFulfilmentId, string processingMessage)
        {

            if (orderFulfilmentId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(orderFulfilmentId));
            }

            var brandingTransactionList = fulfilmentService.GetFulfilmentBrandingView(orderFulfilmentId, processingMessage);
            return View("BrandingTransactions", brandingTransactionList);
        }

        #endregion


        #region Tv Transaction

        /// <summary>
        /// Saves the tv material replies.
        /// </summary>
        /// <param name="FileId">The file identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">messageRepliesListView</exception>
        public FileResult TvfileResult(int FileId)
        {
            var scriptFile = tvServices.GetScriptFileForDownload(FileId);


            return File(scriptFile.FileContent, scriptFile.ContentType);
        }


        /// <summary>
        /// Tvs the transaction.
        /// </summary>
        /// <param name="selectedTvTransactionId">The selected tv transaction identifier.</param>
        /// <param name="selectedUserId">The selected user identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        [CheckUserLogin()]
        public ActionResult TvTransaction(int orderFulfilmentId, string processingMessage)
        {
            if (orderFulfilmentId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(orderFulfilmentId));
            }

            var viewModel = fulfilmentService.GetFulfilmentTvTransaction(orderFulfilmentId, processingMessage);
            return View("TvTransaction", viewModel);
        }

        #endregion


        #region Print Transaction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        [CheckUserLogin()]
        public ActionResult PrintTransactions(int orderFulfilmentId, string processingMessage)
        {
            if (orderFulfilmentId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(orderFulfilmentId));
            }

            var viewModel = fulfilmentService.GetFufillmentPrintTransaction(orderFulfilmentId, processingMessage);
            return View("PrintTransactions", viewModel);
        }


        /// <summary>

        #endregion


        #region FufilPayment
        /// <summary>
        /// Pendings the fulfilment payment.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult PendingFulfilmentPayment(string processingMessage)

        {
            var userId = (int)session.GetSessionValue(SessionKey.UserId);

            var order = orderServices.GetPendingFulfilmentPayment(userId, processingMessage);

            return View("FulfilmentPayment", order);
        }



        /// <summary>
        /// Pendings the fufilment payment.
        /// </summary>
        /// <param name="orderSummary">The order summary.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public async Task FulfilmentPayment(OrderSummaryListView orderSummary)
        {
            var email = (string)session.GetSessionValue(SessionKey.UserName);

            await MakeFulfilmentPayment(email, (int)orderSummary.TotalAmount, orderSummary.OrderId, orderSummary.paymentPurpose);
        }
        /// <summary>
        /// Makes the fulfilment payment.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="totalAmount">The total amount.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        [CheckUserLogin()]
        protected async Task MakeFulfilmentPayment(string email, int totalAmount, int orderId, string paymentPurpose)
        {
            var response =
                await fulfilmentService.InitializeTransaction(email, totalAmount, orderId, paymentPurpose);


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
        public async Task<ActionResult> FulfilmentCompleted(int orderId, string paymentPurpose, string reference)
        {
            //Get The Currently Logged User Id
            var userId = (int)session.GetSessionValue(SessionKey.UserId);
            var response = await transactionService.VerifyTransaction(reference);

            if (paymentPurpose == "FulfilmentScripting")
            {
                fulfilmentService.UpdateFulfilmentScripting(orderId, reference);
            }

            if (paymentPurpose == "FulfilmentProduction")
            {
                fulfilmentService.UpdateFulfilmentProduction(orderId, reference);
            }



            //Send Message of the Transaction to the Administrator
            fulfilmentService.SendNewFulfilmnetEmail(response.data.customer.email, response.data.amount, paymentPurpose);

            transactionService.PendingFulfilment(userId);
            return RedirectToAction("PendingFulfilmentPayment", new { processingMessage = "Payment Completed" });
        }
        #endregion



        #region FulfilmentStages
        /// <summary>
        /// Picks lists of orders in submitted status.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [CheckUserLogin()]
        public ActionResult Pick(string message)
        {
            //Get All Orders in submitted status to be picked
            var orderListView = fulfilmentService.GetFulfilmentOrders(FulfilmentStatus.Submitted);

            return View("Pick", orderListView);
        }


        /// <summary>
        /// Picks order the popup view.
        /// </summary>
        /// <param name="orderFulfilmentId">The order fulfilment identifier.</param>
        /// <returns>ActionResult.</returns>
        /// <exception cref="ArgumentOutOfRangeException">orderFulfilmentId</exception>
        [HttpGet]
        public ActionResult PickPopup(int orderFulfilmentId)
        {
            if (orderFulfilmentId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(orderFulfilmentId));
            }

            var transactionView = fulfilmentService.GetFulfilmentOrderByFulfilmentId(orderFulfilmentId);

            return PartialView("PickPopup", transactionView);
        }

        /// <summary>
        /// Picks the popup.
        /// </summary>
        /// <param name="orderFulfilmentId">The order fulfilment identifier.</param>
        /// <param name="isSendMail">if set to <c>true</c> [is send mail].</param>
        /// <param name="createdByUserId">The created by user identifier.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult PickPopup(int orderFulfilmentId, bool? isSendMail, int createdByUserId)
        {
            if (orderFulfilmentId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(orderFulfilmentId));
            }

            var processingMessage = fulfilmentService.PickOrder(orderFulfilmentId, isSendMail ?? false, createdByUserId);

            return RedirectToAction("Pick", new { message = processingMessage });
        }
        
        #endregion

    }
}