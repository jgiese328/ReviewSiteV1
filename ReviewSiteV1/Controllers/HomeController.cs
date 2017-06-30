using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReviewSiteV1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Anime()
        {
            ViewBag.Message = "Anime Specific Reviews.";

            return View();
        }

        public ActionResult Movie()
        {
            ViewBag.Message = "Movie Specific Reviews.";

            return View();     
        }

        public ActionResult Game()
        {
            ViewBag.Message = "Game Specific Reviews.";

            return View();
        }

    }
}