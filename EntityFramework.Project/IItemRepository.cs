using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Project
{
    public interface IItemRepository
    {
        item RetrieveItemByName(string nameOfItemToAdd);
        string AddItem(string nameOfItem, string categoryOfItem, string itemDescriptionOfItem, decimal priceOfItem, int quantityOfItemToAdd);
        string RemoveItem(string nameOfItemToRemove, int itemsToRemove);
        string RegisterNewUser(string firstName, string lastName, string userName, string passWord);
        user LoginViaEntityFramework(string userName, string passWord);
        int GetStockCount(string itemToCount);
    }
}
