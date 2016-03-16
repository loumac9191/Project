using ECommerceASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceASP.Controllers
{
    public class ECommerceController : Controller
    {
        // GET: ECommerce
        public ActionResult Index()
        {
            ECommerceViewModel vm = new ECommerceViewModel();
            return View(vm);
        }
    }
}