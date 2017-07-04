using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReviewSiteV1.Repositories;

namespace ReviewSiteV1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var reviewRepository = new ReviewRepository();
            var ReviewList = reviewRepository.GetAll();
            return View(ReviewList);
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

        public ActionResult GetImage(int imageId)
        {
            // https://msdn.microsoft.com/en-us/library/system.web.mvc.filecontentresult.filecontentresult(v=vs.118).aspx#M:System.Web.Mvc.FileContentResult.
            throw new NotImplementedException();
        }

    }
}