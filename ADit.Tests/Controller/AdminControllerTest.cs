//using AA.Infrastructure.Interfaces;
//using ADit.Controllers;
//using ADit.Domain.Models;
//using ADit.Interfaces;
//using NUnit.Framework;
//using Rhino.Mocks;
//using System;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.Routing;

//namespace ADit.Tests.Controller
//{
//    [TestFixture, NUnit.Framework.Category("Controllers")]
//    public class AdminControllerTest
//    {
//        /// <summary>
//        /// The look up service
//        /// </summary>
//        private ILookupService lookUpService;

//        /// <summary>
//        /// 
//        /// </summary>
//        private IGeneralRepository generalRepository;

//        private IOrderServices orderServices;
//        private ITransactionService transactionService;
//        /// <summary>
//        /// The HTTP context
//        /// </summary>
//        private HttpContextBase httpContext;

//        /// <summary>
//        /// The apcon view
//        /// </summary>
//        private IApconApprovalView apconView;

//        /// <summary>
//        /// 
//        /// </summary>
//        private IApconApprovalTypePriceListView apconPriceListView;

//        /// <summary>
//        /// The general service
//        /// </summary>
//        private IGeneralService generalService;

//        /// <summary>
//        /// The admin controller
//        /// </summary>
//        private AdministrationController adminController;

//        /// <summary>
//        /// The apcon ListView
//        /// </summary>
//        private IApconApprovalTypeListView apconListView;

//        /// <summary>
//        /// Apcon Price View
//        /// </summary>
//        private IApconApprovalTypePriceView apconPriceView;

//        /// <summary>
//        /// 
//        /// </summary>
//        private IColorListView colorList;

//        /// <summary>
//        /// 
//        /// </summary>
//        private ITimingListView timingList;

//        /// <summary>
//        /// 
//        /// </summary>
//        private IDurationTypeListView durationList;

//        /// <summary>
//        /// 
//        /// </summary>
//        private IDesignElementListView designElementList;

//        /// <summary>
//        /// 
//        /// </summary>
//        private IMaterialTypeListView materialTypeList;

//        /// <summary>
//        /// Material View
//        /// </summary>
//        private IMaterialTypeView materialView;

//        /// <summary>
//        /// Color View
//        /// </summary>
//        private IColorView colorView;

//        /// <summary>
//        /// Timing View
//        /// </summary>
//        private ITimingView timingView;

//        /// <summary>
//        /// Duration View
//        /// </summary>
//        private IDurationTypeView durationView;

//        /// <summary>
//        /// Design element price
//        /// </summary>
//        private IDesignElementPriceListView designElementPrice;

//        /// <summary>
//        /// Design Element Price View
//        /// </summary>
//        private IDesignElementPriceView designElementPriceView;


//        /// <summary>
//        /// Design View
//        /// </summary>
//        private IDesignElementView designView;

//        /// <summary>
//        /// Material Type timing list view
//        /// </summary>
//        private IMaterialTypeTimingListView materialTimingListView;

//        /// <summary>
//        /// Material Timing View
//        /// </summary>
//        private IMaterialTypeTimingView materialTimingView;

//        /// <summary>
//        /// Radio service price list view
//        /// </summary>
//        private IRadioServicePriceListView radioPriceList;

//        /// <summary>
//        /// Radio Price View
//        /// </summary>
//        private IRadioServicePriceList radioPriceView;

//        private ISessionStateService session;
//        private IRadioServices radioServices;
//        private ITvServices tvServices;
//        private IPrintService printService;
//        private IBrandingService brandingService;
//        private IOnlineServices onlineServices;
//        private IAccountService accountService;

//        [SetUp]
//        public void SetUp()
//        {

//            this.httpContext = MockRepository.GenerateStub<HttpContextBase>();
//            this.lookUpService = MockRepository.GenerateMock<ILookupService>();
//            this.generalService = MockRepository.GenerateMock<IGeneralService>();
//            this.generalRepository = MockRepository.GenerateMock<IGeneralRepository>();
//            this.session = MockRepository.GenerateMock<ISessionStateService>();
//            this.radioServices = MockRepository.GenerateMock<IRadioServices>();
//            this.tvServices = MockRepository.GenerateMock<ITvServices>();
//            this.accountService = MockRepository.GenerateMock<IAccountService>();

//            this.adminController = new AdministrationController(this.lookUpService, this.printService,this.generalService,
//                this.brandingService,this.onlineServices,this.orderServices,this.transactionService, this.tvServices);

//            this.adminController.ControllerContext =
//            new ControllerContext(this.httpContext, new RouteData(), this.adminController);

//            apconListView = new ApconApprovalTypeListView { SelectedApconApprovalTypeId = 1 };
//            apconView = new ApconApprovalView { ApconApprovalTypeId = 1, Description = "", ProcessingMessage = ""};
//            apconPriceListView = new ApconApprovalTypePriceListView { ProcessingMessage = "" };
//            apconPriceView = new ApconApprovalTypePriceView { ApconApprovalTypeId = 1 };
//            colorList = new ColorListView { SelectedColorId = 1 };
//            timingList = new TimingListView { SelectedTimingId = 1 };
//            durationList = new DurationTypeListView { SelectedDurationTypeId = "" };
//            designElementList = new DesignElementListView { SelectedDesignElementId = 1 };
//            materialTypeList = new MaterialTypeListView { SelectedMaterialTypeId = 1 };
//            materialView = new MaterialTypeView { MaterialTypeId = 1 };
//            colorView = new ColorView { ColorId = 1 };
//            timingView = new TimingView { TimingId = 1 };
//            durationView = new DurationTypeView { DurationTypeId = 1 };
//            designElementPrice = new DesignElementPriceListView { SelectedDesignElementId = 1 };
//            designElementPriceView = new DesignElementPriceView { DesignElementId = 1 };
//            designView = new DesignElementView { DesignElementId = 1 };
//            materialTimingListView = new MaterialTypeTimingListView { SelectedMaterialTypeId = 1 };
//            materialTimingView = new MaterialTypeTimingView { MaterialTypeId = 1 };
//            radioPriceList = new RadioServicePriceListView { SelectedMaterialTypeId = 1 };
//            radioPriceView = new RadioServicePriceListMain { Id = 1 };
//        }


//        [Test]
//        public void Apcon_Should_Call_GetApconApprovalTypeListView_From_LookUpService_Successfully()
//        {
//            //Setup
//            this.lookUpService.Expect(p => p.GetApconApprovalTypeListView(1, "", "")).IgnoreArguments().Return(apconListView);

//            //Act
//            this.adminController.Apcon(1, "","");

//            //Assert
//            this.lookUpService.VerifyAllExpectations();
//        }

//        [Test]
//        public void AddApconGet_Should_Call_GetApconView_From_LookupServices_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetApconView()).IgnoreArguments().Return(apconView);

//            //Act
//            this.adminController.AddApcon("");

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void AddApconPost_Shoould_Throw_Exception_When_View_Is_Null()
//        {
//            //Arrange
//            ApconApprovalView apconView = null;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.AddApcon(apconView));
//        }

//        [Test]
//        public void AddApconPost_Should_Return_Model_ErrorMessage_When_Input_Model_Is_Not_Valid()
//        {
//            //Arrange
//            var apconView = new ApconApprovalView();
//            this.adminController.ViewData.ModelState.AddModelError("ApconForm","Invalid Values");

//            //Act
//            var log = (ViewResult) this.adminController.AddApcon(apconView);

//            //Assert
//            Assert.AreEqual(1, log.ViewData.ModelState.Values.Count());


//        }


//        [Test]
//        public void AddApconPost_Should_Call_ProcessApconView_From_GeneralService_Successfully()
//        {
//            //Arrange
//            var ApconView = new ApconApprovalView();
//            this.generalService.Expect(p => p.ProcessApconView(ApconView)).IgnoreArguments().Return(null);

//            //Act
//            this.adminController.AddApcon(ApconView);

//            //Assert
//            this.generalService.VerifyAllExpectations();
//        }

        
//        [Test]
//        public void AddApconPost_Should_RedirectTo_Apcon_Home_When_All_Entries_Are_Okay()
//        {
//            //Arrange
//            var ApconView = new ApconApprovalView(); // input into controller

//            this.generalService.Stub(p => p.ProcessApconView(apconView)).Return("");

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.AddApcon(ApconView);

//            // Assert
//            Assert.AreEqual("Apcon", result.RouteValues["action"]);
//        }

//        [Test]
//        public void EditApconGet_Should_Throw_ArgumentNullException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.EditApcon(Id));
//        }

//        [Test]
//        public void EditApconGet_Should_GetApconApprovalById_From_LookUpService_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetApconApprovalById(1, "")).IgnoreArguments().Return(apconView);

//            //Act
//            this.adminController.EditApcon(1);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void EditApconGet_Should_Return_PartialView_EditApcon()
//        {
//            //Arrange
//            this.lookUpService.Stub(p => p.GetApconApprovalById(1, "")).IgnoreArguments().Return(apconView);

//            //Act
//            var log = (PartialViewResult)this.adminController.EditApcon(1);

//            //Assert
//            Assert.AreEqual(log.ViewName, "EditApcon");

//        }

//        [Test]
//        public void EditApconPost_Should_Return_ArgumentError_If_View_IsNull()
//        {
//            //Arrange
//            ApconApprovalView apconView = null;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.EditApcon(apconView));

//        }

//        [Test]
//        public void EditApconPost_Should_Return_View_If_ModelState_IsValid()
//        {
//            //Arrange
//            var apconView = new ApconApprovalView();
//            this.adminController.ViewData.ModelState.AddModelError("ApconForm", "Invalid Values");

//            //Act
//            var log = (ViewResult)this.adminController.AddApcon(apconView);

//            //Assert
//            Assert.AreEqual(1, log.ViewData.ModelState.Values.Count());

//        }
 
        
//        [Test]
//        public void EditApconPost_Shoul_Call_ProcessEditApcon_From_GeneralService_Successfully()
//        {
//            //Arrange
                       
//            this.generalService.Stub(p => p.ProcessEditApcon(apconView)).Return(string.Empty);

//            //Act
//            this.adminController.EditApcon(1);

//            //Assert
//            this.generalService.VerifyAllExpectations();

//        }


//        [Test]
//        public void DeleteApconGet_Should_Throw_ArgumentNullException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.DeleteApcon(Id));
//        }

//        [Test]
//        public void DeleteApconGet_Should_GetApconApprovalById_From_LookUpService_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetApconApprovalById(1, "")).IgnoreArguments().Return(apconView);

//            //Act
//            this.adminController.DeleteApcon(1);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void DeleteApconGet_Should_Return_PartialView_DeleteApcon()
//        {
//            //Arrange
//            this.lookUpService.Stub(p => p.GetApconApprovalById(1, "")).IgnoreArguments().Return(apconView);

//            //Act
//            var log = (PartialViewResult)this.adminController.DeleteApcon(1);

//            //Assert
//            Assert.AreEqual(log.ViewName, "DeleteApcon");

//        }

//        [Test]
//        public void DeleteApconPost_Should_Throw_ArgumentOutOfRangeException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentOutOfRangeException>(() => this.adminController.DeleteApcon(Id, ""));
//        }


//        [Test]
//        public void DeleteApconPost_Should_Call_ProcessDeleteApcon_From_GeneralService_Successfully()
//        {
//            //Arrange
//            int Id = 1;
//            this.generalService.Stub(p => p.ProcessDeleteApcon(Id)).IgnoreArguments().Return(string.Empty);

//            //Act
//            this.adminController.DeleteApcon(1,"");

//            //Assert
//            this.generalService.VerifyAllExpectations();

//        }

//        [Test]
//        public void DeleteApconPost_Should_RedirectTo_Apcon_Home_When_Delete_Entries_Are_Okay()
//        {
//            //Arrange
//            var ApconView = new ApconApprovalView(); // input into controller
//            int Id = 1;
//            this.generalService.Stub(p => p.ProcessDeleteApcon(Id)).Return("");

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.DeleteApcon(1, "");

//            // Assert
//            Assert.AreEqual("Apcon", result.RouteValues["action"]);
//        }


//        [Test]
//        public void ApconPrice_Should_Call_GetApconApprovalTypePriceViewModel_From_LookUpService_Successfully()
//        {
//            //Setup
//            this.lookUpService.Expect(p => p.GetApconApprovalTypePriceViewModel(1, 1, "")).IgnoreArguments().Return(apconPriceListView);

//            //Act
//            this.adminController.ApconPrice(1, 1, "");

//            //Assert
//            this.lookUpService.VerifyAllExpectations();
//        }


//        [Test]
//        public void ApconPrice_Should_Return_ApconPrice_View_Successfully()
//        {
//            //Setup
//            this.lookUpService.Stub(p => p.GetApconApprovalTypePriceViewModel(1, 1, "")).IgnoreArguments().Return(apconPriceListView);

//            //Act
//           var log = (ViewResult) this.adminController.ApconPrice(1, 1, "");

//            //Assert
//            Assert.IsNotNull(log);
//        }

//        [Test]
//        public void CreateApconPriceGet_Should_Call_GetApconApprovalTypePriceView_From_LookupServices_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetApconApprovalTypePriceView()).IgnoreArguments().Return(apconPriceView);

//            //Act
//            this.adminController.CreateApconPrice();

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void CreateApconPriceGet_Should_Return_ApconPrice_View_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetApconApprovalTypePriceView()).IgnoreArguments().Return(apconPriceView);

//            //Act
//            var log = (ViewResult) this.adminController.CreateApconPrice();

//            //Assert
//            Assert.IsNotNull(log);
//        }


//        [Test]
//        public void CreateApconPricePost_Should_Return_ArgumentNullException_When_View_IsNull()
//        {
//            //Arrange
//            ApconApprovalTypePriceView apconPrice = null;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.CreateApconPrice(apconPrice));
//        }

//        [Test]
//        public void CreateApconPricePost_Should_Return_View_If_ModelState_IsValid()
//        {
//            //Arrange
//            var apconView = new ApconApprovalTypePriceView();
//            this.adminController.ViewData.ModelState.AddModelError("ApconForm", "Invalid Values");

//            //Act
//            var log = (ViewResult)this.adminController.CreateApconPrice(apconView);

//            //Assert
//            Assert.AreEqual(1, log.ViewData.ModelState.Values.Count());

//        }

//        [Test]
//        public void CreateApconPricePost_Shoul_Call_ProcessApconApprovalTypePriceView_From_GeneralService_Successfully()
//        {
//            //Arrange
             
//            var apconView = new ApconApprovalTypePriceView();
//            this.generalService.Stub(p => p.ProcessApconApprovalTypePriceView(apconPriceView)).Return(string.Empty);

//            //Act
//            this.adminController.CreateApconPrice(apconView);

//            //Assert
//            this.generalService.VerifyAllExpectations();

//        }

//        [Test]
//        public void CreateApconPricePost_Should_Call_GetApconApprovalTypePriceView_From_LookupService_When_ProcessingMessage_IsNull()
//        {
//            //Arrange
//            var apconPriceView = new ApconApprovalTypePriceView();
//            IApconApprovalTypePriceView returnModel = new ApconApprovalTypePriceView();
//            returnModel.ProcessingMessage = "Error";
//            var message = returnModel.ProcessingMessage;

//            this.lookUpService.Stub(p => p.GetApconApprovalTypePriceView(apconPriceView, message))
//                .Return(returnModel);

//            //Act
//            this.adminController.CreateApconPrice(apconPriceView);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

         
//        [Test]
//        public void CreateApconPricePost_Should_RedirectTo_ApconPrice_Home_When_All_Entries_Are_Okay()
//        {
             
//            //Arrange
//            var apconPriceView = new ApconApprovalTypePriceView();
//            IApconApprovalTypePriceView returnModel = new ApconApprovalTypePriceView();
//            var message = returnModel.ProcessingMessage;

//            this.lookUpService.Stub(p => p.GetApconApprovalTypePriceView(apconPriceView, message))
//              .Return(returnModel);

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.CreateApconPrice(apconPriceView);

//            // Assert
//            Assert.AreEqual("ApconPrice", result.RouteValues["action"]);
//        }


//        [Test]
//        public void EditApconPriceGet_Should_Throw_ArgumentNullException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.EditApconPrice(Id));
//        }

//        [Test]
//        public void EditApconPriceGet_Should_GetApconApprovalTypePriceById_From_LookUpService_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetApconApprovalTypePriceById(1)).IgnoreArguments().Return(apconPriceView);

//            //Act
//            this.adminController.EditApconPrice(1);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void EditApconPriceGet_Should_Return_PartialView_EditApconPrice()
//        {
//            //Arrange
//            this.lookUpService.Stub(p => p.GetApconApprovalTypePriceById(1)).IgnoreArguments().Return(apconPriceView);

//            //Act
//            var log = (PartialViewResult)this.adminController.EditApconPrice(1);

//            //Assert
//            Assert.AreEqual(log.ViewName, "EditApconPrice");

//        }

//        [Test]
//        public void EditApconPricePost_Should_Return_ArgumentError_If_View_IsNull()
//        {
//            //Arrange
//            ApconApprovalTypePriceView apconView = null;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.EditApconPrice(apconView));

//        }

//        [Test]
//        public void EditApconPricePost_Should_Return_View_If_ModelState_IsValid()
//        {
//            //Arrange
//            var apconView = new ApconApprovalTypePriceView();
//            this.adminController.ViewData.ModelState.AddModelError("ApconPriceForm", "Invalid Values");

//            //Act
//            var log = (ViewResult)this.adminController.EditApconPrice(apconView);

//            //Assert
//            Assert.AreEqual(1, log.ViewData.ModelState.Values.Count());

//        }


//        [Test]
//        public void EditApconPricePost_Shoul_Call_ProcessEditApcon_From_GeneralService_Successfully()
//        {
//            //Arrange

//            this.generalService.Stub(p => p.ProcessEditApcon(apconView)).Return(string.Empty);

//            //Act
//            this.adminController.EditApcon(1);

//            //Assert
//            this.generalService.VerifyAllExpectations();

//        }


//        [Test]
//        public void EditApconPricePost_Should_Call_GetApconApprovalTypePriceView_From_LookupService_When_ProcessingMessage_IsNull()
//        {
//            //Arrange
//            var apconPriceView = new ApconApprovalTypePriceView();
//            IApconApprovalTypePriceView returnModel = new ApconApprovalTypePriceView();
//            returnModel.ProcessingMessage = "Error";
//            var message = returnModel.ProcessingMessage;

//            this.lookUpService.Stub(p => p.GetApconApprovalTypePriceView(apconPriceView, message))
//                .Return(returnModel);

//            //Act
//            this.adminController.EditApconPrice(apconPriceView);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }


//        [Test]
//        public void EditApconPricePost_Should_RedirectTo_ApconPrice_Home_When_All_Entries_Are_Okay()
//        {

//            //Arrange
//            var apconPriceView = new ApconApprovalTypePriceView();
//            IApconApprovalTypePriceView returnModel = new ApconApprovalTypePriceView();
//            var message = returnModel.ProcessingMessage;

//            this.lookUpService.Stub(p => p.GetApconApprovalTypePriceView(apconPriceView, message))
//              .Return(returnModel);

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.EditApconPrice(apconPriceView);

//            // Assert
//            Assert.AreEqual("ApconPrice", result.RouteValues["action"]);
//        }



//        [Test]
//        public void DeleteApconPriceGet_Should_Throw_ArgumentNullException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentOutOfRangeException>(() => this.adminController.DeleteApconPrice(Id));
//        }

//        [Test]
//        public void DeleteApconPriceGet_Should_GetDeleteApconApprovalTypePriceById_From_LookUpService_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetDeleteApconApprovalTypePriceById(1)).IgnoreArguments().Return(apconPriceView);

//            //Act
//            this.adminController.DeleteApconPrice(1);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void DeleteApconPriceGet_Should_Return_PartialView_DeleteApconPrice()
//        {
//            //Arrange
//            this.lookUpService.Stub(p => p.GetDeleteApconApprovalTypePriceById(1)).IgnoreArguments().Return(apconPriceView);

//            //Act
//            var log = (PartialViewResult)this.adminController.DeleteApconPrice(1);

//            //Assert
//            Assert.AreEqual(log.ViewName, "DeleteApconPrice");

//        }

//        [Test]
//        public void DeleteApconPricePost_Should_Throw_ArgumentOutOfRangeException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentOutOfRangeException>(() => this.adminController.DeleteApconPrice(Id, ""));
//        }


//        [Test]
//        public void DeleteApconPricePost_Should_Call_ProcessDeleteApconApprovalTypePrice_From_GeneralService_Successfully()
//        {
//            //Arrange
//            int Id = 1;
//            this.generalService.Stub(p => p.ProcessDeleteApconApprovalTypePrice(Id)).IgnoreArguments().Return(string.Empty);

//            //Act
//            this.adminController.DeleteApconPrice(1, "");

//            //Assert
//            this.generalService.VerifyAllExpectations();

//        }

//        [Test]
//        public void DeleteApconPricePost_Should_RedirectTo_ApconPrice_Home_When_Delete_Entries_Are_Okay()
//        {
//            //Arrange
//            var ApconView = new ApconApprovalView(); // input into controller
//            int Id = 1;
//            this.generalService.Stub(p => p.ProcessDeleteApconApprovalTypePrice(Id)).Return("");

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.DeleteApconPrice(1, "");

//            // Assert
//            Assert.AreEqual("ApconPrice", result.RouteValues["action"]);
//        }


//        [Test]
//        public void Color_Should_Call_GetColorListViewModel_From_LookUpService_Successfully()
//        {
//            //Setup
//            this.lookUpService.Expect(p => p.GetColorListViewModel(1, "", "")).IgnoreArguments().Return(colorList);

//            //Act
//            this.adminController.Color(1, "", "");

//            //Assert
//            this.lookUpService.VerifyAllExpectations();
//        }

//        [Test]
//        public void Color_Should_Return_ColorList_View_Successfully()
//        {
//            //Setup
//            this.lookUpService.Stub(p => p.GetColorListViewModel(1, "", "")).IgnoreArguments().Return(colorList);

//            //Act
//            var log = (ViewResult)this.adminController.Color(1, "", "");

//            //Assert
//            Assert.IsNotNull(log);
//        }

//        [Test]
//        public void Timing_Should_Call_GetTimingListView_From_LookUpService_Successfully()
//        {
//            //Setup
//            this.lookUpService.Expect(p => p.GetTimingListView(1, "", "")).IgnoreArguments().Return(timingList);

//            //Act
//            this.adminController.Timing(1, "", "");

//            //Assert
//            this.lookUpService.VerifyAllExpectations();
//        }

//        [Test]
//        public void Timing_Should_Return_ColorList_View_Successfully()
//        {
//            //Setup
//            this.lookUpService.Stub(p => p.GetTimingListView(1, "", "")).IgnoreArguments().Return(timingList);

//            //Act
//            var log = (ViewResult)this.adminController.Timing(1, "", "");

//            //Assert
//            Assert.IsNotNull(log);
//        }


//        [Test]
//        public void DurationType_Should_Call_GetDurationTypeListView_From_LookUpService_Successfully()
//        {
//            //Setup
//            this.lookUpService.Expect(p => p.GetDurationTypeListView("", "", "")).IgnoreArguments().Return(durationList);

//            //Act
//            this.adminController.DurationType("", "", "");

//            //Assert
//            this.lookUpService.VerifyAllExpectations();
//        }

//        [Test]
//        public void DurationType_Should_Return_DurationTypeList_View_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Stub(p => p.GetDurationTypeListView("", "", "")).IgnoreArguments().Return(durationList);

//            //Act
//            var log = (ViewResult) this.adminController.DurationType("", "", "");

//            //Assert
//            Assert.IsNotNull(log);
//        }


//        [Test]
//        public void DesignElement_Should_Call_GetDesignElementListView_From_LookUpService_Successfully()
//        {
//            //Setup
//            this.lookUpService.Expect(p => p.GetDesignElementListView(1, "", "")).IgnoreArguments().Return(designElementList);

//            //Act
//            this.adminController.DesignElement(1, "", "");

//            //Assert
//            this.lookUpService.VerifyAllExpectations();
//        }

//        [Test]
//        public void DesignElement_Should_Return_DesignList_View_Successfully()
//        {
//            //Setup
//            this.lookUpService.Expect(p => p.GetDesignElementListView(1, "", "")).IgnoreArguments().Return(designElementList);

//            //Act
//            var log = (ViewResult)this.adminController.DesignElement(1, "", "");

//            //Assert
//            Assert.IsNotNull(log);
//        }


//        [Test]
//        public void MaterialType_Should_Call_GetMaterialTypeListViewModel_From_LookUpService_Successfully()
//        {
//            //Setup
//            this.lookUpService.Expect(p => p.GetMaterialTypeListViewModel(1, "", "")).IgnoreArguments().Return(materialTypeList);

//            //Act
//            this.adminController.MaterialType(1, "", "");

//            //Assert
//            this.lookUpService.VerifyAllExpectations();
//        }

//        [Test]
//        public void MaterialType_Should_Return_MaterialList_View_Successfully()
//        {
//            //Setup
//            this.lookUpService.Stub(p => p.GetMaterialTypeListViewModel(1, "", "")).IgnoreArguments().Return(materialTypeList);

//            var result = (ViewResult)adminController.AddMaterialType();

//            //Assert
//            Assert.AreEqual(result.ViewName, "AddMaterialType");
//        }


//        [Test]
//        public void AddMaterialTypeGet_Should_Call_GetMaterialTypeView_From_LookupServices_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetMaterialTypeView()).IgnoreArguments().Return(materialView);

//            //Act
//            this.adminController.AddMaterialType();

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void AddMaterialTypeGet_Should_Return_AddMaterialType_View_Successfully()
//        {
//            //Setup
//            this.lookUpService.Stub(p => p.GetMaterialTypeListViewModel(1, "", "")).IgnoreArguments().Return(materialTypeList);

//            //Act
//            var log = this.adminController.MaterialType(1, "", "");

//            //Assert
//            Assert.IsNotNull(log);
//        }


//        [Test]
//        public void AddMaterialTypePost_Should_Throw_Exception_When_View_Is_Null()
//        {
//            //Arrange
//            MaterialTypeView materialView = null;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.AddMaterialType(materialView));
//        }


//        [Test]
//        public void AddMaterialTypePost_Should_Return_Model_ErrorMessage_When_Input_Model_Is_Not_Valid()
//        {
//            //Arrange
//            var materialView = new MaterialTypeView();
//            this.adminController.ViewData.ModelState.AddModelError("MaterialForm", "Invalid Values");

//            //Act
//            var log = (ViewResult)this.adminController.AddMaterialType(materialView);

//            //Assert
//            Assert.AreEqual(1, log.ViewData.ModelState.Values.Count());


//        }


//        [Test]
//        public void AddMaterialTypePost_Should_Call_ProcessMaterialTypeInfo_From_GeneralService_Successfully()
//        {
//            //Arrange
//            var MaterialView = new MaterialTypeView();
//            this.generalService.Expect(p => p.ProcessMaterialTypeInfo(materialView)).IgnoreArguments().Return("");

//            //Act
//            this.adminController.AddMaterialType(MaterialView);

//            //Assert
//            this.generalService.VerifyAllExpectations();
//        }


//        [Test]
//        public void AddMaterialTypePost_Should_Call_GetMaterialTypeView_From_LookupService_When_ProcessingMessage_IsNull()
//        {
//            //Arrange
//            var materialView = new MaterialTypeView();
//            IMaterialTypeView returnModel = new MaterialTypeView();
//            returnModel.ProcessingMessage = "Error";
//            var message = returnModel.ProcessingMessage;

//            this.lookUpService.Stub(p => p.GetMaterialTypeView(materialView, message))
//                .Return(returnModel);

//            //Act
//            this.adminController.AddMaterialType(materialView);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }


//        [Test]
//        public void AddMaterialTypePost_Should_RedirectTo_MaterialType_Home_When_All_Entries_Are_Okay()
//        {
//            //Arrange
//            var MaterialView = new MaterialTypeView(); // input into controller

//            this.generalService.Stub(p => p.ProcessMaterialTypeInfo(materialView)).Return("");

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.AddMaterialType(MaterialView);

//            // Assert
//            Assert.AreEqual("MaterialType", result.RouteValues["action"]);
//        }

//        [Test]
//        public void EditMaterialTypeGet_Should_Throw_ArgumentNullException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.EditMaterialType(Id));
//        }

//        [Test]
//        public void EditMaterialTypeGet_Should_GetMaterialTypeSelectedInfo_From_LookUpService_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetMaterialTypeSelectedInfo(1)).IgnoreArguments().Return(materialView);

//            //Act
//            this.adminController.EditMaterialType(1);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void EditMaterialTypeGet_Should_Return_PartialView_EditApcon()
//        {
//            //Arrange
//            this.lookUpService.Stub(p => p.GetMaterialTypeSelectedInfo(1)).IgnoreArguments().Return(materialView);

//            //Act
//            var log = (PartialViewResult)this.adminController.EditMaterialType(1);

//            //Assert
//            Assert.AreEqual(log.ViewName, "EditMaterialType");

//        }

//        [Test]
//        public void EditMaterialTypePost_Should_Return_ArgumentError_If_View_IsNull()
//        {
//            //Arrange
//            MaterialTypeView materialView = null;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.EditMaterialType(materialView));

//        }

//        [Test]
//        public void EditMaterialTypePost_Should_Return_View_If_ModelState_IsValid()
//        {
//            //Arrange
//            var MaterialView = new MaterialTypeView();
//            this.adminController.ViewData.ModelState.AddModelError("MaterialForm", "Invalid Values");

//            //Act
//            var log = (ViewResult)this.adminController.EditMaterialType(MaterialView);

//            //Assert
//            Assert.AreEqual(1, log.ViewData.ModelState.Values.Count());

//        }


//        [Test]
//        public void EditMaterialTypePost_Shoul_Call_UpdateMaterialTypeInfo_From_GeneralService_Successfully()
//        {
//            //Arrange
//            var MaterialView = new MaterialTypeView();
//            this.generalService.Stub(p => p.UpdateMaterialTypeInfo(MaterialView)).Return(string.Empty);

//            //Act
//            this.adminController.EditMaterialType(MaterialView);

//            //Assert
//            this.generalService.VerifyAllExpectations();

//        }


//        [Test]
//        public void EditMaterialTypePost_Should_Call_GetMaterialTypeView_From_LookupService_When_ProcessingMessage_IsNull()
//        {
//            //Arrange
//            var MaterialView = new MaterialTypeView();
//            IMaterialTypeView returnModel = new MaterialTypeView();
//            returnModel.ProcessingMessage = "Error";
//            var message = returnModel.ProcessingMessage;

//            this.lookUpService.Stub(p => p.GetMaterialTypeView(MaterialView, message))
//                .Return(returnModel);

//            //Act
//            this.adminController.EditMaterialType(MaterialView);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }


//        [Test]
//        public void EditMaterialTypePost_Should_RedirectTo_MaterialType_Home_When_All_Entries_Are_Okay()
//        {

//            //Arrange
//            var MaterialView = new MaterialTypeView();
//            IMaterialTypeView returnModel = new MaterialTypeView();
//            returnModel.ProcessingMessage = "Error";
//            var message = returnModel.ProcessingMessage;

//            this.lookUpService.Stub(p => p.GetMaterialTypeView(MaterialView, message))
//                .Return(returnModel);

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.EditMaterialType(MaterialView);

//            // Assert
//            Assert.AreEqual("MaterialType", result.RouteValues["action"]);
//        }


//        [Test]
//        public void DeleteMaterialTypeGet_Should_Throw_ArgumentOutOfRangeException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentOutOfRangeException>(() => this.adminController.DeleteMaterialType(Id));
//        }

//        [Test]
//        public void DeleteMaterialTypeGet_Should_GetMaterialTypeSelectedInfo_From_LookUpService_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetMaterialTypeSelectedInfo(1)).IgnoreArguments().Return(materialView);

//            //Act
//            this.adminController.DeleteMaterialType(1);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void DeleteMaterialTypeGet_Should_Return_PartialView_DeleteApcon()
//        {
//            //Arrange
//            this.lookUpService.Stub(p => p.GetMaterialTypeSelectedInfo(1)).IgnoreArguments().Return(materialView);

//            //Act
//            var log = (PartialViewResult)this.adminController.DeleteMaterialType(1);

//            //Assert
//            Assert.AreEqual(log.ViewName, "DeleteMaterialType");

//        }

//        [Test]
//        public void DeleteMaterialTypePost_Should_Throw_ArgumentOutOfRangeException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentOutOfRangeException>(() => this.adminController.DeleteMaterialType(Id, ""));
//        }


//        [Test]
//        public void DeleteMaterialTypePost_Should_Call_ProcessDeleteMaterialTypeInfo_From_GeneralService_Successfully()
//        {
//            //Arrange
//            int Id = 1;
//            this.generalService.Stub(p => p.ProcessDeleteMaterialTypeInfo(Id)).IgnoreArguments().Return(string.Empty);

//            //Act
//            this.adminController.DeleteMaterialType(1);

//            //Assert
//            this.generalService.VerifyAllExpectations();

//        }

//        [Test]
//        public void DeleteMaterialTypePost_Should_RedirectTo_MaterialType_Home_When_Delete_Entries_Are_Okay()
//        {
//            //Arrange
//            var MaterialView = new MaterialTypeView(); // input into controller
//            int Id = 1;
//            this.generalService.Stub(p => p.ProcessDeleteMaterialTypeInfo(Id)).Return("");

//            // Act
//            var result = (RedirectToRouteResult) this.adminController.DeleteMaterialType(1, "");

//            // Assert
//            Assert.AreEqual("MaterialType", result.RouteValues["action"]);
//        }

//        [Test]
//        public void EditColorGet_Should_Throw_ArgumentNullException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.EditColor(Id));
//        }

//        [Test]
//        public void EditColorGet_Should_GetSelectedColorByInfo_From_LookUpService_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetSelectedColorByInfo(1)).IgnoreArguments().Return(colorView);

//            //Act
//            this.adminController.EditColor(1);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void EditColorGet_Should_Return_PartialView_EditApcon()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetSelectedColorByInfo(1)).IgnoreArguments().Return(colorView);

//            //Act
//            var log = (PartialViewResult)this.adminController.EditColor(1);

//            //Assert
//            Assert.AreEqual(log.ViewName, "EditColor");

//        }

//        [Test]
//        public void EditColorPost_Should_Return_ArgumentError_If_View_IsNull()
//        {
//            //Arrange
//            ColorView ColorView = null;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.EditColor(ColorView));

//        }

//        [Test]
//        public void EditColorPost_Should_Return_View_If_ModelState_IsValid()
//        {
//            //Arrange
//            var coloView = new ColorView();
//            this.adminController.ViewData.ModelState.AddModelError("ColorForm", "Invalid Values");

//            //Act
//            var log = (ViewResult)this.adminController.EditColor(coloView);

//            //Assert
//            Assert.AreEqual(1, log.ViewData.ModelState.Values.Count());

//        }


//        [Test]
//        public void EditColorPost_Shoul_Call_UpdateColorInfo_From_GeneralService_Successfully()
//        {
//            //Arrange
//            var coloView = new ColorView();
//            this.generalService.Stub(p => p.UpdateColorInfo(coloView)).Return(string.Empty);

//            //Act
//            this.adminController.EditColor(coloView);

//            //Assert
//            this.generalService.VerifyAllExpectations();

//        }


//        [Test]
//        public void EditColorPost_Should_Call_GetColorView_From_LookupService_When_ProcessingMessage_IsNull()
//        {
//            //Arrange
//            var coloView = new ColorView();
//            IColorView returnModel = new ColorView();
//            returnModel.ProcessingMessage = "Error";
//            var message = returnModel.ProcessingMessage;

//            this.lookUpService.Stub(p => p.GetColorView(coloView, message))
//                .Return(returnModel);

//            //Act
//            this.adminController.EditColor(coloView);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }


//        [Test]
//        public void EditColorPost_Should_RedirectTo_Color_Home_When_All_Entries_Are_Okay()
//        {

//            //Arrange
//            var coloView = new ColorView();
//            IColorView returnModel = new ColorView();
//            returnModel.ProcessingMessage = "Error";
//            var message = returnModel.ProcessingMessage;

//            this.lookUpService.Stub(p => p.GetColorView(coloView, message))
//                .Return(returnModel);

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.EditColor(coloView);

//            // Assert
//            Assert.AreEqual("Color", result.RouteValues["action"]);
//        }


//        [Test]
//        public void EditTimingGet_Should_Throw_ArgumentNullException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.EditTiming(Id));
//        }

//        [Test]
//        public void EditTimingGet_Should_GetSelectedColorByInfo_From_LookUpService_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetSelectedTimingByInfo(1)).IgnoreArguments().Return(timingView);

//            //Act
//            this.adminController.EditTiming(1);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void EditTimingGet_Should_Return_PartialView_EditTiming()
//        {
//            //Arrange
//            this.lookUpService.Stub(p => p.GetSelectedTimingByInfo(1)).IgnoreArguments().Return(timingView);

//            //Act
//            var log = (PartialViewResult)this.adminController.EditTiming(1);

//            //Assert
//            Assert.AreEqual(log.ViewName, "EditTiming");

//        }

//        [Test]
//        public void EditTimingPost_Should_Return_ArgumentError_If_View_IsNull()
//        {
//            //Arrange
//            TimingView timinView = null;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.EditTiming(timinView));

//        }

//        [Test]
//        public void EditTimingPost_Should_Return_View_If_ModelState_IsValid()
//        {
//            //Arrange
//            var timinView = new TimingView();
//            this.adminController.ViewData.ModelState.AddModelError("TimingForm", "Invalid Values");

//            //Act
//            var log = (PartialViewResult)this.adminController.EditTiming(timinView);

//            //Assert
//            Assert.AreEqual(1, log.ViewData.ModelState.Values.Count());

//        }


//        [Test]
//        public void EditTimingPost_Shoul_Call_UpdateTimingInfo_From_GeneralService_Successfully()
//        {
//            //Arrange
//            var timinView = new TimingView();
//            this.generalService.Stub(p => p.UpdateTimingInfo(timinView)).Return(string.Empty);

//            //Act
//            this.adminController.EditTiming(timinView);

//            //Assert
//            this.generalService.VerifyAllExpectations();

//        }


//        [Test]
//        public void EditTimingPost_Should_Call_GetTimingView_From_LookupService_When_ProcessingMessage_IsNull()
//        {
//            //Arrange
//            var timinView = new TimingView();
//            ITimingView returnModel = new TimingView();
//            returnModel.ProcessingMessage = "Error";
//            var message = returnModel.ProcessingMessage;

//            this.lookUpService.Stub(p => p.GetTimingView(timinView, message))
//                .Return(returnModel);

//            //Act
//            this.adminController.EditTiming(timinView);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }


//        [Test]
//        public void EditTimingPost_Should_RedirectTo_Timing_Home_When_All_Entries_Are_Okay()
//        {


//            //Arrange
//            var timinView = new TimingView();
//            ITimingView returnModel = new TimingView();
//            returnModel.ProcessingMessage = "Error";
//            var message = returnModel.ProcessingMessage;

//            this.lookUpService.Stub(p => p.GetTimingView(timinView, message))
//                .Return(returnModel);

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.EditTiming(timinView);

//            // Assert
//            Assert.AreEqual("Timing", result.RouteValues["action"]);
//        }


//        [Test]
//        public void EditDurationTypeGet_Should_Throw_ArgumentNullException_When_Id_IsNull()
//        {
//            //Arrange
//            string Id = "";

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.EditDurationType(Id));
//        }

//        [Test]
//        public void EditDurationTypeGet_Should_GetSelectedDurationTypeInfo_From_LookUpService_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetSelectedDurationTypeInfo(durationView.DurationTypeCode)).IgnoreArguments().Return(durationView);

//            //Act
//            this.adminController.EditDurationType(durationView.DurationTypeCode);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void EditDurationTypeGet_Should_Return_PartialView_EditDurationType()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetSelectedDurationTypeInfo(durationView.DurationTypeCode)).IgnoreArguments().Return(durationView);

//            //Act
//            var log = (PartialViewResult)this.adminController.EditDurationType(durationView.DurationTypeCode);

//            //Assert
//            Assert.AreEqual(log.ViewName, "EditDurationType");

//        }

//        [Test]
//        public void EditDurationTypePost_Should_Return_ArgumentError_If_View_IsNull()
//        {
//            //Arrange
//            DurationTypeView durationView = null;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.EditDurationType(durationView));

//        }

//        [Test]
//        public void EditDurationTypePost_Should_Return_View_If_ModelState_IsValid()
//        {
//            //Arrange
//            var durationView = new DurationTypeView();
//            this.adminController.ViewData.ModelState.AddModelError("DurationForm", "Invalid Values");

//            //Act
//            var log = (PartialViewResult)this.adminController.EditDurationType(durationView);

//            //Assert
//            Assert.AreEqual(1, log.ViewData.ModelState.Values.Count());

//        }


//        [Test]
//        public void EditDurationTypePost_Should_Call_UpdateDurationTypeInfo_From_GeneralService_Successfully()
//        {
//            //Arrange
//            var durationView = new DurationTypeView();
//            this.generalService.Stub(p => p.UpdateDurationTypeInfo(durationView)).Return(string.Empty);

//            //Act
//            this.adminController.EditDurationType(durationView);

//            //Assert
//            this.generalService.VerifyAllExpectations();

//        }


//        [Test]
//        public void EditDurationTypePost_Should_Call_GetDurationTypeView_From_LookupService_When_ProcessingMessage_IsNull()
//        {
//            //Arrange
//            var durationView = new DurationTypeView();
//            IDurationTypeView returnModel = new DurationTypeView();
//            returnModel.ProcessingMessage = "Error";
//            var message = returnModel.ProcessingMessage;

//            this.lookUpService.Stub(p => p.GetDurationTypeView(durationView, message))
//                .Return(returnModel);

//            //Act
//            this.adminController.EditDurationType(durationView);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }


//        [Test]
//        public void EditDurationTypePost_Should_RedirectTo_DurationType_Home_When_All_Entries_Are_Okay()
//        {
//            //Arrange
//            var durationView = new DurationTypeView();
//            IDurationTypeView returnModel = new DurationTypeView();
//            returnModel.ProcessingMessage = "Error";
//            var message = returnModel.ProcessingMessage;

//            this.lookUpService.Stub(p => p.GetDurationTypeView(durationView, message))
//                .Return(returnModel);

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.EditDurationType(durationView);

//            // Assert
//            Assert.AreEqual("DurationType", result.RouteValues["action"]);
//        }


//        [Test]
//        public void AddTimingGet_Should_Call_GetTimingView_From_LookupServices_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetTimingView()).IgnoreArguments().Return(timingView);

//            //Act
//            this.adminController.AddTiming();

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void AddTimingGet_Should_Return_AddMaterialType_View_Successfully()
//        {
//            //Setup
//            this.lookUpService.Stub(p => p.GetTimingView()).IgnoreArguments().Return(timingView);

//            //Act
//            var log = (ViewResult) this.adminController.AddTiming();

//            //Assert
//            Assert.IsNotNull(log);
//        }


//        [Test]
//        public void AddTimingPost_Should_Throw_Exception_When_View_Is_Null()
//        {
//            //Arrange
//            TimingView timingView = null;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.AddTiming(timingView));
//        }


//        [Test]
//        public void AddTimingPost_Should_Return_Model_ErrorMessage_When_Input_Model_Is_Not_Valid()
//        {
//            //Arrange
//            var timingView = new TimingView();
//            this.adminController.ViewData.ModelState.AddModelError("TimingForm", "Invalid Values");

//            //Act
//            var log = (ViewResult)this.adminController.AddTiming(timingView);

//            //Assert
//            Assert.AreEqual(1, log.ViewData.ModelState.Values.Count());


//        }


//        [Test]
//        public void AddTimingPost_Should_Call_ProcessTimingIfo_From_GeneralService_Successfully()
//        {
//            //Arrange
//            var timingView = new TimingView();
//            this.generalService.Expect(p => p.ProcessTimingIfo(timingView)).IgnoreArguments().Return("");

//            //Act
//            this.adminController.AddTiming(timingView);

//            //Assert
//            this.generalService.VerifyAllExpectations();
//        }


//        [Test]
//        public void AddTimingPost_Should_Call_GetTimingView_From_LookupService_When_ProcessingMessage_IsNull()
//        {
//            //Arrange
//            var timingView = new TimingView();
//            ITimingView returnModel = new TimingView();
//            returnModel.ProcessingMessage = "Error";
//            var message = returnModel.ProcessingMessage;

//            this.lookUpService.Stub(p => p.GetTimingView(timingView, message))
//                .Return(returnModel);

//            //Act
//            this.adminController.AddTiming(timingView);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }


//        [Test]
//        public void AddTimingPost_Should_RedirectTo_Timing_Home_When_All_Entries_Are_Okay()
//        {
//            //Arrange
//            var timingView = new TimingView();
//            this.generalService.Stub(p => p.ProcessTimingIfo(timingView)).IgnoreArguments().Return("");

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.AddTiming(timingView);

//            // Assert
//            Assert.AreEqual("Timing", result.RouteValues["action"]);
//        }


//        [Test]
//        public void AddColorGet_Should_Call_GetColorView_From_LookupServices_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetColorView()).IgnoreArguments().Return(colorView);

//            //Act
//            this.adminController.AddColor();

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void AddColorGet_Should_Return_AddColor_View_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Stub(p => p.GetColorView()).IgnoreArguments().Return(colorView);

//            //Act
//            var log = (ViewResult)this.adminController.AddColor();

//            //Assert
//            Assert.IsNotNull(log);
//        }


//        [Test]
//        public void AddColorPost_Should_Throw_Exception_When_View_Is_Null()
//        {
//            //Arrange
//            ColorView colorView = null;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.AddColor(colorView));
//        }


//        [Test]
//        public void AddColorPost_Should_Return_Model_ErrorMessage_When_Input_Model_Is_Not_Valid()
//        {
//            //Arrange
//            var colorView = new ColorView();
//            this.adminController.ViewData.ModelState.AddModelError("ColorForm", "Invalid Values");

//            //Act
//            var log = (ViewResult)this.adminController.AddColor(colorView);

//            //Assert
//            Assert.AreEqual(1, log.ViewData.ModelState.Values.Count());


//        }


//        [Test]
//        public void AddColorPost_Should_Call_ProcessColorInfo_From_GeneralService_Successfully()
//        {
//            //Arrange
//            var colorView = new ColorView();
//            this.generalService.Expect(p => p.ProcessColorInfo(colorView)).IgnoreArguments().Return("");

//            //Act
//            this.adminController.AddColor(colorView);

//            //Assert
//            this.generalService.VerifyAllExpectations();
//        }


//        [Test]
//        public void AddColorPost_Should_Call_GetColorView_From_LookupService_When_ProcessingMessage_IsNull()
//        {
//            //Arrange
//            var colorView = new ColorView();
//            IColorView returnModel = new ColorView();
//            returnModel.ProcessingMessage = "Error";
//            var message = returnModel.ProcessingMessage;

//            this.lookUpService.Stub(p => p.GetColorView(colorView, message))
//                .Return(returnModel);

//            //Act
//            this.adminController.AddColor(colorView);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }


//        [Test]
//        public void AddColorPost_Should_RedirectTo_Color_Home_When_All_Entries_Are_Okay()
//        {
//            //Arrange
//            var colorView = new ColorView();
//            this.generalService.Stub(p => p.ProcessColorInfo(colorView)).IgnoreArguments().Return("");

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.AddColor(colorView);

//            // Assert
//            Assert.AreEqual("Color", result.RouteValues["action"]);
//        }


//        [Test]
//        public void AddDurationTypeGet_Should_Call_GetDurationTypeView_From_LookupServices_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetDurationTypeView()).IgnoreArguments().Return(durationView);

//            //Act
//            this.adminController.AddDurationType();

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void AddDurationTypeGet_Should_Return_AddDurationType_View_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Stub(p => p.GetDurationTypeView()).IgnoreArguments().Return(durationView);

//            //Act
//            var log = (ViewResult)this.adminController.AddDurationType();

//            //Assert
//            Assert.IsNotNull(log);
//        }


//        [Test]
//        public void AddDurationTypePost_Should_Throw_Exception_When_View_Is_Null()
//        {
//            //Arrange
//            DurationTypeView durationView = null;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.AddDurationType(durationView));
//        }


//        [Test]
//        public void AddDurationTypePost_Should_Return_Model_ErrorMessage_When_Input_Model_Is_Not_Valid()
//        {
//            //Arrange
//            var durationView = new DurationTypeView();
//            this.adminController.ViewData.ModelState.AddModelError("DurationForm", "Invalid Values");

//            //Act
//            var log = (ViewResult)this.adminController.AddDurationType(durationView);

//            //Assert
//            Assert.AreEqual(1, log.ViewData.ModelState.Values.Count());


//        }


//        [Test]
//        public void AddDurationTypePost_Should_Call_ProcessDurationTypeInfo_From_GeneralService_Successfully()
//        {
//            //Arrange
//            var durationView = new DurationTypeView();
//            this.generalService.Expect(p => p.ProcessDurationTypeInfo(durationView)).IgnoreArguments().Return("");

//            //Act
//            this.adminController.AddDurationType(durationView);

//            //Assert
//            this.generalService.VerifyAllExpectations();
//        }


//        [Test]
//        public void AddDurationTypePost_Should_Call_GetDurationTypeView_From_LookupService_When_ProcessingMessage_IsNull()
//        {
//            //Arrange
//            var durationView = new DurationTypeView();
//            IDurationTypeView returnModel = new DurationTypeView();
//            returnModel.ProcessingMessage = "Error";
//            var message = returnModel.ProcessingMessage;

//            this.lookUpService.Stub(p => p.GetDurationTypeView(durationView, message))
//                .Return(returnModel);

//            //Act
//            this.adminController.AddDurationType(durationView);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }


//        [Test]
//        public void AddDurationTypePost_Should_RedirectTo_DurationType_Home_When_All_Entries_Are_Okay()
//        {
//            //Arrange
//            var durationView = new DurationTypeView();
//            this.generalService.Stub(p => p.ProcessDurationTypeInfo(durationView)).IgnoreArguments().Return("");

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.AddDurationType(durationView);

//            // Assert
//            Assert.AreEqual("DurationType", result.RouteValues["action"]);
//        }


//        [Test]
//        public void DeleteTimingGet_Should_Throw_ArgumentOutOfRangeException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentOutOfRangeException>(() => this.adminController.DeleteTiming(Id));
//        }

//        [Test]
//        public void DeleteTimingGet_Should_GetSelectedTimingByInfo_From_LookUpService_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetSelectedTimingByInfo(1)).IgnoreArguments().Return(timingView);

//            //Act
//            this.adminController.DeleteTiming(1);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void DeleteTimingGet_Should_Return_PartialView_DeleteTiming()
//        {
//            //Arrange
//            this.lookUpService.Stub(p => p.GetSelectedTimingByInfo(1)).IgnoreArguments().Return(timingView);

//            //Act
//            var log = (PartialViewResult)this.adminController.DeleteTiming(1);

//            //Assert
//            Assert.AreEqual(log.ViewName, "DeleteTiming");

//        }

//        [Test]
//        public void DeleteTimingPost_Should_Throw_ArgumentOutOfRangeException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentOutOfRangeException>(() => this.adminController.DeleteMaterialType(Id, ""));
//        }


//        [Test]
//        public void DeleteTimingPost_Should_Call_ProcessDeleteTimingInfo_From_GeneralService_Successfully()
//        {
//            //Arrange
//            int Id = 1;
//            this.generalService.Stub(p => p.ProcessDeleteTimingInfo(Id)).IgnoreArguments().Return(string.Empty);

//            //Act
//            this.adminController.DeleteTiming(1,"");

//            //Assert
//            this.generalService.VerifyAllExpectations();

//        }

//        [Test]
//        public void DeleteTimingPost_Should_RedirectTo_Timing_Home_When_Delete_Entries_Are_Okay()
//        {
//            //Arrange
//            var timingView = new TimingView(); // input into controller
//            int Id = 1;
//            this.generalService.Stub(p => p.ProcessDeleteTimingInfo(Id)).IgnoreArguments().Return(string.Empty);

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.DeleteTiming(1, ""); 
            
//            // Assert
//            Assert.AreEqual("Timing", result.RouteValues["action"]);
//        }


//        [Test]
//        public void DeleteDurationTypeGet_Should_Throw_ArgumentOutOfRangeException_When_Id_Less_Than_One()
//        {
//            //Arrange
//           string Id = "";

//            //Assert
//            Assert.Throws<ArgumentOutOfRangeException>(() => this.adminController.DeleteDurationType(Id));
//        }

//        [Test]
//        public void DeleteDurationTypeGet_Should_GetSelectedTimingByInfo_From_LookUpService_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetSelectedDurationTypeInfo(durationView.DurationTypeCode))
//                .IgnoreArguments().Return(durationView);

//            //Act
//            this.adminController.DeleteDurationType(durationView.DurationTypeCode);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void DeleteDurationTypeGet_Should_Return_PartialView_DeleteDurationType()
//        {
//            //Arrange
//            this.lookUpService.Stub(p => p.GetSelectedDurationTypeInfo(durationView.DurationTypeCode))
//                .IgnoreArguments().Return(durationView);

//            //Act
//            var log = (PartialViewResult)this.adminController.DeleteDurationType(durationView.DurationTypeCode);

//            //Assert
//            Assert.AreEqual(log.ViewName, "DeleteDurationType");

//        }

//        [Test]
//        public void DeleteDurationTypePost_Should_Throw_ArgumentOutOfRangeException_When_Id_IsNull()
//        {
//            //Arrange
//            string Id = "";

//            //Assert
//            Assert.Throws<ArgumentOutOfRangeException>(() => this.adminController.DeleteDurationType(Id, ""));
//        }


//        [Test]
//        public void DeleteDurationTypePost_Should_Call_ProcessDeleteDurationTypeInfo_From_GeneralService_Successfully()
//        {
//            //Arrange
//            int Id = 1;
//            this.generalService.Expect(p => p.ProcessDeleteDurationTypeInfo(durationView.DurationTypeCode)).IgnoreArguments().Return(string.Empty);

//            //Act
//            this.adminController.DeleteDurationType(durationView.DurationTypeCode, "");

//            //Assert
//            this.generalService.VerifyAllExpectations();

//        }

//        [Test]
//        public void DeleteDurationTypePost_Should_RedirectTo_DurationType_Home_When_Delete_Entries_Are_Okay()
//        {
//            //Arrange
             
//            this.generalService.Stub(p => p.ProcessDeleteDurationTypeInfo(durationView.DurationTypeCode)).IgnoreArguments().Return(string.Empty);

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.DeleteDurationType(durationView.DurationTypeCode, "");

//            // Assert
//            Assert.AreEqual("DurationType", result.RouteValues["action"]);
//        }


//        [Test]
//        public void DesignElementPrice_Should_Call_GeDesignElementPriceViewModel_From_LookUpService_Successfully()
//        {
//            //Setup
//            this.lookUpService.Expect(p => p.GeDesignElementPriceViewModel("",1, "", ""))
//                .IgnoreArguments().Return(designElementPrice);

//            //Act
//            this.adminController.DesignElementPrice("", 1, "", "");

//            //Assert
//            this.lookUpService.VerifyAllExpectations();
//        }


//        [Test]
//        public void DesignElementPrice_Should_Return_esignElementPrice_View_Successfully()
//        {
//            //Setup
//            this.lookUpService.Stub(p => p.GeDesignElementPriceViewModel("", 1, "", ""))
//                .IgnoreArguments().Return(designElementPrice);

//            //Act
//            var log = (ViewResult)this.adminController.DesignElementPrice("", 1, "", "");

//            //Assert
//            Assert.IsNotNull(log);
//        }



//        [Test]
//        public void EditDesignElementPriceGet_Should_Throw_ArgumentOutOfRangeException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentOutOfRangeException>(() => this.adminController.EditDesignElementPrice(Id));
//        }

//        [Test]
//        public void EditDesignElementPriceGet_Should_GetDeleteDesignElementPriceById_From_LookUpService_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetDeleteDesignElementPriceById(1))
//                .IgnoreArguments().Return(designElementPriceView);

//            //Act
//            this.adminController.EditDesignElementPrice(1);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void EditDesignElementPriceGet_Should_Return_PartialView_EditDesignElementPrice()
//        {
//            //Arrange
//            this.lookUpService.Stub(p => p.GetDeleteDesignElementPriceById(1))
//                 .IgnoreArguments().Return(designElementPriceView);

//            //Act
//            var log = (PartialViewResult)this.adminController.EditDesignElementPrice(1);

//            //Assert
//            Assert.AreEqual(log.ViewName, "EditDesignElementPrice");

//        }

//        [Test]
//        public void EditDesignElementPricePost_Should_Return_ArgumentOutOfRangeException_If_View_IsNull()
//        {
//            //Arrange
//            DesignElementPriceView designView = null;

//            //Assert
//            Assert.Throws<ArgumentException>(() => this.adminController.EditDesignElementPrice(designView));

//        }

//        [Test]
//        public void EditDesignElementPricePost_Should_Return_View_If_ModelState_IsValid()
//        {
//            //Arrange
//            var designView = new DesignElementPriceView();
//            this.adminController.ViewData.ModelState.AddModelError("DesignElementForm", "Invalid Values");

//            //Act
//            var log = (ViewResult)this.adminController.EditDesignElementPrice(designView);

//            //Assert
//            Assert.AreEqual(1, log.ViewData.ModelState.Values.Count());

//        }


//        [Test]
//        public void EditDesignElementPricePost_Shoul_Call_ProcessEditElementPriceInfo_From_GeneralService_Successfully()
//        {
//            //Arrange
//            var designView = new DesignElementPriceView();
//            this.generalService.Stub(p => p.ProcessEditElementPriceInfo(designElementPriceView)).Return(string.Empty);

//            //Act
//            this.adminController.EditDesignElementPrice(designView);

//            //Assert
//            this.generalService.VerifyAllExpectations();

//        }
         
//        [Test]
//        public void EditDesignElementPricePost_Should_RedirectTo_DesignElementPrice_Home_When_All_Entries_Are_Okay()
//        {

//            //Arrange
//            var designPriceView = new DesignElementPriceView();
//            IDesignElementPriceView returnModel = new DesignElementPriceView();
//            var message = returnModel.ProcessingMessage;

           
//            this.generalService.Stub(p => p.ProcessEditElementPriceInfo(designPriceView)).Return(string.Empty);

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.EditDesignElementPrice(designPriceView);

//            // Assert
//            Assert.AreEqual("DesignElementPrice", result.RouteValues["action"]);
//        }


//        [Test]
//        public void DeleteDesignElementPriceGet_Should_Throw_ArgumentNullException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentOutOfRangeException>(() => this.adminController.DeleteDesignElementPrice(Id));
//        }

//        [Test]
//        public void DeleteDesignElementPriceGet_Should_GetDeleteDesignElementPriceById_From_LookUpService_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetDeleteDesignElementPriceById(1))
//                .IgnoreArguments().Return(designElementPriceView);

//            //Act
//            this.adminController.DeleteDesignElementPrice(1);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void DeleteDesignElementPriceGet_Should_Return_PartialView_DeleteDesignElementPrice()
//        {
//            //Arrange
//            this.lookUpService.Stub(p => p.GetDeleteDesignElementPriceById(1)).IgnoreArguments().Return(designElementPriceView);

//            //Act
//            var log = (PartialViewResult)this.adminController.DeleteDesignElementPrice(1);

//            //Assert
//            Assert.AreEqual(log.ViewName, "DeleteDesignElementPrice");

//        }

//        [Test]
//        public void DeleteDesignElementPricePost_Should_Throw_ArgumentOutOfRangeException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentOutOfRangeException>(() => this.adminController.DeleteDesignElementPrice(Id, ""));
//        }


//        [Test]
//        public void DeleteDesignElementPricePost_Should_Call_ProcessDeleteDesignElementPriceInfo_From_GeneralService_Successfully()
//        {
//            //Arrange
//            int Id = 1;
//            this.generalService.Expect(p => p.ProcessDeleteDesignElementPriceInfo(Id)).IgnoreArguments().Return(string.Empty);

//            //Act
//            this.adminController.DeleteDesignElementPrice(Id, "");

//            //Assert
//            this.generalService.VerifyAllExpectations();

//        }

//        [Test]
//        public void DeleteDesignElementPricePost_Should_RedirectTo_DesignElementPrice_Home_When_Delete_Entries_Are_Okay()
//        {
//            //Arrange
//            var ApconView = new ApconApprovalView(); // input into controller
//            int Id = 1;
//            this.generalService.Stub(p => p.ProcessDeleteDesignElementPriceInfo(Id))
//                .IgnoreArguments().Return(string.Empty);

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.DeleteDesignElementPrice(Id, "");

//            // Assert
//            Assert.AreEqual("DesignElementPrice", result.RouteValues["action"]);
//        }


//        [Test]
//        public void AddDesignElementGet_Should_Call_GetDesignElementViewModel_From_LookupServices_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetDesignElementViewModel()).IgnoreArguments().Return(designView);

//            //Act
//            this.adminController.AddDesignElement();

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void AddDesignElementGet_Should_Return_AddDesignElement_View_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Stub(p => p.GetDesignElementViewModel()).IgnoreArguments().Return(designView);

//            //Act
//            var log = (ViewResult)this.adminController.AddDesignElement();

//            //Assert
//            Assert.IsNotNull(log);
//        }


//        [Test]
//        public void AddDesignElementPost_Should_Throw_Exception_When_View_Is_Null()
//        {
//            //Arrange
//            DesignElementView designView = null;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.AddDesignElement(designView));
//        }


       
//        [Test]
//        public void AddDesignElementPost_Should_Call_GetDesignElementViewModel_From_GeneralService_Successfully()
//        {
//            //Arrange
//            var designView = new DesignElementView();
//            this.generalService.Expect(p => p.GetDesignElementViewModel(designView)).IgnoreArguments().Return("");

//            //Act
//            this.adminController.AddDesignElement(designView);

//            //Assert
//            this.generalService.VerifyAllExpectations();
//        }

//        [Test]
//        public void AddDesignElementPost_Should_RedirectTo_Color_Home_When_All_Entries_Are_Okay()
//        {
//            //Arrange
//            var designView = new DesignElementView();
//            this.generalService.Stub(p => p.GetDesignElementViewModel(designView)).IgnoreArguments().Return("");

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.AddDesignElement(designView);

//            // Assert
//            Assert.AreEqual("DesignElement", result.RouteValues["action"]);
//        }


//        [Test]
//        public void EditDesignElementGet_Should_Throw_ArgumentNullException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            var DesignView = new DesignElementView();
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.EditDesignElement(DesignView,Id));
//        }

//        [Test]
//        public void EditDesignElementGet_Should_GetSelectedColorByInfo_From_LookUpService_Successfully()
//        {
//            //Arrange
//            var DesignView = new DesignElementView();
//            this.lookUpService.Expect(p => p.GetEditDesignElement(DesignView, 1)).IgnoreArguments().Return(designView);

//            //Act
//            this.adminController.EditDesignElement(DesignView, 1);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void EditDesignElementGet_Should_Return_PartialView_EditDesignElement()
//        {
//            //Arrange
//            var DesignView = new DesignElementView();
//            this.lookUpService.Stub(p => p.GetEditDesignElement(DesignView, 1)).IgnoreArguments().Return(designView);

//            //Act
//            var log = (PartialViewResult)this.adminController.EditDesignElement(DesignView, 1);

//            //Assert
//            Assert.AreEqual(log.ViewName, "EditDesignElement");

//        }

//        [Test]
//        public void EditDesignElementPost_Should_Return_ArgumentError_If_View_IsNull()
//        {
//            //Arrange
//            DesignElementView DesignView = null;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.EditDesignElement(DesignView));

//        }

//        [Test]
//        public void EditDesignElementPost_Should_Return_View_If_ModelState_IsValid()
//        {
//            //Arrange
//            var DesignView = new DesignElementView();
//            this.adminController.ViewData.ModelState.AddModelError("EditDesignElement", "Invalid Values");

//            //Act
//            var log = (ViewResult)this.adminController.EditDesignElement(DesignView);

//            //Assert
//            Assert.AreEqual(1, log.ViewData.ModelState.Values.Count());

//        }


//        [Test]
//        public void EditDesignElementPost_Shoul_Call_GetEditDesignElement_From_GeneralService_Successfully()
//        {
//            //Arrange
//            var DesignView = new DesignElementView();
//            this.generalService.Expect(p => p.GetEditDesignElement(DesignView)).Return(string.Empty);

//            //Act
//            this.adminController.EditDesignElement(DesignView);

//            //Assert
//            this.generalService.VerifyAllExpectations();

//        }

//        [Test]
//        public void EditDesignElementPost_Should_RedirectTo_DesignElement_Home_When_All_Entries_Are_Okay()
//        {
//            //Arrange
//            var DesignView = new DesignElementView();
//            IDesignElementView returnModel = new DesignElementView();
//            returnModel.ProcessingMessage = "Error";
//            var message = returnModel.ProcessingMessage;

//            this.generalService.Stub(p => p.GetEditDesignElement(DesignView)).Return(string.Empty);

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.EditDesignElement(DesignView);

//            // Assert
//            Assert.AreEqual("DesignElement", result.RouteValues["action"]);
//        }


//        [Test]
//        public void DeleteDesignElementGet_Should_Throw_ArgumentOutOfRangeException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentOutOfRangeException>(() => this.adminController.DeleteDesignElement(Id));
//        }

//        [Test]
//        public void DeleteDesignElementGet_Should_GetDeleteDesignElement_From_LookUpService_Successfully()
//        {
//            //Arrange
//            var DesignView = new DesignElementView();
//            this.lookUpService.Expect(p => p.GetDeleteDesignElement(DesignView, 1)).IgnoreArguments().Return(designView);

//            //Act
//            this.adminController.DeleteDesignElement(DesignView, 1);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void DeleteDesignElementGet_Should_Return_PartialView_DeleteDesignElement()
//        {
//            //Arrange
//            var DesignView = new DesignElementView();
//            this.lookUpService.Stub(p => p.GetDeleteDesignElement(DesignView, 1)).IgnoreArguments().Return(designView);

//            //Act
//            var log = (PartialViewResult)this.adminController.DeleteDesignElement(DesignView, 1);

//            //Assert
//            Assert.AreEqual(log.ViewName, "DeleteDesignElement");

//        }

//        [Test]
//        public void DeleteDesignElementPost_Should_Throw_ArgumentOutOfRangeException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentOutOfRangeException>(() => this.adminController.DeleteDesignElement(Id));
//        }


//        [Test]
//        public void DeleteDesignElementPost_Should_Call_ProcessDeleteTimingInfo_From_GeneralService_Successfully()
//        {
//            //Arrange
//            int Id = 1;
//            this.generalService.Expect(p => p.GetDeleteDesignElement(Id)).IgnoreArguments().Return(string.Empty);

//            //Act
//            this.adminController.DeleteDesignElement(1);

//            //Assert
//            this.generalService.VerifyAllExpectations();

//        }

//        [Test]
//        public void DeleteDesignElementPost_Should_RedirectTo_DesignElement_Home_When_Delete_Entries_Are_Okay()
//        {
//            //Arrange
//            var timingView = new TimingView(); // input into controller
//            int Id = 1;
//            this.generalService.Stub(p => p.GetDeleteDesignElement(Id)).IgnoreArguments().Return(string.Empty);

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.DeleteDesignElement(1);

//            // Assert
//            Assert.AreEqual("DesignElement", result.RouteValues["action"]);
//        }


//        [Test]
//        public void CreateDesignElementPriceGet_Should_Call_GetDesignElementPriceView_From_LookupServices_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetDesignElementPriceView()).IgnoreArguments().Return(designElementPriceView);

//            //Act
//            this.adminController.CreateDesignElementPrice();

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void CreateDesignElementPriceGet_Should_Return_CreateDesignElementPrice_View_Successfully()
//        {
//            //Setup
//            this.lookUpService.Stub(p => p.GetDesignElementPriceView()).IgnoreArguments().Return(designElementPriceView);

//            //Act
//            var log = (ViewResult)this.adminController.CreateDesignElementPrice();

//            //Assert
//            Assert.IsNotNull(log);
//        }


//        [Test]
//        public void CreateDesignElementPricePost_Should_Throw_Exception_When_View_Is_Null()
//        {
//            //Arrange
//            DesignElementPriceView priceview = null;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.CreateDesignElementPrice(priceview));
//        }


//        [Test]
//        public void CreateDesignElementPricePost_Should_Return_Model_ErrorMessage_When_Input_Model_Is_Not_Valid()
//        {
//            //Arrange
//            var priceview = new DesignElementPriceView();
//            this.adminController.ViewData.ModelState.AddModelError("DesignPriceForm", "Invalid Values");

//            //Act
//            var log = (ViewResult)this.adminController.CreateDesignElementPrice(priceview);

//            //Assert
//            Assert.AreEqual(1, log.ViewData.ModelState.Values.Count());


//        }


//        [Test]
//        public void CreateDesignElementPricePost_Should_Call_ProcessDesignElementPriceInfo_From_GeneralService_Successfully()
//        {
//            //Arrange
//            var priceview = new DesignElementPriceView();
//            this.generalService.Expect(p => p.ProcessDesignElementPriceInfo(priceview)).IgnoreArguments().Return("");

//            //Act
//            this.adminController.CreateDesignElementPrice(priceview);

//            //Assert
//            this.generalService.VerifyAllExpectations();
//        }


//        [Test]
//        public void CreateDesignElementPricePost_Should_Call_GetDesignElementPriceView_From_LookupService_When_ProcessingMessage_IsNull()
//        {
//            //Arrange
//            var desigView = new DesignElementPriceView();
//            IDesignElementPriceView returnModel = new DesignElementPriceView();
//            returnModel.ProcessingMessage = "Error";
//            var message = returnModel.ProcessingMessage;

//            this.lookUpService.Stub(p => p.GetDesignElementPriceView(desigView, message))
//                .Return(returnModel);

//            //Act  
//            this.adminController.CreateDesignElementPrice(desigView);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }


//        [Test]
//        public void CreateDesignElementPricePost_Should_RedirectTo_DesignElementPrice_Home_When_All_Entries_Are_Okay()
//        {
//            //Arrange
//            var priceview = new DesignElementPriceView();
//            this.generalService.Stub(p => p.ProcessDesignElementPriceInfo(priceview)).IgnoreArguments().Return("");

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.CreateDesignElementPrice(priceview);

//            // Assert
//            Assert.AreEqual("DesignElementPrice", result.RouteValues["action"]);
//        }


//        [Test]
//        public void MaterialTiming_Should_Call_GetMaterialTypeTimingListView_From_LookUpService_Successfully()
//        {
//            //Setup
//            this.lookUpService.Expect(p => p.GetMaterialTypeTimingListView(1, 1, "", "")).IgnoreArguments().Return(materialTimingListView);

//            //Act
//            this.adminController.MaterialTiming(1, 1, "", "");

//            //Assert
//            this.lookUpService.VerifyAllExpectations();
//        }


//        [Test]
//        public void MaterialTiming_Should_Return_MaterialTiming_View_Successfully()
//        {
//            //Setup
//            this.lookUpService.Stub(p => p.GetMaterialTypeTimingListView(1, 1, "", "")).IgnoreArguments().Return(materialTimingListView);

//            //Act
//            var log = (ViewResult)this.adminController.MaterialTiming(1, 1, "", "");

//            //Assert
//            Assert.IsNotNull(log);
//        }

//        [Test]
//        public void CreateMaterialTimingGet_Should_Call_GetMaterialTypeTimingView_From_LookupServices_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetMaterialTypeTimingView()).IgnoreArguments().Return(materialTimingView);

//            //Act
//            this.adminController.CreateMaterialTiming();

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void CreateMaterialTimingGet_Should_Return_CreateMaterialTiming_View_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetApconApprovalTypePriceView()).IgnoreArguments().Return(apconPriceView);

//            //Act
//            var log = (ViewResult)this.adminController.CreateMaterialTiming();

//            //Assert
//            Assert.IsNotNull(log);
//        }


//        [Test]
//        public void CreateMaterialTimingPost_Should_Return_ArgumentNullException_When_View_IsNull()
//        {
//            //Arrange
//            MaterialTypeTimingView materialtimingview = null;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.CreateMaterialTiming(materialtimingview));
//        }

//        [Test]
//        public void CreateMaterialTimingPost_Should_Return_View_If_ModelState_IsValid()
//        {
//            //Arrange
//            var materialtimingview = new MaterialTypeTimingView();
//            this.adminController.ViewData.ModelState.AddModelError("MaterialTimingForm", "Invalid Values");

//            //Act
//            var log = (ViewResult)this.adminController.CreateMaterialTiming(materialtimingview);

//            //Assert
//            Assert.AreEqual(1, log.ViewData.ModelState.Values.Count());

//        }

//        [Test]
//        public void CreateMaterialTimingPost_Shoul_Call_ProcessMaterialTypeTimingInfo_From_GeneralService_Successfully()
//        {
//            //Arrange

//            var materialtimingview = new MaterialTypeTimingView();
//            this.generalService.Stub(p => p.ProcessMaterialTypeTimingInfo(materialtimingview)).Return(string.Empty);

//            //Act
//            this.adminController.CreateMaterialTiming(materialtimingview);

//            //Assert
//            this.generalService.VerifyAllExpectations();

//        }

//        [Test]
//        public void CreateMaterialTimingPost_Should_Call_GetMaterialTypeTimingView_From_LookupService_When_ProcessingMessage_IsNull()
//        {
//            //Arrange
//            var materialtimingview = new MaterialTypeTimingView();
//            IMaterialTypeTimingView returnModel = new MaterialTypeTimingView();
//            returnModel.ProcessingMessage = "Error";
//            var message = returnModel.ProcessingMessage;

//            this.lookUpService.Stub(p => p.GetMaterialTypeTimingView(materialtimingview, message))
//                .Return(returnModel);

//            //Act
//            this.adminController.CreateMaterialTiming(materialtimingview);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }


//        [Test]
//        public void CreateMaterialTimingPost_Should_RedirectTo_CreateMaterialTiming_Home_When_All_Entries_Are_Okay()
//        {

//            //Arrange
//            var materialtimingview = new MaterialTypeTimingView();
//            IMaterialTypeTimingView returnModel = new MaterialTypeTimingView();
//            returnModel.ProcessingMessage = "Error";
//            var message = returnModel.ProcessingMessage;

//            this.lookUpService.Stub(p => p.GetMaterialTypeTimingView(materialtimingview, message))
//                .Return(returnModel);

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.CreateMaterialTiming(materialtimingview);

//            // Assert
//            Assert.AreEqual("MaterialTiming", result.RouteValues["action"]);
//        }

//        [Test]
//        public void EditMaterialTimingGet_Should_Throw_ArgumentNullException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.EditMaterialTiming(Id));
//        }

//        [Test]
//        public void EditMaterialTimingGet_Should_GetEditMaterialTypeTimingById_From_LookUpService_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetEditMaterialTypeTimingById(1, "")).IgnoreArguments().Return(materialTimingView);

//            //Act
//            this.adminController.EditMaterialTiming(1);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void EditMaterialTimingGet_Should_Return_PartialView_EditMaterialTiming()
//        {
//            //Arrange
//            this.lookUpService.Stub(p => p.GetApconApprovalTypePriceById(1)).IgnoreArguments().Return(apconPriceView);

//            //Act
//            var log = (PartialViewResult)this.adminController.EditMaterialTiming(1);

//            //Assert
//            Assert.AreEqual(log.ViewName, "EditMaterialTiming");

//        }

//        [Test]
//        public void EditMaterialTimingPost_Should_Return_ArgumentError_If_View_IsNull()
//        {
//            //Arrange
//            MaterialTypeTimingView timingView = null;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.EditMaterialTiming(timingView));

//        }

//        [Test]
//        public void EditMaterialTimingPost_Should_Return_View_If_ModelState_IsValid()
//        {
//            //Arrange
//            var timingView = new MaterialTypeTimingView();
//            this.adminController.ViewData.ModelState.AddModelError("MaterialTimingForm", "Invalid Values");

//            //Act
//            var log = (ViewResult)this.adminController.EditMaterialTiming(timingView);

//            //Assert
//            Assert.AreEqual(1, log.ViewData.ModelState.Values.Count());

//        }


//        [Test]
//        public void EditMaterialTimingPost_Shoul_Call_ProcessMaterialTypeTimingInfo_From_GeneralService_Successfully()
//        {
//            //Arrange
//            var timingView = new MaterialTypeTimingView();

//            this.generalService.Stub(p => p.ProcessMaterialTypeTimingInfo(timingView)).Return(string.Empty);

//            //Act
//            this.adminController.EditMaterialTiming(1);

//            //Assert
//            this.generalService.VerifyAllExpectations();

//        }


//        [Test]
//        public void EditMaterialTimingPost_Should_Call_GetMaterialTypeTimingView_From_LookupService_When_ProcessingMessage_IsNull()
//        {
//            //Arrange
//            var timingView = new MaterialTypeTimingView();
//            IMaterialTypeTimingView returnModel = new MaterialTypeTimingView();
//            returnModel.ProcessingMessage = "Error";
//            var message = returnModel.ProcessingMessage;

//            this.lookUpService.Stub(p => p.GetMaterialTypeTimingView(timingView, message))
//                .Return(returnModel);

//            //Act
//            this.adminController.EditMaterialTiming(timingView);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }


//        [Test]
//        public void EditMaterialTimingPost_Should_RedirectTo_MaterialTiming_Home_When_All_Entries_Are_Okay()
//        {

//            //Arrange
//            var timingView = new MaterialTypeTimingView();
//            IMaterialTypeTimingView returnModel = new MaterialTypeTimingView();
//            returnModel.ProcessingMessage = "Error";
//            var message = returnModel.ProcessingMessage;

//            this.lookUpService.Stub(p => p.GetMaterialTypeTimingView(timingView, message))
//                .Return(returnModel);

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.EditMaterialTiming(timingView);

//            // Assert
//            Assert.AreEqual("MaterialTiming", result.RouteValues["action"]);
//        }


//        [Test]
//        public void DeleteMaterialTimingGet_Should_Throw_ArgumentNullException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentOutOfRangeException>(() => this.adminController.DeleteMaterialTiming(Id));
//        }

//        [Test]
//        public void DeleteMaterialTimingGet_Should_GetDeleteMaterialTypeTimingById_From_LookUpService_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetDeleteMaterialTypeTimingById(1,"")).IgnoreArguments().Return(materialTimingView);

//            //Act
//            this.adminController.DeleteMaterialTiming(1);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void DeleteMaterialTimingGet_Should_Return_PartialView_DeleteMaterialTiming()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetDeleteMaterialTypeTimingById(1, "")).IgnoreArguments().Return(materialTimingView);

//            //Act
//            var log = (PartialViewResult)this.adminController.DeleteMaterialTiming(1);

//            //Assert
//            Assert.AreEqual(log.ViewName, "DeleteMaterialTiming");

//        }

//        [Test]
//        public void DeleteMaterialTimingPost_Should_Throw_ArgumentOutOfRangeException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentOutOfRangeException>(() => this.adminController.DeleteMaterialTiming(Id, ""));
//        }


//        [Test]
//        public void DeleteMaterialTimingPost_Should_Call_ProcessDeleteMaterialTypeTiming_From_GeneralService_Successfully()
//        {
//            //Arrange
//            int Id = 1;
//            this.generalService.Stub(p => p.ProcessDeleteMaterialTypeTiming(Id)).IgnoreArguments().Return(string.Empty);

//            //Act
//            this.adminController.DeleteMaterialTiming(Id, "");

//            //Assert
//            this.generalService.VerifyAllExpectations();

//        }

//        [Test]
//        public void DeleteMaterialTimingPost_Should_RedirectTo_MaterialTiming_Home_When_Delete_Entries_Are_Okay()
//        {
//            //Arrange
//            int Id = 1;
//            this.generalService.Stub(p => p.ProcessDeleteMaterialTypeTiming(Id)).IgnoreArguments().Return(string.Empty);

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.DeleteMaterialTiming(Id, "");

//            // Assert
//            Assert.AreEqual("MaterialTiming", result.RouteValues["action"]);
//        }


//        [Test]
//        public void RadioService_Should_Call_GetRadioServicePriceViewModel_From_LookUpService_Successfully()
//        {
//            //Setup
//            this.lookUpService.Expect(p => p.GetRadioServicePriceViewModel(1,1, 1, 1, "")).IgnoreArguments().Return(radioPriceList);

//            //Act
//            this.adminController.RadioService(1,1, 1, 1, "");

//            //Assert
//            this.lookUpService.VerifyAllExpectations();
//        }


//        [Test]
//        public void RadioService_Should_Return_RadioService_View_Successfully()
//        {
//            //Setup
//            this.lookUpService.Stub(p => p.GetRadioServicePriceViewModel(1, 1, 1, 1, "")).IgnoreArguments().Return(radioPriceList);

//            //Act
//            var log = (ViewResult)this.adminController.RadioService(1, 1, 1, 1, "");

//            //Assert
//            Assert.IsNotNull(log);
//        }

//        [Test]
//        public void CreateRadioServiceGet_Should_Call_GetRadioServiceTypePriceView_From_LookupServices_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetRadioServiceTypePriceView()).IgnoreArguments().Return(radioPriceView);

//            //Act
//            this.adminController.CreateRadioService();

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void CreateRadioServiceGet_Should_Return_CreateRadioService_View_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Stub(p => p.GetRadioServiceTypePriceView()).IgnoreArguments().Return(radioPriceView);

//            //Act
//            var log = (ViewResult)this.adminController.CreateRadioService();

//            //Assert
//            Assert.IsNotNull(log);
//        }


//        [Test]
//        public void CreateRadioServicePost_Should_Return_ArgumentNullException_When_View_IsNull()
//        {
//            //Arrange
//            RadioServicePriceListMain radioserviceview = null;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.CreateRadioService(radioserviceview));
//        }

//        [Test]
//        public void CreateRadioServicePost_Should_Return_View_If_ModelState_IsValid()
//        {
//            //Arrange
//            var radioserviceview = new RadioServicePriceListMain();
//            this.adminController.ViewData.ModelState.AddModelError("RadioServiceForm", "Invalid Values");

//            //Act
//            var log = (ViewResult)this.adminController.CreateRadioService(radioserviceview);

//            //Assert
//            Assert.AreEqual(1, log.ViewData.ModelState.Values.Count());

//        }

//        [Test]
//        public void CreateRadioServicePost_Shoul_Call_ProcessRadioServicePriceView_From_GeneralService_Successfully()
//        {
//            //Arrange

//            var radioserviceview = new RadioServicePriceListMain();
//            this.generalService.Stub(p => p.ProcessRadioServicePriceView(radioserviceview)).Return(string.Empty);

//            //Act
//            this.adminController.CreateRadioService(radioserviceview);

//            //Assert
//            this.generalService.VerifyAllExpectations();

//        }

//        [Test]
//        public void CreateRadioServicePost_Should_Call_GetRadioServiceTypePriceView_From_LookupService_When_ProcessingMessage_IsNull()
//        {
//            //Arrange
//            var radioserviceview = new RadioServicePriceListMain();
//            IRadioServicePriceList returnModel = new RadioServicePriceListMain();
//            returnModel.ProcessingMessages = "Error";
//            var message = returnModel.ProcessingMessages;

//            this.lookUpService.Stub(p => p.GetRadioServiceTypePriceView(radioserviceview, message))
//                .Return(returnModel);

//            //Act
//            this.adminController.CreateRadioService(radioserviceview);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }


//        [Test]
//        public void CreateRadioServicePost_Should_RedirectTo_RadioService_Home_When_All_Entries_Are_Okay()
//        {

//            //Arrange
//            var radioserviceview = new RadioServicePriceListMain();
//            IRadioServicePriceList returnModel = new RadioServicePriceListMain();
//            returnModel.ProcessingMessages = "Error";
//            var message = returnModel.ProcessingMessages;

//            this.lookUpService.Stub(p => p.GetRadioServiceTypePriceView(radioserviceview, message))
//                .Return(returnModel);

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.CreateRadioService(radioserviceview);

//            // Assert
//            Assert.AreEqual("RadioService", result.RouteValues["action"]);
//        }

//        [Test]
//        public void EditRadioServiceGet_Should_Throw_ArgumentNullException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.EditRadioService(Id));
//        }

//        [Test]
//        public void EditRadioServiceGet_Should_GetRadioServicePriceById_From_LookUpService_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetRadioServicePriceById(1)).IgnoreArguments().Return(radioPriceView);

//            //Act
//            this.adminController.EditRadioService(1);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void EditRadioServiceGet_Should_Return_PartialView_EditRadioService()
//        {
//            //Arrange
//            this.lookUpService.Stub(p => p.GetRadioServicePriceById(1)).IgnoreArguments().Return(radioPriceView);

//            //Act
//            var log = (PartialViewResult)this.adminController.EditRadioService(1);

//            //Assert
//            Assert.AreEqual(log.ViewName, "EditRadioService");

//        }

//        [Test]
//        public void EditRadioServicePost_Should_Return_ArgumentError_If_View_IsNull()
//        {
//            //Arrange
//            RadioServicePriceListMain radioView = null;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.adminController.EditRadioService(radioView));

//        }

//        [Test]
//        public void EditRadioServicePost_Should_Return_View_If_ModelState_IsValid()
//        {
//            //Arrange
//            var radioView = new RadioServicePriceListMain();
//            this.adminController.ViewData.ModelState.AddModelError("MaterialTimingForm", "Invalid Values");

//            //Act
//            var log = (ViewResult)this.adminController.EditRadioService(radioView);

//            //Assert
//            Assert.AreEqual(1, log.ViewData.ModelState.Values.Count());

//        }


//        [Test]
//        public void EditRadioServicePost_Shoul_Call_ProcessEditScriptingPrice_From_GeneralService_Successfully()
//        {
//            //Arrange
//            var radioView = new RadioServicePriceListMain();
//            this.generalService.Stub(p => p.ProcessEditScriptingPrice(radioView)).Return(string.Empty);

//            //Act
//            this.adminController.EditRadioService(radioView);

//            //Assert
//            this.generalService.VerifyAllExpectations();

//        }


//        [Test]
//        public void EditRadioServicePost_Should_Call_GetRadioServiceTypePriceView_From_LookupService_When_ProcessingMessage_IsNull()
//        {
//            //Arrange
//            var radioView = new RadioServicePriceListMain();
//            IRadioServicePriceList returnModel = new RadioServicePriceListMain();
//            returnModel.ProcessingMessages = "Error";
//            var message = returnModel.ProcessingMessages;

//            this.lookUpService.Stub(p => p.GetRadioServiceTypePriceView(radioView, message))
//                .Return(returnModel);

//            //Act
//            this.adminController.EditRadioService(radioView);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }


//        [Test]
//        public void EditRadioServicePost_Should_RedirectTo_RadioService_Home_When_All_Entries_Are_Okay()
//        {

//            //Arrange
//            var radioView = new RadioServicePriceListMain();
//            IRadioServicePriceList returnModel = new RadioServicePriceListMain();
//            returnModel.ProcessingMessages = "Error";
//            var message = returnModel.ProcessingMessages;

//            this.lookUpService.Stub(p => p.GetRadioServiceTypePriceView(radioView, message))
//                .Return(returnModel);

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.EditRadioService(radioView);

//            // Assert
//            Assert.AreEqual("RadioService", result.RouteValues["action"]);
//        }


//        [Test]
//        public void DeleteRadioServiceGet_Should_Throw_ArgumentNullException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentOutOfRangeException>(() => this.adminController.DeleteRadioService(Id));
//        }

//        [Test]
//        public void DeleteRadioServiceGet_Should_GetDeleteRadioServicePriceById_From_LookUpService_Successfully()
//        {
//            //Arrange
//            this.lookUpService.Expect(p => p.GetDeleteRadioServicePriceById(1)).IgnoreArguments().Return(radioPriceView);

//            //Act
//            this.adminController.DeleteRadioService(1);

//            //Assert
//            this.lookUpService.VerifyAllExpectations();

//        }

//        [Test]
//        public void DeleteRadioServiceGet_Should_Return_PartialView_DeleteRadioService()
//        {
//            //Arrange
//            this.lookUpService.Stub(p => p.GetDeleteRadioServicePriceById(1)).IgnoreArguments().Return(radioPriceView);

//            //Act
//            var log = (PartialViewResult)this.adminController.DeleteRadioService(1);

//            //Assert
//            Assert.AreEqual(log.ViewName, "DeleteRadioService");

//        }
         
//        [Test]
//        public void DeleteRadioServicePost_Should_Throw_ArgumentOutOfRangeException_When_Id_Less_Than_One()
//        {
//            //Arrange
//            int Id = 0;

//            //Assert
//            Assert.Throws<ArgumentOutOfRangeException>(() => this.adminController.DeleteRadioService(Id, ""));
//        }


//        [Test]
//        public void DeleteRadioServicePost_Should_Call_ProcessDeleteRadioServicePrice_From_GeneralService_Successfully()
//        {
//            //Arrange
//            int Id = 1;
//            this.generalService.Expect(p => p.ProcessDeleteRadioServicePrice(Id)).IgnoreArguments().Return(string.Empty);

//            //Act
//            this.adminController.DeleteRadioService(Id, "");

//            //Assert
//            this.generalService.VerifyAllExpectations();

//        }

//        [Test]
//        public void DeleteRadioServicePost_Should_RedirectTo_RadioService_Home_When_Delete_Entries_Are_Okay()
//        {
//            //Arrange
//            int Id = 1;
//            this.generalService.Stub(p => p.ProcessDeleteRadioServicePrice(Id)).IgnoreArguments().Return(string.Empty);

//            // Act
//            var result = (RedirectToRouteResult)this.adminController.DeleteRadioService(Id, "");

//            // Assert
//            Assert.AreEqual("RadioService", result.RouteValues["action"]);
//        }



//    }
//}
