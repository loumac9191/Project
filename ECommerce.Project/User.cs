using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Project;

namespace ECommerce.Project
{
    public class User
    {
        private IItemRepository iRepository;

        public User(IItemRepository iRepos)
        {
            iRepository = iRepos;
            user currentUser = null;
        }

        public string Login(string userName, string passWord)
        {
            try
            {
                //try to create a user, then if it is null, then dont give that 
                //if the passwords null then.

                currentUser = iRepository.LoginViaEntityFramework(userName, passWord);
                
                if (true)
                {

                }
            }
            catch (Exception)
            {
                
                throw;
            }

            user = iRepository.LoginViaEntityFramework(userName, passWord);
        }

        public void Register(string firstName, string lastName, string userName, string passWord)
        {
            iRepository.RegisterNewUser(firstName, lastName, userName, passWord);
        }
    }
}
