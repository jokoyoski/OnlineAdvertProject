using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using ADit.Repositories.Factories;
using ADit.Repositories.DataAccess;
using ADit.Repositories.Queries;
using ADit.Interfaces.ValueTypes;
using ADit.Repositories.Resources;
using System.Data.Entity.Validation;
using System.Text;

namespace ADit.Repositories.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IPrintRepository" />
    public class PrintRepository : IPrintRepository
    {
        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public PrintRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? new DbContextFactory(null);
        }






        /// <summary>
        /// Saves the type of the add print service.
        /// </summary>
        /// <param name="printServiceTypeInfo">The print service type information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printServiceTypeInfo</exception>
        public string SaveAddPrintServiceType(IPrintServiceTypeView printServiceTypeInfo)
        {
            if (printServiceTypeInfo == null) throw new ArgumentNullException(nameof(printServiceTypeInfo));

            var result = string.Empty;


            var newPrintServiceType = new PrintServiceType
            {
                Description = printServiceTypeInfo.Description,
                IsActive = true
            };

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.PrintServiceTypes.Add(newPrintServiceType);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveNewPrintServiceType - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Saves the print service type description.
        /// </summary>
        /// <param name="PrintServiceTypeInfo">The print service type information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// PrintServiceTypeInfo
        /// or
        /// PrintServiceTypeInfo
        /// </exception>
        public string SavePrintServiceTypeDescription(IPrintServiceTypeView PrintServiceTypeInfo)
        {
            if (PrintServiceTypeInfo == null) throw new ArgumentNullException(nameof(PrintServiceTypeInfo));

            var result = string.Empty;

            using (
                var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
            {
                var aRecord =
                    dbContext.PrintServiceTypes.SingleOrDefault(x => x.Description == PrintServiceTypeInfo.Description);

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
                    var PrintServiceTypeDLL = dbContext.PrintServiceTypes.SingleOrDefault(x =>
                        x.PrintServiceTypeId == PrintServiceTypeInfo.PrintServiceTypeId);
                    if (PrintServiceTypeInfo == null) throw new ArgumentNullException(nameof(PrintServiceTypeInfo));

                    PrintServiceTypeDLL.Description = PrintServiceTypeInfo.Description;
                    PrintServiceTypeDLL.PrintServiceTypeId = PrintServiceTypeInfo.PrintServiceTypeId;
                    PrintServiceTypeDLL.IsActive = true;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SavePrintServiceTypeDescriptionInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Deletes the print service type description.
        /// </summary>
        /// <param name="printServiceTypeId">The print service type identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">printServiceTypeId</exception>
        public string DeletePrintServiceTypeDescription(int printServiceTypeId)
        {
            if (printServiceTypeId < 1)
            {
                throw new ArgumentOutOfRangeException("printServiceTypeId");
            }

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    //var serviceType = dbContext.PrintServiceTypes.Find(printServiceTypeInfo.PrintServiceTypeId);

                    var printServiceTypeDLL =
                        dbContext.PrintServiceTypes.SingleOrDefault(x => x.PrintServiceTypeId == printServiceTypeId);

                    printServiceTypeDLL.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteDescriptionInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            ;
            return result;
        }

        /// <summary>
        /// startedhere
        /// </summary>
        /// <param name="newsPaperInfo">The news paper information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">newsPaperInfo</exception>
        public string SaveAddNewsPaper(INewsPaperView newsPaperInfo)
        {
            if (newsPaperInfo == null) throw new ArgumentNullException(nameof(newsPaperInfo));

            var result = string.Empty;

            var newNewsPaper = new NewsPaper
            {
                Description = newsPaperInfo.Description,
                IsActive = true
            };
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.NewsPapers.Add(newNewsPaper);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveNewNewsPaper - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }







        /// <summary>
        /// Saves the type of the add print media.
        /// </summary>
        /// <param name="newsPaperInfo">The news paper information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">newsPaperInfo</exception>
        public string SaveAddPrintMediaType(IPrintMediaType printMediaType)
        {
            if (printMediaType == null) throw new ArgumentNullException(nameof(printMediaType));

            var result = string.Empty;

            var printType = new PrintMediaType
            {
                Description = printMediaType.Description,
                IsActive = true
            };
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.PrintMediaTypes.Add(printType);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SavePrintMediaType - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Updates the news paper information.
        /// </summary>
        /// <param name="newsPaperInfo">The news paper information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// newsPaperInfo
        /// or
        /// newsPaperDLL
        /// </exception>
        public string UpdateNewsPaperInfo(INewsPaperView newsPaperInfo)
        {
            if (newsPaperInfo == null) throw new ArgumentNullException(nameof(newsPaperInfo));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var newsPaperDLL =
                        dbContext.NewsPapers.SingleOrDefault(x => x.NewsPaperId == newsPaperInfo.NewsPaperId);
                    if (newsPaperDLL == null)
                    {
                        throw new ArgumentNullException(nameof(newsPaperDLL));
                    }

                    newsPaperDLL.Description = newsPaperInfo.Description;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveNewsPaperDescriptionInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }







        /// <summary>
        /// Updates the print media type information.
        /// </summary>
        /// <param name="printMediaType">Type of the print media.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// newsPaperInfo
        /// or
        /// newsPaperDLL
        /// </exception>
        public string UpdatePrintMediaTypeInfo(IPrintMediaType printMediaType)
        {
            if (printMediaType == null) throw new ArgumentNullException(nameof(printMediaType));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var printDLL =
                        dbContext.PrintMediaTypes.SingleOrDefault(x => x.Id == printMediaType.PrintMediaTypeId);
                    if (printDLL == null)
                    {
                        throw new ArgumentNullException(nameof(printDLL));
                    }

                    printDLL.Description = printMediaType.Description;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SavePrintMediaInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        /// <summary>
        /// Deletes the news paper description.
        /// </summary>
        /// <param name="newsPaperId">The news paper identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">newsPaperId</exception>
        public string DeleteNewsPaperDescription(int newsPaperId)
        {
            if (newsPaperId < 1)
            {
                throw new ArgumentOutOfRangeException("newsPaperId");
            }


            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var newsPaperDLL = dbContext.NewsPapers.SingleOrDefault(x => x.NewsPaperId == newsPaperId);

                    newsPaperDLL.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteNewsPaperDescription - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }




        /// <summary>
        /// Deletes the news paper description.
        /// </summary>
        /// <param name="newsPaperId">The news paper identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">newsPaperId</exception>
        public string DeletePrintMediaTypeDescription(int printMediaTypeId)
        {
            if (printMediaTypeId< 1)
            {
                throw new ArgumentOutOfRangeException("printMediaTypeId");
            }


            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var printDLL = dbContext.PrintMediaTypes.SingleOrDefault(x => x.Id == printMediaTypeId);

                    printDLL.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeletePrintMediaType - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }


        /// <summary>
        /// Saves the add print category.
        /// </summary>
        /// <param name="printCategoryInfo">The print category information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printCategoryInfo</exception>
        public string SaveAddPrintCategory(IPrintCategoryView printCategoryInfo)
        {
            if (printCategoryInfo == null) throw new ArgumentNullException(nameof(printCategoryInfo));

            var result = string.Empty;

            var newPrintCategory = new PrintCategory
            {
                Description = printCategoryInfo.Description,
                IsActive = true
            };
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.PrintCategories.Add(newPrintCategory);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveNewPrintCategory - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Updates the print category description.
        /// </summary>
        /// <param name="printCategoryInfo">The print category information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// printCategoryInfo
        /// or
        /// printCategoryInfo
        /// </exception>
        public string UpdatePrintCategoryDescription(IPrintCategoryView printCategoryInfo)
        {
            if (printCategoryInfo == null) throw new ArgumentNullException(nameof(printCategoryInfo));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    //var serviceType = dbContext.PrintServiceTypes.Find(printServiceTypeInfo.PrintServiceTypeId);

                    var printCategoryDLL =
                        dbContext.PrintCategories.SingleOrDefault(x =>
                            x.PrintCategoryId == printCategoryInfo.PrintCategoryId);
                    if (printCategoryInfo == null) throw new ArgumentNullException(nameof(printCategoryInfo));

                    printCategoryDLL.Description = printCategoryInfo.Description;
                    printCategoryDLL.PrintCategoryId = printCategoryInfo.PrintCategoryId;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveDescriptionInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Deletes the print category description.
        /// </summary>
        /// <param name="printCategoryId">The print category identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">printCategoryId</exception>
        public string DeletePrintCategoryDescription(int printCategoryId)
        {
            if (printCategoryId < 1)
            {
                throw new ArgumentOutOfRangeException("printCategoryId");
            }

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var printCategoryDLL =
                        dbContext.PrintCategories.SingleOrDefault(x => x.PrintCategoryId == printCategoryId);


                    printCategoryDLL.IsActive = false;
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

        /// <summary>
        /// Saves the add print service type price.
        /// </summary>
        /// <param name="printServiceTypePriceInfo">The print service type price information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printServiceTypePriceInfo</exception>
        public string SaveAddPrintServiceTypePrice(IPrintServiceTypePriceView printServiceTypePriceInfo)
        {
            if (printServiceTypePriceInfo == null) throw new ArgumentNullException(nameof(printServiceTypePriceInfo));

            var result = string.Empty;

            var newPrintServiceTypePrice = new PrintServiceTypePrice
            {
                Comment = printServiceTypePriceInfo.Comment,
                DateCreated = DateTime.Now,
                DateInactive = null,
                EffectiveDate = printServiceTypePriceInfo.EffectiveDate,
                NewsPaperId = printServiceTypePriceInfo.NewsPaperId,
                PrintServiceTypeId = printServiceTypePriceInfo.PrintServiceTypeId,
                Amount = printServiceTypePriceInfo.Amount,
                PrintServiceColorId=printServiceTypePriceInfo.PrintServiceColorId??0,
                PrintMediaTypeId=printServiceTypePriceInfo.PrintMediaTypeId,
                IsActive = true
                
            };
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var Prevprice = dbContext.PrintServiceTypePrices.Where(x => x.PrintServiceTypeId == printServiceTypePriceInfo.PrintServiceTypeId&&printServiceTypePriceInfo.NewsPaperId==x.NewsPaperId);
                    if (Prevprice != null)
                    {
                        foreach (var j in Prevprice)
                        {
                            j.DateInactive = DateTime.Now;
                            j.IsActive = false;

                        }
                        dbContext.SaveChanges();
                    }
                    dbContext.PrintServiceTypePrices.Add(newPrintServiceTypePrice);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveNewPrintServiceTypePrice - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the print service type price description.
        /// </summary>
        /// <param name="printServiceTypePriceInfo">The print service type price information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// printServiceTypePriceInfo
        /// or
        /// printServiceTypePriceInfo
        /// </exception>
        public IPrintServiceTypePriceView savePrintServiceTypePriceDescription(
            IPrintServiceTypePriceView printServiceTypePriceInfo)
        {
            if (printServiceTypePriceInfo == null) throw new ArgumentNullException(nameof(printServiceTypePriceInfo));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var printServiceTypePriceDLL = dbContext.PrintServiceTypePrices.SingleOrDefault(x =>
                        x.PrintServiceTypePriceId == printServiceTypePriceInfo.PrintServiceTypePriceId);
                    if (printServiceTypePriceInfo == null)
                        throw new ArgumentNullException(nameof(printServiceTypePriceInfo));

                    printServiceTypePriceDLL.PrintMediaTypeId = printServiceTypePriceInfo.PrintMediaTypeId;
                    printServiceTypePriceDLL.PrintServiceTypeId = printServiceTypePriceInfo.PrintServiceTypeId;
                    printServiceTypePriceDLL.NewsPaperId = printServiceTypePriceInfo.NewsPaperId;
                    printServiceTypePriceDLL.EffectiveDate = printServiceTypePriceInfo.EffectiveDate;

                    printServiceTypePriceDLL.DateInactive = printServiceTypePriceInfo.DateInactive;
                    printServiceTypePriceDLL.Comment = printServiceTypePriceInfo.Comment;
                    printServiceTypePriceDLL.PrintServiceTypePriceId =
                        printServiceTypePriceInfo.PrintServiceTypePriceId;
                    printServiceTypePriceDLL.PrintServiceColorId = printServiceTypePriceInfo.PrintServiceColorId??0;

                    printServiceTypePriceDLL.Amount = printServiceTypePriceInfo.Amount;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveDescriptionInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            printServiceTypePriceInfo.ProcessingMessage = result;
            return printServiceTypePriceInfo;
        }

        /// <summary>
        /// Deletes the print service type price description.
        /// </summary>
        /// <param name="printServiceTypePriceId">The print service type price identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">printServiceTypePriceId</exception>
        public string DeletePrintServiceTypePriceDescription(int printServiceTypePriceId)
        {
            if (printServiceTypePriceId < 1)
            {
                throw new ArgumentOutOfRangeException("printServiceTypePriceId");
            }

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var printServiceTypePriceDLL =
                        dbContext.PrintServiceTypePrices.SingleOrDefault(x =>
                            x.PrintServiceTypePriceId == printServiceTypePriceId);


                    printServiceTypePriceDLL.IsActive = false;
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


        /// <summary>
        /// Saves the print transaction.
        /// </summary>
        /// <param name="printTransactionUi">The print transaction UI.</param>
        /// <param name="printTransactionId">The print transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printTransactionUI</exception>
        /// <exception cref="Exception">Repository.Save. Db Entity Validation Exception. Data not saved. Error: " +
        /// sb.ToString()</exception>
        public string SavePrintTransaction(IPrintTransactionUI printTransactionUi, out int printTransactionId)
        {
            var result = string.Empty;

            if(printTransactionUi==null)
            {
                throw new ArgumentNullException(nameof(printTransactionUi));
            }
           
          
            var view = new PrintTransaction
            {
                OrderId = printTransactionUi.OrderId,
                IsHaveMaterial = printTransactionUi.isHaveMaterial,
                ApconApprovalNumber = printTransactionUi.ApconApprovalNumber,
                ApconApprovalTypeId = printTransactionUi.ApconApprovalTypeId,
                OrderTitle = printTransactionUi.OrderTitle,
                ApconApprovalTypePriceId = printTransactionUi.ApconApprovalTypePriceId,
                ApconApprovalAmount = printTransactionUi.ApconAmount,
                PrintCategoryId = printTransactionUi.PrintCategoryId,
                MaterialDigitalFileId = printTransactionUi.MaterialDigitalFileId,
                DesignElementId = printTransactionUi.DesignElementId,
                DesignElementPriceId = printTransactionUi.DesignElementPriceId,
                DesignAmount = printTransactionUi.DesignElementAmount,
                DurationTypeCode = "D",
                ColorDescription =printTransactionUi .ColorDescription,
                DateCreated = DateTime.Now,
                TransactionStatusCode = "A",
                UserId = printTransactionUi.UserId,
                TotalPrice = printTransactionUi.TotalAmount,
            };
            try
            {
                // calling our database 
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    // calling changes
                    dbContext.PrintTransactions.Add(view);
                    dbContext.SaveChanges();
                }
            }

            catch (Exception e)
            {
                result = string.Format("saving Print Services - {0} , {1}", e.Message, e.InnerException != null ? e.InnerException.Message : "");
            }

            printTransactionId = view.PrintTransactionId;
            return result;
        }

        /// <summary>
        /// Saves the print transaction publis.
        /// </summary>
        /// <param name="Printview">The printview.</param>
        /// <param name="PrintTransactionId">The print transaction identifier.</param>
        /// <returns></returns>
        public string SavePrintTransactionPublis(IPrintMediaModelView Printview, int PrintTransactionId)
        {
            var result = string.Empty;

            var view = new PrintTransactionPublish
            {
                
                PrintTransactionId = PrintTransactionId,
                
                PrintServiceAmount = Printview.TotalAmount
            };
            try
            {
                // calling our database 
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    // calling changes
                    dbContext.PrintTransactionPublishes.Add(view);
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
        /// Saves the color of the print transaction.
        /// </summary>
        /// <param name="Printview">The printview.</param>
        /// <param name="PrintTransactionId">The print transaction identifier.</param>
        /// <returns></returns>
        public string SavePrintTransactionColor(IPrintMediaModelView Printview, int PrintTransactionId)
        {
            var result = string.Empty; 

            var view = new PrintTransactionColor
            {
                // PrintTransactionPublishId = PrintTransactionPublishId,
                PrintTransactionId = PrintTransactionId,
                PrintTransactionColorId = Printview.ColorId,
                IsActive = true
            };
            try
            {
                // calling our database 
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    // calling changes
                    dbContext.PrintTransactionColors.Add(view);
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
        /// Deletes the print order.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">radioTransaction</exception>
        public string DeletePrintOrder(int transactionId)
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
                    var printTransaction =
                        dbContext.PrintTransactions.FirstOrDefault(x =>
                            x.PrintTransactionId == transactionId);
                    if (printTransaction == null)
                    {
                        throw new ArgumentNullException(nameof(printTransaction));
                    }

                    printTransaction.TransactionStatusCode = "D";
                    dbContext.SaveChanges();



                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeletePrinttOrder- {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }


        public string DeletePrintTransactionAiring(int PrintTranscationId)
        {
            if (PrintTranscationId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(PrintTranscationId));
            }

            var result = string.Empty;
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var details = dbContext.PrintTransactionAirings.Where(x => x.PrintTransactionId.Equals(PrintTranscationId));
                    if (details.Any())
                    {
                        dbContext.PrintTransactionAirings.RemoveRange(details);
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
        /// Saves the print transaction airing.
        /// </summary>
        /// <param name="printTransactionAiringUIs">The print transaction airing u is.</param>
        /// <param name="printTransactionId">The print transaction identifier.</param>
        /// <returns></returns>
        public string SavePrintTransactionAiring(IList<IPrintTransactionAiringUI> printTransactionAiringUIs, int printTransactionId)
        {
            var result = string.Empty;

        

                try
                {
                //  calling our database 
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    foreach (var j in printTransactionAiringUIs)
                    {
                        var printAiring = new PrintTransactionAiring
                        {

                            PrintTransactionId = printTransactionId,
                            NewsPaperId = j.NewsPaperId,
                            StartDate = j.StartDate,
                            PrintServiceTypePriceId = j.PrintServiceId,
                            NumberOfInserts = j.NumberOfInserts,
                            PrintColorId=j.PrintColorId,
                            Price = j.NewsPaperPrice,
                            PrintMediaTypePriceId=j.PrintMediaTypeId,
                            IsActive = true
                        };

                        dbContext.PrintTransactionAirings.Add(printAiring);
                        dbContext.SaveChanges();
                    }
                }
                }
                catch (Exception e)
                {
                    result = string.Format("Store Airing - {0} , {1}", e.Message,
                        e.InnerException != null ? e.InnerException.Message : "");
                }
            


            return result;
        }


        /// <summary>
        /// Gets the active pm transaction.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetActivePmTransaction</exception>
        public IList<IPrintTransaction> GetActivePmTransaction(int orderNumber)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = PrintQueries.GetActivePmTransaction(dbContext, orderNumber).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetActivePmTransaction", e);
            }
        }




        /// <summary>
        /// Gets the type of the active p media.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetActivePmTransaction</exception>
        public IList<IPrintMediaType> GetActivePMediaType()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = PrintQueries.GetActivePrintMediaTypes(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetActivePmTransaction", e);
            }
        }


        /// <summary>
        /// Gets the name of the news paper description by.
        /// </summary>
        /// <param name="newsPaperName">Name of the news paper.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetNewsPaperDescriptionByName</exception>
        public INewsPaper GetNewsPaperDescriptionByName(string newsPaperName)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = PrintQueries.GetNewsPapaerDescriptionByName(dbContext, newsPaperName);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetNewsPaperDescriptionByName", e);
            }
        }


        /// <summary>
        /// Gets the name of the print media type by.
        /// </summary>
        /// <param name="newsPaperName">Name of the news paper.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetNewsPaperDescriptionByName</exception>
        public IPrintMediaType GetPrintMediaTypeByName(string newsPaperName)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = PrintQueries.GetPrintMediaTypeByName(dbContext, newsPaperName);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetNewsPaperDescriptionByName", e);
            }
        }





        /// <summary>
        /// Gets the name of the print category by.
        /// </summary>
        /// <param name="categoryName">Name of the category.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetPrintCategoryByName</exception>
        public IPrintCategory GetPrintCategoryByName(string categoryName)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = PrintQueries.getPrintCategoryByName(dbContext, categoryName);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetPrintCategoryByName", e);
            }
        }


        /// <summary>
        /// Gets the name of the print service type by.
        /// </summary>
        /// <param name="printServiceType">Type of the print service.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetPrintServiceTypeByName</exception>
        public IPrintServiceType GetPrintServiceTypeByName(string printServiceType)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = PrintQueries.getPrintServiceTypeDescriptionByName(dbContext, printServiceType);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetPrintServiceTypeByName", e);
            }
        }


        /// <summary>
        /// Saves the print transaction airing.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public string SavePrintTransactionAiring(IPrintTransactionAiringView view)
        {
            var result = string.Empty;

            var printAiring = new PrintTransactionAiring
            {
                PrintTransactionId = view.PrintTransactionId,
                NewsPaperId = view.NewsPaperId,
                //ServiceTypeCode = view.ServiceTypeCode,
                IsActive = true
            };

            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.PrintTransactionAirings.Add(printAiring);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SavePrintTransactionAiring - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets the type of the service.
        /// </summary>
        /// <param name="newspaper">The newspaper.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetPrintServiceTypeByName</exception>
        public IPrintServiceTypePrice GetServiceType(int newspaper, int serviceType,int serviceColorId,int printMediaTypeId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = PrintQueries.getPrintServiceTypePriceByNewsPaperID(dbContext, newspaper, serviceType,serviceColorId,printMediaTypeId);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetServiceType", e);
            }
        }


        /// <summary>
        /// Gets the tv transaction airing.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTvTransactionAiring</exception>
        public IList<IPrintTransactionAiring> GetPrintTransactionAiring(int transactionId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        PrintQueries.GetPrintTransactionAirings(dbContext, transactionId).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetPrintTransactionAiring", e);
            }
        }




        public IList<IPrintTransactionAiringUI> GetPrintTransactionAiringList(int transactionId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        PrintQueries.GetPrintTransactionAiringsList(dbContext, transactionId).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetPrintTransactionAiring", e);
            }
        }










        /// <summary>
        /// Updates the print transaction airing.
        /// </summary>
        /// <param name="printInfo">The print information.</param>
        /// <param name="printTransactionId">The print transaction identifier.</param>
        /// <returns></returns>
        public string UpdatePrintTransactionAiring(IPrintMediaModelView printInfo, int printTransactionId)
        {
            var printresult = string.Empty;
            foreach (var item in printInfo.NewPaperSelectionList)
            {
                var newsPaperId = int.Parse(item["NewsPaperId"]);
                var serviceTypeId = int.Parse(item["ServiceTypeId"]);
                var inserts = int.Parse(item["Inserts"]);
                var price = decimal.Parse(item["Price"]); 

                var printTransactionAiringRecord = new PrintTransactionAiring
                {
                    PrintTransactionId = printTransactionId,
                    NewsPaperId = newsPaperId,
                    PrintServiceTypePriceId = serviceTypeId,
                    NumberOfInserts = inserts,
                    Price = price

                };




                try
                {
                    //checking if the Airing Information is Stored 
                    using (
                        var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                    {
                        var printAiringInformation =
                            dbContext.PrintTransactionAirings.FirstOrDefault(x =>
                            x.PrintTransactionId == printInfo.PrintTransactionId && x.NewsPaperId == newsPaperId);
                        if (printAiringInformation != null)
                        {
                            printAiringInformation.PrintTransactionId = printInfo.PrintTransactionId;
                            printAiringInformation.NewsPaperId = newsPaperId;
                            printAiringInformation.PrintServiceTypePriceId = serviceTypeId;
                            printAiringInformation.NumberOfInserts = inserts;
                            printAiringInformation.Price = price;
                        }
                        else
                        {
                            if (price > 0)
                            {
                                dbContext.PrintTransactionAirings.Add(printTransactionAiringRecord);
                            }
                        }
                        dbContext.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    printresult = string.Format("Update Print Airing - {0} , {1}", e.Message,
                        e.InnerException != null ? e.InnerException.Message : "");
                }
            }
            return printresult;
        }


        /// <summary>
        /// Updates the color of the print transaction.
        /// </summary>
        /// <param name="printInfo">The print information.</param>
        /// <param name="printTransactionId">The print transaction identifier.</param>
        /// <returns></returns>
        public string UpdatePrintTransactionColor(IPrintMediaModelView printInfo, int printTransactionId)
        {
            var result = string.Empty;

           

            try
            {
                //checking if the Airing Information is Stored 
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var printTransactionColors =
                        dbContext.PrintTransactionColors.FirstOrDefault(x =>
                        x.PrintTransactionId == printInfo.PrintTransactionId );
                    if (printTransactionColors != null)
                    {
                        printTransactionColors.PrintTransactionId = printInfo.PrintTransactionId;
                        printTransactionColors.PrintTransactionColorId = printInfo.ColorId;
                    }
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Update Print Transaction Color - {0} , {1}", e.Message,
                       e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Updates the print transaction.
        /// </summary>
        /// <param name="Printview">The printview.</param>
        /// <param name="PrintTransactionId">The print transaction identifier.</param>
        /// <returns></returns>
        public string UpdatePrintTransaction(IPrintTransactionUI printTransactionUI)
        {
            var result = string.Empty;
           
           

            try
            {
                //checking if the Airing Information is Stored 
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var printTransaction =
                        dbContext.PrintTransactions.FirstOrDefault(x =>
                        x.PrintTransactionId == printTransactionUI.PrintTransactionId);
                    if (printTransaction != null)
                    {
                       
                        printTransaction.ApconApprovalNumber = printTransactionUI.ApconApprovalNumber;
                        printTransaction.ApconApprovalTypeId = printTransactionUI.ApconApprovalTypeId;
                        printTransaction.OrderTitle = printTransactionUI.OrderTitle;
                        printTransaction.ApconApprovalTypePriceId = printTransactionUI.ApconApprovalTypePriceId;
                        printTransaction.ApconApprovalAmount = printTransactionUI.ApconAmount;
                        printTransaction.PrintCategoryId = printTransactionUI.PrintCategoryId;
                        printTransaction.MaterialDigitalFileId = printTransactionUI.MaterialDigitalFileId;
                        printTransaction.DesignElementId = printTransactionUI.DesignElementId;
                        printTransaction.DesignElementPriceId = printTransactionUI.DesignElementPriceId;
                        printTransaction.DesignAmount = printTransactionUI.DesignElementAmount;
                        
                        printTransaction.ColorDescription = printTransactionUI.ColorDescription;
                        printTransaction.DateCreated = DateTime.Now;
                        printTransaction.TransactionStatusCode = "A";
                        
                        
                        
                        printTransaction.TotalPrice = printTransactionUI.TotalAmount;
                    }

                    dbContext.SaveChanges();
                }

            }
            catch (Exception e)
            {
                result = string.Format("Update Print Transaction - {0} , {1}", e.Message,
                       e.InnerException != null ? e.InnerException.Message : "");
            }
            
            return result;
        }


        /// <summary>
        /// Gets the print transaction airing by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetPrintTransactionAiring</exception>
        public IList<IPrintTransactionAiring> GetPrintTransactionAiringById(int transactionId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        PrintQueries.getPrintTransactionAiringBYId(dbContext, transactionId).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetPrintTransactionAiring", e);
            }
        }


        /// <summary>
        /// Gets the print transaction by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetPrintTransactionById</exception>
        public IPrintTransaction GetPrintTransactionById(int transactionId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        PrintQueries.GetPrintTransactionById(dbContext, transactionId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetPrintTransactionById", e);
            }
        }


      
        /// <summary>
        /// Gets the selected color by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetPrintTransactionById</exception>
        public IList<IPrintTransactionColor> GetSelectedColorById(int transactionId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        PrintQueries.GetSelectedColorsById(dbContext, transactionId).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetPrintTransactionById", e);
            }
        }



        /// <summary>
        /// Gets the print service colors.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetPrintTransactionById</exception>
        public IList<IPrintServiceColor> GetPrintServiceColors()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        PrintQueries.GetPrintServiceColors(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetPrintServiceColors", e);
            }
        }

        /// <summary>
        /// Gets the name of the print service color description by.
        /// </summary>
        /// <param name="PrintServiceTypeColor">Color of the print service type.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetPrintServiceColorDescriptionByName</exception>
        public IPrintServiceColor GetPrintServiceColorDescriptionByName(string PrintServiceTypeColor)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = PrintQueries.GetPrintServiceColorDescriptionByName(dbContext, PrintServiceTypeColor);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetPrintServiceColorDescriptionByName", e);
            }
        }

        /// <summary>
        /// Saves the color of the add print service.
        /// </summary>
        /// <param name="printServiceColor">Color of the print service.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printServiceColor</exception>
        public string SaveAddPrintServiceColor(IPrintServiceColor printServiceColor)
        {
            if (printServiceColor == null) throw new ArgumentNullException(nameof(printServiceColor));

            var result = string.Empty;

            var printType = new PrintServiceColor
            {
                PrintServiceTypeColor = printServiceColor.PrintServiceTypeColor,
                IsActive = true
            };
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.PrintServiceColors.Add(printType);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SavePrintServiceColor - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Updates the print service color information.
        /// </summary>
        /// <param name="printServiceColor">Color of the print service.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// printServiceColor
        /// or
        /// printDLL
        /// </exception>
        public string UpdatePrintServiceColorInfo(IPrintServiceColor printServiceColor)
        {
            if (printServiceColor == null) throw new ArgumentNullException(nameof(printServiceColor));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var printDLL =
                        dbContext.PrintServiceColors.SingleOrDefault(x => x.PrintServiceTypeColorId == printServiceColor.PrintServiceTypeColorId);
                    if (printDLL == null)
                    {
                        throw new ArgumentNullException(nameof(printDLL));
                    }

                    printDLL.PrintServiceTypeColor = printServiceColor.PrintServiceTypeColor;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SavePrintServiceInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Deletes the print service color description.
        /// </summary>
        /// <param name="PrintServiceTypeColorId">The print service type color identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">PrintServiceTypeColorId</exception>
        public string DeletePrintServiceColorDescription(int PrintServiceTypeColorId)
        {
            if (PrintServiceTypeColorId < 1)
            {
                throw new ArgumentOutOfRangeException("PrintServiceTypeColorId");
            }


            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var printDLL = dbContext.PrintServiceColors.SingleOrDefault(x => x.PrintServiceTypeColorId == PrintServiceTypeColorId);

                    printDLL.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeletePrintServiceColor - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }
            return result;
        }

        /// <summary>
        /// Gets the name of the art work price description by.
        /// </summary>
        /// <param name="ServiceTypeCode">The service type code.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetArtWorkPriceDescriptionByName</exception>
        public IOnlineArtworkPrice GetArtWorkPriceDescriptionByName(string ServiceTypeCode)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = PrintQueries.GetArtWorkPriceDescriptionByName(dbContext, ServiceTypeCode);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetArtWorkPriceDescriptionByName", e);
            }
        }

        /// <summary>
        /// Saves the add art work price.
        /// </summary>
        /// <param name="onlineArtworkPrice">The online artwork price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineArtworkPrice</exception>
        public string SaveAddArtWorkPrice(IOnlineArtworkPrice onlineArtworkPrice)
        {
            if (onlineArtworkPrice == null) throw new ArgumentNullException(nameof(onlineArtworkPrice));

            var result = string.Empty;

            var printType = new ArtWorkPrice
            {
                Amount = onlineArtworkPrice.Amount,
                IsActive = true
            };
            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.ArtWorkPrices.Add(printType);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveAddArtWorkPrice - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Updates the art work price information.
        /// </summary>
        /// <param name="onlineArtworkPrice">The online artwork price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// onlineArtworkPrice
        /// or
        /// printDLL
        /// </exception>
        public string UpdateArtWorkPriceInfo(IOnlineArtworkPrice onlineArtworkPrice)
        {
            if (onlineArtworkPrice == null) throw new ArgumentNullException(nameof(onlineArtworkPrice));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var printDLL =
                        dbContext.ArtWorkPrices.SingleOrDefault(x => x.ArtWorkPriceId == onlineArtworkPrice.ArtWorkPriceId);
                    if (printDLL == null)
                    {
                        throw new ArgumentNullException(nameof(printDLL));
                    }

                    printDLL.ServiceTypeCode = onlineArtworkPrice.ServiceTypeCode;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveArtWorkInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
    }
}