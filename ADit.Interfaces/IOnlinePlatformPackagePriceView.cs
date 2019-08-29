using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Interfaces
{
    public interface IOnlinePlatformPackagePriceView 
    {
         int OnlinePlatformPriceId { get; set; }

        int OnlinePlatformId { get; set; }

        IList<SelectListItem> OnlineDurationsList { get; set; }

        int OnlineDurationId { get; set; }

        int DurationQuantity { get; set; }

        decimal Amount { get; set; }

        string Comment { get; set; }

        System.DateTime EffectiveDate { get; set; }
        Nullable<System.DateTime> DateInactive { get; set; }

        //System.DateTime DateInactive { get; set; }

        bool IsActive { get; set; }

        System.DateTime DateCreated { get; set; }

        IList<SelectListItem> OnlinePlatform { get; set; }

        string ProcessingMessage { get; set; }

        string DurationsTypeCode { get; set; }
        IList<SelectListItem> DurationsType { get; set; }
    }
}
