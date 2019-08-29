using AA.Infrastructure.Extensions;
using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;

namespace ADit.Domain.Models
{
    public class PrintMediaModelView : IPrintMediaModelView
    {
        public PrintMediaModelView()
        {
            this.ProcessingMessage = string.Empty;

            this.ApconApprovalCollectionList = new List<SelectListItem>();
            this.DesignElementType = new List<SelectListItem>();
            this.PrintCategoryType = new List<SelectListItem>();
            this.NewspaperType = new List<SelectListItem>();
            this.PrintServiceType = new List<SelectListItem>();
            this.ServiceColorDDl = new List<SelectListItem>();
            this.DurationType = new List<SelectListItem>();
            this.NewsPaperList = new List<INewsPaper>();
            this.AiringDetailsList = new List<IPrintTransactionAiringUI>();

            this.printServiceTypes = new List<IPrintServiceType>();
        }
        /// <summary>
        /// Gets or sets the order fulfilment identifier.
        /// </summary>
        /// <value>
        /// The order fulfilment identifier.
        /// </value>
        public int OrderFulfilmentId { get; set; }
        /// <summary>
        /// Gets or sets the cuurent status code.
        /// </summary>
        /// <value>
        /// The cuurent status code.
        /// </value>
        public string CurrentStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the current status description.
        /// </summary>
        /// <value>
        /// The current status description.
        /// </value>
        public string CurrentStatusDescription { get; set; }
        /// <value>
        /// The status code list.
        /// </value>
        public IList<SelectListItem> StatusCodeList { get; set; }
        /// <summary>
        /// Gets or sets the print media types list.
        /// </summary>
        /// <value>
        /// The print media types list.
        /// </value>
       public IList<string> PrintMediaList { get; set; }
        /// <value>
        /// The status code list.
        /// </value>
        public IList<SelectListItem> PrintMediaTypeList { get; set; }

        /// <summary>
        /// Gets or sets the replies identifier.
        /// </summary>
        /// <value>
        /// The replies identifier.
        /// </value>
        public int RepliesId { get; set; }
        /// <summary>
        /// Gets or sets the message identifier.
        /// </summary>
        /// <value>
        /// The message identifier.
        /// </value>
        public int MessageId { get; set; }
        /// <summary>
        /// Gets or sets the replies list.
        /// </summary>
        /// <value>
        /// The replies list.
        /// </value>
        public IList<IReplies> RepliesList { get; set; }
        /// <summary>
        /// Gets or sets the messages list.
        /// </summary>
        /// <value>
        /// The messages list.
        /// </value>
        public IList<IMessage> MessagesList { get; set; }
        /// <summary>
        /// Gets or sets the print file description.
        /// </summary>
        /// <value>
        /// The print file description.
        /// </value>
        public string PrintFileDescription { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public int OrderId { get; set; }
        /// <summary>
        /// Gets or sets the airing details list.
        /// </summary>
        /// <value>
        /// The airing details list.
        /// </value>
        public IList<IPrintTransactionAiringUI> AiringDetailsList { get; set; }
        /// <summary>
        /// Gets or sets the print service colors.
        /// </summary>
        /// <value>
        /// The print service colors.
        /// </value>
        public IList<IPrintServiceColor> printServiceColors { get; set; }
        /// <summary>
        /// Gets or sets the print service types.
        /// </summary>
        /// <value>
        /// The print service types.
        /// </value>
        public IList<IPrintServiceType> printServiceTypes { get; set; }

        /// <summary>
        /// Gets or sets the selected tv station ids.
        /// </summary>
        /// <value>
        /// The selected tv station ids.
        /// </value>
        public List<int> SelectedTvStationIds { get; set; }
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the service color description.
        /// </summary>
        /// <value>
        /// The service color description.
        /// </value>
        public string ServiceColorDescription { get; set; }

        /// <summary>
        /// Gets or sets the print service color identifier.
        /// </summary>
        /// <value>
        /// The print service color identifier.
        /// </value>
        public int PrintServiceColorId { get; set; }

        /// <summary>
        /// Gets or sets the print media type identifier.
        /// </summary>
        /// <value>
        /// The print media type identifier.
        /// </value>
        public int PrintMediaTypeId { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the print service types.
        /// </summary>
        /// <value>
        /// The print service types.
        /// </value>
        public string PrintServiceTypes { get; set; }
        /// <summary>
        /// Gets or sets the duration types.
        /// </summary>
        /// <value>
        /// The duration types.
        /// </value>
        public string DurationTypes { get; set; }
        /// <summary>
        /// Gets or sets the design element.
        /// </summary>
        /// <value>
        /// The design element.
        /// </value>
        public string DesignElement { get; set; }
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public string Category { get; set; }
        /// <summary>
        /// Gets or sets the type of the apcon.
        /// </summary>
        /// <value>
        /// The type of the apcon.
        /// </value>
        public string ApconType { get; set; }
        /// <summary>
        /// Gets or sets the newspapers list.
        /// </summary>
        /// <value>
        /// The newspapers list.
        /// </value>
        public List<string> NewspapersList { get; set; }
        /// <summary>
        /// Gets or sets the print servcice type list.
        /// </summary>
        /// <value>
        /// The print servcice type list.
        /// </value>
        public List<string> PrintServciceTypeList { get; set; }
        /// <summary>
        /// Gets or sets the nummber of insert list.
        /// </summary>
        /// <value>
        /// The nummber of insert list.
        /// </value>
        public List<int> NummberOfInsertList { get; set; }
        /// <summary>
        /// Gets or sets the prices list.
        /// </summary>
        /// <value>
        /// The prices list.
        /// </value>
        public List<decimal> PricesList { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; set; }
        /// <summary>
        /// Gets or sets the number of inserts.
        /// </summary>
        /// <value>
        /// The number of inserts.
        /// </value>
        public int NumberOfInserts { get; set; }
        /// <summary>
        /// Gets or sets the print transaction identifier.
        /// </summary>
        /// <value>
        /// The print transaction identifier.
        /// </value>
        public int PrintTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the artwork identifier.
        /// </summary>
        /// <value>
        /// The artwork identifier.
        /// </value>
        public int ArtworkId { get; set; }
        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        [Required(ErrorMessage = "Order Title is required")]
        public string OrderTitle { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is have material.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is have material; otherwise, <c>false</c>.
        /// </value>
        public bool IsHaveMaterial { get; set; }
        public bool isHaveMaterial { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Gets or sets the artwork description.
        /// </summary>
        /// <value>
        /// The artwork description.
        /// </value>
        public IList<SelectListItem> ArtworkDescription { get; set; }
        /// <summary>
        /// Gets or sets the apcon approval price collection.
        /// </summary>
        /// <value>
        /// The apcon approval price collection.
        /// </value>
        public IList<IApconApprovalTypePrice> ApconApprovalPriceCollection { get; set; }
        /// <summary>
        /// Gets or sets the apcon approval collection list.
        /// </summary>
        /// <value>
        /// The apcon approval collection list.
        /// </value>
        public IList<SelectListItem> ApconApprovalCollectionList { get; set; }
        /// <summary>
        /// Gets or sets the apcon approval type identifier.
        /// </summary>
        /// <value>
        /// The apcon approval type identifier.
        /// </value>
        public int ApconApprovalTypeId { get; set; }/// <summary>
                                                    /// 
                                                    /// </summary>
        public Nullable<int> ApconApprovalTypePriceId { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval identifier.
        /// </summary>
        /// <value>
        /// The apcon approval identifier.
        /// </value>
        public Nullable<int> ApconApprovalId { get; set; }
        /// <summary>
        /// Gets or sets the apcon amount.
        /// </summary>
        /// <value>
        /// The apcon amount.
        /// </value>
        public decimal ApconAmount { get; set; }
        /// <summary>
        /// Gets or sets the apcon approval number.
        /// </summary>
        /// <value>
        /// The apcon approval number.
        /// </value>
        public string ApconApprovalNumber { get; set; }
        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public DateTime[] EndDate { get; set; }

        /// <summary>
        /// Gets or sets the duration quantity.
        /// </summary>
        /// <value>
        /// The duration quantity.
        /// </value>
        public int DurationQuantity { get; set; }

        /// <summary>
        /// Gets or sets the design element identifier.
        /// </summary>
        /// <value>
        /// The design element identifier.
        /// </value>
        public int DesignElementId { get; set; }
        /// <summary>
        /// Gets or sets the design element price collection.
        /// </summary>
        /// <value>
        /// The design element price collection.
        /// </value>
        public IList<IDesignElementPrice> DesignElementPriceCollection { get; set; }
        /// <summary>
        /// Gets or sets the type of the design element.
        /// </summary>
        /// <value>
        /// The type of the design element.
        /// </value>
        public IList<SelectListItem> DesignElementType { get; set; }
        /// <summary>
        /// Gets or sets the design element amount.
        /// </summary>
        /// <value>
        /// The design element amount.
        /// </value>
        public decimal DesignElementAmount { get; set; }
        /// <summary>
        /// Gets or sets the print category identifier.
        /// </summary>
        /// <value>
        /// The print category identifier.
        /// </value>
        public int PrintCategoryId { get; set; }
        /// <summary>
        /// Gets or sets the print category description.
        /// </summary>
        /// <value>
        /// The print category description.
        /// </value>
        public string PrintCategoryDescription { get; set; }
        /// <summary>
        /// Gets or sets the type of the print category.
        /// </summary>
        /// <value>
        /// The type of the print category.
        /// </value>
        public IList<SelectListItem> PrintCategoryType { get; set; }
        /// <summary>
        /// Gets or sets the color identifier.
        /// </summary>
        /// <value>
        /// The color identifier.
        /// </value>
        public int ColorId { get; set; }
        /// <summary>
        /// Gets or sets the color description.
        /// </summary>
        /// <value>
        /// The color description.
        /// </value>
        public string ColorDescription { get; set; }
        /// <summary>
        /// Gets or sets the type of the color.
        /// </summary>
        /// <value>
        /// The type of the color.
        /// </value>
        public IList<SelectListItem> ColorType { get; set; }


        /// <summary>
        /// Gets or sets the type of the color.
        /// </summary>
        /// <value>
        /// The type of the color.
        /// </value>
        public IList<SelectListItem> ServiceColorDDl { get; set; }
        /// <summary>
        /// Gets or sets the newspaper description.
        /// </summary>
        /// <value>
        /// The newspaper description.
        /// </value>
        public string NewspaperDescription { get; set; }
        /// <summary>
        /// Gets or sets the type of the newspaper.
        /// </summary>
        /// <value>
        /// The type of the newspaper.
        /// </value>
        public IList<SelectListItem> NewspaperType { get; set; }
        /// <summary>
        /// Gets or sets the print service code.
        /// </summary>
        /// <value>
        /// The print service code.
        /// </value>
        public string PrintServiceCode { get; set; }
        /// <summary>
        /// Gets or sets the print service description.
        /// </summary>
        /// <value>
        /// The print service description.
        /// </value>
        public string PrintServiceDescription { get; set; }
        /// <summary>
        /// Gets or sets the type of the print service.
        /// </summary>
        /// <value>
        /// The type of the print service.
        /// </value>
        public IList<SelectListItem> PrintServiceType { get; set; }
        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public string Duration { get; set; }
        /// <summary>
        /// Gets or sets the type of the duration.
        /// </summary>
        /// <value>
        /// The type of the duration.
        /// </value>
        public IList<SelectListItem> DurationType { get; set; }
        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        public string Comment { get; set; }
        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// Gets or sets the effective date.
        /// </summary>
        /// <value>
        /// The effective date.
        /// </value>
        public System.DateTime EffectiveDate { get; set; }
        /// <summary>
        /// Gets or sets the orde identifier.
        /// </summary>
        /// <value>
        /// The orde identifier.
        /// </value>
        public int OrdeId { get; set; }
        /// <summary>
        /// Gets or sets the date inactive.
        /// </summary>
        /// <value>
        /// The date inactive.
        /// </value>
        public Nullable<System.DateTime> DateInactive { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the material digital file identifier.
        /// </summary>
        /// <value>
        /// The material digital file identifier.
        /// </value>
        public Nullable<int> MaterialDigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets the material digital file.
        /// </summary>
        /// <value>
        /// The material digital file.
        /// </value>
        public byte[] MaterialDigitalFile { get; set; }
        /// <summary>
        /// Gets or sets the name of the material digital file.
        /// </summary>
        /// <value>
        /// The name of the material digital file.
        /// </value>
        public string MaterialDigitalFileName { get; set; }
        /// <summary>
        /// Gets or sets the type of the material digital file.
        /// </summary>
        /// <value>
        /// The type of the material digital file.
        /// </value>
        public string MaterialDigitalFileType { get; set; }
        /// <summary>
        /// Gets or sets the material digital file extension.
        /// </summary>
        /// <value>
        /// The material digital file extension.
        /// </value>
        public string MaterialDigitalFileExtension { get; set; }
        /// <summary>
        /// Gets or sets the digital file.
        /// </summary>
        /// <value>
        /// The digital file.
        /// </value>
        public string DigitalFile { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the news paper list.
        /// </summary>
        /// <value>
        /// The news paper list.
        /// </value>
        public IList<INewsPaper> NewsPaperList { get; set; }
        /// <summary>
        /// Gets or sets the print collection.
        /// </summary>
        /// <value>
        /// The print collection.
        /// </value>
        public IList<ITvStation> TvStationList { get; set; }
        /// <summary>
        /// Gets or sets the print collection.
        /// </summary>
        /// <value>
        /// The print collection.
        /// </value>
        public IList<IPrintTransactionAiring> PrintCollection { get; set; }

        /// <summary>
        /// Gets or sets the print transaction airing.
        /// </summary>
        /// <value>
        /// The print transaction airing.
        /// </value>
        public IPrintTransactionAiringModel PrintTransactionAiring { get; set; }

        /// <summary>
        /// Gets or sets the new paper selection list.
        /// </summary>
        /// <value>
        /// The new paper selection list.
        /// </value>
        public List<Dictionary<string, string>> NewPaperSelectionList { get; set; }
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime[] StartDate { get; set; }
        /// <summary>
        /// Gets or sets the start date list.
        /// </summary>
        /// <value>
        /// The start date list.
        /// </value>
        public List<DateTime> StartDateList { get; set; }
        /// <summary>
        /// Gets or sets the airing instruction.
        /// </summary>
        /// <value>
        /// The airing instruction.
        /// </value>
        public string AiringInstruction { get; set; }
        /// <summary>
        /// Gets or sets the design element price identifier.
        /// </summary>
        /// <value>
        /// The design element price identifier.
        /// </value>
        public int? DesignElementPriceId { get; set; }
       


        /// <summary></summary>
        /// <param name="radioStationId"></param>
        /// <returns></returns>
        public string GetNewsPaperDescription(int PrintNewspaperId)
        {

            if (!this.NewsPaperList.Any())
            {
                return string.Empty;
            }

            if (PrintNewspaperId < 1)
            {
                return string.Empty;
            }

            var description = this.NewsPaperList.Where(y => y.NewsPaperId.Equals(PrintNewspaperId)).Select(x => x.Description).FirstOrDefault();

            return description;
        }
        /// <summary>
        /// Gets the print service type DDL.
        /// </summary>
        /// <param name="PrintServiceTypeId">The print service type identifier.</param>
        /// <returns></returns>
        public IList<SelectListItem> GetPrintServiceTypeDDL(int PrintServiceTypeId)
        {
            this.PrintServiceType.Each(x => x.Selected = false);
            this.PrintServiceType.Where(x => x.Value == "-1").Each(y => y.Selected = true);

            var result = new List<SelectListItem>();

            if (PrintServiceTypeId < 1)
            {
                return this.PrintServiceType;
            }

            this.PrintServiceType.Each(x => x.Selected = false);
            this.PrintServiceType.Where(x => x.Value == PrintServiceTypeId.ToString()).Each(y => y.Selected = true);

            return this.PrintServiceType;
        }




        public IList<SelectListItem> GetPrintMediaTypeDDL(int PrintMediaTypeId)
        {
            this.PrintMediaTypeList.Each(x => x.Selected = false);
            this.PrintMediaTypeList.Where(x => x.Value == "-1").Each(y => y.Selected = true);

            var result = new List<SelectListItem>();

            if (PrintMediaTypeId < 1)
            {
                return this.PrintMediaTypeList;
            }

            this.PrintMediaTypeList.Each(x => x.Selected = false);
            this.PrintMediaTypeList.Where(x => x.Value == PrintMediaTypeId.ToString()).Each(y => y.Selected = true);

            return this.PrintMediaTypeList;
        }



        public IList<SelectListItem> GetPrintServiceColorDDL(int PrintServiceColorId)
        {
            this.ServiceColorDDl.Each(x => x.Selected = false);
            this.ServiceColorDDl.Where(x => x.Value == "-1").Each(y => y.Selected = true);

            var result = new List<SelectListItem>();

            if (PrintServiceColorId < 1)
            {
                return this.ServiceColorDDl;
            }

            this.ServiceColorDDl.Each(x => x.Selected = false);
            this.ServiceColorDDl.Where(x => x.Value == PrintServiceColorId.ToString()).Each(y => y.Selected = true);

            return this.ServiceColorDDl;
        }

        
    }
}