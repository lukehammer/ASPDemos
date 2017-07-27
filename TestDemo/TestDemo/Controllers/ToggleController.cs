using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDemo.ViewModels;

namespace TestDemo.Controllers
{
    public class ToggleController : Controller
    {
        // GET: Toggle
        public ActionResult Index()
        {
            var model = new ToggleVm {Good = true, Bad = false};

            return View(model);
        }

        public ActionResult ajax(ToggleVm model)
        {

            return View("Index", model);
        }
    }
}