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
    
    public partial class PrintTransactionPublish
    {
        public int PrintTransactionPublishId { get; set; }
        public int PrintTransactionId { get; set; }
        public Nullable<int> PrintServiceTypePriceId { get; set; }
        public decimal PrintServiceAmount { get; set; }
    }
}
