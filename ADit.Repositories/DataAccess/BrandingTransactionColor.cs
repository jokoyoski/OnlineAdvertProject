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
    
    public partial class BrandingTransactionColor
    {
        public int BrandingTransactionColorId { get; set; }
        public int BrandingTransactionId { get; set; }
        public int ColorId { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
