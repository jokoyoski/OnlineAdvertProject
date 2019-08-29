using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace ADit.Interfaces 
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOnlineView
      
    {
        /// <summary>
        /// Gets or sets the order fulfilment identifier.
        /// </summary>
        /// <value>
        /// The order fulfilment identifier.
        /// </value>
        int OrderFulfilmentId { get; set; }
        /// <summary>
        /// Gets or sets the current status description.
        /// </summary>
        /// <value>
        /// The current status description.
        /// </value>
        string CurrentStatusDescription { get; set; }
        /// <summary>
        /// Gets or sets the cuurent status code.
        /// </summary>
        /// <value>
        /// The cuurent status code.
        /// </value>
        string CuurentStatusCode { get; set; }
        /// <summary>
        /// Gets or sets the status code list.
        /// </summary>
        /// <value>
        /// The status code list.
        /// </value>
        IList<SelectListItem> StatusCodeList { get; set; }
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
        /// Gets if script is approved.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="ServiceCode">The service code.</param>
        /// <returns></returns>
        bool getIfScriptIsApproved(int SentToId, int transactionId, string ServiceCode);
        /// <summary>
        /// Gets the inital message.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="ServiceCode">The service code.</param>
        /// <returns></returns>
        bool getInitalMessage(int SentToId, int transactionId, string ServiceCode);
        /// <summary>
        /// Gets or sets the messages list.
        /// </summary>
        /// <value>
        /// The messages list.
        /// </value>
        IList<IMessage> MessagesList { get; set; }
        /// <summary>
        /// Gets or sets the replies list.
        /// </summary>
        /// <value>
        /// The replies list.
        /// </value>
        IList<IReplies> RepliesList { get; set; }
        /// <summary>
        /// Gets or sets the online extra service.
        /// </summary>
        /// <value>
        /// The online extra service.
        /// </value>
        string OnlineExtraService { get; set; }
        /// <summary>
        /// Gets or sets the platform description.
        /// </summary>
        /// <value>
        /// The platform description.
        /// </value>
        IList<string> PlatformDescription { get; set; }
        /// <summary>
        /// Gets or sets the duration description.
        /// </summary>
        /// <value>
        /// The duration description.
        /// </value>
        IList<string> DurationDescription { get; set; }
        /// <summary>
        /// Gets or sets the prices.
        /// </summary>
        /// <value>
        /// The prices.
        /// </value>
        IList<decimal> Prices { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        string PhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        string Email { get; set; }
        /// <summary>
        /// Gets or sets the online purpose.
        /// </summary>
        /// <value>
        /// The online purpose.
        /// </value>
        string OnlinePurpose { get; set; }
        /// <summary>
        /// Gets or sets the online art work price identifier.
        /// </summary>
        /// <value>
        /// The online art work price identifier.
        /// </value>
        int OnlineArtWorkPriceId { get; set; }
        /// <summary>
        /// Gets or sets the online transaction identifier.
        /// </summary>
        /// <value>
        /// The online transaction identifier.
        /// </value>
        int OnlineTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int UserId { get; set; }
        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        int OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the online purpose identifier.
        /// </summary>
        /// <value>
        /// The online purpose identifier.
        /// </value>
        int OnlinePurposeId { get; set; }



        /// <summary>
        /// Gets or sets the online platform price identifier.
        /// </summary>
        /// <value>
        /// The online platform price identifier.
        /// </value>
        int OnlinePlatformPriceId { get; set; }

        /// <summary>
        /// Gets or sets the online platform amount.
        /// </summary>
        /// <value>
        /// The online platform amount.
        /// </value>
        decimal OnlinePlatformAmount { get; set; }

        /// <summary>
        /// Gets or sets the additional information.
        /// </summary>
        /// <value>
        /// The additional information.
        /// </value>
        string AdditionalInformation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is have art work.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is have art work; otherwise, <c>false</c>.
        /// </value>
        bool IsHaveArtWork { get; set; }

        /// <summary>
        /// Gets or sets the art work identifier.
        /// </summary>
        /// <value>
        /// The art work identifier.
        /// </value>
        Nullable<int> ArtWorkId { get; set; }

        /// <summary>
        /// Gets or sets the art work price identifier.
        /// </summary>
        /// <value>
        /// The art work price identifier.
        /// </value>
        Nullable<int> ArtWorkPriceId { get; set; }

        /// <summary>
        /// Gets or sets the art work amount.
        /// </summary>
        /// <value>
        /// The art work amount.
        /// </value>
        Nullable<decimal> ArtWorkAmount { get; set; }

        /// <summary>
        /// Gets or sets the artwork digital file identifier.
        /// </summary>
        /// <value>
        /// The artwork digital file identifier.
        /// </value>
        Nullable<int> ArtworkDigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        System.DateTime DateCreated { get; set; }

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
        /// Gets or sets the online purpose list.
        /// </summary>
        /// <value>
        /// The online purpose list.
        /// </value>
        IList<SelectListItem> OnlinePurposeList { get; set; }


        /// <summary>
        /// Gets or sets the online platform list.
        /// </summary>
        /// <value>
        /// The online platform list.
        /// </value>
        IList<SelectListItem> OnlinePlatformList { get; set; }
        /// <summary>
        /// Gets or sets the online extra service list.
        /// </summary>
        /// <value>
        /// The online extra service list.
        /// </value>
        IList<SelectListItem> OnlineExtraServiceList { get; set; }
        /// <summary>
        /// Gets or sets the platform packages.
        /// </summary>
        /// <value>
        /// The platform packages.
        /// </value>
        IList<IOnlinePlatform> PlatformPackages { get; set; }

        /// <summary>
        /// Gets or sets the online extra service identifier.
        /// </summary>
        /// <value>
        /// The online extra service identifier.
        /// </value>
        int OnlineExtraServiceId { get; set; }
        /// <summary>
        /// Gets or sets the online extra service price identifier.
        /// </summary>
        /// <value>
        /// The online extra service price identifier.
        /// </value>
        int OnlineExtraServicePriceId { get; set; }
        /// <summary>
        /// Gets or sets the online extra servic amount.
        /// </summary>
        /// <value>
        /// The online extra servic amount.
        /// </value>
        decimal OnlineExtraServicAmount { get; set; }
        /// <summary>
        /// Gets or sets the online artwork amount.
        /// </summary>
        /// <value>
        /// The online artwork amount.
        /// </value>
        Nullable<decimal> OnlineArtworkAmount { get; set; }

        /// <summary>
        /// Gets or sets the online platform identifier.
        /// </summary>
        /// <value>
        /// The online platform identifier.
        /// </value>
        int OnlinePlatformId { get; set; }
        /// <summary>
        /// Gets or sets the artwork list.
        /// </summary>
        /// <value>
        /// The artwork list.
        /// </value>
        IList<SelectListItem> ArtworkList { get; set; }

        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        string OrderTitle { get; set; }
        /// <summary>
        /// Gets or sets the final amount.
        /// </summary>
        /// <value>
        /// The final amount.
        /// </value>
        decimal finalAmount { get; set; }
        /// <summary>
        /// Gets or sets the online duration list.
        /// </summary>
        /// <value>
        /// The online duration list.
        /// </value>
        IList<SelectListItem> OnlineDurationList { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        decimal[] Price { get; set; }
        /// <summary>
        /// Gets or sets the duration of the online.
        /// </summary>
        /// <value>
        /// The duration of the online.
        /// </value>
        int[] OnlineDuration { get; set; }
        /// <summary>
        /// Gets or sets the online platform.
        /// </summary>
        /// <value>
        /// The online platform.
        /// </value>
        int[] OnlinePlatform { get; set; }
        /// <summary>
        /// Gets or sets the is service selected.
        /// </summary>
        /// <value>
        /// The is service selected.
        /// </value>
        bool[] IsServiceSelected { get; set; }
        /// <summary>
        /// Gets or sets the service channel list.
        /// </summary>
        /// <value>
        /// The service channel list.
        /// </value>
        List<Dictionary<string, string>> ServiceChannelList { get; set; }
        /// <summary>
        /// Gets or sets the online transaction details.
        /// </summary>
        /// <value>
        /// The online transaction details.
        /// </value>
        IOnlineTransactionAiringModel OnlineTransactionDetails { get; set; }
    }
}