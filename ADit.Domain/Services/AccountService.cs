using AA.Infrastructure.Interfaces;
using ADit.Domain.Resources;
using ADit.Interfaces;
using ADit.Interfaces.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using AA.Infrastructure.Models;
using ADit.Domain.Utilities;
using Environment = AA.Infrastructure.Utility.Environment;

namespace ADit.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IAccountService" />
    public class AccountService : IAccountService
    {
        private readonly IAccountViewsModelFactory accountViewsModelFactory;

        private readonly IEmailFactory emailFactory;

        private readonly IFormsAuthenticationService formsAuthentication;

        private readonly ISessionStateService session;


        private readonly IAccountRepository accountRepository;


        private readonly IAesEncryption encryptionService;

        private readonly IEmail emailService;

        private readonly IEnvironment environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="accountViewsModelFactory">The account views model factory.</param>
        /// <param name="emailFactory">The email factory.</param>
        /// <param name="session">The session.</param>
        /// <param name="formsAuthentication">The forms authentication.</param>
        /// <param name="accountRepository">The account repository.</param>
        /// <param name="encryptionService">The encryption service.</param>
        /// <param name="emailService">The email service.</param>
        /// <param name="environment">The environment.</param>
        public AccountService(IAccountViewsModelFactory accountViewsModelFactory, IEmailFactory emailFactory,
            ISessionStateService session, IFormsAuthenticationService formsAuthentication,
            IAccountRepository accountRepository, IAesEncryption encryptionService,
            IEmail emailService, IEnvironment environment)
        {
            this.accountViewsModelFactory = accountViewsModelFactory;

            this.accountRepository = accountRepository;
            this.emailFactory = emailFactory;
            this.session = session;
            this.formsAuthentication = formsAuthentication;
            this.encryptionService = encryptionService;
            this.emailService = emailService;
            this.environment = environment;
        }

        /// <summary>
        /// Gets the log on view.
        /// </summary>
        /// <param name="infoMessage">The information message.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        public ILogOnView GetLogOnView(string infoMessage, string errorMessage, string userName, string returnUrl)
        {
            return this.accountViewsModelFactory.CreateLogOnView(infoMessage, errorMessage, userName, returnUrl);
        }

        /// <summary>
        /// Gets the registration view.
        /// </summary>
        /// <returns></returns>
        public IRegistrationView GetRegistrationView()
        {
            // about us source records from database


            // send it to accounts view factory to create the view factory
            var viewModel = this.accountViewsModelFactory.CreateRegistrationView();

            // return the view to controller
            return viewModel;
        }

        /// <summary>
        /// Gets the user registration.
        /// </summary>
        /// <returns></returns>
        public IUserListView GetUserRegistration(string Email, string FirstName)
        {
            var userRegistrationList = this.accountRepository.GetUserRegistration();
            // send it to accounts view factory to create the view factory
            var viewModel =
                this.accountViewsModelFactory.CreateUserRegistrationView(userRegistrationList, Email, FirstName);

            // return the view to controller
            return viewModel;
        }

        /// <summary>
        /// Processes the registration information.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">registrationInfo</exception>
        public IRegistrationView ProcessRegistrationInfo(IRegistrationView registrationInfo)
        {
            if (registrationInfo == null)
            {
                throw new System.ArgumentNullException(nameof(registrationInfo));
            }

            var processingMessage = string.Empty;
            var isDataOkay = true;

            //checks if similar email does exist in the database 
            var registrationData = this.accountRepository.GetRegistrationByEmail(registrationInfo.Email);
            var IsRecordExist = (registrationData != null);

            if (IsRecordExist)
            {
                isDataOkay = false;
                processingMessage = Messages.EmailAlreadyUsedText;
            }

            var returnViewModel =
                this.accountViewsModelFactory.CreateUpdatedRegistraionView(registrationInfo, processingMessage);

            if (!isDataOkay)
            {
                return returnViewModel;
            }

            //save data to database
            //  var registrationId = 0;

            registrationInfo.Password = this.encryptionService.Encrypt(registrationInfo.Password);

            var savedData = this.accountRepository.SaveRegistrationInfo(registrationInfo);
            this.accountRepository.CreateUserRole(registrationInfo);

            if (savedData == string.Empty)
            {
                //Send activation Link to the User
                //Genenrate Activation Code
                var activationCode = CodeGenerators.GenerateActivationCode();

                //Get The registered User Information
                var user = this.accountRepository.GetRegistrationByEmail(registrationInfo.Email);

                //Pass the Code and the user ID to store to Database
                var result = this.accountRepository.SaveUserActivationCode(user.UserRegistrationId, activationCode);


                // email send implementation here
                var emailDetail =
                    this.emailFactory.CreateRegistrationRequestEmail(registrationInfo,
                        activationCode); //999 is the registrationId from database

                 var emailKey = this.environment[EnvironmentValues.EmailKey];

                this.emailService.Send(emailKey, "team@aditng.com", "Adit Team", emailDetail.Subject,
                   emailDetail.Recipients, emailDetail.Recipients, "", emailDetail.Body);


                ////follow below to add attachments 
                var attachmentList = new List<IStagedAttachment>();

                //var aContent = new byte[10]; // this is just sample
                //var anAttachment = new StagedAttachment
                //{
                //    ContentType = "", Filename = "", TheContent = aContent
                //};

                //attachmentList.Add(anAttachment);

                //this.emailService.Send(emailKey, "team@aditng.com", "Adit Team", emailDetail.Subject, emailDetail.Recipients,
                //    emailDetail.Recipients, "", emailDetail.Body, attachmentList);
            }


            return returnViewModel;
        }

        /// <summary>
        /// Gets the forget password view.
        /// </summary>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        public IEmailVerificationView GetForgetPasswordView(string processingMessage)
        {
            // send it to accounts view factory to create the view factory
            var viewModel = this.accountViewsModelFactory.CreateForgetPasswordView(processingMessage);

            // return the view to controller
            return viewModel;
        }

        /// <summary>
        /// Processes the forget password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public string ProcessForgetPassword(string email)
        {
            string processingMessage = "";

            var user = this.accountRepository.GetRegistrationByEmail(email);

            if (user == null)
            {
                processingMessage = "This Account does not exist. Please check your email";
            }
            else
            {
                //Genenrate Activation Code
                var activationCode = CodeGenerators.GenerateActivationCode();

                //Pass the Code and the user ID to store to Database
                var result = this.accountRepository.SaveUserActivationCode(user.UserRegistrationId, activationCode);


                //Generate Forgot Password Email From the factory
                var emailDetail = this.emailFactory.CreateForgetPasswordEmail(activationCode, email);

                var emailKey = this.environment[EnvironmentValues.EmailKey];
                this.emailService.Send(emailKey, "admin@automataAssociates.com", "ADit Team", emailDetail.Subject,
                    emailDetail.Recipients, emailDetail.Recipients, "", emailDetail.Body);

                processingMessage = "A link has been sent to your mail for activation";
            }


            return processingMessage;
        }

        /// <summary>
        /// Saves the password.
        /// </summary>
        /// <param name="passwordInfo">The password information.</param>
        /// <returns></returns>
        public string SavePassword(IPasswordView passwordInfo)
        {
            passwordInfo.Password = this.encryptionService.Encrypt(passwordInfo.Password);


            return this.accountRepository.SavePassword(passwordInfo);
        }

        /// <summary>
        /// Checks the code validity.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public IPasswordView CheckCodeValidity(string code)
        {
            string processingMessage = "";
            var getUser = this.accountRepository.CheckActivationCode(code);

            if (getUser == null)
            {
                processingMessage = "Your activation code is either invalid or expired. Please request another link";
            }
            
            return this.accountViewsModelFactory.ProcessPasswordView(processingMessage, getUser.RegistrationId,
                getUser.ActivationCode);
        }


        /// <summary>
        /// Processes the confirm activation code.
        /// </summary>
        /// <param name="code">The code.</param>
        public string ProcessConfirmActivationCode(string code)
        {
            return this.accountRepository.UpdateActivationCode(code);
        }

        /// <summary>
        /// Signs the in.
        /// </summary>
        /// <param name="logonModel">The logon model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">logonModel</exception>
        public bool SignIn(ILogOnView logonModel)
        {
            if (logonModel == null)
            {
                throw new ArgumentNullException(nameof(logonModel));
            }

            var userInfo = this.accountRepository.GetUserByEmail(logonModel);
            if (userInfo == null)
            {
                return false;
            }

            var decryptedValue = this.encryptionService.Decrypt(userInfo.Password);
            if (!logonModel.Password.Equals(decryptedValue))
            {
                return false;
            }

            var userActionList = this.accountRepository.GetUserRoleActions(logonModel.Email).ToList();
            if (!userActionList.Any())
            {
                userActionList = new List<IUserRolesModel>();
            }

            var actionList = userActionList.Select(x => x.UserRolesDescription).ToArray();

            session.AddValueToSession(SessionKey.UserRoles, actionList);
            session.AddValueToSession(SessionKey.UserId, userInfo.UserRegistrationId);
            session.AddValueToSession(SessionKey.UserName, logonModel.Email);
            session.AddValueToSession(SessionKey.FullName, userInfo.FirstName);
            session.AddValueToSession(SessionKey.UserIsAuthenticated, true);

            this.formsAuthentication.SignIn(logonModel.Email, logonModel.RememberMe);
            return true;
        }

        /// <summary>
        /// Gets the user rolesby email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public IUserRolesView GetUserRolesbyEmail(string email, string processingMessage)
        {
            var getUserRoles = this.accountRepository.GetUserRoleActions(email);

            var userRolesList = this.accountRepository.GetUserRoleCollections();

            return this.accountViewsModelFactory.CreateUserRolesView(getUserRoles, userRolesList, email,
                processingMessage);
        }

        /// <summary>
        /// Deletes the user roles.
        /// </summary>
        /// <param name="userRolesView">The user roles view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userRolesView</exception>
        public string DeleteUserRoles(string email, int userRolesId)
        {
            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            if (userRolesId < 0)
            {
                throw new ArgumentNullException("userRolesId");
            }

            var result = this.accountRepository.DeleteUserRoles(email, userRolesId);
            return result;
        }

        /// <summary>
        /// Saves the user roles.
        /// </summary>
        /// <param name="userRolesView">The user roles view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userRolesView</exception>
        public string SaveUserRoles(IUserRolesView userRolesView)
        {
            var processingMessage = string.Empty;
            if (userRolesView == null)
            {
                throw new ArgumentNullException(nameof(userRolesView));
            }

            var result = this.accountRepository.SaveUserRolesInfo(userRolesView);

            //check for current roles

            var currentRoles = this.accountRepository.CheckCurrentRoles(userRolesView.Email, userRolesView.UserRolesId);
            if(currentRoles)
            {
                processingMessage = Messages.UserRolesExist;
                return this.accountViewsModelFactory.CreateUserRolesView(processingMessage);
            }
            var userInfo= this.accountRepository.SaveUserRolesInfo(userRolesView);
            return this.accountViewsModelFactory.CreateUserRolesView(userInfo);
        }

        /// <summary>
        /// Gets the activation status.
        /// </summary>
        /// <param name="logOnView">The log on view.</param>
        /// <returns></returns>
        public bool GetActivationStatus(ILogOnView logOnView)
        {
            var userInfo = this.accountRepository.GetUserByEmail(logOnView);
            if ((userInfo == null) || (userInfo.IsUserVerified == false) || (userInfo.IsUserVerified == null))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Signs the off.
        /// </summary>
        public void SignOff()
        {
            session.RemoveSessionValue(SessionKey.Email);
            session.RemoveSessionValue(SessionKey.UserIsAuthenticated);

            var userName = (session.GetSessionValue(SessionKey.Email) ?? "").ToString();
            this.formsAuthentication.SignOut(userName);
        }

        /// <summary>
        /// Logs the activity.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="theActivity">The activity.</param>
        /// <param name="orderIdentifier">The order identifier.</param>
        public void LogActivity(string userId, string theActivity, string orderIdentifier)
        {
            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (theActivity == null)
            {
                throw new ArgumentNullException(nameof(theActivity));
            }

            this.accountRepository.LogUserActivity(userId, theActivity, orderIdentifier);
        }
    }
}