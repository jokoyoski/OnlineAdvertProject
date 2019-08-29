using AA.Infrastructure.Interfaces;
using ADit.Domain.Attributes;
using ADit.Domain.Models;
using ADit.Interfaces;
using ADit.Interfaces.ValueTypes;
using ADit.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace ADit.Controllers
{
    public class OnlineController : Controller
    {
        private readonly IOnlineServices onlineServices;
        private readonly ISessionStateService session;
        private readonly ITransactionService transactionService;
        private readonly ILookupService lookupService;
        private readonly IOrderServices orderServices;

        public OnlineController(IOnlineServices onlineServices, ITransactionService transactionService,
            ISessionStateService session, ILookupService lookupService, IOrderServices orderServices)
        {
            this.onlineServices = onlineServices;
            this.transactionService = transactionService;
            this.session = session;
            this.lookupService = lookupService;

            this.orderServices = orderServices;
        }

        #region Online Service Main Transaction Setup

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult Index()
        {
            var onlineView = this.onlineServices.GetView();

            return View("Index", onlineView);
        }


        /// <summary>
        /// Indexes the specified online main transaction.
        /// </summary>
        /// <param name="onlineMainTransaction">The online main transaction.</param>
        /// <param name="transactionAiring">The transaction airing.</param>
        /// <param name="selectedOnlinePlatformIds">The selected online platform ids.</param>
        /// <param name="artWorkUpload">The art works.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// onlineMainTransaction
        /// or
        /// transactionAiring
        /// or
        /// selectedOnlinePlatformIds
        /// </exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult Index(OnlineTransactionUIView onlineMainTransaction,
            List<OnlineTransactionAiringUI> transactionAiring, List<int> selectedOnlinePlatformIds,
            HttpPostedFileBase artWorkUpload)
        {
            if (onlineMainTransaction == null)
            {
                throw new ArgumentNullException(nameof(onlineMainTransaction));
            }

            if (transactionAiring == null)
            {
                throw new ArgumentNullException(nameof(transactionAiring));
            }

            if (selectedOnlinePlatformIds == null)
            {
                throw new ArgumentNullException(nameof(selectedOnlinePlatformIds));
            }


            if (!ModelState.IsValid)
            {
                var viewModel = this.onlineServices.GetUpdatedView(onlineMainTransaction, transactionAiring,
                    selectedOnlinePlatformIds, "");

                return View("Index", viewModel);
            }

            var processingMessage = string.Empty;
            int orderId = -1;


            processingMessage = this.onlineServices.Processview(onlineMainTransaction, transactionAiring,
                selectedOnlinePlatformIds, artWorkUpload, out orderId);


            if (!string.IsNullOrEmpty(processingMessage))
            {
                var viewModel = this.onlineServices.GetUpdatedView(onlineMainTransaction, transactionAiring,
                    selectedOnlinePlatformIds, processingMessage);

                return View("Index", viewModel);
            }


            return this.RedirectToAction("Summary", "Order",
                new {orderId = orderId, message = "Online transaction added to cart"});
        }


        /// <summary>
        /// Edits the cart.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">transactionId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditCart(int transactionId)
        {
            if (transactionId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(transactionId));
            }

            //get the view model
            var model = this.onlineServices.GetEditOnlineCartView(transactionId);


            return View("EditCart", model);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="onlineView"></param>
        /// <param name="transactionAiring"></param>
        /// <param name="selectedOnlinePlatformIds"></param>
        /// <param name="artWorks"></param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditCart(OnlineTransactionUI onlineView, List<OnlineTransactionAiringUI> transactionAiring,
            List<int> selectedOnlinePlatformIds, HttpPostedFileBase artWorks)
        {
            if (onlineView == null)
            {
                throw new ArgumentNullException(nameof(onlineView));
            }

            if (transactionAiring == null)
            {
                throw new ArgumentNullException(nameof(transactionAiring));
            }

            if (selectedOnlinePlatformIds == null)
            {
                throw new ArgumentNullException(nameof(selectedOnlinePlatformIds));
            }

            if (!ModelState.IsValid)
            {
                var viewModel =
                    this.onlineServices.GetUpdatedView(onlineView, transactionAiring, selectedOnlinePlatformIds, "");

                return View("EditCart", viewModel);
            }


            var processingMessage = string.Empty;
            int orderId = -1;


            //Update The Television Transaction Details
            processingMessage = this.onlineServices.UpdateOnlineTransaction(onlineView, transactionAiring,
                selectedOnlinePlatformIds, artWorks, out orderId);


            if (!string.IsNullOrEmpty(processingMessage))
            {
                var viewModel =
                    this.onlineServices.GetUpdatedView(onlineView, transactionAiring, selectedOnlinePlatformIds, "");

                return View("EditCart", viewModel);
            }

            var returnMessage = string.Format("Online Transaction updated");

            return RedirectToAction("Summary", "Order",
                new {orderId = onlineView.OrderId, message = returnMessage});
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        [CheckUserLogin()]
        public ActionResult DeleteOrderById(int transactionId)
        {
            if (transactionId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(transactionId));
            }

            this.onlineServices.DeleteOrder(transactionId);


            //Get The Currently Logged User Id
            var userId = (int) session.GetSessionValue(SessionKey.UserId);

            // Get order id
            var orderId = this.orderServices.GetOrderIdentifier(userId);

            //Update Cart
            this.transactionService.UpdateCart(orderId);

            return RedirectToAction("SummaryRedirect", "Order");
        }

        #endregion


        #region Online Platform setup

        // use to show the list of online platform
        [CheckUserLogin()]
        public ActionResult OnlinePlatformList(int? selectOnlinePlatformId, string selectDescription, string message)


        {
            var onlinePlatformModel =
                this.onlineServices.GetOnlinePlatformListViewModel(selectOnlinePlatformId ?? 0, selectDescription,
                    message);
            return this.PartialView("OnlinePlatformList", onlinePlatformModel);
        }


        [HttpGet]
        [CheckUserLogin()]
        public ActionResult AddOnlinePlatform()
        {
            var onlineView = this.onlineServices.GetOnlinePlatformView();
            return View("AddOnlinePlatform", onlineView);
        }


        [HttpPost]
        [CheckUserLogin()]
        public ActionResult AddOnlinePlatform(OnlinePlatformView onlinePlatformView)
        {
            if (onlinePlatformView == null)
            {
                throw new ArgumentException(nameof(AddOnlinePlatform));
            }

            if (!ModelState.IsValid)
            {
                var onlinePlatformModel = this.onlineServices.GetOnlinePlatformView(onlinePlatformView, string.Empty);
                return this.View("AddOnlinePlatform", onlinePlatformModel);
            }


            var processingMessage = this.onlineServices.ProcessOnlinePlatformInfo(onlinePlatformView);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var onlinePlatformModel =
                    this.onlineServices.GetOnlinePlatformView(onlinePlatformView, processingMessage);
                return View("AddOnlinePlatform", onlinePlatformModel);
            }

            processingMessage = string.Format("Online Platform Saved");

            return RedirectToAction("OnlinePlatformList", new {message = processingMessage});
        }


        /// <summary>
        /// Edits the online platform.
        /// </summary>
        /// <param name="onlinePlatformId">The online platform identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditOnlinePlatform(int onlinePlatformId)
        {
            if (onlinePlatformId <= 0)
            {
                throw new ArgumentNullException(nameof(onlinePlatformId));
            }


            var onlinePlatformModel = this.onlineServices.GetSelectedOnlinePlatformInfo(onlinePlatformId);

            return this.PartialView("EditOnlinePlatform", onlinePlatformModel);
        }

        /// <summary>
        /// Edits the online platform.
        /// </summary>
        /// <param name="onlinePlatformView">The online platform view.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditOnlinePlatform(OnlinePlatformView onlinePlatformView)
        {
            if (onlinePlatformView == null)
            {
                throw new ArgumentNullException(nameof(onlinePlatformView));
            }

           
            if (!ModelState.IsValid)
            {
                var onlinePlatformModel = this.onlineServices.GetOnlinePlatformView(onlinePlatformView, string.Empty);
                return this.PartialView("AddOnlinePlatform", onlinePlatformModel);
            }

            var processingMessage = this.onlineServices.UpdateOnlinePlatformInfo(onlinePlatformView);


            if (!string.IsNullOrEmpty(processingMessage))
            {
                var OnlinePlatformModel =
                    this.onlineServices.GetOnlinePlatformView(onlinePlatformView, processingMessage);
                return View("AddOnlinePlatform", OnlinePlatformModel);
            }

            processingMessage = string.Format("Online Platform Updated ");

            return this.RedirectToAction("OnlinePlatformList",
                new {message = processingMessage});
        }

        /// <summary>
        /// Deletes the online platform.
        /// </summary>
        /// <param name="onlinePlatformId">The online platform identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeleteOnlinePlatform(int onlinePlatformId)
        {
            if (onlinePlatformId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(onlinePlatformId));
            }

            var onlinePlatformModel = this.onlineServices.GetSelectedOnlinePlatformInfo(onlinePlatformId);
            return this.PartialView("DeleteOnlinePlatform", onlinePlatformModel);
        }

        /// <summary>
        /// Deletes the online platform.
        /// </summary>
        /// <param name="onlinePlatformView">The online platform view.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteOnlinePlatform(int onlinePlatformId, string btnSubmit)
        {
            if (onlinePlatformId < 1)
            {
                throw new ArgumentOutOfRangeException("onlinePlatformId");
            }

            this.onlineServices.ProcessDeleteOnlinePlatformInfo(onlinePlatformId);

            var processingMessage = string.Format("Online Platform Deleted ");

            return this.RedirectToAction("OnlinePlatformList",
                new {message = processingMessage});
        }

        #endregion


        #region Online Purpose Setup

        //shows a list of online purposeList
        [CheckUserLogin()]
        public ActionResult OnlinePurposeList(int? selectOnlinePurposeId, string selectDescription, string message)


        {
            var onlinePurposeModel =
                this.onlineServices.GetOnlinePurposeListViewModel(selectOnlinePurposeId ?? 0, selectDescription,
                    message);
            return View("OnlinePurposeList", onlinePurposeModel);
        }

        /// <summary>
        /// Adds the online purpose.
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult AddOnlinePurpose()
        {
            var onlineView = this.onlineServices.CreateOnlinePurposeView();
            return View("AddOnlinePurpose", onlineView);
        }

        //saves online purpose        
        /// <summary>
        /// Adds the online purpose.
        /// </summary>
        /// <param name="onlinePurposeView">The online purpose view.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">AddOnlinePurpose</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult AddOnlinePurpose(OnlinePurposeView onlinePurposeView)
        {
            if (onlinePurposeView == null)
            {
                throw new ArgumentException(nameof(AddOnlinePurpose));
            }

            if (!ModelState.IsValid)
            {
                var onlinePurposeModel = this.onlineServices.GetOnlinePurposeView(onlinePurposeView, string.Empty);
                return this.View("AddOnlinePurpose", onlinePurposeModel);
            }


            var processingMessage = this.onlineServices.ProcessOnlinePurposeInfo(onlinePurposeView);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var onlinePurposeModel = this.onlineServices.GetOnlinePurposeView(onlinePurposeView, processingMessage);
                return View("AddOnlinePurpose", onlinePurposeModel);
            }

            processingMessage = string.Format("Online Purppose Saved");

            return RedirectToAction("OnlinePurposeList", new {message = processingMessage});
        }


        /// <summary>
        /// Edits the online purpose.
        /// </summary>
        /// <param name="onlinePurposeId">The online purpose identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditOnlinePurpose(int onlinePurposeId)
        {
            if (onlinePurposeId <= 0)
            {
                throw new ArgumentNullException(nameof(onlinePurposeId));
            }

            var onlinePurposeModel = this.onlineServices.GetSelectedOnlinePurposeInfo(onlinePurposeId);
            return this.PartialView("EditOnlinePurpose", onlinePurposeModel);
        }

        /// <summary>
        /// Edits the online purpose.
        /// </summary>
        /// <param name="onlinePurposeView">The online purpose view.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditOnlinePurpose(OnlinePurposeView onlinePurposeView)
        {
            if (onlinePurposeView == null)
            {
                throw new ArgumentNullException(nameof(onlinePurposeView));
            }


            if (!ModelState.IsValid)
            {
                var onlinePurposeModel = this.onlineServices.GetOnlinePurposeView(onlinePurposeView, string.Empty);
                return this.PartialView("AddOnlinePurpose", onlinePurposeModel);
            }

            var processingMessage = this.onlineServices.UpdateOnlinePurposeInfo(onlinePurposeView);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var onlinePurposeModel = this.onlineServices.GetOnlinePurposeView(onlinePurposeView, processingMessage);
                return View("EditOnlinePurpose", onlinePurposeModel);
            }


            processingMessage = string.Format("Online Purpose Updated ");

            return this.RedirectToAction("OnlinePurposeList",
                new {message = processingMessage});
        }

        /// <summary>
        /// Deletes the online purpose.
        /// </summary>
        /// <param name="onlinePlatformId">The online platform identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeleteOnlinePurpose(int onlinePurposeId)
        {
            var onlinePurposeModel = this.onlineServices.GetSelectedOnlinePurposeInfo(onlinePurposeId);
            return this.PartialView("DeleteOnlinePurpose", onlinePurposeModel);

        }

        /// <summary>
        /// Deletes the online purpose.
        /// </summary>
        /// <param name="onlinePurposeView">The online purpose view.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteOnlinePurpose(int onlinePurposeId, string btnSubmit)
        {
            if (onlinePurposeId < 1)
            {
                throw new ArgumentOutOfRangeException("onlinePurposeId");
            }

            var message = this.onlineServices.ProcessDeleteOnlinePurposeInfo(onlinePurposeId);

            var returnMessage = string.Format("Online Purpose Deleted ");

            return this.RedirectToAction("OnlinePurposeList",
                new { message = returnMessage });


        }


        #endregion


        #region Online Extra Service Setup

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectOnlineExtraServiceId"></param>
        /// <param name="selectDescription"></param>
        /// <param name="message"></param>
        /// <returns></returns>
       
        [CheckUserLogin()]
        public ActionResult OnlineExtraServiceList(int? selectOnlineExtraServiceId, string selectDescription,
            string message)

        {
            var onlineExtraServiceModel =
                this.onlineServices.GetOnlineExtraServiceListViewModel(selectOnlineExtraServiceId ?? 0,
                    selectDescription, message);

            return View("OnlineExtraServiceList", onlineExtraServiceModel);
        }

        /// <summary>
        /// Adds the online extra service.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult AddOnlineExtraService()
        {
            var onlineView = this.onlineServices.CreateOnlineExtraServiceView();
            return View("AddOnlineExtraService", onlineView);
        }


        /// <summary>
        /// Adds the online extra service.
        /// </summary>
        /// <param name="onlineExtraServiceView">The online extra service view.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">AddOnlineExtraService</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult AddOnlineExtraService(OnlineExtraServiceView onlineExtraServiceView)
        {
            if (onlineExtraServiceView == null)
            {
                throw new ArgumentNullException(nameof(onlineExtraServiceView));
            }


            if (onlineExtraServiceView == null)
            {
                throw new ArgumentException("AddOnlineExtraService");
            }

            if (!ModelState.IsValid)
            {
                var onlineExtraServiceModel =
                    this.onlineServices.GetOnlineExtraServiceView(onlineExtraServiceView, string.Empty);
                return View("AddOnlineExtraService", onlineExtraServiceModel);
            }

            var processingMessage = this.onlineServices.ProcessOnlineExtraServiceInfo(onlineExtraServiceView);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var onlineExtraServiceModel =
                    this.onlineServices.GetOnlineExtraServiceView(onlineExtraServiceView, processingMessage);
                return View("AddOnlineExtraService", onlineExtraServiceModel);
            }


            processingMessage = string.Format("Online Extra Service Saved");
            return RedirectToAction("OnlineExtraServiceList", new {processingMessage});
        }


        /// <summary>
        /// Edits the online extra service.
        /// </summary>
        /// <param name="onlineExtraServiceId">The online extra service identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditOnlineExtraService(int onlineExtraServiceId)
        {
            if (onlineExtraServiceId <= 0)
            {
                throw new ArgumentNullException(nameof(onlineExtraServiceId));
            }

            var onlineExtraServiceModel = this.onlineServices.GetSelectedOnlineExtraServiceInfo(onlineExtraServiceId);
            return this.PartialView("EditOnlineExtraService", onlineExtraServiceModel);
        }
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditOnlineDuration(int onlineDurationId)
        {
            if (onlineDurationId<= 0)
            {
                throw new ArgumentNullException(nameof(onlineDurationId));
            }

            var OnlineExtraServiceModel = this.onlineServices.GetSelectedOnlineDurationInfo(onlineDurationId);
            return this.PartialView("EditOnlineDuration", OnlineExtraServiceModel);
        }

        /// <summary>
        /// Edits the online extra service.
        /// </summary>
        /// <param name="onlineExtraServiceView">The online extra service view.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditOnlineExtraService(OnlineExtraServiceView onlineExtraServiceView)
        {
            if (onlineExtraServiceView == null)
            {
                throw new ArgumentNullException(nameof(onlineExtraServiceView));
            }

            if (!ModelState.IsValid)
            {
                var onlineExtraServiceModel =
                    this.onlineServices.GetOnlineExtraServiceView(onlineExtraServiceView, string.Empty);
                return View("AddOnlineExtraService", onlineExtraServiceModel);
            }

            var processingMessage = this.onlineServices.UpdateOnlineExtraServiceInfo(onlineExtraServiceView);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var onlineExtraServiceModel =
                    this.onlineServices.GetOnlineExtraServiceView(onlineExtraServiceView, processingMessage);
                return View("EditOnlineExtraService", onlineExtraServiceModel);
            }

            processingMessage = string.Format("Online Extra Service Updated ");

            return this.RedirectToAction("OnlineExtraServiceList",
                new {message = processingMessage});
        }



        /// <summary>
        /// Edits the duration of the online.
        /// </summary>
        /// <param name="onlineDurationView">The online duration view.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditOnlineDuration(OnlineDurationView onlineDurationView)
        {
            if (!ModelState.IsValid)
            {
                var OnlineDuration =
                    this.onlineServices.GetOnlineDurationView(onlineDurationView, string.Empty);
                return View("EditOnlineDuration",OnlineDuration );
            }

            var onlineDurationEdit = this.onlineServices.UpdateOnlineDurationInfo(onlineDurationView);

            if (!string.IsNullOrEmpty(onlineDurationEdit))
            {
                var OnlineDurationModel =
                    this.onlineServices.GetOnlineDurationView(onlineDurationView,onlineDurationEdit);
                return View("EditOnlineDuration", OnlineDurationModel);
            }

            var returnMessage = string.Format("Online Duration Updated ");

            return this.RedirectToAction("OnlineDurationList",
                new { message = returnMessage });
        }
        /// <summary>
        /// Deletes the online extra service.
        /// </summary>
        /// <param name="onlineExtraServiceId">The online extra service identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeleteOnlineExtraService(int onlineExtraServiceId)
        {
            var OnlineExtraServiceModel = this.onlineServices.GetSelectedOnlineExtraServiceInfo(onlineExtraServiceId);
            return this.PartialView("DeleteOnlineExtraService", OnlineExtraServiceModel);

        }

        /// <summary>
        /// Deletes the online extra service.
        /// </summary>
        /// <param name="onlineExtraServiceView">The online extra service view.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteOnlineExtraService(int onlineExtraServiceId, string btnSubmit)
        {
            if (onlineExtraServiceId < 1)
            {
                throw new ArgumentOutOfRangeException("extraServiceId");
            }

            var message = this.onlineServices.ProcessDeleteOnlineExtraServiceInfo(onlineExtraServiceId);




            var returnMessage = string.Format("Online Extra Service Deleted ");

            return this.RedirectToAction("OnlineExtraServiceList", new
            {
                message = returnMessage
            });

        }


            public ActionResult DeleteOnlineDuration(int onlineDurationId, string btnSubmit)
            {
                if (onlineDurationId < 1)
                {
                    throw new ArgumentOutOfRangeException("onlineDuration");
                }

                var message = this.onlineServices.ProcessDeleteOnlineDurationInfo(onlineDurationId);


                var returnMessage = string.Format("Online Duration Deleted ");

                return this.RedirectToAction("OnlineDurationList",
                    new { message = returnMessage });
            }
        #endregion


        #region Online Extra Service Price Setup

        /// <summary>
        /// Extras the service service price.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        
        [CheckUserLogin()]
        public ActionResult ExtraServicePrice(int? selectOnlineExtraServicePriceId, int? selectOnlineExtraServiceId,
            string message) // extra service price view
        {
            var viewModel = onlineServices.GetOnlineExtraServicePriceListViewModel(selectOnlineExtraServicePriceId ?? 0,
                selectOnlineExtraServiceId ?? 0, message);
            return View("ExtraServicePrice", viewModel);
        }


        /// <summary>
        /// Creates the online extra service price.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult CreateOnlineExtraServicePrice()
        {
            var viewModel = onlineServices.GetOnlineExtraServicePriceView();
            return View("CreateOnlineExtraServicePrice", viewModel);
        }

        [HttpPost]
        [CheckUserLogin()]
        public ActionResult CreateOnlineExtraServicePrice(OnlineExtraServicePriceView onlineExtraServicePriceView)
        {
            if (onlineExtraServicePriceView == null)
            {
                throw new ArgumentNullException("extraServicePriceView");
            }

            if (!ModelState.IsValid)
            {
                var returnView = this.onlineServices.GetUpdatedOnlineExtraServicePriceView(onlineExtraServicePriceView);
                return View("CreateOnlineExtraServicePrice", returnView);
            }

            var processingMessage = this.onlineServices.ProcessOnlineExtraServicePriceInfo(onlineExtraServicePriceView);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var extraServicePriceInfo =
                    this.onlineServices.GetOnlineExtraServicePriceView(onlineExtraServicePriceView, processingMessage);


                return this.PartialView("CreateOnlineExtraServicePrice", extraServicePriceInfo);
            }

            processingMessage = string.Format("Online Extra Service Price Added");

            return this.RedirectToAction("ExtraServicePrice",
                new {message = processingMessage});
        }


        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditOnlineExtraServicePrice(int onlineExtraServicePriceId)
        {
            if (onlineExtraServicePriceId < 1)
            {
                throw new ArgumentOutOfRangeException("onlineExtraServicePriceId");
            }

            var onlineExtraServicePrice =
                this.onlineServices.GetSelectedOnlineExtraServicePriceInfo(onlineExtraServicePriceId);
            return this.PartialView("EditOnlineExtraServicePrice", onlineExtraServicePrice);
        }

        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditOnlineExtraServicePrice(OnlineExtraServicePriceView onlineExtraServicePriceView)
        {
            if (onlineExtraServicePriceView == null)
            {
                throw new ArgumentException("onlineExtraServicePriceView");
            }

            if (!ModelState.IsValid)
            {
                var onlineExtraServicePriceModel =
                    this.onlineServices.GetUpdatedOnlineExtraServicePriceView(onlineExtraServicePriceView);

                return View("EditOnlineExtraServicePrice", onlineExtraServicePriceModel);
            }

            var processingMessage =
                this.onlineServices.ProcessEditOnlineExtraServicePriceInfo(onlineExtraServicePriceView);


            var returnMessage = string.Format("Online Extra Service Price Edited");

            return this.RedirectToAction("ExtraServicePrice",
                new {message = returnMessage});
        }

        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeleteOnlineExtraServicePrice(int onlineExtraServicePriceId)
        {
            var onlineModel = this.onlineServices.GetDeleteOnlineExtraServicePriceById(onlineExtraServicePriceId);
            return this.PartialView("DeleteOnlineExtraServicePrice", onlineModel);
        }


        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteOnlineExtraServicePrice(int onlineExtraServicePriceId, string btnSubmit)
        {
            if (onlineExtraServicePriceId < 1)
            {
                throw new ArgumentOutOfRangeException("OnlineExtraServicePriceId");
            }


            this.onlineServices.ProcessDeleteOnlineExtraServicePriceInfo(onlineExtraServicePriceId);

            var processingMessage = string.Format("Online Extra Service  Price Deleted");

            return this.RedirectToAction("ExtraServicePrice",
                new {message = processingMessage});
        }

        #endregion


        #region Online Platform Package Setup

        [CheckUserLogin()]
        public ActionResult PlatformPackage(int? selectedOnlinePlatformPriceId, int? selectedOnlinePlatformId,
            string message)
        {
            var viewModel = onlineServices.GetPlatformPackagePriceViewModel(selectedOnlinePlatformPriceId ?? 0,
                selectedOnlinePlatformId ?? 0, message);
            return View("PlatformPackage", viewModel);
        }


        /// <summary>
        /// Creates the platform package.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous, HttpGet]
        [CheckUserLogin()]
        public ActionResult CreatePlatformPackage()
        {
            var viewModel = onlineServices.GetPlatformPackagePriceView();
            return View("CreatePlatformPackage", viewModel);
        }

        /// <summary>
        /// Creates the platform package.
        /// </summary>
        /// <param name="platformprice">The platformprice.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">designelementview</exception>
        [AllowAnonymous, HttpPost]
        [CheckUserLogin()]
        public ActionResult CreatePlatformPackage(OnlinePlatformPackagePriceView platformprice)
        {
            if (platformprice == null)
            {
                throw new ArgumentNullException("platformprice");
            }

            if (!ModelState.IsValid)
            {
                var model = onlineServices.GetUpdatedOnlinePlatformPackagePriceView(platformprice);
                return View("CreatePlatformPackage", model);
            }

            var processingMessage = this.onlineServices.ProcessPlatformPackagePriceInfo(platformprice);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var platformPackageModel =
                    this.onlineServices.GetPlatformPackagePriceView(platformprice, processingMessage);

                return this.View("CreatePlatformPackage", platformPackageModel);
            }


            processingMessage = string.Format("Online Platform Price Added");

            return this.RedirectToAction("PlatFormPackage",
                new {message = processingMessage});
        }


        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditOnlinePlatformPackagePrice(int onlinePlatformPackagePriceId)
        {
            if (onlinePlatformPackagePriceId < 1)
            {
                throw new ArgumentOutOfRangeException("onlinePlatformPackagePriceId");
            }

            var onlinePlatformpackagePrice =
                this.onlineServices.GetSelectedPlatformPackagePriceInfo(onlinePlatformPackagePriceId);
            return this.PartialView("EditOnlinePlatformPackagePrice", onlinePlatformpackagePrice);
        }

        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditOnlinePlatformPackagePrice(
            OnlinePlatformPackagePriceView onlinePlatformPackagePriceView)
        {
            if (onlinePlatformPackagePriceView == null)
            {
                throw new ArgumentNullException(nameof(onlinePlatformPackagePriceView));
            }

            if (!ModelState.IsValid)
            {
                var modelView = onlineServices.GetUpdatedOnlinePlatformPackagePriceView(onlinePlatformPackagePriceView);
                return this.View("EditOnlinePlatformPackagePrice", modelView);
            }


            this.onlineServices.ProcessEditOnlinePlatformPackagePriceInfo(onlinePlatformPackagePriceView);

            var returnMessage = string.Format("Online Platfrom Pacakge Price Edited");

            return this.RedirectToAction("PlatformPackage",
                new {message = returnMessage});
        }

        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeleteOnlinePlatformPackagePrice(int onlinePlatformPriceId)
        {
            if (onlinePlatformPriceId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(onlinePlatformPriceId));
            }
            var onlineModel = this.onlineServices.GetDeletePlatformPackagePriceById(onlinePlatformPriceId);
            return this.PartialView("DeleteOnlinePlatformPackagePrice", onlineModel);
        }

        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteOnlinePlatformPackagePrice(int onlinePlatformPriceId, string btnSubmit)
        {
            if (onlinePlatformPriceId < 1)
            {
                throw new ArgumentOutOfRangeException("onlinePlatformPriceId");
            }

          
                this.onlineServices.ProcessDeleteOnlinePlatformPackagePriceInfo(onlinePlatformPriceId);

            var processingMessage = string.Format("Online Platform Pacakage  Price Deleted");

            return this.RedirectToAction("PlatformPackage",
                new {message = processingMessage});
        }

        #endregion


        #region Artwork Price Setup            
        /// <summary>
        /// Creates the online art work price.
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateOnlineArtWorkPrice() 
        {
            var viewModel = onlineServices.GetOnlineArtWorkPriceView();
            return View("CreateOnlineArtWorkPrice", viewModel);
        }

        [HttpPost]
        [CheckUserLogin()]
        public ActionResult CreateOnlineArtWorkPrice(OnlineArtworkPriceView onlineArtworkPriceView) 
        {
            if (onlineArtworkPriceView == null)
            {
                throw new ArgumentNullException("onlineArtworkPriceView");
            }

            if (!ModelState.IsValid)
            {
                var returnView = this.onlineServices.GetUpdatedOnlineArtworkView(onlineArtworkPriceView);

                return View("CreateOnlineArtWorkPrice", returnView);
            }

            var returnModel = this.onlineServices.ProcessOnlineArtWorkPriceInfo(onlineArtworkPriceView);

            if (!string.IsNullOrEmpty(returnModel))
            {
                var onlineArtworkInfo =
                    this.onlineServices.GetOnlineArtWorkPriceView(onlineArtworkPriceView, returnModel);
                return this.PartialView("CreateOnlineArtWorkPrice", onlineArtworkInfo);
            }

            var returnMessage = string.Format("New Online ArtWork  created");

            return this.RedirectToAction("OnlineArtWorkPrice",
                new { message = returnMessage });
        }

        /// <summary>
        /// Arts the work price.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="selectedArtWorkPriceId">The selected art work price identifier.</param>
        /// <param name="selectedServiceTypeCode">The selected service type code.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <returns></returns>
        [HttpGet]
        
        public ActionResult OnlineArtWorkPrice(string message, int? selectedArtWorkPriceId, 
          string selectedServiceTypeCode, string selectedDescription)
        {
            var viewModel =onlineServices.GetArtworkPriceViewModel(message, selectedArtWorkPriceId ?? 0,
                selectedServiceTypeCode, selectedDescription);
            return View("OnlineArtWorkPrice", viewModel);
        }

        /// <summary>
        /// Edits the artwork price.
        /// </summary>
        /// <param name="artWorkPriceId">The art work price identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">artWorkPriceId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditOnlineArtWorkPrice(int artWorkPriceId)   
        {
            if (artWorkPriceId< 1)
            {
                throw new ArgumentOutOfRangeException("artWorkPriceId");
            }
            

            var artwork = this.onlineServices.GetOnlineArtworkPriceById(artWorkPriceId);
            return this.PartialView("EditOnlineArtWorkPrice", artwork);
        }
        /// <summary>
        /// Edits the online art work price.
        /// </summary>
        /// <param name="onlineArtWorkPriceView">The online art work price view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">onlineArtWorkPriceView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditOnlineArtWorkPrice(OnlineArtworkPriceView onlineArtWorkPriceView) 
        {
            if (onlineArtWorkPriceView == null)
            {
                throw new ArgumentException("onlineArtWorkPriceView");
            }


            if (!ModelState.IsValid)
            {
                var returnView = this.onlineServices.GetUpdatedOnlineArtworkView(onlineArtWorkPriceView); 

                return View("EditOnlineArtWorkPrice", returnView);
            }

            var processingMessage = this.onlineServices.ProcessEditArtWorkPriceInfo(onlineArtWorkPriceView);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var returnView = this.onlineServices.GetUpdatedOnlineArtworkView(onlineArtWorkPriceView);

                return View("EditOnlineArtWorkPrice", returnView);

            }
            processingMessage = string.Format("Online ArtWork Price Edited");

            return this.RedirectToAction("OnlineArtWorkPrice",
                new { message = processingMessage });

        }
        /// <summary>
        /// Deletes the online art work price.
        /// </summary>
        /// <param name="onlineArtWorkPriceId">The online art work price identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">designElementPriceId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeleteOnlineArtWorkPrice(int onlineArtWorkPriceId)
        {
            if (onlineArtWorkPriceId < 1)
            {
                throw new ArgumentOutOfRangeException("onlineArtWorkPriceId");
            }

            var designelement = this.onlineServices.GetOnlineArtworkPriceById(onlineArtWorkPriceId);
            return PartialView("DeleteOnlineArtWorkPrice", designelement);  
        }
        /// <summary>
        /// Deletes the online art work price.
        /// </summary>
        /// <param name="onlineArtWorkPriceId">The online art work price identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">onlineArtWorkPriceId</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteOnlineArtWorkPrice(int onlineArtWorkPriceId, string btnSubmit)
        {
            if (onlineArtWorkPriceId < 1)
            {
                throw new ArgumentOutOfRangeException("onlineArtWorkPriceId");
            }

            this.onlineServices.ProcessDeleteOnlineArtworkPriceInfo(onlineArtWorkPriceId);

            var processingMessage = string.Format("Online ArtWork Price Deleted");


            return this.RedirectToAction("OnlineArtworkPrice",
                new { message = processingMessage });
        }
        #endregion


        #region Online Duration Setup

        /// <summary>
        /// Called when [duration list].
        /// </summary>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>

        [CheckUserLogin()]
        public ActionResult OnlineDurationList(string selectedDescription, string message)
        {
            var returnView = this.onlineServices.GetDurationList(selectedDescription, message);


            return this.View("OnlineDurationList", returnView);
        }

        /// <summary>
        /// Creates the duration of the online.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult CreateOnlineDuration()
        {
            var viewModel = this.onlineServices.GetOnlineDurationView();

            return this.PartialView("CreateOnlineDuration", viewModel);
        }

        /// <summary>
        /// Creates the duration of the online.
        /// </summary>
        /// <param name="onlineDurationInfo">The online duration information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineDurationInfo</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult CreateOnlineDuration(OnlineDurationView onlineDurationInfo)
        {
            if (onlineDurationInfo == null)
            {
                throw new ArgumentNullException(nameof(onlineDurationInfo));
            }

            if (!ModelState.IsValid)
            {
                var returnView = this.onlineServices.GetOnlineDurationView(onlineDurationInfo, string.Empty);

                return View("CreateOnlineDuration", returnView);
            }

            var processingMessage = this.onlineServices.ProcessOnlineDuration(onlineDurationInfo);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var returnView = this.onlineServices.GetOnlineDurationView(onlineDurationInfo, processingMessage);

                return this.View("CreateOnlineDuration", returnView);
            }

            processingMessage = string.Format("New Record Created");

            return RedirectToAction("OnlineDurationList", "Online", new {message = processingMessage});
        }

        #endregion


        #region  Package Price Setup

        /// <summary>
        /// Gets the package price.
        /// </summary>
        /// <param name="packageId">The package identifier.</param>
        /// <param name="durationId">The duration identifier.</param>
        /// <returns></returns>
        
        [CheckUserLogin()]
        public decimal GetPackagePrice(int packageId, int durationId)
        {
            if (packageId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(packageId));
            }

            if (durationId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(durationId));
            }
            var onlinePackagePrice = onlineServices.GetOnlineDurationPackagePrice(packageId, durationId);

            return onlinePackagePrice?.Amount ?? 0;
        }

        #endregion

       
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult OnlineExtraServicePrice(int extraServiceId)
        {
            if (extraServiceId <= 0)
            {
                throw new ArgumentOutOfRangeException("extraServiceId");
            }

            var viewModel = onlineServices.GetOnlineExtraPriceView(extraServiceId);
            var result = new
            {
                extraServicePrice = viewModel.OnlineExtraServicAmount,
                extraServicePriceId = viewModel.OnlineExtraServicePriceId
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}