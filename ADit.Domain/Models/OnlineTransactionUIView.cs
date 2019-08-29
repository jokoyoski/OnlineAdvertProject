using System;
using System.Collections.Generic;
using System.Linq;
using ADit.Interfaces;
using System.Web.Mvc;
using AA.Infrastructure.Extensions;

namespace ADit.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IOnlineTransactionUIView" />
    public class OnlineTransactionUIView : IOnlineTransactionUIView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnlineTransactionUIView"/> class.
        /// </summary>
        public OnlineTransactionUIView() 
        {
            this.OnlineDurationList = new List<SelectListItem>();
            this.PlatformPackages = new List<IOnlinePlatform>();
            this.AiringDetailsList = new List<IOnlineTransactionAiringUI>();
            this.OnlinePurposeList = new List<SelectListItem>();
            this.OnlineExtraServiceList = new List<SelectListItem>();
            this.TimingType = new List<SelectListItem>();
            this.SelectedOnlinePackagesIds = new List<int>();
        }
        /// <summary>
        /// Gets or sets the online duration list.
        /// </summary>
        /// <value>
        /// The online duration list.
        /// </value>
        public IList<SelectListItem> OnlineDurationList { get; set; }



        public int OnlineExtraServiceId { get; set; }

        public int OnlineExtraServicePriceId { get; set; }

        /// <summary>
        /// Gets or sets the online platform identifier.
        /// </summary>
        /// <value>
        /// The online platform identifier.
        /// </value>
        public int OnlinePlatformId { get; set; }

        /// <summary>
        /// Gets or sets the online extra service amount.
        /// </summary>
        /// <value>
        /// The online extra service amount.
        /// </value>
        public decimal OnlineExtraServiceAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the duration of the online.
        /// </summary>
        /// <value>
        /// The duration of the online.
        /// </value>
        public IList<IOnlineDuration> OnlineDuration { get; set; }
        /// <summary>
        /// </summary>
        public IList<IOnlinePlatform> PlatformPackages { get; set; }

        /// <summary>
        /// </summary>
        public IList<IOnlineTransactionAiringUI> AiringDetailsList { get; set; }
        /// <summary>
        /// Gets or sets the type of the timing.
        /// </summary>
        /// <value>
        /// The type of the timing.
        /// </value>
        public IList<SelectListItem> TimingType { get; set; }
        /// <summary>
        /// </summary>
        public IList<SelectListItem> OnlineExtraServiceList { get; set; }

        /// <summary>
        /// </summary>
        public IList<SelectListItem> OnlinePlatformList { get; set; }

        /// <summary>
        /// </summary>
        public IList<SelectListItem> OnlinePurposeList { get; set; }

        /// <summary>
        /// </summary>
        public IList<SelectListItem> ArtworkList { get; set; }
         
        /// <summary>
        /// </summary>
        public List<int> SelectedOnlinePackagesIds { get; set; }


        /// <summary>
        /// Online transaction Id
        /// </summary>
        /// <value>
        /// The online transaction identifier.
        /// </value>
        public int OnlineTransactionId { get; set; }

        /// <summary>
        /// Order Number
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public int OrderId { get; set; }

        /// <summary>
        /// Online Purpose Id
        /// </summary>
        /// <value>
        /// The online purpose identifier.
        /// </value>
        public int OnlinePurposeId { get; set; }

        /// <summary>
        /// User Id
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Online platform price Id
        /// </summary>
        /// <value>
        /// The online platform price identifier.
        /// </value>
        public int OnlinePlatformPriceId { get; set; }

        /// <summary>
        /// Gets or sets the online platform amount.
        /// </summary>
        /// <value>
        /// The online platform amount.
        /// </value>
        public decimal OnlinePlatformAmount { get; set; }


        /// <summary>
        /// Additional information
        /// </summary>
        /// <value>
        /// The additional information.
        /// </value>
        public string AdditionalInformation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is have art work.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is have art work; otherwise, <c>false</c>.
        /// </value>
        public bool IsHaveArtWork { get; set; }

        /// <summary>
        /// Gets or sets the art work price identifier.
        /// </summary>
        /// <value>
        /// The art work price identifier.
        /// </value>
        public Nullable<int> ArtWorkId { get; set; }

        /// <summary>
        /// The artwork price Id
        /// </summary>
        /// <value>
        /// The art work price identifier.
        /// </value>
        public Nullable<int> ArtWorkPriceId { get; set; }

        /// <summary>
        /// Gets or sets the art work amount.
        /// </summary>
        /// <value>
        /// The art work amount.
        /// </value>
        public Nullable<decimal> OnlineArtworkAmount { get; set; }

        /// <summary>
        /// Gets or sets the artwork digital file identifier.
        /// </summary>
        /// <value>
        /// The artwork digital file identifier.
        /// </value>
        public  int ArtworkDigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public System.DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the transaction status code.
        /// </summary>
        /// <value>
        /// The transaction status code.
        /// </value>
        public string TransactionStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the transaction status code.
        /// </summary>
        /// <value>
        /// The transaction status code.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Final Amount
        /// </summary>
        /// <value>
        /// The final amount.
        /// </value>
        public decimal FinalAmount { get; set; }

        /// <summary>
        /// Online extra service amount
        /// </summary>
        /// <value>
        /// The online extra servic amount.
        /// </value>
        public decimal OnlineExtraServicAmount { get; set; }

        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        public string OrderTitle { get; set; }

        /// <summary>
        /// Gets or sets the material file description.
        /// </summary>
        /// <value>The material file description.</value>
        public string MaterialFileDescription { get; set; }


        /// <summary>
        /// Gets the online platform description.
        /// </summary>
        /// <param name="platformId">The platform identifier.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        public string GetOnlinePackageDescription(int platformId)
        {
            if (!this.PlatformPackages.Any())
            {
                return string.Empty;
            }

            if (platformId < 1)
            {
                return string.Empty;
            }

            var description = this.PlatformPackages.Where(y => y.OnlinePlatformId.Equals(platformId)).Select(x => x.Description).FirstOrDefault();

            return description;

        }


        /// <summary>
        /// Gets the timing DDL.
        /// </summary>
        /// <param name="OnlineDurationId">The online duration identifier.</param>
        /// <returns>
        /// IList&lt;SelectListItem&gt;.
        /// </returns>
        public IList<SelectListItem> GetTimingDDL(int OnlineDurationId)
        {
            this.OnlineDurationList.Each(x => x.Selected = false);
            this.OnlineDurationList.Where(x => x.Value == "-1").Each(y => y.Selected = true);

            var result = new List<SelectListItem>();

            if (OnlineDurationId < 1)
            {
                return this.OnlineDurationList;
            }

            this.OnlineDurationList.Each(x => x.Selected = false);
            this.OnlineDurationList.Where(x => x.Value == OnlineDurationId.ToString()).Each(y => y.Selected = true);

            return this.OnlineDurationList;
        }
    }
}
