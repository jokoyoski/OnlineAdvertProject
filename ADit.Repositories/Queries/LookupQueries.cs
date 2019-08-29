using System.Linq;
using ADit.Interfaces;
using ADit.Repositories.DataAccess;
using System.Collections.Generic;
using ADit.Repositories.Models;

namespace ADit.Repositories.Queries
{
    /// <summary>
    /// 
    /// </summary>
    internal static class LookupQueries
    {


        /// <summary>
        /// Gets the order number by order identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="OrderId">The order identifier.</param>
        /// <returns></returns>
        internal static IOrder GetOrderNumberByOrderId(ADitEntities db, int OrderId)
        {

            var result = (from d in db.Orders
                          where d.OrderId == OrderId
                          select new OrderModel
                          {
                              OrderNumber = d.OrderNumber
                          }).SingleOrDefault();

            return result;
        }






        /// <summary>
        /// Gets the type of the apcon approval.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IApconApprovalType> getApconApprovalType(ADitEntities db)
        {
            var result = (from d in db.ApconApprovalTypes
                          select new ApconApprovalTypeModel
                          {
                              ApoconTypeId = d.ApconApprovalTypeId,
                              Description = d.Description,
                              IsActive = d.IsActive
                          }).OrderBy(x => x.Description);

            return result;
        }


        /// <summary>
        /// Gets the type of the apcon approval.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IApconApprovalType> getActiveApconApprovalType(ADitEntities db)
        {
            var result = (from d in db.ApconApprovalTypes
                          join e in db.ApconApprovalTypePrices on d.ApconApprovalTypeId equals e.ApconApprovalTypeId
                          where d.IsActive.Equals(true) && e.IsActive.Equals(true)
                          select new ApconApprovalTypeModel

                          {
                              ApoconTypeId = d.ApconApprovalTypeId,
                              Description = d.Description,
                              IsActive = d.IsActive
                          }).OrderBy(x => x.Description);

            return result;
        }


        /// <summary>
        /// Gets the type of the service.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IServiceType> getServiceType(ADitEntities db)
        {
            var result = (from d in db.ServiceTypes
                          select new Models.SericeTypeModel
                          {
                              ServiceTypeCode = d.ServiceTypeCode,
                              Description = d.Description,
                              IsActive = d.IsActive
                          }).OrderBy(x => x.Description);

            return result;
        }

        /// <summary>
        /// Gets the apcon approval type price.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IApconApprovalTypePrice> getApconApprovalTypePrice(ADitEntities db)
        {
            var result = (from d in db.ApconApprovalTypePrices
                          join e in db.ApconApprovalTypes on d.ApconApprovalTypeId equals e.ApconApprovalTypeId
                          select new Models.ApconApprovalTypePriceModel
                          {
                              ApconTypeId = d.ApconApprovalTypeId,
                              ApconTypePriceId = d.ApconApprovalTypePriceId,
                              ApconTypeDescription = e.Description,
                              EffectiveDate = d.EffectiveDate,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive,
                              Amount = d.Amount,
                              Comment = d.Comment,
                              DateInactive = d.DateInactive,
                          }).OrderBy(x => x.Amount);

            return result;
        }


        /// <summary>
        /// Gets the radio service price price.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IRadioServicePriceListModel> getRadioServicePricePrice(ADitEntities db)
        {
            var result = (from d in db.RadioServicePrices
                          join e in db.RadioStations on d.RadioId equals e.RadioStationId
                          join m in db.MaterialTypes on d.MaterialTypeId equals m.MaterialTypeId
                          join f in db.Timings on d.TimingId equals f.TimingId

                          select new Models.RadioServicePriceListModel
                          {
                              Id = d.Id,
                              RadioId = d.RadioId,
                              RadioDescription = e.Description,
                              TimingId = d.TimingId,
                              TimingDescription = f.Description,
                              Amount = d.Amount,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              MaterialTypeDescription=m.Description,
                              DateEffective = d.DateEffective,
                              DateInActive = d.DateInActive,
                              MaterialTypeId=d.MaterialTypeId

                          }).OrderBy(x => x.Amount);

            return result;
        }


        /// <summary>
        /// Gets the apcon approval type price by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IApconApprovalTypePrice getApconApprovalTypePriceById(ADitEntities db, int Id)
        {
            var result = (from d in db.ApconApprovalTypePrices
                          where d.ApconApprovalTypePriceId.Equals(Id)
                          select new Models.ApconApprovalTypePriceModel
                          {
                              ApconTypeId = d.ApconApprovalTypeId,
                              ApconTypePriceId = d.ApconApprovalTypePriceId,
                              EffectiveDate = d.EffectiveDate,
                              DateCreated = d.DateCreated,
                              DateInactive = d.DateInactive,
                              IsActive = d.IsActive,
                              Amount = d.Amount,
                              Comment = d.Comment
                          }).SingleOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the radio service price by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IRadioServicePriceListModel getRadioServicePriceById(ADitEntities db, int Id)
        {
            var result = (from d in db.RadioServicePrices
                          where d.Id.Equals(Id)
                          select new Models.RadioServicePriceListModel
                          {
                              Id = d.Id,
                              RadioId = d.RadioId,

                              TimingId = d.TimingId,
                              TimingBeltId = d.TimeBeltId,
                              Amount = d.Amount,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              DateEffective = d.DateEffective,
                              DateInActive = d.DateInActive,
                              MaterialTypeId = d.MaterialTypeId,
                          }).SingleOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the type of the material.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IMaterialType> getMaterialType(ADitEntities db)
        {
            var result = (from d in db.MaterialTypes

                          where d.IsActive.Equals(true)

                          select new Models.MaterialTypeModel
                          {
                              MaterialTypeId = d.MaterialTypeId,
                              Description = d.Description,
                              IsActive = d.IsActive
                          }).OrderBy(x => x.Description);

            return result;
        }

        /// <summary>
        /// Gets the type of the material.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IMaterialType> getMaterialTypeForRadio(ADitEntities db)
        {
            var result = (from d in db.MaterialTypes
                          where d.Description.Equals("ANNOUNCORIAL") ||
                                d.Description.Equals("RADIO HYPE") ||
                                d.Description.Equals("NEWS MENTION") ||
                                d.Description.Equals("JINGLE") ||
                                d.Description.Equals("RADIO AD (2 VO)")
                          select new Models.MaterialTypeModel
                          {
                              MaterialTypeId = d.MaterialTypeId,
                              Description = d.Description,
                              IsActive = d.IsActive
                          }).OrderBy(x => x.Description);

            return result;
        }


        /// <summary>
        /// Gets the material type for tv.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IMaterialType> getMaterialTypeForTv(ADitEntities db)
        {
            var result = (from d in db.MaterialTypes
                          where d.Description.Equals("ANNOUNCORIAL") ||
                                d.Description.Equals("INFOMMERCIAL") ||
                                d.Description.Equals("JINGLE") ||
                                d.Description.Equals("TV COMMERCIAL (subject to final script)")
                          select new Models.MaterialTypeModel
                          {
                              MaterialTypeId = d.MaterialTypeId,
                              Description = d.Description,
                              IsActive = d.IsActive
                          }).OrderBy(x => x.Description);

            return result;
        }


        /// <summary>
        /// Gets the actvie material type for tv.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IMaterialType> getActvieMaterialTypeForTv(ADitEntities db)
        {
            var result = (from d in db.MaterialTypes

                          join e in db.MaterialScriptingPrices on d.MaterialTypeId equals e.MaterialTypeId
                          join f in db.MaterialProductionPrices on d.MaterialTypeId equals f.MaterialTypeId
                          where f.ServiceTypeCode == "T" && f.IsActive
                          where e.ServiceTypeCode == "T" && e.IsActive






                          select new MaterialTypeModel
                          {
                              MaterialTypeId = d.MaterialTypeId,
                              Description = d.Description,
                              IsActive = d.IsActive
                          }).OrderBy(x => x.Description);

            return result;
        }


        /// <summary>
        /// Gets the actvie material type for radio.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IMaterialType> getActvieMaterialTypeForRadio(ADitEntities db)
        {
            var result = (from d in db.MaterialTypes
                          join e in db.MaterialScriptingPrices on d.MaterialTypeId equals e.MaterialTypeId
                          join f in db.MaterialProductionPrices on d.MaterialTypeId equals f.MaterialTypeId
                          where f.ServiceTypeCode == "R" && f.IsActive
                          where e.ServiceTypeCode == "R" && e.IsActive
                          select new MaterialTypeModel
                          {
                              MaterialTypeId = d.MaterialTypeId,
                              Description = d.Description,
                              IsActive = d.IsActive
                          }).OrderBy(x => x.Description);

            return result;
        }


        /// <summary>
        /// Gets the design element price by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IDesignElementPrice getDesignElementPriceById(ADitEntities db, int Id)
        {
            var result = (from d in db.DesignElementPrices
                          where d.DesignElementPriceId.Equals(Id)
                          select new Models.DesignElementPriceModel

                          {
                              Amount = d.Amount,
                              Comment = d.Comment,
                              DateCreated = d.DateCreated,
                              DateInactive = d.DateInactive,
                              DesignElementId = d.DesignElementId,
                              DesignElementPriceId = d.DesignElementPriceId,
                              EffectiveDate = d.EffectiveDate,
                              ServiceTypeCode = d.ServiceTypeCode,


                              IsActive = d.IsActive
                          }).OrderBy(x => x.DesignElementId).SingleOrDefault();

            return result;
        }


        /// <summary>
        /// Gets the material scripting price.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IMaterialScriptingPrice> getMaterialScriptingPrice(ADitEntities db)
        {
            var result = (from d in db.MaterialScriptingPrices
                          join e in db.MaterialTypes on d.MaterialTypeId equals e.MaterialTypeId
                          select new MaterialScriptingPriceModel
                          {
                              MaterialScriptingPriceId = d.MaterialScriptingPriceId,
                              ServiceTypeCode = d.ServiceTypeCode,

                              MaterialTypeId = d.MaterialTypeId,
                              MaterialTypeDescription = e.Description,
                              EffectiveDate = d.EffectiveDate,
                              DateInactive = d.DateInactive,
                              DateCreated = d.DateCreated,
                              Amount = d.Amount,
                              Comment = d.Comment,
                              IsActive = d.IsActive
                          }).OrderBy(x => x.Amount);
            return result;
        }


        /// <summary>
        /// Gets the color by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IColor GetColorById(ADitEntities db, int Id)
        {
            var result = (from d in db.Colors
                          where d.ColorId.Equals(Id)
                          select new ColorModel
                          {
                              ColorId = d.ColorId,
                              Description = d.Description
                          }
                ).SingleOrDefault();
            return result;
        }



        /// <summary>
        /// Gets the time belt by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static ITimeBelt GetTimeBeltById(ADitEntities db, int Id)
        {
            var result = (from d in db.TimeBelts
                          where d.Id.Equals(Id)
                          select new TimeBeltModel
                          {
                              TimeBeltId = d.Id,
                              Description = d.Description,
                              isActive = d.IsActive,
                              name = d.Name

                          }
                ).SingleOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the apcon approval by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IApconApprovalType GetApconApprovalById(ADitEntities db, int Id)
        {
            var result = (from d in db.ApconApprovalTypes
                          where d.ApconApprovalTypeId.Equals(Id)
                          select new ApconApprovalTypeModel
                          {
                              ApoconTypeId = d.ApconApprovalTypeId,
                              Description = d.Description
                          }).SingleOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the timing by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static ITiming GetTimingById(ADitEntities db, int Id)
        {
            var result = (from d in db.Timings
                          where d.TimingId.Equals(Id)
                          select new TimingModel
                          {
                              TimingId = d.TimingId,
                              Description = d.Description,
                              IsActive = d.IsActive
                          }
                ).SingleOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the material type identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IMaterialType GetMaterialTypeId(ADitEntities db, int Id)
        {
            var result = (from d in db.MaterialTypes
                          where d.MaterialTypeId.Equals(Id)
                          select new MaterialTypeModel
                          {
                              MaterialTypeId = d.MaterialTypeId,
                              Description = d.Description
                          }
                ).SingleOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the duration type identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        internal static IDurationType GetDurationTypeId(ADitEntities db, string code)
        {
            var result = (from d in db.DurationTypes
                          where d.DurationTypeCode.Equals(code)
                          select new DurationTypeModel
                          {
                              DurationTypeCode = d.DurationTypeCode,
                              Description = d.Description
                          }
                ).SingleOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the material production price by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IMaterialProductionPrice getMaterialProductionPriceById(ADitEntities db, int Id)
        {
            var result = (from d in db.MaterialProductionPrices
                          where d.MaterialProductionPriceId.Equals(Id)
                          select new Models.MaterialProductionPriceModel
                          {
                              MaterialProductionPriceId = d.MaterialProductionPriceId,
                              ServiceTypeCode = d.ServiceTypeCode,
                              MaterialTypeId = d.MaterialTypeId,
                              DateCreated = d.DateCreated,
                              DateInactive = d.DateInactive,
                              EffectiveDate = d.EffectiveDate,
                              Amount = d.Amount,
                              Comment = d.Comment,
                              IsActive = d.IsActive
                          }).SingleOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the type of the duration.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IDurationType> getDurationType(ADitEntities db)
        {
            var result = (from d in db.DurationTypes
                          select new Models.DurationTypeModel
                          {
                              DurationTypeCode = d.DurationTypeCode,
                              Description = d.Description,
                              IsActive = d.IsActive
                          }).OrderBy(x => x.Description);
            return result;
        }


        /// <summary>
        /// Gets the timing.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<ITiming> getTiming(ADitEntities db)
        {
            var result = (from d in db.Timings
                          select new Models.TimingModel
                          {
                              Description = d.Description,
                              TimingId = d.TimingId,

                              IsActive = d.IsActive
                          }).OrderBy(x => x.TimingId);
            return result;
        }


        /// <summary>
        /// Gets the tv timing.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IMaterialTypeTimingModel> getTVTiming(ADitEntities db)
        {
            var result = (from d in db.MaterialTypeTimings
                          join e in db.MaterialTypes on d.MaterialTypeId equals e.MaterialTypeId
                          join f in db.Timings on d.TimingId equals f.TimingId
                          where d.ServiceTypeCode.Equals("TV")
                          select new Models.MaterialTypeTimingModel
                          {
                              MaterialTypeTimingId = d.MaterialTypeTimingId,
                              ServiceTypeCode = d.ServiceTypeCode,
                              MaterialType = e.Description,
                              Timing = f.Description,
                              MaterialTypeId = d.MaterialTypeId,
                              TimingId = d.TimingId,
                              IsActive = d.IsActive
                          }).OrderBy(x => x.TimingId);

            return result;
        }


        /// <summary>
        /// Gets the material type timing.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IMaterialTypeTimingDetail> getMaterialTypeTiming(ADitEntities db)
        {
            var result = (from d in db.MaterialTypeTimings
                          join e in db.MaterialTypes on d.MaterialTypeId equals e.MaterialTypeId
                          join s in db.Timings on d.TimingId equals s.TimingId
                          select new Models.MaterialTypeTimingDetail
                          {
                              MaterialTypeTimingId = d.MaterialTypeTimingId,
                              MaterialTypeId = d.MaterialTypeId,
                              MaterialDescription = e.Description,
                              TimingDescription = s.Description,
                              ServiceTypeCode = d.ServiceTypeCode,
                              TimingId = d.TimingId,

                              IsActive = d.IsActive
                          }).OrderBy(x => x.TimingId);
            return result;
        }

        /// <summary>
        /// Gets the material type timing collection.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IMaterialTypeTimingModel> getMaterialTypeTimingCollection(ADitEntities db, int Id)
        {
            var result = (from d in db.MaterialTypeTimings
                          select new Models.MaterialTypeTimingModel
                          {
                              MaterialTypeTimingId = d.MaterialTypeTimingId,
                              TimingId = d.TimingId,
                              ServiceTypeCode = d.ServiceTypeCode,
                              MaterialTypeId = d.MaterialTypeId,

                              IsActive = d.IsActive
                          }).OrderBy(x => x.MaterialTypeTimingId);
            return result;
        }


        /// <summary>
        /// Gets the timing collection.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ITiming> getTimingCollection(ADitEntities db, int Id)
        {
            var result = (from d in db.Timings
                          select new Models.TimingModel
                          {
                              TimingId = d.TimingId,
                              Description = d.Description,
                              IsActive = d.IsActive
                          }).OrderBy(x => x.Description);
            return result;
        }


        /// <summary>
        /// Gets the material scripting price collection.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="isActiveOnly">if set to <c>true</c> [is active only].</param>
        /// <returns></returns>
        internal static IEnumerable<IMaterialScriptingPrice> getMaterialScriptingPriceCollection(ADitEntities db,
            string serviceType, bool isActiveOnly = true)
        {
            var result = (from d in db.MaterialScriptingPrices
                          join e in db.MaterialTypes on d.MaterialTypeId equals e.MaterialTypeId
                          where d.ServiceTypeCode.Equals(serviceType)
                          select new MaterialScriptingPriceModel
                          {
                              MaterialScriptingPriceId = d.MaterialScriptingPriceId,
                              ServiceTypeCode = d.ServiceTypeCode,
                              MaterialTypeId = d.MaterialTypeId,
                              Amount = d.Amount,
                              Comment = d.Comment,
                              MaterialTypeDescription = e.Description,
                              IsActive = d.IsActive
                          }).Where(y => y.IsActive == isActiveOnly ? true : y.IsActive).OrderBy(x => x.Amount);
            return result;
        }

        /// <summary>
        /// Gets the material production price.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="isActiveOnly">if set to <c>true</c> [is active only].</param>
        /// <returns></returns>
        internal static IEnumerable<IMaterialProductionPrice> getMaterialProductionPriceCollection(ADitEntities db,
            string serviceType, bool isActiveOnly = true)
        {
            var result = (from d in db.MaterialProductionPrices
                          join e in db.MaterialTypes on d.MaterialTypeId equals e.MaterialTypeId
                          where d.ServiceTypeCode.Equals(serviceType)
                          select new Models.MaterialProductionPriceModel
                          {
                              MaterialProductionPriceId = d.MaterialProductionPriceId,
                              ServiceTypeCode = d.ServiceTypeCode,
                              MaterialTypeId = d.MaterialTypeId,
                              Amount = d.Amount,
                              Comment = d.Comment,
                              MaterialTypeDescription = e.Description,
                              IsActive = d.IsActive
                          }).Where(y => y.IsActive == isActiveOnly ? true : y.IsActive).OrderBy(x => x.Amount);
            return result;
        }

        /// <summary>
        /// Gets the material timing collection.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="isActiveOnly">if set to <c>true</c> [is active only].</param>
        /// <returns></returns>
        internal static IEnumerable<IMaterialTypeTimingDetail> getMaterialTimingCollection(ADitEntities db,
            string serviceType, bool isActiveOnly = true)
        {
            var result = (from d in db.MaterialTypeTimings
                          join e in db.MaterialTypes on d.MaterialTypeId equals e.MaterialTypeId
                          join f in db.Timings on d.TimingId equals f.TimingId
                          where d.ServiceTypeCode.Equals(serviceType)
                          select new Models.MaterialTypeTimingDetail
                          {
                              MaterialTypeTimingId = d.MaterialTypeTimingId,
                              MaterialTypeId = d.MaterialTypeId,
                              MaterialDescription = e.Description,
                              TimingId = d.TimingId,
                              TimingDescription = f.Description,
                              ServiceTypeCode = d.ServiceTypeCode,
                              IsActive = d.IsActive,
                          }).Where(y => y.IsActive == isActiveOnly ? true : y.IsActive).OrderBy(x => x.MaterialDescription);
            return result;
        }

        /// <summary>
        /// Gets the script material question collection.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IScriptMaterialQuestion> getScriptMaterialQuestionCollection(ADitEntities db)
        {
            var result = (from d in db.ScriptMaterialQuestions
                          select new Models.ScriptMaterialQuestionModel
                          {
                              ScriptMaterialQuestionCode = d.ScriptMaterialQuestionCode,
                              Description = d.Description
                          }).OrderBy(x => x.Description);
            return result;
        }

        /// <summary>
        /// Gets the material production price.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IMaterialProductionPrice> getMaterialProductionPrice(ADitEntities db)
        {
            var result = (from d in db.MaterialProductionPrices
                          join e in db.MaterialTypes on d.MaterialTypeId equals e.MaterialTypeId
                          select new Models.MaterialProductionPriceModel
                          {
                              MaterialProductionPriceId = d.MaterialProductionPriceId,
                              ServiceTypeCode = d.ServiceTypeCode,
                              MaterialTypeId = d.MaterialTypeId,
                              MaterialTypeDescription = e.Description,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              EffectiveDate = d.EffectiveDate,
                              DateInactive = d.DateInactive,
                              Amount = d.Amount,
                              Comment = d.Comment
                          }).OrderBy(x => x.Amount);
            return result;
        }

        /// <summary>
        /// Gets the apcon approval type price collection.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="isActiveOnly">if set to <c>true</c> [is active only].</param>
        /// <returns></returns>
        internal static IEnumerable<IApconApprovalTypePrice> getApconApprovalTypePriceCollection(ADitEntities db,
            bool isActiveOnly = true)
        {
            var result = (from d in db.ApconApprovalTypePrices
                          join e in db.ApconApprovalTypes on d.ApconApprovalTypeId equals e.ApconApprovalTypeId
                          select new Models.ApconApprovalTypePriceModel
                          {
                              ApconTypePriceId = d.ApconApprovalTypePriceId,
                              ApconTypeId = d.ApconApprovalTypeId,
                              Amount = d.Amount,
                              ApconTypeDescription = e.Description,
                              IsActive = d.IsActive
                          }).Where(y => y.IsActive == isActiveOnly ? true : y.IsActive).OrderBy(x => x.Amount);
            return result;
        }


        /// <summary>
        /// Gets the timing collection by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static ITiming getTimingCollectionById(ADitEntities db, int Id)
        {
            var result = (from d in db.Timings
                          where d.TimingId.Equals(Id)
                          select new Models.TimingModel
                          {
                              TimingId = d.TimingId,
                              Description = d.Description,
                              IsActive = d.IsActive
                          }).SingleOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IColor> getColor(ADitEntities db)
        {
            var result = (from d in db.Colors
                          select new Models.ColorModel
                          {
                              ColorId = d.ColorId,
                              Description = d.Description
                          }).OrderBy(x => x.Description);
            return result;
        }

        /// <summary>
        /// Gets the design element.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IDesignElement> getDesignElement(ADitEntities db)
        {
            var result = (from d in db.DesignElements
                          where d.IsActive==true
                          select new Models.DesignElementModel
                          {
                              DesignElementId = d.DesignElementId,
                              Description = d.Description,
                              IsActive = d.IsActive
                          }).OrderBy(x => x.Description);
            return result;
        }


        /// <summary>
        /// Gets the design element price.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IDesignElementPrice> getDesignElementPrice(ADitEntities db)
        {
            var result = (from d in db.DesignElementPrices
                         join e in db.DesignElements on d.DesignElementId equals e.DesignElementId
                      join f in db.ServiceTypes on d.ServiceTypeCode equals f.ServiceTypeCode
                          select new Models.DesignElementPriceModel
                          {
                              Comment = d.Comment,
                              DateCreated = d.DateCreated,
                              DateInactive = d.DateInactive,
                              Description = e.Description,
                          ServiceTypeCode = f.Description,
                              DesignElementPriceId = d.DesignElementPriceId,
                              EffectiveDate = d.EffectiveDate,
                              IsActive = d.IsActive,
                              DesignElementId = d.DesignElementId,
                              Amount = d.Amount
                          }).OrderBy(x => x.Amount);
            return result;
        }

        /// <summary>
        /// Gets the design element description by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="typeDescriptionId">The type description identifier.</param>
        /// <returns></returns>
        internal static IDesignElement getDesignElementDescriptionByID(ADitEntities db, int typeDescriptionId)
        {
            var result = (from d in db.DesignElements
                          where d.DesignElementId.Equals(typeDescriptionId)
                          select new DesignElementModel
                          {
                              Description = d.Description
                          }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the material scripting price by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IMaterialScriptingPrice getMaterialScriptingPriceById(ADitEntities db, int Id)
        {
            var result = (from d in db.MaterialScriptingPrices
                          where d.MaterialScriptingPriceId.Equals(Id)
                          select new MaterialScriptingPriceModel
                          {
                              MaterialScriptingPriceId = d.MaterialScriptingPriceId,
                              ServiceTypeCode = d.ServiceTypeCode,
                              MaterialTypeId = d.MaterialTypeId,
                              EffectiveDate = d.EffectiveDate,
                              DateInactive = d.DateInactive,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive,

                              Amount = d.Amount,
                              Comment = d.Comment
                          }).SingleOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the material type timing by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IMaterialTypeTimingModel getMaterialTypeTimingById(ADitEntities db, int Id)
        {
            var result = (from d in db.MaterialTypeTimings
                          where d.MaterialTypeTimingId.Equals(Id)
                          select new MaterialTypeTimingModel
                          {
                              MaterialTypeTimingId = d.MaterialTypeTimingId,
                              MaterialTypeId = d.MaterialTypeId,
                              ServiceTypeCode = d.ServiceTypeCode,
                              TimingId = d.TimingId,
                              IsActive = true
                          }).OrderBy(x => x.MaterialTypeTimingId).SingleOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the scripting price by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IMaterialScriptingPrice getScriptingPriceById(ADitEntities db, int Id)
        {
            var result = (from d in db.MaterialScriptingPrices
                          join e in db.MaterialTypes on d.MaterialTypeId equals e.MaterialTypeId
                          select new Models.MaterialScriptingModel
                          {
                              MaterialScriptingPriceId = d.MaterialScriptingPriceId,
                              Amount = d.Amount,
                              MaterialTypeDescription = e.Description,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              EffectiveDate = d.EffectiveDate,
                              DateInactive = d.DateInactive,
                              MaterialTypeId = d.MaterialTypeId,
                              Comment = d.Comment
                          }).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the production price by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IMaterialProductionPrice getProductionPriceById(ADitEntities db, int Id)
        {
            var result = (from d in db.MaterialProductionPrices
                          join e in db.MaterialTypes on d.MaterialTypeId equals e.MaterialTypeId
                          select new Models.MaterialProductionPriceModel
                          {
                              MaterialProductionPriceId = d.MaterialProductionPriceId,
                              Amount = d.Amount,
                              MaterialTypeDescription = e.Description,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              EffectiveDate = d.EffectiveDate,
                              DateInactive = d.DateInactive,
                              MaterialTypeId = d.MaterialTypeId,
                              Comment = d.Comment
                          }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the scripting price by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IMaterialScriptingPrice getScriptingPriceByIdForRadio(ADitEntities db, int Id)
        {
            var result = (from d in db.MaterialScriptingPrices
                          join e in db.MaterialTypes on d.MaterialTypeId equals e.MaterialTypeId
                          where e.MaterialTypeId.Equals(Id) && d.ServiceTypeCode.Equals("R")
                          select new Models.MaterialScriptingModel
                          {
                              MaterialScriptingPriceId = d.MaterialScriptingPriceId,
                              Amount = d.Amount,
                              MaterialTypeDescription = e.Description,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              EffectiveDate = d.EffectiveDate,
                              DateInactive = d.DateInactive,
                              MaterialTypeId = d.MaterialTypeId,
                              Comment = d.Comment
                          }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the production price by identifier for radio.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IMaterialProductionPrice getProductionPriceByIdForRadio(ADitEntities db, int Id)
        {
            var result = (from d in db.MaterialProductionPrices
                          join e in db.MaterialTypes on d.MaterialTypeId equals e.MaterialTypeId
                          where e.MaterialTypeId.Equals(Id) && d.ServiceTypeCode.Equals("R")
                          select new Models.MaterialProductionPriceModel
                          {
                              MaterialProductionPriceId = d.MaterialProductionPriceId,
                              Amount = d.Amount,
                              MaterialTypeDescription = e.Description,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              EffectiveDate = d.EffectiveDate,
                              DateInactive = d.DateInactive,
                              MaterialTypeId = d.MaterialTypeId,
                              Comment = d.Comment
                          }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the scripting price by identifier for tv.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IMaterialScriptingPrice getScriptingPriceByIdForTv(ADitEntities db, int Id)
        {
            var result = (from d in db.MaterialScriptingPrices
                          join e in db.MaterialTypes on d.MaterialTypeId equals e.MaterialTypeId
                          where d.MaterialTypeId.Equals(Id) && d.ServiceTypeCode.Equals("T")
                          select new Models.MaterialScriptingModel
                          {
                              MaterialScriptingPriceId = d.MaterialScriptingPriceId,
                              Amount = d.Amount,
                              MaterialTypeDescription = e.Description,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              EffectiveDate = d.EffectiveDate,
                              DateInactive = d.DateInactive,
                              MaterialTypeId = d.MaterialTypeId,
                              Comment = d.Comment
                          }).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the production price by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IMaterialProductionPrice getProductionPriceByIdForTv(ADitEntities db, int Id)
        {
            var result = (from d in db.MaterialProductionPrices
                          join e in db.MaterialTypes on d.MaterialTypeId equals e.MaterialTypeId
                          where d.MaterialTypeId.Equals(Id) && d.ServiceTypeCode.Equals("T")
                          select new Models.MaterialProductionPriceModel
                          {
                              MaterialProductionPriceId = d.MaterialProductionPriceId,
                              Amount = d.Amount,
                              MaterialTypeDescription = e.Description,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              EffectiveDate = d.EffectiveDate,
                              DateInactive = d.DateInactive,
                              MaterialTypeId = d.MaterialTypeId,
                              Comment = d.Comment
                          }).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the online extra service by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IOnlineExtraServicePrice getOnlineExtraServiceById(ADitEntities db, int Id)
        {
            var result = (from d in db.OnlineExtraServicePrices
                          join e in db.OnlineExtraServices on d.OnlineExtraServiceId equals e.OnlineExtraServiceId
                          where e.OnlineExtraServiceId.Equals(Id)
                          select new OnlineExtraServicePriceModel
                          {
                              OnlineExtraServicePriceId = d.OnlineExtraServicePriceId,
                              Amount = d.Amount,
                              OnlineExtraDescription = e.Description,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              EffectiveDate = d.EffectiveDate,
                              DateInactive = d.DateInactive,
                              OnlineExtraServiceId = d.OnlineExtraServiceId,
                              Comment = d.Comment
                          }).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the artwork price.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IOnlineArtworkPrice> getArtworkPrice(ADitEntities db)
        {
            var result = (from d in db.ArtWorkPrices
                          select new ArtworkPriceModel
                          {
                              ServiceTypeCode = d.ServiceTypeCode,
                              IsActive = d.IsActive,
                              EffectiveDate = d.EffectiveDate,
                              DateInactive = d.DateInactive,
                              DateCreated = d.DateCreated,
                              Comment = d.Comment,
                              ArtWorkPriceId = d.ArtWorkPriceId,
                              Amount = d.Amount,
                          }).OrderBy(x => x.Amount);

            return result;
        }


        /// <summary>
        /// Gets the online artwork price by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IOnlineArtworkPrice getOnlineArtworkPriceById(ADitEntities db, int Id)
        {
            var result = (from d in db.ArtWorkPrices
                          where d.ArtWorkPriceId.Equals(Id)
                          select new OnlineArtworkPriceModel

                          {
                              ArtWorkPriceId = d.ArtWorkPriceId,
                              Amount = d.Amount,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              EffectiveDate = d.EffectiveDate,
                              DateInactive = d.DateInactive,
                              ServiceTypeCode = d.ServiceTypeCode,
                              Comment = d.Comment
                          }).SingleOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the online artwork price.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IOnlineArtworkPrice> getOnlineArtworkPrice(ADitEntities db)
        {
            var result = (from d in db.ArtWorkPrices
                          select new ArtworkPriceModel
                          {
                              ArtWorkPriceId = d.ArtWorkPriceId,
                              ServiceTypeCode = d.ServiceTypeCode,
                              Amount = d.Amount,
                              Comment = d.Comment,
                              EffectiveDate = d.EffectiveDate,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive
                          }).OrderBy(x => x.Amount);

            return result;
        }


        /// <summary>
        /// Gets the print transaction.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IPrintTransaction> getPrintTransaction(ADitEntities db)
        {
            var result = (from d in db.PrintTransactions
                          select new Models.PrintTransactionModel
                          {
                              PrintTransactionId = d.PrintTransactionId,
                              OrderId = d.OrderId,
                              IsHaveMaterial = d.IsHaveMaterial,
                              MaterialDigitalFileId = d.MaterialDigitalFileId,
                              ApconApprovalNumber = d.ApconApprovalNumber,
                              ApconApprovalTypeId = d.ApconApprovalTypeId,
                              ApconApprovalTypePriceId = d.ApconApprovalTypePriceId,
                              ApconApprovalAmount = d.ApconApprovalAmount,
                              PrintCategoryId = d.PrintCategoryId,
                              DesignElementId = d.DesignElementId,
                              DesignElementPriceId = d.DesignElementPriceId,
                              DesignAmount = d.DesignAmount,
                              DurationTypeCode = d.DurationTypeCode,

                              DateCreated = d.DateCreated,
                              TransactionStatusCode = d.TransactionStatusCode
                          }).OrderBy(x => x.OrderId);
            return result;
        }

        /// <summary>
        /// Gets the print transaction by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="transactonId">The transacton identifier.</param>
        /// <returns></returns>
        internal static IPrintTransaction getPrintTransactionById(ADitEntities db, int UserId, int transactonId)
        {
            var result = (from d in db.PrintTransactions
                          where d.PrintTransactionId.Equals(transactonId)
                          join u in db.UserRegistrations on UserId equals u.UserRegistrationId
                          //join e in db.PrintTransactionColors on d.PrintTransactionId equals e.PrintTransactionId
                          where d.TransactionStatusCode == "A"
                          where d.UserId.Equals(UserId)
                          select new PrintTransactionModel
                          {


                              UserName = u.FirstName,
                              PrintTransactionId = d.PrintTransactionId,
                              IsHaveMaterial = d.IsHaveMaterial,
                              MaterialDigitalFileId = d.MaterialDigitalFileId,
                              ApconApprovalNumber = d.ApconApprovalNumber,
                              ApconApprovalTypeId = d.ApconApprovalTypeId,
                              ApconApprovalTypePriceId = d.ApconApprovalTypePriceId,
                              ApconApprovalAmount = d.ApconApprovalAmount,
                              PrintCategoryId = d.PrintCategoryId,
                              DesignElementId = d.DesignElementId,
                              DesignElementPriceId = d.DesignElementPriceId,
                              DesignAmount = d.DesignAmount,
                              DurationTypeCode = d.DurationTypeCode,
                              ColorDescription = d.ColorDescription,
                              DateCreated = d.DateCreated,
                              UserId = d.UserId,
                              TransactionStatusCode = d.TransactionStatusCode,
                              //ColorId = e.ColorId,
                              OrderTitle = d.OrderTitle,
                              TotalPrice = d.TotalPrice,

                          }).FirstOrDefault();

            return result;
        }


        /// <summary>
        /// Gets the radio timing by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IMaterialTypeTimingModel> getRadioTimingById(ADitEntities db)
        {
            var result = (from d in db.MaterialTypeTimings
                          join s in db.MaterialTypes on d.MaterialTypeId equals s.MaterialTypeId
                          join b in db.ServiceTypes on d.ServiceTypeCode equals b.ServiceTypeCode
                          join t in db.Timings on d.TimingId equals t.TimingId
                          where d.ServiceTypeCode == "R"
                          select new MaterialTypeTimingModel
                          {
                              MaterialTypeId = d.MaterialTypeId,
                              MaterialType = s.Description,
                              ServiceTypeCode = b.ServiceTypeCode,
                              Timing = t.Description,
                              MaterialTypeTimingId = d.MaterialTypeTimingId,
                              TimingId = d.TimingId,
                          }).OrderBy(x => x.MaterialTypeTimingId);
            return result;
        }


        /// <summary>
        /// Gets the yes no questions.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IScriptingDetailModel> getScriptTransactionById(ADitEntities db, int Id)
        {
            var result = (from d in db.TvScriptingDetails
                          join s in db.UserAppRoles on d.AppRoleId equals s.AppRoleId
                          join e in db.UserRegistrations on d.UserId equals e.UserRegistrationId
                          where d.UserId.Equals(Id)
                          select new Models.ScriptingDetailModel
                          {
                              AppRoleId = d.AppRoleId,
                              UserId = d.UserId,
                              TvScriptingId = d.TvScriptingId,
                              UserDigitalFileId = d.UserDigitalFileId ?? -1,
                              UserComment = d.UserComment,
                              ScripterId = d.ScripterId,
                              Topic = d.Topic,
                              IsActive = d.IsActive,
                              DateApproved = d.DateApproved,
                              DateUpdated = d.DateUpdated,
                              DateCreated = d.DateCreated
                          }).OrderBy(x => x.AppRoleId);
            return result;
        }


        /// <summary>
        /// Gets the script detail by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IScriptingDetailModel GetScriptDetailById(ADitEntities db, int Id)
        {
            var result = (from d in db.TvScriptingDetails
                          where d.TvScriptingId.Equals(Id)
                          select new Models.ScriptingDetailModel
                          {
                              Topic = d.Topic,
                              UserComment = d.UserComment
                          }).SingleOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the apcon description by value.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        internal static IApconApprovalType getApconDescriptionByValue(ADitEntities db, string description)
        {
            var result = (from d in db.ApconApprovalTypes
                          where d.Description.Equals(description)
                          select new ApconApprovalTypeModel
                          {
                              IsActive = d.IsActive,
                              Description = d.Description
                          }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the color description by value.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        internal static IColor getColorDescriptionByValue(ADitEntities db, string description)
        {
            var result = (from d in db.Colors
                          where d.Description.Equals(description)
                          select new ColorModel
                          {
                              Description = d.Description
                          }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Times the belt.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        internal static ITimeBelt timeBelt(ADitEntities db, string name)
        {
            var result = (from d in db.TimeBelts
                          where d.Name.Equals(name)
                          select new TimeBeltModel
                          {
                              Description = d.Description
                          }).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the material type description by value.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        internal static IMaterialType getMaterialTypeDescriptionByValue(ADitEntities db, string description)
        {
            var result = (from d in db.MaterialTypes
                          where d.Description.Equals(description)
                          select new MaterialTypeModel
                          {
                              Description = d.Description
                          }).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the duration type description by value.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        internal static IDurationType getDurationTypeDescriptionByValue(ADitEntities db, string description)
        {
            var result = (from d in db.DurationTypes
                          where d.Description.Equals(description)
                          select new DurationTypeModel
                          {
                              Description = d.Description
                          }).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the timing description by value.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        internal static ITiming getTimingDescriptionByValue(ADitEntities db, string description)
        {
            var result = (from d in db.Timings
                          where d.Description.Equals(description)
                          select new TimingModel
                          {
                              Description = d.Description
                          }).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the design description by value.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        internal static IDesignElement getDesignDescriptionByValue(ADitEntities db, string description)
        {
            var result = (from d in db.DesignElements
                          where d.Description.Equals(description)
                          select new DesignElementModel
                          {
                              Description = d.Description
                          }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the duration of the online.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IOnlineDuration> GetOnlineDuration(ADitEntities db)
        {
            var result = (from s in db.OnlineDurations
                          select new Models.OnlineDurationModel
                          {
                              OnlineDurationId = s.OnlineDurationId,
                              Description = s.Description,
                              IsActive = s.IsActive
                          }
                ).OrderBy(p => p.OnlineDurationId);

            return result;
        }

        /// <summary>
        /// Gets the tv transaction list.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<ITvTransaction> getTvTransactionList(ADitEntities db)
        {
            var result = (from d in db.TVTransactions

                          select new Models.TvTransactionModel
                          {
                              TVTransactionId = d.TVTransactionId,
                              UserId = d.UserId,
                              IsHaveApconApproval = d.IsHaveApconApproval,
                              IsHaveMaterial = d.IsHaveMaterial,
                              ProductionDigitalFileId = d.ProductionDigitalFileId,
                              ScriptDescription = d.ScriptDescription,
                              ApconApprovalAmount = d.ApconApprovalAmount,
                              ApconApprovalNumber = d.ApconApprovalNumber,
                              ApconApprovalTypeId = d.ApconApprovalTypeId,
                              ApconApprovalTypePriceId = d.ApconApprovalTypePriceId,
                              FinalAmount = d.FinalAmount,
                              AiringInstruction = d.AiringInstruction,
                              TransactionStatusCode = d.TransactionStatusCode,
                              OrderTitle = d.OrderTitle,
                              SentToId = d.UserId,
                              IsActive = d.IsActive

                          }).OrderBy(x => x.TVTransactionId);

            return result;
        }

        /// <summary>
        /// Gets the tv transaction by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="transactonId">The transacton identifier.</param>
        /// <returns></returns>
        internal static ITvTransaction getTvTransactionById(ADitEntities db, int UserId, int transactonId)
        {
            var result = (from d in db.TVTransactions
                              //Get By UserId Also
                          join e in db.UserRegistrations on d.UserId equals e.UserRegistrationId

                          where d.UserId.Equals(UserId)
                          where d.TVTransactionId.Equals(transactonId)
                          select new TvTransactionModel
                          {
                              TVTransactionId = d.TVTransactionId,
                              UserId = d.UserId,
                              ScriptingDigitalFileId = d.ScriptingDigitalFileId,
                              IsHaveApconApproval = d.IsHaveApconApproval,
                              IsHaveMaterial = d.IsHaveMaterial,
                              ProductionDigitalFileId = d.ProductionDigitalFileId,
                              ScriptDescription = d.ScriptDescription,
                              ApconApprovalAmount = d.ApconApprovalAmount,
                              ApconApprovalNumber = d.ApconApprovalNumber,
                              ApconApprovalTypeId = d.ApconApprovalTypeId,
                              ApconApprovalTypePriceId = d.ApconApprovalTypePriceId,
                              FinalAmount = d.FinalAmount,
                              AiringInstruction = d.AiringInstruction,
                              TransactionStatusCode = d.TransactionStatusCode,
                              OrderTitle = d.OrderTitle,
                              IsActive = d.IsActive,

                              UserName = e.FirstName


                          }).SingleOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the tv script transaction by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ITvScriptingTransactionModelView> getTvScriptTransactionById(ADitEntities db, int Id, int userId)
        {

            var result = new List<TvScriptingTransactionModel>();
            return result;
        }

        /// <summary>
        /// Gets the tv material transaction by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ITvMaterialTransactionModel> GetTvMaterialTransactionById(ADitEntities db, int UserId, int transactionId)

        {

            var result = new List<TvMaterialTransactionModel>();
            return result;


        }

        /// <summary>
        /// Gets the print transaction list.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IPrintTransaction> getPrintTransactionList(ADitEntities db)
        {
            var result = (from d in db.PrintTransactions

                          select new PrintTransactionModel
                          {
                              PrintTransactionId = d.PrintTransactionId,
                              //OrderNumber = d.OrderNumber,
                              IsHaveMaterial = d.IsHaveMaterial,
                              ApconApprovalNumber = d.ApconApprovalNumber,
                              ApconApprovalTypeId = d.ApconApprovalTypeId,
                              OrderTitle = d.OrderTitle,
                              ApconApprovalTypePriceId = d.ApconApprovalTypePriceId,
                              ApconApprovalAmount = d.ApconApprovalAmount,
                              PrintCategoryId = d.PrintCategoryId,
                              MaterialDigitalFileId = d.MaterialDigitalFileId,
                              DesignElementId = d.DesignElementId,
                              DesignElementPriceId = d.DesignElementPriceId,
                              DesignAmount = d.DesignAmount,
                              DurationTypeCode = d.DurationTypeCode,
                              ColorDescription = d.ColorDescription,
                              DateCreated = d.DateCreated,
                              TransactionStatusCode = d.TransactionStatusCode,
                              SentToId = d.UserId,
                              TotalPrice = d.TotalPrice,

                          }).OrderBy(x => x.PrintTransactionId);

            return result;
        }

        /// <summary>
        /// Gets the print script transaction by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IPrintScriptingTransactionModel> getPrintScriptTransactionById(ADitEntities db, int Id, int userId)
        {

            var result = new List<PrintScriptingTransactionModel>();
            return result;
        }



        /// <summary>
        /// Gets the order type by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static IOrder GetPendingOrderByUserId(ADitEntities db, int userId)
        {
            var result = (from d in db.Orders
                          where d.OrderStatusCode == "O"
                          where d.UserId.Equals(userId)
                          select new OrderModel
                          {
                              OrderId = d.OrderId,
                              UserId = d.UserId,
                              Status = d.OrderStatusCode,
                              OrderNumber = d.OrderNumber
                          }).FirstOrDefault();
            return result;
        }



        /// <summary>
        /// Gets the order number status.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static IOrder GetOrderNumberStatus(ADitEntities db, int orderId, int userId)
        {
            var result = (from d in db.Orders
                          where d.UserId.Equals(userId)
                          where d.OrderId.Equals(orderId)
                          select new OrderModel
                          {
                              OrderId = d.OrderId,
                              UserId = d.UserId,
                              Status = d.OrderStatusCode,
                              OrderNumber = d.OrderNumber
                          }).FirstOrDefault();
            return result;
        }




        /// <summary>
        /// Gets the contactby identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IContact GetContactbyId(ADitEntities db, int Id)
        {
            var result = (from d in db.Contacts
                          where d.Id.Equals(Id)

                          select new ContactModel
                          {
                              ContactId = d.Id,
                              Email = d.Email,
                              Decsription = d.Description

                          }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the contact list.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IContact> GetContactList(ADitEntities db)
        {
            var result = (from d in db.Contacts


                          select new ContactModel
                          {
                              ContactId = d.Id,
                              Email = d.Email,
                              Decsription = d.Description

                          }).OrderBy(x => x.ContactId);
            return result;
        }




        /// <summary>
        /// Gets the time belts.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<ITimeBelt> GetTimeBelts(ADitEntities db)
        {

            var result = (from d in db.TimeBelts
                          select new TimeBeltModel
                          {
                              Description = d.Description,
                              isActive = d.IsActive,
                              name = d.Name,
                              TimeBeltId = d.Id
                          }).OrderBy(x => x.TimeBeltId);


            return result;
        }


        /// <summary>
        /// Gets the user details for email.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="Details">The details.</param>
        /// <param name="db">The database.</param>
        /// <returns></returns>










        internal static ISendMailScript GetUserDetailsForEmail(int SentToId, ADitEntities db)
        {
            var result = (from d in db.UserRegistrations
                          where d.UserRegistrationId == SentToId
                          select new SendMailScriptModel
                          {

                              FirstName = d.FirstName,
                              LastName = d.Lastname,
                              Email = d.Email
                          }
                        ).FirstOrDefault();

            return result;
        }




    }

}
   
