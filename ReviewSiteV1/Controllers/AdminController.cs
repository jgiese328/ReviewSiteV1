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

        // select action here
        public ActionResult Index()
        {
            ViewBag.Message = "Select Action";
            return View();
        }

        // load add view
        public ActionResult Add()
        {
            return View();
        }

        // add save
        [HttpPost]
        public ActionResult AddSave(Review review, HttpPostedFileBase upload)
        {

            // missing PublishDate
            if (review.PublishDate == DateTime.MinValue)
            {
                TempData["Error"] = TempData["Error"] + " Publish Date was empty";
            }


            // missing Type
            if (String.IsNullOrEmpty(review.ReviewType))
            {
                TempData["Error"] = TempData["Error"] + " Review Type was empty";
            }


            // Odd way to handle empty image, but it works
            try
            {
                if (upload.GetType() == typeof(HttpPostedFileBase))
                {
                    // This will never hit
                    TempData["Error"] = null;
                }
            }
            catch {
                TempData["Error"] = TempData["Error"] + " Image was not uploaded correctly";
            }

            // missing header
            if (String.IsNullOrEmpty(review.ReviewHeader))
            {
                TempData["Error"] = TempData["Error"] + " Title was empty";
            }


            // missing review
            if (String.IsNullOrEmpty(review.ReviewText))
            {
                TempData["Error"] = TempData["Error"] + " Review was empty";
            }

            // return with error
            if (TempData["Error"] != null)
            {
                return View("Add");
            }


            if (upload.ContentLength > 3500000)
            {
                TempData["Error"] = "File Size is Too Large";
                return View("Add");
            }


            // final catch if somehow there is an issue, but gets by other checks
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Unable to process, form data was missing";
                return View("Add");
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

        // action to populate image on the view
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

        // edit view load
        public ActionResult Edit()
        {
            var reviewRepository = new ReviewRepository();
            var ReviewList = reviewRepository.GetAll();
            return View(ReviewList);
        }

        // loading modify page after line is chosen for update
        [HttpPost]
        public ActionResult EditModify(int id)
        {
            var reviewRepository = new ReviewRepository();
            var reviewToModify = reviewRepository.GetById(id);
            return View(reviewToModify);
        }

        // submitting changes
        [HttpPost]
        public ActionResult EditSubmit(Review review)
        {
            // missing PublishDate
            if (review.PublishDate == DateTime.MinValue)
            {
                TempData["Error"] = TempData["Error"] + " Publish Date was empty";
            }

            // missing Type
            if (String.IsNullOrEmpty(review.ReviewType))
            {
                TempData["Error"] = TempData["Error"] + " Review Type was empty";
            }

            // missing header
            if (String.IsNullOrEmpty(review.ReviewHeader))
            {
                TempData["Error"] = TempData["Error"] + " Title was empty";
            }


            // missing review
            if (String.IsNullOrEmpty(review.ReviewText))
            {
                TempData["Error"] = TempData["Error"] + " Review was empty";
            }

            // return with error
            if (TempData["Error"] != null)
            {
                var ReviewRepository = new ReviewRepository();
                return View("EditModify", ReviewRepository.GetById(review.Id));
            }

            // final catch if somehow there is an issue, but gets by other checks
            if (!ModelState.IsValid)
            {
                var ReviewRepository = new ReviewRepository();
                TempData["Error"] = "Unable to process, form data was missing";
                return View("EditModify", ReviewRepository.GetById(review.Id));
            }

            var reviewRepository = new ReviewRepository();
            int changedId = reviewRepository.Update(review);
            TempData["Success"] = "Successfully Updated Review " + review.Id;
            return View("Index");
        }

        // load remove view
        public ActionResult Remove()
        {
            var reviewRepository = new ReviewRepository();
            var ReviewList = reviewRepository.GetAll();
            return View(ReviewList);
        }

        // saving remove action
        [HttpPost]
        public ActionResult RemoveSave(int id)
        {
            var reviewRepository = new ReviewRepository();

            // check if default hidden value is passed -- means empty form 
            if (id == 0)
            {
                TempData["Error"] = "Unable to process, no ID was specified";
                var ReviewList = reviewRepository.GetAll();
                return View("Remove", ReviewList);
            }

            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Unable to process, no ID was specified";
                var ReviewList = reviewRepository.GetAll();
                return View("Remove");
            }

            reviewRepository.Delete(id);
            TempData["Success"] = "Successfully Deleted Review " + id;
            return View("Index");
        }


    }
}