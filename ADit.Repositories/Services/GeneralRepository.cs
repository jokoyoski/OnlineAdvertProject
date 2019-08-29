using System;
using System.Collections.Generic;
using System.Linq;
using ADit.Interfaces;
using ADit.Repositories.DataAccess;
using ADit.Interfaces.ValueTypes;
using System.Data.Entity.Validation;
using System.Text;

namespace ADit.Repositories.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IGeneralRepository" />
    public class GeneralRepository : IGeneralRepository
    {
        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public GeneralRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        #region Apcon Type Setup

        /// <summary>
        /// Saves the apcon.
        /// </summary>
        /// <param name="apconInfo">The apcon information.</param>
        /// <returns></returns>
        public string SaveApcon(IApconApprovalView apconInfo)
        {
            var result = string.Empty;

            var view = new ApconApprovalType
            {
                Description = apconInfo.Description,

                IsActive = true

            };
            try
            {
                // calling our database 
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    // calling changes
                    dbContext.ApconApprovalTypes.Add(view);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("view - {0} , {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : "");
            }

            //MaterialProductionPriceId = productionInfo.MaterialProductionPriceId;
            return result;
        }


        /// <summary>
        /// Edits the type of the apcon approval.
        /// </summary>
        /// <param name="apconview">The apconview.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">apconview
        /// or
        /// ApconView</exception>
        public string EditApconApprovalType(IApconApprovalView apconview)
        {
            var result = string.Empty;

            if (apconview == null)
            {
                throw new ArgumentNullException(nameof(apconview));
            }
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var ApconView = dbContext.ApconApprovalTypes.SingleOrDefault(x => x.ApconApprovalTypeId == apconview.ApconApprovalTypeId);
                    if (ApconView == null) throw new ArgumentNullException(nameof(ApconView));
                    ApconView.ApconApprovalTypeId = apconview.ApconApprovalTypeId;
                    ApconView.Description = apconview.Description;
                    ApconView.IsActive = true;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("EditApconApprovalType - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }


        /// <summary>
        /// Deletes the type of the apcon approval.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Id</exception>
        /// <exception cref="ApplicationException">Id</exception>
        public string DeleteApconApprovalType(int Id)
        {

            if (Id < 1)
            {
                throw new ArgumentOutOfRangeException("Id");
            }
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var apconview = dbContext.ApconApprovalTypes.SingleOrDefault(x => x.ApconApprovalTypeId.Equals(Id));
                    if (apconview == null)
                    {
                        throw new ApplicationException("Id");
                    }
                    apconview.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete Apcon Approval Type- {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }

#endregion

        #region Apcon Price Setup

        /// <summary>
        /// Saves the apcon price.
        /// </summary>
        /// <param name="apconInfo">The apcon information.</param>
        /// <returns></returns>
        public string SaveApconPrice(IApconApprovalTypePriceView apconInfo)
        {
            var result = string.Empty;

          
            var view = new ApconApprovalTypePrice
            {
                ApconApprovalTypeId = apconInfo.ApconApprovalTypeId,

                Amount = apconInfo.Amount,
                Comment = apconInfo.Comment,
                EffectiveDate = apconInfo.EffectiveDate,
                DateInactive = null,
                IsActive = true,
                DateCreated = DateTime.Now
            };
            try
            {
                // calling our database 
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                  var Prevapcon = dbContext.ApconApprovalTypePrices.Where(x => x.ApconApprovalTypeId == apconInfo.ApconApprovalTypeId);
                   

                    if (Prevapcon!=null)
                    {
                        foreach (var j in Prevapcon)
                        {
                            j.DateInactive = DateTime.Now;
                            j.IsActive = false;
                          
                        }
                        dbContext.SaveChanges();
                    }
                    // calling changes
                    dbContext.ApconApprovalTypePrices.Add(view);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("view - {0} , {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : "");
            }

            //MaterialProductionPriceId = productionInfo.MaterialProductionPriceId;
            return result;
        }


        /// <summary>
        /// Edits the apcon approval type price.
        /// </summary>
        /// <param name="apconPrice">The apcon price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">apconPrice
        /// or
        /// ApconPrice</exception>
        public string EditApconApprovalTypePrice(IApconApprovalTypePriceView apconPrice)
        {
            var result = string.Empty;
            if (apconPrice == null)
            {
                throw new ArgumentNullException(nameof(apconPrice));
            }

            try
            {
                using (
                   var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var ApconPrice = dbContext.ApconApprovalTypePrices.SingleOrDefault(x => x.ApconApprovalTypePriceId == apconPrice.ApconApprovalTypePriceId);
                    if (ApconPrice == null)
                    {
                        throw new ArgumentNullException(nameof(ApconPrice));
                    }

                    ApconPrice.ApconApprovalTypePriceId = apconPrice.ApconApprovalTypePriceId;
                    ApconPrice.ApconApprovalTypeId = apconPrice.ApconApprovalTypeId;

                    ApconPrice.Amount = apconPrice.Amount;
                    ApconPrice.Comment = apconPrice.Comment;

                    ApconPrice.EffectiveDate = apconPrice.EffectiveDate;
                    ApconPrice.DateInactive = apconPrice.DateInactive;

                    dbContext.SaveChanges();
                    ApconPrice.IsActive = true;
                }


            }
            catch (Exception e)
            {
                result = string.Format("EditApconApprovalTypePrice - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }

            return result;
        }

        /// <summary>
        /// Deletes the apcon approval type price.
        /// </summary>
        /// <param name="apconPrice">The apcon price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">ApconPrice</exception>
        public string DeleteApconApprovalTypePrice(int apconPrice)
        {
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var ApconPrice = dbContext.ApconApprovalTypePrices.SingleOrDefault(x => x.ApconApprovalTypePriceId.Equals(apconPrice));
                    if (ApconPrice == null) throw new ArgumentNullException(nameof(ApconPrice));
                    ApconPrice.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteApconApprovalTypePrice - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }


        #endregion


        #region Radio Service Price Setup

        /// <summary>
        /// Saves the radio service price.
        /// </summary>
        /// <param name="radioService">The radio service.</param>
        /// <returns></returns>
        public string SaveRadioServicePrice(IRadioServicePriceList radioService)
        {
            var result = string.Empty;

            var view = new RadioServicePrice
            {

                RadioId = radioService.RadioId,
                TimingId = radioService.TimingId,
                MaterialTypeId = radioService.MaterialTypeId,
                Amount = radioService.Amount,
                DateEffective = radioService.DateEffective,
                DateInActive = null,
                IsActive = true,
                DateCreated = DateTime.Now,
                TimeBeltId = radioService.TimingBeltId
            };
            try
            {
                // calling our database 
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var Prevprice = dbContext.RadioServicePrices.FirstOrDefault(x => x.RadioId == radioService.RadioId && radioService.TimingId == x.TimingId && radioService.MaterialTypeId == x.MaterialTypeId && radioService.TimingBeltId == x.TimeBeltId);
                    if (Prevprice != null)
                    {
                        Prevprice.DateInActive = DateTime.Now;
                        Prevprice.IsActive = false;
                        dbContext.SaveChanges();
                    }
                    // calling changes
                    dbContext.RadioServicePrices.Add(view);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("view - {0} , {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : "");
            }

            //MaterialProductionPriceId = productionInfo.MaterialProductionPriceId;
            return result;
        }




        /// <summary>
        /// Edits the radio service price.
        /// </summary>
        /// <param name="Price">The price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Price
        /// or
        /// RadioPrice</exception>
        public string EditRadioServicePrice(IRadioServicePriceList Price)
        {
            var result = string.Empty;
            if (Price == null)
            {
                throw new ArgumentNullException(nameof(Price));
            }

            try
            {
                using (
                   var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var RadioPrice = dbContext.RadioServicePrices.SingleOrDefault(x => x.Id == Price.Id);
                    if (RadioPrice == null)
                    {
                        throw new ArgumentNullException(nameof(RadioPrice));
                    }

                    RadioPrice.Id = Price.Id;
                    RadioPrice.RadioId = Price.RadioId;
                    RadioPrice.TimingId = Price.TimingId;
                  RadioPrice.MaterialTypeId = Price.MaterialTypeId;
                    RadioPrice.Amount = Price.Amount;
                    

                    RadioPrice.DateEffective = Price.DateEffective;
                    RadioPrice.DateInActive = Price.DateInActive;
                    RadioPrice.IsActive = true;
                    RadioPrice.TimeBeltId = Price.TimingBeltId;
                    dbContext.SaveChanges();
                    
                }


            }
            catch (Exception e)
            {
                result = string.Format("EditRadioServicePrice - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }

            return result;
        }

      

        /// <summary>
        /// Deletes the radio service price.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">radioPrice</exception>
        public string DeleteRadioServicePrice(int Id)
        {
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var radioPrice = dbContext.RadioServicePrices.SingleOrDefault(x => x.Id.Equals(Id));
                    if (radioPrice == null) throw new ArgumentNullException(nameof(radioPrice));
                    radioPrice.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteRadioServicePrice - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }


        #endregion

        #region Material Scripting Price Setup

        /// <summary>
        /// Edits the material scripting price.
        /// </summary>
        /// <param name="materialScriptingPrice">The material scripting price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">materialScriptingPrice
        /// or
        /// MaterialScriptingPrice</exception>
        /// <exception cref="Exception">Repository.Save. Db Entity Validation Exception. Data not saved. Error: " +
        ///                                         sb.ToString()</exception>
        public string EditMaterialScriptingPrice(IMaterialScriptingPriceView materialScriptingPrice)
        {
            var result = string.Empty;
            if (materialScriptingPrice == null)
            {
                throw new ArgumentNullException(nameof(materialScriptingPrice));
            }

            try
            {
                using (
                   var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var MaterialScriptingPrice = dbContext.MaterialScriptingPrices.SingleOrDefault(x => x.MaterialScriptingPriceId == materialScriptingPrice.MaterialScriptingPriceId);
                    if (MaterialScriptingPrice == null)
                    {
                        throw new ArgumentNullException(nameof(MaterialScriptingPrice));
                    }

                    MaterialScriptingPrice.MaterialScriptingPriceId = materialScriptingPrice.MaterialScriptingPriceId;
                    MaterialScriptingPrice.MaterialTypeId = materialScriptingPrice.MaterialTypeId;
                    MaterialScriptingPrice.ServiceTypeCode = materialScriptingPrice.ServiceTypeCode;
                    MaterialScriptingPrice.Amount = materialScriptingPrice.Amount;
                    MaterialScriptingPrice.Comment = materialScriptingPrice.Comment;
                    // MaterialScriptingPrice.DateCreated = materialScriptingPrice.DateCreated;
                    MaterialScriptingPrice.IsActive = true;
                    MaterialScriptingPrice.EffectiveDate = materialScriptingPrice.EffectiveDate;
                    MaterialScriptingPrice.DateInactive = materialScriptingPrice.DateInactive;

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
        /// Deletes the material scripting price.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">ScriptingPrice</exception>
        public string DeleteMaterialScriptingPrice(int Id)
        {
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var ScriptingPrice = dbContext.MaterialScriptingPrices.SingleOrDefault(x => x.MaterialScriptingPriceId.Equals(Id));
                    if (ScriptingPrice == null) throw new ArgumentNullException(nameof(ScriptingPrice));
                    ScriptingPrice.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            { 
                result = string.Format("DeleteMaterialScriptingPrice - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }


        #endregion


        #region Material Production Price Setup
        /// <summary>
        /// Edits the material production price.
        /// </summary>
        /// <param name="materialProductionPrice">The material production price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">materialProductionPrice
        /// or
        /// MaterialProductionPrice</exception>
        public string EditMaterialProductionPrice(IMaterialProductionPriceView materialProductionPrice)
        {
            var result = string.Empty;
            if (materialProductionPrice == null)
            {
                throw new ArgumentNullException(nameof(materialProductionPrice));
            }

            try
            {
                using (
                   var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var MaterialProductionPrice = dbContext.MaterialProductionPrices.SingleOrDefault(x => x.MaterialProductionPriceId == materialProductionPrice.MaterialProductionPriceId);
                    if (MaterialProductionPrice == null)
                    {
                        throw new ArgumentNullException(nameof(MaterialProductionPrice));
                    }

                    MaterialProductionPrice.MaterialProductionPriceId = materialProductionPrice.MaterialProductionPriceId;
                    MaterialProductionPrice.MaterialTypeId = materialProductionPrice.MaterialTypeId;
                    MaterialProductionPrice.ServiceTypeCode = materialProductionPrice.ServiceTypeCode;
                    MaterialProductionPrice.Amount = materialProductionPrice.Amount;
                    MaterialProductionPrice.Comment = materialProductionPrice.Comment;

                    MaterialProductionPrice.IsActive = true;
                    MaterialProductionPrice.EffectiveDate = materialProductionPrice.EffectiveDate;
                    MaterialProductionPrice.DateInactive = materialProductionPrice.DateInactive;

                    dbContext.SaveChanges();
                }


            }
            catch (Exception e)
            {
                result = string.Format("EditMaterialProductionPrice - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }

            return result;
        }


        /// <summary>
        /// Deletes the material production price.
        /// </summary>
        /// <param name="productionPrice">The production price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">ProductionPrice</exception>
        public string DeleteMaterialProductionPrice(int productionPrice)
        {
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var ProductionPrice = dbContext.MaterialProductionPrices.SingleOrDefault(x => x.MaterialProductionPriceId.Equals(productionPrice));
                    if (ProductionPrice == null) throw new ArgumentNullException(nameof(ProductionPrice));
                    ProductionPrice.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteMaterialProductionPrice - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }


#endregion


        /// <summary>
        /// Edits the color.
        /// </summary>
        /// <param name="colorView">The color view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// colorView
        /// or
        /// colorDetails
        /// </exception>
        public string EditColor(IColorView colorView)
        {
            var result = string.Empty;
            if (colorView == null) throw new ArgumentNullException(nameof(colorView));
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var colorDetails = dbContext.Colors.SingleOrDefault(x => x.ColorId == colorView.ColorId);
                    if (colorDetails == null) throw new ArgumentNullException(nameof(colorDetails));

                    colorDetails.Description = colorView.Description;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveColor - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }



        /// <summary>
        /// Gets the radio serviceprice.
        /// </summary>
        /// <param name="radioServicePriceList">The radio service price list.</param>
        /// <returns></returns>
        public bool CheckRadioServiceprice(IRadioServicePriceList radioServicePriceList)
        {
            var result = string.Empty;
            if (radioServicePriceList == null)
            {
                throw new ArgumentNullException(nameof(radioServicePriceList));
            }
            using (
               var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
            {
                var RadioPrice = dbContext.RadioServicePrices.SingleOrDefault(x => x.MaterialTypeId == radioServicePriceList.TimingBeltId && x.TimingId == radioServicePriceList.TimingId && x.TimeBeltId == radioServicePriceList.TimingBeltId);
                if (RadioPrice != null)
                {
                    return true;
                }



            }

            return false;



        }


        /// <summary>
        /// Admins the color of the save.
        /// </summary>
        /// <param name="colorView">The color view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">AdminSaveTiming</exception>
        /// <exception cref="System.ArgumentException">AdminSaveTiming</exception>
        public string SaveColorInfo(IColorView colorView)
        {
            var result = string.Empty;
            if (colorView == null)
            {
                throw new ArgumentException("AdminSaveTiming");
            }

            var newRecord = new Color
            {
                Description = colorView.Description,
            };

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.Colors.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveTiming - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        #region Time Belt Setup



        /// <summary>
        /// Saves the time belt information.
        /// </summary>
        /// <param name="timeBeltView">The time belt view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">timeBeltView</exception>
        public string SaveTimeBeltInfo(ITimeBeltView timeBeltView)
        {
            var result = string.Empty;
            if (timeBeltView == null)
            {
                throw new ArgumentException("timeBeltView ");
            }

            var newRecord = new TimeBelt
            {
                Description = timeBeltView.Description,
                IsActive=true,
                Name=timeBeltView.name,
            };

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.TimeBelts.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveTimeBelt - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Edits the time belt.
        /// </summary>
        /// <param name="timeBeltView">The time belt view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// timeBeltView
        /// or
        /// timeDetails
        /// </exception>
        public string EditTimeBelt(ITimeBeltView timeBeltView)
        {
            var result = string.Empty;
            if (timeBeltView == null) throw new ArgumentNullException(nameof(timeBeltView));
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var timeDetails = dbContext.TimeBelts.SingleOrDefault(x => x.Id == timeBeltView.TimeBeltId);
                    if (timeDetails == null) throw new ArgumentNullException(nameof(timeDetails));

                    timeDetails.Description = timeBeltView.Description;
                    timeDetails.Name = timeBeltView.name;
                    timeDetails.IsActive = true;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveTimeBelt - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }



        /// <summary>
        /// Deletes the time belt.
        /// </summary>
        /// <param name="TimeBeltId">The time belt identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Id</exception>
        /// <exception cref="ApplicationException">timeview</exception>
        public string DeleteTimeBelt(int TimeBeltId)
        {

            if (TimeBeltId < 1)
            {
                throw new ArgumentOutOfRangeException("Id");
            }
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var timeview = dbContext.TimeBelts.SingleOrDefault(x => x.Id.Equals(TimeBeltId));
                    if (timeview == null)
                    {
                        throw new ApplicationException("timeview ");
                    }
                    timeview.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete Time Belt- {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }


        #endregion


        #region Material Type Setup

        /// <summary>
        /// Admins the type of the save material.
        /// </summary>
        /// <param name="materialTypeView">The material type view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">materialTypeView</exception>
        /// <exception cref="System.ArgumentException">materialTypeView</exception>
        public string SaveMaterialTypeInfo(IMaterialTypeView materialTypeView)
        {
            var result = string.Empty;
            if (materialTypeView == null)
            {
                throw new ArgumentException("materialTypeView");
            }

            var newRecord = new MaterialType
            {
                Description = materialTypeView.Description,

                IsActive = true,
            };

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.MaterialTypes.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveMaterialType - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Edits the type of the material.
        /// </summary>
        /// <param name="materialTypeView">The material type view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">materialTypeView
        /// or
        /// materialTypeDetails</exception>
        public string EditMaterialType(IMaterialTypeView materialTypeView)
        {
            var result = string.Empty;
            if (materialTypeView == null) throw new ArgumentNullException(nameof(materialTypeView));
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var materialTypeDetails =
                        dbContext.MaterialTypes.SingleOrDefault(
                            x => x.MaterialTypeId == materialTypeView.MaterialTypeId);
                    if (materialTypeDetails == null) throw new ArgumentNullException(nameof(materialTypeDetails));

                    materialTypeDetails.Description = materialTypeView.Description;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveMaterialType - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }



        /// <summary>
        /// Deletes the material type information.
        /// </summary>
        /// <param name="materialTypeId">The material type identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">materialTypeDetails</exception>
        public string DeleteMaterialTypeInfo(int materialTypeId)
        {
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var materialTypeDetails =
                        dbContext.MaterialTypes.SingleOrDefault(
                            x => x.MaterialTypeId == materialTypeId);
                    if (materialTypeDetails == null) throw new ArgumentNullException(nameof(materialTypeDetails));
                    materialTypeDetails.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteMaterial - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


#endregion

        #region Duration Type Setup

        /// <summary>
        /// Admings the type of the save duration.
        /// </summary>
        /// <param name="durationTypeView">The duration type view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">durationTypeView</exception>
        /// <exception cref="System.ArgumentException">durationTypeView</exception>
        public string SaveDurationTypeInfo(IDurationTypeView durationTypeView)
        {
            var result = string.Empty;
            if (durationTypeView == null)
            {
                throw new ArgumentException("durationTypeView");
            }

            var newRecord = new DurationType
            {
                DurationTypeCode = durationTypeView.DurationTypeCode,
                Description = durationTypeView.Description,

                IsActive = true
            };

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.DurationTypes.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveDurationType - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;


        }


        /// <summary>
        /// Edits the type of the duration.
        /// </summary>
        /// <param name="durationTypeView">The duration type view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// durationTypeView
        /// or
        /// durationTypeDetails
        /// </exception>
        public string EditDurationType(IDurationTypeView durationTypeView)
        {
            var result = string.Empty;
            if (durationTypeView == null) throw new ArgumentNullException(nameof(durationTypeView));
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var durationTypeDetails =
                        dbContext.DurationTypes.SingleOrDefault(x =>
                            x.DurationTypeCode == durationTypeView.DurationTypeCode);
                    if (durationTypeView == null) throw new ArgumentNullException(nameof(durationTypeDetails));

                    durationTypeDetails.Description = durationTypeView.Description;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format(" Edit Duration Type - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Deletes the duration type information.
        /// </summary>
        /// <param name="durationTypeId">The duration type identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">durationTypeDetails</exception>
        public string DeleteDurationTypeInfo(string durationTypeId)
        {
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var durationTypeDetails =
                        dbContext.DurationTypes.SingleOrDefault(x =>
                            x.DurationTypeCode == durationTypeId);
                    if (durationTypeDetails == null) throw new ArgumentNullException(nameof(durationTypeDetails));
                    durationTypeDetails.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteDuration- {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        #endregion

        #region Timing Setup

        /// <summary>
        /// Admins the save timing.
        /// </summary>
        /// <param name="timingView">The timing view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">AdminSaveTiming</exception>
        /// <exception cref="System.ArgumentException">AdminSaveTiming</exception>
        public string SaveTimingInfo(ITimingView timingView)
        {
            var result = string.Empty;
            if (timingView == null)
            {
                throw new ArgumentException("AdminSaveTiming");
            }

            var newRecord = new Timing
            {
                Description = timingView.Description,

                IsActive = true,
            };

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.Timings.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveTiming - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Edits the timing.
        /// </summary>
        /// <param name="timingView">The timing view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// timingView
        /// or
        /// timingDetails
        /// </exception>
        public string EditTiming(ITimingView timingView)
        {
            var result = string.Empty;
            if (timingView == null) throw new ArgumentNullException(nameof(timingView));
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var timingDetails = dbContext.Timings.SingleOrDefault(x => x.TimingId == timingView.TimingId);
                    if (timingDetails == null) throw new ArgumentNullException(nameof(timingDetails));

                    timingDetails.Description = timingView.Description;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveMaterialType - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Deletes the timing information.
        /// </summary>
        /// <param name="TimingId">The timing identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">TimingId</exception>
        /// <exception cref="ArgumentNullException">TimingDetails</exception>
        public string DeleteTimingInfo(int TimingId)
        {
            var result = string.Empty;
            if (TimingId < 1)
            {
                throw new ArgumentException(nameof(TimingId));
            }


            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var TimingDetails = dbContext.Timings.SingleOrDefault(x => x.TimingId == TimingId);
                    if (TimingDetails == null) throw new ArgumentNullException(nameof(TimingDetails));
                    TimingDetails.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteTiming - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        #endregion


        #region Design Element Price Setup


        /// <summary>
        /// Saves the design element price.
        /// </summary>
        /// <param name="designelement">The designelement.</param>
        /// <returns></returns>
        public string SaveDesignElementPrice(IDesignElementPriceView designelement)
        {
            var result = string.Empty;

            var view = new DesignElementPrice
            {
                ServiceTypeCode = designelement.ServiceTypeCode,
                DesignElementId = designelement.DesignElementId,
                Amount = designelement.Amount,
                Comment = designelement.Comment,
                EffectiveDate = designelement.EffectiveDate,
                DateInactive = null,
                IsActive = true,
                DateCreated = DateTime.Now
            };
            try
            {
                // calling our database 
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var Prevprice = dbContext.DesignElementPrices.FirstOrDefault(x => x.DesignElementId == designelement.DesignElementId&&designelement.ServiceTypeCode==x.ServiceTypeCode);
                    if (Prevprice != null)
                    {
                        Prevprice.DateInactive = DateTime.Now;
                        Prevprice.IsActive = false;
                        dbContext.SaveChanges();
                    }
                    // calling changes
                    dbContext.DesignElementPrices.Add(view);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("view - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }
        
        
        /// <summary>
        /// Edits the design element type price.
        /// </summary>
        /// <param name="designElementPriceView">The design element price view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// designElementPriceView
        /// or
        /// designElementDetails
        /// </exception>
        public string EditDesignElementTypePrice(IDesignElementPriceView designElementPriceView)
        {
            var result = string.Empty;
            if (designElementPriceView == null) throw new ArgumentNullException(nameof(designElementPriceView));
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var designElementDetails = dbContext.DesignElementPrices.SingleOrDefault(x =>
                        x.DesignElementPriceId == designElementPriceView.DesignElementPriceId);
                    if (designElementDetails == null) throw new ArgumentNullException(nameof(designElementDetails));


                    designElementDetails.Comment = designElementPriceView.Comment;
                    designElementDetails.Amount = designElementPriceView.Amount;

                    designElementDetails.DateInactive = designElementPriceView.DateInactive;
                    designElementDetails.DesignElementId = designElementPriceView.DesignElementId;
                    designElementDetails.DesignElementPriceId = designElementPriceView.DesignElementPriceId;
                    designElementDetails.EffectiveDate = designElementDetails.EffectiveDate;

                    designElementDetails.ServiceTypeCode = designElementPriceView.ServiceTypeCode;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveMaterialType - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Deletes the design element price.
        /// </summary>
        /// <param name="designElementPriceId">The design element price identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">designElementDetails</exception>
        public string DeleteDesignElementPrice(int designElementPriceId)
        {
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var designElementDetails = dbContext.DesignElementPrices.SingleOrDefault(x =>
                        x.DesignElementPriceId == designElementPriceId);
                    if (designElementDetails == null) throw new ArgumentNullException(nameof(designElementDetails));
                    designElementDetails.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteDesignElement - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        #endregion


        #region Design Element Setup

        /// <summary>
        /// Saves the add design element.
        /// </summary>
        /// <param name="designElementInfo">The design element information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">designElementInfo</exception>
        public string SaveAddDesignElement(IDesignElementView designElementInfo)
        {
            if (designElementInfo == null) throw new ArgumentNullException(nameof(designElementInfo));

            var result = string.Empty;

            var newDesignElement = new DesignElement
            {
                Description = designElementInfo.Description,
                IsActive = true
            };
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.DesignElements.Add(newDesignElement);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveNewDesignElement - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Saves the design element description.
        /// </summary>
        /// <param name="designElementInfo">The design element information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">designElementInfo
        /// or
        /// designElementInfo</exception>
        public string EditDesignElementDescription(IDesignElementView designElementInfo)
        {
            if (designElementInfo == null) throw new ArgumentNullException(nameof(designElementInfo));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {


                    var designElementDLL =
                        dbContext.DesignElements.SingleOrDefault(x =>
                            x.DesignElementId == designElementInfo.DesignElementId);
                    if (designElementInfo == null) throw new ArgumentNullException(nameof(designElementInfo));

                    designElementDLL.Description = designElementInfo.Description;
                    designElementDLL.DesignElementId = designElementInfo.DesignElementId;
                    designElementDLL.IsActive = true;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveDescriptionInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            designElementInfo.ProcessingMessage = result;
            return result;
        }



        /// <summary>
        /// Deletes the design element description.
        /// </summary>
        /// <param name="designElementId">The design element identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">designElementId</exception>
        public string DeleteDesignElementDescription(int designElementId)
        {
            if (designElementId < 1)
            {
                throw new ArgumentOutOfRangeException("designElementId");
            }

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {


                    var designElementDLL =
                        dbContext.DesignElements.SingleOrDefault(x =>
                            x.DesignElementId == designElementId);

                    designElementDLL.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteDescriptionInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }
            return result;
        }

        #endregion

        #region Material Type Timing Setup

        /// <summary>
        /// Saves the material type timing.
        /// </summary>
        /// <param name="timingInfo">The timing information.</param>
        /// <returns></returns>
        public string SaveMaterialTypeTiming(IMaterialTypeTimingView timingInfo)
        {
            var result = string.Empty;

            var view = new MaterialTypeTiming
            {
                ServiceTypeCode = timingInfo.ServiceTypeCode,
                MaterialTypeId = timingInfo.MaterialTypeId,
                TimingId = timingInfo.TimingId,
                IsActive = true

            };
            try
            {

                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {

                    dbContext.MaterialTypeTimings.Add(view);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("view - {0} , {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : "");
            }

            //MaterialProductionPriceId = productionInfo.MaterialProductionPriceId;
            return result;
        }

        /// <summary>
        /// Edits the material type timing.
        /// </summary>
        /// <param name="timing">The timing.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">timing
        /// or
        /// materialTypeTiming</exception>
        public string EditMaterialTypeTiming(IMaterialTypeTimingView timing)
        {
            var result = string.Empty;
            if (timing == null)
            {
                throw new ArgumentNullException(nameof(timing));
            }

            try
            {
                using (
                   var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var materialTypeTiming = dbContext.MaterialTypeTimings.SingleOrDefault(x => x.MaterialTypeTimingId == timing.MaterialTypeTimingId);
                    if (materialTypeTiming == null)
                    {
                        throw new ArgumentNullException(nameof(materialTypeTiming));
                    }

                    materialTypeTiming.MaterialTypeTimingId = timing.MaterialTypeTimingId;
                    materialTypeTiming.MaterialTypeId = timing.MaterialTypeId;
                    materialTypeTiming.ServiceTypeCode = timing.ServiceTypeCode;
                    materialTypeTiming.TimingId = timing.TimingId;
                    materialTypeTiming.IsActive = true;

                    dbContext.SaveChanges();
                }


            }
            catch (Exception e)
            {
                result = string.Format("EditMaterialTypeTiming - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }

            return result;
        }


        /// <summary>
        /// Deletes the material type timing.
        /// </summary>
        /// <param name="TypeTiming">The type timing.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">TypeTiming</exception>
        /// <exception cref="ArgumentNullException">materialType</exception>
        public string DeleteMaterialTypeTiming(int TypeTiming)
        {
            if (TypeTiming < 1)
            {
                throw new ArgumentOutOfRangeException("TypeTiming");
            }

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var materialType = dbContext.MaterialTypeTimings.SingleOrDefault(x => x.MaterialTypeTimingId.Equals(TypeTiming));
                    if (materialType == null) throw new ArgumentNullException(nameof(materialType));
                    materialType.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete Material Type Timing - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }


#endregion
       
          

        /// <summary>s
        /// Saves the payment transaction.
        /// </summary>
        /// <param name="paymentDetails">The payment details.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Repository.Save. Db Entity Validation Exception. Data not saved. Error: " +
        /// sb.ToString()</exception>
        public string SavePaymentTransaction(IPaymentModel paymentDetails)
        {
            var result = string.Empty;

            var savingPayment = new Payment
            {

                OrderId = paymentDetails.OrderId,
                TotalAmount = paymentDetails.TotalAmount,
                AmountPaid = paymentDetails.AmountPaid,
                ReferenceCode = paymentDetails.ReferenceCode,
                UserId = paymentDetails.UserId,
                DateCreated = DateTime.Now, 

            };
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.Payments.Add(savingPayment);
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

         
    }

}
