using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICart
    {
        /// <summary>
        /// Gets or sets the cart identifier.
        /// </summary>
        /// <value>
        /// The cart identifier.
        /// </value>
        int CartId { get; set; }
        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        int OrderNumber { get; set; }
        /// <summary>
        /// Gets or sets the type of the service.
        /// </summary>
        /// <value>
        /// The type of the service.
        /// </value>
        string ServiceType { get; set; }
        /// <summary>
        /// Gets or sets the item code.
        /// </summary>
        /// <value>
        /// The item code.
        /// </value>
        string ItemCode { get; set; }
        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        string Comment { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        System.DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is have material.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is have material; otherwise, <c>false</c>.
        /// </value>
        bool IsHaveMaterial { get; set; }
        /// <summary>
        /// Gets or sets the material digital file identifier.
        /// </summary>
        /// <value>
        /// The material digital file identifier.
        /// </value>
        Nullable<int> MaterialDigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets the apcon approval number.
        /// </summary>
        /// <value>
        /// The apcon approval number.
        /// </value>
        string ApconApprovalNumber { get; set; }
        /// <summary>
        /// Gets or sets the apcon approval type identifier.
        /// </summary>
        /// <value>
        /// The apcon approval type identifier.
        /// </value>
        Nullable<int> ApconApprovalTypeId { get; set; }
        /// <summary>
        /// Gets or sets the apcon approval type price identifier.
        /// </summary>
        /// <value>
        /// The apcon approval type price identifier.
        /// </value>
        Nullable<int> ApconApprovalTypePriceId { get; set; }
        /// <summary>
        /// Gets or sets the apcon approval amount.
        /// </summary>
        /// <value>
        /// The apcon approval amount.
        /// </value>
        decimal ApconApprovalAmount { get; set; }
        /// <summary>
        /// Gets or sets the print category identifier.
        /// </summary>
        /// <value>
        /// The print category identifier.
        /// </value>
        int PrintCategoryId { get; set; }
        /// <summary>
        /// Gets or sets the design element identifier.
        /// </summary>
        /// <value>
        /// The design element identifier.
        /// </value>
        int DesignElementId { get; set; }
        /// <summary>
        /// Gets or sets the design element price identifier.
        /// </summary>
        /// <value>
        /// The design element price identifier.
        /// </value>
        Nullable<int> DesignElementPriceId { get; set; }
        /// <summary>
        /// Gets or sets the design amount.
        /// </summary>
        /// <value>
        /// The design amount.
        /// </value>
        decimal DesignAmount { get; set; }
        /// <summary>
        /// Gets or sets the duration type code.
        /// </summary>
        /// <value>
        /// The duration type code.
        /// </value>
        string DurationTypeCode { get; set; }
        /// <summary>
        /// Gets or sets the duration quantity.
        /// </summary>
        /// <value>
        /// The duration quantity.
        /// </value>
        int DurationQuantity { get; set; }
        /// <summary>
        /// Gets or sets the number of inserts.
        /// </summary>
        /// <value>
        /// The number of inserts.
        /// </value>
        int NumberOfInserts { get; set; }

        /// <summary>
        /// Gets or sets the transaction status code.
        /// </summary>
        /// <value>
        /// The transaction status code.
        /// </value>
        string TransactionStatusCode { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the print category list.
        /// </summary>
        /// <value>
        /// The print category list.
        /// </value>
        IList<SelectListItem> PrintCategoryList { get; set; }
        /// <summary>
        /// Gets or sets the print newspaper list.
        /// </summary>
        /// <value>
        /// The print newspaper list.
        /// </value>
        IList<SelectListItem> PrintNewspaperList { get; set; }
        /// <summary>
        /// Gets or sets the print service type list.
        /// </summary>
        /// <value>
        /// The print service type list.
        /// </value>
        IList<SelectListItem> PrintServiceTypeList { get; set; }
        /// <summary>
        /// Gets or sets the color list.
        /// </summary>
        /// <value>
        /// The color list.
        /// </value>
        IList<SelectListItem> ColorList { get; set; }
        /// <summary>
        /// Gets or sets the design element list.
        /// </summary>
        /// <value>
        /// The design element list.
        /// </value>
        IList<SelectListItem> DesignElementList { get; set; }
        /// <summary>
        /// Gets or sets the news paper identifier.
        /// </summary>
        /// <value>
        /// The news paper identifier.
        /// </value>

        int NewsPaperId { get; set; }
        /// <summary>
        /// Gets or sets the color identifier.
        /// </summary>
        /// <value>
        /// The color identifier.
        /// </value>
        int ColorId { get; set; }
        /// <summary>
        /// Gets or sets the duration list.
        /// </summary>
        /// <value>
        /// The duration list.
        /// </value>

        IList<SelectListItem> DurationList { get; set; }
        /// <summary>
        /// Gets or sets the apcon approval list.
        /// </summary>
        /// <value>
        /// The apcon approval list.
        /// </value>
        IList<SelectListItem> ApconApprovalList { get; set; }

        /// <summary>
        /// Gets or sets the print service type identifier.
        /// </summary>
        /// <value>
        /// The print service type identifier.
        /// </value>
        int PrintServiceTypeId { get; set; }
    }
}
