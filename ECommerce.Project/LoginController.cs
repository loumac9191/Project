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
            user currentUser = iRepository.LoginViaEntityFramework(userName, passWord);
            if (currentUser.firstName != null || currentUser.firstName == "")
            {
                returnString = String.Format("Welcome {0}", userName);
                return returnString;
            }
            else
            {
                returnString = "The username/password that you entered was incorrect. Please try again.";
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
