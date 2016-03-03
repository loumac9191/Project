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
        IItemRepository sIRepository;
        
        public Stock(IItemRepository itemRepo)
        {
            sIRepository = itemRepo;
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
