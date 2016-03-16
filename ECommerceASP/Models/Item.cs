using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceASP.Models
{
    public class Item
    {
        public int Item_id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Item_description { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> QuantityOfItem { get; set; }
    }
}