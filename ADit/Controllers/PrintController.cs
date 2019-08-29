using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using ADit.Domain.Models;
using AA.Infrastructure.Interfaces;
using ADit.Domain.Attributes;
using ADit.Interfaces.ValueTypes;

namespace ADit.Controllers
{
    public class PrintController : Controller
    {
        public IOrderServices orderServices;
        private readonly IPrintService printService;
        private readonly ISessionStateService session;
        private readonly ITransactionService transactionService;
        private readonly ILookupService lookupService;


        public PrintController(IPrintService printService, ITransactionService transactionService,
            ISessionStateService session, ILookupService lookupService, IOrderServices orderServices)
        {
            this.printService = printService;
            this.transactionService = transactionService;
            this.session = session;
            this.lookupService = lookupService;
            this.orderServices = orderServices;
        }

        public ActionResult PrintMediaType(int? SelectedPrintNewsPaperId, string SelectedDescription, string message)
        {
            var viewModel =
                printService.GetPrintMediaTypeListViewModel(SelectedPrintNewsPaperId ?? 0, SelectedDescription,
                    message);
            return View("PrintMediaType", viewModel);
        }




        /// <summary>
        /// Adds the news paper.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult AddPrintMediaType()
        {
            var viewModel = this.printService.GetPrintMediaViewModel();

            return View("AddPrintMediaType", viewModel);
        }

     



        /// <summary>
        /// Adds the type of the print media.
        /// </summary>
        /// <param name="printMediaTypeView">The print media type view.</param>
        /// <returns></returns>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult AddPrintMediaType(PrintMediaTypeView printMediaTypeView)
        {
            if (printMediaTypeView == null)
            {
                throw new ArgumentNullException(nameof(printMediaTypeView));
            }

            if (!ModelState.IsValid)
            {
                return this.View("AddPrintMediaType", printMediaTypeView);
            }

            var viewModel = this.printService.ProcessPrintMediaInfo(printMediaTypeView);

            if (!string.IsNullOrEmpty(viewModel))
            {
                var returnModel = this.printService.getUpdatedPrintMediaType(printMediaTypeView, viewModel);
                return View("AddPrintMediaType", returnModel);
            }

            return RedirectToAction("PrintMediaType", "Print");
        }

        /// <summary>
        /// Edits the type of the print media.
        /// </summary>
        /// <param name="printMediaTypeView">The print media type view.</param>
        /// <param name="printMediaTypeId">The print media type identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditPrintMediaType(PrintMediaTypeView printMediaTypeView, int printMediaTypeId)
        {
            var editPrintMediaView = this.printService.GetEditPrintMediaType(printMediaTypeView, printMediaTypeId);
            return PartialView(editPrintMediaView);
        }




        /// <param name="newsPaperView">The news paper view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">newsPaperView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditPrintMediaType(PrintMediaTypeView printMediaTypeView)
        {
            if (printMediaTypeView == null)
            {
                throw new ArgumentNullException(nameof(printMediaTypeView));
            }

            if (!ModelState.IsValid)
            {
                return this.View("EditPrintMediaType", printMediaTypeView);
            }

            var processingMessage = this.printService.ProcessUpdatePrintMediaInfo(printMediaTypeView);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var returnModel = this.printService.getUpdatedPrintMediaType(printMediaTypeView, processingMessage);
                return View("EditPrintMediaType", returnModel);
            }

            return RedirectToAction("PrintMediaType", "Print");
        }
        /// <param name="newsPaperId">The news paper identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeletePrintMediaType(PrintMediaTypeView printMediaTypeView, int printTypeId)
        {
            var deleteNewsPaperView = this.printService.GetDeletePrintMediaType(printMediaTypeView, printTypeId);
            return PartialView(deleteNewsPaperView);
        }



        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeletePrintMediaTypeId(int PrintMediaTypeId)
        {
            if (PrintMediaTypeId< 1)
            {
                throw new ArgumentOutOfRangeException("PrintMediaTypeId");
            }

            var returnMessage = this.printService.GetDeletePrintMediaType(PrintMediaTypeId);

            return RedirectToAction("PrintMediaType", "Print", new { message = returnMessage });
        }





        #region Service Type Setup

        /// <summary>
        /// Prints the type of the service.
        /// </summary>
        /// <param name="selectedPrintServiceTypeId">The selected print service type identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>

        [CheckUserLogin()]
        public ActionResult PrintServiceType(int? selectedPrintServiceTypeId, string selectedDescription,
            string message)
        {
            var viewModel =
                printService.GetPrintServiceTypeListViewModel(selectedPrintServiceTypeId ?? 0, selectedDescription,
                    message);
            return View("PrintServiceType", viewModel);
        }


        /// <summary>
        /// Prints the service type price.
        /// </summary>
        /// <param name="selectedPrintServiceTypePriceId">The selected print service type price identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>

        [CheckUserLogin()]
        public ActionResult PrintServiceTypePrice(int? selectedPrintServiceTypePriceId, string selectedDescription,
            string message)
        {
            var viewModel = printService.GetPrintServiceTypePriceViewModel(selectedPrintServiceTypePriceId ?? 0,
                selectedDescription, message);
            return View("PrintServiceTypePrice", viewModel);
        }


        /// <summary>
        /// Adds the type of the print service.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult AddPrintServiceType()
        {
            var viewModel = this.printService.GetPrintServiceTypeViewModel();

            return this.View("AddPrintServiceType", viewModel);
        }

        /// <summary>
        /// Adds the type of the print service.
        /// </summary>
        /// <param name="printServiceTypeInfo">The print service type information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printServiceTypeInfo</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult AddPrintServiceType(PrintServiceTypeView printServiceTypeInfo)
        {
            if (printServiceTypeInfo == null)
            {
                throw new ArgumentNullException(nameof(printServiceTypeInfo));
            }

            if (!ModelState.IsValid)
            {
                return this.View("AddPrintServiceType", printServiceTypeInfo);
            }

            var processingMessage = this.printService.ProcessPrintServiceTypeInfo(printServiceTypeInfo);


            if (!string.IsNullOrEmpty(processingMessage))
            {
                var returnModel =
                    this.printService.GetUpdatedPrintSerrviceType(printServiceTypeInfo, processingMessage);
                return View("AddPrintServiceType", returnModel);
            }

            processingMessage = "New Print Service Type Added";

            return RedirectToAction("PrintServiceType", "Print", new {message = processingMessage});
        }


        /// <summary>
        /// Edits the type of the print service.
        /// </summary>
        /// <param name="printServiceTypeView">The print service type view.</param>
        /// <param name="printServiceTypeId">The print service type identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditPrintServiceType(PrintServiceTypeView printServiceTypeView, int printServiceTypeId)
        {
            var editPrintServiceTypeView =
                this.printService.GetEditPrintServiceType(printServiceTypeView, printServiceTypeId);
            return PartialView(editPrintServiceTypeView);
        }


        /// <summary>
        /// Edits the type of the print service.
        /// </summary>
        /// <param name="printServiceTypeView">The print service type view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printServiceTypeView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditPrintServiceType(PrintServiceTypeView printServiceTypeView)
        {
            if (printServiceTypeView == null)
            {
                throw new ArgumentNullException(nameof(printServiceTypeView));
            }

            if (!ModelState.IsValid)
            {
                return this.View("EditPrintServiceType", printServiceTypeView);
            }

            var processingMessage = this.printService.ProcessUpdatePrintServiceType(printServiceTypeView);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var viewModel =
                    this.printService.GetUpdatedPrintSerrviceType(printServiceTypeView, processingMessage);
                return View("EditPrintServiceType", viewModel);
            }

            processingMessage = "Selected Print Service Type Updated";
            return RedirectToAction("PrintServiceType", "Print");
        }


        /// <summary>
        /// Deletes the type of the print service.
        /// </summary>
        /// <param name="printServiceTypeView">The print service type view.</param>
        /// <param name="printServiceTypeId">The print service type identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeletePrintServiceType(PrintServiceTypeView printServiceTypeView, int printServiceTypeId)
        {
            var editPrintServiceTypeView =
                this.printService.GetDeletePrintServiceType(printServiceTypeView, printServiceTypeId);
            return PartialView("DeletePrintServiceType", editPrintServiceTypeView);
        }

        /// <summary>
        /// Deletes the type of the print service.
        /// </summary>
        /// <param name="printServiceTypeId">The print service type identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">newsPaperId</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeletePrintServiceType(int printServiceTypeId)
        {
            if (printServiceTypeId < 1)
            {
                throw new ArgumentOutOfRangeException("printServiceTypeId");
            }

            var returnMessage = this.printService.GetDeletePrintServiceType(printServiceTypeId);

            return RedirectToAction("PrintServiceType", "Print", new {message = returnMessage});
        }

        #endregion


        #region Newspaper Setup

        /// <summary>
        /// Newses the paper.
        /// </summary>
        /// <param name="selectedPrintNewsPaperId">The selected print news paper identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        
        [CheckUserLogin()]
        public ActionResult NewsPaper(int? selectedPrintNewsPaperId, string selectedDescription, string message)
        {
            var viewModel =
                printService.GetPrintNewsPaperListViewModel(selectedPrintNewsPaperId ?? 0, selectedDescription,
                    message);
            return View("NewsPaper", viewModel);
        }


        /// <summary>
        /// Adds the news paper.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult AddNewsPaper()
        {
            var viewModel = this.printService.GetNewsPaperViewModel();

            return View("AddNewsPaper", viewModel);
        }



        /// <summary>
        /// Adds the news paper.
        /// </summary>
        /// <param name="newsPaperView">The news paper view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">newsPaperView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult AddNewsPaper(NewsPaperView newsPaperView)
        {
            if (newsPaperView == null)
            {
                throw new ArgumentNullException(nameof(newsPaperView));
            }

            if (!ModelState.IsValid)
            {
                return this.View("AddNewsPaper", newsPaperView);
            }

            var processingMessage = this.printService.ProcessNewsPaperInfo(newsPaperView);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var returnModel = this.printService.GetUpdatedNewspaperView(newsPaperView, processingMessage);
                return View("AddNewsPaper", returnModel);
            }

            return RedirectToAction("Newspaper", "Print");
        }


        /// <summary>
        /// Edits the news paper.
        /// </summary>
        /// <param name="newsPaperView">The news paper view.</param>
        /// <param name="newsPaperId">The news paper identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditNewsPaper(NewsPaperView newsPaperView, int newsPaperId)
        {
            var editNewsPaperView = this.printService.GetEditNewsPaper(newsPaperView, newsPaperId);
            return PartialView("EditNewsPaper", editNewsPaperView);
        }







        /// <summary>
        /// Edits the news paper.
        /// </summary>
        /// <param name="newsPaperView">The news paper view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">newsPaperView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditNewsPaper(NewsPaperView newsPaperView)
        {
            if (newsPaperView == null)
            {
                throw new ArgumentNullException(nameof(newsPaperView));
            }

            if (!ModelState.IsValid)
            {
                return this.View("EditNewsPaper", newsPaperView);
            }

            var processingMessage = this.printService.ProcessUpdateNewsPaperInfo(newsPaperView);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var returnModel = this.printService.GetUpdatedNewspaperView(newsPaperView, processingMessage);
                return View("EditNewsPaper", returnModel);
            }

            return RedirectToAction("NewsPaper", "Print");
        }


        /// <summary>
        /// Deletes the news paper.
        /// </summary>
        /// <param name="newsPaperView">The news paper view.</param>
        /// <param name="newsPaperId">The news paper identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeleteNewsPaper(NewsPaperView newsPaperView, int newsPaperId)
        {
            if (newsPaperView == null)
            {
                throw new ArgumentNullException(nameof(newsPaperView));
            }

            if (newsPaperId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(newsPaperId));
            }

            var deleteNewsPaperView = this.printService.GetDeleteNewsPaper(newsPaperView, newsPaperId);
            return PartialView("DeleteNewsPaper", deleteNewsPaperView);
        }

        /// <summary>
        /// Deletes the news paper.
        /// </summary>
        /// <param name="newsPaperId">The news paper identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">newsPaperId</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteNewsPaper(int newsPaperId)
        {
            if (newsPaperId < 1)
            {
                throw new ArgumentOutOfRangeException("newsPaperId");
            }

            var processinigMessage = this.printService.GetDeleteNewsPaper(newsPaperId);

            return RedirectToAction("NewsPaper", "Print", new {message = processinigMessage});
        }


        /// <summary>
        /// Gets the news paper price.
        /// </summary>
        /// <param name="newsPaperId">The news paper identifier.</param>
        /// <param name="serviceTypeId">The service type identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// newsPaperId
        /// or
        /// serviceTypeId
        /// </exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult GetNewsPaperPrice(int newsPaperId, int serviceTypeId, int serviceColorId,int PrintMediaTypeId)
        {
            if (newsPaperId <= 0)
            {
                throw new ArgumentOutOfRangeException("newsPaperId");
            }


            if (serviceTypeId <= 0)
            {
                throw new ArgumentOutOfRangeException("serviceTypeId");
            }

            var price = printService.GetNewsPaperPrice(newsPaperId, serviceTypeId, serviceColorId,PrintMediaTypeId);

            var result = new
            {
                price = price,
            };


            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region Print Category Setup

        /// <summary>
        /// Prints the category.
        /// </summary>
        /// <param name="selectedPrintCategoryId">The selected print category identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        
        [CheckUserLogin()]
        public ActionResult PrintCategory(int? selectedPrintCategoryId, string selectedDescription, string message)
        {
            var viewModel =
                printService.GetPrintCategoryListViewModel(selectedPrintCategoryId ?? 0, selectedDescription, message);
            return View("PrintCategory", viewModel);
        }


        /// <summary>
        /// Adds the print category.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult AddPrintCategory()
        {
            var viewModel = this.printService.GetPrintCategoryViewModel();

            return this.View("AddPrintCategory", viewModel);
        }

        /// <summary>
        /// Adds the print category.
        /// </summary>
        /// <param name="printCategoryView">The print category view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printCategoryView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult AddPrintCategory(PrintCategoryView printCategoryView)
        {
            if (printCategoryView == null)
            {
                throw new ArgumentNullException(nameof(printCategoryView));
            }

            if (!ModelState.IsValid)
            {
                return this.View("AddPrintCategory", printCategoryView);
            }

            var viewModel = this.printService.ProcessPrintCategoryInfo(printCategoryView);

            if (!string.IsNullOrEmpty(viewModel))
            {
                var returnModel = this.printService.GetUpdatedPrintCategoryView(printCategoryView, viewModel);
                return View("AddPrintCategory", returnModel);
            }

            return RedirectToAction("PrintCategory", "Print");
        }


        /// <summary>
        /// Edits the print category.
        /// </summary>
        /// <param name="printCategoryView">The print category view.</param>
        /// <param name="printCategoryId">The print category identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditPrintCategory(PrintCategoryView printCategoryView, int printCategoryId)
        {
            var editPrintCategoryView = this.printService.GetEditPrintCategory(printCategoryView, printCategoryId);
            return PartialView(editPrintCategoryView);
        }

        /// <summary>
        /// Edits the print category.
        /// </summary>
        /// <param name="printCategoryInfo">The print category information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">PrintCategoryInfo</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditPrintCategory(PrintCategoryView printCategoryInfo)
        {
            if (printCategoryInfo == null)
            {
                throw new ArgumentNullException(nameof(printCategoryInfo));
            }

            if (!ModelState.IsValid)
            {
                return this.View("EditPrintCategory", printCategoryInfo);
            }

            var processingMessage = this.printService.ProcessUpdatePrintCategory(printCategoryInfo);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var viewModel = this.printService.GetUpdatedPrintCategoryView(printCategoryInfo, processingMessage);
                return View("EditPrintCategory", viewModel);
            }

            return RedirectToAction("PrintCategory", "Print");
        }


        /// <summary>
        /// Deletes the print category.
        /// </summary>
        /// <param name="printCategoryView">The print category view.</param>
        /// <param name="printCategoryId">The print category identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeletePrintCategory(PrintCategoryView printCategoryView, int printCategoryId)
        {
            var deletePrintCategoryView = this.printService.GetDeletePrintCategory(printCategoryView, printCategoryId);
            return PartialView("DeletePrintCategory", deletePrintCategoryView);
        }

        /// <summary>
        /// Deletes the print category.
        /// </summary>
        /// <param name="printCategoryId">The print category identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">printCategoryId</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeletePrintCategory(int printCategoryId)
        {
            if (printCategoryId < 1)
            {
                throw new ArgumentOutOfRangeException("printCategoryId");
            }

            var processingMessage = this.printService.GetDeletePrintCategory(printCategoryId);

            return RedirectToAction("PrintCategory", "Print", new {message = processingMessage});
        }

        #endregion


        #region Service Type Price

        /// <summary>
        /// Adds the print service type price.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult AddPrintServiceTypePrice()
        {
            var viewModel = this.printService.GetPrintServiceTypePriceViewModel();

            return View("AddPrintServiceTypePrice", viewModel);
        }

        /// <summary>
        /// Adds the print service type price.
        /// </summary>
        /// <param name="printServiceTypePriceView">The print service type price view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printServiceTypePriceView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult AddPrintServiceTypePrice(PrintServiceTypePriceView printServiceTypePriceView)
        {
            if (printServiceTypePriceView == null)
            {
                throw new ArgumentNullException(nameof(printServiceTypePriceView));
            }

            if (!ModelState.IsValid)
            {
                var returnView = this.printService.GetUpdatedPrintServiceTypePriceView(printServiceTypePriceView);
                return this.View("AddPrintServiceTypePrice", returnView);
            }

            printService.ProcessAddPrintServiceTypePriceViewModel(printServiceTypePriceView);
            var viewModel = this.printService.GetPrintServiceTypePriceViewModel();

            return RedirectToAction("PrintServiceTypePrice", "Print");
        }

        /// <summary>
        /// Edits the print service type price.
        /// </summary>
        /// <param name="printServiceTypePriceView">The print service type price view.</param>
        /// <param name="printServiceTypePriceId">The print service type price identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditPrintServiceTypePrice(PrintServiceTypePriceView printServiceTypePriceView,
            int printServiceTypePriceId)
        {
            var editPrintServiceTypePriceView =
                this.printService.GetEditPrintServiceTypePrice(printServiceTypePriceView, printServiceTypePriceId);
            return PartialView("EditPrintServiceTypePrice", editPrintServiceTypePriceView);
        }

        /// <summary>
        /// Edits the print service type price.
        /// </summary>
        /// <param name="printServiceTypePriceView">The print service type price view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printServiceTypePriceView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditPrintServiceTypePrice(PrintServiceTypePriceView printServiceTypePriceView)
        {
            if (printServiceTypePriceView == null)
            {
                throw new ArgumentNullException(nameof(printServiceTypePriceView));
            }

            if (!ModelState.IsValid)
            {
                var returnView = this.printService.GetUpdatedPrintServiceTypePriceView(printServiceTypePriceView);
                return View("EditPrintServiceTypePrice", returnView);
            }

            var editPrintServiceTypePriceView =
                this.printService.GetEditPrintServiceTypePrice(printServiceTypePriceView);

            return RedirectToAction("PrintServiceTypePrice", "Print",
                new {printServiceTypePriceId = editPrintServiceTypePriceView.PrintServiceTypePriceId});
        }


        /// <summary>
        /// Deletes the print service type price.
        /// </summary>
        /// <param name="printServiceTypePriceView">The print service type price view.</param>
        /// <param name="printServiceTypePriceId">The print service type price identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeletePrintServiceTypePrice(PrintServiceTypePriceView printServiceTypePriceView,
            int printServiceTypePriceId)
        {
            var editPrintServiceTypePriceView =
                this.printService.GetDeletePrintServiceTypePrice(printServiceTypePriceView, printServiceTypePriceId);
            return PartialView("DeletePrintServiceTypePrice", editPrintServiceTypePriceView);
        }

        /// <summary>
        /// Deletes the print service type price.
        /// </summary>
        /// <param name="printServiceTypePriceId">The print service type price identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">printServiceTypePriceId</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeletePrintServiceTypePrice(int printServiceTypePriceId)
        {
            if (printServiceTypePriceId < 1)
            {
                throw new ArgumentOutOfRangeException("printServiceTypePriceId");
            }

            var returnMessage = this.printService.GetDeletePrintServiceTypePrice(printServiceTypePriceId);

            return RedirectToAction("PrintServiceTypePrice", "Print", new {message = returnMessage});
        }

        #endregion


        #region Print Media Service Main Setup

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous, HttpGet]
        [CheckUserLogin()]
        public ActionResult Index()
        {
            var printView = this.printService.GetPrintView();


            return this.View("Index", printView);
        }


        /// <summary>
        /// Indexes the specified print transaction UI.
        /// </summary>
        /// <param name="printTransactionUi">The print transaction UI.</param>
        /// <param name="printTransactionAiringUi">The print transaction airing UI.</param>
        /// <param name="selectedNewsPapersId">The selected news papers identifier.</param>
        /// <param name="artworkUpload">The artwork upload.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// printTransactionUi
        /// or
        /// printTransactionAiringUi
        /// or
        /// selectedNewsPapersId
        /// </exception>
        [ValidateAntiForgeryToken]
        [AllowAnonymous, HttpPost]
        [CheckUserLogin()]
        public ActionResult Index(PrintTransactionUI printTransactionUi,
            List<PrintTransactionAiringUI> printTransactionAiringUi, List<int> selectedNewsPapersId,
            HttpPostedFileBase artworkUpload)
        {
            if (printTransactionUi == null)
            {
                throw new ArgumentNullException(nameof(printTransactionUi));
            }

            if (printTransactionAiringUi == null)
            {
                throw new ArgumentNullException(nameof(printTransactionAiringUi));
            }

            if (selectedNewsPapersId == null)
            {
                throw new ArgumentNullException(nameof(selectedNewsPapersId));
            }


            //Get The Currently Logged User Id
            if (!ModelState.IsValid)
            {
                var viewModel = this.printService.GetPrintView(printTransactionUi, printTransactionAiringUi,
                    selectedNewsPapersId, "");

                return View("Index", viewModel);
            }


            var processingMessage = string.Empty;
            int orderId = -1;

            //save the order info
            processingMessage = this.printService.ProcessPrintView(printTransactionUi, printTransactionAiringUi,
                artworkUpload,
                out orderId, selectedNewsPapersId);


            if (!string.IsNullOrEmpty(processingMessage))
            {
                var viewModel = this.printService.GetPrintView(printTransactionUi, printTransactionAiringUi,
                    selectedNewsPapersId, processingMessage);

                return View("Index", viewModel);
            }


            return RedirectToAction("Summary", "Order",
                new {orderId = orderId, message = string.Format("Print Media Service Added to Cart")});
        }

        /// <summary>
        /// Prints the specified selected print transaction ids.
        /// </summary>
        /// <param name="selectedPrintTransactionIds">The selected print transaction ids.</param>
        /// <returns></returns>
        [AllowAnonymous, HttpGet]
        [CheckUserLogin()]
        public ActionResult Print(int? selectedPrintTransactionIds)
        {
            var viewModel = this.printService.GetPrintHistoryPage(selectedPrintTransactionIds ?? -1);
            return View("Print", viewModel);
        }


        /// <summary>
        /// Edits the print.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">transactionId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditPrint(int transactionId)
        {
            if (transactionId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(transactionId));
            }


            //Get The Currently Logged User Id
            var userId = (int) session.GetSessionValue(SessionKey.UserId);


            var viewModel = this.printService.GetPrint(transactionId, userId, "");


            return this.View("EditPrint", viewModel);
        }

        //user can delete the order by Id
        [CheckUserLogin()]
        public ActionResult DeleteOrderById(int transactionId)

        {
            if (transactionId <= 0)
            {
                throw new ArgumentNullException(nameof(transactionId));
            }

            this.printService.DeletePrintOrder(transactionId);

            //Get The Currently Logged User Id
            var userId = (int) session.GetSessionValue(SessionKey.UserId);

            // Get order id
            var orderId = this.orderServices.GetOrderIdentifier(userId);

            //Update Cart
            this.transactionService.UpdateCart(orderId);
            return RedirectToAction("SummaryRedirect", "Order");
        }

        /// <summary>
        /// Edits the print.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="artwork">The artwork.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">view</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditPrint(PrintTransactionUI printTransactionUi,
            List<PrintTransactionAiringUI> printTransactionAiringUi, List<int> selectedNewsPapersId,
            HttpPostedFileBase artworkUpload)
        {
            if (printTransactionUi == null)
            {
                throw new ArgumentNullException(nameof(printTransactionUi));
            }

            if (printTransactionAiringUi == null)
            {
                throw new ArgumentNullException(nameof(printTransactionAiringUi));
            }

            if (selectedNewsPapersId == null)
            {
                throw new ArgumentNullException(nameof(selectedNewsPapersId));
            }


            //Get The Currently Logged User Id
            if (!ModelState.IsValid)
            {
                var viewModel = this.printService.GetPrintView(printTransactionUi, printTransactionAiringUi,
                    selectedNewsPapersId, "");

                return View("Index", viewModel);
            }


            var processingMessage = string.Empty;
            int orderId = -1;

            //save the order info
            processingMessage = this.printService.ProcessEditPrint(printTransactionUi, printTransactionAiringUi,
                artworkUpload,
                out orderId, selectedNewsPapersId);


            if (!string.IsNullOrEmpty(processingMessage))
            {
                var viewModel = this.printService.GetPrintView(printTransactionUi, printTransactionAiringUi,
                    selectedNewsPapersId, processingMessage);

                return View("Index", viewModel);
            }


            return RedirectToAction("Summary", "Order",
                new {orderId = orderId, message = string.Format("Print Media Service Updated")});
        }

        #endregion


        #region Airing Setup

        /// <summary>
        /// Adds the print airing.
        /// </summary>
        /// <param name="printAiringId">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Id</exception>
        [AllowAnonymous, HttpGet]
        [CheckUserLogin()]
        public ActionResult AddPrintAiring(int printAiringId)
        {
            if (printAiringId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(printAiringId));
            }

            var model = this.printService.GetPrintAiring(printAiringId, string.Empty);

            return PartialView("AddPrintAiring",model);
        }

        /// <summary>
        /// Adds the print airing.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">view</exception>
        [AllowAnonymous, HttpPost]
        [CheckUserLogin()]
        public ActionResult AddPrintAiring(PrintTransactionAiringView view)
        {
            if (view == null)
            {
                throw new ArgumentNullException(nameof(view));
            }


            if (!ModelState.IsValid)
            {
                var model = this.printService.GetPrintAiring(view.NewsPaperId, string.Empty);
                return View("AddPrintAiring", model);
            }

            var processingMessage = this.printService.ProcessPrintAiringView(view);


            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.printService.GetPrintAiring(view.NewsPaperId, string.Empty);
                return View("AddPrintAiring", model);
            }

            processingMessage = string.Format("New Nespaper item Added to this transaction");

            return RedirectToAction("EditPrint", "Print",
                new {transactionId = view.PrintTransactionId, message = processingMessage });
        }

        #endregion


        #region Apcon Approval Setup

        /// <summary>
        /// Apcons the approval price.
        /// </summary>
        /// <param name="apconApprovalId">The apcon approval identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">apconApprovalId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult ApconApprovalPrice(int apconApprovalId)
        {
            if (apconApprovalId <= 0)
            {
                throw new ArgumentOutOfRangeException("apconApprovalId");
            }

            var viewModel = printService.GetApconApprovalView(apconApprovalId);

            var result = new
            {
                apconApprovalAmount = viewModel.ApconAmount,
                apconApprovalTypePriceId = viewModel.ApconApprovalTypePriceId
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Apcons the approval price radio.
        /// </summary>
        /// <param name="apconApprovalTypeId">The apcon approval type identifier.</param>
        /// <returns></returns>
        
        [CheckUserLogin()]
        public ActionResult ApconApprovalPriceRadio(int apconApprovalTypeId)
        {
            var model = printService.GetApconApprovalView(apconApprovalTypeId);
            var result = new
            {
                apconPrice = model.ApconAmount,
                apconApprovalTypePriceId = model.ApconApprovalTypePriceId
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region Design Element

        /// <summary>
        /// Designs the element price.
        /// </summary>
        /// <param name="designElementPriceId">The design element price identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">designElementPriceId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DesignElementPrice(int designElementPriceId)
        {
            if (designElementPriceId <= 0)
            {
                throw new ArgumentOutOfRangeException("designElementPriceId");
            }

            var viewModel = printService.GetDesignElementPriceView(designElementPriceId);

            var result = new
            {
                DesignElementPrice = viewModel.DesignElementAmount,
                DesignElementPriceId = viewModel.DesignElementPriceId
            };


            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region PrintServiceColor

        /// <summary>
        /// Prints the color of the service.
        /// </summary>
        /// <param name="SelectedPrintServiceTypeColorId">The selected print service type color identifier.</param>
        /// <param name="SelectedPrintServiceTypeColor">Color of the selected print service type.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult PrintServiceColor(int? SelectedPrintServiceTypeColorId, string SelectedPrintServiceTypeColor, string message)
        {
            var viewModel =
                printService.GetPrintServiceColorListViewModel(SelectedPrintServiceTypeColorId ?? 0, SelectedPrintServiceTypeColor,
                    message);
            return View("PrintServiceColor", viewModel);

        }

        /// <summary>
        /// Adds the color of the print service.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult AddPrintServiceColor()
        {
            var viewModel = this.printService.GetPrintServiceColorViewModel();

            return View("AddPrintServiceColor", viewModel);
        }

        /// <summary>
        /// Adds the color of the print service.
        /// </summary>
        /// <param name="printServiceColorView">The print service color view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printServiceColorView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult AddPrintServiceColor(PrintServiceColorView printServiceColorView)
        {
            if (printServiceColorView == null)
            {
                throw new ArgumentNullException(nameof(printServiceColorView));
            }

            if (!ModelState.IsValid)
            {
                return this.View("AddPrintServiceColor", printServiceColorView);
            }

            var viewModel = this.printService.ProcessPrintServiceInfo(printServiceColorView);

            if (!string.IsNullOrEmpty(viewModel))
            {
                var returnModel = this.printService.GetUpdatedPrintServiceColor(printServiceColorView, viewModel);
                return View("AddPrintServiceColor", returnModel);
            }

            return RedirectToAction("PrintServiceColor", "Print");
        }


        /// <summary>
        /// Edits the color of the print service.
        /// </summary>
        /// <param name="printServiceTypeColorId">The print service type color identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditPrintServiceColor(int printServiceTypeColorId)
        {
            var editPrintServiceView = this.printService.GetEditPrintServiceColor(printServiceTypeColorId);
            return PartialView(editPrintServiceView);
        }


        /// <summary>
        /// Edits the color of the print service.
        /// </summary>
        /// <param name="printServiceColorView">The print service color view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printServiceColorView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditPrintServiceColor(PrintServiceColorView printServiceColorView)
        {
            if (printServiceColorView == null)
            {
                throw new ArgumentNullException(nameof(printServiceColorView));
            }

            if (!ModelState.IsValid)
            {
                return this.View("EditPrintServiceColor", printServiceColorView);
            }

            var processingMessage = this.printService.ProcessUpdatePrintServiceInfo(printServiceColorView);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var returnModel = this.printService.GetUpdatedPrintServiceColor(printServiceColorView, processingMessage);
                return View("EditPrintServiceColor", returnModel);
            }

            return RedirectToAction("PrintServiceColor", "Print");
        }

        /// <summary>
        /// Deletes the color of the print service.
        /// </summary>
        /// <param name="printServiceTypeColorId">The print service type color identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeletePrintServiceColor(PrintServiceColorView printServiceColorView, int printServiceTypeColorId)
        {
            var deletePrintServiceView = this.printService.GetDeletePrintServiceColor(printServiceColorView, printServiceTypeColorId);
            return PartialView(deletePrintServiceView);
        }


        /// <summary>
        /// Deletes the color of the print service.
        /// </summary>
        /// <param name="printServiceColorView">The print service color view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printServiceColorView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeletePrintServiceColor( int printServiceTypeColorId)
        {
            if (printServiceTypeColorId < 1) 
            {
                throw new ArgumentOutOfRangeException("printServiceTypeColorId");
            }

            var returnMessage = this.printService.GetDeletePrintServiceColor(printServiceTypeColorId);

            return RedirectToAction("PrintServiceColor", "Print", new { message = returnMessage });
        }



        #endregion

    }
}