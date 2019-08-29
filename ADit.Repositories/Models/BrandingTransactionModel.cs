using ADit.Interfaces;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IBrandingTransaction" />
    public class BrandingTransactionModel : IBrandingTransaction
    {

        /// <summary>
        /// Gets or sets the branding attachment description.
        /// </summary>
        /// <value>
        /// The branding attachment description.
        /// </value>
        public string BrandingAttachmentDescription { get; set; }
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
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// Gets or sets the sent to identifier.
        /// </summary>
        /// <value>
        /// The sent to identifier.
        /// </value>
        public int SentToId { get; set; }
        /// <summary>
        /// Gets or sets the matertial file identifier.
        /// </summary>
        /// <value>
        /// The matertial file identifier.
        /// </value>
        public int MatertialFileId { get; set; }
        /// <summary>
        /// Gets or sets the branding transaction identifier.
        /// </summary>
        /// <value>
        /// The branding transaction identifier.
        /// </value>
        public int BrandingTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the color of the other.
        /// </summary>
        /// <value>
        /// The color of the other.
        /// </value>
        public string OtherColor { get; set; }

        /// <summary>
        /// Gets or sets the additional information.
        /// </summary>
        /// <value>
        /// The additional information.
        /// </value>
        public string AdditionalInformation { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public System.DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date modified.
        /// </summary>
        /// <value>
        /// The date modified.
        /// </value>
        public System.DateTime DateModified { get; set; }

        /// <summary>
        /// Gets or sets the transaction status code.
        /// </summary>
        /// <value>
        /// The transaction status code.
        /// </value>
        public string TransactionStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

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
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        public string OrderTitle { get; set; }

        /// <summary>
        /// Gets or sets the branding material price identifier.
        /// </summary>
        /// <value>
        /// The branding material price identifier.
        /// </value>
        public int BrandingMaterialPriceId { get; set; }

        /// <summary>
        /// Gets or sets the branding material identifier.
        /// </summary>
        /// <value>
        /// The branding material identifier.
        /// </value>
        public int BrandingMaterialId { get; set; }

        /// <summary>
        /// Gets or sets the color identifier.
        /// </summary>
        /// <value>
        /// The color identifier.
        /// </value>
        public int ColorId { get; set; }
        /// <summary>
        /// Gets or sets the design element price identifier.
        /// </summary>
        /// <value>
        /// The design element price identifier.
        /// </value>
        public int DesignElementPriceId { get; set; }

        /// <summary>
        /// Gets or sets the design element identifier.
        /// </summary>
        /// <value>
        /// The design element identifier.
        /// </value>
        public int DesignElementId { get; set; }

        /// <summary>
        /// 6
        /// </summary>
        /// <value>
        /// The branding file identifier.
        /// </value>
        public int? BrandingFileId { get; set; }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }


    }
}