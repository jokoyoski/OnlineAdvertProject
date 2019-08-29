using System;

namespace ADit.Interfaces
{
    public interface IOnlinePlatformPrice
    {
        
        int OnlinePlatformPriceId { get; set; }
        
        int OnlinePlatformId { get; set; }
        
        int OnlineDurationId { get; set; }

        string PlatformDescription { get; set; }
        string DurationTypeCode { get; set; }

        string DurationDescription { get; set; }

        int DurationQuantity { get; set; }
        
        decimal Amount { get; set; }
        
        string Comment { get; set; }
        
        System.DateTime EffectiveDate { get; set; }
        
        Nullable<System.DateTime> DateInactive { get; set; }
        
       bool? IsActive { get; set; }
        
        System.DateTime DateCreated { get; set; }
    }
}
