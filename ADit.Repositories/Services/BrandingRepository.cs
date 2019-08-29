using ADit.Interfaces;
using ADit.Interfaces.ValueTypes;
using ADit.Repositories.DataAccess;
using ADit.Repositories.Factories;
using ADit.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;


namespace ADit.Repositories.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IBrandingRepository" />
    public class BrandingRepository : IBrandingRepository
    {
        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="BrandingRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public BrandingRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? new DbContextFactory(null);
        }

        #region Branding Material Price Setup
        /// <summary>
        /// Saves the material price.
        /// </summary>
        /// <param name="materialprice">The materialprice.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Repository.Save. Db Entity Validation Exception. Data not saved. Error: " +
        ///                                         sb.ToString()</exception>
        public string SaveMaterialPrice(IBrandingMaterialPriceView materialprice)
        {
            var result = string.Empty;

            var view = new BrandingMaterialPrice
            {
                BrandingMaterialId = materialprice.BrandingMaterialId,
                Amount = materialprice.Amount,
                Comment = materialprice.Comment,
                EffectiveDate = materialprice.EffectiveDate,
                DateInactive = null,
                IsActive = true,
                DateCreated = DateTime.Now
            };
            try
            {
                // calling our database 
                using (var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var Prevprice = dbContext.BrandingMaterialPrices.Where(x => x.BrandingMaterialId == materialprice.BrandingMaterialId);
                    if (Prevprice != null)
                    {
                        foreach (var j in Prevprice)
                        {
                            j.DateInactive = DateTime.Now;
                            j.IsActive = false;

                        }
                        dbContext.SaveChanges();
                    }
                    // calling changes
                    dbContext.BrandingMaterialPrices.Add(view);
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

            return result;
        }




        /// <summary>
        /// Deletes the branding material price.
        /// </summary>
        /// <param name="brandingMaterialPriceId">The branding material price identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">DeleteBrandingMaterialPrice</exception>
        /// <exception cref="ArgumentNullException">brandingMaterialPriceDetails</exception>
        public string DeleteBrandingMaterialPrice(int brandingMaterialPriceId)
        {
            if (brandingMaterialPriceId < 1)
            {
                throw new ArgumentOutOfRangeException("DeleteBrandingMaterialPrice");
            }

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var brandingMaterialPriceDetails =
                        dbContext.BrandingMaterialPrices.SingleOrDefault(x =>
                            x.BrandingMaterialPriceId == brandingMaterialPriceId);
                    if (brandingMaterialPriceDetails == null)
                        throw new ArgumentNullException(nameof(brandingMaterialPriceDetails));
                    brandingMaterialPriceDetails.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Branding Material Price - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Edits the branding material price.
        /// </summary>
        /// <param name="brandingMaterialPriceView">The branding material price view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// brandingMaterialPriceView
        /// or
        /// brandingMaterialDetails
        /// </exception>
        public string EditBrandingMaterialPrice(IBrandingMaterialPriceView brandingMaterialPriceView)
        {
            var result = string.Empty;
            if (brandingMaterialPriceView == null) throw new ArgumentNullException(nameof(brandingMaterialPriceView));
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var brandingMaterialDetails = dbContext.BrandingMaterialPrices.SingleOrDefault(x =>
                        x.BrandingMaterialPriceId == brandingMaterialPriceView.BrandingMaterialPriceId);
                    if (brandingMaterialDetails == null)
                        throw new ArgumentNullException(nameof(brandingMaterialDetails));

                    brandingMaterialDetails.Amount = brandingMaterialPriceView.Amount;
                    brandingMaterialDetails.BrandingMaterialId = brandingMaterialPriceView.BrandingMaterialId;
                    brandingMaterialDetails.Comment = brandingMaterialPriceView.Comment;

                    brandingMaterialDetails.DateInactive = brandingMaterialPriceView.DateInactive;
                    brandingMaterialDetails.EffectiveDate = brandingMaterialPriceView.EffectiveDate;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveOnlineExtraService - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        #endregion

        #region Saving Uploaded Branding Material Setup

       
        #endregion


        #region Brading Material Setup

        /// <summary>
        /// Saves the material information.
        /// </summary>
        /// <param name="brandingMaterialView">The branding material view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">AdminSaveMaterial</exception>
        public string SaveMaterialInfo(IBrandingMaterialView brandingMaterialView)
        {
            var result = string.Empty;
            if (brandingMaterialView == null)
            {
                throw new ArgumentException("AdminSaveMaterial");
            }


            var newRecord = new BrandingMaterial
            {
                Description = brandingMaterialView.Description,
                IsActive = true,
            };

            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    dbContext.BrandingMaterials.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveBrandingInfo -{0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }



        /// <summary>
        /// Deletes the branding material.
        /// </summary>
        /// <param name="brandingMaterialId">The branding material identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">brandingMaterialId</exception>
        /// <exception cref="ArgumentNullException">brandingMaterialsdetails</exception>
        public string DeleteBrandingMaterialInfo(int brandingMaterialId)
        {
            var result = string.Empty;
            if (brandingMaterialId < 1)
            {
                throw new ArgumentException(nameof(brandingMaterialId));
            }


            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var brandingMaterialsdetails =
                        dbContext.BrandingMaterials.SingleOrDefault(x => x.BrandingMaterialId == brandingMaterialId);
                    if (brandingMaterialsdetails == null)
                        throw new ArgumentNullException(nameof(brandingMaterialsdetails));
                    brandingMaterialsdetails.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteBrandingMaterial - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Deletes the branding material.
        /// </summary>
        /// <param name="brandingMaterialView">The branding material view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">brandingDetails</exception>
        public string DeleteBrandingMaterial(IBrandingMaterialView brandingMaterialView)
        {
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var brandingDetails = dbContext.BrandingMaterials.SingleOrDefault(x =>
                        x.BrandingMaterialId == brandingMaterialView.BrandingMaterialId);
                    if (brandingDetails == null) throw new ArgumentNullException(nameof(brandingDetails));
                    brandingDetails.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteBrandMaterial- {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Edits the material.
        /// </summary>
        /// <param name="brandingMaterialView">The branding material view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">brandingMaterialView</exception>
        /// <exception cref="ArgumentNullException">brandingMaterialViewDetails</exception>
        public string EditMaterial(IBrandingMaterialView brandingMaterialView)
        {
            var result = string.Empty;
            if (brandingMaterialView == null) throw new ArgumentException(nameof(brandingMaterialView));


            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var brandingMaterialViewDetails = dbContext.BrandingMaterials.SingleOrDefault(x =>
                        x.BrandingMaterialId == (brandingMaterialView.BrandingMaterialId));
                    if (brandingMaterialViewDetails == null)
                        throw new ArgumentNullException(nameof(brandingMaterialViewDetails));

                    brandingMaterialViewDetails.Description = brandingMaterialView.Description;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("EditMaterial - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }



        /// <summary>
        /// Gets the name of the branding material by.
        /// </summary>
        /// <param name="materialName">Name of the material.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">materialName</exception>
        /// <exception cref="ApplicationException">Repository GetBrandingMaterialByName</exception>
        public IBrandingMaterial GetBrandingMaterialByName(string materialName)
        {
            if (materialName == null)
            {
                throw new ArgumentNullException(nameof(materialName));
            }

            try
            {
                using (var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var list = BrandingQueries.GetBrandingMaterialByName(dbContext, materialName);
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetBrandingMaterialByName", e);
            }
        }


        #endregion



        #region Branding Transaction Attachment Setup
        /// <summary>
        /// Saves the branding transaction attachment information.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <param name="brandingTransactionId">The branding transaction identifier.</param>
        /// <returns></returns>
        public string saveBrandingTransactionAttachmentInfo(IBrandingView brandingView, int brandingTransactionId)
        {
            var result = string.Empty;


            var brandingTransactionAttachmentRecord = new BrandingTransactionAttachment
            {
                BrandingTransactionId = brandingTransactionId,
                DigitalFileId = brandingView.DesignDigitalFileId,
                IsActive = true
            };

            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    dbContext.BrandingTransactionAttachments.Add(brandingTransactionAttachmentRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("saveBrandingTransactionAttachmentInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }






        /// <summary>
        /// Gets the branding attachment transactions by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetBrandingAttachmentTransactionsById</exception>
        public IBrandingTransactionAttachment GetBrandingAttachmentTransactionsById(int transactionId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        BrandingQueries.GetBrandingTransactionAttachmentById(dbContext, transactionId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetBrandingAttachmentTransactionsById", e);
            }
        }

        /// <summary>
        /// Gets the branding attachment transactions.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetRadioStationPrice</exception>
        public IList<IBrandingAttachmentTransaction> GetBrandingAttachmentTransactions(int UserId, int transactionId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        BrandingQueries
                            .GetBrandingTransactionAttachmentTransactionById(dbContext, UserId, transactionId).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetBrandingAttachmentTransactions", e);
            }
        }


        /// <summary>
        /// Updates the branding transaction attachments.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">brandingTransactionAttachement</exception>
        public string UpdateBrandingTransactionAttachments(IBrandingView brandingView)
        {
            var result = string.Empty;
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var brandingTransactionAttachement =
                        dbContext.BrandingTransactionAttachments.FirstOrDefault(x =>
                            x.BrandingTransactionId == brandingView.BrandingTransactionId);

                    if (brandingTransactionAttachement == null)
                    {
                        throw new ArgumentNullException(nameof(brandingTransactionAttachement));
                    }


                    if (brandingView.DesignDigitalFileId > 0)
                    {
                        brandingTransactionAttachement.DigitalFileId = brandingView.DesignDigitalFileId;
                    }


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("UpdateBrandingTransactionAttachments - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        #endregion


        #region Branding Transaction Material Setup



        /// <summary>
        /// Gets the i branding transaction material by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetIBrandingTransactionMaterialById</exception>
        public IBrandingTransactionMaterial GetIBrandingTransactionMaterialById(int transactionId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        BrandingQueries.GetBrandingTransactionMaterialById(dbContext, transactionId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetIBrandingTransactionMaterialById", e);
            }
        }



        /// <summary>
        /// Updates the branding transaction material information.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">brandingTransaction</exception>
        /// <exception cref="Exception">Repository.Save. Db Entity Validation Exception. Data not saved. Error: " +
        /// sb.ToString()</exception>
        public string UpdateBrandingTransactionMaterialInfo(IBrandingView brandingView)
        {
            var result = string.Empty;
            try
            {
                using (var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var brandingTransaction = dbContext.BrandingTransactionMaterials.FirstOrDefault(x =>
                        x.BrandingTransactionId == brandingView.BrandingTransactionId);

                    if (brandingTransaction == null)
                    {
                        throw new ArgumentNullException(nameof(brandingTransaction));
                    }

                   
                    brandingTransaction.BrandingMaterialId = brandingView.BrandingMaterialId;
                    brandingTransaction.BrandingMaterialPriceId = brandingView.BrandingMaterialPriceId;
                    brandingTransaction.BrandingMaterialAmount = brandingView.BrandingMaterialAmount;
                    brandingTransaction.IsActive = true;


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

            return result;
        }


        /// <summary>
        /// Saves the branding transaction material information.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <param name="brandingTransactionId">The branding transaction identifier.</param>
        /// <returns></returns>
        public string saveBrandingTransactionMaterialInfo(IBrandingView brandingView, int brandingTransactionId)
        {
            var result = string.Empty;
            var brandingTransactionMaterialRecord = new BrandingTransactionMaterial
            {
                BrandingTransactionId = brandingTransactionId,
                BrandingMaterialId = brandingView.BrandingMaterialId,
                BrandingMaterialPriceId = brandingView.BrandingMaterialPriceId,
                BrandingMaterialAmount = brandingView.BrandingMaterialAmount,
                IsActive = true
            };

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.BrandingTransactionMaterials.Add(brandingTransactionMaterialRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveBrandingInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        #endregion


        #region Branding Transaction Color Setup



        /// <summary>
        /// Gets the color of the selected.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetSelectedColor</exception>
        /// #$
        public IList<IBrandingTransactionColor> GetSelectedColor(int transactionId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        BrandingQueries.GetSelectedColors(dbContext, transactionId).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetSelectedColor", e);
            }
        }


        /// <summary>
        /// Gets the selected color by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetSelectedColorById</exception>
        /// <exception cref="System.ApplicationException">GetSelectedColorById</exception>
        public IBrandingTransactionColor GetSelectedColorById(int transactionId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        BrandingQueries.GetSelectedColorById(dbContext, transactionId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetSelectedColorById", e);
            }
        }






        /// <summary>
        /// Saves the branding transaction color information.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <param name="brandingTransactionId">The branding transaction identifier.</param>
        /// <returns></returns>
        public string saveBrandingTransactionColorInfo(IBrandingView brandingView, int brandingTransactionId)
        {
            var result = string.Empty;

            if (brandingView.ColorId != null)
            {
                foreach (var colorId in brandingView.ColorId)
                {
                    var brandingTransactionColorRecord = new BrandingTransactionColor
                    {
                        BrandingTransactionId = brandingTransactionId,
                        ColorId = colorId,
                        IsActive = true
                    };

                    try
                    {
                        using (
                            var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                        {
                            dbContext.BrandingTransactionColors.Add(brandingTransactionColorRecord);
                            dbContext.SaveChanges();
                        }
                    }
                    catch (Exception e)
                    {
                        result = string.Format("SaveBrandingInfo - {0} , {1}", e.Message,
                            e.InnerException != null ? e.InnerException.Message : "");
                    }
                }



            }

            return result;
        }


        /// <summary>
        /// Updates the branding transaction color information.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <param name="brandingtransactioncolorId">The brandingtransactioncolor identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">brandingTransaction</exception>
        /// <exception cref="Exception">Repository.Save. Db Entity Validation Exception. Data not saved. Error: " +
        /// sb.ToString()</exception>
        public string UpdateBrandingTransactionColorInfo(IBrandingView brandingView, int brandingtransactioncolorId)
        {
            var result = string.Empty;

            foreach (var colorId in brandingView.ColorId)
            {
                
                
                var brandingTransactionColorRecord = new BrandingTransactionColor
                {
                    BrandingTransactionColorId = brandingtransactioncolorId,
                    BrandingTransactionId = brandingView.BrandingTransactionId,
                    ColorId = colorId,
                    IsActive = true
                };

                try
                {
                    using (
                        var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                    {
                        var ColorDetails =
                            dbContext.BrandingTransactionColors.FirstOrDefault(x =>
                                x.BrandingTransactionId == brandingTransactionColorRecord.BrandingTransactionId);
                        dbContext.BrandingTransactionColors.Remove(ColorDetails);
                        if (ColorDetails == null)
                        {
                            dbContext.BrandingTransactionColors.Add(brandingTransactionColorRecord);
                            ColorDetails.BrandingTransactionColorId = brandingtransactioncolorId;
                            ColorDetails.BrandingTransactionId = brandingView.BrandingTransactionId;
                            ColorDetails.ColorId = colorId;
                            ColorDetails.IsActive = true;
                            

                        }
                        else
                        {
                            dbContext.BrandingTransactionColors.Add(brandingTransactionColorRecord);

                        }
                   
                        dbContext.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    result = string.Format("SaveBrandingInfo - {0} , {1}", e.Message,
                        e.InnerException != null ? e.InnerException.Message : "");
                }
            }


            return result;
        }


        #endregion


        #region Branding Transaction Design Element Setup



        /// <summary>
        /// Gets the branding transaction design element by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetBrandingTransactionDesignElementById</exception>
        public IBrandingTransactionDesignElement GetBrandingTransactionDesignElementById(int transactionId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        BrandingQueries.GetBrandingTransactionDesignElementsById(dbContext, transactionId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetBrandingTransactionDesignElementById", e);
            }
        }




        /// <summary>
        /// Updates the branding transaction design element information.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">brandingTransaction</exception>
        /// <exception cref="Exception">Repository.Save. Db Entity Validation Exception. Data not saved. Error: " +
        /// sb.ToString()</exception>
        public string UpdateBrandingTransactionDesignElementInfo(IBrandingView brandingView)
        {
            var result = string.Empty;
            try
            {
                using (var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var brandingTransaction = dbContext.BrandingTransactionDesignElements.FirstOrDefault(x =>
                        x.BrandingTransactionId == brandingView.BrandingTransactionId);

                    if (brandingTransaction == null)
                    {
                        throw new ArgumentNullException(nameof(brandingTransaction));
                    }
 
                    brandingTransaction.DesignElementId = brandingView.DesignElementId;
                    brandingTransaction.DesignElementPriceId = brandingView.DesignElementPriceId;
                    brandingTransaction.DesignElementAmount = brandingView.DesignElementAmount;
                    brandingTransaction.IsActive = true;


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

            return result;
        }


        
        /// <summary>
        /// Saves the branding transaction design element information.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <param name="brandingTransactionId">The branding transaction identifier.</param>
        /// <returns></returns>
        public string saveBrandingTransactionDesignElementInfo(IBrandingView brandingView, int brandingTransactionId)
        {
            var result = string.Empty;
            var brandingTransactionDesignElementRecord = new BrandingTransactionDesignElement
            {
                BrandingTransactionId = brandingTransactionId,
                DesignElementId = brandingView.DesignElementId,
                DesignElementPriceId = brandingView.DesignElementPriceId,
                DesignElementAmount = brandingView.DesignElementAmount,
                IsActive = true
            };

            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    dbContext.BrandingTransactionDesignElements.Add(brandingTransactionDesignElementRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveBrandingInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        #endregion



        #region Branding Transaction Setup

        /// <summary>
        /// Saves the branding transaction information.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <param name="brandingTransactionId">The branding transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">brandingView</exception>
        public string saveBrandingTransactionInfo(IBrandingView brandingView, out int brandingTransactionId)
        {
            var result = string.Empty;
            if (brandingView == null) throw new ArgumentNullException(nameof(brandingView));


            var newRecord = new BrandingTransaction
            {
                OrderTitle = brandingView.OrderTitle,
                BrandingTransactionId = brandingView.BrandingTransactionId,
                OrderId = brandingView.OrderId,
                OtherColor = brandingView.OtherColor,
                AdditionalInformation = brandingView.AdditionalInformation,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                TransactionStatusCode = "A",
                UserId = brandingView.UserId,
                TotalAmount = brandingView.TotalAmount,
                //IsActive = true
            };

            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    dbContext.BrandingTransactions.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("saveBrandingTransactionInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            brandingTransactionId = newRecord.BrandingTransactionId;

            return result;
        }



     

        /// <summary>
        /// Updates the branding transaction.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">brandingTransaction</exception>
        /// <exception cref="Exception">Repository.Save. Db Entity Validation Exception. Data not saved. Error: " +
        /// sb.ToString()</exception>
        public string UpdateBrandingTransaction(IBrandingView brandingView)
        {
            var result = string.Empty;
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var brandingTransaction = dbContext.BrandingTransactions.FirstOrDefault(x =>
                        x.BrandingTransactionId == brandingView.BrandingTransactionId);

                    if (brandingTransaction == null)
                    {
                        throw new ArgumentNullException(nameof(brandingTransaction));
                    }

                    brandingTransaction.OrderTitle = brandingView.OrderTitle;

                    brandingTransaction.OtherColor = brandingView.OtherColor;
                    brandingTransaction.AdditionalInformation = brandingView.AdditionalInformation;
                    brandingTransaction.DateCreated = DateTime.Now;
                    brandingTransaction.DateModified = DateTime.Now;
                    brandingTransaction.TransactionStatusCode = "A";
                    brandingTransaction.UserId = brandingView.UserId;
                    brandingTransaction.TotalAmount = brandingView.TotalAmount;
                    brandingTransaction.UserId = brandingView.UserId;
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

            return result;
        }


       

        /// <summary>
        /// Gets the active branding transaction.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">getActiveBrandingTransaction</exception>
        public IList<IBrandingTransaction> getActiveBrandingTransaction(int orderNumber)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        BrandingQueries.GetActiveBrandingTransaction(dbContext, orderNumber).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("getActiveBrandingTransaction", e);
            }
        }


        /// <summary>
        /// Gets the transaction details.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">getActiveBrandingTransaction</exception>
        public IBrandingTransaction GetTransactionDetails(int transactionId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        BrandingQueries.GetBrandingTransactionDetail(dbContext, transactionId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("getActiveBrandingTransaction", e);
            }
        }


        /// <summary>
        /// Gets all branding transaction.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository BrandingTransactions</exception>
        public IList<IBrandingTransaction> GetAllBrandingTransaction()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        BrandingQueries.GetBrandingTransactions(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository BrandingTransactions", e);
            }
        }


        //gets the Id info to dispaly for the first order made by the user 
        /// <summary>
        /// Gets the branding transaction.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetRadioStationPrice</exception>
        public IBrandingTransaction GetBrandingTransaction(int SentToId, int transactionId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        BrandingQueries.GetBrandingTransactionById(dbContext, SentToId, transactionId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetRadioStationPrice", e);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public string DeleteBrandOrder(int transactionId)
        {
            if (transactionId <= 0)
            {
                throw new ArgumentNullException(nameof(transactionId));
            }
            var result = string.Empty;


            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var brandTransaction =
                        dbContext.BrandingTransactions.FirstOrDefault(x =>
                            x.BrandingTransactionId == transactionId);
                    if (brandTransaction == null)
                    {
                        throw new ArgumentNullException(nameof(brandTransaction));
                    }

                    brandTransaction.TransactionStatusCode = "D";
                    dbContext.SaveChanges();



                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteBrandtOrder- {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }

        public void ChangeOrderStatus(int transactionId, int OrderId)
        {

            if(OrderId<1)
            {
                throw new ArgumentNullException("Order Id is null");
            }


            if (transactionId < 1)
            {
                throw new ArgumentNullException("Order Id is null");
            }
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var Order = dbContext.Orders.FirstOrDefault(x => x.OrderId == OrderId);
                    Order.OrderStatusCode = "I";
                    var orderFulfilment = dbContext.OrderFulfilments.FirstOrDefault(x => x.ServiceTransactionId == transactionId);
                    orderFulfilment.FulfilmentStatusCode = "SP";

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetRadioStationPrice", e);
            }
        }


        #endregion




    }
}