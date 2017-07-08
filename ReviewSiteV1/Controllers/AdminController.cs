using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReviewSiteV1.Repositories;
using ReviewSiteV1.Models;

namespace ReviewSiteV1.Controllers
{
    public class AdminController : Controller
    {
        private ReviewRepository reviewRepository;
        // GET: Admin

        public ActionResult Index()
        {
            ViewBag.Message = "Select Action";
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSave(Review review, HttpPostedFileBase upload)
        {
            ViewBag.Error = "";

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (upload.ContentLength > 3500000)
            {
                ViewBag.Error = "File Size is Too Large";
                return View();
            }

            reviewRepository = new ReviewRepository();

            if (upload != null && upload.ContentLength > 0)
            {
                var image = new Image
                {
                    ImageName = System.IO.Path.GetFileName(upload.FileName),
                    ContentType = upload.ContentType
                };
                using (var reader = new System.IO.BinaryReader(upload.InputStream))
                {
                    image.ImageData = reader.ReadBytes(upload.ContentLength);
                }
                review.Image = image;
            }

            reviewRepository.Create(review);

            TempData["Success"] = "Successfully Added Review ";
            return View("Index");
            // If I ever wanted to show addition right away:
            // return RedirectToAction("Index", "Home");
        }

        public ActionResult GetImage(int imageId)
        {
            if (imageId != 0)
            {
                reviewRepository = new ReviewRepository();
                var image = reviewRepository.GetImageById(imageId);
                
                foreach (KeyValuePair<string, byte[]> pair in image)
                {
                    return new FileContentResult(pair.Value, pair.Key);
                }
                return View("Index");

            }
            else
                return View("Index");
        }


        public ActionResult Edit()
        {
            var reviewRepository = new ReviewRepository();
            var ReviewList = reviewRepository.GetAll();
            return View(ReviewList);
        }

        public ActionResult Remove()
        {
            var reviewRepository = new ReviewRepository();
            var ReviewList = reviewRepository.GetAll();
            return View(ReviewList);
        }

        [HttpPost]
        public ActionResult RemoveSave(int id)
        {
            var reviewRepository = new ReviewRepository();
            reviewRepository.Delete(id);
            TempData["Success"] = "Successfully Deleted Review " + id;
            return View("Index");
        }


    }
}