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
    /// <seealso cref="ADit.Interfaces.ITvRepository" />
    public class TvRepostiory : ITvRepository
    {
        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="TvRepostiory"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public TvRepostiory(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? new DbContextFactory(null);
        }


        #region Uploaded Script Setup








        #endregion


        #region Tv Station Setup


        /// <summary>
        /// Saves the uploaded script.
        /// </summary>
        /// <param name="tvStationView">The tv station view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">AdminSaveTvStations</exception>
        public string SaveTvStationInfo(ITvStationView tvStationView)
        {
            var result = string.Empty;
            if (tvStationView == null)
            {
                throw new ArgumentException("AdminSaveTvStations");
            }

            var newRecord = new TVStation
            {
                Description = tvStationView.Description,
                IsActive = true
            };
            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    dbContext.TVStations.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveTvInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }

        /// <summary>
        /// Deletes the tv station information.
        /// </summary>
        /// <param name="tvStationId">The tv station identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">tvStationViewDetails</exception>
        public string DeleteTvStationInfo(int tvStationId)
        {
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var tvStationViewDetails = dbContext.TVStations.SingleOrDefault(x => x.TVStationId == tvStationId);
                    if (tvStationViewDetails == null) throw new ArgumentNullException(nameof(tvStationViewDetails));
                    tvStationViewDetails.IsActive = false;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("TvStation- {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Edits the tv station.
        /// </summary>
        /// <param name="tvStationView">The tv station view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">tvStationView</exception>
        /// <exception cref="ArgumentNullException">tvStationViewDetails</exception>
        public string EditTvStation(ITvStationView tvStationView)
        {
            var result = string.Empty;
            if (tvStationView == null) throw new ArgumentException(nameof(tvStationView));
            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var tvStationViewDetails =
                        dbContext.TVStations.SingleOrDefault(x => x.TVStationId == tvStationView.TVStationId);
                    if (tvStationViewDetails == null) throw new ArgumentNullException(nameof(tvStationViewDetails));
                    tvStationViewDetails.Description = tvStationView.Description;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Tv Station - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }



        #endregion


        #region Material Type Timing

        /// <summary>
        /// Saves the material type timings information.
        /// </summary>
        /// <param name="tvView">The tv view.</param>
        /// <param name="MaterialTypeTiming">The material type timing.</param>
        /// <returns></returns>
        public string SaveMaterialTypeTimingsInfo(ITvView tvView, out int MaterialTypeTiming)
        {
            var result = string.Empty;
            var materialTypeTimingRecord = new MaterialTypeTiming
            {
                ServiceTypeCode = "5",
                MaterialTypeId = tvView.MaterialTypeId,
                TimingId = 2,
            };
            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    dbContext.MaterialTypeTimings.Add(materialTypeTimingRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveTvInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            MaterialTypeTiming = materialTypeTimingRecord.MaterialTypeTimingId;

            return result;
        }

        #endregion



        #region Tv Transaction Setup
        /// <summary>
        /// Saves the tv transaction information.
        /// </summary>
        /// <param name="tvOrder">The tv order.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        public string SaveTvTransactionInfo(ITvTransactionUI tvOrder, out int transactionId)
        {
            var result = string.Empty;
          

            var newRecord = new TVTransaction
            {


                OrderTitle = tvOrder.OrderTitle,

           

                IsHaveMaterial = tvOrder.IsHaveMaterial,

                IsHaveApconApproval = tvOrder.IsHaveApconApproval,

                ApconApprovalTypeId = tvOrder.ApconApprovalTypeId,

                ApconApprovalAmount = tvOrder.ApconApprovalAmount,

                ProductionAmount = tvOrder.ProductionAmount,

                ScriptingAmount = tvOrder.ScriptingAmount,

                MaterialScriptingPriceId = tvOrder.MaterialScriptingPriceId,

                MaterialProductionPriceId = tvOrder.MaterialProductionPriceId,

                FinalAmount = tvOrder.FinalAmount,

                AiringInstruction = tvOrder.AiringInstruction,

                MaterialTypeId = tvOrder.MaterialTypeId,

                ScriptMaterialQuestionCode = tvOrder.ScriptingMaterialCode.ToString(),

                DateCreated = DateTime.Now,

                TransactionStatusCode = "A", 

                OrderId = tvOrder.OrderId,

                UserId = tvOrder.UserId,

                IsActive = true,

                ProductionDigitalFileId = tvOrder.MaterialDigitalFileId,

                ScriptingDigitalFileId = tvOrder.ScriptDigitalFileId,
               
            };


            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    dbContext.TVTransactions.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }


            catch (Exception e)
            {
                result = string.Format("SaveTvInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            transactionId = newRecord.TVTransactionId;

            return result;
        }


        /// <summary>
        /// Deletes the tv order.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">tvTransaction</exception>
        public string DeleteTvOrder(int transactionId)
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
                    var tvTransaction =
                        dbContext.TVTransactions.FirstOrDefault(x =>
                            x.TVTransactionId == transactionId);
                    if (tvTransaction == null)
                    {
                        throw new ArgumentNullException(nameof(tvTransaction));
                    }

                    tvTransaction.TransactionStatusCode = "D";
                    dbContext.SaveChanges();



                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteTvOrder- {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }


        /// <summary>
        /// Gets the active tv transaction.
        /// </summary>
        /// <param name="orderNumber">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetActiveTvTransaction</exception>
        public IList<ITvTransaction> GetActiveTvTransaction(int orderNumber)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = TvQueries.GetActiveTvTransactions(dbContext, orderNumber).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetActiveTvTransaction", e);
            }
        }


        /// <summary>
        /// Updates the tv transaction.
        /// </summary>
        /// <param name="tvInfo">The tv information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">tvTransaction</exception>
        public string UpdateTvTransaction(ITvTransactionUI tvInfo)
        {
            var result = string.Empty;


            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var tvTransaction =
                        dbContext.TVTransactions.FirstOrDefault(x =>
                            x.TVTransactionId == tvInfo.TvTransactionId);
                    if (tvTransaction == null)
                    {
                        throw new ArgumentNullException(nameof(tvTransaction));
                    }

                    tvTransaction.MaterialProductionPriceId = tvInfo.MaterialDigitalFileId;
                    tvTransaction.MaterialScriptingPriceId = tvInfo.ScriptDigitalFileId;
                    tvTransaction.MaterialTypeId = tvInfo.MaterialTypeId;
                    tvTransaction.IsHaveMaterial = tvInfo.IsHaveMaterial;
                    tvTransaction.ProductionAmount = tvInfo.ProductionAmount;
                    tvTransaction.ScriptingAmount = tvInfo.ScriptingAmount;

                    tvTransaction.OrderTitle = tvInfo.OrderTitle;


                    tvTransaction.ScriptDescription = tvInfo.ScriptDescription;
                    tvTransaction.IsHaveApconApproval = tvInfo.IsHaveApconApproval;
                    tvTransaction.ApconApprovalNumber = tvInfo.ApconApprovalNumber;
                    tvTransaction.ApconApprovalTypeId = tvInfo.ApconApprovalTypeId;
                    tvTransaction.ApconApprovalTypePriceId = tvInfo.ApconApprovalTypePriceId;
                    tvTransaction.ApconApprovalAmount = tvInfo.ApconApprovalAmount;
                    tvTransaction.FinalAmount = tvInfo.FinalAmount;
                    tvTransaction.ScriptMaterialQuestionCode = tvInfo.ScriptMaterialQuestionCode;
                    tvTransaction.AiringInstruction = tvInfo.AiringInstruction;



                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("updateRadio - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }

        /// <summary>
        /// Gets the tv transaction.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTvStationPrice</exception>
        public ITvTransaction GetTvTransaction(int SentToId, int transactionId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        TvQueries.GetTvTransactionById(dbContext, SentToId, transactionId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTvStationPrice", e);
            }
        }




        #endregion


        #region Airing Transaction Setup
        /// <summary>
        /// Saves the radio transaction airing.
        /// </summary>
        /// <param name="transactionAiringList">The transaction airing list.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        public string SaveTvTransactionAiring(IList<ITvTransactionAiringUI> transactionAiringList, int transactionId)
        {
            var result = string.Empty;
            

                try
                {
                    using (
                        var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                    {
                    foreach (var item in transactionAiringList)
                    {
                        var aSubRecord = new TVTransactionAiring
                        {
                            TVTransactionId = transactionId,
                            TVStationId = item.TvStationId,
                            MaterialTypeTimingId = item.TimingId,
                            StartDate = item.StartDate.Value,
                            EndDate = item.EndDate.Value,
                            Slots = item.Slots,
                            Price = item.Price,
                            TimeBeltId = item.TimeBeltId,
                            TotalSlots = item.TotalSlots,
                            DurationTypeCode = "D",
                            IsActive = true
                        };

                        dbContext.TVTransactionAirings.Add(aSubRecord);
                    }

                    dbContext.SaveChanges();
                }
                            }
                catch (Exception e)
                {
                    result = string.Format("SaveTvInfo - {0} , {1}", e.Message,
                        e.InnerException != null ? e.InnerException.Message : "");
                }
            

            return result;
        }


        /// <summary>
        /// Updates the tv transaction airing.
        /// </summary>
        /// <param name="tvStationsTransactions">The tv stations transactions.</param>
        /// <returns></returns>
        public string UpdateTvTransactionAiring(ITvView tvStationsTransactions)
        {
            var result = string.Empty;
            foreach (var item in tvStationsTransactions.TvChannelList)
            {
                var tvStation = int.Parse(item["Station"]);
                var materialTiming = int.Parse(item["Timing"]);
                var slots = int.Parse(item["Slots"]);
                var durationCode = "A";
                var totalSlots = int.Parse(item["TotalSlots"]);
                var startDate = DateTime.Parse(item["StartDate"]);
                var endDate = DateTime.Parse(item["EndDate"]);
                var timeBeltId = int.Parse(item["TimeBelt"]);
                var price = decimal.Parse(item["Price"]);

                //If this is a new Tv Station Selected and the Price is Gre

                var tvTransactionAiringRecord = new TVTransactionAiring
                {
                    TVTransactionId = tvStationsTransactions.TVTransactionId,


                    TVStationId = tvStation,

                    MaterialTypeTimingId = materialTiming,

                    DurationTypeCode = durationCode,

                    Slots = slots,

                    TotalSlots = totalSlots,
                    StartDate = startDate,
                    EndDate = endDate,
                    TimeBeltId = timeBeltId,

                    Price = price,
                };


                try
                {
                    //Cheking If the Airing Information is Already Stored
                    using (
                        var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                    {
                        var tvAiringInformation =
                            dbContext.TVTransactionAirings.FirstOrDefault(x =>
                                x.TVTransactionId == tvStationsTransactions.TVTransactionId &&
                                x.TVStationId == tvStation);

                        if (tvAiringInformation != null)
                        {
                            tvAiringInformation.TVTransactionId = tvStationsTransactions.TVTransactionId;

                            tvAiringInformation.TVStationId = tvStation;

                            tvAiringInformation.MaterialTypeTimingId = materialTiming;

                            tvAiringInformation.DurationTypeCode = durationCode;

                            tvAiringInformation.Slots = slots;

                            tvAiringInformation.TotalSlots = totalSlots;
                            tvAiringInformation.StartDate = startDate;
                            tvAiringInformation.EndDate = endDate;
                            tvAiringInformation.TimeBeltId = timeBeltId;


                            tvAiringInformation.Price = price;
                        }
                        else
                        {
                            //If there is a new Tv Selected and the Price is greater than 0;
                            if (price > 0)
                            {
                                dbContext.TVTransactionAirings.Add(tvTransactionAiringRecord);
                            }
                        }

                        dbContext.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    result = string.Format("Update Television Airing - {0} , {1}", e.Message,
                        e.InnerException != null ? e.InnerException.Message : "");
                }
            }

            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tvTransactionId"></param>
        /// <returns></returns>
        public string DeleteTvTransactionAiring(int tvTransactionId)
        {
            if (tvTransactionId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(tvTransactionId));
            }

            var result = string.Empty;
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var details = dbContext.TVTransactionAirings.Where(x => x.TVTransactionId.Equals(tvTransactionId));
                    if (details.Any())
                    {
                        dbContext.TVTransactionAirings.RemoveRange(details);
                    }

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = $"DeleteTvTransactionAiring- {e.Message} , {(e.InnerException != null ? e.InnerException.Message : "")}";
            }

            return result;
        }


        /// <summary>
        /// Gets the tv transaction airing.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTvTransactionAiring</exception>
        public IList<ITvTransactionAiringUI> GetTvTransactionAiringList(int transactionId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        TvQueries.getTvTransactionAiringList(dbContext, transactionId).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTvTransactionAiring", e);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public IList<ITvTransactionAiring> GetTvTransactionAiring(int transactionId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        TvQueries.getTvTransactionAiring(dbContext, transactionId).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTvTransactionAiring", e);
            }
        }

        #endregion

        #region Uploaded Material Setup
      

        #endregion


        #region Getting Tv setup
        /// <summary>
        /// Gets the tv description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTvDescriptionByValue</exception>
        public ITvStation GetTvDescriptionByValue(string description)
        {
            try
            {
                var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext();
                {
                    var aRecord = TvQueries.getTvStationDescription(dbContext, description);

                    return aRecord;
                }
            }

            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTvDescriptionByValue", e);
            }
        }

        /// <summary>
        /// Gets the user tv order by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetUserTvOrderById</exception>
        public ITvOrder GetUserTvOrderById(int transactionId)
        {
            try
            {
                using (var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var list = TvQueries.getTvTransactonById(dbContext, transactionId);
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetUserTvOrderById", e);
            }
        }

        #endregion




        #region Service Price Setup

        /// <summary>
        /// Checks the tv serviceprice.
        /// </summary>
        /// <param name="radioServicePriceList">The radio service price list.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">radioServicePriceList</exception>
        public bool CheckTvServiceprice(ITVServicePricesListView tVServicePricesList)
        {
            var result = string.Empty;
            if (tVServicePricesList == null)
            {
                throw new ArgumentNullException(nameof(tVServicePricesList));
            }
            using (
               var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
            {
                var RadioPrice = dbContext.TvServicesPrices.SingleOrDefault(x => x.MaterialTypeId == tVServicePricesList.TimingBeltId && x.TimingId == tVServicePricesList.TimingId && x.TimeBeltId == tVServicePricesList.TimingBeltId);
                if (RadioPrice != null)
                {
                    return true;
                }



            }

            return false;



        }
        /// <summary>
        /// Gets the itv service prices list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTvTransactionAiring</exception>
        public IList<ITVServicePricesList> GetITVServicePricesList()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        TvQueries.GetITVServicePricesList(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTvTransactionAiring", e);
            }
        }


        /// <summary>
        /// Saves the tv service price list.
        /// </summary>
        /// <param name="tVServicePricesListView">The t v service prices ListView.</param>
        /// <returns></returns>
        public string saveTvServicePriceList(ITVServicePricesListView tVServicePricesListView)
        {
            var result = string.Empty;

            var tvList = new TvServicesPrice
            {
                TVStationId = tVServicePricesListView.TvStationId,
                Amount = tVServicePricesListView.Amount,
                DateEffective = tVServicePricesListView.DateEffective,
                MaterialTypeId=tVServicePricesListView.MaterialTypeId,
                DateInActive = null,
                IsActive = true,
                TimingId = tVServicePricesListView.TimingId,
                TimeBeltId = tVServicePricesListView.TimingBeltId,
            };

            try
            {
                using (var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var Prevprice = dbContext.TvServicesPrices.FirstOrDefault(x => x.TVStationId == tVServicePricesListView.TvStationId&&tVServicePricesListView.TimingId==x.TimingId&&tVServicePricesListView.TimingBeltId==x.TimeBeltId);
                    if (Prevprice != null)
                    {
                        Prevprice.DateInActive = DateTime.Now;
                        Prevprice.IsActive = false;
                        dbContext.SaveChanges();
                    }
                    dbContext.TvServicesPrices.Add(tvList);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveTvPriceList - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }


        /// <summary>
        /// Getedits the tv service price ListView.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTvTransactionAiring</exception>
        public ITVServicePricesList GeteditTvServicePriceListView(int Id)
        {
            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        TvQueries.GetITVServicePricesListById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTvTransactionAiring", e);
            }
        }


        /// <summary>
        /// Deletes the service price ListView.
        /// </summary>
        /// <param name="tvServicesPriceId">The identifier.</param>
        /// <returns></returns>
        public string deleteServicePriceListView(int tvServicesPriceId)
        {
            var result = string.Empty;


            try
            {
                using (var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var tvId = dbContext.TvServicesPrices.SingleOrDefault(x =>
                        x.TvServicesPriceId == tvServicesPriceId);
                    tvId.IsActive = false;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete tvserrice Price List {0},{1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }


        /// <summary>
        /// Updates the tv service price list.
        /// </summary>
        /// <param name="tVServicePricesListView">The t v service prices ListView.</param>
        /// <returns></returns>
        public string UpdateTvServicePriceList(ITVServicePricesListView tVServicePricesListView)
        {
            var result = string.Empty;


            try
            {
                using (var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var tvId = dbContext.TvServicesPrices.SingleOrDefault(x =>
                        x.TvServicesPriceId == tVServicePricesListView.TvServicesPriceListId);
                    tvId.DateInActive = tVServicePricesListView.DateInActive;
                    tvId.DateEffective = tVServicePricesListView.DateEffective;
                    tvId.Amount = tVServicePricesListView.Amount;
                    tvId.IsActive = true;
                    tvId.TimingId = tVServicePricesListView.TimingId;
                    tvId.TVStationId = tVServicePricesListView.TvStationId;
                    tvId.TimeBeltId = tVServicePricesListView.TimingBeltId;
                    tvId.MaterialTypeId = tVServicePricesListView.MaterialTypeId;

                   
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Update tvserrice Price List {0},{1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }

#endregion
        
        
        /// <summary>
        /// Gets the tv effective price.
        /// </summary>
        /// <param name="tvStationId">The tv station identifier.</param>
        /// <param name="timingId">The timing identifier.</param>
        /// <param name="timeBeltId">The time belt identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTvEffectivePrice</exception>
        public ITVServicePricesList GetTvEffectivePrice(int tvStationId, int timingId, int timeBeltId,int materialTypeId)
        {
            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        TvQueries.GetTvEffectivePrices(dbContext, tvStationId, timingId, timeBeltId,materialTypeId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTvEffectivePrice", e);
            }
        }


        
       
        









    }
}