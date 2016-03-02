﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Project
{
    public class Basket
    {
        //When a basket is instantiated, it should not have any constructor
        //Upon instantiation, it will be given a blank list, uniqueID and a capacity for price
        private Dictionary<Item,int> basket = new Dictionary<Item,int>();
        private Guid basketID = Guid.NewGuid();
        private int totalPrice;

        //to do later, make sure this adds to database as well
        //check to see what is being added isnt null
        public void AddItem(Item itemToAdd)
        {
            basket.Add(itemToAdd,1);
        }

        public void RemoveItem(string itemName)
        {
            //void 
            Item itemToRemove = basket.SingleOrDefault(i => i.Key.ItemName == itemName).Key;
            //basket.sing

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

        public string GetBasketID()
        {
            string basketID = this.basketID.ToString();
            return basketID;
        }

        public int CalculatePrice()
        {
            //if statement inside to check whether items exist
            foreach (KeyValuePair<Item, int> item in basket)
            {
                totalPrice += item.Key.Price;
            }
            return totalPrice;
        }
    }
}
