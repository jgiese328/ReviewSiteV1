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

        //[HttpGet]
        //public ActionResult Students()
        //{
        //    studentRepository = new StudentRepository();
        //    var students = studentRepository.GetAll();

        //    return View(students);
        //}

        public ActionResult Add()
        {
            ViewBag.Message = "Edit Posted Reviews.";
            return View();
        }


        [HttpPost]
        public ActionResult AddSave(Review review, HttpPostedFileBase upload)
        {
            if (!ModelState.IsValid)
            {
                return View("Enroll");
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
                review.Image = new List<Image> { image };
            }


            reviewRepository.Create(review);
            return RedirectToAction("Index", "Home");
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