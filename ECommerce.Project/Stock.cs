using EntityFramework.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Project
{
    public class Stock
    {
        private IItemRepository sIRepository;

        public Stock()
        {
            sIRepository = new ItemRepository();
        }
        
        public Stock(IItemRepository itemRepo)
        {
            sIRepository = itemRepo;
        }

        public item StockRetriever(string itemToCheck)
        {            
            item itemToCheckFromStock = sIRepository.RetrieveItemByName(itemToCheck);
            if (itemToCheckFromStock.name == null || itemToCheckFromStock.name == "")
            {
                return itemToCheckFromStock;
            }
            else
            {
                return itemToCheckFromStock;
            }
        }

        public string StockChecker(string itemToCheck)
        {
            string checkResult;
            int quantityOfStock = sIRepository.GetStockCount(itemToCheck);
            if (quantityOfStock >= 1)
            {
                
                checkResult = String.Format("{0} stock count is: {1}",itemToCheck,quantityOfStock);
                return checkResult;
            }
            else
            {
                checkResult = String.Format("{0} is not in stock",itemToCheck);
                return checkResult;
            }    
        }

        public string AddStock(string nameOfItem, string categoryOfItem, string itemDescriptionOfItem, decimal priceOfItem, int quantityOfItemToAdd)
        {
            string addResult;
            addResult = sIRepository.AddItem(nameOfItem, categoryOfItem, itemDescriptionOfItem, priceOfItem, quantityOfItemToAdd);
            return addResult;
        }

        public string RemoveStock(string itemToRemoveFromStock, int itemQuantity)
        {
            string removeResult;
            removeResult = sIRepository.RemoveItem(itemToRemoveFromStock, itemQuantity);
            return removeResult;           
        } 
    }
}
