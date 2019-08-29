using ADit.Repositories.DataAccess;
using ADit.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ADit.Interfaces;

namespace ADit.Repositories.Queries
{
    /// <summary>
    /// 
    /// 
    /// 
    /// </summary>
    public class OnlineQueries
    {
        /// <summary>
        /// Gets the online purpose.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IOnlinePurpose> GetOnlinePurpose(ADitEntities db)
        {
            var result = (from s in db.OnlinePurposes
                    select new OnlinePurposeModel

                    {
                        OnlinePurposeId = s.OnlinePurposeId,
                        Description = s.Description,
                        IsActive = s.IsActive
                    }
                ).OrderBy(x => x.Description);
            return result;
        }

        /// <summary>
        /// Gets the online extra service.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IOnlineExtraService> GetOnlineExtraService(ADitEntities db)
        {
            var result = (from s in db.OnlineExtraServices
                    select new OnlineExtraServiceModel

                    {
                        OnlineExtraServiceId = s.OnlineExtraServiceId,
                        Description = s.Description,
                        IsActive = s.IsActive
                    }
                ).OrderBy(x => x.Description);
            return result;
        }


        /// <summary>
        /// Gets the active online extra service.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IOnlineExtraService> GetActiveOnlineExtraService(ADitEntities db)
        {
            var result = (from s in db.OnlineExtraServices
                    join t in db.OnlineExtraServicePrices on s.OnlineExtraServiceId equals t.OnlineExtraServiceId
                    where t.EffectiveDate <= DateTime.Now
                    where t.DateInactive >= DateTime.Now ||t.DateInactive==null
                    where t.IsActive
                    where s.IsActive
                    select new OnlineExtraServiceModel

                    {
                        OnlineExtraServiceId = s.OnlineExtraServiceId,
                        Description = s.Description,
                        IsActive = s.IsActive
                    }
                ).OrderBy(x => x.Description);
            return result;
        }

        /// <summary>
        /// Gets the online platform.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IOnlinePlatform> GetOnlinePlatform(ADitEntities db)
        {
            var result = (from s in db.OnlinePlatforms
                    select new OnlinePlatformModel

                    {
                        OnlinePlatformId = s.OnlinePlatformId,
                        Description = s.Description,
                        IsActive = s.IsActive
                    }
                ).OrderBy(x => x.Description);
            return result;
        }


        /// <summary>
        /// Gets the online extra service price.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IOnlineExtraServicePrice> GetOnlineExtraServicePrice(ADitEntities db)
        {
            var result = (from s in db.OnlineExtraServicePrices
                    join e in db.OnlineExtraServices on s.OnlineExtraServiceId equals e.OnlineExtraServiceId
                    select new OnlineExtraServicePriceModel

                    {
                        OnlineExtraServicePriceId = s.OnlineExtraServicePriceId,
                        OnlineExtraServiceId = s.OnlineExtraServiceId,
                        ExtraDescription = e.Description,
                        Comment = s.Comment,
                        IsActive = s.IsActive,
                        Amount = s.Amount,
                        DateCreated = s.DateCreated,
                        EffectiveDate = s.EffectiveDate,
                        DateInactive = s.DateInactive
                    }
                ).OrderBy(x => x.Comment);
            return result;
        }

        /// <summary>
        /// Gets the online extra service by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IOnlineExtraService GetOnlineExtraServiceById(ADitEntities db, int Id)
        {
            var result = (from d in db.OnlineExtraServices
                    where d.OnlineExtraServiceId.Equals(Id)
                    select new OnlineExtraServiceModel
                    {
                        OnlineExtraServiceId = d.OnlineExtraServiceId,
                        Description = d.Description,
                        IsActive = d.IsActive
                    }
                ).SingleOrDefault();
            return result;
        }




        /// <summary>
        /// Gets the online duration identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IOnlineDuration GetOnlineDurationId(ADitEntities db, int Id)
        {
            var result = (from d in db.OnlineDurations
                          where d.OnlineDurationId.Equals(Id)
                          select new OnlineDurationModel
                          {
                             OnlineDurationId = d.OnlineDurationId,
                              Description = d.Description,
                              IsActive = d.IsActive
                          }
                ).SingleOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the online platform by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IOnlinePlatform GetOnlinePlatformById(ADitEntities db, int Id)
        {
            var result = (from d in db.OnlinePlatforms
                    where d.OnlinePlatformId.Equals(Id)
                    select new OnlinePlatformModel
                    {
                        OnlinePlatformId = d.OnlinePlatformId,
                        Description = d.Description,
                        IsActive = d.IsActive
                    }
                ).SingleOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the online purpose identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IOnlinePurpose GetOnlinePurposeId(ADitEntities db, int Id)
        {
            var result = (from d in db.OnlinePurposes
                    where d.OnlinePurposeId.Equals(Id)
                    select new OnlinePurposeModel
                    {
                        OnlinePurposeId = d.OnlinePurposeId,
                        Description = d.Description,
                        IsActive = d.IsActive
                    }
                ).SingleOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the online extra service price by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IOnlineExtraServicePrice GetOnlineExtraServicePriceById(ADitEntities db, int Id)
        {
            var result = (from d in db.OnlineExtraServicePrices
                    where d.OnlineExtraServicePriceId.Equals(Id)
                    select new OnlineExtraServicePriceModel
                    {
                        OnlineExtraServicePriceId = d.OnlineExtraServicePriceId,
                        OnlineExtraServiceId = d.OnlineExtraServiceId,
                        Comment = d.Comment,
                        IsActive = d.IsActive,
                        Amount = d.Amount,
                        DateCreated = d.DateCreated,
                        EffectiveDate = d.EffectiveDate,
                        DateInactive = d.DateInactive
                    }
                ).SingleOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the online platform price.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IOnlinePlatformPrice> getOnlinePlatformPrice(ADitEntities db)
        {
            var result = (from s in db.OnlinePlatformPrices
                join e in db.OnlinePlatforms on s.OnlinePlatformId equals e.OnlinePlatformId
                join d in db.OnlineDurations on s.OnlineDurationId equals d.OnlineDurationId
                select new OnlinePlatformPriceModel
                {
                    OnlinePlatformPriceId = s.OnlinePlatformPriceId,
                    OnlinePlatformId = s.OnlinePlatformId,
                    PlatformDescription = e.Description,
                    DurationDescription = d.Description,
                    OnlineDuration = d.Description,

                    Amount = s.Amount,
                    Comment = s.Comment,
                    EffectiveDate = s.EffectiveDate,
                    DateInactive = s.DateInactive,
                    IsActive = s.IsActive ?? true,
                    DateCreated = s.DateCreated
                }).OrderBy(x => x.Amount);
            return result;
        }


        /// <summary>
        /// Gets the online platform price by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="platformPriceId">The identifier.</param>
        /// <returns></returns>
        internal static IOnlinePlatformPrice getOnlinePlatformPriceById(ADitEntities db, int platformPriceId)
        {
            var result = (from d in db.OnlinePlatformPrices
                where d.OnlinePlatformPriceId.Equals(platformPriceId)
                select new OnlinePlatformPriceModel
                {
                    DateCreated = d.DateCreated,
                    EffectiveDate = d.EffectiveDate,
                    DateInactive = d.DateInactive,
                    OnlineDurationId = d.OnlineDurationId,
                    OnlinePlatformPriceId = d.OnlinePlatformPriceId,
                    Amount = d.Amount,
                    IsActive = d.IsActive ?? true,
                    Comment = d.Comment,
                    DurationTypeCode = d.DurationTypeCode,
                    OnlinePlatformId = d.OnlinePlatformId
                }).SingleOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the name of the online platform by.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="onlinePlatfromName">Name of the online platfrom.</param>
        /// <returns></returns>
        internal static IOnlinePlatform GetOnlinePlatformByName(ADitEntities db, string onlinePlatfromName)
        {
            var result = (from d in db.OnlinePlatforms
                    where d.Description.Equals(onlinePlatfromName)
                    select new OnlinePlatformModel
                    {
                        OnlinePlatformId = d.OnlinePlatformId,
                        Description = d.Description,
                        IsActive = d.IsActive
                    }
                ).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the name of the online purpose.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="purposeName">Name of the purpose.</param>
        /// <returns></returns>
        internal static IOnlinePurpose GetOnlinePurposeName(ADitEntities db, string purposeName)
        {
            var result = (from d in db.OnlinePurposes
                    where d.Description.Equals(purposeName)
                    select new OnlinePurposeModel
                    {
                        OnlinePurposeId = d.OnlinePurposeId,
                        Description = d.Description,
                        IsActive = d.IsActive
                    }
                ).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the online duration by description.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        internal static IOnlineDuration GetOnlineDurationByDescription(ADitEntities db, string description)
        {
            var result = (from s in db.OnlineDurations
                    where s.Description.Equals(description)
                    select new Models.OnlineDurationModel
                    {
                        OnlineDurationId = s.OnlineDurationId,
                        Description = s.Description,
                        IsActive = s.IsActive
                    }
                ).FirstOrDefault();

            return result;
        }


        /// <summary>
        /// Gets the online platform price identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="packageId">The package identifier.</param>
        /// <param name="durationId">The duration identifier.</param>
        /// <returns></returns>
        /// 09066894642
        internal static IOnlinePlatformPrice getOnlinePlatformPriceId(ADitEntities db, int packageId,
            int durationId)
        {
            var result = (from s in db.OnlinePlatformPrices
                where s.OnlinePlatformId.Equals(packageId)
                where s.OnlineDurationId.Equals(durationId)
                where s.EffectiveDate <= DateTime.UtcNow
                where s.DateInactive >= DateTime.UtcNow || s.DateInactive==null
                select new OnlinePlatformPriceModel
                {
                    OnlinePlatformPriceId = s.OnlinePlatformPriceId,
                    OnlinePlatformId = s.OnlinePlatformId,


                    Amount = s.Amount,
                    Comment = s.Comment,
                    EffectiveDate = s.EffectiveDate,
                    DateInactive = s.DateInactive,
                    IsActive = s.IsActive ?? true,
                    DateCreated = s.DateCreated
                }).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the active online transaction.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IOnlineTransaction> getActiveOnlineTransaction(ADitEntities db, int orderId)
        {
            var result = (from d in db.OnlineTransactions
                where d.TransactionStatusCode.Equals("A")
                where d.OrderId.Equals(orderId)

              
                select new OnlineTransactionModel
                {
                    OnlineTransactionId = d.OnlineTransactionId,
                    OrderId = d.OrderId,
                    OrderTitle = d.OrderTitle,
                    OnlinePurposeId = d.OnlinePurposeId,
                    OnlinePlatformId = d.OnlinePlatformId,
                    OnlinePlatformPriceId = d.OnlinePlatformPriceId,
                    OnlinePlatformAmount = d.OnlinePlatformAmount,
                    AdditionalInformation = d.AdditionalInformation,
                    IsHaveArtWork = d.IsHaveArtWork,
                    ArtWorkPriceId = d.ArtWorkPriceId,
                    ArtWorkAmount = d.ArtWorkAmount ?? 0,
                    ArtworkDigitalFileId = d.ArtworkDigitalFileId,
                    DateCreated = d.DateCreated,
                    OnlineExtraServiceAmount = d.OnlineExtraServiceAmount,
                    TransactionStatusCode = d.TransactionStatusCode,
                    Price = d.Price,
                    UserId=d.UserId
                }).OrderBy(x => x.OnlineTransactionId);
            return result;
        }

        /// <summary>
        /// Gets the online transacton by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static IOnlineTransaction getOnlineTransactonById(ADitEntities db, int transactionId)
        {
            var result = (from d in db.OnlineTransactions
                          join b in db.UserRegistrations on d.UserId equals b.UserRegistrationId
                          join c in db.OnlinePurposes on d.OnlinePurposeId equals c.OnlinePurposeId into onlinePurpose
                          from online in onlinePurpose.DefaultIfEmpty()
                where d.TransactionStatusCode.Equals("A")
                where d.OnlineTransactionId.Equals(transactionId)
               
                select new OnlineTransactionModel
                {
                    Name=b.FirstName,
                    Email=b.Email,
                    PhoneNumber=b.PhoneNumber,
                    OnlinePurpose=online.Description,
                    OnlineTransactionId = d.OnlineTransactionId,
                    OrderId = d.OrderId,
                    OrderTitle = d.OrderTitle,
                    OnlinePurposeId = d.OnlinePurposeId,
                    OnlinePlatformId = d.OnlinePlatformId,
                    OnlinePlatformPriceId = d.OnlinePlatformPriceId,
                    OnlinePlatformAmount = d.OnlinePlatformAmount,
                    AdditionalInformation = d.AdditionalInformation,
                    IsHaveArtWork = d.IsHaveArtWork,
                    ArtWorkPriceId = d.ArtWorkPriceId,
                    ArtWorkAmount = d.ArtWorkAmount ?? 0,
                    ArtworkDigitalFileId = d.ArtworkDigitalFileId,
                    DateCreated = d.DateCreated,
                    Price = d.Price,
                    OnlineExtraServiceAmount = d.OnlineExtraServiceAmount,
                    TransactionStatusCode = d.TransactionStatusCode,
                    UserId=d.UserId,
                    
                }).FirstOrDefault();
            return result;
        }

        //gets online extra service
        /// <summary>
        /// Gets the online extra service transaction by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static IOnlineTransactionExtraService getOnlineExtraServiceTransactionById(ADitEntities db,
            int transactionId)
        {
            var result = (from d in db.OnlineTransactionExtraServices
                          join f in db.OnlineExtraServices on d.OnlineExtraServiceId equals f.OnlineExtraServiceId into onlineExtraService
                          where d.OnlineTransactionId.Equals(transactionId)
                          from onlineExtra in onlineExtraService.DefaultIfEmpty()
                select new OnlineTransactionExtraServiceModel
                {
                   OnlineExtraService=onlineExtra.Description,
                    OnlineTransactionExtraServiceId = d.OnlineTransactionExtraServiceId,
                    OnlineTransactionId = d.OnlineTransactionId,
                    OnlineExtraServiceId = d.OnlineExtraServiceId,
                    OnlineExtraServiceAmount = d.OnlineExtraServiceAmount,
                    OnlineExtraServicePriceId = d.OnlineExtraServicePriceId,

                    IsActive = d.IsActive,
                }).SingleOrDefault();
            return result;
        }

        //gets online  Aiiring transaction by Id
        /// <summary>
        /// Gets the online transaction airing.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IOnlineTransactionAiringUI> getOnlineTransactionAiring(ADitEntities db,
            int transactionId)
        {
            var result = (from s in db.OnlineTransactionAirings
                    where s.OnlineTransactionId.Equals(transactionId)
                    join e in db.OnlineDurations on s.OnlineDurationId equals e.OnlineDurationId
                    join g in db.OnlinePlatforms on s.OnlinePlatformId equals g.OnlinePlatformId
                    
                    select new OnlineTransactionAiringUI
                    {
                        IsActive = s.IsActive,

                        OnlineTransactionAiringId = s.OnlineTransactionAiringId,
                        OnlinePlatformId = s.OnlinePlatformId,
                        OnlineDurationId = s.OnlineDurationId,
                        OnlineTransactionId = s.OnlineTransactionId,
                        OnlineDurationDesccription=e.Description,
                        OnlinePlatformDescription=g.Description,
                       

                        IsSelected = true,
                         
                        Price = s.Price
                    }
                ).OrderBy(x => x.OnlinePlatformId);
            return result;
        }


        /// <summary>
        /// Gets all online transactions.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IOnlineTransaction> GetAllOnlineTransactions(ADitEntities db)
        {
            var result = (from s in db.OnlineTransactions
                where s.TransactionStatusCode.Equals("A")
                where s.IsActive.Equals(true)
                select new OnlineTransactionModel
                {
                    AdditionalInformation = s.AdditionalInformation,
                    ArtWorkAmount = s.ArtWorkAmount,

                    ArtworkDigitalFileId = s.ArtworkDigitalFileId,
                    ArtWorkPriceId = s.ArtWorkPriceId,
                    DateCreated = s.DateCreated,
                    OnlinePlatformId = s.OnlinePlatformId,
                    OrderId = s.OrderId,
                    OrderTitle = s.OrderTitle,
                    OnlineTransactionId = s.OnlineTransactionId,
                    UserId = s.UserId,
                    TransactionStatusCode = s.TransactionStatusCode,
                    SentToId = s.UserId
                }).OrderBy(x => x.OnlineTransactionId);
            return result;
        }

        /// <summary>
        /// Gets the online artwork transaction by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IOnlineArtworkTransacton> GetOnlineArtworkTransactionById(ADitEntities db,
            int UserId, int transactionId)

        {
         
            var result = new List<OnlineArtworkTransactionModel>();
            // return result;

            return result;
        }


        /// <summary>
        /// Gets the online transaction by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        internal static IOnlineTransactionUI GetOnlineMainTransactionById(ADitEntities db, int transactionId) 

        {
            var result = (from d in db.OnlineTransactions
                    join b in db.UserRegistrations on d.UserId equals b.UserRegistrationId
                    where d.OnlineTransactionId == transactionId
                    where d.IsActive == true
                    where d.TransactionStatusCode == "A"
                    select new OnlineTransactionUI
                    {
                        OnlineTransactionId = d.OnlineTransactionId,
                        OrderTitle = d.OrderTitle,
                        //UserName = b.FirstName,
                        OnlinePlatformAmount = d.OnlinePlatformAmount,
                        OnlineExtraServiceAmount = d.OnlineExtraServiceAmount,
                        OnlineArtworkAmount = d.ArtWorkAmount,
                        ArtWorkPriceId = d.ArtWorkPriceId,
                        IsHaveArtWork = d.IsHaveArtWork,
                        OnlinePurposeId = d.OnlinePurposeId,
                        AdditionalInformation = d.AdditionalInformation,
                        FinalAmount = d.Price,
                        ArtworkDigitalFileId = d.ArtworkDigitalFileId??0,
                        UserId = d.UserId,
                        IsActive = d.IsActive,
                        OrderId = d.OrderId,
                        TransactionStatusCode = d.TransactionStatusCode,
                        Price = d.Price
                        
                    }
                ).SingleOrDefault();

            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        internal static IOnlineTransaction GetOnlineTransactionById(ADitEntities db, int transactionId)

        {
            var result = (from d in db.OnlineTransactions
                          join b in db.UserRegistrations on d.UserId equals b.UserRegistrationId
                          where d.OnlineTransactionId == transactionId
                          where d.IsActive == true
                          select new OnlineTransactionModel
                          {
                              OnlineTransactionId = d.OnlineTransactionId,
                              OrderTitle = d.OrderTitle,
                              //UserName = b.FirstName,
                              OnlinePlatformAmount = d.OnlinePlatformAmount,
                              OnlineExtraServiceAmount = d.OnlineExtraServiceAmount,
                              ArtWorkAmount = d.ArtWorkAmount,
                              ArtWorkPriceId = d.ArtWorkPriceId,
                              IsHaveArtWork = d.IsHaveArtWork,
                              OnlinePurposeId = d.OnlinePurposeId,
                              AdditionalInformation = d.AdditionalInformation,
                              OrderId=d.OrderId,
                              ArtworkDigitalFileId = d.ArtworkDigitalFileId,
                              UserId = d.UserId,
                          }
                ).SingleOrDefault();

            return result;
        }




        /// <summary>
        /// Gets the online attachment transaction by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        internal static IOnlineTransactionAttachment GetOnlineAttachmentTransactionById(ADitEntities db, int UserId, int transactionId)

        {
            var result = (from d in db.OnlineTransactionAttachments
                         
                          where d.OnlineTransactionId == transactionId
                         
                          where d.IsActive == true
                          select new OnlineTransactionAttachmentModel
                          {
                             
                             DigitalFileId=d.DigitalFileId,
                             IsActive=d.IsActive,
                             OnlineTransactionAttachmentId=d.OnlineTransactionAttachmentId,
                             OnlineTransactionId=d.OnlineTransactionId,
                          }
                ).SingleOrDefault();

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
        /// Gets the online art work price by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IOnlineArtworkPrice GetOnlineArtWorkPriceById(ADitEntities db, int Id)  
        {
            var result = (from d in db.ArtWorkPrices
                          join s in db.ServiceTypes on d.ServiceTypeCode equals s.ServiceTypeCode
                          where d.ArtWorkPriceId.Equals(Id)
                          select new ArtworkPriceModel

                          {
                              Amount = d.Amount,
                              Comment = d.Comment,
                              DateCreated = d.DateCreated,
                              DateInactive = d.DateInactive,
                              ArtWorkPriceId = d.ArtWorkPriceId,
                              EffectiveDate = d.EffectiveDate,
                              ServiceTypeCode = s.Description,


                              IsActive = d.IsActive
                          }).OrderBy(x => x.ArtWorkPriceId).SingleOrDefault();

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
                          join e in db.ArtWorkPrices on d.ArtWorkPriceId equals e.ArtWorkPriceId
                          select new Models.ArtworkPriceModel
                          {
                              Comment = d.Comment,
                              DateCreated = d.DateCreated,
                              DateInactive = d.DateInactive,
                              ServiceTypeCode = d.ServiceTypeCode,
                              ArtWorkPriceId = d.ArtWorkPriceId,
                              EffectiveDate = d.EffectiveDate,
                              IsActive = d.IsActive,
                              Amount = d.Amount
                          }).OrderBy(x => x.Amount);
            return result;
        }

        /// <summary>
        /// Gets the printing art work price.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IOnlineArtworkPrice> getPrintingArtWorkPrice(ADitEntities db) 
        {
            var result = (from d in db.ArtWorkPrices
                          join e in db.ArtWorkPrices on d.ArtWorkPriceId equals e.ArtWorkPriceId
                          where d.ServiceTypeCode == "P" // ArtWork for Only Print
                          where d.EffectiveDate <= DateTime.UtcNow
                          where d.DateInactive >= DateTime.UtcNow || d.DateInactive == null
                          where d.IsActive == true
                          where e.IsActive == true
                          select new Models.OnlineArtworkPriceModel
                          {
                              ArtWorkPriceId = d.ArtWorkPriceId,
                              Amount = d.Amount,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              EffectiveDate = d.EffectiveDate,
                              DateInactive = d.DateInactive,
                              Comment = d.Comment
                          }).OrderBy(x => x.Amount);
            return result;
        }

        /// <summary>
        /// Gets the art work price.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IOnlineArtworkPrice> getArtWorkPrice(ADitEntities db)
        {
            var result = (from d in db.ArtWorkPrices
                         
                          join o in db.ServiceTypes on d.ServiceTypeCode equals o.ServiceTypeCode

                          where d.ServiceTypeCode == "O"
                          where d.EffectiveDate <= DateTime.UtcNow
                          where d.DateInactive == null
                        
                        
                          select new Models.OnlineArtworkPriceModel
                          {
                              ArtWorkPriceId = d.ArtWorkPriceId,
                              Amount = d.Amount,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              ServiceTypeCode=o.ServiceTypeCode,
                              EffectiveDate = d.EffectiveDate,
                              DateInactive = d.DateInactive,
                              Comment = d.Comment
                          }).OrderBy(x => x.Amount);
            return result;
        
        }




    }
} 