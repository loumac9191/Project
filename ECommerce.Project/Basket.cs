using EntityFramework.Project;
using System;
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
        private Dictionary<item,int> basket = new Dictionary<item,int>();
        private Guid basketID = Guid.NewGuid();
        private decimal totalPrice = 0m;
        private IItemRepository _itemRepo;

        public Basket(IItemRepository itemRepo) 
        {
            _itemRepo = itemRepo;
        }

        //to do later, make sure this adds to database as well
        //check to see what is being added isnt null
        public void AddItem(item itemToAdd)
        {
            _itemRepo.AddItem(itemToAdd);
            basket.Add(itemToAdd,1);
        }

        public void RemoveItem(string itemName)
        {
            //recommend to have this return a string that states whether the item was removed or not
            //string removeItemResult;
            //void 
            item itemToRemove = basket.SingleOrDefault(i => i.Key.name == itemName).Key;

            //def if statement
            //if the itemToRemove is null then give a message saying that no item exists in the basket
            //possibly have this check a database to see whether the itemName is contained

            if (itemToRemove == null)
            {
                //need to find code for this
                //returns a message that says that the item does not exist in the basket
                //removeItemResult = "The item that you have tried to remove does not exist.";
            }
            else
            {
                basket.Remove(itemToRemove);
                //removeItemResult = "The item has been successfully removed.";
            }
        }

        public Dictionary<item, int> GetContents()
        {
            return basket;
        }

        public string GetBasketID()
        {
            string basketID = this.basketID.ToString();
            return basketID;
        }

        public decimal CalculatePrice()
        {
            //if statement inside to check whether items exist
            foreach (KeyValuePair<item, int> item in basket)
            {
                totalPrice += (decimal)item.Key.price;
            }
            return totalPrice;
        }
    }
}
