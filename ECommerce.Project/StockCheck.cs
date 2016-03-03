using EntityFramework.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Project
{
    public class StockCheck
    {
        IItemRepository sIRepository;
        
        public StockCheck(IItemRepository itemRepo)
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
    }
}
