using AA.Infrastructure.Interfaces;
using ADit.Domain.Models;
using ADit.Domain.Resources;
using ADit.Domain.Services;
using ADit.Interfaces;
using ADit.Repositories.Models;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;

namespace ADit.Tests.Domain.Services
{

    [TestFixture]
    public class ActionServiceTest
    {
        private IEmailFactory emailFactory;

        //private readonly ILookupRepository lookupRepository;
        private IAccountRepository accountRepository;
        private IAccountViewsModelFactory accountfactory;

        private AccountService accountService;
        private IRegistrationView registrationInfo;
        private IRegistrationView returnModel;
        private IRegistration registrationData;
        private ILogOnView LogOnView;

        private IFormsAuthenticationService formsAuthentication;
        private ISessionStateService session;
        private  IAesEncryption encryptionService;
        private IEmail emailService;
        private IEnvironment environment;

        [SetUp]
        public void Setup()
        {
            this.emailFactory = MockRepository.GenerateMock<IEmailFactory>();
            this.accountRepository = MockRepository.GenerateMock<IAccountRepository>();
            this.accountfactory = MockRepository.GenerateMock<IAccountViewsModelFactory>();
            this.encryptionService = MockRepository.GenerateMock<IAesEncryption>();
            this.environment = MockRepository.GenerateMock<IEnvironment>();
            this.emailService = MockRepository.GenerateMock<IEmail>();

            this.accountService = new AccountService(this.accountfactory, this.emailFactory,
                 this.session, this.formsAuthentication, this.accountRepository,this.encryptionService
                 , this.emailService, this.environment);


            registrationInfo = new RegistrationView { UserRegistrationId = 1, Email = "testEmail" };
            returnModel = new RegistrationView { UserRegistrationId = 1, Email = "testEmail" };
            registrationData = new RegistrationRepModel { UserRegistrationId = 1, Email = "testEmail" };
            LogOnView = new LogOnView { Email = "jokoyoski@gmail.com",Password="joko" };
        }


        [Test]
        public void GetLogOnView_should_call_CreateLogOnView_of_accountViewsModelFactory()
        {
           var infoMessage=string.Empty;
            string errorMessage=string.Empty;
            string userName=string.Empty;
            string returnUrl=string.Empty;


            //setup
            this.accountfactory.Expect(p=>p.CreateLogOnView(infoMessage,errorMessage,userName,returnUrl)).IgnoreArguments().Return(new LogOnView());
            //act
            this.accountService.GetLogOnView(infoMessage, errorMessage, userName, returnUrl);
            //assert
            this.accountfactory.VerifyAllExpectations();

        }


        [Test]
        public void GetLogOnView_should_return_view()
        {
            var infoMessage = string.Empty;
            string errorMessage = string.Empty;
            string userName = string.Empty;
            string returnUrl = string.Empty;


            //setup
            this.accountfactory.Stub(p => p.CreateLogOnView(infoMessage, errorMessage, userName, returnUrl)).IgnoreArguments().Return(new LogOnView());
            //act
          var model  =this.accountService.GetLogOnView(infoMessage, errorMessage, userName, returnUrl);
            //assert

            Assert.AreEqual(typeof(LogOnView), model.GetType());
        }



        [Test]
        public void Confirm_if_the_account_service_gets_the_Get_Registrationview()
        {
            // Arrange
            this.accountfactory.Expect(p => p.CreateRegistrationView()).IgnoreArguments()
                .Return(null);

            //act
            this.accountService.GetRegistrationView();

            // Assert
            this.accountfactory.VerifyAllExpectations();
        }


        [Test]
        public void GetRegistrationView_should_return_View()
        {
            // Arrange
            this.accountfactory.Expect(p => p.CreateRegistrationView()).IgnoreArguments()
                .Return(new RegistrationView());

            //act
            var model=this.accountService.GetRegistrationView();

            // Assert
            Assert.AreEqual(typeof(RegistrationView), model.GetType());
        }



        [Test]
        public void ProcessRegistrationInfo_Should_Throw_When_registrationInfo_Is_Null()
        {
            registrationInfo = null;
            Assert.Throws<ArgumentNullException>(() => this.accountService.ProcessRegistrationInfo(registrationInfo));
        }
        [Test]
        public void ProcessRegistrationInfo_Should_Call_GetRegistrationByEmail_Of_AccountRepository_Successfully()
        {
            //arrange
            this.accountRepository.Expect(p => p.GetRegistrationByEmail(registrationInfo.Email)).IgnoreArguments().Return(registrationData);
            this.accountfactory.Stub(p => p.CreateUpdatedRegistraionView(null, null)).IgnoreArguments().Return(new RegistrationView());




            //act
            this.accountService.ProcessRegistrationInfo(registrationInfo);

            //assert

            this.accountRepository.VerifyAllExpectations();

        }



        [Test]
        public void ProcessRegistrationInfo_Should_Return_Error_Message_When_Email_Already_Exist()
        {
            //arrange
            this.accountRepository.Expect(p => p.GetRegistrationByEmail(registrationInfo.Email)).IgnoreArguments().Return(registrationData);
            returnModel.ProcessingMessage = Messages.UserAlreadyExistText;
            this.accountfactory.CreateUpdatedRegistraionView(registrationInfo, returnModel.ProcessingMessage);
            //act
            this.accountService.ProcessRegistrationInfo(registrationInfo);
            //asert
            Assert.AreEqual(Messages.UserAlreadyExistText, returnModel.ProcessingMessage);
        }

        [Test]
        public void ProcessRegistration_should_save_user_info_if_Email_does_not_exist()
        {
            //arrange
            this.accountRepository.Stub(p => p.GetRegistrationByEmail(null)).IgnoreArguments().Return(null);
            this.accountRepository.Expect(p => p.SaveRegistrationInfo(registrationInfo)).IgnoreArguments().Return(null);

            //act
            this.accountService.ProcessRegistrationInfo(registrationInfo);

            //assert
            this.accountRepository.VerifyAllExpectations();

        }
        [Test]
        public void SignIn_sould_call_GetUserByEmail_of_acount_repository()
        {
            //setup
            this.accountRepository.Expect(p => p.GetUserByEmail(LogOnView)).IgnoreArguments().Return(new RegistrationRepModel());
            //act
            this.accountService.SignIn(LogOnView);
            //assert
            this.accountRepository.VerifyAllExpectations();
        }




        [Test]
        public void SignIn_sould_call_Encrypt_of_encryptionService()
        {
            //setup
            this.accountRepository.Stub(p => p.GetUserByEmail(LogOnView)).IgnoreArguments().Return(new RegistrationRepModel());
            this.encryptionService.Expect(p => p.Encrypt(LogOnView.Password)).IgnoreArguments().Return(string.Empty);
            //act
            this.accountService.SignIn(LogOnView);
            //assert
            this.accountRepository.VerifyAllExpectations();
        }

        [Test]
        public void SignIn_sould_call_Decrypt_of_encryptionService()
        {
            List<string> user = new List<string>(); ;
            //setup
            this.accountRepository.Stub(p => p.GetUserByEmail(LogOnView)).IgnoreArguments().Return(new RegistrationRepModel());
            this.encryptionService.Stub(p => p.Encrypt(LogOnView.Password)).IgnoreArguments().Return(string.Empty);
            this.encryptionService.Stub(p => p.Decrypt(LogOnView.Password)).IgnoreArguments().Return(string.Empty);
           // this.accountRepository.Expect(p => p.GetUserRoleActions(LogOnView.Email)).IgnoreArguments().Return(user);
            //act
            this.accountService.SignIn(LogOnView);
            //assert
            this.accountRepository.VerifyAllExpectations();
        }


        [Test]
        public void SignIn_sould_call_GetUserRoleActions_of_accountRepository()
        {
            //setup
            this.accountRepository.Stub(p => p.GetUserByEmail(LogOnView)).IgnoreArguments().Return(new RegistrationRepModel());
            this.encryptionService.Stub(p => p.Encrypt(LogOnView.Password)).IgnoreArguments().Return(string.Empty);
            this.encryptionService.Stub(p => p.Decrypt(LogOnView.Password)).IgnoreArguments().Return(string.Empty);
            //act
            this.accountService.SignIn(LogOnView);
            //assert
            this.accountRepository.VerifyAllExpectations();
        }
    }
}
