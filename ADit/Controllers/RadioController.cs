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
using ADit.Repositories.Models;

namespace ADit.Controllers
{


  
    [Authorize]
    public class RadioController : Controller
    {
        private readonly IRadioServices radioServices;
        private readonly ISessionStateService session;
        private readonly ITransactionService transactionService;
        private readonly ILookupService lookupService;
        private readonly IOrderServices orderServices;


        public RadioController(IRadioServices radioServices, ISessionStateService session,
             ITransactionService transactionService, ILookupService lookupService, IOrderServices orderServices)
        {
            this.radioServices = radioServices;
            this.session = session;
            this.transactionService = transactionService;
            this.lookupService = lookupService;
            this.orderServices = orderServices;
        }



        #region Radio Service Setup

        /// <summary>
        /// Radio service get
        /// </summary>
        /// <returns>
        /// ActionResult view/model
        /// </returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult Radio()
        {
            var viewModel = radioServices.GetRadioMainView();

            return View("Radio", viewModel);
        }


        /// <summary>
        /// Radio transaction posted to database.
        /// </summary>
        /// <param name="radioMainTransaction">The radio main transaction.</param>
        /// <param name="transactionAiring">The transaction airing.</param>
        /// <param name="selectedRadioStationIds">The selected radio station ids.</param>
        /// <param name="scriptingMaterial">The scripting material.</param>
        /// <param name="productionMaterial">The production material.</param>
        /// <returns>
        /// ActionResult.
        /// </returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult Radio(RadioTransactionUI radioMainTransaction,
            List<RadioTransactionAiringUI> transactionAiring, List<int> selectedRadioStationIds,
            HttpPostedFileBase scriptingMaterial, HttpPostedFileBase productionMaterial)
        {
            if (radioMainTransaction == null)
            {
                throw new ArgumentNullException(nameof(radioMainTransaction));
            }

            if (transactionAiring == null)
            {
                throw new ArgumentNullException(nameof(transactionAiring));
            }

            if (selectedRadioStationIds == null)
            {
                throw new ArgumentNullException(nameof(selectedRadioStationIds));
            }

            if (!ModelState.IsValid)
            {
                var viewModel = this.radioServices.GetRadioMainView(radioMainTransaction, transactionAiring,
                    selectedRadioStationIds, "");

                return View("Radio", viewModel);
            }


            var processingMessage = string.Empty;
            int orderId = -1;

            processingMessage = this.radioServices.ProcessRadioMainInfo(radioMainTransaction, transactionAiring,
                selectedRadioStationIds, scriptingMaterial, productionMaterial,
                out orderId);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var viewModel = this.radioServices.GetRadioMainView(radioMainTransaction, transactionAiring,
                    selectedRadioStationIds, processingMessage);

                return View("Radio", viewModel);
            }

            return RedirectToAction("Summary", "Order",
                new
                {
                    orderId = orderId, message = "Radio transaction added to cart"
                });
        }


        /// <summary>
        /// Edits the cart.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">transactionId</exception> 
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditCart(int transactionId)
        {
            if (transactionId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(transactionId));
            }
            
            // get view model
            var editModel = radioServices.GetRadioMainViewByTransactionId(transactionId);
            
            return View("EditCart", editModel);
        }

        /// <summary>
        /// Edits the cart.
        /// </summary>
        /// <param name="radioMainTransaction">The radio main transaction.</param>
        /// <param name="transactionAiring">The transaction airing.</param>
        /// <param name="selectedRadioStationIds">The selected radio station ids.</param>
        /// <param name="scriptingMaterial">The scripting material.</param>
        /// <param name="productionMaterial">The production material.</param>
        /// <returns>ActionResult.</returns>
        /// <exception cref="ArgumentNullException">radioMainInfo</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditCart(RadioTransactionUI radioMainTransaction,
            List<RadioTransactionAiringUI> transactionAiring, List<int> selectedRadioStationIds,
            HttpPostedFileBase scriptingMaterial, HttpPostedFileBase productionMaterial)
        {
            if (radioMainTransaction == null)
            {
                throw new ArgumentNullException(nameof(radioMainTransaction));
            }

            if (transactionAiring == null)
            {
                throw new ArgumentNullException(nameof(transactionAiring));
            }

            if (selectedRadioStationIds == null)
            {
                throw new ArgumentNullException(nameof(selectedRadioStationIds));
            }

            if (!ModelState.IsValid)
            {
                var viewModel = this.radioServices.GetRadioMainView(radioMainTransaction, transactionAiring,
                    selectedRadioStationIds, "");

                return View("EditCart", viewModel);
            }

            var processingMessage = this.radioServices.UpdateRadioMainInfo(radioMainTransaction, transactionAiring,
                selectedRadioStationIds, scriptingMaterial, productionMaterial);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var viewModel = this.radioServices.GetRadioMainView(radioMainTransaction, transactionAiring,
                    selectedRadioStationIds, processingMessage);

                return View("EditCart", viewModel);
            }

            return RedirectToAction("Summary", "Order",
                new
                {
                    orderId = radioMainTransaction.OrderId, message = "Radio transaction updated"
                });
        }


        //user can delete the order by Id
        /// <summary>
        /// Deletes the order by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns>ActionResult.</returns>
        [CheckUserLogin()]
        public ActionResult DeleteOrderById(int transactionId)
        {
            if (transactionId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(transactionId));
            }
            this.radioServices.DeleteRadioOrder(transactionId);
            //Get The Currently Logged User Id
            var userId = (int)session.GetSessionValue(SessionKey.UserId);

            // Get order id
            var orderId = this.orderServices.GetOrderIdentifier(userId);

            //Update Cart
            this.transactionService.UpdateCart(orderId);

            return RedirectToAction("SummaryRedirect", "Order");

        }




        /// <summary>
        /// Uploads the radio script.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult UploadRadioScript(int transactionId, int userId)
        {
            if (transactionId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(transactionId));
            }
            var radio = new RadioScriptTransactionListView
            {
                transactionId = transactionId,
                userId = userId
            };

            return View(radio);
        }



        /// <summary>
        /// Files the result.
        /// </summary>
        /// <param name="FileId">The file identifier.</param>
        /// <returns></returns>
        public FileResult FileResult(int fileId)
        {
            var scriptFile = radioServices.GetScriptFileForDownload(fileId);


            return File(scriptFile.FileContent, scriptFile.ContentType);
        }

        #endregion



        #region Production Setup

        /// <summary>
        /// Gets the radio production view by identifier.
        /// </summary>
        /// <param name="radioProductionId">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult GetRadioProductionViewById(int radioProductionId)
        {
            if (radioProductionId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radioProductionId));
            }
            var radioModel = radioServices.GetRadioProductionListView(radioProductionId);
            return View("GetRadioProductionViewById",radioModel);
        }

        /// <summary>
        /// Uploads the radio production.
        /// </summary>
        /// <param name="radioProductionId">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult UploadRadioProduction(int radioProductionId)
        {
            if (radioProductionId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radioProductionId));
            }

            RadioProductionView radioview = new RadioProductionView();
            radioview.RadioTransactionId = radioProductionId;
            return View("UploadRadioProduction",radioview);
        }


        /// <summary>
        /// Uploads the radio production.
        /// </summary>
        /// <param name="radioProductionView">The radio production view.</param>
        /// <param name="productionMaterial">The production material.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult UploadRadioProduction(RadioProductionView radioProductionView,
            HttpPostedFileBase productionMaterial)
        {
            var userId = (int)session.GetSessionValue(SessionKey.UserId);
            radioProductionView.RadioTransactionId = userId;
            var view = radioServices.SaveradioProduction(radioProductionView, productionMaterial);

            return RedirectToAction("RadioListView");
        }


        #endregion


        #region Airing Setup

        /// <summary>/**/
        /// Adds the radio airing.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">transactionId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult AddRadioAiring(int transactionId)
        {
            if (transactionId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(transactionId));
            }


            //Get The Airing View in A Partial View

            var model = radioServices.GetRadioAiringView(transactionId, string.Empty);

            return PartialView("AddRadioAiring",model);
        }


        /// <summary>
        /// Adds the radio airing.
        /// </summary>
        /// <param name="radioAiringInfo">The radio airing information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">radioAiringInfo</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">transactionId</exception>
        [ValidateAntiForgeryToken]
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult AddRadioAiring(RadioTransactionAiringView radioAiringInfo)
        {
            if (radioAiringInfo == null)
            {
                throw new ArgumentNullException(nameof(radioAiringInfo));
            }

            if (!ModelState.IsValid)
            {
                var model = radioServices.GetRadioAiringView(radioAiringInfo.RadioTransactionId,
                    string.Empty);
                return View("AddRadioAiring", model);
            }

            var message = radioServices.ProcessAddRadioAiring(radioAiringInfo);

            if (!string.IsNullOrEmpty(message))
            {
                var model = radioServices.GetRadioAiringView(radioAiringInfo.RadioTransactionId,
                    message);
                return View("AddRadioAiring", model);
            }

            var returnMessage = string.Format("New Radio Station Added to this transaction");

            return RedirectToAction("EditCart", "Radio",
                new { cartId = radioAiringInfo.RadioTransactionId, message = returnMessage });
        }


        /// <summary>
        /// Deletes the by identifier.
        /// </summary>
        /// <param name="radioId">The identifier.</param>
        /// <returns></returns>
        [CheckUserLogin()]
        public ActionResult deleteById(int radioId)
        {
            if (radioId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radioId));
            }


            var delete = radioServices.DeleteRadioById(radioId);
            return RedirectToAction("Summary", "Order");
        }

        #endregion


        #region Radio Station Setup

        /// <summary>
        /// Radioes the station.
        /// </summary>
        /// <param name="selectedRadioStationId">The selected radio station identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>

        [CheckUserLogin()]
        public ActionResult RadioStation(int? selectedRadioStationId, string selectedDescription, string message)
        {
            var viewModel =
                radioServices.GetRadioStationListViewModel(selectedRadioStationId ?? 0, selectedDescription, message);
            return View("RadioStation", viewModel);
        }


        /// <summary>
        /// Radioes the ListView.
        /// </summary>
        /// <returns></returns>
        public ActionResult RadioListView()
        {
            var radioList = radioServices.GetRadioTransaction();
            return View("RadioListView",radioList);
        }


        /// <summary>
        /// Adds the radio station.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult AddRadioStation()
        {
            var radioModel = radioServices.GetRadioStationView();
            return View("AddRadioStation", radioModel);
        }

        /// <summary>
        /// Adds the radio station.
        /// </summary>
        /// <param name="radioview">The radioview.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">radioview</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult AddRadioStation(RadioStationView radioview)
        {
            if (radioview == null)
            {
                throw new ArgumentNullException("radioview");
            }

            if (!ModelState.IsValid)
            {
                var model = radioServices.GetRadioStationView(radioview, string.Empty);
                return View("AddRadioStation", model);
            }

            var message = radioServices.ProcessRadioStation(radioview);

            if (!string.IsNullOrEmpty(message))
            {
                var model = radioServices.GetRadioStationView(radioview, message);
                return View("AddRadioStation", model);
            }

            var returnMessage = string.Format("New Radio Station Registered - {0}", radioview.Description);

            return RedirectToAction("RadioStation", "Radio", new { message = returnMessage });
        }

        /// <summary>
        /// Edits the radio station.
        /// </summary>
        /// <param name="radioStationId">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditRadioStation(int radioStationId)
        {
            if (radioStationId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radioStationId));
            }
            var viewModel = radioServices.GetRadioStationById(radioStationId, "");
            return PartialView("EditRadioStation", viewModel);
        }


        /// <summary>
        /// Edits the radio station.
        /// </summary>
        /// <param name="radio">The radio.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditRadioStation(RadioStationView radio)
        {
            if (radio == null)
            {
                throw new ArgumentNullException(nameof(radio));
            }

            if (!ModelState.IsValid)
            {
                var model = radioServices.GetRadioStationView(radio, string.Empty);
                return View("EditRadioStation", model);
            }

            var processingMessage = radioServices.ProcessEditRadio(radio);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = radioServices.GetRadioStationView(radio, processingMessage);
                return View("EditRadioStation", model);
            }

            processingMessage = string.Format("Radio Station Edited");

            return RedirectToAction("RadioStation",
                new { message = processingMessage });
        }


        /// <summary>
        /// Deletes the radio station.
        /// </summary>
        /// <param name="radioStationId">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeleteRadioStation(int radioStationId)
        {
            if (radioStationId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radioStationId));
            }
            var radio = radioServices.GetRadioStationById(radioStationId, "");
            return PartialView("DeleteRadioStation", radio);
        }


        /// <summary>
        /// Deletes the radio station.
        /// </summary>
        /// <param name="radioStationId">The identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteRadioStation(int radioStationId, string btnSubmit)
        {
            var radioStation = radioServices.ProcessDeleteRadioStation(radioStationId);
            var returnMessage = string.Format("Radio Station Deleted");

            return RedirectToAction("RadioStation",
                new { message = returnMessage });
        }

        /// <summary>
        /// Gets the radio station price.
        /// </summary>
        /// <param name="radioStation">The radio station.</param>
        /// <param name="timingId">The timing identifier.</param>
        /// <param name="timeBeltId">The time belt identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult GetRadioStationPrice(int radioStation, int timingId, int timeBeltId,int materialTypeId)
        {
            var price = radioServices.GetRadioStationEffectivePrice(radioStation, timingId, timeBeltId,materialTypeId);
            return Json(price, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Radioes the station price.
        /// </summary>
        /// <param name="radioStation">The radio station.</param>
        /// <param name="timingId">The timing identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public decimal RadioStationPrice(int radioStation, int timingId,int materialType)
        {
            var price = radioServices.GetRadioPrice(radioStation, timingId,materialType);
            return price?.Amount ?? 0;
        }


        #endregion



        #region Production Price Setup
        /// <summary>
        /// Productions the price.
        /// </summary>
        /// <param name="selectedMaterialProductionPriceId">The selected material production price identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="selectedServiceTypeCode">The selected service type code.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>

        [CheckUserLogin()]
        public ActionResult ProductionPrice(int? selectedMaterialProductionPriceId, string selectedDescription,
            string selectedServiceTypeCode, string message)
        {
            var viewModel = radioServices.GetProductionPriceViewModel(selectedMaterialProductionPriceId ?? 0,
                selectedDescription, selectedServiceTypeCode, message);
            return View("ProductionPrice", viewModel);
        }


        /// <summary>
        /// Creates the production price.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous, HttpGet]
        [CheckUserLogin()]
        public ActionResult CreateProductionPrice()
        {
            var viewModel = radioServices.GetProductionPriceView();
            return View("CreateProductionPrice", viewModel);
        }

        /// <summary>
        /// Creates the production price.
        /// </summary>
        /// <param name="productionview">The productionview.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">productionview</exception>
        /// <exception cref="System.ArgumentNullException">productionview</exception>
        [AllowAnonymous, HttpPost]
        [CheckUserLogin()]
        public ActionResult CreateProductionPrice(MaterialProductionPriceView productionview)
        {
            if (productionview == null)
            {
                throw new ArgumentNullException("productionview");
            }

            if (productionview.MaterialTypeId.Equals(-1) && productionview.ServiceTypeCode == "")
            {
                var processingmessage = Messages.SelectOption;
                var model = radioServices.GetProductionPriceView(productionview, processingmessage);
                return View("CreateProductionPrice", model);
            }

            if (!ModelState.IsValid)
            {
                var model = radioServices.GetProductionPriceView(productionview, string.Empty);
                return View("CreateProductionPrice", model);
            }

            var message = radioServices.ProcessProductionPriceInfo(productionview);

            if (!string.IsNullOrEmpty(message))
            {
                var model = radioServices.GetProductionPriceView(productionview, message);

                return View("CreateProductionPrice", model);
            }

            var returnMessage = string.Format("New Material Production Price Registered - {0}", productionview.Comment);

            return RedirectToAction("ProductionPrice", "Radio", new { message = returnMessage });
        }


        /// <summary>
        /// Edits the material production price.
        /// </summary>
        /// <param name="materialProductionId">The identifier.</param>
        /// <returns></returns>
        [AllowAnonymous, HttpGet]
        [CheckUserLogin()]
        public ActionResult EditMaterialProductionPrice(int productionPriceId)
        {
            if (productionPriceId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(productionPriceId));
            }
            var viewModel = radioServices.GetMaterialProductionPriceById(productionPriceId, "");
            return PartialView("EditMaterialProductionPrice", viewModel);
        }

        /// <summary>
        /// Edits the material production price.
        /// </summary>
        /// <param name="priceview">The priceview.</param>
        /// <returns></returns>
        [AllowAnonymous, HttpPost]
        [CheckUserLogin()]
        public ActionResult EditMaterialProductionPrice(MaterialProductionPriceView priceview)
        {
            if (priceview == null)
            {
                throw new ArgumentNullException(nameof(priceview));
            }
            if (!ModelState.IsValid)
            {
                var model = radioServices.GetProductionPriceView(priceview, string.Empty);
                return View("EditMaterialProductionPrice", model);
            }

            var message = radioServices.ProcessEditProductionPrice(priceview);

            if (!string.IsNullOrEmpty(message))
            {
                var model = radioServices.GetProductionPriceView(priceview, message);

                return View("EditMaterialProductionPrice", model);
            }

            var returnMessage = string.Format("Production Price Edited");

            return RedirectToAction("ProductionPrice",
                new { message = returnMessage });
        }


        /// <summary>
        /// Deletes the material production price.
        /// </summary>
        /// <param name="productionPriceId">The production price identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">productionPriceId</exception>
        [CheckUserLogin()]
        public ActionResult DeleteMaterialProductionPrice(int productionPriceId)
        {
            if (productionPriceId < 1)
            {
                throw new ArgumentOutOfRangeException("productionPriceId");
            }

            var productionprice = radioServices.GetMaterialProductionPriceById(productionPriceId, "");
            return PartialView("DeleteMaterialProductionPrice", productionprice);
        }

        /// <summary>
        /// Deletes the material production price.
        /// </summary>
        /// <param name="productionPriceId">The identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Id</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteMaterialProductionPrice(int productionPriceId, string btnSubmit)
        {
            if (productionPriceId < 1)
            {
                throw new ArgumentOutOfRangeException("productionPriceId");
            }


            var message = radioServices.ProcessDeleteMaterialProductionPrice(productionPriceId);


            var returnMessage = string.Format("Material Production Price Deleted");

            return RedirectToAction("ProductionPrice",
                new { message = returnMessage });
        }

        #endregion


        #region Scripting Price Setup
        /// <summary>
        /// Scriptings the price.
        /// </summary>
        /// <param name="selectedMaterialScriptingPriceId">The selected material scripting price identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="selectedServiceTypeCode">The selected service type code.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        
        [CheckUserLogin()]
        public ActionResult ScriptingPrice(int? selectedMaterialScriptingPriceId, string selectedDescription,
            string selectedServiceTypeCode, string message)
        {
            var viewModel = radioServices.GetScriptingPriceViewModel(selectedMaterialScriptingPriceId ?? 0,
                selectedDescription, selectedServiceTypeCode, message);
            return View("ScriptingPrice", viewModel);
        }

        /// <summary>
        /// Creates the scripting price.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous, HttpGet]
        [CheckUserLogin()]
        public ActionResult CreateScriptingPrice()
        {
            var viewModel = radioServices.GetScriptingPriceView();
            return View("CreateScriptingPrice", viewModel);
        }

        /// <summary>
        /// Creats the scripting price.
        /// </summary>
        /// <param name="scriptingview">The scriptingview.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">scriptingview</exception>
        /// <exception cref="System.ArgumentNullException">scriptingview</exception>
        [AllowAnonymous, HttpPost]
        [CheckUserLogin()]
        public ActionResult CreateScriptingPrice(MaterialScriptingPriceView scriptingview)
        {
            if (scriptingview == null)
            {
                throw new ArgumentNullException("scriptingview");
            }

            if (!ModelState.IsValid)
            {
                var model = radioServices.GetScriptingPriceView(scriptingview, string.Empty);
                return View("CreateScriptingPrice", model);
            }

            var message = radioServices.ProcessScriptingPriceInfo(scriptingview);


            if (!string.IsNullOrEmpty(message))
            {
                var model = radioServices.GetScriptingPriceView(scriptingview, message);

                return View("CreateScriptingPrice", model);
            }

            var returnMessage = string.Format("New Material Scripting Price Registered - {0}", scriptingview.Comment);

            return RedirectToAction("ScriptingPrice", "Radio", new { message = returnMessage });
        }


        /// <summary>
        /// Edits the material scripting price.
        /// </summary>
        /// <param name="scriptingPriceId">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditMaterialScriptingPrice(int scriptingPriceId)
        {
            if (scriptingPriceId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(scriptingPriceId));
            }
            var viewModel = radioServices.GetMaterialScriptingPriceById(scriptingPriceId, string.Empty);
            return PartialView("EditMaterialScriptingPrice", viewModel);
        }

        /// <summary>
        /// Edits the material scripting price.
        /// </summary>
        /// <param name="priceView">The priceview.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditMaterialScriptingPrice(MaterialScriptingPriceView priceView)
        {
            if (priceView == null)
            {
                throw new ArgumentNullException(nameof(priceView));
            }
            if (!ModelState.IsValid)
            {
                var model = radioServices.GetScriptingPriceView(priceView, string.Empty);
                return View("EditMaterialScriptingPrice", model);
            }

            var message = radioServices.ProcessEditScriptingPrice(priceView);

            if (!string.IsNullOrEmpty(message))
            {
                var model = radioServices.GetScriptingPriceView(priceView, message);

                return View("EditMaterialScriptingPrice", model);
            }

            var returnMessage = string.Format("Material Scripting Price Edited", priceView.Comment);

            return RedirectToAction("ScriptingPrice",
                new { message = returnMessage });
        }


        /// <summary>
        /// Deletes the material scripting price.
        /// </summary>
        /// <param name="materialScriptingPriceId">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeleteMaterialScriptingPrice(int materialScriptingPriceId)
        {
            if (materialScriptingPriceId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(materialScriptingPriceId));
            }
            var viewModel = radioServices.GetMaterialScriptingPriceById(materialScriptingPriceId, string.Empty);
            return PartialView("DeleteMaterialScriptingPrice", viewModel);
        }


        /// <summary>
        /// Deletes the material scripting price.
        /// </summary>
        /// <param name="materialScriptingPriceId">The identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Id</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteMaterialScriptingPrice(int materialScriptingPriceId, string btnSubmit)
        {
            if (materialScriptingPriceId < 1)
            {
                throw new ArgumentOutOfRangeException("Id");
            }

            var message = radioServices.ProcessDeleteMaterialScriptingPrice(materialScriptingPriceId);


            var returnMessage = string.Format("Material Scripting Price Deleted");

            return RedirectToAction("ScriptingPrice",
                new { message = returnMessage });
        }

        #endregion


        #region Material Timing Setup
        /// <summary>
        /// Adds the material timing.
        /// </summary>
        /// <param name="timingId">The timing identifier.</param>
        /// <returns></returns>
       
        [CheckUserLogin()]
        public ActionResult AddMaterialTiming(int timingId)
        {
            if (timingId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(timingId));
            }
            var viewModel = radioServices.GetMaterialTimingRegistrationView(timingId);
            return PartialView("AddMaterialTiming", viewModel);
        }


        /// <summary>
        /// Gets the material prices.
        /// </summary>
        /// <param name="materialTypeId">The material type identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">materialTypeId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult GetMaterialPrices(int materialTypeId)
        {
            if (materialTypeId <= 0)
            {
                throw new ArgumentOutOfRangeException("materialTypeId");
            }

            var scriptingPrice = radioServices.GetScriptingPriceView(materialTypeId);
            var productionPrice = radioServices.GetProductionPriceView(materialTypeId);

            var result = new
            {
                scriptingPrice = scriptingPrice.ScriptingAmount,
                scriptingPriceId = scriptingPrice.MaterialScriptingPriceId,
                productionPrice = productionPrice.ProductionAmount,
                productionPriceId = productionPrice.MaterialProductionPriceId
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

       
       
        

#endregion
    }
}