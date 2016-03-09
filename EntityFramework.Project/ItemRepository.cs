using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityFramework.Project
{
    public class ItemRepository : IItemRepository
    {
        private ProjectDatabaseEntities _context;

        public ItemRepository()
        {
            _context = new ProjectDatabaseEntities();
        }

        public ItemRepository(ProjectDatabaseEntities context)
        {
            _context = context;
        }

        public virtual item RetrieveItemByName(string nameOfItemToRetrieve)
        {
            item itemToRetrieve;
            
            try
            {
                using (_context)
                {
                    itemToRetrieve = _context.items.SingleOrDefault(x => x.name == nameOfItemToRetrieve);
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

        public virtual string AddItem(string nameOfItem, string categoryOfItem, string itemDescriptionOfItem, decimal priceOfItem)
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

        public virtual string RemoveItem(string nameOfItemToRemove)
        {
            string toremoveResult;
            item itemToRemove;
            
            try
            {
                using (_context)
                {
                    itemToRemove = _context.items.SingleOrDefault(x => x.name == nameOfItemToRemove);
                    _context.items.Remove(itemToRemove);
                    _context.SaveChanges();
                    toremoveResult = String.Format("{0} has been removed from the Database.", nameOfItemToRemove);
                    return toremoveResult;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual user LoginViaEntityFramework(string userName, string passWord)
        {
            try
            {
                using (_context)
                {
                    user userToLogIn = _context.users.SingleOrDefault(x => x.username == userName);

                    if (userToLogIn.user_password == passWord)
                    {
                        return userToLogIn;
                    }
                    else
                	{
                        return null;
                	}
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual string RegisterNewUser(string firstName, string lastName, string userName, string passWord)
        {           
            string returnString;

            try
            {
                user newUser = new user();
                newUser.username = userName;
                newUser.user_password = passWord;
                using (_context)
                {
                    if (_context.users.Count(x => x.username == newUser.username) < 1)
                    {
                        _context.users.Add(newUser);
                        _context.SaveChanges();
                        returnString = String.Format("{0} has been added to the database", userName);
                        return returnString;
                    }
                    else
                    {
                        returnString = String.Format("{0} already exists on the database", userName);
                        return returnString;
                    }
                }
            }
            catch (Exception exception)
            {
                returnString = String.Format("The following exception was thrown: {0}",exception.Message);
                return returnString;
            }
        }
    }
}
