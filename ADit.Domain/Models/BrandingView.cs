using ADit.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;

namespace ADit.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IBrandingView" />
    public class BrandingView : IBrandingView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BrandingView"/> class.
        /// </summary>
        public BrandingView()
        {
            MaterialList = new List<SelectListItem>();
            ColorList = new List<SelectListItem>();
            DesignElementList = new List<SelectListItem>();

            // ColorId = new int[]{};
        }


        /// <summary>
        /// Gets or sets the current status description.
        /// </summary>
        /// <value>
        /// The current status description.
        /// </value>
        public string CurrentStatusDescription { get; set; }
        /// <summary>
        /// Gets or sets the order fulfilment identifier.
        /// </summary>
        /// <value>
        /// The order fulfilment identifier.
        /// </value>
        public int OrderFulfilmentId { get; set; }
        /// <summary>
        /// Gets or sets the current order status.
        /// </summary>
        /// <value>
        /// The current order status.
        /// </value>
        public string CurrentOrderStatus { get; set; }
        /// <summary>
        /// Gets or sets the branding file identifier.
        /// </summary>
        /// <value>
        /// The branding file identifier.
        /// </value>
        public int? BrandingFileId { get; set; }
        /// <summary>
        /// Gets or sets the digital file.
        /// </summary>
        /// <value>
        /// The digital file.
        /// </value>
        public IDigitalFile digitalFile { get; set; }
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
        /// Gets or sets the branding attachment file description.
        /// </summary>
        /// <value>
        /// The branding attachment file description.
        /// </value>
        public string BrandingAttachmentFileDescription { get; set; }
        /// <summary>
        /// Gets or sets the branding attachment file identifier.
        /// </summary>
        /// <value>
        /// The branding attachment file identifier.
        /// </value>
        public string BrandingAttachmentFileId { get; set; }
        /// <summary>
        /// </summary>
        public int DesignElementPriceId { get; set; }
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public int OrderId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the colors.
        /// </summary>
        /// <value>
        /// The colors.
        /// </value>
        public IList<string> Colors { get; set; }
        /// <summary>
        /// Gets or sets the design element.
        /// </summary>
        /// <value>
        /// The design element.
        /// </value>
        public string DesignElement { get; set; }

        /// <summary>
        /// Gets or sets the additional color information.
        /// </summary>
        /// <value>
        /// The additional color information.
        /// </value>
        public string AdditionalColorInfo { get; set; }
        /// <summary>
        /// Gets or sets the branding material.
        /// </summary>
        /// <value>
        /// The branding material.
        /// </value>
        public string BrandingMaterial { get; set; }

        /// <summary>
        /// </summary>
        public int BrandingTransactionId { get; set; }

        /// <summary>
        /// </summary>
        public int OrderNumber { get; set; }

        /// <summary>
        /// </summary>
        public string OtherColor { get; set; }

        /// <summary>
        /// </summary>
        [Required(ErrorMessage = "Please provided additional information for this transaction")]
        public string AdditionalInformation { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTime DateCreated { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTime DateModified { get; set; }

        /// <summary>
        /// </summary>
        public string TransactionStatusCode { get; set; }

        /// <summary>
        /// </summary>
        public IList<SelectListItem> MaterialList { get; set; }

        /// <summary>
        /// </summary>
        public IList<SelectListItem> ColorList { get; set; }

        /// <summary>
        /// Gets or sets the status code list.
        /// </summary>
        /// <value>
        /// The status code list.
        /// </value>
        public IList<SelectListItem> StatusCodeList { get; set; }
        
        /// <summary>
        /// </summary>
        public IList<SelectListItem> DesignElementList { get; set; }

        /// <summary>
        /// </summary>

        public string ProcessingMessage { get; set; }

        /// <summary>
        /// </summary>
        public int BrandingMaterialPriceId { get; set; }

        /// <summary>
        /// Gets or sets the branding material identifier.
        /// </summary>
        /// <value>
        /// The branding material identifier.
        /// </value>
        public int BrandingMaterialId { get; set; }

        /// <summary>
        /// </summary>
        public int[] ColorId { get; set; }

        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        [Required(ErrorMessage = "Order Title is required")]
        public string OrderTitle { get; set; }

        /// <summary>
        /// Gets or sets the branding transaction color identifier.
        /// </summary>
        /// <value>
        /// The branding transaction color identifier.
        /// </value>


        public int BrandingTransactionColorId { get; set; }

        /// <summary>
        /// Gets or sets the design element identifier.
        /// </summary>
        /// <value>
        /// The design element identifier.
        /// </value>
        public int DesignElementId { get; set; }
        /// <summary>
        /// Gets or sets the branding material amount.
        /// </summary>
        /// <value>
        /// The branding material amount.
        /// </value>
        public decimal BrandingMaterialAmount { get; set; }
        /// <summary>
        /// Gets or sets the design element amount.
        /// </summary>
        /// <value>
        /// The design element amount.
        /// </value>
        public decimal DesignElementAmount { get; set; }


        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the design digital file identifier.
        /// </summary>
        /// <value>
        /// The design digital file identifier.
        /// </value>
        public int DesignDigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// Gets or sets the color tran list.
        /// </summary>
        /// <value>
        /// The color tran list.
        /// </value>
        public List<Dictionary<string, string>> ColorTranList { get; set; }
    }
}