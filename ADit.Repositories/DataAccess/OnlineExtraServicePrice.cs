//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ADit.Repositories.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class OnlineExtraServicePrice
    {
        public int OnlineExtraServicePriceId { get; set; }
        public int OnlineExtraServiceId { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }
        public System.DateTime EffectiveDate { get; set; }
        public Nullable<System.DateTime> DateInactive { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime DateCreated { get; set; }
    }
}
