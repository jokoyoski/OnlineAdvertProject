namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAccountService
    {

        string DeleteUserRoles(string email, int userRolesId);
        /// <summary>
        /// Deletes the user roles.
        /// </summary>
        /// <param name="userRolesView">The user roles view.</param>
        /// <returns></returns>
        string SaveUserRoles(IUserRolesView userRolesView);
        /// <summary>
        /// Gets the user rolesby email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        IUserRolesView GetUserRolesbyEmail(string email, string processingMessage);
        /// <summary>
        /// Gets the user registration.
        /// </summary>
        /// <returns></returns>
        IUserListView GetUserRegistration(string Email,string FirstName);
        /// <summary>
        /// Gets the activation status.
        /// </summary>
        /// <param name="logOnView">The log on view.</param>
        /// <returns></returns>
        bool GetActivationStatus(ILogOnView logOnView);

        /// <summary>
        /// Gets the forget password view.
        /// </summary>
        /// <returns></returns>
        IEmailVerificationView GetForgetPasswordView(string processingMessage);

        /// <summary>
        /// Processes the confirm activation code.
        /// </summary>
        /// <param name="code">The code.</param>
        string ProcessConfirmActivationCode(string code);

        /// <summary>
        /// Saves the password.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <returns></returns>
        string SavePassword(IPasswordView registrationInfo);

        /// <summary>
        /// Checks the code validity.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        IPasswordView CheckCodeValidity(string code);

        /// <summary>
        /// Processes the forget password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        string ProcessForgetPassword(string email);


        /// <summary>
        /// Gets the registration view.
        /// </summary>
        /// <returns></returns>
        IRegistrationView GetRegistrationView();

        /// <summary>
        /// Processes the registration information.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <returns></returns>
        IRegistrationView ProcessRegistrationInfo(IRegistrationView registrationInfo);

        /// <summary>
        /// Gets the log on view.
        /// </summary>
        /// <param name="infoMessage">The information message.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        ILogOnView GetLogOnView(string infoMessage, string errorMessage, string userName, string returnUrl);

        /// <summary>
        /// Signs the in.
        /// </summary>
        /// <param name="logonModel">The logon model.</param>
        /// <returns></returns>
        bool SignIn(ILogOnView logonModel);

        /// <summary>
        /// Signs the off.
        /// </summary>
        void SignOff();

        /// <summary>
        /// Logs the activity.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="theActivity">The activity.</param>
        /// <param name="orderIdentifier">The order identifier.</param>
        void LogActivity(string userId, string theActivity, string orderIdentifier);
    }
}