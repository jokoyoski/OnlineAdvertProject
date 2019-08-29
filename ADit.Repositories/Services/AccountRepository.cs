using ADit.Interfaces;
using ADit.Repositories.DataAccess;
using ADit.Repositories.Factories;
using ADit.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADit.Repositories.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IAccountRepository" />
    public class AccountRepository : IAccountRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository"/> class.
        /// </summary>
        public AccountRepository()
            : this(null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public AccountRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? new DbContextFactory(null);
        }

        /// <summary>
        /// Gets the registration by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetRegistrationByEmail</exception>
        public IRegistration GetRegistrationByEmail(string email)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
                {
                    var aRecord = AccountQueries.getRegistrationByEmail(dbContext, email);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetRegistrationByEmail", e);
            }
        }


        /// <summary>C:\Users\Automata\source\repos\ADIT\ADit.Repositories\Services\AccountRepository.cs
        /// Sends the email.
        /// </summary>
        /// <param name="logOnView">The log on view.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetRegistrationByEmail</exception>
        public IRegistration GetUserByEmail(ILogOnView logOnView)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
                {
                    var aRecord = AccountQueries.getRegistrationByEmail(dbContext, logOnView.Email);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetRegistrationByEmail", e);
            }
        }


        /// <summary>
        /// Gets the user role actions.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetUserRoleIdCollection</exception>
        public IList<IUserRolesModel> GetUserRoleActions(string username)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
                {
                    var list = AccountQueries.GetUserRoleActionCollection(dbContext, username).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetUserRoleIdCollection", e);
            }
        }

        /// <summary>
        /// Gets the user role actions by identifier.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetUserRoleActionsById</exception>
        public IList<int> GetUserRoleActionsById(string email)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
                {
                    var list = AccountQueries.GetUserRoleActionCollectionId(dbContext, email).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetUserRoleActionsById", e);
            }
        }
        /// <summary>
        /// Gets the user role collections.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetUserRoleIdCollection</exception>
        public IList<IUserRolesModel> GetUserRoleCollections()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
                {
                    var list = AccountQueries.GetUserRolesCollection(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetUserRolesCollection", e);
            }
        }


        /// <summary>
        /// Gets the user registration.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetUserRegistration</exception>
        public IList<IUserModel> GetUserRegistration()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
                {
                    var list = AccountQueries.GetUserRegistration(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetUserRegistration", e);
            }
        }




        /// <summary>
        /// Checks the activation code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">CheckActivationCode</exception>
        public IUserActivationCode CheckActivationCode(string code)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
                {
                    var userActivationCode = AccountQueries.CheckActivationCode(dbContext, code);


                    return userActivationCode;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("CheckActivationCode", e);
            }
        }



        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <param name="userId">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">CheckActivationCode</exception>
        public IRegistration GetUserId(int userId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
                {
                    var list = AccountQueries.getUserById(dbContext, userId);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("CheckActivationCode", e);
            }
        }


        /// <summary>
        /// Saves the registration information.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <param name="registrationId">The registration identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">registrationInfo</exception>
        /// string SaveRegistrationInfo(IRegistrationView registrationInfo, out int registrationId);
        public string SaveRegistrationInfo(IRegistrationView registrationInfo)
        {
            if (registrationInfo == null)
            {
                throw new ArgumentNullException(nameof(registrationInfo));
            }

            var result = string.Empty;
            var newRecord = new UserRegistration
            {
                Password = registrationInfo.Password,
                FirstName = registrationInfo.FirstName,
                Email = registrationInfo.Email,
                Consent = registrationInfo.Consent,
                Lastname = registrationInfo.LastName,
                IsActive = false,
                PhoneNumber = registrationInfo.Phonenumber,
                DateCreated = DateTime.UtcNow,
                IsUserVerified = false
            };

            using (
                var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
            {
                dbContext.UserRegistrations.Add(newRecord);
                dbContext.SaveChanges();
            }

            return result;
            ;
        }

        /// <summary>
        /// Saves the user roles information.
        /// </summary>
        /// <param name="userRolesView">The user roles view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userRolesView</exception>
        public string SaveUserRolesInfo(IUserRolesView userRolesView)
        {
            if (userRolesView == null)
            {
                throw new ArgumentNullException(nameof(userRolesView));
            }

            var result = string.Empty;
            var newRecord = new UserAppRole
            {
                AppRoleId = userRolesView.UserRolesId,
                CreateByUserName = userRolesView.CreatedByName,
                DateCreated = DateTime.Now,
                Email = userRolesView.Email,

            };

            using (
                var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
            {
                dbContext.UserAppRoles.Add(newRecord);
                dbContext.SaveChanges();
            }

            return result;
            ;
        }

        /// <summary>
        /// Saves the password.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">registrationInfo</exception>
        public string SavePassword(IPasswordView registrationInfo)
        {
            var result = string.Empty;
            if (registrationInfo == null)
            {
                throw new ArgumentNullException(nameof(registrationInfo));
            }

            try
            {
                using (
                    var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
                {
                    var userinfo =
                        dbContext.UserRegistrations.SingleOrDefault(
                            x => x.UserRegistrationId == registrationInfo.userId);
                    var useractive =
                        dbContext.UserActivationCodes.SingleOrDefault(x => x.ActivationCode == registrationInfo.code);
                    useractive.IsUsed = true;
                    dbContext.SaveChanges();
                    userinfo.Password = registrationInfo.Password;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SavePassword - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
            ;
        }




        /// <summary>
        /// Checks the current roles.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="userRolesId">The user roles identifier.</param>
        /// <returns></returns>
        public bool CheckCurrentRoles(string email,int userRolesId)
        {
            

            
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var userinfo =
                        dbContext.UserAppRoles.SingleOrDefault(
                            x => x.AppRoleId == userRolesId && x.Email==email);
                   
                    if(userinfo==null)
                    {
                        return false;
                    }
                    return true;
                }
            
           
        }


        /// <summary>
        /// Updates the activation code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public string UpdateActivationCode(string code)
        {
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
                {
                    var userinfo = dbContext.UserActivationCodes.SingleOrDefault(x => x.ActivationCode == code);

                    if (userinfo != null)
                    {
                        var userData =
                            dbContext.UserRegistrations.SingleOrDefault(x =>
                                x.UserRegistrationId == userinfo.RegistrationId);

                        userData.IsUserVerified = true;
                        userData.DateVerified = DateTime.Now;
                        userData.IsActive = true;
                    }

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("UpdateActivationCode- {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }
            return result;
            ;
        }


        /// <summary>
        /// Creates the user role.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">registrationInfo</exception>
        public string CreateUserRole(IRegistrationView registrationInfo)
        {
            if (registrationInfo == null)
            {
                throw new ArgumentNullException(nameof(registrationInfo));
            }

            var result = string.Empty;
            var newRecord = new UserAppRole
            {
                Email = registrationInfo.Email,
                AppRoleId = 1, //User Role by default
                DateCreated = DateTime.Now
            };
            try
            {
                using (
                    var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
                {
                    dbContext.UserAppRoles.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveRegistrationInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
            ;
        }
        /// <summary>
        /// Deletes the user roles.
        /// </summary>
        /// <param name="userRolesId">The user roles identifier.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userRolesId</exception>
        /// <exception cref="ArgumentOutOfRangeException">Email</exception>
        /// <exception cref="ApplicationException">Repository SaveUserActivationCode</exception>
        public string DeleteUserRoles(string email, int userRolesId)
        {

            var result = string.Empty;
            if (userRolesId < 0)
            {
                throw new ArgumentNullException(nameof(userRolesId));
            }

            if (email == null)
            {
                throw new ArgumentOutOfRangeException(nameof(email));
            }
            try
            {
                using (
                    var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
                {
                    var userRoles = dbContext.UserAppRoles.FirstOrDefault(x => x.Email == email && x.AppRoleId == userRolesId);

                    dbContext.UserAppRoles.Remove(userRoles);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("DeleteUserRoles", e);
            }

            return result;
        }
        /// <summary>
        /// Saves the user activation code.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="activationCode">The activation code.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetRegistrationByEmail</exception>
        public string SaveUserActivationCode(int userId, string activationCode)
        {
            if (activationCode == null)
            {
                throw new ArgumentNullException(nameof(activationCode));
            }

            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId));
            }

            var result = string.Empty;

            var userActivationCode = new UserActivationCode
            {
                ActivationCode = activationCode,
                DateCreated = DateTime.Now,
                ExpirationDate = DateTime.Now.AddHours(24),
                IsUsed = false,
                RegistrationId = userId,
            };

            try
            {
                using (
                    var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
                {
                    dbContext.UserActivationCodes.Add(userActivationCode);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository SaveUserActivationCode", e);
            }

            return result;
        }


        /// <summary>
        /// Logs the user action.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="theAction">The action.</param>
        /// <param name="isGranted">if set to <c>true</c> [is granted].</param>
        public void LogUserAction(string userId, string theAction, bool isGranted)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId");
            }
            if (string.IsNullOrEmpty(theAction))
            {
                throw new ArgumentNullException("theAction");
            }
            try
            {
                using (
                    var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
                {
                    var actionLog = new ActionLog
                    {
                        Action = theAction,
                        ISGranted = isGranted,
                        LogDate = DateTime.Now,
                        UserEmail = userId,
                        DateStamp = DateTime.Now
                    };

                    dbContext.ActionLogs.Add(actionLog);

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"LogUserAction - {e.Message} , {(e.InnerException != null ? e.InnerException.Message : "")}");
            }
        }

        /// <summary>
        /// Logs the user activity.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="theActivity">The activity.</param>
        /// <param name="orderIdentifier">The order identifier.</param>
        public void LogUserActivity(string userId, string theActivity, string orderIdentifier)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException(nameof(userId));
            }
            if (string.IsNullOrEmpty(theActivity))
            {
                throw new ArgumentNullException(nameof(theActivity));
            }
            try
            {
                using (
                    var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
                {
                    var activity = new AppActivityLog
                    {
                        Activity = theActivity,
                        OrderIdentifier = orderIdentifier ?? "",
                        LogDate = DateTime.Now,
                        UserEmail = userId
                    };

                    dbContext.AppActivityLogs.Add(activity);

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"LogUserActivity - {e.Message} , {(e.InnerException != null ? e.InnerException.Message : "")}");
            }
        }

    }
}