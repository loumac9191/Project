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
        }

        public void Login(string userName, string passWord)
        {
            iRepository.LoginViaEntityFramework(userName, passWord);
        }

        public void Register(string firstName, string lastName, string userName, string passWord)
        {
            iRepository.RegisterNewUser(firstName, lastName, userName, passWord);
        }
    }
}
