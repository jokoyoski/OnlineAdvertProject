using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Repositories.Models
{
    public class OnlineTransactionUI : IOnlineTransactionUI
    {
        public int OnlineTransactionId { get; set; }
        public int OrderId { get; set; }
        public int OnlinePurposeId { get; set; }
        public int UserId { get; set; }
        public int OnlinePlatformId { get; set; }
        public int OnlinePlatformPriceId { get; set; }
        public decimal OnlinePlatformAmount { get; set; }
        public string AdditionalInformation { get; set; }
        public bool IsHaveArtWork { get; set; }
        public Nullable<int> ArtWorkPriceId { get; set; }
        public Nullable<decimal> OnlineArtworkAmount { get; set; }
        public  int ArtworkDigitalFileId { get; set; }
        public decimal Price { get; set; }
        public decimal FinalAmount { get; set; }
        public Nullable<int> ArtWorkId { get; set; }
        public bool IsActive { get; set; }
        public decimal OnlineExtraServiceAmount { get; set; }
        public string OrderTitle { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string TransactionStatusCode { get; set; }
        public int OnlineExtraServiceId { get; set; }
        public int OnlineExtraServicePriceId { get ; set ; }
        /// <summary>
        /// Gets or sets the material file description.
        /// </summary>
        /// <value>The material file description.</value>
        public string MaterialFileDescription { get; set; }

    }
}
