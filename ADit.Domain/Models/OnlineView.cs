using System;
using System.Collections.Generic;
using ADit.Interfaces;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ADit.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IOnlineView" />
    public class OnlineView : IOnlineView

    {/// <summary>
    /// 
    /// </summary>
        public string CurrentStatusDescription { get; set; }
        /// <summary>
        /// Gets or sets the order fulfilment identifier.
        /// </summary>
        /// <value>
        /// The order fulfilment identifier.
        /// </value>
        public int OrderFulfilmentId { get; set; }
        /// <summary>
        /// Gets or sets the status code list.
        /// </summary>
        /// <value>
        /// The status code list.
        /// </value>
        public IList<SelectListItem> StatusCodeList { get; set; }

        /// <summary>
        /// Gets or sets the cuurent status code.
        /// </summary>
        /// <value>
        /// The cuurent status code.
        /// </value>
        public string CuurentStatusCode { get; set; }
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
        /// Gets or sets the messages list.
        /// </summary>
        /// <value>
        /// The messages list.
        /// </value>
       public  IList<IMessage> MessagesList { get; set; }
        /// <summary>
        /// Gets or sets the replies list.
        /// </summary>
        /// <value>
        /// The replies list.
        /// </value>
       public  IList<IReplies> RepliesList { get; set; }
        /// <summary>
        /// Gets or sets the online extra service.
        /// </summary>
        /// <value>
        /// The online extra service.
        /// </value>
        public string OnlineExtraService { get; set; }
        /// <summary>
        /// Gets or sets the platform description.
        /// </summary>
        /// <value>
        /// The platform description.
        /// </value>
        public IList<string> PlatformDescription { get; set; }
        /// <summary>
        /// Gets or sets the duration description.
        /// </summary>
        /// <value>
        /// The duration description.
        /// </value>
        public IList<string> DurationDescription { get; set; }
        /// <summary>
        /// Gets or sets the prices.
        /// </summary>
        /// <value>
        /// The prices.
        /// </value>
        public IList<decimal> Prices { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the online purpose.
        /// </summary>
        /// <value>
        /// The online purpose.
        /// </value>
        public string OnlinePurpose { get; set; }

        /// <summary>
        /// Gets or sets the online transaction identifier.
        /// </summary>
        /// <value>
        /// The online transaction identifier.
        /// </value>
        public int OnlineTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        public int OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the online purpose identifier.
        /// </summary>
        /// <value>
        /// The online purpose identifier.
        /// </value>
        public int OnlinePurposeId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the online platform identifier.
        /// </summary>
        /// <value>
        /// The online platform identifier.
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
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>

        [Required(ErrorMessage = "Order Title is required")]
        public string OrderTitle { get; set; }

        /// <summary>
        /// Gets or sets the additional information.
        /// </summary>
        /// <value>
        /// The additional information.
        /// </value>
        [Required(ErrorMessage = "Please provided additional information for this transaction")]
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
        /// Gets or sets the art work price identifier.
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
        public Nullable<decimal> ArtWorkAmount { get; set; }

        /// <summary>
        /// Gets or sets the artwork digital file identifier.
        /// </summary>
        /// <value>
        /// The artwork digital file identifier.
        /// </value>
        public Nullable<int> ArtworkDigitalFileId { get; set; }

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
        /// Gets or sets the artwork list.
        /// </summary>
        /// <value>
        /// The artwork list.
        /// </value>
        public IList<SelectListItem> ArtworkList { get; set; }

        /// <summary>
        /// Gets or sets the online purpose list.
        /// </summary>
        /// <value>
        /// The online purpose list.
        /// </value>
        public IList<SelectListItem> OnlinePurposeList { get; set; }

        /// <summary>
        /// Gets or sets the online platform list.
        /// </summary>
        /// <value>
        /// The online platform list.
        /// </value>
        public IList<SelectListItem> OnlinePlatformList { get; set; }

        /// <summary>
        /// Gets or sets the online extra service list.
        /// </summary>
        /// <value>
        /// The online extra service list.
        /// </value>
        public IList<SelectListItem> OnlineExtraServiceList { get; set; }

        /// <summary>
        /// Gets or sets the platform packages.
        /// </summary>
        /// <value>
        /// The platform packages.
        /// </value>
        public IList<IOnlinePlatform> PlatformPackages { get; set; }

        /// <summary>
        /// Gets or sets the online extra service identifier.
        /// </summary>
        /// <value>
        /// The online extra service identifier.
        /// </value>
        public int OnlineExtraServiceId { get; set; }

        /// <summary>
        /// Gets or sets the online extra service price identifier.
        /// </summary>
        /// <value>
        /// The online extra service price identifier.
        /// </value>
        public int OnlineExtraServicePriceId { get; set; }

        /// <summary>
        /// Gets or sets the online extra servic amount.
        /// </summary>
        /// <value>
        /// The online extra servic amount.
        /// </value>
        public decimal OnlineExtraServicAmount { get; set; }

        /// <summary>
        /// Gets or sets the online artwork amount.
        /// </summary>
        /// <value>
        /// The online artwork amount.
        /// </value>
        public Nullable<decimal> OnlineArtworkAmount { get; set; }

        /// <summary>
        /// Gets or sets the online art work price identifier.
        /// </summary>
        /// <value>
        /// The online art work price identifier.
        /// </value>
        public int OnlineArtWorkPriceId { get; set; }



        /// <summary>
        /// Gets or sets the online platform identifier.
        /// </summary>
        /// <value>
        /// The online platform identifier.
        /// </value>
        public int OnlinePlatformId { get; set; }


        /// <summary>
        /// Gets or sets the final amount.
        /// </summary>
        /// <value>
        /// The final amount.
        /// </value>
        public decimal finalAmount { get; set; }


        /// <summary>
        /// Gets or sets the online duration list.
        /// </summary>
        /// <value>
        /// The online duration list.
        /// </value>
        public IList<SelectListItem> OnlineDurationList { get; set; }

        //   public IList<IOnlinePlatform> PlatformList { get; set; }

        /// <summary>
        /// Gets or sets the online collection.
        /// </summary>
        /// <value>
        /// The online collection.
        /// </value>
        public IList<IOnlineTransactionAiring> OnlineCollection { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal[] Price { get; set; }
        /// <summary>
        /// Gets or sets the duration of the online.
        /// </summary>
        /// <value>
        /// The duration of the online.
        /// </value>
        public int[] OnlineDuration { get; set; }

        /// <summary>
        /// Gets or sets the online platform.
        /// </summary>
        /// <value>
        /// The online platform.
        /// </value>
        public int[] OnlinePlatform { get; set; }

        /// <summary>
        /// Gets or sets the is service selected.
        /// </summary>
        /// <value>
        /// The is service selected.
        /// </value>
        public bool[] IsServiceSelected { get; set; }
        /// <summary>
        /// Gets or sets the service channel list.
        /// </summary>
        /// <value>
        /// The service channel list.
        /// </value>
        public List<Dictionary<string, string>> ServiceChannelList { get; set; }
        /// <summary>
        /// Gets or sets the online transaction details.
        /// </summary>
        /// <value>
        /// The online transaction details.
        /// </value>
        public IOnlineTransactionAiringModel OnlineTransactionDetails { get; set; }


        /// <summary>
        /// Gets if script is approved.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="ServiceCode">The service code.</param>
        /// <returns></returns>
        public bool getIfScriptIsApproved(int SentToId, int transactionId, string ServiceCode)
        {
            //checks the messags if it was approved 
            var Approval = this.MessagesList.FirstOrDefault(x => x.SentToId == SentToId && x.TransactionId == transactionId && x.ServiceCode == "Print");

            if (Approval == null)
            {
                return false;
            }


            if (Approval.IsApproved == true)
            {
                return true;
            }
            else  //if it hasnr been approved the message table , we then proceed to chceck from the reply table to see if it was approved 
            {
                var RepliesApproval = RepliesList.Where(x => x.MessageId == Approval.Id).ToList();
                if (RepliesApproval == null)
                {
                    return false;
                }
                foreach (var j in RepliesApproval)
                {
                    if (j.IsApproved == true)
                    {
                        return true;
                    }; //if it was approved in the reply table, return true

                }
                return false;
            }



        }
        /// <summary>
        /// Gets the inital message.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="ServiceCode">The service code.</param>
        /// <returns></returns>
        public bool getInitalMessage(int SentToId, int transactionId, string ServiceCode)
        {
            var initMessage = this.MessagesList.FirstOrDefault(x => x.SentToId == SentToId && x.TransactionId == transactionId && x.ServiceCode == ServiceCode);

            if (initMessage == null)
            {
                return false;
            }
            if (initMessage.Message != null)
            {
                return true;
            }
            return false;
        }
    }
}