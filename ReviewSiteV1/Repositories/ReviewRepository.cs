using ReviewSiteV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewSiteV1.Repositories
{
    public class ReviewRepository
    {
        //Adds to the database the review and image passed in
        public void Create(Review review)
        {
            using (var context = new Context())
            {
                if(review.Image!=null)
                    context.Images.Add(review.Image);

                context.Reviews.Add(review);

                context.SaveChanges();
            }
        }

        // Updates existing review -- minus the image. By design, if image needs changing, delete and re-add
        public int Update(Review review)
        {
            using (var context = new Context())
            {
                var reviewToUpdate = context.Reviews.Find(review.Id);

                // updating each field, apart from image info
                reviewToUpdate.ReviewType = review.ReviewType;
                reviewToUpdate.PublishDate = review.PublishDate;
                reviewToUpdate.ReviewHeader = review.ReviewHeader;
                reviewToUpdate.ReviewText = review.ReviewText;

                context.SaveChanges();
                return reviewToUpdate.Id;
            }
        }

        // Removes the line of both image and review, handled in the Remove method
        public void Delete(int id)
        {
            using (var context = new Context())
            {
                var reviewToRemove = context.Reviews.Find(id);
                context.Reviews.Remove(reviewToRemove);

                context.SaveChanges();
            }
        }

        // Pulls ALL results, including the images from the Images table
        public List<Review> GetAll()
        {
            List<Review> reviews = new List<Review>();
            using (var context = new Context())
            {
                reviews = context.Reviews.Include("Image").ToList();
                return reviews;
            }
        }

        // Locking down to specific types for the individual review tabs
        public List<Review> GetAll(string type)
        {
            List<Review> reviews = new List<Review>();
            using (var context = new Context())
            {
                reviews = context.Reviews.ToList();
                var results = reviews.Where(x=>x.ReviewType == type);
                return results.ToList();
            }            
        }

        // Pull individual, used for Edit screen -- NOT pulling image in here, if needed, delete and re-add the review
        public Review GetById(int id)
        {
            Review review = null;
            using (var context = new Context())
            {
                review = context.Reviews.Find(id);
            }
            return review;
        }

        // Populating the image data and type to properly display to the screen
        public Dictionary<string, byte[]> GetImageById(int id)
        {
            Image image = null;
            using (var context = new Context())
            {
                image = context.Images.Find(id);
                Dictionary<string, byte[]> dictionary = new Dictionary<string, byte[]>();
                dictionary.Add(image.ContentType, image.ImageData);
                return dictionary;
            }
        }
    }
}