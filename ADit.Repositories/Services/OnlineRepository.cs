using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADit.Interfaces;
using ADit.Repositories.Factories;
using ADit.Interfaces.ValueTypes;
using ADit.Repositories.Queries;
using ADit.Repositories.DataAccess;
using System.Data.Entity.Validation;
using ADit.Repositories.Resources;

namespace ADit.Repositories.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IOnlineRepository" />
    public class OnlineRepository : IOnlineRepository
    {
        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;
        /// <summary>
        /// Initializes a new instance of the <see cref="OnlineRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public OnlineRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? new DbContextFactory(null);
        }

        /// <summary>
        /// Saves the online extra service information.
        /// </summary>
        /// <param name="onlineExtraServiceView">The online extra service view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">SaveOnlineExtraServiceInfo</exception>
        public string SaveOnlineExtraServiceInfo(IOnlineExtraServiceView onlineExtraServiceView)
        {
            var result = string.Empty;
            if (onlineExtraServiceView == null)
            {
                throw new ArgumentException("SaveOnlineExtraServiceInfo");
            }
            using (
                   var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
            {
                var aRecord = dbContext.OnlineExtraServices.SingleOrDefault(x => x.Description == onlineExtraServiceView.Description);

                if (aRecord != null)
                {
                    string processingMessage = Messages.DescriptionExist;
                    return processingMessage;
                }

            }
            var newRecord = new OnlineExtraService
            {

                Description = onlineExtraServiceView.Description,
                IsActive = true,

            };

            try
            {
                using (

                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.OnlineExtraServices.Add(newRecord);
                    dbContext.SaveChanges();
                }

            }
            catch (Exception e)
            {
                result = string.Format("Save OnlineInfo -{0}, {1}", e.Message, e.InnerException != null ? e.InnerException.Message : "");

            }

            return result;

        }

        /// <summary>
        /// Saves the online platform information.
        /// </summary>
        /// <param name="onlinePlatformView">The online platform view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">SaveOnlinePlatformInfo</exception>
        public string SaveOnlinePlatformInfo(IOnlinePlatformView onlinePlatformView)
        {
            var result = string.Empty;
            if (onlinePlatformView == null)
            {
                throw new ArgumentException("SaveOnlinePlatformInfo");
            }



            var newRecord = new OnlinePlatform
            {

                Description = onlinePlatformView.Description,
                IsActive = true,

            };

            try
            {
                using (

                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.OnlinePlatforms.Add(newRecord);
                    dbContext.SaveChanges();
                }

            }
            catch (Exception e)
            {
                result = string.Format("Save OnlineInfo -{0}, {1}", e.Message, e.InnerException != null ? e.InnerException.Message : "");

            }

            return result;

        }

        /// <summary>
        /// Saves the online purpose information.
        /// </summary>
        /// <param name="onlinePurposeView">The online purpose view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">SaveOnlinePurposeInfo</exception>
        public string SaveOnlinePurposeInfo(IOnlinePurposeView onlinePurposeView)
        {
            var result = string.Empty;
            if (onlinePurposeView == null)
            {
                throw new ArgumentException("SaveOnlinePurposeInfo");
            }

            using (
                   var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
            {
                var aRecord = dbContext.OnlinePurposes.SingleOrDefault(x => x.Description == onlinePurposeView.Description);

                if (aRecord != null)
                {
                    string processingMessage = Messages.DescriptionExist;
                    return processingMessage;
                }

            }
            var newRecord = new OnlinePurpose
            {

                Description = onlinePurposeView.Description,
                IsActive = true,

            };

            try
            {
                using (

                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.OnlinePurposes.Add(newRecord);
                    dbContext.SaveChanges();
                }

            }
            catch (Exception e)
            {
                result = string.Format("Save OnlineInfo -{0}, {1}", e.Message, e.InnerException != null ? e.InnerException.Message : "");

            }

            return result;

        }
        /// <summary>
        /// Saves the online transaction.
        /// </summary>
        /// <param name="onlineView">The online view.</param>
        /// <param name="onlineTransactionId">The online transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string SaveOnlineTransaction(IOnlineView onlineView, int onlineTransactionId)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Saves the online transaction information.
        /// </summary>
        /// <param name="onlineOrder">The online order.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        public string SaveOnlineTransactionInfo(IOnlineTransactionUIView onlineOrder, out int transactionId)
        {
            if (onlineOrder.ArtworkDigitalFileId == null)
            {
                onlineOrder.ArtworkDigitalFileId = 0;
            }


            var result = string.Empty;
            transactionId = -1;

            var newOnlineTransaction = new OnlineTransaction
            {

                OrderId = onlineOrder.OrderId,
                OnlinePurposeId = onlineOrder.OnlinePurposeId,
                OnlinePlatformId = onlineOrder.OnlinePlatformId,
                OnlinePlatformPriceId = onlineOrder.OnlinePlatformPriceId,
                OnlineExtraServiceAmount = onlineOrder.OnlineExtraServiceAmount,
                OnlinePlatformAmount = onlineOrder.OnlinePlatformAmount,
                AdditionalInformation = onlineOrder.AdditionalInformation,
                IsHaveArtWork = onlineOrder.IsHaveArtWork,
                OrderTitle = onlineOrder.OrderTitle,
                ArtWorkPriceId = onlineOrder.ArtWorkId,

                ArtWorkAmount = onlineOrder.OnlineArtworkAmount,
                ArtworkDigitalFileId = onlineOrder.ArtworkDigitalFileId,
                DateCreated = DateTime.Now,
                Price = onlineOrder.FinalAmount,
                UserId = onlineOrder.UserId,
                TransactionStatusCode = "A",
                IsActive = true,


            };

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.OnlineTransactions.Add(newOnlineTransaction);
                    dbContext.SaveChanges();
                }
            }


            catch (Exception e)
            {
                result = string.Format("SaveOnlineInfo - {0} , {1}", e.Message, e.InnerException != null ? e.InnerException.Message : "");
            }


            transactionId = newOnlineTransaction.OnlineTransactionId;

            return result;

        }

        /// <summary>
        /// Saves the online transaction airing.
        /// </summary>
        /// <param name="onlineTransactionId">The online transaction identifier.</param>
        /// <param name="transactionAiringList">The transaction airing list.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">transactionAiringList</exception>
        /// <exception cref="ArgumentOutOfRangeException">onlineTransactionId</exception> 
        public string SaveOnlineTransactionAiring(int onlineTransactionId, IList<IOnlineTransactionAiringUI> transactionAiringList)
        {
            if (transactionAiringList == null)
            {
                throw new ArgumentNullException(nameof(transactionAiringList));
            }
            if (onlineTransactionId < 1)
            {
                throw new ArgumentOutOfRangeException("onlineTransactionId");
            }

            var result = string.Empty;
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    // save transaction airings
                    foreach (var item in transactionAiringList)
                    {
                        var aSubRecord = new OnlineTransactionAiring
                        {
                            OnlineTransactionId = onlineTransactionId,
                            OnlinePlatformId = item.OnlinePlatformId,
                            OnlineDurationId = item.OnlineDurationId,
                            Price = item.Price,

                            IsActive = true
                        };

                        dbContext.OnlineTransactionAirings.Add(aSubRecord);
                    }

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveOnlineTransactionAiring - {0} , {1}", e.Message, e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="onlineTransactionId"></param>
        /// <returns></returns>
        public string DeleteOnlineTransactionAiring(int onlineTransactionId)
        {
            if (onlineTransactionId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(onlineTransactionId));
            }

            var result = string.Empty;
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var details = dbContext.OnlineTransactionAirings.Where(x => x.OnlineTransactionId.Equals(onlineTransactionId));
                    if (details.Any())
                    {
                        dbContext.OnlineTransactionAirings.RemoveRange(details);
                    }

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = $"DeleteOnlineTransactionAiring- {e.Message} , {(e.InnerException != null ? e.InnerException.Message : "")}";
            }

            return result;
        }



        /// <summary>
        /// Updates the online transaction information.
        /// </summary>
        /// <param name="onlineOrder">The online order.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineTransaction</exception>
        /// <exception cref="Exception">Repository.Save. Db Entity Validation Exception. Data not saved. Error: " + sb.ToString()</exception>
        public string UpdateOnlineTransactionInfo(IOnlineTransactionUI onlineOrder)
        {
            var result = string.Empty;


            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var onlineTransaction =
                        dbContext.OnlineTransactions.FirstOrDefault(x =>
                            x.OnlineTransactionId == onlineOrder.OnlineTransactionId);

                    var onlineExtraSeviceTransaction =
                       dbContext.OnlineTransactionExtraServices.FirstOrDefault(x =>
                           x.OnlineTransactionId == onlineOrder.OnlineTransactionId);
                    if (onlineTransaction == null)
                    {
                        throw new ArgumentNullException(nameof(onlineTransaction));
                    }

                    onlineTransaction.OnlinePurposeId = onlineOrder.OnlinePurposeId;

                    onlineTransaction.OrderTitle = onlineOrder.OrderTitle;
                    onlineTransaction.ArtWorkAmount = onlineOrder.OnlineArtworkAmount;
                    onlineTransaction.DateCreated = DateTime.Now;
                    onlineTransaction.AdditionalInformation = onlineOrder.AdditionalInformation;
                    onlineTransaction.ArtWorkPriceId = onlineOrder.ArtWorkId;
                    onlineTransaction.IsActive = true;
                    onlineTransaction.OnlineExtraServiceAmount = onlineOrder.OnlineExtraServiceAmount;
                    onlineTransaction.OnlinePlatformAmount = onlineOrder.OnlinePlatformAmount;
                    onlineTransaction.OnlinePlatformId = onlineOrder.OnlinePlatformId;
                    onlineTransaction.OnlinePlatformPriceId = onlineOrder.OnlinePlatformPriceId;

                    onlineTransaction.Price = onlineOrder.FinalAmount;
                    onlineExtraSeviceTransaction.OnlineExtraServiceId = onlineOrder.OnlineExtraServiceId;
                    onlineExtraSeviceTransaction.OnlineExtraServiceAmount = onlineOrder.OnlineExtraServiceAmount;
                    if (onlineOrder.ArtworkDigitalFileId > 0)
                    {
                        onlineOrder.ArtworkDigitalFileId = onlineTransaction.ArtworkDigitalFileId ?? 0;
                    }

                    dbContext.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                List<String> lstErrors = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    string msg = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
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

                    throw new Exception("Repository.Save. Db Entity Validation Exception. Data not saved. Error: " + sb.ToString());

                }


            }
            return result;
        }


        /// <summary>
        /// Saves the online transation airing.
        /// </summary>
        /// <param name="onlineOrder">The online order.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        public string SaveOnlineTransationAiring(IOnlineView onlineOrder, int transactionId)
        {
            var result = string.Empty;
            foreach (var item in onlineOrder.ServiceChannelList)
            {
                var platform = item["Platform"];
                var duration = item["Duration"];

                var price = item["Price"];

                var onlineAiringTransaction = new OnlineTransactionAiring
                {
                    OnlineTransactionId = transactionId,

                    OnlinePlatformId = int.Parse(platform),

                    OnlineDurationId = int.Parse(duration),



                    Price = decimal.Parse(price),

                    IsActive = true
                };

                try
                {
                    using (
                        var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                    {
                        dbContext.OnlineTransactionAirings.Add(onlineAiringTransaction);
                        dbContext.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    result = string.Format("SaveOnlineTransationAiring - {0} , {1}", e.Message,
                        e.InnerException != null ? e.InnerException.Message : "");
                }
            }

            return result;
        }


        /// <summary>
        /// Updates the online transation airing.
        /// </summary>
        /// <param name="onlineOrder">The online order.</param>
        /// <returns></returns>
        public string UpdateOnlineTransationAiring(IOnlineView onlineOrder)
        {
            var result = string.Empty;
            foreach (var item in onlineOrder.ServiceChannelList)
            {
                var platform = int.Parse(item["Platform"]);
                var duration = int.Parse(item["Duration"]);
                var price = decimal.Parse(item["Price"]);

                //If this is a new Tv Station Selected and the Price is Gre

                var onlineAiringTransaction = new OnlineTransactionAiring
                {
                    OnlineTransactionId = onlineOrder.OnlineTransactionId,

                    OnlinePlatformId = platform,

                    OnlineDurationId = duration,



                    Price = price,

                    IsActive = true
                };


                try
                {
                    //Cheking If the Airing Information is Already Stored
                    using (
                        var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                    {

                        var tvAiringInformation =
                            dbContext.OnlineTransactionAirings.FirstOrDefault(x =>
                                x.OnlineTransactionId == onlineOrder.OnlineTransactionId && x.OnlineTransactionId == platform);

                        if (tvAiringInformation != null)
                        {
                            tvAiringInformation.OnlineTransactionId = onlineOrder.OnlineTransactionId;

                            tvAiringInformation.OnlinePlatformId = platform;

                            tvAiringInformation.OnlineDurationId = duration;



                            tvAiringInformation.Price = price;


                        }
                        else
                        {

                            //If there is a new Tv Selected and the Price is greater than 0;
                            if (price > 0)
                            {
                                dbContext.OnlineTransactionAirings.Add(onlineAiringTransaction);
                            }

                        }
                        dbContext.SaveChanges();
                    }



                }
                catch (Exception e)
                {
                    result = string.Format("Update Online Platform Airing - {0} , {1}", e.Message,
                        e.InnerException != null ? e.InnerException.Message : "");
                }
            }

            return result;
        }



        /// <summary>
        /// Saves the online transaction attachment.
        /// </summary>
        /// <param name="onlineView">The online view.</param>
        /// <param name="onlineTransactionId">The online transaction identifier.</param>
        /// <returns></returns>
        public string SaveOnlineTransactionAttachment(IOnlineView onlineView, int onlineTransactionId)
        {
            var result = string.Empty;

            var attachmentRecord = new OnlineTransactionAttachment
            {
                OnlineTransactionId = onlineTransactionId,
                IsActive = true,
            };

            try
            {
                using (

                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.OnlineTransactionAttachments.Add(attachmentRecord);
                    dbContext.SaveChanges();
                }

            }
            catch (Exception e)
            {
                result = string.Format("Save AttachmentInfo -{0}, {1}", e.Message, e.InnerException != null ? e.InnerException.Message : "");

            }


            return result;
        }
        /// <summary>
        /// Saves the online transaction extra service.
        /// </summary>
        /// <param name="onlineView">The online view.</param>
        /// <param name="onlineTransactionId">The online transaction identifier.</param>
        /// <returns></returns>
        public string saveOnlineTransactionExtraService(IOnlineTransactionUIView onlineView, int onlineTransactionId)
        {
            var result = string.Empty;

            var extraServiceRecord = new OnlineTransactionExtraService
            {
                OnlineTransactionId = onlineTransactionId,
                OnlineExtraServiceId = onlineView.OnlineExtraServiceId,
                OnlineExtraServicePriceId = onlineView.OnlineExtraServicePriceId,
                OnlineExtraServiceAmount = onlineView.OnlineExtraServiceAmount,
                IsActive = true,
            };

            try
            {
                using (

                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.OnlineTransactionExtraServices.Add(extraServiceRecord);
                    dbContext.SaveChanges();
                }

            }
            catch (Exception e)
            {
                result = string.Format("Save ExtraServicetInfo -{0}, {1}", e.Message, e.InnerException != null ? e.InnerException.Message : "");

            }


            return result;
        }
        /// <summary>
        /// Edits the online extra service.
        /// </summary>
        /// <param name="onlineExtraServiceView">The online extra service view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// onlineExtraServiceView
        /// or
        /// ExtraServiceDetails
        /// </exception>
        public string EditOnlineExtraService(IOnlineExtraServiceView onlineExtraServiceView)
        {
            var result = string.Empty;

            using (
                   var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
            {
                var aRecord = dbContext.OnlineExtraServices.SingleOrDefault(x => x.Description == onlineExtraServiceView.Description);

                if (aRecord != null)
                {
                    string processingMessage = Messages.DescriptionExist;
                    return processingMessage;
                }

            }
            if (onlineExtraServiceView == null) throw new ArgumentNullException(nameof(onlineExtraServiceView));
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var ExtraServiceDetails = dbContext.OnlineExtraServices.SingleOrDefault(x => x.OnlineExtraServiceId == onlineExtraServiceView.OnlineExtraServiceId);
                    if (onlineExtraServiceView == null) throw new ArgumentNullException(nameof(ExtraServiceDetails));

                    ExtraServiceDetails.Description = onlineExtraServiceView.Description;
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





        /// <summary>
        /// Edits the online extra service.
        /// </summary>
        /// <param name="onlineExtraServiceView">The online extra service view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// onlineExtraServiceView
        /// or
        /// ExtraServiceDetails
        /// </exception>
        public string EditOnlineDuration(IOnlineDurationView onlineDurationView)
        {
            var result = string.Empty;

            using (
                   var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
            {
                var aRecord = dbContext.OnlineDurations.SingleOrDefault(x => x.Description == onlineDurationView.Description);

                if (aRecord != null)
                {
                    string processingMessage = Messages.DescriptionExist;
                    return processingMessage;
                }

            }
            if (onlineDurationView == null) throw new ArgumentNullException(nameof(onlineDurationView));
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var ExtraServiceDetails = dbContext.OnlineDurations.SingleOrDefault(x => x.OnlineDurationId == onlineDurationView.OnlineDurationId);
                    if (onlineDurationView == null) throw new ArgumentNullException(nameof(ExtraServiceDetails));

                    ExtraServiceDetails.Description = onlineDurationView.Description;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveOnlineDuration - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }
        /// <summary>
        /// Edits the online purpose.
        /// </summary>
        /// <param name="onlinePurposeView">The online purpose view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// onlinePurposeView
        /// or
        /// OnlinePurposeDetails
        /// </exception>
        public string EditOnlinePurpose(IOnlinePurposeView onlinePurposeView)
        {
            var result = string.Empty;


            using (
                   var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
            {
                var aRecord = dbContext.OnlinePurposes.SingleOrDefault(x => x.Description == onlinePurposeView.Description);

                if (aRecord != null)
                {
                    string processingMessage = Messages.DescriptionExist;
                    return processingMessage;
                }

            }
            if (onlinePurposeView == null) throw new ArgumentNullException(nameof(onlinePurposeView));
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var OnlinePurposeDetails = dbContext.OnlinePurposes.SingleOrDefault(x => x.OnlinePurposeId == onlinePurposeView.OnlinePurposeId);
                    if (onlinePurposeView == null) throw new ArgumentNullException(nameof(OnlinePurposeDetails));

                    OnlinePurposeDetails.Description = onlinePurposeView.Description;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveOnlinePurpose - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }
        /// <summary>
        /// Edits the online platform.
        /// </summary>
        /// <param name="onlinePlatformView">The online platform view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// onlinePlatformView
        /// or
        /// OnlinePlatformDetails
        /// </exception>
        public string EditOnlinePlatform(IOnlinePlatformView onlinePlatformView)
        {
            var result = string.Empty;


            if (onlinePlatformView == null) throw new ArgumentNullException(nameof(onlinePlatformView));
            using (
                   var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
            {
                var aRecord = dbContext.OnlinePlatforms.SingleOrDefault(x => x.Description == onlinePlatformView.Description);

                if (aRecord != null)
                {
                    string processingMessage = Messages.DescriptionExist;
                    return processingMessage;
                }

            }


            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var OnlinePlatformDetails = dbContext.OnlinePlatforms.SingleOrDefault(x => x.OnlinePlatformId == onlinePlatformView.OnlinePlatformId);
                    if (onlinePlatformView == null) throw new ArgumentNullException(nameof(OnlinePlatformDetails));

                    OnlinePlatformDetails.Description = onlinePlatformView.Description;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveOnlinePlatform - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }



        /// <summary>
        /// Deletes the online platform information.
        /// </summary>
        /// <param name="OnlinePlatformId">The online platform identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">OnlinePlatformId</exception>
        /// <exception cref="ArgumentNullException">OnlinePlatformDetails</exception>
        public string DeleteOnlinePlatformInfo(int OnlinePlatformId)
        {

            var result = string.Empty;
            if (OnlinePlatformId <= 0)
            {
                throw new ArgumentException(nameof(OnlinePlatformId));
            }


            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var OnlinePlatformDetails = dbContext.OnlinePlatforms.SingleOrDefault(x => x.OnlinePlatformId == OnlinePlatformId);
                    if (OnlinePlatformDetails == null) throw new ArgumentNullException(nameof(OnlinePlatformDetails));
                    OnlinePlatformDetails.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteOnlinePlatform - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }



        /// <summary>
        /// Deletes the online purpose information.
        /// </summary>
        /// <param name="onlinePurposeId">The online purpose identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">onlinePurposeId</exception>
        /// <exception cref="ArgumentNullException">OnlinePurposeDetails</exception>
        public string DeleteOnlinePurposeInfo(int onlinePurposeId)
        {
            var result = string.Empty;
            if (onlinePurposeId <= 0)
            {
                throw new ArgumentException(nameof(onlinePurposeId));
            }

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var OnlinePurposeDetails = dbContext.OnlinePurposes.SingleOrDefault(x => x.OnlinePurposeId == onlinePurposeId);
                    if (OnlinePurposeDetails == null) throw new ArgumentNullException(nameof(OnlinePurposeDetails));
                    OnlinePurposeDetails.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteOnlinePurpose - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }




        /// <summary>
        /// Deletes the online extra service information.
        /// </summary>
        /// <param name="onlineExtraServiceId">The online extra service identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">onlineExtraServiceId</exception>
        /// <exception cref="ArgumentNullException">OnlineExraServiceDetails</exception>
        public string DeleteOnlineExtraServiceInfo(int onlineExtraServiceId)
        {
            var result = string.Empty;
            if (onlineExtraServiceId <= 0)
            {
                throw new ArgumentException(nameof(onlineExtraServiceId));
            }


            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var OnlineExraServiceDetails = dbContext.OnlineExtraServices.SingleOrDefault(x => x.OnlineExtraServiceId == onlineExtraServiceId);
                    if (OnlineExraServiceDetails == null) throw new ArgumentNullException(nameof(OnlineExraServiceDetails));
                    OnlineExraServiceDetails.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteOnlineExtraService - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }







        /// <exception cref="ArgumentNullException">OnlineExraServiceDetails</exception>
        public string DeleteOnlineDurationInfo(int onlineDurationId)
        {
            var result = string.Empty;
            if (onlineDurationId <= 0)
            {
                throw new ArgumentException(nameof(onlineDurationId));
            }


            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var OnlineDurationDetails = dbContext.OnlineDurations.SingleOrDefault(x => x.OnlineDurationId == onlineDurationId);
                    if (OnlineDurationDetails == null) throw new ArgumentNullException(nameof(OnlineDurationDetails));
                    OnlineDurationDetails.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteOnlineDuration - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }










        /// <summary>
        /// Gets the online platform price.
        /// </summary>
        /// <param name="priceview">The priceview.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Repository.Save. Db Entity Validation Exception. Data not saved. Error: " + sb.ToString()</exception>
        /// <exception cref="System.ApplicationException">Repository GetOnlinePlatformPrice</exception>
        public string SavePlatfromPackagePrice(IOnlinePlatformPackagePriceView priceview)
        {
            var result = string.Empty;

            var view = new OnlinePlatformPrice
            {

                OnlinePlatformId = priceview.OnlinePlatformId,
                OnlineDurationId = priceview.OnlineDurationId,
                DurationTypeCode = priceview.DurationsTypeCode,
                Amount = priceview.Amount,
                Comment = priceview.Comment,
                EffectiveDate = priceview.EffectiveDate,
                DateInactive = null,
                IsActive = true,
                DateCreated = DateTime.Now
            };

            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var Prevprice = dbContext.OnlinePlatformPrices.Where(x => x.OnlinePlatformId == priceview.OnlinePlatformId && priceview.OnlineDurationId == x.OnlineDurationId && priceview.DurationsTypeCode == x.DurationTypeCode);
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
                    dbContext.OnlinePlatformPrices.Add(view);
                    dbContext.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                List<String> lstErrors = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    string msg = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
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

                    throw new Exception("Repository.Save. Db Entity Validation Exception. Data not saved. Error: " + sb.ToString());

                }


            }

            return result;
        }

        /// <summary>
        /// Edits the online platform price.
        /// </summary>
        /// <param name="onlinePlatformPackagePrice">The online platform package price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">EditOnlinePlatformPrice</exception>
        /// <exception cref="ArgumentNullException">onlinePlatformDetails</exception>
        public string EditOnlinePlatformPrice(IOnlinePlatformPackagePriceView onlinePlatformPackagePrice)
        {
            if (onlinePlatformPackagePrice == null)
            {
                throw new ArgumentException("EditOnlinePlatformPrice");
            }
            var result = string.Empty;
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var onlinePlatformDetails = dbContext.OnlinePlatformPrices.SingleOrDefault(x => x.OnlinePlatformPriceId == onlinePlatformPackagePrice.OnlinePlatformPriceId);
                    if (onlinePlatformDetails == null) throw new ArgumentNullException(nameof(onlinePlatformDetails));

                    onlinePlatformDetails.OnlinePlatformId = onlinePlatformPackagePrice.OnlinePlatformId;
                    onlinePlatformDetails.OnlineDurationId = onlinePlatformPackagePrice.OnlineDurationId;
                    onlinePlatformDetails.Amount = onlinePlatformPackagePrice.Amount;
                    onlinePlatformDetails.Comment = onlinePlatformPackagePrice.Comment;
                    onlinePlatformDetails.EffectiveDate = onlinePlatformPackagePrice.EffectiveDate;



                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveOnlinePacckage - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }


        /// <summary>
        /// Deletes the online platform price.
        /// </summary>
        /// <param name="onlinePlatformPackagePrice">The online platform package price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">DeleteOnlinePlatformPrice</exception>
        /// <exception cref="ArgumentNullException">onlinePlatformPackagePriceDetails</exception>
        public string DeleteOnlinePlatformPrice(int onlinePlatformPackagePrice)
        {

            if (onlinePlatformPackagePrice < 1)
            {
                throw new ArgumentException("DeleteOnlinePlatformPrice");
            }
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var onlinePlatformPackagePriceDetails = dbContext.OnlinePlatformPrices.SingleOrDefault(x => x.OnlinePlatformPriceId.Equals(onlinePlatformPackagePrice));
                    if (onlinePlatformPackagePriceDetails == null) throw new ArgumentNullException(nameof(onlinePlatformPackagePriceDetails));
                    onlinePlatformPackagePriceDetails.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("OnlinePlatformPackage - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }
        /// <summary>
        /// Saves the online extra service price.
        /// </summary>
        /// <param name="onlineExtraServicePriceView">The online extra service price view.</param>
        /// <returns></returns>
        public string SaveOnlineExtraServicePrice(IOnlineExtraServicePriceView onlineExtraServicePriceView)
        {
            var result = string.Empty;

            var view = new OnlineExtraServicePrice
            {

                OnlineExtraServiceId = onlineExtraServicePriceView.OnlineExtraServiceId,
                Amount = onlineExtraServicePriceView.Amount,
                Comment = onlineExtraServicePriceView.Comment,
                EffectiveDate = onlineExtraServicePriceView.EffectiveDate,
                DateInactive = null,
                IsActive = true,
                DateCreated = DateTime.Now
            };

            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var Prevprice = dbContext.OnlineExtraServicePrices.FirstOrDefault(x => x.OnlineExtraServiceId == onlineExtraServicePriceView.OnlineExtraServiceId);
                    if (Prevprice != null)
                    {
                        Prevprice.DateInactive = DateTime.Now;
                        Prevprice.IsActive = false;
                        dbContext.SaveChanges();
                    }
                    // calling changes
                    dbContext.OnlineExtraServicePrices.Add(view);
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
        /// Deletes the online extra service price.
        /// </summary>
        /// <param name="OnlineExtraServicePriceId">The online extra service price identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineExtraServicePriceDetails</exception>
        public string DeleteOnlineExtraServicePrice(int OnlineExtraServicePriceId)
        {
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var onlineExtraServicePriceDetails = dbContext.OnlineExtraServicePrices.SingleOrDefault(x => x.OnlineExtraServicePriceId == OnlineExtraServicePriceId);
                    if (onlineExtraServicePriceDetails == null) throw new ArgumentNullException(nameof(onlineExtraServicePriceDetails));
                    onlineExtraServicePriceDetails.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("ExtraServicePrice - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;


        }
        /// <summary>
        /// Edits the online extra service price.
        /// </summary>
        /// <param name="onlineExtraServicePriceView">The online extra service price view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// onlineExtraServicePriceView
        /// or
        /// ExtraServicePriceDetails
        /// </exception>
        /// <exception cref="Exception">Repository.Save. Db Entity Validation Exception. Data not saved. Error: " + sb.ToString()</exception>
        public string EditOnlineExtraServicePrice(IOnlineExtraServicePriceView onlineExtraServicePriceView)
        {
            var result = string.Empty;
            if (onlineExtraServicePriceView == null) throw new ArgumentNullException(nameof(onlineExtraServicePriceView));
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var ExtraServicePriceDetails = dbContext.OnlineExtraServicePrices.SingleOrDefault(x => x.OnlineExtraServicePriceId == onlineExtraServicePriceView.OnlineExtraServicePriceId);
                    if (onlineExtraServicePriceView == null) throw new ArgumentNullException(nameof(ExtraServicePriceDetails));

                    ExtraServicePriceDetails.Comment = onlineExtraServicePriceView.Comment;
                    ExtraServicePriceDetails.Amount = onlineExtraServicePriceView.Amount;
                    ExtraServicePriceDetails.DateCreated = DateTime.Now;
                    ExtraServicePriceDetails.DateInactive = onlineExtraServicePriceView.DateInactive;
                    ExtraServicePriceDetails.EffectiveDate = DateTime.Now;
                    dbContext.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                List<String> lstErrors = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    string msg = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
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

                    throw new Exception("Repository.Save. Db Entity Validation Exception. Data not saved. Error: " + sb.ToString());

                }


            }

            return result;

        }

        /// <summary>
        /// Saves the online artwork price.
        /// </summary>
        /// <param name="artWorkPriceView">The art work price view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">artWorkPriceView</exception>
        


        /// <summary>
        /// Gets the name of the online platform by.
        /// </summary>
        /// <param name="onlineName">Name of the online.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetOnlinePlatformByName</exception>
        public IOnlinePlatform GetOnlinePlatformByName(string onlineName)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var onlinePlatform = OnlineQueries.GetOnlinePlatformByName(dbContext, onlineName);

                    return onlinePlatform;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetOnlinePlatformByName", e);
            }
        }



        /// <summary>
        /// Gets the name of the online purpose.
        /// </summary>
        /// <param name="purposeName">Name of the purpose.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetOnlinePlatformByName</exception>
        public IOnlinePurpose GetOnlinePurposeName(string purposeName)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var onlinePurpose = OnlineQueries.GetOnlinePurposeName(dbContext, purposeName);

                    return onlinePurpose;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetOnlinePurposeName", e);
            }
        }

        /// <summary>
        /// Gets the online duration by description.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">GetOnlineDurationByDescription</exception>
        public IOnlineDuration GetOnlineDurationByDescription(string description)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var result = OnlineQueries.GetOnlineDurationByDescription(dbContext, description);

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("GetOnlineDurationByDescription", e);
            }
        }

        /// <summary>
        /// Saves the online duration information.
        /// </summary>
        /// <param name="onlineDurationInfo">The online duration information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineDurationInfo</exception>
        public string SaveOnlineDurationInfo(IOnlineDurationView onlineDurationInfo)
        {
            if (onlineDurationInfo == null)
            {
                throw new ArgumentNullException(nameof(onlineDurationInfo));
            }

            var result = string.Empty;


            var newRecord = new OnlineDuration
            {

                Description = onlineDurationInfo.Description,
                IsActive = true
            };

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.OnlineDurations.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save OnlineInfo -{0}, {1}", e.Message, e.InnerException != null ? e.InnerException.Message : "");

            }

            return result;
        }


        /// <summary>
        /// Gets the platform package price.
        /// </summary>
        /// <param name="packageId">The package identifier.</param>
        /// <param name="durationId">The duration identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetPlatformPackagePrice</exception>
        public IOnlinePlatformPrice GetPlatformPackagePrice(int packageId, int durationId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var onlinePlatform = OnlineQueries.getOnlinePlatformPriceId(dbContext, packageId, durationId);

                    return onlinePlatform;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetPlatformPackagePrice", e);
            }
        }

        /// <summary>
        /// Gets the active online transaction.
        /// </summary>
        /// <param name="orderNumber">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">getActiveOnlineTransaction</exception>
        public IList<IOnlineTransaction> getActiveOnlineTransaction(int orderNumber)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        OnlineQueries.getActiveOnlineTransaction(dbContext, orderNumber).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("getActiveOnlineTransaction", e);
            }
        }


        /// <summary>
        /// Gets the user online order by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetUserOnlineOrderById</exception>
        public IOnlineTransaction GetUserOnlineOrderById(int transactionId)
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = OnlineQueries.getOnlineTransactonById(dbContext, transactionId);
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetUserOnlineOrderById", e);
            }
        }


        /// <summary>
        /// Gets the online extra service transaction by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetOnlineExtraServiceTransactionById</exception>
        public IOnlineTransactionExtraService GetOnlineExtraServiceTransactionById(int transactionId)
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = OnlineQueries.getOnlineExtraServiceTransactionById(dbContext, transactionId);
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetOnlineExtraServiceTransactionById", e);
            }
        }


        /// <summary>
        /// Gets the online transaction airing.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetOnlineTransactionAiring</exception>
        public IList<IOnlineTransactionAiringUI> GetOnlineTransactionAiring(int transactionId)
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        OnlineQueries.getOnlineTransactionAiring(dbContext, transactionId).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetOnlineTransactionAiring", e);
            }
        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public string DeleteOnlineOrder(int transactionId)
        {
            var result = string.Empty;


            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var onlineTransaction =
                        dbContext.OnlineTransactions.FirstOrDefault(x =>
                            x.OnlineTransactionId == transactionId);
                    if (onlineTransaction == null)
                    {
                        throw new ArgumentNullException(nameof(onlineTransaction));
                    }

                    onlineTransaction.TransactionStatusCode = "D";
                    dbContext.SaveChanges();



                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteOnlineOrder- {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }



        /// <summary>
        /// Gets all online transaction.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAllOnlineTransaction</exception>
        public IList<IOnlineTransaction> GetAllOnlineTransaction()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        OnlineQueries.GetAllOnlineTransactions(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAllOnlineTransaction", e);
            }
        }





        /// <summary>
        /// Gets the online artwork transactons.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetRadioStationPrice</exception>
        public IList<IOnlineArtworkTransacton> GetOnlineArtworkTransactons(int UserId, int transactionId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        OnlineQueries.GetOnlineArtworkTransactionById(dbContext, UserId, transactionId).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetRadioStationPrice", e);
            }
        }



        /// <summary>
        /// Gets the online transaction.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository OnlineTransactions</exception>
        public IOnlineTransaction GetOnlineTransaction(int transactionId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        OnlineQueries.GetOnlineTransactionById(dbContext, transactionId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetOnlineTransaction", e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public IOnlineTransactionUI GetOnlineMainTransaction(int transactionId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        OnlineQueries.GetOnlineMainTransactionById(dbContext, transactionId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetOnlineMainTransaction", e);
            }
        }


        /// <summary>
        /// Gets the online attachment transaction by identifier.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetOnlineAttachmentTransactionById</exception>
        public IOnlineTransactionAttachment GetOnlineAttachmentTransactionById(int UserId, int transactionId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        OnlineQueries.GetOnlineAttachmentTransactionById(dbContext, UserId, transactionId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetOnlineAttachmentTransactionById", e);
            }
        }

        #region Art Work Price Setup


        /// <summary>
        /// Saves the art work price.
        /// </summary>
        /// <param name="artWork">The art work.</param>
        /// <returns></returns>
        public string SaveArtWorkPrice(IOnlineArtworkPriceView artWork)
        {
            var result = string.Empty;

            var view = new ArtWorkPrice
            {
                ServiceTypeCode = "O",
                ArtWorkPriceId = artWork.ArtWorkPriceId,
                Amount = artWork.Amount,
                Comment = artWork.Comment,
                EffectiveDate = artWork.EffectiveDate,
                DateInactive = null,
                IsActive = true,
                DateCreated = DateTime.Now
            };
            try
            {
                // calling our database 
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var Prevprice = dbContext.ArtWorkPrices.FirstOrDefault(x => x.ArtWorkPriceId == artWork.ArtWorkPriceId && artWork.ServiceTypeCode == x.ServiceTypeCode);
                    if (Prevprice != null)
                    {
                        Prevprice.DateInactive = DateTime.Now;
                        Prevprice.IsActive = false;
                        dbContext.SaveChanges();
                    }
                    // calling changes
                    dbContext.ArtWorkPrices.Add(view);
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
        /// Deletes the art work price.
        /// </summary>
        /// <param name="artWorkPriceId">The art work price identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">artWorkDetails</exception>

        public IList<IOnlineArtworkPrice> GetArtWorkPrice()
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = OnlineQueries.getArtWorkPrice(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetArtWorkPrice", e);
            }
        }
        /// <summary>
        /// Gets the art work price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetDepartmentById</exception>
        public IOnlineArtworkPrice GetOnlineArtWorkPriceById(int Id )
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                       OnlineQueries.GetOnlineArtWorkPriceById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetOnlineArtWorkPriceById", e);
            }
        }
        /// <summary>
        /// Deletes the art work price.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">ArtWorkPrice</exception>
        public string DeleteOnlineArtWorkPrice(int Id) 
        {
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var ArtWorkPrice = dbContext.ArtWorkPrices.SingleOrDefault(x => x.ArtWorkPriceId.Equals(Id));
                    if (ArtWorkPrice == null) throw new ArgumentNullException(nameof(ArtWorkPrice));
                    ArtWorkPrice.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteArtWorkPrice - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }
        
        /// <summary>
        /// Gets the art work price amount by identifier.
        /// </summary>
        /// <param name="artWorkPriceId">The art work price identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetArtWorkPriceAmountById</exception>
        public IOnlineArtworkPrice GetArtWorkPriceAmountById(int artWorkPriceId) 
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        OnlineQueries.GetOnlineArtWorkPriceById(dbContext, artWorkPriceId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetArtWorkPriceAmountById", e);
            }
        }

        public IList<IOnlineArtworkPrice> GetPrintArtWorkPriceList() 
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = OnlineQueries.getPrintingArtWorkPrice(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetPrintArtWorkPriceList", e);
            }
        }
        #endregion
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
        /// Edits the online art work type price.
        /// </summary>
        /// <param name="onlineArtWorkPriceView">The online art work price view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// onlineArtWorkPriceView
        /// or
        /// onlineArtWorktDetails
        /// </exception>
        public string EditOnlineArtWorkTypePrice(IOnlineArtworkPriceView onlineArtWorkPriceView) 
        {
            var result = string.Empty;
            if (onlineArtWorkPriceView == null) throw new ArgumentNullException(nameof(onlineArtWorkPriceView));
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var onlineArtWorktDetails = dbContext.ArtWorkPrices.SingleOrDefault(x =>
                        x.ArtWorkPriceId == onlineArtWorkPriceView.ArtWorkPriceId);
                    if (onlineArtWorktDetails == null) throw new ArgumentNullException(nameof(onlineArtWorktDetails));


                    onlineArtWorktDetails.Comment = onlineArtWorkPriceView.Comment;
                    onlineArtWorktDetails.Amount = onlineArtWorkPriceView.Amount;

                    onlineArtWorktDetails.DateInactive = onlineArtWorkPriceView.DateInactive;
                    onlineArtWorktDetails.ArtWorkPriceId = onlineArtWorkPriceView.ArtWorkPriceId;
                    onlineArtWorktDetails.EffectiveDate = onlineArtWorkPriceView.EffectiveDate;
                    onlineArtWorktDetails.ServiceTypeCode = onlineArtWorkPriceView.ServiceTypeCode;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveArtWorkType - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        public string SaveOnlineArtworkPrice(IOnlineArtworkPriceView onlineArtWork)
        {
            var result = string.Empty;

            var view = new ArtWorkPrice
            {
                ServiceTypeCode = "O",
                ArtWorkPriceId = onlineArtWork.ArtWorkPriceId,
                Amount = onlineArtWork.Amount,
                Comment = onlineArtWork.Comment,
                EffectiveDate = onlineArtWork.EffectiveDate,
                DateInactive = null,
                IsActive = true,
                DateCreated = DateTime.Now
            };
            try
            {
                // calling our database 
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var Prevprice = dbContext.DesignElementPrices.FirstOrDefault(x => x.DesignElementId == onlineArtWork.ArtWorkPriceId && onlineArtWork.ServiceTypeCode == x.ServiceTypeCode);
                    if (Prevprice != null)
                    {
                        Prevprice.DateInactive = DateTime.Now;
                        Prevprice.IsActive = false;
                        dbContext.SaveChanges();
                    }
                    // calling changes
                    dbContext.ArtWorkPrices.Add(view);
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
    }
}