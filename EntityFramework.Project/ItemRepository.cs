using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Project
{
    public class ItemRepository
    {
        public void testRead()
        {
            string test;
            using (var context = new ProjectDatabaseEntities())
            {
                //foreach (var item in context)
                //{
                //    string test;
                //}
            }
        }
    }
}
