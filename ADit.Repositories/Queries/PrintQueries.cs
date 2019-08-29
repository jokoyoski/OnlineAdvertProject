using System;
using System.Collections.Generic;
using System.Linq;
using ADit.Repositories.DataAccess;
using ADit.Interfaces;
using ADit.Repositories.Models;

namespace ADit.Repositories.Queries
{
    internal static class PrintQueries
    {
        /// <summary>
        /// Gets the news papers.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<INewsPaper> GetNewsPapers(ADitEntities db)
        {
            var result = (from s in db.NewsPapers
                          select new NewsPaperModel
                          {
                              NewsPaperId = s.NewsPaperId,
                              Description = s.Description,
                              IsActive = s.IsActive
                          }).OrderBy(x => x.Description);


            return result;
        }


        internal static IEnumerable<IPrintMediaType> GetPrintMediaTypes(ADitEntities db)
        {
            var result = (from s in db.PrintMediaTypes
                          select new PrintMediaTypeModel
                          {
                              PrintMediaTypeId = s.Id,
                              Description = s.Description,
                              IsActive = s.IsActive
                          }).OrderBy(x => x.Description);


            return result;
        }


        internal static IEnumerable<IPrintMediaType> GetActivePrintMediaTypes(ADitEntities db)
        {
            var result = (from s in db.PrintMediaTypes
                          where s.IsActive == true
                          select new PrintMediaTypeModel
                          {
                              PrintMediaTypeId = s.Id,
                              Description = s.Description,
                          }).OrderBy(x => x.Description);


            return result;
        }


        /// <summary>
        /// Gets the service types.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IPrintServiceType> GetServiceTypes(ADitEntities db)
        {
            var result = (from s in db.PrintServiceTypes
                          select new PrintServiceTypeModel
                          {
                              PrintServiceTypeId = s.PrintServiceTypeId,
                              Description = s.Description,
                              IsActive = s.IsActive
                          }).OrderBy(x => x.Description);


            return result;
        }

        /// <summary>
        /// Gets the print categories.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IPrintCategory> getPrintCategories(ADitEntities db)
        {
            var result = (from s in db.PrintCategories
                          select new PrintCategoryModel
                          {
                              PrintCategoryId = s.PrintCategoryId,
                              Description = s.Description,
                              IsActive = s.IsActive
                          }).OrderBy(x => x.Description);


            return result;
        }


        /// <summary>
        /// Gets the apcon approval price by type identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <returns></returns>
        internal static IApconApprovalTypePrice GetApconApprovalPriceByTypeId(ADitEntities db, int typeId)
        {
            var result = (from d in db.ApconApprovalTypePrices
                          where d.ApconApprovalTypeId.Equals(typeId)
                          select new ApconApprovalTypePriceModel
                          {
                              ApconTypePriceId = d.ApconApprovalTypePriceId,
                              ApconTypeId = d.ApconApprovalTypeId,
                              Amount = d.Amount,
                              Comment = d.Comment,


                              EffectiveDate = d.EffectiveDate,
                              DateInactive = d.DateInactive,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated
                              // Consent=d.Consent,.
                          }).FirstOrDefault();


            return result;
        }

        /// <summary>
        /// Gets the print service type price.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IPrintServiceTypePrice> getPrintServiceTypePrice(ADitEntities db)
        {
            var result = (from s in db.PrintServiceTypePrices
                          join d in db.NewsPapers on s.NewsPaperId equals d.NewsPaperId
                          join f in db.PrintServiceColors on s.PrintServiceColorId equals f.PrintServiceTypeColorId
                          join p in db.PrintServiceTypes on s.PrintServiceTypeId equals p.PrintServiceTypeId
                          select new PrintServiceTypePriceModel
                          {
                              PrintServiceTypePriceId = s.PrintServiceTypePriceId,
                              PrintServiceTypeId = s.PrintServiceTypeId,
                              NewsPaperId = s.NewsPaperId,
                              Amount = s.Amount,
                              Comment = s.Comment,
                              EffectiveDate = s.EffectiveDate,
                              DateInactive = s.DateInactive,
                              DateCreated = s.DateCreated,
                              IsActive = s.IsActive,
                              ServiceTypeDescription = p.Description,
                              NewspaperDescription = d.Description,
                              ServiceColorDescription = f.PrintServiceTypeColor,
                          }).OrderBy(x => x.PrintServiceTypeId);


            return result;
        }

        /// <summary>
        /// Gets the print service type description by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="typeDescriptionId">The type description identifier.</param>
        /// <returns></returns>
        internal static IPrintServiceType getPrintServiceTypeDescriptionByID(ADitEntities db, int typeDescriptionId)
        {
            var result = (from d in db.PrintServiceTypes
                          where d.PrintServiceTypeId.Equals(typeDescriptionId)
                          select new PrintServiceTypeModel
                          {
                              Description = d.Description
                          }).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the news paper description by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="typeDescriptionId">The type description identifier.</param>
        /// <returns></returns>
        internal static INewsPaper GetNewsPaperDescriptionById(ADitEntities db, int typeDescriptionId)
        {
            var result = (from d in db.NewsPapers
                          where d.NewsPaperId.Equals(typeDescriptionId)
                          select new NewsPaperModel
                          {
                              Description = d.Description
                          }).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the print media type description by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="typeDescriptionId">The type description identifier.</param>
        /// <returns></returns>
        internal static IPrintMediaType GetPrintMediaTypeDescriptionById(ADitEntities db, int typeDescriptionId)
        {
            var result = (from d in db.PrintMediaTypes
                          where d.Id.Equals(typeDescriptionId)
                          select new PrintMediaTypeModel
                          {
                              PrintMediaTypeId = typeDescriptionId,
                              Description = d.Description
                          }).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the print category description by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="typeDescriptionId">The type description identifier.</param>
        /// <returns></returns>
        internal static IPrintCategory getPrintCategoryDescriptionByID(ADitEntities db, int typeDescriptionId)
        {
            var result = (from d in db.PrintCategories
                          where d.PrintCategoryId.Equals(typeDescriptionId)
                          select new PrintCategoryModel
                          {
                              Description = d.Description
                          }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the print service type price description by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="typeDescriptionId">The type description identifier.</param>
        /// <returns></returns>
        internal static IPrintServiceTypePrice getPrintServiceTypePriceDescriptionByID(ADitEntities db,
            int typeDescriptionId)
        {
            var result = (from d in db.PrintServiceTypePrices
                          where d.PrintServiceTypePriceId.Equals(typeDescriptionId)
                          select new PrintServiceTypePriceModel
                          {
                              Comment = d.Comment,
                              IsActive = d.IsActive,
                              NewsPaperId = d.NewsPaperId,
                              Amount = d.Amount,
                              DateInactive = d.DateInactive,
                              DateCreated = d.DateCreated,
                              EffectiveDate = d.EffectiveDate,
                              PrintServiceTypeId = d.PrintServiceTypeId,
                              PrintServiceTypePriceId = d.PrintServiceTypePriceId,
                              PrintServiceColorId = d.PrintServiceColorId,
                              PrintMediaTypeId = d.PrintMediaTypeId
                          }).FirstOrDefault();
            return result;
        }

        internal static IEnumerable<IApconApprovalTypePrice> getApconApprovalPrice(ADitEntities db)
        {
            var result = (from d in db.ApconApprovalTypePrices
                          join e in db.ApconApprovalTypes on d.ApconApprovalTypeId equals e.ApconApprovalTypeId
                          select new Models.ApconApprovalTypePriceModel
                          {
                              ApconTypePriceId = d.ApconApprovalTypePriceId,
                              Amount = d.Amount,
                              ApconTypeDescription = e.Description,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              EffectiveDate = d.EffectiveDate,
                              DateInactive = d.DateInactive,
                              ApconTypeId = d.ApconApprovalTypeId,
                              Comment = d.Comment
                          }).OrderBy(x => x.Amount);
            return result;
        }


        /// <summary>
        /// Gets the apcon approval price by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IApconApprovalTypePrice getApconApprovalPriceById(ADitEntities db, int Id)
        {
            var result = (from d in db.ApconApprovalTypePrices
                          join e in db.ApconApprovalTypes on d.ApconApprovalTypeId equals e.ApconApprovalTypeId
                          where e.ApconApprovalTypeId.Equals(Id)
                          where d.IsActive.Equals(true)
                          select new Models.ApconApprovalTypePriceModel
                          {
                              ApconTypePriceId = d.ApconApprovalTypePriceId,
                              Amount = d.Amount,
                              ApconTypeDescription = e.Description,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              EffectiveDate = d.EffectiveDate,
                              // DateInactive = d.DateInactive,
                              ApconTypeId = d.ApconApprovalTypeId,
                              Comment = d.Comment
                          }).SingleOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the design e lment price.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IDesignElementPrice> getDesignElementPrice(ADitEntities db)
        {
            var result = (from d in db.DesignElementPrices
                join e in db.DesignElements on d.DesignElementId equals e.DesignElementId
               
                where d.ServiceTypeCode == "B" // Design Element for Only Branding
                where d.EffectiveDate <= DateTime.UtcNow
                where d.DateInactive >= DateTime.UtcNow || d.DateInactive == null
                where d.IsActive == true
                where e.IsActive == true
                select new Models.DesignElementPriceModel
                {
                    DesignElementPriceId = d.DesignElementPriceId,
                    Amount = d.Amount,
                    Description = e.Description,
                    IsActive = d.IsActive,
                    DateCreated = d.DateCreated,
                    EffectiveDate = d.EffectiveDate,
                    DateInactive = d.DateInactive,
                    DesignElementId = d.DesignElementId,
                    Comment = d.Comment
                }).OrderBy(x => x.Amount);
            return result;
        }


        /// <summary>
        /// Gets the printing design element price.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IDesignElementPrice> getPrintingDesignElementPrice(ADitEntities db)
        {
            var result = (from d in db.DesignElementPrices
                          join e in db.DesignElements on d.DesignElementId equals e.DesignElementId
                          where d.ServiceTypeCode == "P" // Design Element for Only Print
                          where d.EffectiveDate <= DateTime.UtcNow
                          where d.DateInactive >= DateTime.UtcNow || d.DateInactive == null
                          where d.IsActive == true
                          where e.IsActive == true
                          select new Models.DesignElementPriceModel
                          {
                              DesignElementPriceId = d.DesignElementPriceId,
                              Amount = d.Amount,
                              Description = e.Description,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              EffectiveDate = d.EffectiveDate,
                              DateInactive = d.DateInactive,
                              DesignElementId = d.DesignElementId,
                              Comment = d.Comment
                          }).OrderBy(x => x.Amount);
            return result;
        }


        /// <summary>
        /// Gets the design element price by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="designElementId">The identifier.</param>
        /// <returns></returns>
        internal static IDesignElementPrice getDesignElementPriceById(ADitEntities db, int designElementId)
        {
            var result = (from d in db.DesignElementPrices
                          join e in db.DesignElements on d.DesignElementId equals e.DesignElementId
                          where d.DesignElementId.Equals(designElementId)
                          where d.EffectiveDate <= DateTime.UtcNow
                          where d.DateInactive >= DateTime.UtcNow || d.DateInactive == null
                          where d.IsActive == true
                          where e.IsActive == true
                          select new DesignElementPriceModel
                          {
                              DesignElementPriceId = d.DesignElementPriceId,
                              Amount = d.Amount,
                              Description = e.Description,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              EffectiveDate = d.EffectiveDate,
                              DateInactive = d.DateInactive,
                              DesignElementId = d.DesignElementId,
                              Comment = d.Comment
                          }).First();
            return result;
        }

        /// <summary>
        /// Gets the active pm transaction.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IPrintTransaction> GetActivePmTransaction(ADitEntities db, int orderId)
        {
            var result = (from s in db.PrintTransactions
                          where s.OrderId.Equals(orderId)
                          where s.TransactionStatusCode.Equals("A")
                          select new PrintTransactionModel
                          {
                              PrintTransactionId = s.PrintTransactionId,
                              OrderId = s.OrderId,
                              IsHaveMaterial = s.IsHaveMaterial,
                              MaterialDigitalFileId = s.MaterialDigitalFileId,
                              ApconApprovalNumber = s.ApconApprovalNumber,
                              ApconApprovalTypeId = s.ApconApprovalTypeId,
                              ApconApprovalTypePriceId = s.ApconApprovalTypePriceId,
                              ApconApprovalAmount = s.ApconApprovalAmount,
                              PrintCategoryId = s.PrintCategoryId,
                              DesignElementId = s.DesignElementId,
                              DesignElementPriceId = s.DesignElementPriceId,
                              DesignAmount = s.DesignAmount,
                              DurationTypeCode = s.DurationTypeCode,

                              DateCreated = s.DateCreated,
                              TransactionStatusCode = s.TransactionStatusCode,
                              OrderTitle = s.OrderTitle,
                              UserId = s.UserId,
                              TotalPrice = s.TotalPrice,
                          }
                ).OrderBy(x => x.PrintTransactionId);
            return result;
        }


        /// <summary>
        /// Gets the name of the news papaer description by.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="newsPaperName">Name of the news paper.</param>
        /// <returns></returns>
        internal static INewsPaper GetNewsPapaerDescriptionByName(ADitEntities db, string newsPaperName)
        {
            var result = (from s in db.NewsPapers
                          where s.Description.Equals(newsPaperName)
                          select new NewsPaperModel
                          {
                              NewsPaperId = s.NewsPaperId,
                              Description = s.Description,
                              IsActive = s.IsActive
                          }
                ).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the name of the news papaer description by.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="newsPaperName">Name of the news paper.</param>
        /// <returns></returns>
        internal static IPrintMediaType GetPrintMediaTypeByName(ADitEntities db, string Name)
        {
            var result = (from s in db.PrintMediaTypes
                          where s.Description.Equals(Name)
                          select new PrintMediaTypeModel
                          {
                              PrintMediaTypeId = s.Id,
                              Description = s.Description,
                              IsActive = s.IsActive
                          }
                ).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the name of the print category by.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="categoryName">Name of the category.</param>
        /// <returns></returns>
        internal static IPrintCategory getPrintCategoryByName(ADitEntities db, string categoryName)
        {
            var result = (from d in db.PrintCategories
                          where d.Description.Equals(categoryName)
                          select new PrintCategoryModel
                          {
                              Description = d.Description,
                              PrintCategoryId = d.PrintCategoryId,
                              IsActive = d.IsActive,
                          }).FirstOrDefault();
            return result;
        }



        /// <summary>
        /// Gets the name of the print service type description by.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="serviceTypeName">Name of the service type.</param>
        /// <returns></returns>
        internal static IPrintServiceType getPrintServiceTypeDescriptionByName(ADitEntities db, string serviceTypeName)
        {
            var result = (from d in db.PrintServiceTypes
                          where d.Description.Equals(serviceTypeName)
                          select new PrintServiceTypeModel
                          {
                              Description = d.Description,
                              IsActive = d.IsActive,
                              PrintServiceTypeId = d.PrintServiceTypeId,
                          }).FirstOrDefault();
            return result;
        }


        internal static IPrintServiceTypePrice getPrintServiceTypePriceByNewsPaperID(ADitEntities db,
            int newspaper, int serviceTypeId, int serviceColorId, int PrintMediaTypeId)
        {
            var result = (from d in db.PrintServiceTypePrices
                          where d.NewsPaperId.Equals(newspaper)
                          where d.PrintServiceColorId.Equals(serviceColorId)
                          where d.PrintServiceTypeId.Equals(serviceTypeId)
                          where d.PrintMediaTypeId.Equals(PrintMediaTypeId)
                          where d.EffectiveDate <= DateTime.UtcNow
                                || d.DateInactive == null
                          where d.IsActive == true
                          select new PrintServiceTypePriceModel
                          {
                              Comment = d.Comment,
                              IsActive = d.IsActive,
                              NewsPaperId = d.NewsPaperId,
                              Amount = d.Amount,
                              DateInactive = d.DateInactive,
                              DateCreated = d.DateCreated,
                              EffectiveDate = d.EffectiveDate,
                              PrintServiceTypeId = d.PrintServiceTypeId,
                              PrintServiceTypePriceId = d.PrintServiceTypePriceId,
                              PrintServiceColorId = d.PrintServiceColorId,
                              PrintMediaTypeId = d.PrintMediaTypeId
                          }).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the print transaction airings.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IPrintTransactionAiring> GetPrintTransactionAirings(ADitEntities db,
            int transactionId)
        {
            var result = (from s in db.PrintTransactionAirings
                          where s.PrintTransactionId.Equals(transactionId)
                          join e in db.NewsPapers on s.NewsPaperId equals e.NewsPaperId

                          // join f in db.ServiceTypes on s.PrintServiceTypePriceId equals f.ServiceTypeCode
                          select new PrintTransactionAiringModel
                          {
                              PrintTransactionId = s.PrintTransactionId,
                              IsActive = s.IsActive,
                              PrintTransactionAiringId = s.PrintTransactionAiringId,
                              Newspaper = e.Description, //Newspaper News
                              NewsPaperId = s.NewsPaperId,
                              PrintServiceId = s.PrintServiceTypePriceId,
                              NumberOfInserts = s.NumberOfInserts,
                              Price = s.Price,
                              StartDate = s.StartDate,
                          }
                ).OrderBy(x => x.PrintTransactionId);
            return result;
        }


        internal static IPrintTransaction GetPrintTransactionById(ADitEntities db, int transactionId)
        {
            var result = (from s in db.PrintTransactions
                          where s.PrintTransactionId.Equals(transactionId)
                          join b in db.ApconApprovalTypes on s.ApconApprovalTypeId equals b.ApconApprovalTypeId into
                              apconTypes
                          from apcon in apconTypes.DefaultIfEmpty()
                          join i in db.PrintCategories on s.PrintCategoryId equals i.PrintCategoryId into printCategories
                          from print in printCategories.DefaultIfEmpty()
                          join u in db.UserRegistrations on s.UserId equals u.UserRegistrationId
                          join d in db.DesignElements on s.DesignElementId equals d.DesignElementId into designElementTypes
                          from element in designElementTypes.DefaultIfEmpty()
                          where s.TransactionStatusCode.Equals("A")
                          select new PrintTransactionModel
                          {
                              Name = u.FirstName,
                              PhoneNumber = u.PhoneNumber,
                              Email = u.Email,
                              DesignElement = element.Description,
                              ApconType = apcon.Description,
                              PrintTransactionId = s.PrintTransactionId,
                              OrderId = s.OrderId,
                              IsHaveMaterial = s.IsHaveMaterial,
                              MaterialDigitalFileId = s.MaterialDigitalFileId,
                              ApconApprovalNumber = s.ApconApprovalNumber,
                              ApconApprovalTypeId = s.ApconApprovalTypeId,
                              ApconApprovalTypePriceId = s.ApconApprovalTypePriceId,
                              ApconApprovalAmount = s.ApconApprovalAmount,
                              PrintCategoryId = s.PrintCategoryId,
                              DesignElementId = s.DesignElementId,
                              DesignElementPriceId = s.DesignElementPriceId,
                              DesignAmount = s.DesignAmount,
                              DurationTypeCode = s.DurationTypeCode,
                              Category = print.Description,
                              DateCreated = s.DateCreated,
                              TransactionStatusCode = s.TransactionStatusCode,
                              OrderTitle = s.OrderTitle,
                              UserId = s.UserId,
                              TotalPrice = s.TotalPrice,
                              // DurationType=m.Description
                          }
                ).SingleOrDefault();
            return result;
        }


        internal static IEnumerable<IPrintTransactionAiringUI> GetPrintTransactionAiringsList(ADitEntities db,
            int transactionId)
        {
            var result = (from s in db.PrintTransactionAirings
                          where s.PrintTransactionId.Equals(transactionId)
                          join e in db.NewsPapers on s.NewsPaperId equals e.NewsPaperId

                          // join f in db.ServiceTypes on s.PrintServiceTypePriceId equals f.ServiceTypeCode
                          select new PrintTransactionAiringUIModel
                          {
                              PrintColorId = s.PrintColorId,
                              PrintTransactionId = s.PrintTransactionId,
                              IsActive = s.IsActive,
                              PrintTransactionAiringId = s.PrintTransactionAiringId,
                              Newspaper = e.Description, //Newspaper News
                              NewsPaperId = s.NewsPaperId,
                              PrintServiceId = s.PrintServiceTypePriceId,
                              NumberOfInserts = s.NumberOfInserts,
                              NewsPaperPrice = s.Price,
                              PrintMediaTypeId = s.PrintMediaTypePriceId,
                              StartDate = s.StartDate,
                          }
                ).OrderBy(x => x.PrintTransactionId);
            return result;
        }

        internal static IEnumerable<IPrintTransactionColor> GetSelectedColorsById(ADitEntities db, int transactionId)
        {
            var result = (from d in db.PrintTransactionColors
                          join s in db.Colors on d.ColorId equals s.ColorId
                          where d.PrintTransactionId.Equals(transactionId)
                          select new PrintTransactionColorModel
                          {
                              PrintTransactionId = d.PrintTransactionId,
                              ColorId = d.ColorId,
                              PrintTransactionColorId = d.PrintTransactionColorId,
                              IsActive = d.IsActive,
                              Colors = s.Description
                          }).OrderBy(x => x.PrintTransactionColorId);

            return result;
        }


        internal static IEnumerable<IPrintServiceColor> GetPrintServiceColors(ADitEntities db)
        {
            var result = (from d in db.PrintServiceColors
                          select new PrintServiceColorModel
                          {
                              PrintServiceTypeColorId = d.PrintServiceTypeColorId,
                              PrintServiceTypeColor = d.PrintServiceTypeColor,
                              IsActive = d.IsActive

                          }).OrderBy(x => x.PrintServiceTypeColorId);

            return result;
        }

        //gets online  Aiiring transaction by Id
        internal static IEnumerable<IPrintTransactionAiring> getPrintTransactionAiringBYId(ADitEntities db,
            int transactionId)
        {
            var result = (from s in db.PrintTransactionAirings
                          where s.PrintTransactionId.Equals(transactionId)
                          join e in db.NewsPapers on s.NewsPaperId equals e.NewsPaperId
                          join d in db.PrintServiceTypes on s.PrintServiceTypePriceId equals d.PrintServiceTypeId
                          join p in db.PrintMediaTypes on s.PrintMediaTypePriceId equals p.Id
                          select new PrintTransactionAiringModel
                          {
                              PrintTransactionAiringId = s.PrintTransactionAiringId,
                              IsActive = s.IsActive,
                              Newspaper = e.Description,
                              NumberOfInserts = s.NumberOfInserts,
                              PrintServiceType = d.Description,

                              PrintMediaType = p.Description,
                              Price = s.Price
                          }
                ).OrderBy(x => x.PrintTransactionAiringId);
            return result;
        }

        /// <summary>
        /// Gets the name of the print service color description by.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="PrintServiceTypeColor">Color of the print service type.</param>
        /// <returns></returns>
        internal static IPrintServiceColor GetPrintServiceColorDescriptionByName(ADitEntities db, string PrintServiceTypeColor)
        {
            var result = (from s in db.PrintServiceColors
                          where s.PrintServiceTypeColor.Equals(PrintServiceTypeColor)
                          select new PrintServiceColorModel
                          {
                              PrintServiceTypeColorId = s.PrintServiceTypeColorId,
                              PrintServiceTypeColor = s.PrintServiceTypeColor,
                              IsActive = s.IsActive,
                          }
                ).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the print service color list.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IPrintServiceColor> GetPrintServiceColorList(ADitEntities db)
        {
            var result = (from s in db.PrintServiceColors
                          select new PrintServiceColorModel
                          {
                              PrintServiceTypeColorId = s.PrintServiceTypeColorId,
                              PrintServiceTypeColor = s.PrintServiceTypeColor,
                              IsActive = s.IsActive,
                          }).OrderBy(x => x.PrintServiceTypeColor);


            return result;
        }

        /// <summary>
        /// Gets the print servie color by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="printServiceTypeColorId">The print service type color identifier.</param>
        /// <returns></returns>
        internal static IPrintServiceColor GetPrintServieColorById(ADitEntities db, int printServiceTypeColorId)
        {
            var result = (from d in db.PrintServiceColors
                          where d.PrintServiceTypeColorId.Equals(printServiceTypeColorId)
                          select new PrintServiceColorModel
                          {
                              PrintServiceTypeColorId = printServiceTypeColorId,
                              PrintServiceTypeColor = d.PrintServiceTypeColor,
                              IsActive = d.IsActive
                          }).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the art work prices.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IOnlineArtworkPrice> GetArtWorkPrices(ADitEntities db)
        {
            var result = (from d in db.ArtWorkPrices
                          select new ArtworkPriceModel
                          {
                              ArtWorkPriceId = d.ArtWorkPriceId,
                              ServiceTypeCode = d.ServiceTypeCode,
                              Amount = d.Amount,
                              Comment = d.Comment,
                              EffectiveDate = d.EffectiveDate,
                              DateInactive = d.DateInactive,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated

                          }).OrderBy(x => x.ArtWorkPriceId);

            return result;
        }

        /// <summary>
        /// Gets the name of the art work price description by.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="ServiceTypeCode">The service type code.</param>
        /// <returns></returns>
        internal static IOnlineArtworkPrice GetArtWorkPriceDescriptionByName(ADitEntities db, string ServiceTypeCode)
        {
            var result = (from s in db.ArtWorkPrices
                          where s.ServiceTypeCode.Equals(ServiceTypeCode)
                          select new ArtworkPriceModel
                          {
                              ArtWorkPriceId = s.ArtWorkPriceId,
                              ServiceTypeCode = s.ServiceTypeCode,
                              Amount = s.Amount,
                              Comment = s.Comment,
                              EffectiveDate = s.EffectiveDate,
                              DateInactive = s.DateInactive,
                              IsActive = s.IsActive,
                              DateCreated = s.DateCreated
                          }
                ).FirstOrDefault();
            return result;

        }

        /// <summary>
        /// Gets the art work price by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="ArtWorkPriceId">The art work price identifier.</param>
        /// <returns></returns>
        internal static IOnlineArtworkPrice GetArtWorkPriceById(ADitEntities db, int ArtWorkPriceId)
        {
            var result = (from d in db.ArtWorkPrices
                          where d.ArtWorkPriceId.Equals(ArtWorkPriceId)
                          select new ArtworkPriceModel
                          {
                              ArtWorkPriceId = ArtWorkPriceId,
                              ServiceTypeCode = d.ServiceTypeCode,
                              Amount = d.Amount,
                              Comment = d.Comment,
                              EffectiveDate = d.EffectiveDate,
                              DateInactive = d.DateInactive,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated
                          }).FirstOrDefault();
            return result;
        }
    }
}