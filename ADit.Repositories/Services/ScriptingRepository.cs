using System;
using ADit.Interfaces.ValueTypes;
using ADit.Repositories.DataAccess;
using ADit.Repositories.Factories;
using ADit.Interfaces;
using System.Collections.Generic;
using ADit.Repositories.Queries;
using System.Linq;
using System.Text;
using System.Data.Entity.Validation;

namespace ADit.Repositories.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IScriptingRepository" />
    public class ScriptingRepository : IScriptingRepository
    {
        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;


        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository" /> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public ScriptingRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? new DbContextFactory(null);
        }


        /// <summary>
        /// Saves the scripting detail admin.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="TvScriptingId">The tv scripting identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Repository.Save. Db Entity Validation Exception. Data not saved. Error: " +
        ///                                         sb.ToString()</exception>
        public string SaveScriptingDetailAdmin(IScriptingView view, out int TvScriptingId)
        {
            var result = string.Empty;


            var savingScriptingDetail = new TvScriptingDetail
            {
                
                ScripterDigitalField = view.ScriptingDigitalFileId,
                ScripterComment = view.Comment,
                UserComment = view.Comment,
                ScripterId = view.ScripterId,
                //AppRoleId = view.AppRoleId,
                UserId = view.UserId,
                //UserComment = view.Use,
                DateCreated = DateTime.Now,
                IsActive = true,
                IsApproved = false,
                DateApproved = DateTime.Now,
                DateUpdated = DateTime.Now
            };
            try
            {

                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {

                    dbContext.TvScriptingDetails.Add(savingScriptingDetail);
                    dbContext.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                List<String> lstErrors = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    string msg = string.Format(
                        "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name,
                        eve.Entry.State);

                    lstErrors.Add(msg);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        msg = string.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                        lstErrors.Add(msg);
                    }
                }

                if (lstErrors != null && lstErrors.Count() > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in lstErrors)
                    {
                        sb.Append(item + "; ");
                    }

                    throw new Exception("Repository.Save. Db Entity Validation Exception. Data not saved. Error: " +
                                        sb.ToString());
                }
            }


            catch (NotSupportedException e)
            {
            }
            TvScriptingId = savingScriptingDetail.TvScriptingId;
            return result;
            
        }


        /// <summary>
        /// Saves the scripting detail user.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="TvScriptingId">The tv scripting identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Repository.Save. Db Entity Validation Exception. Data not saved. Error: " +
        ///                                         sb.ToString()</exception>
        public string SaveScriptingDetailUser(IScriptingView view, out int TvScriptingId)
        {
            var result = string.Empty;


            var savingScriptingDetail = new TvScriptingDetail
            {

                UserDigitalFileId = view.ScriptingDigitalFileId,
                //AppRoleId = view.AppRoleId,
                Topic = view.Topic,
                UserComment = view.Comment,
                ScripterId = view.ScripterId,
                UserId = view.UserId,
                IsActive = true,
                IsApproved = false,
                DateCreated = DateTime.Now,
                ScripterComment = view.Comment,
                DateApproved = DateTime.Now,
                DateUpdated = DateTime.Now
            };
            try
            {

                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {

                    dbContext.TvScriptingDetails.Add(savingScriptingDetail);
                    dbContext.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                List<String> lstErrors = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    string msg = string.Format(
                        "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name,
                        eve.Entry.State);

                    lstErrors.Add(msg);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        msg = string.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                        lstErrors.Add(msg);
                    }
                }

                if (lstErrors != null && lstErrors.Count() > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in lstErrors)
                    {
                        sb.Append(item + "; ");
                    }

                    throw new Exception("Repository.Save. Db Entity Validation Exception. Data not saved. Error: " +
                                        sb.ToString());
                }
            }


            catch (NotSupportedException e)
            {
            }
            TvScriptingId = savingScriptingDetail.TvScriptingId;
            return result;

        }


        /// <summary>
        /// Gets the script transaction by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetScriptTransactionById</exception>
        public IScriptingDetailModel GetScriptTransactionById(int Id)
        {
            try {
                using (
                       var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.GetScriptDetailById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetScriptTransactionById", e);
            }

          
        }
    }
}
