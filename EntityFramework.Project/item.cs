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
    
    public partial class item
    {
        public item()
        {
            this.purchases = new HashSet<purchase>();
        }
    
        public int item_id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string item_description { get; set; }
        public Nullable<decimal> price { get; set; }
    
        public virtual ICollection<purchase> purchases { get; set; }
    }
}
