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
                //this used to have a using statement
                itemToRetrieve = _context.items.SingleOrDefault(x => x.name == nameOfItemToRetrieve);
                return itemToRetrieve;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            //return itemToRetrieve;
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

        public virtual string AddItem(string nameOfItem, string categoryOfItem, string itemDescriptionOfItem, decimal priceOfItem, int quantityOfItemToAdd)
        {
            string toAddResult;
            item itemToAdd = new item();

            itemToAdd.name = nameOfItem;

            if (_context.items.SingleOrDefault(i => i.name == itemToAdd.name) == null)
	        {            
                itemToAdd.category = categoryOfItem;
                itemToAdd.item_description = itemDescriptionOfItem;
                itemToAdd.price = priceOfItem;
                itemToAdd.quantityOfItem = quantityOfItemToAdd;
                _context.items.Add(itemToAdd);
                _context.SaveChanges();
                toAddResult = String.Format("{0} has been added to the Database", itemToAdd.name);
                return toAddResult;
                
	        }
            else
	        {                
                int totalOfItem = Convert.ToInt32(_context.items.SingleOrDefault(i => i.name == nameOfItem).quantityOfItem);
                
                _context.items.SingleOrDefault(i => i.name == itemToAdd.name).quantityOfItem += quantityOfItemToAdd;
                _context.SaveChanges();
                toAddResult = String.Format("There are now a total of {0} of {1} in stock", (totalOfItem+quantityOfItemToAdd), nameOfItem);
                return toAddResult;
	        }
        }

        public virtual string RemoveItem(string nameOfItemToRemove,int quantityToRemove)
        {
            string toremoveResult;
            item itemToRemove;

            if (_context.items.SingleOrDefault(x => x.name == nameOfItemToRemove) != null)
            {
                int totalInDb = Convert.ToInt32(_context.items.SingleOrDefault(x => x.name == nameOfItemToRemove).quantityOfItem);
                
                if (totalInDb == quantityToRemove)
                {
                    itemToRemove = _context.items.SingleOrDefault(x => x.name == nameOfItemToRemove);
                    _context.items.Remove(itemToRemove);
                    _context.SaveChanges();
                    toremoveResult = String.Format("{0} has been removed from the database", nameOfItemToRemove);
                    return toremoveResult;
                }
                else
                {
                    _context.items.SingleOrDefault(x => x.name == nameOfItemToRemove).quantityOfItem -= quantityToRemove;
                    _context.SaveChanges();
                    toremoveResult = String.Format("There are now a total of {0} of {1} in stock",(totalInDb-quantityToRemove),nameOfItemToRemove);
                    return toremoveResult;
                }
            }
            else
            {
                toremoveResult = String.Format("{0} could not be removed as this does not exist within the database", nameOfItemToRemove);
                return toremoveResult;
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
                newUser.firstName = firstName;
                newUser.lastName = lastName;
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
                returnString = String.Format("The following exception was thrown: {0}", exception.Message);
                return returnString;
            }
        }
    }
}
