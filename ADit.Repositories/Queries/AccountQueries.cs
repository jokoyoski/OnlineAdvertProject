using System.Linq;
using ADit.Interfaces;
using ADit.Repositories.DataAccess;
using ADit.Repositories.Models;
using System.Collections.Generic;

namespace ADit.Repositories.Queries
{
    /// <summary>
    /// 
    /// </summary>
    internal static class AccountQueries
    {
        /// <summary>
        /// Gets the registration by user identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        internal static IRegistration getRegistrationByEmail(ADitEntities db, string email)
        {
            var result = (from d in db.UserRegistrations
                where d.Email.Equals(email)
                select new RegistrationRepModel
                {
                    Email = d.Email,
                    FirstName = d.FirstName,
                    LastName = d.Lastname,
                    Phonenumber = d.PhoneNumber,
                    UserRegistrationId = d.UserRegistrationId,
                    Password = d.Password,
                    IsUserVerified = d.IsUserVerified
                }).FirstOrDefault();

            var a = result;
            return result;
        }




        /// <summary>
        /// Gets the user registration.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        internal static IEnumerable<IUserModel> GetUserRegistration (ADitEntities db)
        {
            var result = (from d in db.UserRegistrations
                       
                          select new UserModel
                          {
                              Email = d.Email,
                              FirstName = d.FirstName,
                              LastName = d.Lastname,
                              PhoneNumber = d.PhoneNumber,
                              UserRegistrationId = d.UserRegistrationId,

                             

                          }).OrderBy(x=>x.UserRegistrationId);

            var a = result;
            return result;
        }








        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IRegistration getUserById(ADitEntities db, int Id)
        {
            var result = (from d in db.UserRegistrations
                where d.UserRegistrationId.Equals(Id)
                select new RegistrationRepModel
                {
                    Email = d.Email,
                    FirstName = d.FirstName,
                    LastName = d.Lastname,
                    Phonenumber = d.PhoneNumber,
                    UserRegistrationId = d.UserRegistrationId,
                  
                    Password = d.Password,
                  
                    IsUserVerified = d.IsUserVerified
                }).FirstOrDefault();

            var a = result;
            return result;
        }

        /// <summary>
        /// Checks the activation code.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        internal static IUserActivationCode CheckActivationCode(ADitEntities db, string code)
        {
            var result = (from d in db.UserActivationCodes
                where d.ActivationCode.Equals(code)
                where d.IsUsed == false
              where d.ExpirationDate > System.DateTime.Now
                select new UserActivationCodeModel
                {
                    RegistrationId = d.RegistrationId,
                    ActivationCode = d.ActivationCode,
                    ExpirationDate = d.ExpirationDate,
                    IsUsed = d.IsUsed
                }).FirstOrDefault();

           
            return result;
        }

        /// <summary>
        /// Gets the user role action collection.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        internal static IEnumerable<IUserRolesModel> GetUserRoleActionCollection(ADitEntities db, string username)
        {
           
           
            var result = (from d in db.UserAppRoles
                          where d.Email == username

                          join s in db.AppRoles on d.AppRoleId equals s.AppRoleId

                          select new UserRolesModel
                          {UserRolesId=s.AppRoleId,
                              UserRolesDescription=s.Action
                          }


                );
            return result;
        }






        





        /// <summary>
        /// Gets the user roles collection.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IUserRolesModel> GetUserRolesCollection(ADitEntities db)
        {


            var result = (from d in db.AppRoles
                       

                          

                          select new UserRolesModel
                          {
                              UserRolesDescription = d.Action,
                              UserRolesId=d.AppRoleId
                          }

                );
            return result;
        }

        /// <summary>
        /// Gets the user role action collection identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<int> GetUserRoleActionCollectionId(ADitEntities db, string email)
        {
            var result = (from d in db.UserAppRoles
               // join s in db.AppRoles on d.AppRoleId equals s.AppRoleId
                where d.Email== email
                select d.AppRoleId);
            return result;
        }
    }
}