using System;
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
    /// <seealso cref="ADit.Interfaces.IRadioRepository" />
    public class RadioRepository : IRadioRepository
    {
        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;


        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository" /> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public RadioRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? new DbContextFactory(null);
        }

        /// <summary>
        /// Saves the radio transaction information.
        /// </summary>
        /// <param name="radioMainTransaction">The radio main transaction.</param>
        /// <param name="radioTransactionId">The radio transaction identifier.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        /// <exception cref="ArgumentNullException">radioMainTransaction</exception>
        public string SaveRadioTransactionInfo(IRadioTransactionUI radioMainTransaction, out int radioTransactionId)
        {
            if (radioMainTransaction == null)
            {
                throw new ArgumentNullException(nameof(radioMainTransaction));
            } 

            var result = string.Empty;
            var aRecord = new RadioTransaction
            {
                MaterialProductionPriceId = radioMainTransaction.MaterialProductionPriceId,
                MaterialScriptingPriceId = radioMainTransaction.MaterialScriptingPriceId,
                MaterialTypeId = radioMainTransaction.MaterialTypeId,
                IsHaveMaterial = radioMainTransaction.IsHaveMaterial,
                ProductionAmount = radioMainTransaction.ProductionAmount,
                ScriptingAmount = radioMainTransaction.ScriptingAmount,
                ScriptMaterialQuestionCode = radioMainTransaction.ScriptMaterialQuestionCode,
                OrderTitle = radioMainTransaction.OrderTitle,
                MaterialDigitalFileId = radioMainTransaction.MaterialDigitalFileId,
                ScriptDigitalFileId = radioMainTransaction.ScriptDigitalFileId,
                UserId = radioMainTransaction.UserId,
                IsActive = true,
                ScriptDescription = radioMainTransaction.ScriptDescription,
                IsHaveApconApproval = radioMainTransaction.IsHaveApconApproval,
                ApconApprovalNumber = radioMainTransaction.ApconApprovalNumber,
                ApconApprovalTypeId = radioMainTransaction.ApconApprovalTypeId,
                ApconApprovalTypePriceId = radioMainTransaction.ApconApprovalTypePriceId,
                ApconApprovalAmount = radioMainTransaction.ApconApprovalAmount,
                FinalAmount = radioMainTransaction.FinalAmount,
                OrderId = radioMainTransaction.OrderId,
                AiringInstruction = radioMainTransaction.AiringInstruction,

                DateCreated = DateTime.Now,
                TransactionStatusCode = "A",
            };
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.RadioTransactions.Add(aRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = $"savingRadio - {e.Message} , {(e.InnerException != null ? e.InnerException.Message : "")}";
            }

            radioTransactionId = aRecord.RadioTransactionId;

            return result;
        }

        /// <summary>
        /// Saves the radio transaction airing.
        /// </summary>
        /// <param name="radioTransactionId">The radio transaction identifier.</param>
        /// <param name="transactionAiringList">The transaction airing list.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        /// <exception cref="ArgumentNullException">transactionAiringList</exception>
        /// <exception cref="ArgumentOutOfRangeException">radioTransactionId</exception>
        public string SaveRadioTransactionAiring(int radioTransactionId, IList<IRadioTransactionAiringUI> transactionAiringList)
        {
            if (transactionAiringList == null)
            {
                throw new ArgumentNullException(nameof(transactionAiringList));
            }
            if (radioTransactionId < 1)
            {
                throw new ArgumentOutOfRangeException("radioTransactionId");
            }

            var result = string.Empty;
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    // save transaction airings
                    foreach (var item in transactionAiringList)
                    {
                        var aSubRecord = new RadioTransactionAiring
                        {
                            RadioTransactionId = radioTransactionId,
                            RadioStationId = item.RadioStationId,
                            MaterialTypeTimingId = item.TimingId,
                            StartDate = item.StartDate ?? DateTime.MinValue,
                            EndDate = item.EndDate ?? DateTime.MinValue,
                            Slots = item.Slots,
                            Price = item.RadioStationPrice,
                            TimeBeltId = item.TimeBeltId,
                            TotalSlots = item.TotalSlots,
                            DurationTypeCode = "D",
                            IsActive = true
                        };

                        dbContext.RadioTransactionAirings.Add(aSubRecord);
                    }

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = $"SaveRadioTransactionAiring - {e.Message} , {(e.InnerException != null ? e.InnerException.Message : "")}";
            }
            return result;
        }

        /// <summary>
        /// Gets the radio main transaction by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns>IRadioTransactionUI.</returns>
        public IRadioTransactionUI GetRadioMainTransactionById(int transactionId)
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var transaction = RadioQueries.getRadioTransactonUIById(dbContext, transactionId);

                    return transaction;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetRadioMainTransactionById", e);
            }
        }

        /// <summary>
        /// Gets the radio transaction airing by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns>IEnumerable&lt;IRadioTransactionAiringUI&gt;.</returns>
        public IEnumerable<IRadioTransactionAiringUI> GetRadioTransactionAiringById(int transactionId)
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var transaction = RadioQueries.getRadioTransactonAiringUIById(dbContext, transactionId).ToList();

                    return transaction;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetRadioTransactionAiringById", e);
            }
        }

        /// <summary>
        /// Updates the radio transaction information.
        /// </summary>
        /// <param name="radioMainTransaction">The radio main transaction.</param>
        /// <returns>System.String.</returns>
        public string UpdateRadioTransactionInfo(IRadioTransactionUI radioMainTransaction)
        {
            if (radioMainTransaction == null)
            {
                throw new ArgumentNullException(nameof(radioMainTransaction));
            }
            var result = string.Empty;

            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var radioTransaction = dbContext.RadioTransactions.SingleOrDefault(x =>x.RadioTransactionId == radioMainTransaction.RadioTransactionId);

                    if (radioTransaction == null)
                    {
                        throw new ApplicationException(nameof(radioTransaction));
                    }

                    radioTransaction.MaterialProductionPriceId = radioMainTransaction.MaterialProductionPriceId;
                    radioTransaction.MaterialScriptingPriceId = radioMainTransaction.MaterialScriptingPriceId;
                    radioTransaction.MaterialTypeId = radioMainTransaction.MaterialTypeId;
                    radioTransaction.IsHaveMaterial = radioMainTransaction.IsHaveMaterial;
                    radioTransaction.ProductionAmount = radioMainTransaction.ProductionAmount;
                    radioTransaction.ScriptingAmount = radioMainTransaction.ScriptingAmount;
                    radioTransaction.OrderTitle = radioMainTransaction.OrderTitle;
                    radioTransaction.ScriptDescription = radioMainTransaction.ScriptDescription;
                    radioTransaction.IsHaveApconApproval = radioMainTransaction.IsHaveApconApproval;
                    radioTransaction.ApconApprovalNumber = radioMainTransaction.ApconApprovalNumber;
                    radioTransaction.ApconApprovalTypeId = radioMainTransaction.ApconApprovalTypeId;
                    radioTransaction.ApconApprovalTypePriceId = radioMainTransaction.ApconApprovalTypePriceId;
                    radioTransaction.ApconApprovalAmount = radioMainTransaction.ApconApprovalAmount;
                    radioTransaction.FinalAmount = radioMainTransaction.FinalAmount;
                    radioTransaction.AiringInstruction = radioMainTransaction.AiringInstruction;
                    radioTransaction.MaterialDigitalFileId = radioMainTransaction.MaterialDigitalFileId;
                    radioTransaction.ScriptDigitalFileId = radioMainTransaction.ScriptDigitalFileId;
                    radioTransaction.ScriptMaterialQuestionCode = radioMainTransaction.ScriptMaterialQuestionCode;

                    dbContext.SaveChanges();

                }
            }
            catch (Exception e)
            {
                result = $"savingRadio - {e.Message} , {(e.InnerException != null ? e.InnerException.Message : "")}";
            }


            return result;
        }

        /// <summary>
        /// Deletes the radio transaction airing.
        /// </summary>
        /// <param name="radioTransactionId">The radio transaction identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteRadioTransactionAiring(int radioTransactionId)
        {
            if (radioTransactionId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(radioTransactionId));
            }

            var result = string.Empty;
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var details = dbContext.RadioTransactionAirings.Where(x => x.RadioTransactionId.Equals(radioTransactionId));
                    if (details.Any())
                    {
                        dbContext.RadioTransactionAirings.RemoveRange(details);
                    }

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = $"DeleteRadioTransactionAiring- {e.Message} , {(e.InnerException != null ? e.InnerException.Message : "")}";
            }

            return result;
        }

        /// <summary>
        /// Deletes the radio order.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">tvTransaction</exception>
        public string DeleteRadioOrder(int transactionId)
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
                    var radioTransaction =
                        dbContext.RadioTransactions.FirstOrDefault(x =>
                            x.RadioTransactionId == transactionId);
                    if (radioTransaction == null)
                    {
                        throw new ArgumentNullException(nameof(radioTransaction));
                    }

                    radioTransaction.TransactionStatusCode = "D";
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
        /// Deletes the radio station.
        /// </summary>
        /// <param name="radio">The radio.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">radio</exception>
        /// <exception cref="ArgumentNullException">radioDetails</exception>
        /// <exception cref="System.ArgumentNullException">radiodetails</exception>
        public string DeleteRadioStation(int radio)
        {
            if (radio < 1)
            {
                throw new ArgumentOutOfRangeException("radio");
            }

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var radioDetails = dbContext.RadioStations.SingleOrDefault(x => x.RadioStationId.Equals(radio));
                    if (radioDetails == null) throw new ArgumentNullException(nameof(radioDetails));
                    radioDetails.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteRadioStation- {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Edits the radio station.
        /// </summary>
        /// <param name="radio">The radio.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">radio
        /// or
        /// radiostation</exception>
        public string EditRadioStation(IRadioStationView radio)
        {
            var result = string.Empty;
            if (radio == null)
            {
                throw new ArgumentNullException(nameof(radio));
            }

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var radiostation =
                        dbContext.RadioStations.SingleOrDefault(x => x.RadioStationId == radio.RadioStationId);
                    if (radiostation == null) throw new ArgumentNullException(nameof(radiostation));

                    radiostation.RadioStationId = radio.RadioStationId;
                    radiostation.Description = radio.Description;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("EditRadioStation - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets the radio effective price.
        /// </summary>
        /// <param name="RadioStationId">The radio station identifier.</param>
        /// <param name="timingId">The timing identifier.</param>
        /// <param name="timeBeltId">The time belt identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTvEffectivePrice</exception>
        public IRadioServicePriceListModel GetRadioEffectivePrice(int RadioStationId, int timingId, int timeBeltId,int materialTypeId)
        {
            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        RadioQueries.GetRadioEffectivePrices(dbContext, RadioStationId, timingId, timeBeltId,materialTypeId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTvEffectivePrice", e);
            }
        }
        /// <summary>
        /// Updates the radio transaction.
        /// </summary>
        /// <param name="radioOrderModel">The radio order model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">radioTransaction</exception>
        public string UpdateRadioTransaction(IRadioMainView radioOrderModel)
        {
            var result = string.Empty;



            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var radioTransaction =
                        dbContext.RadioTransactions.SingleOrDefault(x =>
                            x.RadioTransactionId == radioOrderModel.RadioTransactionId);
                    if (radioTransaction == null) throw new ArgumentNullException(nameof(radioTransaction));

                    radioTransaction.MaterialProductionPriceId = radioOrderModel.MaterialProductionPriceId;
                    radioTransaction.MaterialScriptingPriceId = radioOrderModel.MaterialScriptingPriceId;
                    radioTransaction.MaterialTypeId = radioOrderModel.MaterialTypeId;
                    radioTransaction.IsHaveMaterial = radioOrderModel.IsHaveMaterial;
                    radioTransaction.ProductionAmount = radioOrderModel.ProductionAmount;
                    radioTransaction.ScriptingAmount = radioOrderModel.ScriptingAmount;

                    radioTransaction.OrderTitle = radioOrderModel.OrderTitle;




                    radioTransaction.ScriptDescription = radioOrderModel.ScriptDescription;
                    radioTransaction.IsHaveApconApproval = radioOrderModel.IsHaveApconApproval;
                    radioTransaction.ApconApprovalNumber = radioOrderModel.ApconApprovalNumber;
                    radioTransaction.ApconApprovalTypeId = radioOrderModel.ApconApprovalTypeId;
                    radioTransaction.ApconApprovalTypePriceId = radioOrderModel.ApconApprovalTypePriceId;
                    radioTransaction.ApconApprovalAmount = radioOrderModel.ApconApprovalAmount;
                    radioTransaction.FinalAmount = radioOrderModel.FinalAmount;

                    radioTransaction.AiringInstruction = radioOrderModel.AiringDescription;

                    if (radioOrderModel.MaterialDigitalFileId > 0)
                    {
                        radioTransaction.MaterialDigitalFileId = radioOrderModel.MaterialDigitalFileId;
                    }

                    if (radioOrderModel.ScriptDigitalFileId > 0)
                    {
                        radioTransaction.ScriptDigitalFileId = radioOrderModel.ScriptDigitalFileId;
                    }

                    dbContext.SaveChanges();

                }
            }
            catch (Exception e)
            {
                result = string.Format("savingRadio - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }


        /// <summary>
        /// Saves the radio station.
        /// </summary>
        /// <param name="radioInfo">The radio information.</param>
        /// <returns></returns>
        public string SaveRadioStation(IRadioStationView radioInfo)
        {
            var result = string.Empty;

            var view = new RadioStation
            {
                RadioStationId = radioInfo.RadioStationId,
                Description = radioInfo.Description,
                IsActive = true
            };
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.RadioStations.Add(view);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveRadioStation - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }

        /// <summary>
        /// Saves the production price.
        /// </summary>
        /// <param name="productionInfo">The production information.</param>
        /// <returns></returns>
        public string SaveProductionPrice(IMaterialProductionPriceView productionInfo)
        {
            var result = string.Empty;

            var view = new MaterialProductionPrice
            {
                ServiceTypeCode = productionInfo.ServiceTypeCode,
                MaterialTypeId = productionInfo.MaterialTypeId,
                Amount = productionInfo.Amount,
                Comment = productionInfo.Comment,
                EffectiveDate = productionInfo.EffectiveDate,
                DateInactive = null,
                IsActive = true,
                DateCreated = DateTime.Now
            };
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var Prevprice = dbContext.MaterialProductionPrices.Where(x => x.MaterialTypeId == productionInfo.MaterialTypeId && productionInfo.ServiceTypeCode == x.ServiceTypeCode);
                    if (Prevprice != null)
                    {
                        foreach (var j in Prevprice)
                        {
                            j.DateInactive = DateTime.Now;
                            j.IsActive = false;

                        }
                        dbContext.SaveChanges();
                    }
                    dbContext.MaterialProductionPrices.Add(view);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("savingRadio - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }


        /// <summary>
        /// Saves the scripting price.
        /// </summary>
        /// <param name="scriptingInfo">The scripting information.</param>
        /// <returns></returns>
        public string SaveScriptingPrice(IMaterialScriptingPriceView scriptingInfo)
        {
            var result = string.Empty;

            var view = new MaterialScriptingPrice
            {
                ServiceTypeCode = scriptingInfo.ServiceTypeCode,
                MaterialTypeId = scriptingInfo.MaterialTypeId,
                Amount = scriptingInfo.Amount,
                Comment = scriptingInfo.Comment,
                EffectiveDate = scriptingInfo.EffectiveDate,
                DateInactive = null,
                IsActive = true,
                DateCreated = DateTime.Now
            };
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var Prevprice = dbContext.MaterialScriptingPrices.FirstOrDefault(x => x.MaterialTypeId == scriptingInfo.MaterialTypeId && scriptingInfo.ServiceTypeCode == x.ServiceTypeCode);
                    if (Prevprice != null)
                    {
                        Prevprice.DateInactive = DateTime.Now;
                        Prevprice.IsActive = false;
                        dbContext.SaveChanges();
                    }
                    dbContext.MaterialScriptingPrices.Add(view);
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
        /// Saves the material type timing.
        /// </summary>
        /// <param name="radioOrderModel">The radio order model.</param>
        /// <param name="MaterialTypeTimingId">The material type timing identifier.</param>
        /// <returns></returns>
        public string SaveMaterialTypeTiming(IRadioOrderModel radioOrderModel, out int MaterialTypeTimingId)
        {
            var result = string.Empty;

            var savingmaterialtypetiming = new MaterialTypeTiming
            {
                ServiceTypeCode = "Online",
                MaterialTypeId = radioOrderModel.MaterialTypeId,
                TimingId = 2,
                IsActive = true
            };

            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.MaterialTypeTimings.Add(savingmaterialtypetiming);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("savingmaterialtypetiming - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            MaterialTypeTimingId = savingmaterialtypetiming.MaterialTypeTimingId;
            return result;
        }


        /// <summary>
        /// Gets the user radio order by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetUserRadioOrderById</exception>
        /// <exception cref="System.ApplicationException">Repository GetUserRadioOrderById</exception>
        public IRadioOrder GetUserRadioOrderById(int transactionId)
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = RadioQueries.getRadioTransactonById(dbContext, transactionId);
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetUserRadioOrderById", e);
            }
        }


        /// <summary>
        /// Deletes the radio by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Id</exception>
        /// <exception cref="ArgumentNullException">
        /// radioTransactiondetails
        /// or
        /// radio
        /// </exception>
        /// <exception cref="System.ArgumentException">Id</exception>
        /// <exception cref="System.ArgumentNullException">radioTransactiondetails
        /// or
        /// radio</exception>
        public string deleteRadioById(int Id)
        {
            var result = string.Empty;

            if (Id < 1)
            {
                throw new ArgumentException("Id");
            }


            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var radioTransactiondetails =
                        dbContext.RadioTransactions.SingleOrDefault(x => x.RadioTransactionId.Equals(Id));
                    if (radioTransactiondetails == null)
                        throw new ArgumentNullException(nameof(radioTransactiondetails));
                    radioTransactiondetails.IsActive = false;
                    dbContext.SaveChanges();


                    var radio = dbContext.RadioTransactions.SingleOrDefault(x => x.RadioTransactionId.Equals(Id));
                    if (radio == null) throw new ArgumentNullException(nameof(radio));
                    radio.TransactionStatusCode = "D";
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("savingtransactionairing - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Edits the radio transaction information.
        /// </summary>
        /// <param name="radioOrderModel">The radio order model.</param>
        /// <param name="RadioTransactionId">The radio transaction identifier.</param>
        /// <returns></returns>
        public string EditRadioTransactionInfo(IRadioMainView radioOrderModel, out int RadioTransactionId)
        {
            var radioId = 0;
            var result = string.Empty;
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var radios = dbContext.RadioTransactions.SingleOrDefault(x =>
                        x.RadioTransactionId.Equals(radioOrderModel.RadioTransactionId));


                    radios.MaterialProductionPriceId = radioOrderModel.MaterialProductionPriceId;
                    radios.MaterialScriptingPriceId = radioOrderModel.MaterialProductionPriceId;
                    radios.MaterialTypeId = radioOrderModel.MaterialTypeId;
                    radios.IsHaveMaterial = radioOrderModel.IsHaveMaterial;
                    radios.ProductionAmount = radioOrderModel.ProductionAmount;
                    radios.ScriptingAmount = radioOrderModel.ScriptingAmount;

                    radios.OrderTitle = radioOrderModel.OrderTitle;
                    radios.MaterialDigitalFileId = radioOrderModel.ScriptDigitalFileId;
                    radios.ScriptDigitalFileId = radioOrderModel.MaterialDigitalFileId;
                    

                    radios.ScriptDescription = radioOrderModel.ScriptDescription;
                    radios.IsHaveApconApproval = false;
                    radios.ApconApprovalNumber = radioOrderModel.ApconApprovalNumber;
                    radios.ApconApprovalTypeId = radioOrderModel.ApconApprovalTypeId;
                    radios.ApconApprovalTypePriceId = radioOrderModel.ApconApprovalTypePriceId;
                    radios.ApconApprovalAmount = radioOrderModel.ApconApprovalAmount;
                    radios.FinalAmount = radioOrderModel.FinalAmount;
                    radios.AiringInstruction = "radioOrderModel.AiringDescription";

                    radios.DateCreated = DateTime.Now;
                    radios.TransactionStatusCode = "A";
                    radioId = radios.RadioTransactionId;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("savingtransactionairing - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            RadioTransactionId = radioId;
            return result;
        }



        /// <summary>
        /// Gets the active radio tranasction.
        /// </summary>
        /// <param name="orderNumber">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetActiveRadioTranasction</exception>
        public IList<IRadioTransaction> GetActiveRadioTranasction(int orderNumber)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        RadioQueries.getActiveRadioTranasction(dbContext, orderNumber).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetActiveRadioTranasction", e);
            }
        }

        /// <summary>
        /// Gets the radio transaction airing.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository getAvtiveRadioTranasction</exception>
        /// <exception cref="System.ApplicationException">Repository getAvtiveRadioTranasction</exception>
        public IList<IRadioTransactionAiring> GetRadioTransactionAiring(int transactionId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        RadioQueries.getRadioTransactionAiring(dbContext, transactionId).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository getAvtiveRadioTranasction", e);
            }
        }


        /// <summary>
        /// Gets the radio tranasction.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository getAvtiveRadioTranasction</exception>
        /// <exception cref="System.ApplicationException">Repository getAvtiveRadioTranasction</exception>
        public IList<IRadioTransaction> GetRadioTranasction()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        RadioQueries.GetRadioTransaction(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository getAvtiveRadioTranasction", e);
            }
        }


        /// <summary>
        /// Saves the radio transaction airing.
        /// </summary>
        /// <param name="radioAiringInfo">The radio airing information.</param>
        /// <returns></returns>
        public string SaveRadioTransactionAiring(IRadioTransactionAiringView radioAiringInfo)
        {
            var result = string.Empty;

            var radioAiring = new RadioTransactionAiring
            {
                RadioStationId = radioAiringInfo.RadioStationId,
                IsActive = true,
                
                RadioTransactionId = radioAiringInfo.RadioTransactionId,
                
                DurationTypeCode = radioAiringInfo.DurationTypeCode,
                MaterialTypeTimingId = radioAiringInfo.MaterialTypeTimingId,
            };

            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.RadioTransactionAirings.Add(radioAiring);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveRadioTransactionAiring - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }


        /// <summary>
        /// Gets the radio production view by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository getAvtiveRadioTranasction</exception>
        public IRadioTransaction GetRadioProductionViewById(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        RadioQueries.GetRadioProductionViewById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository getAvtiveRadioTranasction", e);
            }
        }


        /// <summary>
        /// Gets the radio production list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetMaterialProductionPriceById</exception>
        public IList<IRadioProduction> GetRadioProductionList()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        RadioQueries.getRadioProdution(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetMaterialProductionPriceById", e);
            }
        }


        /// <summary>
        /// Saveradioes the production.
        /// </summary>
        /// <param name="radioProduction">The radio production.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">radioProduction</exception>
        public string SaveradioProduction(IRadioProductionView radioProduction)
        {
            var result = string.Empty;
            if (radioProduction == null)
            {
                throw new ArgumentNullException("radioProduction");
            }

            var RadioProduction = new RadioProduction


            {
                DateCreated = DateTime.Now,
                IsActive = true,
                ProductionManagerId = radioProduction.ProductionManagerId,
                ProductionManagerNote = radioProduction.ProductionManagerNote,
                RadioManagerProductionDigitalId = radioProduction.RadioManagerProductionDigitalId,

                RadioTransactionId = radioProduction.RadioTransactionId,





            };

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.RadioProductions.Add(RadioProduction);

                    dbContext.SaveChanges();
                }




            }
            catch (Exception e)
            {
                result = string.Format("savingtransactionairing - {0} , {1}", e.Message,
        e.InnerException != null ? e.InnerException.Message : "");





            }
            return result;
        }



        /// <summary>
        /// Gets the radio description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetRadioDescriptionByValue</exception>
        public IRadioStationModel GetRadioDescriptionByValue(string description)
        {
            try
            {
                var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext();
                {

                    var aRecord = RadioQueries.getRadioStationDescription(dbContext, description);

                    return aRecord;
                }

            }

            catch (Exception e)
            {
                throw new ApplicationException("Repository GetRadioDescriptionByValue", e);

            }




        }

        /// <summary>
        /// Gets the active material type for radio.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetMaterialType</exception>
        public IList<IMaterialType> GetActiveMaterialTypeForRadio()
        {
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = RadioQueries.getActvieMaterialTypeForRadio(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetMaterialType", e);
            }
        }

        /// <summary>
        /// Gets the radio station price.
        /// </summary>
        /// <param name="radionStationId">The radion station identifier.</param>
        /// <param name="timingId">The timing identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetRadioStationPrice</exception>
        public IRadioServicePriceListModel GetRadioStationPrice(int radionStationId, int timingId,int materialTypeId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        RadioQueries.GetRadioStationPrice(dbContext, radionStationId, timingId,materialTypeId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetRadioStationPrice", e);
            }
        }

        /// <summary>
        /// Updates the radio transaction airing.
        /// </summary>
        /// <param name="radioMainView">The radio main view.</param>
        /// <returns></returns>
        public string UpdateRadioTransactionAiring(IRadioMainView radioMainView)
        {
            var result = string.Empty;
            foreach (var item in radioMainView.RadioChannelList)
            {
                var radioStation = int.Parse(item["Station"]);
                var materialTiming = int.Parse(item["Timing"]);
              
                var price = decimal.Parse(item["Price"]);
                var Slots = int.Parse(item["Slots"]);
                var totalSlots = int.Parse(item["totalSlots"]);
                var timeBeltId = int.Parse(item["TimeBeltId"]);
                var StartDate = DateTime.Parse(item["StartDate"]);
                var EndDate = DateTime.Parse(item["EndDate"]);

                //If this is a new Tv Station Selected and the Price is Gre

                var radioTransactionAiringRecord = new RadioTransactionAiring
                {
                    RadioTransactionId = radioMainView.RadioTransactionId,

                    RadioStationId = radioStation,

                    MaterialTypeTimingId = materialTiming,

                    DurationTypeCode = "D",
                    Slots = Slots,
                    TotalSlots = totalSlots,
                    TimeBeltId = timeBeltId,
                    StartDate = StartDate,
                    EndDate = EndDate,
                    

                    Price = price,


                };

                try
                {



                    //Cheking If the Airing Information is Already Stored
                    using (
                        var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                    {

                        var radioAiringInformation =
                            dbContext.RadioTransactionAirings.FirstOrDefault(x =>
                                x.RadioTransactionId == radioTransactionAiringRecord.RadioTransactionId && x.RadioStationId == radioStation);

                        if (radioAiringInformation != null)
                        {
                            radioAiringInformation.RadioTransactionId = radioTransactionAiringRecord.RadioTransactionId;

                            radioAiringInformation.RadioStationId = radioStation;
                           

                            radioAiringInformation.MaterialTypeTimingId = materialTiming;

                            radioAiringInformation.DurationTypeCode = "D";
                            radioAiringInformation.IsActive = true;
                            radioAiringInformation.Slots = Slots;
                            radioAiringInformation.TotalSlots = totalSlots;
                            radioAiringInformation.TimeBeltId = timeBeltId;
                            radioAiringInformation.StartDate = StartDate;
                            radioAiringInformation.EndDate = EndDate;
                            radioAiringInformation.Price = price;

                           


                        }
                        else
                        {

                            //If there is a new Tv Selected and the Price is greater than 0;
                            if (price > 0)
                            {
                                dbContext.RadioTransactionAirings.Add(radioTransactionAiringRecord);
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

      


        

        // 

        /// <summary>
        /// Gets the radio transaction.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetRadioStationPrice</exception>
        public IRadioTransaction GetRadioTransaction(int SentToId, int transactionId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        RadioQueries.GetRadioTransactionById(dbContext, SentToId, transactionId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetRadioStationPrice", e);
            }
        }



        /// <summary>
        /// Gets all radio transaction.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetRadioStationPrice</exception>
        public IList<IRadioTransaction> GetAllRadioTransaction()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        RadioQueries.getAllRadioTransaction(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetRadioStationPrice", e);
            }
        }

      







      


    }
}
