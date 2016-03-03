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
            
            try
            {
                using (var context = new ProjectDatabaseEntities())
                {
                    itemToRetrieve = context.items.SingleOrDefault(x => x.name == nameOfItemToRetrieve);
                }
            }
            catch (Exception exception)
            {
                
                throw exception;
            }
            return itemToRetrieve;
        }

        //public item testingMethod(string testString)
        //{
        //    item itemToReturn;
        //    using (var context = new ProjectDatabaseEntities())
        //    {
        //        var query = (from i in context.items
        //                     where i.name == testString
        //                     select i);
        //        itemToReturn = (item)query;                
        //    }
        //    return itemToReturn;
        //}

        public string AddItem(string nameOfItem, string categoryOfItem, string itemDescriptionOfItem, decimal priceOfItem)
        {
            string toAddResult;
            item itemToAdd = null;

            try
            {
                //no item_id is given, this should be automatically generated
                itemToAdd.name = nameOfItem;
                itemToAdd.category = categoryOfItem;
                itemToAdd.item_description = itemDescriptionOfItem;
                itemToAdd.price = priceOfItem;

                using (var context = new ProjectDatabaseEntities())
                {
                    context.items.Add(itemToAdd);
                    context.SaveChanges();
                }
                toAddResult = String.Format("{0} has been added to the Database", itemToAdd.name);
                return toAddResult;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public string RemoveItem(string nameOfItemToRemove)
        {
            string toremoveResult;
            item itemToRemove;
            
            try
            {
                using (var context = new ProjectDatabaseEntities())
                {
                    itemToRemove = context.items.SingleOrDefault(x => x.name == nameOfItemToRemove);
                    context.items.Remove(itemToRemove);
                    context.SaveChanges();
                    toremoveResult = String.Format("{0} has been removed from the Database.", nameOfItemToRemove);
                    return toremoveResult;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
