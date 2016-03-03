using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityFramework.Project
{
    public class ItemRepository : IItemRepository
    {
        public virtual item RetrieveItemByName(string nameOfItemToRetrieve)
        {
            item itemToRetrieve;

            using (var context = new ProjectDatabaseEntities())
            {
                itemToRetrieve = context.items.SingleOrDefault(x => x.name == nameOfItemToRetrieve);
            }

            return itemToRetrieve;
        }

        public void RemoveItem(item itemToRemove)
        {

        }
    }
}
