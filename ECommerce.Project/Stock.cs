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

        //public void CreateStock()
        //{
        //    //
        //}

        //untested
        public item StockRetriever(string itemToCheck)
        {
            try
            {
                item itemToCheckFromStock = sIRepository.RetrieveItemByName(itemToCheck);
                return itemToCheckFromStock;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public string StockChecker(string itemToCheck)
        {
            string checkResult;

            try
            {
                item itemToAdd = sIRepository.RetrieveItemByName(itemToCheck);
                checkResult = String.Format("{0} is in stock.", itemToCheck);
                return checkResult;
            }
            catch (Exception exception)
            {
                checkResult = String.Format("Error: {0} Inner Exception: {1}", exception.Message, exception.InnerException);
                return checkResult;
            }        
        }

        public string AddStock(string nameOfItem, string categoryOfItem, string itemDescriptionOfItem, decimal priceOfItem, int quantityOfItemToAdd)
        {
            string addResult;
            addResult = sIRepository.AddItem(nameOfItem, categoryOfItem, itemDescriptionOfItem, priceOfItem, quantityOfItemToAdd);
            return addResult;
        }

        //this will now need to include a number to instruct many items of stock need to be deleted

        public string RemoveStock(string itemToRemoveFromStock, int itemQuantity)
        {
            string removeResult;
            try
            {
                removeResult = sIRepository.RemoveItem(itemToRemoveFromStock, itemQuantity);
                return removeResult;
            }
            catch (Exception exception)
            {   
                throw exception;
            }
        }
    }
}
