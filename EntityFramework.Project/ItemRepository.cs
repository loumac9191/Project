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

            if (_context.items.SingleOrDefault(x => x.name == nameOfItemToRetrieve) != null)
            {
                itemToRetrieve = _context.items.Single(x => x.name == nameOfItemToRetrieve);
                return itemToRetrieve;
            }
            else
            {
                itemToRetrieve = new item();                    
                return itemToRetrieve;
            }
        }

        public virtual string AddItem(string nameOfItem, string categoryOfItem, string itemDescriptionOfItem, decimal priceOfItem, int quantityOfItemToAdd)
        {
            string toAddResult;

            if (_context.items.SingleOrDefault(i => i.name == nameOfItem) == null)
	        {
                item itemToAdd = new item() 
                {
                    name = nameOfItem,
                    category = categoryOfItem,
                    item_description = itemDescriptionOfItem,
                    price = priceOfItem,
                    quantityOfItem = quantityOfItemToAdd
                };
                _context.items.Add(itemToAdd);
                _context.SaveChanges();
                toAddResult = String.Format("{0} has been added to the Database", itemToAdd.name);
                return toAddResult;             
	        }
            else
	        {                
                int totalOfItem = Convert.ToInt32(_context.items.SingleOrDefault(i => i.name == nameOfItem).quantityOfItem);
                
                _context.items.SingleOrDefault(i => i.name == nameOfItem).quantityOfItem += quantityOfItemToAdd;
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
            user userToLogin;

            if (_context.users.SingleOrDefault(x => x.username == userName) == null)
            {
                userToLogin = new user();
                return userToLogin;
            }
            else if (_context.users.SingleOrDefault(x => x.username == userName).user_password == passWord)
            {
                userToLogin = _context.users.SingleOrDefault(x => x.username == userName);
                return userToLogin;
            }
            else
            {
                userToLogin = new user();
                return userToLogin;
            }
        }

        public virtual string RegisterNewUser(string firstName, string lastName, string userName, string passWord)
        {
            string returnString;

            if (_context.users.SingleOrDefault(x => x.username == userName) == null)
            {
                user newUser = new user();
                newUser.username = userName;
                newUser.user_password = passWord;
                newUser.firstName = firstName;
                newUser.lastName = lastName;

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

        public virtual int GetStockCount(string nameOfItemToCount)
        {
            int countOfStock;

            if (_context.items.SingleOrDefault(x => x.name == nameOfItemToCount).quantityOfItem >= 1)
            {
                countOfStock = Convert.ToInt32(_context.items.SingleOrDefault(x => x.name == nameOfItemToCount).quantityOfItem);
                return countOfStock;
            }
            else
            {
                countOfStock = 0;
                return countOfStock;
            }
        }
    }
}
