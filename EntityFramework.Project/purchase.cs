//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFramework.Project
{
    using System;
    using System.Collections.Generic;
    
    public partial class purchase
    {
        public int purchase_id { get; set; }
        public Nullable<System.TimeSpan> timeofpurchase { get; set; }
        public Nullable<int> purchase_itemid { get; set; }
    
        public virtual item item { get; set; }
    }
}
