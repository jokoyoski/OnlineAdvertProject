using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBrandingView
    {
        /// <summary>
        /// Gets or sets the current status description.
        /// </summary>
        /// <value>
        /// The current status description.
        /// </value>
        string CurrentStatusDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int OrderFulfilmentId { get; set; }
        /// <summary>
        /// Gets or sets the current order status.
        /// </summary>
        /// <value>
        /// The current order status.
        /// </value>
        string CurrentOrderStatus { get; set; }
        /// <summary>
        /// Gets or sets the branding file identifier.
        /// </summary>
        /// <value>
        /// The branding file identifier.
        /// </value>
        int? BrandingFileId { get; set; }
        /// <summary>
        /// Gets or sets the digital file.
        /// </summary>
        /// <value>
        /// The digital file.
        /// </value>
        IDigitalFile digitalFile { get; set; }
        /// <summary>
        /// Gets or sets the status code list.
        /// </summary>
        /// <value>
        /// The status code list.
        /// </value>
        IList<SelectListItem> StatusCodeList { get; set; }

        ///
        /// <summary>
        /// Gets or sets the branding attachment file description.
        /// </summary>
        /// <value>
        /// The branding attachment file description.
        /// </value>
        string BrandingAttachmentFileDescription { get; set; }
        /// <summary>
        /// Gets or sets the branding attachment file identifier.
        /// </summary>
        /// <value>
        /// The branding attachment file identifier.
        /// </value>
        string BrandingAttachmentFileId { get; set; }

      
        
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        int OrderId { get; set; }
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
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        string PhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the colors.
        /// </summary>
        /// <value>
        /// The colors.
        /// </value>
        IList<string> Colors { get; set; }
        /// <summary>
        /// Gets or sets the design element.
        /// </summary>
        /// <value>
        /// The design element.
        /// </value>
        string DesignElement { get; set; }
        /// <summary>
        /// Gets or sets the additional color information.
        /// </summary>
        /// <value>
        /// The additional color information.
        /// </value>
        string AdditionalColorInfo { get; set; }
        /// <summary>
        /// Gets or sets the branding material.
        /// </summary>
        /// <value>
        /// The branding material.
        /// </value>
        string BrandingMaterial { get; set; }

        /// <summary>
        /// Gets or sets the branding transaction identifier.
        /// </summary>
        /// <value>
        /// The branding transaction identifier.
        /// </value>
        int BrandingTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        int OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the color of the other.
        /// </summary>
        /// <value>
        /// The color of the other.
        /// </value>
        string OtherColor { get; set; }

        /// <summary>
        /// Gets or sets the additional information.
        /// </summary>
        /// <value>
        /// The additional information.
        /// </value>
        string AdditionalInformation { get; set; }

        /// <summary>
        /// Gets or sets the replies identifier.
        /// </summary>
        /// <value>
        /// The replies identifier.
        /// </value>
        int RepliesId { get; set; }
        /// <summary>
        /// Gets or sets the message identifier.
        /// </summary>
        /// <value>
        /// The message identifier.
        /// </value>
        int MessageId { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        System.DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date modified.
        /// </summary>
        /// <value>
        /// The date modified.
        /// </value>
        System.DateTime DateModified { get; set; }

        /// <summary>
        /// Gets or sets the transaction status code.
        /// </summary>
        /// <value>
        /// The transaction status code.
        /// </value>
        string TransactionStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the material list.
        /// </summary>
        /// <value>
        /// The material list.
        /// </value>
        IList<SelectListItem> MaterialList { get; set; }

        /// <summary>
        /// Gets or sets the color list.
        /// </summary>
        /// <value>
        /// The color list.
        /// </value>
        IList<SelectListItem> ColorList { get; set; }

        //   IList<IColor> ColorList { get; set; }
        /// <summary>
        /// Gets or sets the design element list.
        /// </summary>
        /// <value>
        /// The design element list.
        /// </value>
        IList<SelectListItem> DesignElementList { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>

        string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the branding material price identifier.
        /// </summary>
        /// <value>
        /// The branding material price identifier.
        /// </value>
        int BrandingMaterialPriceId { get; set; }

        /// <summary>
        /// Gets or sets the branding material identifier.
        /// </summary>
        /// <value>
        /// The branding material identifier.
        /// </value>
        int BrandingMaterialId { get; set; }

        /// <summary>
        /// Gets or sets the color identifier.
        /// </summary>
        /// <value>
        /// The color identifier.
        /// </value>
        int[] ColorId { get; set; }


        /// <summary>
        /// Gets or sets the design element price identifier.
        /// </summary>
        /// <value>
        /// The design element price identifier.
        /// </value>
        int DesignElementPriceId { get; set; }

        /// <summary>
        /// Gets or sets the design element identifier.
        /// </summary>
        /// <value>
        /// The design element identifier.
        /// </value>
        int DesignElementId { get; set; }
        /// <summary>
        /// Gets or sets the branding material amount.
        /// </summary>
        /// <value>
        /// The branding material amount.
        /// </value>
        decimal BrandingMaterialAmount { get; set; }
        /// <summary>
        /// Gets or sets the design element amount.
        /// </summary>
        /// <value>
        /// The design element amount.
        /// </value>
        decimal DesignElementAmount { get; set; }
        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        string OrderTitle { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int UserId { get; set; }
        /// <summary>
        /// Gets or sets the design digital file identifier.
        /// </summary>
        /// <value>
        /// The design digital file identifier.
        /// </value>
        int DesignDigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        decimal TotalAmount { get; set; }
        /// <summary>
        /// Gets or sets the color tran list.
        /// </summary>
        /// <value>
        /// The color tran list.
        /// </value>
        List<Dictionary<string, string>> ColorTranList { get; set; }
        /// <summary>
        /// Gets or sets the branding transaction color identifier.
        /// </summary>
        /// <value>
        /// The branding transaction color identifier.
        /// </value>
        int BrandingTransactionColorId { get; set; }
    }
}