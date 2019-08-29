using System;
using System.Collections.Generic;
using ADit.Domain.Models;
using ADit.Domain.Utilities;
using ADit.Interfaces;
using System.Linq;

namespace ADit.Domain.Factories
{
    /// <summary>
    /// Accounts views model factory, creates different view models for account controller
    /// </summary>
    /// <seealso cref="IAccountViewsModelFactory" />
    public class AccountViewsModelFactory : IAccountViewsModelFactory
    {
    public ILogOnView CreateLogOnView(string infoMessage, string errorMessage, string userName, string returnUrl)
        {
            var model = new LogOnView
            {

                InfoMessage = infoMessage ?? "",
                ErrorMessage = errorMessage ?? "",
                Email = userName ?? "",
                ReturnUrl = returnUrl ?? ""


            };
            return model;

        }

        /// <summary>
        /// Creates the registration view.
        /// </summary>
        /// <param name="aboutUsSourceCollection">The about us source collection.</param>
        /// <returns>Registration view model</returns>
        /// <exception cref="ArgumentNullException">aboutUsSourceCollection</exception>
        public IRegistrationView CreateRegistrationView()
        {


            var view = new RegistrationView
            {


                ProcessingMessage = string.Empty
            };

            return view;
        }


        /// <summary>
        /// Creates the user roles view.
        /// </summary>
        /// <param name="userActiveRoles">The user active roles.</param>
        /// <param name="userRolesList">The user roles list.</param>
        /// <returns></returns>
        public IUserRolesView CreateUserRolesView(IList<IUserRolesModel>userActiveRoles,IList<IUserRolesModel>userRolesList,string email,string processingMessage)
        {
            var userRolesDDl = GetUserRolesDropdown.UserRolesListItems(userRolesList, -1);


            var userView = new UserRolesView
            {
                UserRoles = userActiveRoles,
                UserRolesList = userRolesDDl,
                Email=email,
                processingMessage=processingMessage
            };

            return userView;
        }
       


        /// <summary>
        /// Creates the user registration view.
        /// </summary>
        /// <returns></returns>
        public IUserListView CreateUserRegistrationView(IList<IUserModel>userList,string Email,string FirstName)
        {
            
           
            //filter with desciprtion
         var  filteredList = userList.Where(x => x.FirstName.Contains(string.IsNullOrEmpty(FirstName) ? x.FirstName : FirstName)).ToList();
            filteredList = userList.Where(x => x.Email.Contains(string.IsNullOrEmpty(Email) ? x.Email :Email)).ToList();


            var view = new UserListView
            {


                UserRegistrationList=filteredList
            };

            return view;
        }

        public IEmailVerificationView CreateForgetPasswordView(string processingMessage)
        {


            var view = new EmailVerificationView
            {


                ProcessingMessage = processingMessage
            };

            return view;
        }


        /// <summary>
        /// Creates the user roles view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public string CreateUserRolesView(string processingMessage)
        {


            return processingMessage;


        }


        /// <summary>
        /// Creates the updated registraion view.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="aboutUsSourceCollection">The about us source collection.</param>
        /// <returns></returns>
        public IRegistrationView CreateUpdatedRegistraionView(IRegistrationView registrationInfo, string processingMessage)
        {
            if (registrationInfo == null)
            {
                throw new ArgumentNullException(nameof(registrationInfo));
            }
           
            registrationInfo.ProcessingMessage = processingMessage;

            return registrationInfo;

        }


        /// <summary>
        /// Processes the registration view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IRegistrationView ProcessRegistrationView(string processingMessage)
        {
            var view = new RegistrationView
            {
               
                ProcessingMessage=processingMessage
            };
            return view;
        }


        /// <summary>
        /// Processes the email verification view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IEmailVerificationView ProcessEmailVerificationView(string processingMessage)
        {
            var view = new EmailVerificationView
            {

                ProcessingMessage = processingMessage
            };
            return view;
        }





        /// <summary>
        /// Processes the password view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="Id">The identifier.</param>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public IPasswordView ProcessPasswordView(string processingMessage, int Id,string code)
        {
            var view = new PasswordView
            {
                userId = Id,
                ProcessingMessage = processingMessage,
                code=code

            };
            return view;
        }
    }
}
