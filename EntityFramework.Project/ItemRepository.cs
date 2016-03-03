using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityFramework.Project
{
    public class ItemRepository : IItemRepository
    {
        public item RetrieveItemByName(string nameOfItemToAdd)
        {
            item itemToAdd;

            using (var context = new ProjectDatabaseEntities())
            {
                itemToAdd = context.items.SingleOrDefault(x => x.name == nameOfItemToAdd);
            }

            return itemToAdd;
        }

        public void RemoveItem(item itemToRemove)
        {

        }
    }
}
