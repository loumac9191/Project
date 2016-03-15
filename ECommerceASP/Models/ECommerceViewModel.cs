using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityFramework.Project;

namespace ECommerceASP.Models
{
    public class ECommerceViewModel
    {
        IItemRepository iRepo = new ItemRepository();
        public List<item> listOfItems = new List<item>();

        public ECommerceViewModel()
        {
            listOfItems = iRepo.RetrieveAllStockItems();
        }
    }
}