using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Interfaces
{
    public interface IOnlineOrderModel
    {

        string OrderTitle { get; set; }
        byte[] ArtworkDigitalFile { get; set; }
        string ArtworkDigitalFileName { get; set; }
        string ArtworkDigitalFileType { get; set; }
        string ArtworkDigitalFileExtension { get; set; }
        int OnlineTransactionId { get; set; }

        int OrderNumber { get; set; }

        int OnlinePurposeId { get; set; } 

        int OnlinePlatformId { get; set; }

        int OnlinePlatformPriceId { get; set; }

        decimal OnlinePlatformAmount { get; set; }

        string AdditionalInformation { get; set; }

        bool IsHaveArtWork { get; set; }

        int ArtWorkPriceId { get; set; }

        Nullable<decimal> ArtWorkAmount { get; set; }

        Nullable<int> ArtworkDigitalFileId { get; set; }

        System.DateTime DateCreated { get; set; }

        string TransactionStatusCode { get; set; }


        string ProcessingMessage { get; set; }


        IList<SelectListItem> OnlinePurposeList { get; set; }


        IList<SelectListItem> OnlinePlatformList { get; set; }
        IList<SelectListItem> OnlineExtraServiceList { get; set; }
        int OnlineExtraServiceId { get; set; }
        int OnlineExtraServicePriceId { get; set; }
        decimal OnlineExtraServicAmount { get; set; }
        Nullable<decimal> OnlineArtworkAmount { get; set; }

         
        int OnlineArtWorkPriceId { get; set; }

        IList<SelectListItem> ArtworkList { get; set; }
        decimal[] Price { get; set; }
        int[] OnlineDuration { get; set; }
        int[] OnlinePlatform { get; set; }
        bool[] IsServiceSelected { get; set; }
        List<Dictionary<string, string>> ServiceChannelList { get; set; }
        IOnlineTransactionAiringModel OnlineTransactionDetails { get; set; }
    }
}
