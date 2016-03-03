﻿using System;
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

        public string RemoveItem(string nameOfItemToRemove)
        {
            string toremoveResult;
            item itemToRemove;
            using (var context = new ProjectDatabaseEntities())
            {
                itemToRemove = context.items.SingleOrDefault(x => x.name == nameOfItemToRemove);
                context.items.Remove(itemToRemove);
                toremoveResult = String.Format("{0} was successfully removed from the Database.", nameOfItemToRemove);
            }
            return toremoveResult;
        }
    }
}
