using AA.Infrastructure.Interfaces;
using ADit.Domain.Attributes;
using ADit.Domain.Models;
using ADit.Domain.Resources;
using ADit.Interfaces;
using ADit.Interfaces.ValueTypes;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace ADit.Controllers
{
  
    [Authorize]
    public class TvController : Controller
    {
        
        public IOrderServices orderServices;
        public ITransactionService transactionService;
        private readonly ITvServices tvServices;
        private readonly ISessionStateService session;

     
        public TvController(ITvServices tvServices, ISessionStateService session, IOrderServices orderServices, ITransactionService transactionService)
        {
            this.tvServices = tvServices;
            this.session = session;
            this.orderServices = orderServices;
            this.transactionService = transactionService;
            
        }

        #region Tv Services Setup

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult Index()
        {
            //Generate TV View.
            var tvView = this.tvServices.GetTvview();

            return this.View("Index", tvView);
        }


        /// <summary>
        /// Indexes the specified tv view.
        /// </summary>
        /// <param name="tvMainTransaction">The tv main transaction.</param>
        /// <param name="transactionAiring">The transaction airing.</param>
        /// <param name="selectedTvStationIds">The selected tv station ids.</param>
        /// <param name="productionMaterial">The production material.</param>
        /// <param name="scriptingMaterial">The scripting material.</param>
        /// <returns>
        /// ActionResult.
        /// </returns>
        /// <exception cref="ArgumentNullException">tvView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult Index(TvTransactionUI tvMainTransaction, List<TvTransactionAiringUI> transactionAiring,
            List<int> selectedTvStationIds,
            HttpPostedFileBase productionMaterial, HttpPostedFileBase scriptingMaterial)
        {
            //Check if tv Transaction model is null
            if (tvMainTransaction == null)
            {
                throw new ArgumentNullException(nameof(tvMainTransaction));
            }

            //Check if transaction airing is null
            if (transactionAiring == null)
            {
                throw new ArgumentNullException(nameof(transactionAiring));
            }

            //Check for Selected Television Station ID
            if (selectedTvStationIds == null)
            {
                throw new ArgumentNullException(nameof(selectedTvStationIds));
            }

            //Check For Model Validity
            if (!this.ModelState.IsValid)
            {
                var model = this.tvServices.CreateTvTransactionUpdatedView(tvMainTransaction, transactionAiring,
                    selectedTvStationIds, "");
                return View(model);
            }


            int orderId = -1;
            var processingMessage = this.tvServices.processTVMainInfo(tvMainTransaction, transactionAiring,
                selectedTvStationIds, scriptingMaterial, productionMaterial, out orderId);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var viewModel = this.tvServices.CreateTvTransactionUpdatedView(tvMainTransaction, transactionAiring,
                    selectedTvStationIds, processingMessage);
                return View("Index", viewModel);
            }

            return this.RedirectToAction("Summary", "Order", new
            {
                orderId = orderId,
                message = "TV transaction added to cart"
            });
        }



        //user can delete the order by Id
        [CheckUserLogin()]
        public ActionResult DeleteOrderById(int transactionId)
        {
            if (transactionId <= 0)
            {
                throw new ArgumentNullException(nameof(transactionId));
            }
            var Order = this.tvServices.DeleteTvOrder(transactionId);
            //Get The Currently Logged User Id
            var userId = (int)session.GetSessionValue(SessionKey.UserId);

            // Get order id
            var orderId = this.orderServices.GetOrderIdentifier(userId);

            //Update Cart
            this.transactionService.UpdateCart(orderId);
            return RedirectToAction("SummaryRedirect", "Order");

        }

        /// <summary>
        /// Edits the cart.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns>
        /// ActionResult.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">transactionId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditCart(int transactionId)
        {
            if (transactionId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(transactionId));
            }

            var model = this.tvServices.GetEditTvCartView(transactionId);

            return this.View("EditCart", model);
        }


        /// <summary>
        /// Edits the cart.
        /// </summary>
        /// <param name="tvInfo">The tv information.</param>
        /// <param name="scriptingMaterial">The scripting material.</param>
        /// <param name="productionMaterial">The production material.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">tvInfo</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditCart(TvTransactionUI tvMainTransaction, List<TvTransactionAiringUI> transactionAiring,
            List<int> selectedTvStationIds,
            HttpPostedFileBase productionMaterial, HttpPostedFileBase scriptingMaterial)
        {
              //Check if tv Transaction model is null
            if (tvMainTransaction == null)
            {
                throw new ArgumentNullException(nameof(tvMainTransaction));
            }

            //Check if transaction airing is null
            if (transactionAiring == null)
            {
                throw new ArgumentNullException(nameof(transactionAiring));
            }

            //Check for Selected Television Station ID
            if (selectedTvStationIds == null)
            {
                throw new ArgumentNullException(nameof(selectedTvStationIds));
            }

            //Check For Model Validity
            if (!this.ModelState.IsValid)
            {
                var model = this.tvServices.CreateTvTransactionUpdatedView(tvMainTransaction, transactionAiring,
                    selectedTvStationIds, "");
                return View(model);
            }


            int orderId = -1;
            var processingMessage = this.tvServices.UpdateTvTransaction(tvMainTransaction, transactionAiring,
                selectedTvStationIds, scriptingMaterial, productionMaterial, out orderId);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var viewModel = this.tvServices.CreateTvTransactionUpdatedView(tvMainTransaction, transactionAiring,
                    selectedTvStationIds, processingMessage);
                return View("Index", viewModel);
            }

            return this.RedirectToAction("Summary", "Order", new
            {
                orderId = orderId,
                message = "TV transaction added to cart"
            });

        }

        #endregion


        #region Service Price Setup


        /// <summary>
        /// Tvs the service price list.
        /// </summary>
        /// <param name="selectedTvServicesPriceId">The selected tv services price identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>

        [CheckUserLogin()]
        public ActionResult TvServicePriceList(int? selectedTvServicesPriceId, string selectedDescription,
            string message)
        {
            var tvList =
                this.tvServices.GetITVServicePricesList(selectedTvServicesPriceId ?? 0, selectedDescription, message);


            return this.View("TvServicePriceList",tvList);
        }

        /// <summary>
        /// Adds the tv service price.
        /// </summary>
        /// <returns></returns>

        [CheckUserLogin()]
        public ActionResult AddTvServicePrice()
        {
            var view = this.tvServices.GetTVServicePricesListView();

            return this.View("AddTvServicePrice",view);
        }

        /// <summary>
        /// Adds the tv service price.
        /// </summary>
        /// <param name="tVServicesPricesListView">The t v services prices ListView.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">tVServicesPricesListView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult AddTvServicePrice(TVServicesPricesListView tVServicesPricesListView)
        {
            var processingMessage = "";
            if (tVServicesPricesListView == null)
            {
                throw new ArgumentNullException("tVServicesPricesListView");
            }

            if (!this.ModelState.IsValid)

            {
                var tvView = this.tvServices.GetAddTvServicesListView(tVServicesPricesListView, string.Empty);
                return this.View("AddTvServicePrice", tvView);
            }

            var result = this.tvServices.CheckTvService(tVServicesPricesListView);
            if (result)
            {
                processingMessage = Messages.ServiceExist;
                var viewModel = this.tvServices.GetUpdatedTvServicesListView(tVServicesPricesListView, processingMessage);
                return this.View("AddTvServicePrice", viewModel);
            }

            var returnModel = this.tvServices.saveTvServicePriceList(tVServicesPricesListView);
            if (!string.IsNullOrEmpty(returnModel))
            {
                var tvView = this.tvServices.GetAddTvServicesListView(tVServicesPricesListView, string.Empty);
                return this.View("AddTvServicePrice", tvView);
            }

            var message = string.Format("TV Service Added", tVServicesPricesListView);
            return this.RedirectToAction("TvServicePriceList", new {message = message});
        }

        /// <summary>
        /// Edits the tv service price.
        /// </summary>
        /// <param name="tvServicePriceId">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Id</exception>

        [CheckUserLogin()]
        public ActionResult EditTvServicePrice(int tvServicePriceId)
        {
            if (tvServicePriceId <= 0)
            {
                throw new ArgumentNullException(nameof(tvServicePriceId));
            }

            var tvView = this.tvServices.GeteditTvServicePriceListView(tvServicePriceId);
            return this.PartialView("EditTvServicePrice",tvView);
        }

        /// <summary>
        /// Edits the tv service price.
        /// </summary>
        /// <param name="tVServicesPricesListView">The t v services prices ListView.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditTvServicePrice(TVServicesPricesListView tVServicesPricesListView)
        {
            var processingMessage = "";
            if (!this.ModelState.IsValid)
            {
                var tvView = this.tvServices.GetUpdatedTvServicesListView(tVServicesPricesListView, string.Empty);
                return this.PartialView("EditTvServicePrice", tvView);
            }
            var result = this.tvServices.CheckTvService(tVServicesPricesListView);
            if (result)
            {
                processingMessage = Messages.ServiceExist;
                var viewModel = this.tvServices.GetUpdatedTvServicesListView(tVServicesPricesListView, processingMessage);
                return this.View("AddTvServicePrice", viewModel);
            }
            var returnModel = this.tvServices.UpdateTvServicePriceList(tVServicesPricesListView);
            if (!string.IsNullOrEmpty(returnModel))
            {
                var tvView = this.tvServices.GetUpdatedTvServicesListView(tVServicesPricesListView, string.Empty);
                return this.PartialView("EditTvServicePrice", tvView);
            }

            var message = string.Format("TV Service Edited");
            return this.RedirectToAction("TvServicePriceList", new {message = message});
        }


        /// <summary>
        /// Deletes the tv service price.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Id</exception>
        
        [CheckUserLogin()]
        public ActionResult DeleteTvServicePrice(int tvServicePriceId, string btnSubmit)
        {
            if (tvServicePriceId < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(tvServicePriceId));
            }


            var tvView = this.tvServices.GeteditTvServicePriceListView(tvServicePriceId);
            return this.PartialView("DeleteTvServicePrice",tvView);
        }

        /// <summary>
        /// Deletes the tv service price.
        /// </summary>
        /// <param name="tvServicesPricesListView">The tv services prices ListView.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteTvServicePrice(TVServicesPricesListView tvServicesPricesListView)
        {
            var tvVew = this.tvServices.deleteServicePriceListView(tvServicesPricesListView.TvServicesPriceListId);

            var message = string.Format("TV Service Deleted")
                ;
            return this.RedirectToAction("TvServicePriceList", new {message = message});
        }


        #endregion




        #region Tv Airing Setup

        /// <summary>
        /// Adds the tv airing.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">transactionId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult AddTvAiring(int transactionId)
        {
            if (transactionId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(transactionId));
            }


            //Get The Airing View in A Partial View

            var model = this.tvServices.GetTvAiringView(transactionId, string.Empty);

            return this.PartialView(model);
        }


        /// <summary>
        /// Adds the radio airing.
        /// </summary>
        /// <param name="tvAiringInfo">The radio airing information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">tvAiringInfo</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">transactionId</exception>
        [ValidateAntiForgeryToken]
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult AddTvAiring(TVTransactionAiringView tvAiringInfo)
        {
            if (tvAiringInfo == null)
            {
                throw new ArgumentNullException(nameof(tvAiringInfo));
            }

            if (!this.ModelState.IsValid)
            {
                var model = this.tvServices.GetTvAiringView(tvAiringInfo.TvStationId,
                    string.Empty);
                return this.View("AddTvAiring", model);
            }

            var message = this.tvServices.ProcessAddTVAiring(tvAiringInfo);

            if (!string.IsNullOrEmpty(message))
            {
                var model = this.tvServices.GetTvAiringView(tvAiringInfo.TvStationId,
                    message);
                return this.View("AddTvAiring", model);
            }

            var returnMessage = string.Format("New Tv Station Added to this transaction");

            return this.RedirectToAction("EditCart", "Tv",
                new {transactionId = tvAiringInfo.TvTransactionId, message = returnMessage});
        }


        #endregion


        #region Tv Stattions Setup

        /// <summary>
        /// Tvs the stations.
        /// </summary>
        /// <param name="selectedTvStationId">The selected tv station identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>

        [CheckUserLogin()]
        public ActionResult TvStations(int? selectedTvStationId, string selectedDescription, string message)
        {
            var viewModel =
                this.tvServices.GetTvStationViewModel(selectedTvStationId ?? 0, selectedDescription, message);

            return this.View("TvStations", viewModel);
        }

        /// <summary>
        /// Adds the tv station.
        /// </summary>
        /// <returns></returns>

        [CheckUserLogin()]
        public ActionResult AddTvStation()
        {
            var tvModel = this.tvServices.GetTvStationView();
            return this.View("AddTvStation", tvModel);
        }


        /// <summary>
        /// Adds the tv station.
        /// </summary>
        /// <param name="tvStationView">The tv station view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">tvStationView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult AddTvStation(TvStationView tvStationView)
        {
            if (tvStationView == null)
            {
                throw new ArgumentNullException(nameof(tvStationView));
            }

            if (!this.ModelState.IsValid)
            {
                var tvModel = this.tvServices.GetTvStationView(tvStationView, string.Empty);
                return this.View("AddTvStation", tvStationView);
            }

            var tvInfo = this.tvServices.ProcessTvStationInfo(tvStationView);
            if (!string.IsNullOrEmpty(tvInfo))
            {
                var tvModel = this.tvServices.GetTvStationView(tvStationView, tvInfo);
                return this.View("AddTvStation", tvModel);
            }


            var returnMessage = string.Format("Tv Station Saved");
            return this.RedirectToAction("TvStations",
                new {message = returnMessage});
        }


        /// <summary>
        /// Edits the tv station.
        /// </summary>
        /// <param name="tvStationId">The tv station identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">tvStationId</exception>
        [HttpGet]
        public ActionResult EditTvStation(int tvStationId)
        {
            if (tvStationId <= 0)
            {
                throw new ArgumentNullException(nameof(tvStationId));
            }

            var tvStationModel = this.tvServices.GetSelectedTvStationInfo(tvStationId);
            return this.PartialView("EditTvStation", tvStationModel);
        }

        /// <summary>
        /// Edits the tv station.
        /// </summary>
        /// <param name="tvStationView">The tv station view.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditTvStation(TvStationView tvStationView)
        {
            if (!this.ModelState.IsValid)
            {
                var tvModel = this.tvServices.GetTvStationView(tvStationView, string.Empty);
                return this.View("EditTvStation", tvStationView);
            }

            var tvEdit = this.tvServices.UpdateTvStationInfo(tvStationView);


            if (!string.IsNullOrEmpty(tvEdit))
            {
                var tvModel = this.tvServices.GetTvStationView(tvStationView, tvEdit);
                return this.View("EditTvStation", tvModel);
            }


            var returnMessage = string.Format("Tv Station Updated ");

            return this.RedirectToAction("TvStations",
                new {message = returnMessage});
        }


        /// <summary>
        /// Deletes the tv station.
        /// </summary>
        /// <param name="tvStationId">The tv station identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeleteTvStation(int tvStationId)
        {
            if (tvStationId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(tvStationId));
            }
            var tvStationModel = this.tvServices.GetSelectedTvStationInfo(tvStationId);
            return PartialView("DeleteTvStation", tvStationModel);
        }


        /// <summary>
        /// Deletes the tv station.
        /// </summary>
        /// <param name="tvStationId">The tv station identifier.</param>
        /// <param name="btnsubnmit">The btnsubnmit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">tvStationId</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteTvStation(int tvStationId, string btnsubnmit)
        {
            if (tvStationId < 1)
            {
                throw new ArgumentOutOfRangeException("tvStationId");
            }

            var TvStationEdit = this.tvServices.ProcessDeleteTvStationInfo(tvStationId);


            var returnMessage = string.Format("Tv Station Deleted");

            return this.RedirectToAction("TvStations",
                new {message = returnMessage});
        }


        #endregion



        #region Material Prices Setup


        /// <summary>
        /// Tvs the material prices.
        /// </summary>
        /// <param name="materialPriceId">The material price identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public JsonResult TVMaterialPrices(int materialPriceId)
        {
            if (materialPriceId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(materialPriceId));
            }
            var productionPrice = this.tvServices.GetTvProductionPriceView(materialPriceId);
            var scriptingPrice = this.tvServices.GetTvScriptingPriceView(materialPriceId);


            var result = new
            {
                productionPrice = productionPrice.ProductionAmount,
                productionPriceId = productionPrice.MaterialProductionTypeId,
                scriptingPrice = scriptingPrice.ScriptingAmount,
                scriptingPriceId = scriptingPrice.MaterialScriptingTypeId,
            };
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region Tv Station Price Setup

        /// <summary>
        /// Tvs the station price.
        /// </summary>
        /// <param name="tvStation">The tv station.</param>
        /// <param name="timingId">The timing identifier.</param>
        /// <param name="timeBeltId">The time belt identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult TVStationPrice(int tvStation, int timingId, int timeBeltId,int  materialTypeId)
        {
            var price = this.tvServices.GetTvStationEffectivePrice(tvStation, timingId, timeBeltId,materialTypeId);

            return this.Json(price, JsonRequestBehavior.AllowGet);
        }


#endregion
    }
}