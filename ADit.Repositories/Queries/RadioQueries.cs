using ADit.Interfaces;
using ADit.Repositories.DataAccess;
using ADit.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADit.Repositories.Queries
{
    public class RadioQueries
    {
        /// <summary>
        /// Gets the radio station.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IRadioStationModel> getRadioStation(ADitEntities db)
        {
            var result = (from d in db.RadioStations
                select new Models.RadioStationModel
                {
                    RadioStationId = d.RadioStationId,
                    Description = d.Description,
                    IsActive = d.IsActive
                }).OrderBy(x => x.Description);
            return result;
        }

        /// <summary>
        /// Gets the radio station by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IRadioStationModel getRadioStationById(ADitEntities db, int Id)
        {
            var result = (from d in db.RadioStations
                where d.RadioStationId.Equals(Id)
                select new Models.RadioStationModel
                {
                    RadioStationId = d.RadioStationId,
                    Description = d.Description,
                    IsActive = d.IsActive
                }).SingleOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the script material question.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IScriptMaterialQuestion> getScriptMaterialQuestion(ADitEntities db)
        {
            var result = (from d in db.ScriptMaterialQuestions
                select new Models.ScriptMaterialQuestionModel
                {
                    ScriptMaterialQuestionCode = d.ScriptMaterialQuestionCode,
                    Description = d.Description
                }).OrderBy(x => x.Description);
            return result;
        }


        internal static IEnumerable<IRadioTransaction> getActiveRadioTranasction(ADitEntities db, int orderId)
        {
            var result = (from s in db.RadioTransactions
                    // join d in db.OrderCodes on s.UserId equals d.UserId
                    //     where d.OrderNumber.Equals(s.OrderNumber)
                    where s.OrderId.Equals(orderId)
                    where s.TransactionStatusCode.Equals("A")
                    where s.IsActive.Equals(true)
                    select new RadioTransactionModel
                    {
                        RadioTransactionId = s.RadioTransactionId,
                        TransactionStatusCode = s.TransactionStatusCode,
                        ApconApprovalTypeId = s.ApconApprovalTypeId,
                        AiringInstruction = s.AiringInstruction,

                        ApconApprovalAmount = s.ApconApprovalAmount,
                        ApconApprovalNumber = s.ApconApprovalNumber,
                        ApconApprovalTypePriceId = s.ApconApprovalTypePriceId,
                        FinalAmount = s.FinalAmount,
                        IsHaveApconApproval = s.IsHaveApconApproval,
                        ScriptDescription = s.ScriptDescription,
                        ScriptingDigitalFileId = s.ScriptDigitalFileId,
                        DateCreated = s.DateCreated,
                        ProductionDigitalFileId = s.MaterialDigitalFileId,
                        IsHaveMaterial = s.IsHaveMaterial,
                        OrderId = s.OrderId,
                        OrderTitle = s.OrderTitle,
                        UserId = s.UserId,
                        ScriptingAmount = s.ScriptingAmount,
                        ProductionAmount = s.ProductionAmount,
                    }
                ).OrderBy(x => x.RadioTransactionId);
            return result;
        }

        /// <summary>
        /// Gets the radio transaction airing.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IRadioTransactionAiring> getRadioTransactionAiring(ADitEntities db,
            int transactionId)
        {
            var result = (from s in db.RadioTransactionAirings
                    where s.RadioTransactionId.Equals(transactionId)
                    join e in db.RadioStations on s.RadioStationId equals e.RadioStationId into radiostations
                    join f in db.DurationTypes on s.DurationTypeCode equals f.DurationTypeCode into durationTypes
                    join t in db.TimeBelts on s.TimeBeltId equals t.Id into timebelt
                    join x in db.Timings on s.MaterialTypeTimingId equals x.TimingId into timing
                    join g in db.MaterialTypeTimings on s.MaterialTypeTimingId equals g.MaterialTypeTimingId into
                        materialtypetming
                    from radio in radiostations.DefaultIfEmpty()
                    from duration in durationTypes.DefaultIfEmpty()
                    from time in timebelt.DefaultIfEmpty()
                    from timings in timing.DefaultIfEmpty()
                    from materialtime in materialtypetming.DefaultIfEmpty()
                    select new RadioTransactionAiringModel
                    {
                        EndDate = s.EndDate,
                        StartDate = s.StartDate,
                        TimeBeltId = s.TimeBeltId,
                        Slots = s.Slots,
                        TotalSlots = s.TotalSlots,
                        RadioTransactionId = s.RadioTransactionId,
                        // MaterialQuestionId = s.
                        // AiringNumberPerDay = s.AiringNumberPerDay,
                        IsActive = s.IsActive,
                        RadioTransactionAiringId = s.RadioTransactionAiringId,
                        // DurationQuantity = s.DurationQuantity,
                        DurationTypeCode = s.DurationTypeCode,
                        MaterialTypeTimingId = s.MaterialTypeTimingId,
                        RadioStationId = s.RadioStationId,
                        RadioStationName = radio.Description,
                        DurationName = duration.Description,
                        TimingName = timings.Description,
                        Price = s.Price,
                        TimeBeltName = time.Name,
                        // MaterialTypTimingName=materialtime.Description,
                    }
                ).OrderBy(x => x.RadioStationId);
            return result;
        }

        /// <summary>
        /// Gets the radio transacton by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="cartId">The cart identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// 
        internal static IEnumerable<IMaterialType> getActvieMaterialTypeForRadio(ADitEntities db)
        {
            var result = (from d in db.MaterialTypes
                join e in db.MaterialScriptingPrices on d.MaterialTypeId equals e.MaterialTypeId
                join f in db.MaterialProductionPrices on d.MaterialTypeId equals f.MaterialTypeId
                where d.IsActive.Equals(true) &&
                      e.ServiceTypeCode.Equals("Radio") &&
                      e.IsActive.Equals(true) && e.EffectiveDate <= DateTime.Now && e.DateInactive > DateTime.Now &&
                      f.ServiceTypeCode.Equals("Radio") &&
                      f.IsActive.Equals(true) && f.EffectiveDate <= DateTime.Now && f.DateInactive > DateTime.Now
                select new MaterialTypeModel
                {
                    MaterialTypeId = d.MaterialTypeId,
                    Description = d.Description,
                    IsActive = d.IsActive
                }).OrderBy(x => x.Description);

            return result;
        }

        /// <summary>
        /// Gets the radio transacton by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="transactionId">The cart identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static IRadioOrder getRadioTransactonById(ADitEntities db, int transactionId)
        {
            var result = (from d in db.RadioTransactions
                join u in db.UserRegistrations on d.UserId equals u.UserRegistrationId
                join a in db.ApconApprovalTypes on d.ApconApprovalTypeId equals a.ApconApprovalTypeId into Apcontypes
                join m in db.MaterialTypes on d.MaterialTypeId equals m.MaterialTypeId
                // join p in db.ApconApprovalTypePrices on d.ApconApprovalTypePriceId equals p.ApconApprovalTypePriceId
                from apcon in Apcontypes.DefaultIfEmpty()
                where d.RadioTransactionId.Equals(transactionId)
                where d.TransactionStatusCode == "A"
                // where d.UserId.Equals(userId)
                select new RadioOrder

                {
                    OrderId = d.OrderId,
                    userId = d.UserId,
                    FirstName = u.FirstName,
                    LastName = u.Lastname,
                    PhoneNumber = u.PhoneNumber,
                    Email = u.Email,
                    RadioTransactionId = transactionId,
                    OrderTitle = d.OrderTitle,
                    ApconType = apcon.Description,
                    AiringDescription = d.AiringInstruction,
                    ApconApprovalAmount = d.ApconApprovalAmount,
                    ApconApprovalTypeId = d.ApconApprovalTypeId,
                    ApconApprovalNumber = d.ApconApprovalNumber,
                    ApconApprovalTypePriceId = d.ApconApprovalTypePriceId,
                    ApconTypePrice = d.ApconApprovalAmount,
                    DateCreated = d.DateCreated,
                    IsHaveApconApproval = d.IsHaveApconApproval,
                    MaterialQuestionId = d.ScriptMaterialQuestionCode,
                    ScriptDescription = d.ScriptDescription,
                    MaterialTypeId = d.MaterialTypeId,
                    MaterialTypeName = m.Description,
                    ScriptingAmount = d.ScriptingAmount,
                    ProductionAmount = d.ProductionAmount,
                    MaterialScriptingPriceId = d.MaterialScriptingPriceId,
                    MaterialProductionPriceId = d.MaterialProductionPriceId,
                    //OrderId = d.OrderId,
                    FinalAmount = d.FinalAmount,
                    IsActive = d.IsActive,
                    IsHaveMaterial = d.IsHaveMaterial,
                    ScriptDigitalFileId = d.ScriptDigitalFileId,
                    MaterialDigitalFileId = d.MaterialDigitalFileId,
                }).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the radio transaction.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IRadioTransaction> GetRadioTransaction(ADitEntities db)
        {
            var result = (from s in db.RadioTransactions
                select new RadioTransactionModel
                {
                    RadioTransactionId = s.RadioTransactionId,
                    TransactionStatusCode = s.TransactionStatusCode,


                    AiringInstruction = s.AiringInstruction,


                    ProductionDigitalFileId = s.MaterialDigitalFileId,

                    //OrderNumber = s.OrderNumber,
                    OrderTitle = s.OrderTitle,
                    UserId = s.UserId,
                }).OrderBy(x => x.UserId);

            return result;
        }


        /// <summary>
        /// Gets the radio production view by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IRadioTransaction GetRadioProductionViewById(ADitEntities db, int Id)
        {
            var result = (from s in db.RadioTransactions
                join b in db.UserRegistrations on s.UserId equals b.UserRegistrationId
                where s.RadioTransactionId.Equals(Id)
                select new RadioTransactionModel
                {
                    RadioTransactionId = s.RadioTransactionId,
                    TransactionStatusCode = s.TransactionStatusCode,
                    ApconApprovalTypeId = s.ApconApprovalTypeId,
                    AiringInstruction = s.AiringInstruction,

                    ApconApprovalAmount = s.ApconApprovalAmount,
                    ApconApprovalNumber = s.ApconApprovalNumber,
                    ApconApprovalTypePriceId = s.ApconApprovalTypePriceId,
                    FinalAmount = s.FinalAmount,
                    IsHaveApconApproval = s.IsHaveApconApproval,
                    ScriptDescription = s.ScriptDescription,
                    ScriptingDigitalFileId = s.ScriptDigitalFileId,
                    DateCreated = s.DateCreated,
                    ProductionDigitalFileId = s.MaterialDigitalFileId,
                    IsHaveMaterial = s.IsHaveMaterial,
                    //OrderNumber = s.OrderNumber,
                    OrderTitle = s.OrderTitle,
                    UserName = b.FirstName,
                    ScriptingAmount = s.ScriptingAmount,
                    ProductionAmount = s.ProductionAmount,
                }).SingleOrDefault();

            return result;
        }


        /// <summary>
        /// Gets the radio prodution.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IRadioProduction> getRadioProdution(ADitEntities db)
        {
            var result = (from d in db.RadioProductions
                select new RadioProductionModel
                {
                    DateCreated = d.DateCreated,
                    IsActive = d.IsActive,
                    ProductionManagerId = d.ProductionManagerId,
                    ProductionManagerNote = d.ProductionManagerNote,
                    RadioManagerProductionDigitalId = d.RadioManagerProductionDigitalId,
                    RadioProductionId = d.RadioProductionId,
                    RadioTransactionId = d.RadioTransactionId,
                    RadioUserProductionDigitalId = d.RadioUserProductionDigitalId,
                    UserNote = d.UserNote
                }).OrderBy(x => x.RadioProductionId);

            return result;
        }


        /// <summary>
        /// Gets the radio station description.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        internal static IRadioStationModel getRadioStationDescription(ADitEntities db, string description)
        {
            var result = (from d in db.RadioStations
                where d.Description.Equals(description)
                select new RadioStationModel
                {
                    IsActive = d.IsActive,
                    Description = d.Description
                }).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the radio station price.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="radioStationId">The radio station identifier.</param>
        /// <param name="materialTypeTimingId">The material type timing identifier.</param>
        /// <param name="durationCode">The duration code.</param>
        /// <returns></returns>
        internal static IRadioServicePriceListModel GetRadioStationPrice(ADitEntities db, int radioStationId,
            int timingId,int materialTypeId)
        {
            var result = (from d in db.RadioServicePrices
                where d.RadioId.Equals(radioStationId)
                where d.TimingId.Equals(timingId)
                          where d.MaterialTypeId.Equals(materialTypeId)
                where d.DateEffective <= DateTime.Now
                where d.DateInActive >= DateTime.Now || d.DateInActive == null
                select new RadioServicePriceListModel
                {
                    IsActive = d.IsActive,
                    Amount = d.Amount,
                }).FirstOrDefault();
            return result;
        }





        internal static IRadioTransaction GetRadioTransactionById(ADitEntities db, int SentToId, int transactionId)

        {
            var result = (from d in db.RadioTransactions
                    join b in db.UserRegistrations on d.UserId equals b.UserRegistrationId
                    where d.UserId == SentToId
                    where d.RadioTransactionId == transactionId
                    where d.IsActive == true
                    select new RadioTransactionModel
                    {
                        RadioTransactionId = d.RadioTransactionId,
                        OrderTitle = d.OrderTitle,
                        UserName = b.FirstName,
                        ScriptingDigitalFileId = d.ScriptDigitalFileId,
                        UserId = d.UserId,
                        ProductionDigitalFileId = d.MaterialDigitalFileId,

                        LastName = b.Lastname,
                        AiringInstruction = d.AiringInstruction
                    }
                ).SingleOrDefault();

            return result;
        }


        internal static IRadioServicePriceListModel GetRadioEffectivePrices(ADitEntities db,
            int RadioStationId, int timingId, int timeBeltId,int materialType)
        {
            var result = (from d in db.RadioServicePrices
                where d.RadioId == RadioStationId
                where d.MaterialTypeId==materialType
                where d.TimingId == timingId
                where d.TimeBeltId == timeBeltId
                where d.IsActive == true
                select new RadioServicePriceListModel

                {
                    Id = d.Id,
                    RadioId = d.RadioId,


                    Amount = d.Amount,
                    TimingBeltId = d.TimeBeltId,
                    DateEffective = d.DateEffective,
                    DateInActive = d.DateInActive,
                    TimingId = d.TimingId,
                    IsActive = d.IsActive
                }).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets all radio transaction.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IRadioTransaction> getAllRadioTransaction(ADitEntities db)
        {
            var result = (from s in db.RadioTransactions
                    where s.TransactionStatusCode.Equals("A")
                    where s.IsActive.Equals(true)
                    select new RadioTransactionModel
                    {
                        RadioTransactionId = s.RadioTransactionId,
                        TransactionStatusCode = s.TransactionStatusCode,
                        ApconApprovalTypeId = s.ApconApprovalTypeId,
                        AiringInstruction = s.AiringInstruction,

                        ApconApprovalAmount = s.ApconApprovalAmount,
                        ApconApprovalNumber = s.ApconApprovalNumber,
                        ApconApprovalTypePriceId = s.ApconApprovalTypePriceId,
                        FinalAmount = s.FinalAmount,
                        IsHaveApconApproval = s.IsHaveApconApproval,
                        ScriptDescription = s.ScriptDescription,
                        ScriptingDigitalFileId = s.ScriptDigitalFileId,
                        DateCreated = s.DateCreated,
                        ProductionDigitalFileId = s.MaterialDigitalFileId,
                        IsHaveMaterial = s.IsHaveMaterial,
                        ///*OrderNumber*/ = s.OrderNumber,
                        OrderTitle = s.OrderTitle,
                        SentToId = s.UserId,
                        ScriptingAmount = s.ScriptingAmount,
                        ProductionAmount = s.ProductionAmount,
                    }
                ).OrderBy(x => x.RadioTransactionId);
            return result;
        }

        /// <summary>
        /// Gets the radio transacton UI by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns>IRadioTransactionUI.</returns>
        internal static IRadioTransactionUI getRadioTransactonUIById(ADitEntities db, int transactionId)
        {
            var result = (from s in db.RadioTransactions
                    where s.RadioTransactionId.Equals(transactionId)
                    select new RadioTransactionUI
                    {
                        RadioTransactionId = s.RadioTransactionId,
                        TransactionStatusCode = s.TransactionStatusCode,
                        ApconApprovalTypeId = s.ApconApprovalTypeId,
                        AiringInstruction = s.AiringInstruction,
                        ApconApprovalAmount = s.ApconApprovalAmount,
                        ApconApprovalNumber = s.ApconApprovalNumber,
                        ApconApprovalTypePriceId = s.ApconApprovalTypePriceId,
                        FinalAmount = s.FinalAmount,
                        IsHaveApconApproval = s.IsHaveApconApproval,
                        ScriptDescription = s.ScriptDescription,
                        ScriptDigitalFileId = s.ScriptDigitalFileId,
                        MaterialDigitalFileId = s.MaterialDigitalFileId,
                        IsHaveMaterial = s.IsHaveMaterial,
                        OrderId = s.OrderId,
                        OrderTitle = s.OrderTitle,
                        ScriptingAmount = s.ScriptingAmount,
                        ProductionAmount = s.ProductionAmount,
                        UserId = s.UserId,
                        IsActive = s.IsActive,
                        ScriptMaterialQuestionCode = s.ScriptMaterialQuestionCode,
                        MaterialProductionPriceId = s.MaterialProductionPriceId,
                        MaterialTypeId = s.MaterialTypeId
                    }
                ).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Gets the radio transacton airing UI by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns>IEnumerable&lt;IRadioTransactionAiringUI&gt;.</returns>
        internal static IEnumerable<IRadioTransactionAiringUI> getRadioTransactonAiringUIById(ADitEntities db,
            int transactionId)
        {
            var result = (from s in db.RadioTransactionAirings
                    where s.RadioTransactionId.Equals(transactionId)
                    select new RadioTransactionAiringUI
                    {
                        EndDate = s.EndDate,
                        StartDate = s.StartDate,
                        TimeBeltId = s.TimeBeltId,
                        TimingId = s.MaterialTypeTimingId,
                        Slots = s.Slots,
                        TotalSlots = s.TotalSlots,
                        RadioTransactionId = s.RadioTransactionId,
                        IsActive = s.IsActive,
                        RadioTransactionAiringId = s.RadioTransactionAiringId,
                        MaterialTypeTimingId = s.MaterialTypeTimingId,
                        RadioStationId = s.RadioStationId,
                        RadioStationPrice = s.Price,
                        IsSelected = true,
                    }
                ).OrderBy(x => x.RadioStationId);
            return result;
        }
    }
}