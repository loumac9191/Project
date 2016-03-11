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

        //untested - need to check that the name test works
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

            // OLD CODE //        
            //try
            //{
            //    item itemToCheckFromStock = sIRepository.RetrieveItemByName(itemToCheck);
            //    return itemToCheckFromStock;
            //}
            //catch (Exception)
            //{                
            //    throw;
            //}
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

            //OLD CODE//
            //try
            //{
            //    item itemToAdd = sIRepository.RetrieveItemByName(itemToCheck);
            //    checkResult = String.Format("{0} is in stock.", itemToCheck);
            //    return checkResult;
            //}
            //catch (Exception exception)
            //{
            //    checkResult = String.Format("Error: {0} Inner Exception: {1}", exception.Message, exception.InnerException);
            //    return checkResult;
            //}        
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
