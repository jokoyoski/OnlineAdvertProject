using System.Collections.Generic;

namespace ADit.Interfaces
{
    public interface IAccountViewsModelFactory 
    {

        /// <summary>
        /// Creates the user roles view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        string CreateUserRolesView(string processingMessage);
        /// <summary>
        /// Creates the user roles view.
        /// </summary>
        /// <param name="userActiveRoles">The user active roles.</param>
        /// <param name="userRolesList">The user roles list.</param>
        /// <returns></returns>
        IUserRolesView CreateUserRolesView(IList<IUserRolesModel> userActiveRoles, IList<IUserRolesModel> userRolesList,string email,string processingMessage);
        /// <summary>
        /// Creates the user registration view.
        /// </summary>
        /// <param name="userList">The user list.</param>
        /// <returns></returns>
        IUserListView CreateUserRegistrationView(IList<IUserModel> userList,string Email,string FirstName);
        /// <summary>
        /// Processes the email verification view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmailVerificationView ProcessEmailVerificationView(string processingMessage);

        /// <summary>
        /// Creates the forget password view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmailVerificationView CreateForgetPasswordView(string processingMessage);

        /// <summary>
        /// Processes the password view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        IPasswordView ProcessPasswordView(string processingMessage,int userId,string code);



        /// <summary>
        /// Processes the registration view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IRegistrationView ProcessRegistrationView(string processingMessage);

        /// <summary>
        /// Creates the registration view.
        /// </summary>
        /// <param name="aboutUsSourceCollection">The about us source collection.</param>
        /// <returns>Returns Registration view model</returns>
        IRegistrationView CreateRegistrationView();

        /// <summary>
        /// Creates the updated registraion view.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="aboutUsSourceCollection">The about us source collection.</param>
        /// <returns></returns>
        IRegistrationView CreateUpdatedRegistraionView(IRegistrationView registrationInfo, string processingMessage);

        /// <summary>
        /// Creates the log on view.
        /// </summary>
        /// <param name="infoMessage">The information message.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        ILogOnView CreateLogOnView(string infoMessage, string errorMessage, string userName, string returnUrl);


    }
}
