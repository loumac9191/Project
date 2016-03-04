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
        
        public Stock(IItemRepository itemRepo)
        {
            sIRepository = itemRepo;
        }

        public void CreateStock()
        {
            //
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

        public string AddStock(string nameOfItem, string categoryOfItem, string itemDescriptionOfItem, decimal priceOfItem)
        {
            string addResult;
            addResult = sIRepository.AddItem(nameOfItem, categoryOfItem, itemDescriptionOfItem, priceOfItem);
            return addResult;
        }

        public string RemoveStock(string itemToRemoveFromStock)
        {
            string removeResult;
            try
            {
                removeResult = sIRepository.RemoveItem(itemToRemoveFromStock);
                return removeResult;
            }
            catch (Exception exception)
            {   
                throw exception;
            }
        }
    }
}
