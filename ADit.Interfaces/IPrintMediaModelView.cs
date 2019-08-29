using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IPrintTransactionUI" />
    public interface IPrintMediaModelView : IPrintTransactionUI
    {
        /// <summary>
        /// Gets or sets the current status description.
        /// </summary>
        /// <value>
        /// The current status description.
        /// </value>
        string CurrentStatusDescription { get; set; }
        /// <summary>
        /// Gets or sets the print media type identifier.
        /// </summary>
        /// <value>
        /// The print media type identifier.
        /// </value>
        int PrintMediaTypeId { get; set; }

        /// <value>
        /// The status code list.
        /// </value>
        IList<SelectListItem> PrintMediaTypeList { get; set; }
        /// <summary>
        /// Gets or sets the print media list.
        /// </summary>
        /// <value>
        /// The print media list.
        /// </value>
        IList<string> PrintMediaList { get; set; }
        /// <summary>
        /// Gets the print media type DDL.
        /// </summary>
        /// <param name="PrintMediaTypeId">The print media type identifier.</param>
        /// <returns></returns>
        IList<SelectListItem> GetPrintMediaTypeDDL(int PrintMediaTypeId);
        /// <summary>
        /// Gets or sets the order fulfilment identifier.
        /// </summary>
        /// <value>
        /// The order fulfilment identifier.
        /// </value>
        int OrderFulfilmentId { get; set; }
        /// <summary>
        /// Gets or sets the cuurent status code.
        /// </summary>
        /// <value>
        /// The cuurent status code.
        /// </value>
        string CurrentStatusCode { get; set; }
        /// <summary>
        /// Gets or sets the status code list.
        /// </summary>
        /// <value>
        /// The status code list.
        /// </value>
        IList<SelectListItem> StatusCodeList { get; set; }
        /// <summary>
        /// Gets or sets the message identifier.
        /// </summary>
        /// <value>
        /// The message identifier.
        /// </value>
        int MessageId { get; set; }
        /// <summary>
        /// Gets or sets the replies identifier.
        /// </summary>
        /// <value>
        /// The replies identifier.
        /// </value>
        int RepliesId { get; set; }
        
        /// <summary>
        /// Gets or sets the replies list.
        /// </summary>
        /// <value>
        /// The replies list.
        /// </value>
        IList<IReplies> RepliesList { get; set; }
        /// <summary>
        /// Gets or sets the messages list.
        /// </summary>
        /// <value>
        /// The messages list.
        /// </value>
        IList<IMessage> MessagesList { get; set; }

        /// <summary>
        /// Gets the print service color DDL.
        /// </summary>
        /// <param name="PrintServiceColorId">The print service color identifier.</param>
        /// <returns></returns>
        IList<SelectListItem> GetPrintServiceColorDDL(int PrintServiceColorId);
        /// <summary>
        /// Gets or sets the service color d dl.
        /// </summary>
        /// <value>
        /// The service color d dl.
        /// </value>
        IList<SelectListItem> ServiceColorDDl { get; set; }
        /// <summary>
        /// Gets or sets the print service colors.
        /// </summary>
        /// <value>
        /// The print service colors.
        /// </value>
        IList<IPrintServiceColor> printServiceColors { get; set; }
        /// <summary>
        /// Gets or sets the service color description.
        /// </summary>
        /// <value>
        /// The service color description.
        /// </value>
        string ServiceColorDescription { get; set; }

        /// <summary>
        /// Gets or sets the print service color identifier.
        /// </summary>
        /// <value>
        /// The print service color identifier.
        /// </value>
        int PrintServiceColorId { get; set; }
        /// <summary>
        /// Gets or sets the print file description.
        /// </summary>
        /// <value>
        /// The print file description.
        /// </value>
        string PrintFileDescription { get; set; }
        /// <summary>
        /// Gets or sets the print service types.
        /// </summary>
        /// <value>
        /// The print service types.
        /// </value>
        IList<IPrintServiceType> printServiceTypes { get; set; }

        /// <summary>
        /// Gets or sets the airing details list.
        /// </summary>
        /// <value>
        /// The airing details list.
        /// </value>
        IList<IPrintTransactionAiringUI> AiringDetailsList { get; set; }
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        string PhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string PrintServiceTypes { get; set; }
        /// <summary>
        /// Gets or sets the newspapers list.
        /// </summary>
        /// <value>
        /// The newspapers list.
        /// </value>
        List<string> NewspapersList { get; set; }
        /// <summary>
        /// Gets or sets the print servcice type list.
        /// </summary>
        /// <value>
        /// The print servcice type list.
        /// </value>
        List<string> PrintServciceTypeList { get; set; }
        /// <summary>
        /// Gets or sets the nummber of insert list.
        /// </summary>
        /// <value>
        /// The nummber of insert list.
        /// </value>
        List<int> NummberOfInsertList { get; set; }
        /// <summary>
        /// Gets or sets the prices list.
        /// </summary>
        /// <value>
        /// The prices list.
        /// </value>
        List<decimal> PricesList { get; set; }
        /// <summary>
        /// Gets or sets the duration types.
        /// </summary>
        /// <value>
        /// The duration types.
        /// </value>
        string DurationTypes { get; set; }
        /// <summary>
        /// Gets or sets the design element.
        /// </summary>
        /// <value>
        /// The design element.
        /// </value>
        string DesignElement { get; set; }
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        string Category { get; set; }
        /// <summary>
        /// Gets or sets the type of the apcon.
        /// </summary>
        /// <value>
        /// The type of the apcon.
        /// </value>
        string ApconType { get; set; }
        /// <summary>
        /// Gets or sets the print transaction identifier.
        /// </summary>
        /// <value>
        /// The print transaction identifier.
        /// </value>
        int PrintTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the artwork identifier.
        /// </summary>
        /// <value>
        /// The artwork identifier.
        /// </value>
        int ArtworkId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is have material.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is have material; otherwise, <c>false</c>.
        /// </value>
        bool IsHaveMaterial { get; set; }
       
        /// Gets or sets the duration quantity.
        /// </summary>
        /// <value>
        /// The duration quantity.
        /// </value>
        int DurationQuantity { get; set; }
        /// <summary>
        /// Gets or sets the artwork description.
        /// </summary>
        /// <value>
        /// The artwork description.
        /// </value>
        IList<SelectListItem> ArtworkDescription { get; set; }
        /// <summary>
        /// Gets or sets the apcon approval price collection.
        /// </summary>
        /// <value>
        /// The apcon approval price collection.
        /// </value>
        IList<IApconApprovalTypePrice> ApconApprovalPriceCollection { get; set; }
        /// <summary>
        /// Gets or sets the apcon approval type identifier.
        /// </summary>
        /// <value>
        /// The apcon approval type identifier.
        /// </value>
        int ApconApprovalTypeId { get; set; }
        /// <summary>
        /// Gets or sets the apcon approval collection list.
        /// </summary>
        /// <value>
        /// The apcon approval collection list.
        /// </value>
        IList<SelectListItem> ApconApprovalCollectionList { get; set; }
        
        /// <summary>
        /// Gets or sets the apcon approval identifier.
        /// </summary>
        /// <value>
        /// The apcon approval identifier.
        /// </value>
        Nullable<int> ApconApprovalId { get; set; }
       
       
       
        /// <summary>
        /// Gets or sets the orde identifier.
        /// </summary>
        /// <value>
        /// The orde identifier.
        /// </value>
        int OrdeId { get; set; }
        /// <summary>
        /// Gets or sets the design element price collection.
        /// </summary>
        /// <value>
        /// The design element price collection.
        /// </value>
        IList<IDesignElementPrice> DesignElementPriceCollection { get; set; }
        /// <summary>
        /// Gets or sets the type of the design element.
        /// </summary>
        /// <value>
        /// The type of the design element.
        /// </value>
        IList<SelectListItem> DesignElementType { get; set; }
        /// <summary>
        /// Gets or sets the design element amount.
        /// </summary>
        /// <value>
        /// The design element amount.
        /// </value>
        decimal DesignElementAmount { get; set; }
       
        /// <summary>
        /// Gets or sets the print category description.
        /// </summary>
        /// <value>
        /// The print category description.
        /// </value>
        string PrintCategoryDescription { get; set; }
        /// <summary>
        /// Gets or sets the type of the print category.
        /// </summary>
        /// <value>
        /// The type of the print category.
        /// </value>
        IList<SelectListItem> PrintCategoryType { get; set; }
        /// <summary>
        /// Gets or sets the color identifier.
        /// </summary>
        /// <value>
        /// The color identifier.
        /// </value>
        int ColorId { get; set; }
       
        /// <summary>
        /// Gets or sets the type of the color.
        /// </summary>
        /// <value>
        /// The type of the color.
        /// </value>
        IList<SelectListItem> ColorType { get; set; }
        /// <summary>
        /// Gets or sets the newspaper description.
        /// </summary>
        /// <value>
        /// The newspaper description.
        /// </value>
        string NewspaperDescription { get; set; }
        /// <summary>
        /// Gets or sets the type of the newspaper.
        /// </summary>
        /// <value>
        /// The type of the newspaper.
        /// </value>
        IList<SelectListItem> NewspaperType { get; set; }
        /// <summary>
        /// Gets or sets the print service code.
        /// </summary>
        /// <value>
        /// The print service code.
        /// </value>
        string PrintServiceCode { get; set; }
        /// <summary>
        /// Gets or sets the print service description.
        /// </summary>
        /// <value>
        /// The print service description.
        /// </value>
        string PrintServiceDescription { get; set; }
        /// <summary>
        /// Gets or sets the type of the print service.
        /// </summary>
        /// <value>
        /// The type of the print service.
        /// </value>
        IList<SelectListItem> PrintServiceType { get; set; }
        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        string Duration { get; set; }
        /// <summary>
        /// Gets or sets the type of the duration.
        /// </summary>
        /// <value>
        /// The type of the duration.
        /// </value>
        IList<SelectListItem> DurationType { get; set; }
        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        string Comment { get; set; }/// <summary>
        /// 
        /// </summary>
        decimal TotalAmount { get; set; }
        /// <summary>
        /// Gets or sets the effective date.
        /// </summary>
        /// <value>
        /// The effective date.
        /// </value>
        System.DateTime EffectiveDate { get; set; }
        /// <summary>
        /// Gets or sets the date inactive.
        /// </summary>
        /// <value>
        /// The date inactive.
        /// </value>
        Nullable<System.DateTime> DateInactive { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        System.DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the material digital file identifier.
        /// </summary>
        /// <value>
        /// The material digital file identifier.
        /// </value>
        Nullable<int> MaterialDigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets the material digital file.
        /// </summary>
        /// <value>
        /// The material digital file.
        /// </value>
        byte[] MaterialDigitalFile { get; set; }
        /// <summary>
        /// Gets or sets the name of the material digital file.
        /// </summary>
        /// <value>
        /// The name of the material digital file.
       

        string MaterialDigitalFileName { get; set; }
        /// <summary>
        /// Gets or sets the type of the material digital file.
        /// </summary>
        /// <value>
        /// The type of the material digital file.
        /// </value>
        string MaterialDigitalFileType { get; set; }
        /// <summary>
        /// Gets or sets the material digital file extension.
        /// </summary>
        /// <value>
        /// The material digital file extension.
        /// </value>
        string MaterialDigitalFileExtension { get; set; }
        /// <summary>
        /// Gets or sets the digital file.
        /// </summary>
        /// <value>
        /// The digital file.
        /// </value>
        string DigitalFile { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int UserId { get; set; }

        /// <summary>
        /// Gets or sets the news paper list.
        /// </summary>
        /// <value>
        /// The news paper list.
        /// </value>
        IList<INewsPaper> NewsPaperList { get; set; }
        /// <summary>
        /// Gets or sets the print collection.
        /// </summary>
        /// <value>
        /// The print collection.
        /// </value>
        IList<IPrintTransactionAiring> PrintCollection { get; set; }


        /// <summary>
        /// Gets or sets the print transaction airing.
        /// </summary>
        /// <value>
        /// The print transaction airing.
        /// </value>
        IPrintTransactionAiringModel PrintTransactionAiring { get; set; }

        /// <summary>
        /// Gets or sets the new paper selection list.
        /// </summary>
        /// <value>
        /// The new paper selection list.
        /// </value>
        List<Dictionary<string, string>> NewPaperSelectionList { get; set; }
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        DateTime[] StartDate { get; set; }
        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        DateTime[] EndDate { get; set; }/// <summary>
        /// 
        /// </summary>
        List<DateTime> StartDateList { get; set; }
        // <summary>
        /// Gets the tv station description.
        /// </summary>
        /// <param name="radioStationId">The radio station identifier.</param>
        /// <returns></returns>
        string GetNewsPaperDescription(int radioStationId);
        /// <summary>
        /// Gets the print service type DDL.
        /// </summary>
        /// <param name="PrintServiceTypeId">The print service type identifier.</param>
        /// <returns></returns>
        IList<SelectListItem> GetPrintServiceTypeDDL(int PrintServiceTypeId);

    }
}