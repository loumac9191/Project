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
        //Upon instantiation, Baskets are given a blank dictionary, uniqueID and a capacity for price and IItemRepository
        private Dictionary<item,int> basket = new Dictionary<item,int>();
        private Guid basketID = Guid.NewGuid();
        private decimal totalPrice = 0m;
        private IItemRepository _itemRepo;

        public Basket(IItemRepository itemRepo) 
        {
            _itemRepo = itemRepo;
            string basketID = this.basketID.ToString();
        }

        //to do later, make sure this adds to database as well
        //check to see what is being added isnt null
        public void AddItem(string itemToAddByName)//item itemToAdd)
        {
            item itemToAdd = _itemRepo.RetrieveItemByName(itemToAddByName);
            basket.Add(itemToAdd,1);
        }

        //uncertain whether both of these will need to be given a string or an item

        public string RemoveItem(string itemName)
        {
            //recommend to have this return a string that states whether the item was removed or not
            string removeItemResult;

            //Remove method is from the users perspective and they therefore will not need to contact
            //the database.

            if (basket.Count == 0)
            {
                removeItemResult = "Your Basket is currently empty, there is nothing to currently remove from your Basket.";
                return removeItemResult;
            }
            else if (itemName == null || itemName == "")
	        {
                removeItemResult = "You have not entered a name of an item you would like to remove.";
                return removeItemResult;
	        }
            else
	        {        
		        item itemToRemove = basket.SingleOrDefault(i => i.Key.name == itemName).Key;
                    
                removeItemResult = String.Format("{0} has been successfully removed.", itemName);
                basket.Remove(itemToRemove);
                return removeItemResult;                  	          
	        }
        }

        public Dictionary<item, int> GetContents()
        {
            return basket;
        }

        //public string GetBasketID()
        //{
        //    string basketID = this.basketID.ToString();
        //    return basketID;
        //}

        public virtual decimal CalculatePrice()
        {
            foreach (KeyValuePair<item, int> item in basket)
            {
                totalPrice += (decimal)item.Key.price;
            }
            return totalPrice;
        }
    }
}
