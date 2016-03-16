using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityFramework.Project;

namespace ECommerceASP.Models
{
    public class ECommerceViewModel
    {
        IItemRepository iRepo = new ItemRepository();
        public List<item> listOfItems = new List<item>();
        public List<Item> displayedListOfItems = new List<Item>();

        public ECommerceViewModel()
        {
            listOfItems = iRepo.RetrieveAllStockItems();

            foreach (EntityFramework.Project.item item in listOfItems)
            {
                Item ItemCopy = new Item() 
                { 
                    Name = item.name, 
                    Price = item.price, 
                    Item_description = item.item_description
                };
                displayedListOfItems.Add(ItemCopy);
            }
        }

        //public Action Something()
        //{
        //    iRepo.RemoveItem(,1);
        //}
    }
}