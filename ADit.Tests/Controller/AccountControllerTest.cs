using AA.Infrastructure.Interfaces;
using ADit.Controllers;
using ADit.Domain.Models;
using ADit.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ADit.Tests.Controller
{
[TestFixture, Category("Controllers")]
    public class AccountControllerTest
    {
        private HttpContextBase httpContext;
        private IAccountService accountService;
        private AccountController accountController;
        private readonly ITransactionService transactionService;
        private readonly ISessionStateService session;
        private IOrderServices orderServices;

        [SetUp]
        public void SetUp()
        {
            this.httpContext = MockRepository.GenerateStub<HttpContextBase>();
            this.accountService = MockRepository.GenerateMock<IAccountService>();
            this.orderServices = MockRepository.GenerateMock<IOrderServices>();

            this.accountController = new AccountController(this.accountService,this.transactionService,this.session, this.orderServices);

            this.accountController.ControllerContext = new ControllerContext(this.httpContext, new RouteData(), this.accountController);
        }

        [Test]
        public void Register_Get_Should_Call_GetRegistrationView_Method_From_AccountService_Successfully()
        {
            // Arrange
            this.accountService.Expect(p => p.GetRegistrationView()).IgnoreArguments().Return(new RegistrationView());

            // Act
            this.accountController
                .Register();

            // Assert
            this.accountService.VerifyAllExpectations();
        }
        [Test]
        public void Register_Get_Should_Return_ViewResult_That_Is_Not_Null()
        {
            // Arrange
            var viewModel = new RegistrationView();
            this.accountService.Expect(p => p.GetRegistrationView()).IgnoreArguments().Return(viewModel);

            //Act
            var result = (ViewResult)accountController.Register();

            // Assert
            Assert.IsNotNull(result);
        }
        [Test]
        public void Register_Get_Should_Return_View_Register_Successfully()
        {
            // Arrange
            var viewModel = new RegistrationView();
            this.accountService.Expect(p => p.GetRegistrationView()).IgnoreArguments().Return(viewModel);

            //Act
            var result = (ViewResult)accountController.Register();

            // Assert
            Assert.AreEqual(result.ViewName, "Register");
        }
        [Test]
        public void Register_Post_Should_Throw_Exception_When_RegistrationInfo_Is_Null()
        {
            // Arrange
            RegistrationView registrationInfo = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() => this.accountController.Register(registrationInfo));
        }

        [Test]
        public void Register_Post_Should_Return_Model_ErrorMessage_When_Input_Model_Is_Not_Valid()
        {
            // Arrange
            var registrationInfo = new RegistrationView();
            this.accountController.ViewData.ModelState.AddModelError("RegistrationForm", "Invalid Values");

            var result = (ViewResult)this.accountController.Register(registrationInfo);

            Assert.AreEqual(1, result.ViewData.ModelState.Values.Count);
        }

        [Test]
        public void Register_Post_Should_Call_AccountService_Method_ProcessRegistrationInfo_When_ModelState_Is_Valid()
        {
            // Arrange
            var registrationInfo = new RegistrationView();
            IRegistrationView returnModel = new RegistrationView();
            this.accountService.Expect(p => p.ProcessRegistrationInfo(registrationInfo)).IgnoreArguments().Return(returnModel);

            // Act
            this.accountController.Register(registrationInfo);

            // Assert
            this.accountService.VerifyAllExpectations();
        }

        [Test]
        public void Register_Post_Should_Return_Error_Message_When_AccountService_Method_ProcessRegistrationInfo_Returns_Error_Message()
        {
            // Arrange
            var registrationInfo = new RegistrationView();                 // input into controller
            IRegistrationView returnModel = new RegistrationView();
            returnModel.ProcessingMessage = "Errors";

            this.accountService.Stub(p => p.ProcessRegistrationInfo(registrationInfo)).Return(returnModel);  // stub accountservice 

            // Act
            var result = (ViewResult)this.accountController.Register(registrationInfo);

            // Assert
            var resultingViewModel = (IRegistrationView)result.ViewData.Model;
            Assert.AreEqual("Errors", resultingViewModel.ProcessingMessage);
        }

        [Test]
        public void Register_Post_Should_Redirect_To_Controller_Register_When_All_Entries_Are_Okay()
        {
            // Arrange
            var registrationInfo = new RegistrationView();                 // input into controller
            IRegistrationView returnModel = new RegistrationView();

            this.accountService.Stub(p => p.ProcessRegistrationInfo(registrationInfo)).Return(returnModel);

            // Act
            var result = (RedirectToRouteResult)this.accountController.Register(registrationInfo);

            // Assert
            Assert.AreEqual("Account", result.RouteValues["controller"]);
        }

        [Test]
        public void Register_Post_Should_Redirect_To_Action_Confirm_When_All_Entries_Are_Okay()
        {
            // Arrange
            var registrationInfo = new RegistrationView();                 // input into controller
            IRegistrationView returnModel = new RegistrationView();

            this.accountService.Stub(p => p.ProcessRegistrationInfo(registrationInfo)).Return(returnModel);

            // Act
            var result = (RedirectToRouteResult)this.accountController.Register(registrationInfo);

            // Assert
            Assert.AreEqual("Confirm", result.RouteValues["action"]);
        }



    }
}
