using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReviewSiteV1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        public ActionResult Index()
        {
            ViewBag.Message = "Select Action";
            return View();
        }

        public ActionResult Add()
        {
            ViewBag.Message = "Add Posted Reviews.";
            return View("Add");
        }

        public ActionResult Edit()
        {
            ViewBag.Message = "Edit Posted Reviews.";
            return View();
        }

        public ActionResult Remove()
        {
            ViewBag.Message = "Delete Posted Reviews.";
            return View();
        }
    }
}