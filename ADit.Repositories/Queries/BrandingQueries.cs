using ADit.Interfaces;
using ADit.Repositories.DataAccess;
using ADit.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADit.Repositories.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class BrandingQueries
    {
        /// <summary>
        /// Gets the branding material.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IBrandingMaterial> GetBrandingMaterial(ADitEntities db)
        {
            var result = (from s in db.BrandingMaterials
                    select new BrandingMaterialModel
                    {
                        BrandingMaterialId = s.BrandingMaterialId,
                        Description = s.Description,
                        IsActive = s.IsActive
                    }
                ).OrderBy(x => x.Description);
            return result;
        }

        /// <summary>
        /// Gets the name of the branding material by.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="materialName">Name of the material.</param>
        /// <returns></returns>
        internal static IBrandingMaterial GetBrandingMaterialByName(ADitEntities db, string materialName)
        {
            var result = (from s in db.BrandingMaterials
                    where s.Description.Equals(materialName)
                    select new BrandingMaterialModel
                    {
                        BrandingMaterialId = s.BrandingMaterialId,
                        Description = s.Description,
                        IsActive = s.IsActive
                    }
                ).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the branding material price.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IBrandingMaterialPrice> GetBrandingMaterialPrice(ADitEntities db)
        {
            var result = (from d in db.BrandingMaterialPrices
                join e in db.BrandingMaterials on d.BrandingMaterialId equals e.BrandingMaterialId
                where d.EffectiveDate <= DateTime.UtcNow
                where d.DateInactive >= DateTime.UtcNow || d.DateInactive==null
                where d.IsActive == true
                where e.IsActive == true
                select new Models.BrandingMaterialPriceModel
                {
                    BrandingMaterialPriceId = d.BrandingMaterialPriceId,
                    Amount = d.Amount,
                    Description = e.Description,
                    IsActive = d.IsActive,
                    DateCreated = d.DateCreated,
                    EffectiveDate = d.EffectiveDate,
                    DateInactive = d.DateInactive,
                    BrandingMaterialId = d.BrandingMaterialId,
                    Comment = d.Comment
                }).OrderBy(x => x.Amount);
            return result;
        }

        /// <summary>
        /// Gets the branding materialr by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IBrandingMaterial GetBrandingMaterialrById(ADitEntities db, int Id)
        {
            var result = (from d in db.BrandingMaterials
                    where d.BrandingMaterialId.Equals(Id)
                    select new BrandingMaterialModel
                    {
                        BrandingMaterialId = d.BrandingMaterialId,
                        Description = d.Description,
                        IsActive = d.IsActive
                    }
                ).SingleOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the material price.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IBrandingMaterialPrice> getMaterialPrice(ADitEntities db)
        {
            var result = (from d in db.BrandingMaterialPrices
                join e in db.BrandingMaterials on d.BrandingMaterialId equals e.BrandingMaterialId
                select new Models.BrandingMaterialPriceModel
                {
                    BrandingMaterialPriceId = d.BrandingMaterialPriceId,
                    Description = e.Description,
                    Amount = d.Amount,
                    IsActive = d.IsActive,
                    DateCreated = d.DateCreated,
                    EffectiveDate = d.EffectiveDate,
                    DateInactive = d.DateInactive,
                    BrandingMaterialId = d.BrandingMaterialId,
                    Comment = d.Comment
                }).OrderBy(x => x.Amount);
            return result;
        }


        /// <summary>
        /// Gets the material price by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IBrandingMaterialPrice getMaterialPriceById(ADitEntities db, int Id)
        {
            var result = (from d in db.BrandingMaterialPrices
                where d.BrandingMaterialPriceId.Equals(Id)
                select new Models.BrandingMaterialPriceModel
                {
                    BrandingMaterialPriceId = d.BrandingMaterialPriceId,
                    Amount = d.Amount,
                    IsActive = d.IsActive,
                    DateCreated = d.DateCreated,
                    EffectiveDate = d.EffectiveDate,
                    DateInactive = d.DateInactive,
                    BrandingMaterialId = d.BrandingMaterialId,
                    Comment = d.Comment
                }).SingleOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the active branding transaction.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="ordeId">The orde identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IBrandingTransaction> GetActiveBrandingTransaction(ADitEntities db, int ordeId)
        {
            var result = (from d in db.BrandingTransactions
                where d.TransactionStatusCode == "A"
                where d.OrderId == ordeId
               join s in db.BrandingTransactionAttachments on d.BrandingTransactionId equals s.BrandingTransactionId
                join f in db.BrandingTransactionDesignElements on d.BrandingTransactionId equals f.BrandingTransactionId
                join g in db.BrandingTransactionMaterials on d.BrandingTransactionId equals g.BrandingTransactionId
                select new BrandingTransactionModel
                {
                    OrderTitle = d.OrderTitle,
                    AdditionalInformation = d.AdditionalInformation,
                    BrandingTransactionId = d.BrandingTransactionId,
                    DateCreated = d.DateCreated,
                    DateModified = d.DateModified,
                    OrderId = d.OrderId,
                    OtherColor = d.OtherColor,
                    TransactionStatusCode = d.TransactionStatusCode,
                    UserId = d.UserId,
                    BrandingMaterialAmount = g.BrandingMaterialAmount,
                    DesignElementAmount = f.DesignElementAmount,
                    BrandingFileId=s.DigitalFileId
                }).OrderBy(x => x.BrandingTransactionId);
            return result;
        }

        /// <summary>
        /// Gets the material price amount by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IBrandingMaterialPrice getMaterialPriceAmountById(ADitEntities db, int Id)
        {
            var result = (from d in db.BrandingMaterialPrices
                join e in db.BrandingMaterials on d.BrandingMaterialId equals e.BrandingMaterialId
                where e.BrandingMaterialId.Equals(Id)
                select new BrandingMaterialPriceModel
                {
                    BrandingMaterialPriceId = d.BrandingMaterialPriceId,
                    Amount = d.Amount,
                  
                    IsActive = d.IsActive,
                    DateCreated = d.DateCreated,
                    EffectiveDate = d.EffectiveDate,
                    DateInactive = d.DateInactive,
                    BrandingMaterialId = d.BrandingMaterialId,
                    Comment = d.Comment
                }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the branding transaction detail.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static IBrandingTransaction GetBrandingTransactionDetail(ADitEntities db, int transactionId
           )
        {
            var result = (from d in db.BrandingTransactions
                join e in db.BrandingTransactionAttachments on d.BrandingTransactionId equals e.BrandingTransactionId
                join r in db.UserRegistrations on d.UserId equals r.UserRegistrationId
                join f in db.BrandingTransactionColors on d.BrandingTransactionId equals f.BrandingTransactionId 
                join g in db.BrandingTransactionDesignElements on d.BrandingTransactionId equals g.BrandingTransactionId into designElement
                from design in designElement.DefaultIfEmpty()
                join h in db.BrandingTransactionMaterials on d.BrandingTransactionId equals h.BrandingTransactionId into brandMaterial
                from brandingMaterial in brandMaterial.DefaultIfEmpty()
                where d.BrandingTransactionId.Equals(transactionId)
                
                select new BrandingTransactionModel
                {
                    UserName=r.FirstName,
                    Email=r.Email,
                    PhoneNumber=r.PhoneNumber,
                    TotalAmount=d.TotalAmount,
                    BrandingTransactionId = d.BrandingTransactionId,
                    AdditionalInformation = d.AdditionalInformation,
                    DateCreated = d.DateCreated,
                    OrderId = d.OrderId,
                    OrderTitle = d.OrderTitle,
                    OtherColor = d.OtherColor,
                    UserId = d.UserId,
                    DesignElementAmount = design.DesignElementAmount,
                    BrandingMaterialAmount = brandingMaterial.BrandingMaterialAmount,
                    BrandingMaterialId = brandingMaterial.BrandingMaterialId,
                    DesignElementId = design.DesignElementId,
                    ColorId = f.ColorId,
                    BrandingFileId=e.DigitalFileId,
                    
                }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the branding transactions.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IBrandingTransaction> GetBrandingTransactions(ADitEntities db)
        {
            var result = (from d in db.BrandingTransactions
                join e in db.BrandingTransactionAttachments on d.BrandingTransactionId equals e.BrandingTransactionId
                select new BrandingTransactionModel
                {
                    BrandingTransactionId = d.BrandingTransactionId,
                    AdditionalInformation = d.AdditionalInformation,
                    DateCreated = d.DateCreated,
                    OrderId = d.OrderId,
                    OrderTitle = d.OrderTitle,
                    SentToId = d.UserId,
                    BrandingFileId = e.BrandingTransactionAttachmentId,
                }).OrderBy(x => x.BrandingTransactionId);

            return result;
        }


        /// <summary>
        /// Gets the branding transaction attachment transaction by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IBrandingAttachmentTransaction> GetBrandingTransactionAttachmentTransactionById(
            ADitEntities db, int UserId, int transactionId)

        {
            
            var result = new List<BrandingAttachmentTransactionModel>();
            return result;
        }



        /// <summary>
        /// Gets the branding transaction by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        internal static IBrandingTransaction GetBrandingTransactionById(ADitEntities db, int SentToId,
            int transactionId)

        {
            var result = (from d in db.BrandingTransactions
                    join c in db.BrandingTransactionAttachments on d.BrandingTransactionId equals c
                        .BrandingTransactionId
                    join b in db.UserRegistrations on d.UserId equals b.UserRegistrationId
                    where d.UserId == SentToId
                    where d.BrandingTransactionId == transactionId
                    select new BrandingTransactionModel
                    {
                        BrandingTransactionId = d.BrandingTransactionId,
                        OrderTitle = d.OrderTitle,
                        UserName = b.FirstName,
                        BrandingFileId = c.DigitalFileId,
                        SentToId = d.UserId,
                        AdditionalInformation=d.AdditionalInformation,
                        OrderId=d.OrderId,
                        
                    }
                ).SingleOrDefault();

            return result;
        }


        /// <summary>
        /// Gets the selected colors.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IBrandingTransactionColor> GetSelectedColors(ADitEntities db, int transactionId)
        { 
            var result = (from d in db.BrandingTransactionColors
                          join s in db.Colors on d.ColorId equals s.ColorId
                where d.BrandingTransactionId.Equals(transactionId)
                select new BrandingTransactionColorModel
                {
                    BrandingTransactionId = d.BrandingTransactionId,
                    ColorId = d.ColorId,
                    BrandingTransactionColorId = d.BrandingTransactionColorId,
                    IsActive = d.IsActive,
                    Color=s.Description
                }).OrderBy(x => x.BrandingTransactionId);

            return result;
        }

        /// <summary>
        /// Gets the selected color by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        internal static IBrandingTransactionColor GetSelectedColorById(ADitEntities db, int transactionId)
        {
            var result = (from d in db.BrandingTransactionColors
                          join b in db.Colors on d.ColorId equals b.ColorId
                          where d.BrandingTransactionId.Equals(transactionId)
                          
                          select new BrandingTransactionColorModel
                          {
                              Color=b.Description,
                              BrandingTransactionId = d.BrandingTransactionId,
                              ColorId = d.ColorId,
                              BrandingTransactionColorId = d.BrandingTransactionColorId,
                              IsActive = d.IsActive,
                          }).FirstOrDefault();

            return result;
        }









        /// <summary>
        /// Gets the branding transaction attachment by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        internal static IBrandingTransactionAttachment GetBrandingTransactionAttachmentById(ADitEntities db, int transactionId)
        {
            var result = (from d in db.BrandingTransactionAttachments
                          where d.BrandingTransactionId.Equals(transactionId)
                          select new BrandingTransactionAttachmentModel
                          {
                              BrandingTransactionId = d.BrandingTransactionId,
                             BrandingTransactionAttachmentId=d.BrandingTransactionAttachmentId,
                             DigitalFileId=d.DigitalFileId,
                              IsActive = d.IsActive,
                          }).FirstOrDefault();

            return result;
        }





        /// <summary>
        /// Gets the branding transaction design elements by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        internal static IBrandingTransactionDesignElement GetBrandingTransactionDesignElementsById(ADitEntities db, int transactionId)
        {
            var result = (from d in db.BrandingTransactionDesignElements
                          where d.BrandingTransactionId.Equals(transactionId)
                          join c in db.DesignElements on d.DesignElementId equals c.DesignElementId
                          select new BrandingTransactionDesignElementModel
                          {
                              DesignElement=c.Description,
                              BrandingTransactionId = d.BrandingTransactionId,
                            BrandingTransactionDesignElementId=d.BrandingTransactionDesignElementId,
                            DesignElementAmount=d.DesignElementAmount,
                            DesignElementId=d.DesignElementId,
                              IsActive = d.IsActive,
                          }).SingleOrDefault();

            return result;
        }



        /// <summary>
        /// Gets the branding transaction material by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        internal static IBrandingTransactionMaterial GetBrandingTransactionMaterialById(ADitEntities db, int transactionId)
        {
            var result = (from d in db.BrandingTransactionMaterials
                          where d.BrandingTransactionId.Equals(transactionId)
                          join b in db.BrandingMaterials on d.BrandingMaterialId equals b.BrandingMaterialId
                          select new BrandingTransactionMaterialModel
                          {
                              BrandingMaterialId = d.BrandingMaterialId,
                              BrandingMaterialAmount = d.BrandingMaterialAmount,
                              BrandingMaterialPriceId = d.BrandingMaterialPriceId,
                              BrandingTransactionMaterialId = d.BrandingTransactionMaterialId,
                              BrandingTransactionId = d.BrandingTransactionId,
                              BrandingMaterial = b.Description,
                              IsActive = d.IsActive,
                          }).SingleOrDefault();

            return result;
        }

    }
}