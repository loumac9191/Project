using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Project
{
    public abstract class Item : IBuyable //intention is to have this as an abstract class
    {
        //public int ItemI { get; set; }
        //want Items to be read from an external database
        //Item objects are given attributes via database
        public string ItemId;
        public string ItemName;
        public string Description;
        public double Price;

        public void BuyItem()
        {
            
        }

        public void TrackItem()
        {
            
        }

        public void ReviewItem()
        {

        }
    }
}
