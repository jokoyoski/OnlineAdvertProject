using ADit.Domain.Models;
using ADit.Domain.Resources;
using ADit.Interfaces;
using System;
using System.Web.Mvc;
using AA.Infrastructure.Interfaces;
using ADit.Interfaces.ValueTypes;
using ADit.Domain.Attributes;

namespace ADit.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        private readonly ITransactionService transactionService;
        private readonly ISessionStateService session;
        private readonly IOrderServices orderServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="accountService">The account service.</param>
        /// <param name="transactionService">The transaction service.</param>
        /// <param name="session">The session.</param>
        /// <param name="orderServices">The order services.</param>
        
        public AccountController(IAccountService accountService, ITransactionService transactionService,
            ISessionStateService session, IOrderServices orderServices)
        {
            this.accountService = accountService;
            this.transactionService = transactionService;
            this.session = session;

            this.orderServices = orderServices;
        }
        ///
        #region Registration

        /// <summary>
        /// Registers this instance.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous, HttpGet]
        public ActionResult Register()
        {
            var viewModel = this.accountService.GetRegistrationView();

            return this.View("Register", viewModel);
        }


        /// <summary>
        /// Registrations the specified registration.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">registration</exception>
        [AllowAnonymous, HttpPost]
        public ActionResult Register(RegistrationView registrationInfo)
        {
            if (registrationInfo == null)
            {
                throw new ArgumentNullException("registrationInfo");
            }

            // check if entries are valid based on definations in RegistrationView model
            if (!this.ModelState.IsValid)
            {
                return this.View("Register", registrationInfo);
            }

            // call service in domain to process Registration information
            var returnModel = this.accountService.ProcessRegistrationInfo(registrationInfo);

            // check if there is error message then redisplay view using model
            if (!string.IsNullOrEmpty(returnModel.ProcessingMessage))
            {
                return this.View("Register", returnModel);
            }

            return this.RedirectToAction("Login", "Account",
                new {infoMessage = "We have sent an email, Please Login to continue"});
        }

        #endregion


        #region Login

        /// <summary>
        /// Logins the specified information message.
        /// </summary>
        /// <param name="infoMessage">The information message.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        [AllowAnonymous, HttpGet]
        public ActionResult Login(string infoMessage = "", string errorMessage = "", string userName = "",
            string returnUrl = "")
        {
            var viewModel = this.accountService.GetLogOnView(infoMessage, errorMessage, userName, returnUrl);

            return this.View("Login", viewModel);
        }

        /// <summary>
        /// Logins the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">model</exception>
        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(LogOnView model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (!this.ModelState.IsValid)
            {
                return View("Login", model);
            }

            var isUserValid = this.accountService.SignIn(model);
            if (isUserValid)
            {
                //Check if the User Account is Validated
                //TODO : Account that are not validated should be able to request for anotherr activation code incase they loose the first 
                var userStatus = this.accountService.GetActivationStatus(model);
                if (userStatus == false)
                {
                    this.ModelState.AddModelError("", Messages.Verified);


                    return this.View(model);
                }


                //Get The Currently Logged User Id
                var userId = (int) session.GetSessionValue(SessionKey.UserId);

                // Get order id
                var orderId = this.orderServices.GetOrderIdentifier(userId);

                //Update Cart
                this.transactionService.UpdateCart(orderId);

                this.transactionService.PendingFulfilment(userId);

             
                return !string.IsNullOrEmpty(model.ReturnUrl)
                    ? (ActionResult) this.Redirect(model.ReturnUrl)
                    : this.RedirectToAction("Index", "Service");
            }

            this.ModelState.AddModelError("", Messages.IncorrectPasswordText);


            return this.View(model);
        }

        #endregion


        #region Logoff

        /// <summary>
        /// Logs the off.
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOff()
        {
            this.accountService.SignOff();

            return this.RedirectToAction("Index", "Home");
        }

        #endregion


        #region Forget Password

        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ForgetPassword()
        {
            var viewModel = this.accountService.GetForgetPasswordView(string.Empty);
            return View(viewModel);
        }

        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <param name="emailVerification">The email verification.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">registrationInfo</exception>
        [HttpPost]
        public ActionResult ForgetPassword(EmailVerificationView emailVerification)
        {
            if (emailVerification == null)
            {
                throw new ArgumentNullException("emailVerification");
            }

            var processingMessage = string.Empty;

            // check if entries are valid based on definations in RegistrationView model
            if (!this.ModelState.IsValid)
            {
                return this.View("ForgetPassword");
            }

            processingMessage = this.accountService.ProcessForgetPassword(emailVerification.Email);

            var viewModel = this.accountService.GetForgetPasswordView(processingMessage);


            // call service in domain to process Registration information
            return View("ForgetPassword", viewModel);
        }

        #endregion


        #region Confirm Password

        /// <summary>
        /// Confirms the password.
        /// </summary>
        /// <param name="activationCode">The code.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ConfirmPassword(string activationCode)
        {
            var activation = this.accountService.CheckCodeValidity(activationCode);

           
       
            if (activation == null)
            {
                return RedirectToAction("Login", "Account",
                    new
                    {
                        infoMessage = "Your activation code is either invalid or expired. Please request another link"
                    });
            }


            return View("ConfirmPassword", activation);
        }

        /// <summary>
        /// Confirms the password.
        /// </summary>
        /// <param name="passwordInfo">The password information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">passwordInfo</exception>
        [HttpPost]
        public ActionResult ConfirmPassword(PasswordView passwordInfo)
        {
            if (passwordInfo == null)
            {
                throw new ArgumentNullException("passwordInfo");
            }

            // check if entries are valid based on definations in RegistrationView model
            if (!ModelState.IsValid)
            {
                return View("ConfirmPassword", passwordInfo);
            }

            var returnModel = this.accountService.SavePassword(passwordInfo);
            if (!string.IsNullOrEmpty(returnModel))
            {
                return this.View("ConfirmPassword", returnModel);
            }

            return this.RedirectToAction("Login", "Account", new {infoMessage = "Password changed successfully"});
        }

        #endregion


        #region Activation Code

        /// <summary>
        /// Activations the code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public ActionResult ActivationCode(string code)
        {
            if (code == null)
            {
                throw new ArgumentNullException(nameof(code));
            }

            


            var processingMessage = this.accountService.ProcessConfirmActivationCode(code);

            if (string.IsNullOrEmpty(processingMessage))
            {
                processingMessage = "Your account has been verified, You can now login";
            }
            else
            {
                processingMessage = "Invalid Activation code, Please try again";
            }


            return RedirectToAction("Login", "Account", new {infoMessage = processingMessage });
        }

        #endregion



      
    }
}