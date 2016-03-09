using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Project;

namespace ECommerce.Project
{
    public class LoginController
    {
        private IItemRepository iRepository;

        public LoginController()
        {
            iRepository = new ItemRepository();
        }

        public LoginController(IItemRepository iRepos)
        {
            iRepository = iRepos;
        }

        public string Login(string userName, string passWord)
        {
            string returnString;
            user currentUser;
            try
            {
                //try to create a user, then if it is null, then dont give that 
                //if the passwords null then.

                currentUser = iRepository.LoginViaEntityFramework(userName, passWord);

                if (currentUser == null)
                {
                    returnString = "The password you entered was incorrect. Please try again.";
                    return returnString;
                }
                else
                {
                    returnString = String.Format("Welcome {0}", currentUser.username);
                    return returnString;
                }
            }
            catch (Exception exception)
            {
                returnString = String.Format("You could not log in due to {0}, please try again", exception.Message);
                return returnString;
            }
        }

        public string Register(string firstName, string lastName, string userName, string passWord)
        {
            string returnString = iRepository.RegisterNewUser(firstName, lastName, userName, passWord);
            return returnString;       
        }
    }
}
