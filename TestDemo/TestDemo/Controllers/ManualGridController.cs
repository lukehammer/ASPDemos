using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDemo.ViewModels;

namespace TestDemo.Controllers
{
    public class ManualGridController : Controller
    {
        // GET: ManualGrid
        public ActionResult Index()
        {
            DashboardViewModel model = new DashboardViewModel();
            
               return View(model);
        }

    }
}