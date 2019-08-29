using AA.Infrastructure.Interfaces;
using ADit.Domain.Models;
using ADit.Interfaces;
using ADit.Interfaces.ValueTypes;
using System;
using System.Web;
using System.Web.Mvc;
using ADit.Domain.Attributes;

namespace ADit.Controllers
{
    [Authorize]
    public class BrandingController : Controller
    {
        public IOrderServices orderServices;
        private readonly IBrandingService brandingService;
        private readonly ISessionStateService session;
        private readonly ITransactionService transactionService;
        private readonly ILookupService lookupService;


        public BrandingController(IBrandingService brandingService, ITransactionService transactionService,
            ISessionStateService session, ILookupService lookupService, IOrderServices orderServices)
        {
            this.brandingService = brandingService;
            this.transactionService = transactionService;
            this.session = session;

            this.lookupService = lookupService;
            this.orderServices = orderServices;
        }


        #region Branding Service Setup 

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult Index()
        {
            var brandingView = this.brandingService.GetBrandingView();
            return this.View("Index", brandingView);
        }


        /// <summary>
        /// Indexes the specified branding view.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <param name="designMaterial">The design material.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">brandingView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult Index(BrandingView brandingView, HttpPostedFileBase designMaterial)
        {
            if (brandingView == null)
            {
                throw new ArgumentNullException(nameof(brandingView));
            }


            //
            int orderId = -1;


            if (!ModelState.IsValid)
            {
                var modelView = this.brandingService.GetBrandingUpdatedView(brandingView, "");
                return View("Index", modelView);
            }


            //Store Branding Information to DB
            var processingMessage = this.brandingService.ProcessView(brandingView, designMaterial, out orderId);


            if (!string.IsNullOrEmpty(processingMessage))
            {
                var modelView = this.brandingService.GetBrandingUpdatedView(brandingView, "");
                return View("Index", modelView);
            }


            return this.RedirectToAction("Summary", "Order",
                new {orderId = orderId, message = "Branding transaction added to cart"});
        }

        //user can delete the order by Id
        [CheckUserLogin()]
        public ActionResult DeleteOrderById(int transactionId)

        {
            if (transactionId <= 0)
            {
                throw new ArgumentNullException(nameof(transactionId));
            }

            this.brandingService.DeleteBrandOrder(transactionId);
            //Get The Currently Logged User Id
            var userId = (int) session.GetSessionValue(SessionKey.UserId);

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
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">transactionId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditTransaction(int? transactionId, string message)
        {
            if (transactionId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(transactionId));
            }

            int transactionID = (int) transactionId;


            //Get The Currently Logged User Id
            var userId = (int) session.GetSessionValue(SessionKey.UserId);

            //update the message


            var model = this.brandingService.GetEditBrandingTransactionView(transactionID, userId, message);


            return View("EditTransaction", model);
        }


        /// <summary>
        /// Edits the cart.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <param name="designMaterial">The design material.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">tvInfo</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditTransaction(BrandingView brandingView, HttpPostedFileBase designMaterial)
        {
            var processingMessage = string.Empty;

            if (brandingView == null)
            {
                throw new ArgumentNullException(nameof(brandingView));
            }


            //Get The Currently Logged User Id
            var userId = (int) session.GetSessionValue(SessionKey.UserId);

            //update the message

            brandingView.UserId = userId;


            if (!ModelState.IsValid)
            {
                var model = this.brandingService.GetEditBrandingTransactionView(brandingView.BrandingTransactionId,
                    userId, "");
                return View("EditTransaction", model);
            }

            processingMessage = this.brandingService.UpdateBrandingTransaction(brandingView, designMaterial);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.brandingService.GetEditBrandingTransactionView(brandingView.BrandingTransactionId,
                    userId, "");
                return View("EditTransaction", model);
            }

            processingMessage = string.Format(" Branding Transaction updated");

            return RedirectToAction("Summary", "Order",
                new {orderId = brandingView.OrderNumber, message = processingMessage});
        }

        #endregion

        #region Branding Material Setup

        /// <summary>
        /// Materials List view.
        /// </summary>
        /// <param name="selectedBrandingMaterialId">The selected branding material identifier.</param>
        /// <param name="selectedDesccription">The selected desccription.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>

        [CheckUserLogin()]
        public ActionResult Material(int? selectedBrandingMaterialId, string selectedDesccription, string message)
        {
            var viewModel =
                brandingService.GetMaterialListViewModel(selectedBrandingMaterialId ?? 0, selectedDesccription,
                    message);

            return View("Material", viewModel);
        }


        /// <summary>
        /// Adds the material.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ViewResult AddMaterial(string message)
        {
            var viewModel = this.brandingService.GetBrandingMaterialView();

            return View("AddMaterial", viewModel);
        }

        /// <summary>
        /// Adds the material.
        /// </summary>
        /// <param name="brandingMaterialView">The branding material view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">brandingMaterialView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult AddMaterial(BrandingMaterialView brandingMaterialView)
        {
            if (brandingMaterialView == null)
            {
                throw new ArgumentNullException("brandingMaterialView");
            }

            if (!ModelState.IsValid)
            {
                var brandingMaterialModel =
                    this.brandingService.GetBrandingMaterialView(brandingMaterialView, string.Empty);
                return this.View("AddMaterial", brandingMaterialModel);
            }


            var processingMessage = this.brandingService.ProcessBrandingMaterialInfo(brandingMaterialView);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var brandingMaterialModel =
                    this.brandingService.GetBrandingMaterialView(brandingMaterialView, processingMessage);
                return View("AddMaterial", brandingMaterialModel);
            }

            processingMessage = string.Format("Branding Material Saved");
            return this.RedirectToAction("Material", new {message = processingMessage});
        }


        /// <summary>
        /// Edits the branding material.
        /// </summary>
        /// <param name="brandingMaterialId">The branding material identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">BrandingMaterialId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditBrandingMaterial(int brandingMaterialId)
        {
            if (brandingMaterialId <= 0)
            {
                throw new ArgumentNullException(nameof(brandingMaterialId));
            }

            var brandingmaterialModel = this.brandingService.GetSelectedBrandingMaterialInfo(brandingMaterialId);
            return this.PartialView("EditBrandingMaterial", brandingmaterialModel);
        }

        /// <summary>
        /// Edits the branding material.
        /// </summary>
        /// <param name="brandingMaterialView">The brandingmaterial view.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditBrandingMaterial(BrandingMaterialView brandingMaterialView)
        {
            var processingMessage = string.Empty;

            if (!ModelState.IsValid)
            {
                var brandingMaterialModel =
                    this.brandingService.GetBrandingMaterialView(brandingMaterialView, string.Empty);

                return this.View("EditBrandingMaterial", brandingMaterialModel);
            }

             processingMessage = this.brandingService.UpdateBrandingMaterialInfo(brandingMaterialView);


            if (!string.IsNullOrEmpty(processingMessage))
            {
                var brandingMaterialModel =
                    this.brandingService.GetBrandingMaterialView(brandingMaterialView, processingMessage);
                return this.View("EditBrandingMaterial", brandingMaterialModel);
            }


            processingMessage = string.Format("Branding Material Updated ");

            return this.RedirectToAction("Material",
                new {message = processingMessage });
        }

        /// <summary>
        /// Deletes the branding material.
        /// </summary>
        /// <param name="brandingMaterialId">The branding material identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeleteBrandingMaterial(int brandingMaterialId)
        {
            if (brandingMaterialId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(brandingMaterialId));
            }
            var brandingMaterialModel = this.brandingService.GetSelectedBrandingMaterialInfo(brandingMaterialId);
            return this.PartialView("DeleteBrandingMaterial", brandingMaterialModel);
        }

        /// <summary>
        /// Deletes the branding material.
        /// </summary>
        /// <param name="brandingMaterialId">The branding material identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">brandingMaterialId</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteBrandingMaterial(int brandingMaterialId, string btnSubmit)
        {
            if (brandingMaterialId < 1)
            {
                throw new ArgumentOutOfRangeException("brandingMaterialId");
            }

             this.brandingService.ProcessDeleteBrandingMaterialInfo(brandingMaterialId);

            var returnMessage = string.Format("Branding Material Deleted");

            return this.RedirectToAction("Material",
                new {message = returnMessage});
        }

        #endregion


        #region Branding Material Price Setup

        /// <summary>
        /// Brandings the material price.
        /// </summary>
        /// <param name="selectedBrandingMaterialPriceId">The selected branding material price identifier.</param>
        /// <param name="selectedBrandingMaterial">The selected branding material.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>

        [CheckUserLogin()]
        public ActionResult BrandingMaterialPrice(int? selectedBrandingMaterialPriceId, string selectedBrandingMaterial,
            string message)
        {
            var viewModel = brandingService.GetBrandingMaterialPriceViewModel(selectedBrandingMaterialPriceId ?? 0,
                selectedBrandingMaterial, message);
            return View("BrandingMaterialPrice", viewModel);
        }


        /// <summary>
        /// Creates the material price.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult CreateMaterialPrice()
        {
            var viewModel = brandingService.GetMaterialPriceView();
            return View("CreateMaterialPrice", viewModel);
        }

        /// <summary>
        /// Creates the material price.
        /// </summary>
        /// <param name="materialview">The materialview.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">materialview</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult CreateMaterialPrice(BrandingMaterialPriceView materialview)
        {
            if (materialview == null)
            {
                throw new ArgumentNullException("materialview");
            }

            if (!ModelState.IsValid)
            {
                var brandingMateriaprice = this.brandingService.GetMaterialPriceView(materialview, string.Empty);
                return this.View("CreateMaterialPrice", brandingMateriaprice);
            }

            var processingMessage = this.brandingService.ProcessMaterialPriceInfo(materialview);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var brandingMaterialModel = this.brandingService.GetMaterialPriceView(materialview, processingMessage);

                return this.View("CreateMaterialPrice", brandingMaterialModel);
            }

            processingMessage = string.Format("New branding material price added ");

            return this.RedirectToAction("BrandingMaterialPrice",
                new {message = processingMessage });
        }

        /// <summary>
        /// Edits the branding material price.
        /// </summary>
        /// <param name="brandingMaterialPriceId">The branding material price identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditBrandingMaterialPrice(int brandingMaterialPriceId)
        {
            var brandingMaterialPrice =
                this.brandingService.GetSelectedBrandingMaterialPricenfo(brandingMaterialPriceId);
            return this.PartialView("EditBrandingMaterialPrice", brandingMaterialPrice);
        }

        /// <summary>
        /// Edits the branding material price.
        /// </summary>
        /// <param name="brandingMaterialPriceView">The branding material price view.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditBrandingMaterialPrice(BrandingMaterialPriceView brandingMaterialPriceView)
        {
            if (!ModelState.IsValid)
            {
                var brandingMaterialviewModel =
                    this.brandingService.GetMaterialPriceView(brandingMaterialPriceView, string.Empty);

                return View("EditBrandingMaterialPrice", brandingMaterialviewModel);
            }

            var processingMessage = this.brandingService.ProcessEditBrandingMaterialPriceInfo(brandingMaterialPriceView);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var brandingMaterialPriceInfo =
                    this.brandingService.GetMaterialPriceView(brandingMaterialPriceView, processingMessage);
                return this.View("EditBrandingMaterialPrice", brandingMaterialPriceInfo);
            }


            processingMessage = string.Format("Branding Material Price Edited");
            return this.RedirectToAction("BrandingMaterialPrice",
                new {message = processingMessage });
        }


        /// <summary>
        /// Deletes the branding material price.
        /// </summary>
        /// <param name="brandingMaterialPriceId">The branding material price identifier.</param>
        /// <returns></returns>
        public ActionResult DeleteBrandingMaterialPrice(int brandingMaterialPriceId)
        {
            var brandingMaterialModel =
                this.brandingService.GetSelectedBrandingMaterialPricenfo(brandingMaterialPriceId);
            return this.PartialView("DeleteBrandingMaterialPrice", brandingMaterialModel);
        }

        /// <summary>
        /// Deletes the branding material price.
        /// </summary>
        /// <param name="brandingMaterialPriceId">The branding material price identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteBrandingMaterialPrice(int brandingMaterialPriceId, string btnSubmit)
        {
            var brandingModel = this.brandingService.ProcessDeleteMaterialPriceInfo(brandingMaterialPriceId);

            var returnMessage = string.Format("Branding Material Price  Deleted");

            return this.RedirectToAction("BrandingMaterialPrice",
                new {message = returnMessage});
        }

        #endregion

        #region Branding Material Price Setup

        /// <summary>
        /// Brandings the material price amount.
        /// </summary>
        /// <param name="brandingMaterialId">The branding material identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">brandingMaterialId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult BrandingMaterialPriceAmount(int brandingMaterialId)
        {
            if (brandingMaterialId <= 0)
            {
                throw new ArgumentOutOfRangeException("brandingMaterialId");
            }

            var viewModel = brandingService.GetBrandingMaterialPrice(brandingMaterialId);

            var result = new
            {
                brandingMaterialPriceAmount = viewModel.BrandingMaterialAmount,
                brandingMaterialPriceId = viewModel.BrandingMaterialPriceId
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}