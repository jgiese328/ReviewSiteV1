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
        // Main view page
        public ActionResult Index()
        {
            var reviewRepository = new ReviewRepository();
            var ReviewList = reviewRepository.GetAll();
            return View(ReviewList);
        }

        // The following are all locked to respective types

        public ActionResult Anime()
        {
            ViewBag.Message = "Anime Specific Reviews.";
            var reviewRepository = new ReviewRepository();
            var ReviewList = reviewRepository.GetAll("Anime");
            return View(ReviewList);
        }

        public ActionResult Movie()
        {
            ViewBag.Message = "Movie Specific Reviews.";
            var reviewRepository = new ReviewRepository();
            var ReviewList = reviewRepository.GetAll("Movie");
            return View(ReviewList);
        }

        public ActionResult Game()
        {
            ViewBag.Message = "Game Specific Reviews.";
            var reviewRepository = new ReviewRepository();
            var ReviewList = reviewRepository.GetAll("Game");
            return View(ReviewList);
        }

    }
}