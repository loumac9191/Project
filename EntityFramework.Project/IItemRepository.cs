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
        //item testingMethod(string testString);
        string AddItem(string nameOfItem, string categoryOfItem, string itemDescriptionOfItem, decimal priceOfItem);
        string RemoveItem(string nameOfItemToRemove);
    }
}
