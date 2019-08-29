using ADit.Interfaces;
using ADit.Repositories.DataAccess;
using ADit.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADit.Repositories.Queries
{
    public class TvQueries
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        internal static IEnumerable<ITvStation> GetTvStations(ADitEntities db)
        {
            var result = (from s in db.TVStations
                    select new TvStationModel
                    {
                        TVStationId = s.TVStationId,
                        Description = s.Description,
                        IsActive = s.IsActive
                    }
                ).OrderBy(x => x.Description);
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        internal static ITvStation GetTvStationById(ADitEntities db, int Id)
        {
            var result = (from d in db.TVStations
                    where d.TVStationId.Equals(Id)
                    select new TvStationModel
                    {
                        TVStationId = d.TVStationId,
                        Description = d.Description,
                    }
                ).SingleOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the tv stations.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<ITvTransaction> GetActiveTvTransactions(ADitEntities db, int orderId)
        {
            var result = (from s in db.TVTransactions
                   
                    where s.OrderId.Equals(orderId)
                    where s.TransactionStatusCode.Equals("A")
                    where s.IsActive.Equals(true)
                    
                    select new TvTransactionModel
                    {
                        TVTransactionId = s.TVTransactionId,
                        TransactionStatusCode = s.TransactionStatusCode,
                        ApconApprovalTypeId = s.ApconApprovalTypeId,
                        AiringInstruction = s.AiringInstruction,
                        ApconApprovalAmount = s.ApconApprovalAmount,
                        ApconApprovalNumber = s.ApconApprovalNumber,
                        ApconApprovalTypePriceId = s.ApconApprovalTypePriceId,
                        FinalAmount = s.FinalAmount,
                        IsHaveApconApproval = s.IsHaveApconApproval,
                        ScriptDescription = s.ScriptDescription,
                        ScriptingDigitalFileId = s.ScriptingDigitalFileId,
                        DateCreated = s.DateCreated,
                        ProductionDigitalFileId = s.ProductionDigitalFileId,
                        IsHaveMaterial = s.IsHaveMaterial,
                        OrderId = s.OrderId,
                        OrderTitle = s.OrderTitle,
                        UserId = s.UserId,
                        ProductionAmount = s.ProductionAmount,
                        ScriptingAmount = s.ScriptingAmount,
                    }
                ).OrderBy(x => x.TVTransactionId);


            return result;
        }


        /// <summary>
        /// Gets the tv station description.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        internal static ITvStation getTvStationDescription(ADitEntities db, string description)
        {
            var result = (from d in db.TVStations
                where d.Description.Equals(description)
                select new TvStationModel
                {
                    IsActive = d.IsActive,
                    Description = d.Description
                }).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the tv transacton by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static ITvOrder getTvTransactonById(ADitEntities db, int transactionId)
        {
            var result = (from d in db.TVTransactions
                          join m in db.ApconApprovalTypes on d.ApconApprovalTypeId equals m.ApconApprovalTypeId into apconApprovalTypes
                          join n in db.UserRegistrations  on d.UserId equals n.UserRegistrationId into users
                from apconApproval in apconApprovalTypes.DefaultIfEmpty()
                from user in users.DefaultIfEmpty()

                where d.TVTransactionId.Equals(transactionId)
                where d.TransactionStatusCode == "A"
              //  where d.UserId.Equals(userId)
                select new TvOrder
                {ScriptMaterialQuestionCode=d.ScriptMaterialQuestionCode,
                    ScriptingDigitalFileId=d.ScriptingDigitalFileId??-1,
                    PhoneNumber=user.PhoneNumber,
                    email= user.Email,
                    Name= user.FirstName,
                    ApconType= apconApproval.Description,
                    TvTransactionId = d.TVTransactionId,
                    OrderTitle = d.OrderTitle,
                    AiringDescription = d.AiringInstruction,
                    ApconApprovalAmount = d.ApconApprovalAmount,
                    ApconApprovalId = d.ApconApprovalTypeId,
                    ApconApprovalNumber = d.ApconApprovalNumber,
                    ApconApprovalTypePriceId = d.ApconApprovalTypePriceId,
                    ApconTypePrice = d.ApconApprovalAmount,
                    DateCreated = d.DateCreated,
                    IsHaveApconApproval = d.IsHaveApconApproval,
                    ScriptDescription = d.ScriptDescription,
                    MaterialTypeId = d.MaterialTypeId,
                    ScriptingAmount = d.ScriptingAmount,
                    ProductionAmount = d.ProductionAmount,
                    MaterialScriptingPriceId = d.MaterialScriptingPriceId,
                    MaterialProductionPriceId = d.MaterialProductionPriceId,
                    //OrderNumber = d.OrderNumber,
                    FinalAmount = d.FinalAmount,
                    IsActive = d.IsActive,
                    MaterialDigitalFileId = d.ProductionDigitalFileId,
                   UserId=d.UserId,
                   OrderId=d.OrderId,
                   
                }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        internal static IEnumerable<ITVServicePricesList> GetITVServicePricesList(ADitEntities db)
        {
            var result = (from d in db.TvServicesPrices
                join e in db.TVStations on d.TVStationId equals e.TVStationId
                join f in db.MaterialTypes on d.MaterialTypeId equals f.MaterialTypeId
                join s in db.Timings on d.TimingId equals s.TimingId
                select new Models.TvServicesPriceListModel
                {
                    TvServicesPriceListId = d.TvServicesPriceId,

                    Amount = d.Amount,
                    TvStation = d.TVStationId,
                    DateEffective = d.DateEffective,
                    MaterialTypeDescription=f.Description,
                    DateInActive = d.DateInActive,
                    Time = d.TimingId,
                    IsActive = d.IsActive,
                    TvStationDescription = e.Description,
                    TimingDescription = s.Description
                }).OrderBy(x => x.Time);
            return result;
        }

        /// <summary>
        /// Gets the itv service prices list by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static ITVServicePricesList GetITVServicePricesListById(ADitEntities db, int Id)
        {
            var result = (from d in db.TvServicesPrices
                where d.TvServicesPriceId.Equals(Id)
                where d.IsActive == true
                select new TvServicesPriceListModel
                {
                    
                    TvServicesPriceListId = d.TvServicesPriceId,
                    Amount = d.Amount,
                    TvStation = d.TVStationId,
                    DateEffective = d.DateEffective,
                    DateInActive = d.DateInActive,
                    MaterialTypeId=d.MaterialTypeId,
                    Time = d.TimingId,
                    IsActive = d.IsActive,
                    TimingBeltId = d.TimeBeltId
                }).OrderBy(x => x.TvServicesPriceListId).SingleOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the tv transaction airing.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// 

        //internal static ITVServicePricesList GetITVServicePricesListById(ADitEntities db, int Id)
        //{
        //    var result = (from d in db.TvServicesPrices
        //                  where d.TvServicesPriceId.Equals(Id)
        //                  where d.IsActive == true
        //                  select new TvServicesPriceListModel
        //                  {
        //                      TvServicesPriceListId = d.TvServicesPriceId,
        //                      Amount = d.Amount,
        //                      TvStation = d.TVStationId,
        //                      DateEffective = d.DateEffective,
        //                      DateInActive = d.DateInActive,
        //                      Time = d.TimingId,
        //                      IsActive = d.IsActive,
        //                      TimingBeltId = d.TimeBeltId
        //                  }).OrderBy(x => x.TvServicesPriceListId).SingleOrDefault();
        //    return result;
        //}


        /// <summary>
        /// Gets the tv transaction airing.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// 
        internal static IEnumerable<ITvTransactionAiringUI> getTvTransactionAiringList(ADitEntities db,
            int transactionId)
        {
            var result = (from s in db.TVTransactionAirings
                          where s.TVTransactionId.Equals(transactionId)
                          //join e in db.TVStations on s.TVStationId equals e.TVStationId
                          //join n in db.TimeBelts on s.TimeBeltId equals n.Id
                          //join g in db.Timings on s.MaterialTypeTimingId equals g.TimingId


                          select new TvAiringTransactionUIModel
                          {
                              EndDate = s.EndDate,
                              StartDate = s.StartDate,
                              TimeBeltId = s.TimeBeltId,
                              TimingId = s.MaterialTypeTimingId,
                              Slots = s.Slots,
                              TotalSlots = s.TotalSlots,
                              TvTransactionId = s.TVTransactionId,
                              IsActive = s.IsActive,
                              TvTransactionAiringId = s.TVTransactionAiringId,
                              MaterialTypeTimingId = s.MaterialTypeTimingId,
                              TvStationId = s.TVStationId,
                              Price = s.Price,
                              IsSelected = true,

                          }
                ).OrderBy(x => x.TvStationId);
            return result;
        }




        internal static IEnumerable<ITvTransactionAiring> getTvTransactionAiring(ADitEntities db,
            int transactionId)
        {
            var result = (from s in db.TVTransactionAirings
                    where s.TVTransactionId.Equals(transactionId)
                    join e in db.TVStations on s.TVStationId equals e.TVStationId 
                    join n in db.TimeBelts on s.TimeBeltId equals n.Id
                    join g in db.Timings on s.MaterialTypeTimingId equals g.TimingId 
                   
                  
                    select new TvTransactionAiringModel
                    {
                        TVTransactionId = s.TVTransactionId,
                        TotalSlots = s.TotalSlots,
                        IsActive = s.IsActive,
                        TVTransactionAiringId = s.TVTransactionAiringId,
                        Slots = s.Slots,
                        DurationTypeCode = s.DurationTypeCode,
                        MaterialTypeTimingId = s.MaterialTypeTimingId,
                        TVStationId = s.TVStationId,
                        TVStationName = e.Description,
                   
                        TimingName = g.Description,
                        Price = s.Price,
                        StartDate = s.StartDate,
                        EndDate = s.EndDate,
                        TimeBeltId = s.TimeBeltId,
                        TimeBeltName=n.Name,
                    }
                ).OrderBy(x => x.TVStationId);
            return result;
        }


        /// <summary>
        /// Gets the tv transaction airing information.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="tvStationId">The tv station identifier.</param>
        /// <returns></returns>
        internal static ITvTransactionAiring getTvTransactionAiringInformation(ADitEntities db,
            int transactionId, int tvStationId)
        {
            var result = (from s in db.TVTransactionAirings
                    where s.TVTransactionId.Equals(transactionId)
                          join t in db.TimeBelts on s.TimeBeltId equals t.Id
                          join x in db.Timings on s.MaterialTypeTimingId equals x.TimingId
                          join g in db.MaterialTypeTimings on s.MaterialTypeTimingId equals g.MaterialTypeTimingId
                          where s.TVStationId.Equals(tvStationId)
                    select new TvTransactionAiringModel
                    {
                        TVTransactionId = s.TVTransactionId,
                        TotalSlots = s.TotalSlots,
                        IsActive = s.IsActive,
                        TVTransactionAiringId = s.TVTransactionAiringId,
                        Slots = s.Slots,
                        DurationTypeCode = s.DurationTypeCode,
                        MaterialTypeTimingId = s.MaterialTypeTimingId,
                        TVStationId = s.TVStationId,
                        Price = s.Price,
                        StartDate = s.StartDate,
                        EndDate = s.EndDate,
                        TimeBeltId = s.TimeBeltId,
                    }
                ).First();

            return result;
        }


        /// <summary>
        /// Gets the tv effective prices.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="tvStationId">The tv station identifier.</param>
        /// <param name="timingId">The timing identifier.</param>
        /// <param name="timeBeltId">The time belt identifier.</param>
        /// <returns></returns>
        internal static ITVServicePricesList GetTvEffectivePrices(ADitEntities db,
            int tvStationId, int timingId, int timeBeltId,int materialTypeId)
        {
            var result = (from d in db.TvServicesPrices
                where d.TVStationId.Equals(tvStationId)
                where d.MaterialTypeId.Equals(materialTypeId)
                where d.TimingId.Equals(timingId)
                where d.TimeBeltId.Equals(timeBeltId)
                where d.IsActive 
                where d.DateEffective <= DateTime.Now
                where d.DateInActive >= DateTime.UtcNow ||d.DateInActive==null
                select new TvServicesPriceListModel
                {
                    TvServicesPriceListId = d.TvServicesPriceId,
                    Amount = d.Amount,
                    TvStation = d.TVStationId,
                    DateEffective = d.DateEffective,
                    DateInActive = d.DateInActive,
                    Time = d.TimingId,
                    IsActive = d.IsActive,
                    TimingBeltId = d.TimeBeltId,
                    
                }).SingleOrDefault();
            return result;
        }

       
       
        internal static ITvTransaction GetTvTransactionById(ADitEntities db, int SentToId, int transactionId)

        {
            var result = (from d in db.TVTransactions
                    join b in db.UserRegistrations on d.UserId equals b.UserRegistrationId
                    where d.UserId == SentToId
                    where d.TVTransactionId == transactionId
                    where d.IsActive == true
                    
                    select new TvTransactionModel
                    {
                        TVTransactionId = d.TVTransactionId,
                        OrderTitle = d.OrderTitle,
                        UserName = b.FirstName,
                        ScriptingDigitalFileId = d.ScriptingDigitalFileId,
                        UserId = d.UserId,
                        ProductionDigitalFileId = d.ProductionDigitalFileId,
                        AiringInstruction=d.AiringInstruction,
                        OrderId=d.OrderId,
                       
                    }
                ).SingleOrDefault();

            return result;
        }
    }
}