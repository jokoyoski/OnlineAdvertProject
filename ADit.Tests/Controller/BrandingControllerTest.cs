//using System;
//using System.Collections.Generic;
//using System.Data.SqlTypes;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;
//using ADit.Controllers;
//using ADit.Interfaces;
//using System.Web;
//using Rhino.Mocks;
//using NUnit.Framework;
//using System.Web.Mvc;
//using System.Web.Routing;
//using ADit.Domain.Models;

//namespace ADit.Tests.Controller
//{
//    [TestFixture, Category("Controllers")]
//    public class BrandingControllerTest
//    {
//        private HttpContextBase httpContext;
//        private IBrandingService brandingService;
//        private BrandingController brandingController;

//        [SetUp]
//        public void SetUp()
//        {
//            this.httpContext = MockRepository.GenerateStub<HttpContextBase>();
//            this.brandingService = MockRepository.GenerateMock<IBrandingService>();

//            this.brandingController = new BrandingController(this.brandingService);

//            this.brandingController.ControllerContext =
//                new ControllerContext(this.httpContext, new RouteData(), this.brandingController);
//        }
//        [Test]      
//        public void Branding_Get_Should_Call_GetBrandingView_Method_From_BrandingService_Successfully()
//        {
           
//            // Arrange
//            this.brandingService.Expect(p => p.GetBrandingView()).IgnoreArguments().Return(new BrandingView());
          
//            // Act
//            this.brandingController.Index();
                

//            // Assert
//            this.brandingService.VerifyAllExpectations();
//        }

//        [Test]
//        public void Branding_Post_Should_Call_ProcessView_Method_from_BrandingService()
//        {
//            BrandingView brandingView = new BrandingView();
//            // Arrange
//            this.brandingService.Expect(p => p.ProcessView(brandingView)).IgnoreArguments().Return(new BrandingView());

//            // Act
//            this.brandingController.Index(brandingView);
//            // Assert 
//            this.brandingService.VerifyAllExpectations();
//        }

//        [Test]
//        public void Material_Get_Should_Call_GetMaterialListViewModel_Method_From_BrandingService_Successfully()
//        {
//            var message = string.Empty;
//            // Arrange
//            this.brandingService.Expect(p => p.GetMaterialListViewModel(message)).IgnoreArguments()
//                .Return(new BrandingMaterialListView());
//            //Act
//            this.brandingController.Material(message);
//            // Assert
//            this.brandingService.VerifyAllExpectations();
//        }

//        [Test]
//        public void AddMaterial_Get_Should_Call_CreateBrandingMaterialView_Method_From_BrandingService_Successfully()
//        {
//            var message = string.Empty;
//            // Arrange
//            this.brandingService.Expect(p => p.CreateBrandingMaterialView()).IgnoreArguments()
//                .Return(new BrandingMaterialView());
//            // Act
//            this.brandingController.AddMaterial(message);
//            // Assert
//            this.brandingService.VerifyAllExpectations();
//        }

//        [Test]
//        public void AddMaterial_Post_Should_throw_Exception_when_brandingMaterialView_is_Null()
//        {
           


//            //Arrange
//            BrandingMaterialView brandingMaterialInfo = null;

//            //Assert
//            Assert.Throws<ArgumentNullException>(() => this.brandingController.AddMaterial(brandingMaterialInfo));
          
//        }

//        [Test]
//        public void AddMaterial_Post_Should_Return_Model_ErrorMessage_When_Input_Model_Is_Not_Valid()
//        {
//            //Arrange
//            var brandingMaterialView = new BrandingMaterialView();
//            this.brandingController.ViewData.ModelState.AddModelError("BrandingMaterialView", "Invalid Values");
//            var result = (ViewResult) this.brandingController.AddMaterial(brandingMaterialView);

//            Assert.AreEqual(1,result.ViewData.ModelState.Values.Count);
//        }

//        [Test]
//        public void AddMaterial_Post_Should_Return_Error_Message_When_BrandingService_Method_ProcessBrandingMaterialView_Returns_Error_Message()
//        {
//            // Arrange
//            var brandingMaterialView = new BrandingMaterialView();
//            IBrandingMaterialView returnModel = new BrandingMaterialView();
//            returnModel.ProcessingMessage = "Errors";

//            //Act
//            this.brandingController.AddMaterial(brandingMaterialView);

//            //Assert
//            this.brandingService.VerifyAllExpectations();
//        }

//        [Test]
//        public void AddMaterial_Post_Should_Call_AdminSaveMaterial_Method_From_BrandingService_Successfully()
//        {
//            var brandingMaterialView = new BrandingMaterialView();
//            //Arrange
//            this.brandingService.Expect(p => p.AdminSaveMaterial(brandingMaterialView)).IgnoreArguments()
//                .Return(brandingMaterialView);
//            //Act 
//            this.brandingController.AddMaterial(brandingMaterialView);

//            //Assert
//            this.brandingService.VerifyAllExpectations();
//        }

//        [Test]
//        public void AddMaterial_Get_should_return_AddMaterialView()
//        {

           
//            //Arrange
//            var results = string.Empty;


//            //Act
//            var result = (ViewResult)this.brandingController.AddMaterial(results);


//            Assert.IsNotEmpty("AddMaterial");
//        }

//        [Test]
//        public void AddMaterial_Get_Should_RedirectToAction_MaterialView()
//        {
//            //Arrange
//            var brandingMaterialView = new BrandingMaterialView();
//            //Act
//            var result = (RedirectToRouteResult) this.brandingController.AddMaterial(brandingMaterialView);
            
//            Assert.AreEqual("Material",result.RouteValues["action"]);
//        }

//        [Test]
//        public void EditBrandingMaterial_Get_Should_Call_GetBrandingMaterialById_Method_From_BrandingService_Successfully()
//        {
//            var brandingMaterialId = 2;
//                //Assert 
//            this.brandingService.Expect(p => p.GetBrandingMaterialById(brandingMaterialId)).IgnoreArguments()
//                .Return(new BrandingMaterialView());
//            //Act
//            this.brandingController.EditBrandingMaterial(brandingMaterialId);
//            //Assert
//            this.brandingService.VerifyAllExpectations();

//        }

//        [Test]
//        public void EditBrandingMaterial_Should_Call_ProcessEditBrandingMaterial_Method_From_BrandingService()
//        {
//            //Assert

            
//        }
       



//    }
//}








