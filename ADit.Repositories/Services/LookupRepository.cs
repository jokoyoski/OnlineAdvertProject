using System;
using System.Collections.Generic;
using System.Linq;
using ADit.Interfaces;
using ADit.Repositories.DataAccess;
using ADit.Repositories.Queries;
using ADit.Interfaces.ValueTypes;

namespace ADit.Repositories.Services
{


    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.ILookupRepository" />
    public class LookupRepository : ILookupRepository
    {/// <summary>
     /// 
     /// </summary>
     /// <returns></returns>
     
        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupRepository" /> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public LookupRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Gets the type of the apcon approval.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetApconApprovalType</exception>
        public IList<IApconApprovalType> GetApconApprovalTypeList()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getApconApprovalType(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetApconApprovalType", e);
            }
        }


        /// <summary>
        /// Gets the active apcon approval type list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetApconApprovalType</exception>
        /// Active APCON approvals type are approval types that already have their prices setup, effective and is ACtive
        public IList<IApconApprovalType> GetActiveAPCONApprovalTypeList()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getActiveApconApprovalType(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetApconApprovalType", e);
            }
        }



        /// <summary>
        /// Gets the apcon approval type price.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetApconApprovalType</exception>
        /// This will get the Apcon approval price based on the particular Id selected from the Apcon tpe table
        public IList<IApconApprovalTypePrice> GetApconApprovalTypePrice()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getApconApprovalTypePrice(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetApconApprovalType", e);
            }
        }

        /// <summary>
        /// Gets the radio service price.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetRadioServicePrice</exception>
        public IList<IRadioServicePriceListModel> GetRadioServicePrice()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getRadioServicePricePrice(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetRadioServicePrice", e);
            }
        }


        /// <summary>
        /// Gets the apcon approval type price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetApconApprovalTypePriceById</exception>
        public IApconApprovalTypePrice GetApconApprovalTypePriceById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.getApconApprovalTypePriceById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetApconApprovalTypePriceById", e);
            }
        }

        /// <summary>
        /// Gets the radio service price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetRadioServicePriceById</exception>
        public IRadioServicePriceListModel GetRadioServicePriceById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.getRadioServicePriceById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetRadioServicePriceById", e);
            }
        }

        /// <summary>
        /// Gets the type of the material.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetMaterialType</exception>
        public IList<IMaterialType> GetMaterialType()
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getMaterialType(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetMaterialType", e);
            }
        }

        /// <summary>
        /// Gets the type of the material.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetMaterialType</exception>
        public IList<IMaterialType> GetMaterialTypeForRadio()
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getMaterialTypeForRadio(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetMaterialType", e);
            }
        }


        /// <summary>
        /// Gets the material type for tv.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetMaterialType</exception>
        public IList<IMaterialType> GetMaterialTypeForTv()
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getMaterialTypeForTv(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetMaterialType", e);
            }
        }


        /// <summary>
        /// Gets the active material type for tv.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetMaterialType</exception>
        /// Active Material Types for TV are Material Types That are Active, Effective  and has Prices
        public IList<IMaterialType> GetActiveMaterialTypeForTv()
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getActvieMaterialTypeForTv(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetActiveMaterialTypeForTv", e);
            }
        }


        /// <summary>
        /// Gets the active material type for radio.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetActiveMaterialTypeForRadio</exception>
        public IList<IMaterialType> GetActiveMaterialTypeForRadio()
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getActvieMaterialTypeForRadio(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetActiveMaterialTypeForRadio", e);
            }
        }


        /// <summary>
        /// Gets the type of the service.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetServiceType</exception>
        public IList<IServiceType> GetServiceType()
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getServiceType(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetServiceType", e);
            }
        }


        /// <summary>
        /// Gets the material scripting price.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetMaterialScriptingPrice</exception>
        public IList<IMaterialScriptingPrice> GetMaterialScriptingPriceList()
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getMaterialScriptingPrice(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetMaterialScriptingPrice ", e);
            }
        }


        /// <summary>
        /// Gets the material scripting price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetMaterialScriptingPriceById</exception>
        public IMaterialScriptingPrice GetMaterialScriptingPriceById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.getMaterialScriptingPriceById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetMaterialScriptingPriceById", e);
            }
        }



        /// <summary>
        /// Gets the material scripting price.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetMaterialProductionPrice</exception>
        public IList<IMaterialProductionPrice> GetMaterialProductionPriceList()
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getMaterialProductionPrice(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetMaterialProductionPrice ", e);
            }
        }


        /// <summary>
        /// Gets the material production price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetMaterialProductionPriceById</exception>
        public IMaterialProductionPrice GetMaterialProductionPriceById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.getMaterialProductionPriceById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetMaterialProductionPriceById", e);
            }
        }




        /// <summary>
        /// Gets the duration.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetDuration</exception>
        public IList<IDurationType> GetDurationList()
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getDurationType(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetDuration", e);
            }
        }




        /// <summary>
        /// Gets the timing.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTiming</exception>
        public IList<ITiming> GetTiming()
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getTiming(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTiming", e);
            }
        }

        /// <summary>
        /// Gets the tv timing.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTiming</exception>
        public IList<IMaterialTypeTimingModel> GetTVTiming()
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getTVTiming(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTiming", e);
            }
        }


        /// <summary>
        /// Gets the timing collection.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTimingCollection</exception>
        /// <exception cref="System.ApplicationException">Repository GetTimingCollection</exception>
        public IList<ITiming> GetTimingCollection(int Id)
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getTimingCollection(dbContext, Id).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTimingCollection", e);
            }
        }

        /// <summary>
        /// Gets the timing collection by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetDepartmentById</exception>
        public ITiming GetTimingCollectionById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.getTimingCollectionById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTimingCollectionById", e);
            }
        }



        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetColor</exception>
        /// <exception cref="System.ApplicationException">Repository GetColor</exception>
        public IList<IColor> GetColor()

        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getColor(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetColor", e);
            }
        }

        /// <summary>
        /// Gets the design element.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetDesignElement</exception>
        /// <exception cref="System.ApplicationException">Repository GetDesignElement</exception>
        public IList<IDesignElement> GetDesignElement()
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getDesignElement(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetDesignElement", e);
            }
        }


        /// <summary>
        /// Gets the design element price.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetDesignElementPrice</exception>
        /// <exception cref="System.ApplicationException">Repository GetDesignElementPrice</exception>
        public IList<IDesignElementPrice> GetDesignElementPrice()
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getDesignElementPrice(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetDesignElementPrice", e);
            }
        }


        /// <summary>
        /// Gets the color by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetColorById</exception>
        public IColor GetColorById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.GetColorById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetColorById", e);
            }
        }







        /// <summary>
        /// Gets the time belt by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTimeById</exception>
        public ITimeBelt GetTimeBeltById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.GetTimeBeltById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTimeById", e);
            }
        }

        /// <summary>
        /// Gets the apcon approval by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetApconApprovalById</exception>
        public IApconApprovalType GetApconApprovalById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.GetApconApprovalById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetApconApprovalById", e);
            }
        }


        /// <summary>
        /// Gets the material type by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetDepartmentById</exception>
        public IMaterialType GetMaterialTypeById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.GetMaterialTypeId(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetDepartmentById", e);
            }
        }

        /// <summary>
        /// Gets the duration type by identifier.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetDepartmentById</exception>
        public IDurationType GetDurationTypeById(string code)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.GetDurationTypeId(dbContext, code);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetDepartmentById", e);
            }
        }

        /// <summary>
        /// Gets the timing by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetDepartmentById</exception>
        public ITiming GetTimingById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.GetTimingById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetDepartmentById", e);
            }
        }

        /// <summary>
        /// Gets the design element price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetDepartmentById</exception>
        public IDesignElementPrice GetDesignElementPriceById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.getDesignElementPriceById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetDepartmentById", e);
            }
        }


        /// <summary>
        /// Gets the design element description by identifier.
        /// </summary>
        /// <param name="designElementId">The design element identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">ServiceTypes</exception>
        public string GetDesignElementDescriptionByID(int designElementId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var a = LookupQueries.getDesignElementDescriptionByID(dbContext, designElementId);

                    return a.Description;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("ServiceTypes", e);
            }
        }




        /// <summary>
        /// Gets the timing.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetMaterialTypeTiming</exception>
        /// <exception cref="System.ApplicationException">Repository GetTiming</exception>
        public IList<IMaterialTypeTimingDetail> GetMaterialTypeTimingList()
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getMaterialTypeTiming(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetMaterialTypeTiming", e);
            }
        }

        /// <summary>
        /// Gets the material type timing collection.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetMaterialTypeTimingCollection</exception>
        public IList<IMaterialTypeTimingModel> GetMaterialTypeTimingCollection(int Id)
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getMaterialTypeTimingCollection(dbContext, Id).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetMaterialTypeTimingCollection", e);
            }
        }

        /// <summary>
        /// Gets the edit material type timing by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetEditMaterialTypeTimingById</exception>
        public IMaterialTypeTimingModel GetEditMaterialTypeTimingById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.getMaterialTypeTimingById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetEditMaterialTypeTimingById", e);
            }
        }


        /// <summary>
        /// Gets the branding material price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetBrandingMaterialPrice</exception>
        public IBrandingMaterialPrice GetBrandingMaterialPriceById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        BrandingQueries.getMaterialPriceById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetBrandingMaterialPrice", e);
            }
        }






        /// <summary>
        /// Gets the order number by order identifier.
        /// </summary>
        /// <param name="OrderId">The order identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetOrderNumberByOrderId</exception>
        public IOrder GetOrderNumberByOrderId(int OrderId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        OrderQueries.GetOrderNumberByOrderId(OrderId,dbContext);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetOrderNumberByOrderId", e);
            }
        }
        /// <summary>
        /// Gets the branding material by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetDepartmentById</exception>
        public IBrandingMaterial GetBrandingMaterialById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        BrandingQueries.GetBrandingMaterialrById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetDepartmentById", e);
            }

        }


        /// <summary>
        /// Gets the material list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetBrandingMaterialList</exception>
        public IList<IBrandingMaterial> GetMaterialList()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = BrandingQueries.GetBrandingMaterial(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetBrandingMaterialList", e);
            }
        }

        /// <summary>
        /// Deletes the design element price.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">DesignPrice</exception>
        public string DeleteDesignElementPrice(int Id)
        {
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var DesignPrice = dbContext.DesignElementPrices.SingleOrDefault(x => x.DesignElementPriceId.Equals(Id));
                    if (DesignPrice == null) throw new ArgumentNullException(nameof(DesignPrice));
                    DesignPrice.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteDesignElementPrice - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }

        /// <summary>
        /// Gets the material price list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetMaterialPriceList</exception>
        public IList<IBrandingMaterialPrice> GetMaterialPriceList()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = BrandingQueries.GetBrandingMaterialPrice(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetMaterialPriceList", e);
            }
        }


        /// <summary>
        /// Gets the branding material price.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetBrandingMaterialPrice</exception>
        public IList<IBrandingMaterialPrice> GetBrandingMaterialPriceList()
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = BrandingQueries.getMaterialPrice(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetBrandingMaterialPrice", e);
            }

        }


        /// <summary>
        /// Gets the online extra service list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetOnlineExraServiceList</exception>
        public IList<IOnlineExtraService> GetOnlineExtraServiceList()
        {
            try
            {
                using (

                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = OnlineQueries.GetOnlineExtraService(dbContext).ToList();
                    return aRecord;
                }
            }

            catch (Exception e)
            {
                throw new ApplicationException("GetOnlineExraServiceList", e);
            }

        }



        /// <summary>
        /// Gets the active online extra service list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetOnlineExraServiceList</exception>
        public IList<IOnlineExtraService> GetActiveOnlineExtraServiceList()
        {
            try
            {
                using (

                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = OnlineQueries.GetActiveOnlineExtraService(dbContext).ToList();
                    return aRecord;
                }
            }

            catch (Exception e)
            {
                throw new ApplicationException("GetOnlineExraServiceList", e);
            }

        }



        /// <summary>
        /// Gets the online extra service by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetExtraServiceById</exception>
        public IOnlineExtraService GetOnlineExtraServiceById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        OnlineQueries.GetOnlineExtraServiceById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetExtraServiceById", e);
            }
        }


        /// <summary>
        /// Gets the online extra service by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetExtraServiceById</exception>
        public IOnlineDuration GetOnlineDurationById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        OnlineQueries.GetOnlineDurationId(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetExtraServiceById", e);
            }
        }


        /// <summary>
        /// Gets the online platform list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetOnlinePlatformList</exception>
        public IList<IOnlinePlatform> GetOnlinePlatformList()
        {
            try
            {
                using (

                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = OnlineQueries.GetOnlinePlatform(dbContext).ToList();
                    return aRecord;
                }
            }

            catch (Exception e)
            {
                throw new ApplicationException("GetOnlinePlatformList", e);
            }

        }


        /// <summary>
        /// Gets the online platform by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetOnlinePlatformById</exception>
        public IOnlinePlatform GetOnlinePlatformById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        OnlineQueries.GetOnlinePlatformById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetOnlinePlatformById", e);
            }
        }

        /// <summary>
        /// Gets the online purposes list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetOnlinePurposeList</exception>
        public IList<IOnlinePurpose> GetOnlinePurposesList()
        {
            try
            {
                using (

                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = OnlineQueries.GetOnlinePurpose(dbContext).ToList();
                    return aRecord;
                }
            }

            catch (Exception e)
            {
                throw new ApplicationException("GetOnlinePurposeList", e);
            }

        }

        /// <summary>
        /// Gets the online purpose by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetExtraServiceById</exception>
        public IOnlinePurpose GetOnlinePurposeById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        OnlineQueries.GetOnlinePurposeId(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetExtraServiceById", e);
            }
        }

        /// <summary>
        /// Gets the online platform price list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetOnlinePlatformPrice</exception>
        public IList<IOnlinePlatformPrice> GetOnlinePlatformPriceList()
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = OnlineQueries.getOnlinePlatformPrice(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetOnlinePlatformPrice", e);
            }
        }

        /// <summary>
        /// Gets the online platform price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetOnlinePlatformPriceById</exception>
        /// <exception cref="System.ApplicationException">Repository GetOnlinePlatformPriceById</exception>
        public IOnlinePlatformPrice GetOnlinePlatformPriceById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        OnlineQueries.getOnlinePlatformPriceById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetOnlinePlatformPriceById", e);
            }
        }


        /// <summary>
        /// Gets the oline platform price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetDepartmentById</exception>
        public IOnlinePlatformPrice GetOlinePlatformPriceById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                       OnlineQueries.getOnlinePlatformPriceById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetDepartmentById", e);
            }
        }


        /// <summary>
        /// Gets the online extra service price list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetOnlineExraServicPriceeList</exception>
        public IList<IOnlineExtraServicePrice> GetOnlineExtraServicePriceList()
        {
            try
            {
                using (

                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = OnlineQueries.GetOnlineExtraServicePrice(dbContext).ToList();
                    return aRecord;
                }
            }

            catch (Exception e)
            {
                throw new ApplicationException("GetOnlineExraServicPriceeList", e);
            }

        }


        /// <summary>
        /// Gets the online extra service price by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetExtraServicePriceById</exception>
        public IOnlineExtraServicePrice GetOnlineExtraServicePriceById(int id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        OnlineQueries.GetOnlineExtraServicePriceById(dbContext, id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetExtraServicePriceById", e);
            }
        }


        /// <summary>
        /// Gets the script material question.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetScriptMaterialQuestion</exception>
        public IList<IScriptMaterialQuestion> GetScriptMaterialQuestionList()
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = RadioQueries.getScriptMaterialQuestion(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetScriptMaterialQuestion", e);
            }
        }






        /// <summary>
        /// Gets the radio station.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetRadioStation</exception>
        public IList<IRadioStationModel> GetRadioStationList()
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = RadioQueries.getRadioStation(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetRadioStation", e);
            }
        }


        /// <summary>
        /// Gets the radio station by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetRadioStationById</exception>
        public IRadioStationModel GetRadioStationById(int Id)
        {
            try
            {
                using (
                  var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        RadioQueries.getRadioStationById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetRadioStationById", e);
            }
        }


        /// <summary>
        /// Gets the print categories list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetPrintCategoriesCategories</exception>
        public IList<IPrintCategory> GetPrintCategoriesList()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = PrintQueries.getPrintCategories(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetPrintCategoriesCategories", e);
            }
        }
        /// <summary>
        /// Gets the service type list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">ServiceTypes</exception>
        public IList<IPrintServiceType> GetServiceTypeList()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = PrintQueries.GetServiceTypes(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("ServiceTypes", e);
            }
        }


        /// <summary>
        /// Gets the apcon approval price by type identifier.
        /// </summary>
        /// <param name="typeId">The type identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">ServiceTypes</exception>
        public IApconApprovalTypePrice GetApconApprovalPriceByTypeId(int typeId)
        {

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var a = PrintQueries.GetApconApprovalPriceByTypeId(dbContext, typeId);

                    return a;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("ServiceTypes", e);
            }
        }


        /// <summary>
        /// Gets the news paper list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetNewsPaperList</exception>
        public IList<INewsPaper> GetNewsPaperList()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = PrintQueries.GetNewsPapers(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetNewsPaperList", e);
            }
        }



        /// <summary>
        /// Gets the print media type list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetNewsPaperList</exception>
        public IList<IPrintMediaType> GetPrintMediaTypeList()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = PrintQueries.GetPrintMediaTypes(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetNewsPaperList", e);
            }
        }

        /// <summary>
        /// Gets the print service type list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetPrintServiceTypeList</exception>
        public IList<IPrintServiceType> GetPrintServiceTypeList()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = PrintQueries.GetServiceTypes(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetPrintServiceTypeList", e);
            }
        }
        /// <summary>
        /// Gets the print category list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetPrintCategoryList</exception>
        public IList<IPrintCategory> GetPrintCategoryList()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = PrintQueries.getPrintCategories(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetPrintCategoryList", e);
            }
        }
        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetPrintServiceTypePriceList</exception>
        public IList<IPrintServiceTypePrice> GetPrintServiceTypePriceList()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = PrintQueries.getPrintServiceTypePrice(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetPrintServiceTypePriceList", e);
            }
        }

        /// <summary>
        /// Gets the print service type description by identifier.
        /// </summary>
        /// <param name="printServiceTypeId">The print service type identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printServiceTypeId</exception>
        /// <exception cref="ApplicationException">ServiceTypes</exception>
        public string GetPrintServiceTypeDescriptionByID(int printServiceTypeId)
        {
            if (printServiceTypeId <= -1) throw new ArgumentNullException(nameof(printServiceTypeId));

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var a = PrintQueries.getPrintServiceTypeDescriptionByID(dbContext, printServiceTypeId);

                    return a.Description;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("ServiceTypes", e);
            }

        }

        /// <summary>
        /// Gets the news paper description by identifier.
        /// </summary>
        /// <param name="newsPaperId">The news paper identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">newsPaperId</exception>
        /// <exception cref="ApplicationException">NewsPapers</exception>
        public string GetNewsPaperDescriptionById(int newsPaperId)
        {
            if (newsPaperId <= -1) throw new ArgumentNullException(nameof(newsPaperId));

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var a = PrintQueries.GetNewsPaperDescriptionById(dbContext, newsPaperId);

                    return a.Description;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("NewsPapers", e);
            }

        }







        /// <summary>
        /// Gets the print media type description by identifier.
        /// </summary>
        /// <param name="printMediaTypeId">The print media type identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printMediaTypeId</exception>
        /// <exception cref="ApplicationException">PrintMediaType</exception>
        public string GetPrintMediaTypeDescriptionById(int printMediaTypeId)
        {
            if (printMediaTypeId<= -1) throw new ArgumentNullException(nameof(printMediaTypeId));

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var a = PrintQueries.GetPrintMediaTypeDescriptionById(dbContext, printMediaTypeId);

                    return a.Description;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("PrintMediaType", e);
            }

        }



        /// <summary>
        /// Gets the print category description by identifier.
        /// </summary>
        /// <param name="printCategoryId">The print category identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printCategoryId</exception>
        /// <exception cref="ApplicationException">PrintCategoryDescription</exception>
        public string GetPrintCategoryDescriptionByID(int printCategoryId)
        {
            if (printCategoryId <= -1) throw new ArgumentNullException(nameof(printCategoryId));

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var a = PrintQueries.getPrintCategoryDescriptionByID(dbContext, printCategoryId);

                    return a.Description;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("PrintCategoryDescription", e);
            }

        }

        /// <summary>
        /// Gets the print service type price description by identifier.
        /// </summary>
        /// <param name="printServiceTypePriceId">The print service type price identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">ServiceTypePrices</exception>
        public IPrintServiceTypePrice GetPrintServiceTypePriceDescriptionByID(int printServiceTypePriceId)
        {
            //if (printServiceTypePriceId == null) throw new ArgumentNullException(nameof(printServiceTypePriceId));

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var a = PrintQueries.getPrintServiceTypePriceDescriptionByID(dbContext, printServiceTypePriceId);

                    return a;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("ServiceTypePrices", e);
            }

        }

        /// <summary>
        /// Gets the tv station by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Tv Station Id</exception>
        public ITvStation GetTvStationById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        TvQueries.GetTvStationById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Tv Station Id", e);
            }

        }





        /// <summary>
        /// Gets the tv station list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetTvStationList</exception>
        public IList<ITvStation> GetTvStationList()
        {
            try
            {
                using (
                  var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = TvQueries.GetTvStations(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetTvStationList", e);
            }

        }

        /// <summary>
        /// Gets the print media.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetPrintMedia</exception>
        public IList<IApconApprovalTypePrice> GetPrintMedia()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = PrintQueries.getApconApprovalPrice(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetPrintMedia", e);
            }
        }


        /// <summary>
        /// Gets the design element price list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetDesignElementPriceList</exception>
        /// <exception cref="System.ApplicationException">GetDesignElementPriceList</exception>
        public IList<IDesignElementPrice> GetDesignElementPriceList()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = PrintQueries.getDesignElementPrice(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetDesignElementPriceList", e);
            }
        }

        /// <summary>
        /// Gets the apcon approval price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetBrandingMaterialPrice</exception>
        /// <exception cref="System.ApplicationException">Repository GetBrandingMaterialPrice</exception>
        public IApconApprovalTypePrice GetApconApprovalPriceById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        PrintQueries.getApconApprovalPriceById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetBrandingMaterialPrice", e);
            }
        }


        /// <summary>
        /// Gets the design element price amount by identifier.
        /// </summary>
        /// <param name="designElementPriceId">The design element price identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetDesignElementPriceAmountById</exception>
        /// <exception cref="System.ApplicationException">Repository GetBrandingMaterialPrice</exception>
        public IDesignElementPrice GetDesignElementPriceAmountById(int designElementPriceId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        PrintQueries.getDesignElementPriceById(dbContext, designElementPriceId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetDesignElementPriceAmountById", e);
            }
        }


        /// <summary>
        /// Gets the radio scripting price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetBrandingMaterialPrice</exception>
        /// <exception cref="System.ApplicationException">Repository GetBrandingMaterialPrice</exception>
        public IMaterialScriptingPrice GetRadioScriptingPriceById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.getScriptingPriceByIdForRadio(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetBrandingMaterialPrice", e);
            }
        }

        /// <summary>
        /// Gets the scripting price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetBrandingMaterialPrice</exception>
        /// <exception cref="System.ApplicationException">Repository GetBrandingMaterialPrice</exception>
        public IMaterialScriptingPrice GetScriptingPriceById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.getScriptingPriceById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetBrandingMaterialPrice", e);
            }
        }


        /// <summary>
        /// Gets the production price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetBrandingMaterialPrice</exception>
        /// <exception cref="System.ApplicationException">Repository GetBrandingMaterialPrice</exception>
        public IMaterialProductionPrice GetProductionPriceById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.getProductionPriceById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetBrandingMaterialPrice", e);
            }
        }


        /// <summary>
        /// Gets the radio production price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetBrandingMaterialPrice</exception>
        /// <exception cref="System.ApplicationException">Repository GetBrandingMaterialPrice</exception>
        public IMaterialProductionPrice GetRadioProductionPriceById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.getProductionPriceByIdForRadio(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetBrandingMaterialPrice", e);
            }
        }


        /// <summary>
        /// Gets the tv scripting price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetBrandingMaterialPrice</exception>
        /// <exception cref="System.ApplicationException">Repository GetBrandingMaterialPrice</exception>
        public IMaterialScriptingPrice GetTvScriptingPrice(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.getScriptingPriceByIdForTv(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetBrandingMaterialPrice", e);
            }
        }


        /// <summary>
        /// Gets the tv production price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetBrandingMaterialPrice</exception>
        /// <exception cref="System.ApplicationException">Repository GetBrandingMaterialPrice</exception>
        public IMaterialProductionPrice GetTvProductionPrice(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.getProductionPriceByIdForTv(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetBrandingMaterialPrice", e);
            }
        }


        /// <summary>
        /// Gets the online extra service amount by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetOnlineExtraServiceAmountById</exception>
        /// <exception cref="System.ApplicationException">Repository GetBrandingMaterialPrice</exception>
        public IOnlineExtraServicePrice GetOnlineExtraServiceAmountById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.getOnlineExtraServiceById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetOnlineExtraServiceAmountById", e);
            }
        }



        /// <summary>
        /// Gets the branding material amount by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetBrandingMaterialAmountById</exception>
        /// <exception cref="System.ApplicationException">Repository GetBrandingMaterialAmountById</exception>
        public IBrandingMaterialPrice GetBrandingMaterialAmountById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        BrandingQueries.getMaterialPriceAmountById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetBrandingMaterialAmountById", e);
            }
        }


        /// <summary>
        /// Gets the online artwork price list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetBrandingMaterialAmountById</exception>
        /// <exception cref="System.ApplicationException">Repository GetBrandingMaterialAmountById</exception>
        public IList<IOnlineArtworkPrice> GetOnlineArtworkPriceList()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.getOnlineArtworkPrice(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetBrandingMaterialAmountById", e);
            }
        }


        /// <summary>
        /// Gets the online artwor amount by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetBrandingMaterialAmountById</exception>
        /// <exception cref="System.ApplicationException">Repository GetBrandingMaterialAmountById</exception>
        public IOnlineArtworkPrice GetOnlineArtworAmountById(int id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.getOnlineArtworkPriceById(dbContext, id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetBrandingMaterialAmountById", e);
            }
        }


        /// <summary>
        /// Gets the print transaction.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetPrintTransaction</exception>
        /// <exception cref="System.ApplicationException">Repository GetPrintTransaction</exception>
        public IList<IPrintTransaction> GetPrintTransaction()
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getPrintTransaction(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetPrintTransaction ", e);
            }
        }


        /// <summary>
        /// Gets the print transaction by identifier.
        /// </summary>
        /// <param name="transactonId">The transacton identifier.</param>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetMaterialProductionPriceById</exception>
        /// <exception cref="System.ApplicationException">Repository GetMaterialProductionPriceById</exception>
        public IPrintTransaction GetPrintTransactionById(int transactonId, int SentToId)
        {
            try 
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.getPrintTransactionById(dbContext, SentToId, transactonId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetMaterialProductionPriceById", e);
            }
        }


        /// <summary>
        /// Gets the radio timing.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTiming</exception>
        /// <exception cref="System.ApplicationException">Repository GetTiming</exception>
        public IList<IMaterialTypeTimingModel> GetRadioTiming()
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getRadioTimingById(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTiming", e);
            }
        }

        /// <summary>
        /// Gets the script transaction by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetScriptTransactionById</exception>
        public IList<IScriptingDetailModel> GetScriptTransactionById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.getScriptTransactionById(dbContext, Id).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetScriptTransactionById", e);
            }
        }


        /// <summary>
        /// Gets the apcon description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetApconDescriptionByValue</exception>
        public IApconApprovalType GetApconDescriptionByValue(string description)
        {
            try
            {
                var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext();
                {

                    var aRecord = LookupQueries.getApconDescriptionByValue(dbContext, description);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetApconDescriptionByValue", e);
            }

        }

        /// <summary>
        /// Gets the color description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetColorDescriptionByValue</exception>
        public IColor GetColorDescriptionByValue(string description)
        {
            try
            {
                var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext();
                {

                    var aRecord = LookupQueries.getColorDescriptionByValue(dbContext, description);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetColorDescriptionByValue", e);
            }

        }







        /// <summary>
        /// Gets the time belt description by value.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTimeBeltByValue</exception>
        public ITimeBelt GetTimeBeltDescriptionByValue(string name)
        {
            try
            {
                var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext();
                {

                    var aRecord = LookupQueries.timeBelt(dbContext, name);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTimeBeltByValue", e);
            }

        }


        /// <summary>
        /// Gets the material type description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetMaterialTypeDescriptionByValue</exception>
        public IMaterialType GetMaterialTypeDescriptionByValue(string description)
        {
            try
            {
                var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext();
                {

                    var aRecord = LookupQueries.getMaterialTypeDescriptionByValue(dbContext, description);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetMaterialTypeDescriptionByValue", e);
            }

        }


        /// <summary>
        /// Gets the duration type description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetDurationTypeDescriptionByValue</exception>
        public IDurationType GetDurationTypeDescriptionByValue(string description)
        {
            try
            {
                var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext();
                {

                    var aRecord = LookupQueries.getDurationTypeDescriptionByValue(dbContext, description);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetDurationTypeDescriptionByValue", e);
            }

        }


        /// <summary>
        /// Gets the timing description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTimingDescriptionByValue</exception>
        public ITiming GetTimingDescriptionByValue(string description)
        {
            try
            {
                var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext();
                {

                    var aRecord = LookupQueries.getTimingDescriptionByValue(dbContext, description);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTimingDescriptionByValue", e);
            }

        }


        /// <summary>
        /// Gets the contact by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetContact By Id</exception>
        public IContact GetContactById(int Id)
        {
            try
            {
                var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext();
                {

                    var aRecord = LookupQueries.GetContactbyId(dbContext,Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetContact By Id", e);
            }

        }


        /// <summary>
        /// Gets the design description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTimingDescriptionByValue</exception>
        public IDesignElement GetDesignDescriptionByValue(string description)
        {
            try
            {
                var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext();
                {

                    var aRecord = LookupQueries.getDesignDescriptionByValue(dbContext, description);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTimingDescriptionByValue", e);
            }

        }

        /// <summary>
        /// Gets the print design element price list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetDesignElementPriceList</exception>
        public IList<IDesignElementPrice> GetPrintDesignElementPriceList()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = PrintQueries.getPrintingDesignElementPrice(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetDesignElementPriceList", e);
            }
        }

        /// <summary>
        /// Gets the online duration list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetDesignElementPriceList</exception>
        public IList<IOnlineDuration> GetOnlineDurationList()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = LookupQueries.GetOnlineDuration(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetOnlineDurationList", e);
            }
        }

        /// <summary>
        /// Gets the tv transaction list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTvTransactionList</exception>
        public IList<ITvTransaction> GetTvTransactionList()
        {
            try 
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getTvTransactionList(dbContext).ToList();
                    return list;
                }
            } 
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTvTransactionList", e);
            }
        }

        /// <summary>
        /// Gets the tv transaction by identifier.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="transactonId">The transacton identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTvTransactionById</exception>
        public ITvTransaction GetTvTransactionById(int UserId, int transactonId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.getTvTransactionById(dbContext, UserId, transactonId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTvTransactionById", e);
            }
        }

        /// <summary>
        /// Gets the tv script transaction.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTvScriptTransaction</exception>
        public IList<ITvScriptingTransactionModelView> GetTvScriptTransaction(int Id, int userId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.getTvScriptTransactionById(dbContext, Id, userId).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTvScriptTransaction", e);
            }
        }


        /// <summary>
        /// Gets the tv material transaction.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetRadioStationPrice</exception>
        public IList<ITvMaterialTransactionModel> GetTvMaterialTransaction(int UserId, int transactionId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.GetTvMaterialTransactionById(dbContext, UserId, transactionId).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetRadioStationPrice", e);
            }
        }

        /// <summary>
        /// Gets the print transaction list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetPrintTransactionList</exception>
        public IList<IPrintTransaction> GetPrintTransactionList()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getPrintTransactionList(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetPrintTransactionList", e);
            }
        }

       
   

        /// <summary>
        /// Gets the contact list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetContactList</exception>
        public IList<IContact> GetContactList()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.GetContactList(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetContactList", e);
            }
        }



        /// <summary>
        /// Gets the order type by identifier.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetOrderTypeById</exception>
        public IOrder GetPendingOrderByUserId(int UserId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = LookupQueries.GetPendingOrderByUserId(dbContext, UserId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetPendingOrderByUserId", e);
            }
        }

        /// <summary>
        /// Gets the order numbe status.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="orderId">The order number.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetOrderTypeById</exception>
        public IOrder GetOrderNumbeStatus(int userId, int orderId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.GetOrderNumberStatus(dbContext, orderId, userId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetOrderTypeById", e);
            }
        }

        /// <summary>
        /// Gets the time belts.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetTimeBelt</exception>
        public IList<ITimeBelt> GetTimeBelts()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.GetTimeBelts(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetTimeBelt", e);
            }
        }



        /// <summary>
        /// Gets the user details for email.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="Details">The details.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetUserDetailsForEmail</exception>
        public ISendMailScript GetUserDetails( int SentToId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.GetUserDetailsForEmail(SentToId,dbContext);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(" GetUserDetailsForEmail", e);
            }
        }


        /// <summary>
        /// Gets the print service color list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetNewsPaperList</exception>
        public IList<IPrintServiceColor> GetPrintServiceColorList()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = PrintQueries.GetPrintServiceColors(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetNewsPaperList", e);
            }
        }


        /// <summary>
        /// Gets the print servie color by identifier.
        /// </summary>
        /// <param name="PrintServiceTypeColorId">The print service type color identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">PrintServiceTypeColorId</exception>
        /// <exception cref="ApplicationException">PrintServiceColor</exception>
        public IPrintServiceColor GetPrintServieColorById(int PrintServiceTypeColorId)
        {
            if (PrintServiceTypeColorId <= -1) throw new ArgumentNullException(nameof(PrintServiceTypeColorId));

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var a = PrintQueries.GetPrintServieColorById(dbContext, PrintServiceTypeColorId);

                    return a;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("PrintServiceColor", e);
            }
             
        }


        /// <summary>
        /// Gets the art work price list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetNewsPaperList</exception>
        public IList<IOnlineArtworkPrice> GetArtWorkPriceList()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = PrintQueries.GetArtWorkPrices(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetNewsPaperList", e);
            }
         }


        /// <summary>
        /// Gets the art work price by identifier.
        /// </summary>
        /// <param name="ArtWorkPriceId">The art work price identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">ArtWorkPriceId</exception>
        /// <exception cref="ApplicationException">ArtWorkPrice</exception>
        public IOnlineArtworkPrice GetArtWorkPriceById(int ArtWorkPriceId)
        {
            if (ArtWorkPriceId <= -1) throw new ArgumentNullException(nameof(ArtWorkPriceId));

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var a = PrintQueries.GetArtWorkPriceById(dbContext, ArtWorkPriceId);

                    return a;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("ArtWorkPrice", e);
            }

        }

        public string GetPrintServiceColorDescriptionById(int printServiceTypeColorId)
        {
            if (printServiceTypeColorId <= -1) throw new ArgumentNullException(nameof(printServiceTypeColorId));

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var a = PrintQueries.GetPrintServieColorById(dbContext, printServiceTypeColorId);

                    return a.PrintServiceTypeColor;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("PrintServiceColor", e);
            }
        }

       
    }
    
}

