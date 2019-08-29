using ADit.Domain.Models;
using ADit.Interfaces;
using System;
using System.Web.Mvc;
using ADit.Domain.Attributes;
using ADit.Interfaces.ValueTypes;
using AA.Infrastructure.Interfaces;
using ADit.Domain.Resources;

namespace ADit.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class AdministrationController : Controller
    {
        private readonly IPrintService printService;
        private readonly IAccountService accountService;
        private readonly IBrandingService brandingService;
        private readonly ILookupService lookUpService;
        private readonly ISessionStateService session;
        private readonly ITvServices tvServices;
        private readonly IGeneralService generalService;
        private readonly IOnlineServices onlineServices;
        private readonly IOrderServices orderServices;
        private readonly ITransactionService transactionService;

        #region Initialization


        /// <summary>
        /// Initializes a new instance of the <see cref="AdministrationController"/> class.
        /// </summary>
        /// <param name="lookUpService">The look up service.</param>
        /// <param name="printService">The print service.</param>
        /// <param name="generalService">The general service.</param>
        /// <param name="brandingService">The branding service.</param>
        /// <param name="onlineServices">The online services.</param>
        /// <param name="orderServices">The order services.</param>
        /// <param name="transactionService">The transaction service.</param>
        /// <param name="radioServices">The radio services.</param>
        /// <param name="tvServices">The tv services.</param>
        public AdministrationController(ILookupService lookUpService, IPrintService printService, IGeneralService generalService,
            IBrandingService brandingService, IOnlineServices onlineServices, IOrderServices orderServices,
            ITransactionService transactionService, ITvServices tvServices,IAccountService accountService,  ISessionStateService session)

        {
            this.printService = printService;
            this.onlineServices = onlineServices;
            this.lookUpService = lookUpService;
            this.generalService = generalService;
            this.orderServices = orderServices;
            this.transactionService = transactionService;
            this.accountService = accountService;
            this.tvServices = tvServices;
            this.session = session;
            this.brandingService = brandingService;
        }

        #endregion

        #region Main Index Pages

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View("Index");
        }

        /// <summary>
        /// Brandings this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Branding()
        {
            return View("Index");
        }

        /// <summary>
        /// Prints this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Print()
        {
            return View("Index");
        }

        /// <summary>
        /// Onlines this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Online()
        {
            return View("Index");
        }

        /// <summary>
        /// Radioes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Radio()
        {
            return View("Index");
        }

        /// <summary>
        /// Tvs this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult TV()
        {
            return View("Index");
        }

        #endregion

        #region ApconSetup

        /// <summary>
        /// Apcons the specified message.
        /// </summary>
        /// <param name="selectedApconApprovalTypeId">The selected apcon approval type identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        [CheckUserLogin()]
        public ActionResult Apcon(int? selectedApconApprovalTypeId, string selectedDescription, string message)
        {
            var viewModel =
                this.lookUpService.GetApconApprovalTypeListView(selectedApconApprovalTypeId ?? 0, selectedDescription,
                    message);

            return View("Apcon", viewModel);
        }

        /// <summary>
        /// Adds the apcon.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult AddApcon(string message)
        {
            var viewModel = this.lookUpService.GetApconView();
            return this.View("AddApcon", viewModel);
        }

        /// <summary>
        /// Adds the apcon.
        /// </summary>
        /// <param name="apconView">The apconview.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">apconview</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult AddApcon(ApconApprovalView apconView)
        {
            if (apconView == null)
            {
                throw new ArgumentNullException("apconview");
            }

            if (!ModelState.IsValid)
            {
                var viewModel = this.lookUpService.GetApconView(apconView, string.Empty);
                return View("AddApcon", viewModel);
            }

            var processingMessage = this.generalService.ProcessApconView(apconView);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var viewModel = this.lookUpService.GetApconView(apconView, string.Empty);
                return this.View("AddApcon", viewModel);
            }

            return RedirectToAction("Apcon");
        }


        /// <summary>
        /// Edits the apcon.
        /// </summary>
        /// <param name="apconId">The apcon identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">apconId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditApcon(int apconId)
        {
            if (apconId <= 0)
            {
                throw new ArgumentNullException(nameof(apconId));
            }

            var viewModel = this.lookUpService.GetApconApprovalById(apconId, string.Empty);

            return this.PartialView("EditApcon", viewModel);
        }

        /// <summary>
        /// Edits the apcon.
        /// </summary>
        /// <param name="apconView">The apconview.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">apconview</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditApcon(ApconApprovalView apconView)
        {
            if (apconView == null)
            {
                throw new ArgumentNullException("apconview");
            }

            if (!ModelState.IsValid)
            {
                var viewModel = this.lookUpService.GetApconView(apconView, string.Empty);
                return View("EditApcon", viewModel);
            }

            var processingMessage = this.generalService.ProcessEditApcon(apconView);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var viewModel = this.lookUpService.GetApconView(apconView, string.Empty);
                return this.View("EditApcon", viewModel);
            }

            processingMessage = string.Format("Apcon Approval Type Edited");

            return this.RedirectToAction("Apcon",
                new {message = processingMessage});
        }


        /// <summary>
        /// Deletes the apcon.
        /// </summary>
        /// <param name="apconApprovalId">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Id</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeleteApcon(int apconApprovalId)
        {
            if (apconApprovalId <= 0)
            {
                throw new ArgumentNullException("apconApprovalId");
            }

            var viewModel = this.lookUpService.GetApconApprovalById(apconApprovalId, "");

            return this.PartialView("DeleteApcon", viewModel);
        }

        /// <summary>
        /// Deletes the apcon.
        /// </summary>
        /// <param name="apconId">The identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Id</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteApcon(int apconId, string btnSubmit)
        {
            if (apconId <= 0)
            {
                throw new ArgumentOutOfRangeException("apconId");
            }

            this.generalService.ProcessDeleteApcon(apconId);

            var processingMessage = string.Format("Apcon Deleted");

            return this.RedirectToAction("Apcon",
                new {message = processingMessage});
        }


        /// <summary>
        /// Apcons the price.
        /// </summary>
        /// <param name="selectedApconApprovalTypePriceId">The selected apcon approval type price identifier.</param>
        /// <param name="selectedApconApprovalId">The selected apcon approval identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        [CheckUserLogin()]
        public ActionResult ApconPrice(int? selectedApconApprovalTypePriceId, int? selectedApconApprovalId,
            string message)
        {
            var viewModel = lookUpService.GetApconApprovalTypePriceViewModel(selectedApconApprovalTypePriceId ?? 0,
                selectedApconApprovalId ?? 0, message);

            return View("ApconPrice", viewModel);
        }

        /// <summary>
        /// Creates the apcon price.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult CreateApconPrice()
        {
            var viewModel = this.lookUpService.GetApconApprovalTypePriceView();

            return this.View("CreateApconPrice", viewModel);
        }

        /// <summary>
        /// Creates the apcon price.
        /// </summary>
        /// <param name="apconPrice">The apcon price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">apconPrice</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult CreateApconPrice(ApconApprovalTypePriceView apconPrice)
        {
            if (apconPrice == null)
            {
                throw new ArgumentNullException("apconPrice");
            }

            if (!ModelState.IsValid)
            {
                // call service to update parentCompany drop down list
                var viewModel = this.lookUpService.GetApconApprovalTypePriceView(apconPrice, string.Empty);


                // return view
                return View("CreateApconPrice", viewModel);
            }

            var processingMessage = this.generalService.ProcessApconApprovalTypePriceView(apconPrice);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var viewModel = this.lookUpService.GetApconApprovalTypePriceView(apconPrice, processingMessage);
                // return view
                return View("CreateApconPrice", viewModel);
            }

            processingMessage =
                string.Format("{0} - Apcon Approval Type Price Registered", apconPrice.ApconApprovalType);

            return this.RedirectToAction("ApconPrice", new {message = processingMessage});
        }

        /// <summary>
        /// Edits the apcon price.
        /// </summary>
        /// <param name="apconPriceId">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Id</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditApconPrice(int apconPriceId)
        {
            if (apconPriceId <= 0)
            {
                throw new ArgumentNullException(nameof(apconPriceId));
            }

            var viewModel = this.lookUpService.GetApconApprovalTypePriceById(apconPriceId);
            return this.PartialView("EditApconPrice", viewModel);
        }

        /// <summary>
        /// Edits the apcon price.
        /// </summary>
        /// <param name="apconView">The apcon view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">apconView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditApconPrice(ApconApprovalTypePriceView apconView)
        {
            if (apconView == null)
            {
                throw new ArgumentNullException(nameof(apconView));
            }

            if (!ModelState.IsValid)
            {
                // call service to update parentCompany drop down list
                var viewModel = this.lookUpService.GetApconApprovalTypePriceView(apconView, string.Empty);
                return View("EditApconPrice", viewModel);
            }

            var processingMessage = this.generalService.ProcessEditScriptingPrice(apconView);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var viewModel = this.lookUpService.GetApconApprovalTypePriceView(apconView, processingMessage);
                // return view
                return View("EditApconPrice", viewModel);
            }

            var returnMessage = string.Format("Apcon Approval Type Price Edited");

            return this.RedirectToAction("ApconPrice",
                new {message = returnMessage});
        }

        /// <summary>
        /// Deletes the apcon price.
        /// </summary>
        /// <param name="apconPriceId">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Id</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeleteApconPrice(int apconPriceId)
        {
            if (apconPriceId <= 0)
            {
                throw new ArgumentOutOfRangeException("Id");
            }

            var apconPrice = this.lookUpService.GetDeleteApconApprovalTypePriceById(apconPriceId);
            return this.PartialView("DeleteApconPrice", apconPrice);
        }

        /// <summary>
        /// Deletes the apcon price.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Id</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteApconPrice(int apconPriceId, string btnSubmit)
        {
            if (apconPriceId <= 0)
            {
                throw new ArgumentOutOfRangeException("apconId");
            }

            this.generalService.ProcessDeleteApconApprovalTypePrice(apconPriceId);
            var returnMessage = string.Format("Apcon Approval Type Price Deleted");
            return this.RedirectToAction("ApconPrice", new {message = returnMessage});
        }

        #endregion

        #region Color Setup

        /// <summary>
        /// Colors the specified message.
        /// </summary>
        /// <param name="selectedColorId">The selected color identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        [CheckUserLogin()]
        public ActionResult Color(int? selectedColorId, string selectedDescription, string message)
        {
            var colorList = this.lookUpService.GetColorListViewModel(selectedColorId ?? 0, selectedDescription, message);
            return View("Color", colorList);
        }


        /// <summary>
        /// Edits the color.
        /// </summary>
        /// <param name="colorId">The color identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">ColorId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditColor(int colorId)
        {
            if (colorId <= 0)
            {
                throw new ArgumentNullException(nameof(colorId));
            }

            var viewModel = this.lookUpService.GetSelectedColorByInfo(colorId);
            return this.PartialView("EditColor", viewModel);
        }

        /// <summary>
        /// Edits the color.
        /// </summary>
        /// <param name="colorView">The color view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">colorView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditColor(ColorView colorView)
        {
            if (colorView == null)
            {
                throw new ArgumentNullException("colorView");
            }

            if (!ModelState.IsValid)
            {
                var colorModel = this.lookUpService.GetColorView(colorView, string.Empty);

                return this.View("EditColor", colorModel);
            }


            var colorEdit = this.generalService.UpdateColorInfo(colorView);

            if (!string.IsNullOrEmpty(colorEdit))
            {
                var colorModel = this.lookUpService.GetColorView(colorView, colorEdit);
                return View("EditColor", colorModel);
            }

            var returnMessage = string.Format("Color Updated ");

            return this.RedirectToAction("Color",
                new {message = returnMessage});
        }


        /// <summary>
        /// Adds the color.
        /// </summary>
        /// <returns></returns>
        [CheckUserLogin()]
        public ActionResult AddColor()

        {
            var viewModel = this.lookUpService.GetColorView();
            return this.View("AddColor", viewModel);
        }




        /// <summary>
        /// </summary>
        /// <param name="colorView">The color view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">colorView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult AddColor(ColorView colorView)
        {
            if (colorView == null)
            {
                throw new ArgumentNullException(nameof(colorView));
            }

            if (!ModelState.IsValid)
            {
                var colorModel = this.lookUpService.GetColorView(colorView, string.Empty);
                return this.View("AddColor", colorModel);
            }


            var colorInfo = this.generalService.ProcessColorInfo(colorView);
            if (!string.IsNullOrEmpty(colorInfo))
            {
                var colorModel = this.lookUpService.GetColorView(colorView, colorInfo);
                return View("AddColor", colorModel);
            }

            var returnMessage = string.Format("Color Saved");
            return this.RedirectToAction("Color",
                new {message = returnMessage});
        }

        #endregion

        #region TIming Setup

        /// <summary>
        /// Timings the specified message.
        /// </summary>
        /// <param name="selectedTimingId">The selected timing identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        [CheckUserLogin()]
        public ActionResult Timing(int? selectedTimingId, string selectedDescription, string message)
        {
            var timingList = this.lookUpService.GetTimingListView(selectedTimingId ?? 0, selectedDescription, message);
            return View("Timing", timingList);
        }


        /// <summary>
        /// Edits the timing.
        /// </summary>
        /// <param name="timingId">The timing identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">timingId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditTiming(int timingId)
        {
            if (timingId <= 0)
            {
                throw new ArgumentNullException(nameof(timingId));
            }

            var timingModel = this.lookUpService.GetSelectedTimingByInfo(timingId);
            return this.PartialView("EditTiming", timingModel);
        }

        /// <summary>
        /// Edits the timing.
        /// </summary>
        /// <param name="timingView">The timing view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">timingView</exception>
        [HttpPost]

        public ActionResult EditTiming(TimingView timingView)
        {
            if (timingView == null)
            {
                throw new ArgumentNullException("timingView");
            }

            if (!ModelState.IsValid)
            {
                var timingModel = this.lookUpService.GetTimingView(timingView, string.Empty);
                return PartialView("EditTiming", timingModel);
            }

            var timingEdit = this.generalService.UpdateTimingInfo(timingView);
            if (!string.IsNullOrEmpty(timingEdit))
            {
                var timingModel = this.lookUpService.GetTimingView(timingView, timingEdit);
                return PartialView("EditTiming", timingModel);
            }

            var returnMessage = string.Format("Timing Updated ");

            return this.RedirectToAction("Timing",
                new {message = returnMessage});
        }


        /// <summary>
        /// Adds the timing.
        /// </summary>
        /// <returns></returns>
        public ActionResult AddTiming()

        {
            var timingModel = this.lookUpService.GetTimingView();
            return View("AddTiming", timingModel);
        }


        /// <summary>
        /// save the material type
        /// </summary>
        /// <param name="timingView">The timing view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">timingView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult AddTiming(TimingView timingView)
        {
            if (timingView == null)
            {
                throw new ArgumentNullException(nameof(timingView));
            }


            if (!ModelState.IsValid)
            {
                var timingModel = this.lookUpService.GetTimingView(timingView, string.Empty);
                return View("AddTiming", timingModel);
            }

            var timingInfo = this.generalService.ProcessTimingIfo(timingView);
            if (!string.IsNullOrEmpty(timingInfo))
            {
                var timingModel = this.lookUpService.GetTimingView(timingView, timingInfo);
                return View("AddTiming", timingModel);
            }

            var returnMessage = string.Format("Timing Saved");
            return this.RedirectToAction("Timing",
                new {message = returnMessage});
        }


        /// <summary>
        /// Deletes the timing.
        /// </summary>
        /// <param name="timingId">The timing identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">timingId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeleteTiming(int timingId)
        {
            if (timingId < 1)
            {
                throw new ArgumentOutOfRangeException("timingId");
            }

            var timingModel = this.lookUpService.GetSelectedTimingByInfo(timingId);
            return this.PartialView("DeleteTiming", timingModel);
        }


        /// <summary>
        /// Deletes the timing.
        /// </summary>
        /// <param name="timingId">The timing identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">timingId</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteTiming(int timingId, string btnSubmit)
        {
            if (timingId < 1)
            {
                throw new ArgumentOutOfRangeException("timingId");
            }

            var message = this.generalService.ProcessDeleteTimingInfo(timingId);


            var returnMessage = string.Format("Timing Deleted");

            return this.RedirectToAction("Timing",
                new {message = returnMessage});
        }

        #endregion

        #region Duration Type Setups

        /// <summary>
        /// Durations the type.
        /// </summary>
        /// <param name="selectedDurationTypeId">The selected duration type identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        [CheckUserLogin()]
        public ActionResult DurationType(string selectedDurationTypeId, string selectedDescription, string message)
        {
            var durationTypeList =
                this.lookUpService.GetDurationTypeListView(selectedDurationTypeId, selectedDescription, message);
            return View("DurationType", durationTypeList);
        }


        /// <summary>
        /// Edits the duration.
        /// </summary>
        /// <param name="durationTypeCode">The duration type code.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">durationTypeCode</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditDurationType(string durationTypeCode)
        {
            if (durationTypeCode == "")
            {
                throw new ArgumentNullException(nameof(durationTypeCode));
            }


            var durationModel = this.lookUpService.GetSelectedDurationTypeInfo(durationTypeCode);
            return this.PartialView("EditDurationType", durationModel);
        }

        /// <summary>
        /// Edits the duration.
        /// </summary>
        /// <param name="durationTypeView">The duration type view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">durationTypeView</exception>
        [HttpPost]

        public ActionResult EditDurationType(DurationTypeView durationTypeView)
        {
            if (durationTypeView == null)
            {
                throw new ArgumentNullException("durationTypeView");
            }

            if (!ModelState.IsValid)
            {
                var durationTypeModel = this.lookUpService.GetDurationTypeView(durationTypeView, string.Empty);

                return this.View("EditDurationType", durationTypeModel);
            }

            var durationEdit = this.generalService.UpdateDurationTypeInfo(durationTypeView);
            if (!string.IsNullOrEmpty(durationEdit))
            {
                var durationModel = this.lookUpService.GetDurationTypeView(durationTypeView, durationEdit);
                return View("EditDurationType", durationModel);
            }

            var returnMessage = string.Format("Duration Updated ");

            return this.RedirectToAction("DurationType",
                new {message = returnMessage});
        }


        /// <summary>
        /// Adds the type of the duration.
        /// </summary>
        /// <returns></returns>
        public ActionResult AddDurationType()

        {
            var durationModel = this.lookUpService.GetDurationTypeView();
            return this.View("AddDurationType", durationModel);
        }

        //save the material type
        /// <summary>
        /// Adds the type of the duration.
        /// </summary>
        /// <param name="durationTypeView">The duration type view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">durationTypeView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult AddDurationType(DurationTypeView durationTypeView)
        {
            if (durationTypeView == null)
            {
                throw new ArgumentNullException(nameof(durationTypeView));
            }

            if (!ModelState.IsValid)
            {
                return this.View("AddDurationType", durationTypeView);
            }

            var durationInfo = this.generalService.ProcessDurationTypeInfo(durationTypeView);

            if (!string.IsNullOrEmpty(durationInfo))
            {
                var durationModel = this.lookUpService.GetDurationTypeView(durationTypeView, durationInfo);
                return View("AddDurationType", durationModel);
            }

            var returnMessage = string.Format("Duration Saved");
            return this.RedirectToAction("DurationType",
                new {message = returnMessage});
        }


        /// <summary>
        /// Deletes the type of the duration.
        /// </summary>
        /// <param name="durationTypeCode">The duration type code.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">durationTypeCode</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeleteDurationType(string durationTypeCode)
        {
            if (durationTypeCode == "")
            {
                throw new ArgumentOutOfRangeException("durationTypeCode");
            }

            var durationTypeModel = this.lookUpService.GetSelectedDurationTypeInfo(durationTypeCode);
            return this.PartialView("DeleteDurationType", durationTypeModel);
        }


        /// <summary>
        /// Deletes the type of the duration.
        /// </summary>
        /// <param name="durationTypeCode">The duration type code.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">durationTypeCode</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteDurationType(string durationTypeCode, string btnSubmit)
        {
            if (durationTypeCode == "")
            {
                throw new ArgumentOutOfRangeException("durationTypeCode");
            }

            var message = this.generalService.ProcessDeleteDurationTypeInfo(durationTypeCode);


            var returnMessage = string.Format("DurationType Deleted");

            return this.RedirectToAction("DurationType",
                new {message = returnMessage});
        }

        #endregion

        #region Design Element Setup

        /// <summary>
        /// Designs the element.
        /// </summary>
        /// <param name="selectedDesignElementId">The selected design element identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        [CheckUserLogin()]
        public ActionResult DesignElement(int? selectedDesignElementId, string selectedDescription, string message)
        {
            var viewModel =
                lookUpService.GetDesignElementListView(selectedDesignElementId ?? 0, selectedDescription, message);
            return View("DesignElement", viewModel);
        }


        /// <summary>
        /// Designs the element price.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="selectedDesignElementPriceId">The selected design element price identifier.</param>
        /// <param name="selectedServiceTypeCode">The selected service type code.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <returns></returns>
        [CheckUserLogin()]
        public ActionResult DesignElementPrice(string message, int? selectedDesignElementPriceId,
            string selectedServiceTypeCode, string selectedDescription)
        {
            var viewModel = lookUpService.GeDesignElementPriceViewModel(message, selectedDesignElementPriceId ?? 0,
                selectedServiceTypeCode, selectedDescription);
            return View("DesignElementPrice", viewModel);
        }

        /// <summary>
        /// Edits the design element price.
        /// </summary>
        /// <param name="designElementPriceId">The design element price identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">DesignElementPriceId</exception>
        
        [CheckUserLogin()]
        public ActionResult EditDesignElementPrice(int designElementPriceId)
        {
            if (designElementPriceId < 1)
            {
                throw new ArgumentOutOfRangeException("designElementPriceId");
            }


            var designelement = this.lookUpService.GetDeleteDesignElementPriceById(designElementPriceId);
            return this.PartialView("EditDesignElementPrice", designelement);
        }


        /// <summary>
        /// Edits the design element price.
        /// </summary>
        /// <param name="designElementPriceView">The design element price view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">designElementPriceView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditDesignElementPrice(DesignElementPriceView designElementPriceView)
        {
            if (designElementPriceView == null)
            {
                throw new ArgumentException("designElementPriceView");
            }
            

            if (!ModelState.IsValid)
            {
                var returnView = this.generalService.getUpdatedDesignElementView(designElementPriceView);

                return View("EditDesignElementPrice", returnView);
            }

            var processingMessage = this.generalService.ProcessEditElementPriceInfo(designElementPriceView);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var returnView = this.generalService.getUpdatedDesignElementView(designElementPriceView);

                return View("EditDesignElementPrice", returnView);

            }
            processingMessage = string.Format("Design Element Price Edited");

            return this.RedirectToAction("DesignElementPrice",
                new {message = processingMessage });
        }


        /// <summary>
        /// Deletes the design element price.
        /// </summary>
        /// <param name="designElementPriceId">The design element price identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">designElementPriceId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeleteDesignElementPrice(int designElementPriceId)
        {
            if (designElementPriceId < 1)
            {
                throw new ArgumentOutOfRangeException("designElementPriceId");
            }

            var designelement = this.lookUpService.GetDeleteDesignElementPriceById(designElementPriceId);
            return PartialView("DeleteDesignElementPrice", designelement);
        }


        /// <summary>
        /// Deletes the design element price.
        /// </summary>
        /// <param name="designElementPriceId">The design element price identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">designElementPriceId</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteDesignElementPrice(int designElementPriceId, string btnSubmit)
        {
            if (designElementPriceId < 1)
            {
                throw new ArgumentOutOfRangeException("designElementPriceId");
            }

             this.generalService.ProcessDeleteDesignElementPriceInfo(designElementPriceId);

            var processingMessage = string.Format("Design Element Price Deleted");


            return this.RedirectToAction("DesignElementPrice",
                new {message = processingMessage });
        }


        /// <summary>
        /// Adds the design element.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult AddDesignElement()
        {
            var viewModel = this.lookUpService.GetDesignElementViewModel();

            return this.View("AddDesignElement", viewModel);
        }


        /// <summary>
        /// Adds the design element.
        /// </summary>
        /// <param name="designElementView">The design element view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">designElementView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult AddDesignElement(DesignElementView designElementView)
        {
            if (designElementView == null)
            {
                throw new ArgumentNullException(nameof(designElementView));
            }


            var processingMessage = this.generalService.GetDesignElementViewModel(designElementView);

            var returnMessage = string.Format("Design Element Added");


            return this.RedirectToAction("DesignElement",
                new {message = returnMessage});
        }


        /// <summary>
        /// Edits the design element.
        /// </summary>
        /// <param name="designElementView">The design element view.</param>
        /// <param name="designElementId">The design element identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">designElementId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditDesignElement(DesignElementView designElementView, int designElementId)
        {
            if (designElementId < 1)
            {
                throw new ArgumentNullException("designElementId");
            }

            var editDesignElementView = this.lookUpService.GetEditDesignElement(designElementView, designElementId);
            return PartialView("EditDesignElement", editDesignElementView);
        }


        /// <summary>
        /// Edits the design element.
        /// </summary>
        /// <param name="designElementView">The design element view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">designElementView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditDesignElement(DesignElementView designElementView)
        {
            if (designElementView == null)
            {
                throw new ArgumentNullException("designElementView");
            }


            if (!ModelState.IsValid)
            {
                return this.View("EditDesignElement", designElementView);
            }

            var editDesignElementView = this.generalService.GetEditDesignElement(designElementView);

            return RedirectToAction("DesignElement", "Administration",
                new {designElementId = editDesignElementView});
        }

        /// <summary>
        /// Deletes the design element.
        /// </summary>
        /// <param name="designElementView">The design element view.</param>
        /// <param name="designElementId">The design element identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">designElementId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeleteDesignElement(DesignElementView designElementView, int designElementId)
        {
            if (designElementId < 1)
            {
                throw new ArgumentOutOfRangeException("designElementId");
            }

            var editDesignElementView = this.lookUpService.GetDeleteDesignElement(designElementView, designElementId);
            return PartialView("DeleteDesignElement", editDesignElementView);
        }


        /// <summary>
        /// Deletes the design element.
        /// </summary>
        /// <param name="designElementId">The design element identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">designElementId</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteDesignElement(int designElementId)
        {
            if (designElementId < 1)
            {
                throw new ArgumentOutOfRangeException("designElementId");
            }

            var returnMessage = this.generalService.GetDeleteDesignElement(designElementId);

            return RedirectToAction("DesignElement", "Administration",
                new {message = returnMessage});
        }


        /// <summary>
        /// Creates the design element price.
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateDesignElementPrice()
        {
            var viewModel = lookUpService.GetDesignElementPriceView();
            return View("CreateDesignElementPrice", viewModel);
        }


        /// <summary>
        /// Creates the design element price.
        /// </summary>
        /// <param name="designElementPriceView">The design element price view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">designelementview</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult CreateDesignElementPrice(DesignElementPriceView designElementPriceView)
        {
            if (designElementPriceView == null)
            {
                throw new ArgumentNullException("designelementview");
            }

            if (!ModelState.IsValid)
            {
                var returnView = this.generalService.getUpdatedDesignElementView(designElementPriceView);

                return View("CreateDesignElementPrice", returnView);
            }

            var returnModel = this.generalService.ProcessDesignElementPriceInfo(designElementPriceView);

            if (!string.IsNullOrEmpty(returnModel))
            {
                var designElementInfo =
                    this.lookUpService.GetDesignElementPriceView(designElementPriceView, returnModel);
                return this.PartialView("CreateDesignElementPrice", designElementInfo);
            }

            var returnMessage = string.Format("New design element created");

            return this.RedirectToAction("DesignElementPrice",
                new {message = returnMessage});
        }

        #endregion

        #region Material Type Setup

        /// <summary>
        /// Materials the type.
        /// </summary>
        /// <param name="selectedMaterialTypeId">The selected material type identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        //shows the list of material type
        [CheckUserLogin()]
        public ActionResult MaterialType(int? selectedMaterialTypeId, string selectedDescription, string message)
        {
            var viewModel =
                lookUpService.GetMaterialTypeListViewModel(selectedMaterialTypeId ?? 0, selectedDescription, message);
            return View("MaterialType", viewModel);
        }

        /// <summary>
        /// Adds the type of the material.
        /// </summary>
        /// <returns></returns>
        public ActionResult AddMaterialType()

        {
            var materialTypeModel = this.lookUpService.GetMaterialTypeView();
            return this.View("AddMaterialType", materialTypeModel);
        }

        /// <summary>
        /// Adds the type of the material.
        /// </summary>
        /// <param name="materialTypeView">The material type view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">materialTypeView</exception>
        //save the material type
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult AddMaterialType(MaterialTypeView materialTypeView)
        {
            if (materialTypeView == null)
            {
                throw new ArgumentNullException(nameof(materialTypeView));
            }

            if (!ModelState.IsValid)
            {
                var materialTypeModel = this.lookUpService.GetMaterialTypeView(materialTypeView, string.Empty);
                return this.View("AddMaterialType", materialTypeModel);
            }

            var materialTypeInfo = this.generalService.ProcessMaterialTypeInfo(materialTypeView);

            if (!string.IsNullOrEmpty(materialTypeInfo))
            {
                var materialTypeModel = this.lookUpService.GetMaterialTypeView(materialTypeView, materialTypeInfo);
                return View("AddMaterialType", materialTypeModel);
            }

            var returnMessage = string.Format("MaterialType Saved");
            return this.RedirectToAction("MaterialType",
                new {message = returnMessage});
        }


        /// <summary>
        /// Edits the type of the material.
        /// </summary>
        /// <param name="materialTypeId">The material type identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">materialTypeId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditMaterialType(int materialTypeId)
        {
            if (materialTypeId <= 0)
            {
                throw new ArgumentNullException(nameof(materialTypeId));
            }

            var materialTypeModel = this.lookUpService.GetMaterialTypeSelectedInfo(materialTypeId);
            return this.PartialView("EditMaterialType", materialTypeModel);
        }

        /// <summary>
        /// Edits the duration.
        /// </summary>
        /// <param name="materialTypeView">The material type view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">materialTypeView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditMaterialType(MaterialTypeView materialTypeView)
        {
            if (materialTypeView == null)
            {
                throw new ArgumentNullException("materialTypeView");
            }

            if (!ModelState.IsValid)
            {
                var materialTypeModel = this.lookUpService.GetMaterialTypeView(materialTypeView, string.Empty);
                return this.View("EditMaterialType", materialTypeModel);
            }

            var materialTypeEdit = this.generalService.UpdateMaterialTypeInfo(materialTypeView);

            if (!string.IsNullOrEmpty(materialTypeEdit))
            {
                var materialTypeModel = this.lookUpService.GetMaterialTypeView(materialTypeView, materialTypeEdit);
                return View("EditMaterialType", materialTypeModel);
            }


            var returnMessage = string.Format("Material Updated ");

            return this.RedirectToAction("MaterialType",
                new {message = returnMessage});
        }


        /// <summary>
        /// Deletes the type of the material.
        /// </summary>
        /// <param name="materialTypeId">The material type identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">materialTypeId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeleteMaterialType(int materialTypeId)
        {
            if (materialTypeId < 1)
            {
                throw new ArgumentOutOfRangeException("materialTypeId");
            }

            var materialTypeModel = this.lookUpService.GetMaterialTypeSelectedInfo(materialTypeId);
            return this.PartialView("DeleteMaterialType", materialTypeModel);
        }

        /// <summary>
        /// Deletes the type of the material.
        /// </summary>
        /// <param name="materialTypeId">The material type identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">materialTypeId</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteMaterialType(int materialTypeId, string btnSubmit)
        {
            if (materialTypeId < 1)
            {
                throw new ArgumentOutOfRangeException("materialTypeId");
            }


            this.generalService.ProcessDeleteMaterialTypeInfo(materialTypeId);

            var returnMessage = string.Format("MaterialType Deleted");

            return this.RedirectToAction("MaterialType",
                new {message = returnMessage});
        }

        #endregion

        #region Material Timing Setup

        /// <summary>
        /// Timings the specified message.
        /// </summary>
        /// <param name="selectedMaterialTypeTimingId">The selected material type timing identifier.</param>
        /// <param name="selectedTimingId">The selected timing identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        [CheckUserLogin()]
        public ActionResult MaterialTiming(int? selectedMaterialTypeTimingId, int? selectedTimingId,
            string selectedDescription, string message)
        {
            var timingList = this.lookUpService.GetMaterialTypeTimingListView(selectedMaterialTypeTimingId ?? 0,
                selectedTimingId ?? 0, selectedDescription, message);
            return View("MaterialTiming", timingList);
        }


        /// <summary>
        /// Creates the material timing.
        /// </summary>
        /// <returns></returns>
        
        [AllowAnonymous, HttpGet]
        [CheckUserLogin()]
        public ActionResult CreateMaterialTiming()
        {
            var viewModel = this.lookUpService.GetMaterialTypeTimingView();
            return this.View("CreateMaterialTiming", viewModel);
        }

        /// <summary>
        /// Creats the scripting price.
        /// </summary>
        /// <param name="timingview">The timingview.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">timingview</exception>
        /// <exception cref="System.ArgumentNullException">scriptingview</exception>
        
        [AllowAnonymous, HttpPost]
        [CheckUserLogin()]
        public ActionResult CreateMaterialTiming(MaterialTypeTimingView timingview)
        {
            if (timingview == null)
            {
                throw new ArgumentNullException("timingview");
            }

            if (!ModelState.IsValid)
            {
                // call service to update parentCompany drop down list
                var viewModel = this.lookUpService.GetMaterialTypeTimingView(timingview, string.Empty);

                // return view
                return View("CreateMaterialTiming", viewModel);
            }

            var processingMessage = this.generalService.ProcessMaterialTypeTimingInfo(timingview);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                // call service to update parentCompany drop down list
                var viewModel = this.lookUpService.GetMaterialTypeTimingView(timingview, string.Empty);
                // return the view
                return this.View("CreateMaterialTiming", viewModel);
            }

            var returnMessage = string.Format("{0} - Material Type Timing Registered", timingview.MaterialType);

            return this.RedirectToAction("MaterialTiming", new {message = returnMessage});
        }

        /// <summary>
        /// Edits the material timing.
        /// </summary>
        /// <param name="materialTypeTimingId">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Id</exception>
        
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditMaterialTiming(int materialTypeTimingId)
        {
            if (materialTypeTimingId <= 0)
            {
                throw new ArgumentNullException(nameof(materialTypeTimingId));
            }

            var editMaterialTypeTiming = this.lookUpService.GetEditMaterialTypeTimingById(materialTypeTimingId, "");
            return PartialView("EditMaterialTiming", editMaterialTypeTiming);
        }

        /// <summary>
        /// Edits the material timing.
        /// </summary>
        /// <param name="timingView">The timing view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">timingView</exception>
        
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditMaterialTiming(MaterialTypeTimingView timingView)
        {
            if (timingView == null)
            {
                throw new ArgumentNullException("timingView");
            }

            if (!ModelState.IsValid)
            {
                // call service to update parentCompany drop down list
                var viewModel = this.lookUpService.GetMaterialTypeTimingView(timingView, string.Empty);

                // return view
                return View("EditMaterialTiming", viewModel);
            }

            var processingMessage = this.generalService.ProcessMaterialTypeTimingInfo(timingView);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                // call service to update parentCompany drop down list
                var viewModel = this.lookUpService.GetMaterialTypeTimingView(timingView, string.Empty);
                // return the view
                return this.View("EditMaterialTiming", viewModel);
            }

            var returnMessage = string.Format("Material Type Edited");
            return this.RedirectToAction("MaterialTiming", new {message = returnMessage});
        }

        /// <summary>
        /// Deletes the material timing.
        /// </summary>
        /// <param name="materialTimingId">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Id</exception>
        
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeleteMaterialTiming(int materialTimingId)
        {
            if (materialTimingId <= 0)
            {
                throw new ArgumentOutOfRangeException("materialTimingId");
            }

            var materialTypeTiming = this.lookUpService.GetDeleteMaterialTypeTimingById(materialTimingId, "");
            return this.PartialView("DeleteMaterialTiming", materialTypeTiming);
        }

        /// <summary>
        /// Deletes the material timing.
        /// </summary>
        /// <param name="materialTimingId">The identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Id</exception>
        
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteMaterialTiming(int materialTimingId, string btnSubmit)
        {
            if (materialTimingId < 0)
            {
                throw new ArgumentOutOfRangeException("materialTimingId");
            }

            this.generalService.ProcessDeleteMaterialTypeTiming(materialTimingId);
            var returnMessage = string.Format("Material Type Timing Deleted");
            return this.RedirectToAction("MaterialTiming",
                new {message = returnMessage});
        }

        #endregion

        #region Radio Service

        /// <summary>
        /// Radioes the service.
        /// </summary>
        /// <param name="selectedRadioServiceId">The selected radio service identifier.</param>
        /// <param name="selectedRadioId">The selected radio identifier.</param>
        /// <param name="selectedTimingId">The selected timing identifier.</param>
        /// <param name="selectedMaterialTypeId">The selected material type identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        
        [CheckUserLogin()]
        public ActionResult RadioService(int? selectedRadioServiceId, int? selectedRadioId, int? selectedTimingId,
            int? selectedMaterialTypeId, string message)
        {
            var viewModel = lookUpService.GetRadioServicePriceViewModel(selectedRadioServiceId ?? 0,
                selectedRadioId ?? 0, selectedTimingId ?? 0, selectedMaterialTypeId ?? 0, message);
            return View("RadioService", viewModel);
        }


        /// <summary>
        /// Creates the radio service.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult CreateRadioService()
        {
            var viewModel = this.lookUpService.GetRadioServiceTypePriceView();
            return this.View("CreateRadioService", viewModel);
        }


        /// <summary>
        /// Creates the radio service.
        /// </summary>
        /// <param name="radioService">The radio service.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">radioService</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult CreateRadioService(RadioServicePriceListMain radioService)
        {

            var processingMessage = "";
            if (radioService == null)
            {
                throw new ArgumentNullException("radioService");
            }

            if (!ModelState.IsValid)
            {
                // call service to update parentCompany drop down list
                var viewModel = this.lookUpService.GetRadioServiceTypePriceView(radioService, string.Empty);


                // return view
                return View("CreateRadioService", viewModel);
            }
            var result = this.generalService.CheckRadioService(radioService);
            if (result)
            {
                processingMessage = Messages.ServiceExist;
                var viewModel = this.lookUpService.GetRadioServiceTypePriceView(radioService, processingMessage);

                return View("CreateRadioService", viewModel);
            }

            processingMessage = this.generalService.ProcessRadioServicePriceView(radioService);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var viewModel = this.lookUpService.GetRadioServiceTypePriceView(radioService, processingMessage);
                // return view
                return View("CreateRadioService", viewModel);
            }

            var returnMessage = string.Format("{0} - Radio Service Price Registered", radioService.RadioStationType);

            return this.RedirectToAction("RadioService", new {message = returnMessage});
        }


        /// <summary>
        /// Edits the radio service.
        /// </summary>
        /// <param name="radioServiceId">The radio service identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">radioServiceId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditRadioService(int radioServiceId)
        {
            if (radioServiceId <= 0)
            {
                throw new ArgumentNullException(nameof(radioServiceId));
            }

            var viewModel = this.lookUpService.GetRadioServicePriceById(radioServiceId);
            return this.PartialView("EditRadioService", viewModel);
        }


        /// <summary>
        /// Edits the radio service.
        /// </summary>
        /// <param name="radioServicePriceListView">The view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">view</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditRadioService(RadioServicePriceListMain radioServicePriceListView)
        {
            var processingMessage = "";
            if (radioServicePriceListView == null)
            {
                throw new ArgumentNullException(nameof(radioServicePriceListView));
            }

            if (!ModelState.IsValid)
            {
                // call service to update parentCompany drop down list
                var viewModel =
                    this.lookUpService.GetRadioServiceTypePriceView(radioServicePriceListView, string.Empty);
                return View("EditRadioService", viewModel);
            }


            var result = this.generalService.CheckRadioService(radioServicePriceListView);
            if (result)
            {
                processingMessage = Messages.ServiceExist;
                var viewModel = this.lookUpService.GetRadioServiceTypePriceView(radioServicePriceListView, processingMessage);
                return View("EditRadioService", viewModel);
            }

             processingMessage = this.generalService.ProcessEditScriptingPrice(radioServicePriceListView);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var viewModel =
                    this.lookUpService.GetRadioServiceTypePriceView(radioServicePriceListView, processingMessage);
                // return view
                return View("EditRadioService", viewModel);
            }

            var returnMessage = string.Format("Radio Service Price Edited");

            return this.RedirectToAction("RadioService",
                new {message = returnMessage});
        }


        /// <summary>
        /// Deletes the radio service.
        /// </summary>
        /// <param name="radioServiceId">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Id</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeleteRadioService(int radioServiceId)
        {
            if (radioServiceId <= 0)
            {
                throw new ArgumentOutOfRangeException("radioServiceId");
            }

            var radioPrice = this.lookUpService.GetDeleteRadioServicePriceById(radioServiceId);
            return this.PartialView("DeleteRadioService", radioPrice);
        }


        /// <summary>
        /// Deletes the radio service.
        /// </summary>
        /// <param name="radioServiceId">The identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Id</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteRadioService(int radioServiceId, string btnSubmit)
        {
            if (radioServiceId <= 0)
            {
                throw new ArgumentOutOfRangeException("radioServiceId");
            }

            this.generalService.ProcessDeleteRadioServicePrice(radioServiceId);
            var returnMessage = string.Format("Radio Service Price Deleted");
            return this.RedirectToAction("RadioService", new {message = returnMessage});
        }

        #endregion

        #region Time Belt Seup

        /// <summary>
        /// Times the belt.
        /// </summary>
        /// <param name="selectedDescription">The selected description.</param>
        /// <returns></returns>
        
        [CheckUserLogin()]
        public ActionResult TimeBelt(string selectedDescription)
        {
            var timeBelt = this.lookUpService.GetTimeBeltListView(selectedDescription);
            return View(timeBelt);
        }


        /// <summary>
        /// Adds the time belt.
        /// </summary>
        /// <returns></returns>
        public ActionResult AddTimeBelt()
        {
            var timebelt = this.lookUpService.GetTimeBeltView();
            return PartialView(timebelt);
        }


        /// <summary>
        /// Adds the time belt.
        /// </summary>
        /// <param name="timeBeltView">The time belt view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">timeBeltView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult AddTimeBelt(TimeBeltView timeBeltView)
        {
            if (timeBeltView == null)
            {
                throw new ArgumentNullException(nameof(timeBeltView));
            }

            if (!ModelState.IsValid)
            {
                var timeBeltViewModel = this.lookUpService.GetTimeBeltView();
                return View("AddTimeBelt", timeBeltViewModel);
            }


            var timeBeltInfo = this.generalService.ProcessTimeBeltInfo(timeBeltView);
            if (!string.IsNullOrEmpty(timeBeltInfo))
            {
                var timeBeltModel = this.lookUpService.GetTimeBeltView();
                return View("AddTimeBelt", timeBeltModel);
            }

            var returnMessage = string.Format("TimeBelt Saved");
            return this.RedirectToAction("TimeBelt",
                new {message = returnMessage});
        }


        /// <summary>
        /// Edits the time belt.
        /// </summary>
        /// <param name="timeBeltId">The time belt identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">TimeBeltId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditTimeBelt(int timeBeltId)
        {
            if (timeBeltId <= 0)
            {
                throw new ArgumentNullException(nameof(timeBeltId));
            }

            var timeModel = this.lookUpService.GetSelectedTimeBeltByInfo(timeBeltId);
            return this.PartialView("EditTimeBelt", timeModel);
        }


        /// <summary>
        /// Edits the time belt.
        /// </summary>
        /// <param name="timeBeltView">The time belt view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">TimeBeltView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditTimeBelt(TimeBeltView timeBeltView)
        {
            if (timeBeltView == null)
            {
                throw new ArgumentNullException("TimeBeltView");
            }

            if (!ModelState.IsValid)
            {
                var timeBeltViewModel = this.lookUpService.GetTimeBeltView();

                return this.View("EditTimeBelt", timeBeltViewModel);
            }

            var timeEdit = this.generalService.UpdateTimeBeltInfo(timeBeltView);

            if (!string.IsNullOrEmpty(timeEdit))
            {
                var timeModel = this.lookUpService.GetColorView();
                return View("EditTimeBelt", timeModel);
            }

            var returnMessage = string.Format("Color Updated ");

            return this.RedirectToAction("TimeBelt",
                new {message = returnMessage});
        }


        /// <summary>
        /// Deletes the time belt.
        /// </summary>
        /// <param name="timeBeltId">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Id</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult DeleteTimeBelt(int timeBeltId)
        {
            if (timeBeltId <= 0)
            {
                throw new ArgumentNullException("timeBeltId");
            }

            var timeModel = this.lookUpService.GetTimeBeltById(timeBeltId, "");
            return this.PartialView("DeleteTimeBelt", timeModel);
        }

        /// <summary>
        /// Deletes the time belt.
        /// </summary>
        /// <param name="timeBeltId">The identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Id</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult DeleteTimeBelt(int timeBeltId, string btnSubmit)
        {
            if (timeBeltId <= 0)
            {
                throw new ArgumentOutOfRangeException("timeBeltId");
            }

            var apconEdit = this.generalService.ProcessDeleteTimingBelt(timeBeltId);
            var returnMessage = string.Format("TimeBelt Deleted");

            return this.RedirectToAction("TimeBelt",
                new {message = returnMessage});
        }

        #endregion

        #region Online Service

        //gets the user order details for admin
        /// <summary>
        /// Called when [user transaction].
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>

        [CheckUserLogin()]
        public ActionResult OnlineUserTransaction(int transactionId, int userId)
        {
            if (transactionId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(transactionId));
            }

            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId));
            }
            //update the message


            var order = this.onlineServices.GetOnlineUserTransaction(transactionId);
            return View("OnlineUserTransaction", order);
        }

        #endregion

        #region Print Service

        /// <summary>
        /// Prints the user transaction.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>

        [CheckUserLogin()]
        public ActionResult PrintUserTransaction(int transactionId)
        {
            if (transactionId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(transactionId));
            }
            //update the message


            var order = this.printService.GetUserPrintTransaction(transactionId);
            return View("PrintUserTransaction", order);
        }

        #endregion

        #region Branding Service

        /// <summary>
        /// Brandings the user transaction.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>

        [CheckUserLogin()]
        public ActionResult BrandingUserTransaction(int transactionId, int userId)
        {
            if (transactionId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(transactionId));
            }

            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId));
            }
            //update the message

            var order = this.brandingService.GetUserBrandingView(transactionId);
            return View("BrandingUserTransaction", order);
        }

        #endregion

        #region Tv Service

        /// <summary>
        /// Tvs the user transaction.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>

        [CheckUserLogin()]
        public ActionResult TvUserTransaction(int transactionId, int userId)
        {
            if (transactionId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(transactionId));
            }

            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId));
            }
            //update the message

            var order = this.tvServices.GetTvUserTransaction(transactionId, userId);
            return View("TvUserTransaction",order);
        }

        #endregion

        #region Order

        /// <summary>
        /// Orderses this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult Orders()
        {
            //Get All Orders 


            var order = this.orderServices.GetAllOrders();

            return View("Orders",order);
        }

        #endregion

        #region  Summary

        /// <summary>
        /// Summaries this instance.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">orderNumber</exception>
        /// <exception cref="ArgumentNullException">order</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult Summary(int orderId, int userId)
        {
            if (orderId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(orderId));
            }


            //var Order Information this  Order so that i can check that the order Belongs to this user
            var order = this.transactionService.GetOrderNumberInfo(userId, orderId);

            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }


            var model = this.transactionService.GetCartSummary(order, "");
            return View("Summary",model);
        }

        #endregion

        #region UserManagment

        /// <summary>
        /// Users the registration.
        /// </summary>
        /// <returns></returns>
        /// 
        [CheckUserLogin()]
        public ActionResult UserRegistration(string selectedEmailAddress, string selectedFirstName)
        {
            var userRegistrationList = this.accountService.GetUserRegistration(selectedEmailAddress, selectedFirstName);

            return this.View("UserRegistration", userRegistrationList);
        }

        /// <summary>
        /// Users the registration roles.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">email</exception>

        [CheckUserLogin()]
        public ActionResult UserRegistrationRoles(string email, string processingMessage)
        {


            var userRolesView = this.accountService.GetUserRolesbyEmail(email, processingMessage);

            return this.View("UserRegistrationRoles", userRolesView);
        }

        [HttpPost]
        [CheckUserLogin()]
        public ActionResult UserRegistrationRoles(UserRolesView userRolesView)
        {
            if (userRolesView == null)
            {
                throw new ArgumentNullException("userRolesView");
            }
            var createdUserInfo = (string)this.session.GetSessionValue(SessionKey.UserName);

            userRolesView.CreatedByName = createdUserInfo;
            var userRolesInfo = this.accountService.SaveUserRoles(userRolesView);
            if (!string.IsNullOrEmpty(userRolesInfo))
            {
                return this.RedirectToAction("UserRegistrationRoles", new { processingMessage = userRolesInfo, email = userRolesView.Email });

            }



            return this.RedirectToAction("UserRegistrationRoles", new { processingMessage = "User Roles Saved Successfully", email = userRolesView.Email });

        }



        [CheckUserLogin()]
        public ActionResult DeleteRoles(int userRolesId, string email)
        {
            if (userRolesId < 0)
            {
                throw new ArgumentNullException("userRolesId");
            }

            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            var userRolesInfo = this.accountService.DeleteUserRoles(email, userRolesId);



            return this.RedirectToAction("UserRegistrationRoles", new { processingMessage = "User Roles Deleted Successfully", email = email });
        }

        #endregion
    }
}