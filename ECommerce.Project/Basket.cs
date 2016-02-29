using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Project
{
    public class Basket
    {
        Dictionary<Item,int> basket = new Dictionary<Item,int>();

        //to do later, make sure this adds to database as well
        public Dictionary<Item, int> AddItem(Item itemToAdd)
        {
            basket.Add(itemToAdd,1);
            return basket;
        }
    }
}
