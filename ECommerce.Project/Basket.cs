﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Project
{
    public class Basket
    {
        Dictionary<Item,int> basket = new Dictionary<Item,int>();
        public Guid basketID = Guid.NewGuid();

        //to do later, make sure this adds to database as well
        public void AddItem(Item itemToAdd)
        {
            basket.Add(itemToAdd,1);
        }
        public void RemoveItem(string itemName)
        {
            //void 
            Item itemToRemove = basket.SingleOrDefault(i => i.Key.ItemName == itemName).Key;

            //def if statement
            //if the itemToRemove is null then give a message saying that no item exists in the basket
            //possibly have this check a database to see whether the itemName is contained

            if (itemToRemove == null)
            {
                //need to find code for this
                //returns a message that says that the item does not exist in the basket
            }
            else
            {
                basket.Remove(itemToRemove);
            }
        }
        public Dictionary<Item, int> GetContents()
        {
            return basket;
        }
    }
}
