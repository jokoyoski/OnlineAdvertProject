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
    
    public partial class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string OrderNumber { get; set; }
        public string OrderStatusCode { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
    }
}
