using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using TestDemo.ViewModels;

namespace TestDemo.Controllers
{
    public class DevExpressController : Controller
    {
        // GET: DevExpress
        public ActionResult Index()
        {
            DashboardViewModel model = new DashboardViewModel();
            ViewData["ProductID"] = model.Product.ProductID;
            ViewData["Headers"] = model.TaskHeaders;
            return View(model);
        }


        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = new DashboardViewModel();
            ViewData["ProductID"] = model.Product.ProductID;
            ViewData["Headers"] = model.TaskHeaders;
            return PartialView("_GridViewPartial", model.Rows);
        }

        public JsonResult UpdateData(string data)
        {
            try
            {
                Console.Write(data);
                return Json("OK");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }


        //[HttpPost, ValidateInput(false)]
        //public ActionResult GridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] TestDemo.ViewModels.DashboardViewModel item)
        //{
        //    DashboardViewModel model = new DashboardViewModel();
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // Insert here a code to insert the new item in your model
        //        }
        //        catch (Exception e)
        //        {
        //            ViewData["EditError"] = e.Message;
        //        }
        //    }
        //    else
        //        ViewData["EditError"] = "Please, correct all errors.";
        //    return PartialView("_GridViewPartial", model);
        //}
        //[HttpPost, ValidateInput(false)]
        //public ActionResult GridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] TestDemo.ViewModels.DashboardViewModel item)
        //{
        //    var model = new DashboardViewModel();
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // Insert here a code to update the item in your model
        //        }
        //        catch (Exception e)
        //        {
        //            ViewData["EditError"] = e.Message;
        //        }
        //    }
        //    else
        //        ViewData["EditError"] = "Please, correct all errors.";
        //    return PartialView("_GridViewPartial", model);
        //}

    }
}
