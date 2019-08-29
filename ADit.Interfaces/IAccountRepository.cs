using System.Collections.Generic;

namespace ADit.Interfaces
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Checks the current roles.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="userRolesId">The user roles identifier.</param>
        /// <returns></returns>
        bool CheckCurrentRoles(string email, int userRolesId);
        /// <summary>
        /// Deletes the user roles.
        /// </summary>
        /// <param name="userRolesId">The user roles identifier.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        string DeleteUserRoles(string email,int userRolesId);
        /// <summary>
        /// Saves the user roles information.
        /// </summary>
        /// <param name="userRolesView">The user roles view.</param>
        /// <returns></returns>
        string SaveUserRolesInfo(IUserRolesView userRolesView);
        /// <summary>
        /// Gets the user role collections.
        /// </summary>
        /// <returns></returns>
        IList<IUserRolesModel> GetUserRoleCollections();
        /// <summary>
        /// Gets the user registration.
        /// </summary>
        /// <returns></returns>
        IList<IUserModel> GetUserRegistration();
        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IRegistration GetUserId(int Id);


        /// <summary>
        /// Saves the password.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <returns></returns>
        string SavePassword(IPasswordView registrationInfo);


        /// <summary>
        /// Updates the activation code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        string UpdateActivationCode(string code);


        /// <summary>
        /// Checks the activation code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        IUserActivationCode CheckActivationCode(string code);


        /// <summary>
        /// Saves the user activation code.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="activationCode">The activation code.</param>
        /// <returns></returns>
        string SaveUserActivationCode(int userId, string activationCode);


        /// <summary>
        /// Gets the registration information by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        // IRegistration GetRegistrationByUserId(string userId);

        /// <summary>
        /// Gets the registration by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        IRegistration GetRegistrationByEmail(string email);

        /// <summary>
        /// Saves the registration information.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <param name="registrationId">The registration identifier.</param>
        /// <returns></returns>
        string SaveRegistrationInfo(IRegistrationView registrationInfo);

        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="logOnView">The log on view.</param>
        /// <returns></returns>
        //string SendEmail(IEmailDetail registrationRequestEmail);

        IRegistration GetUserByEmail(ILogOnView logOnView);


        /// <summary>
        /// Gets the user role actions.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        IList<IUserRolesModel> GetUserRoleActions(string username);

        /// <summary>
        /// Creates the user role.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <returns></returns>
        string CreateUserRole(IRegistrationView registrationInfo);


        /// <summary>
        /// Gets the user role actions by identifier.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        IList<int> GetUserRoleActionsById(string email);

        /// <summary>
        /// Logs the user action.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="theAction">The action.</param>
        /// <param name="isGranted">if set to <c>true</c> [is granted].</param>
        void LogUserAction(string userId, string theAction, bool isGranted);

        /// <summary>
        /// Logs the user activity.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="theActivity">The activity.</param>
        /// <param name="orderIdentifier">The order identifier.</param>
        void LogUserActivity(string userId, string theActivity, string orderIdentifier);
    }
}
