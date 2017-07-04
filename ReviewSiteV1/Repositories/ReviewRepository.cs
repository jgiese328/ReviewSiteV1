using ReviewSiteV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewSiteV1.Repositories
{
    public class ReviewRepository
    {
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

        public void Update(Review review)
        {
            using (var context = new Context())
            {
                var reviewToUpdate = context.Reviews.Find(review.Id);
                reviewToUpdate.Id = review.Id;

                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new Context())
            {
                var reviewToRemove = context.Reviews.Find(id);
                context.Reviews.Remove(reviewToRemove);

                context.SaveChanges();
            }
        }

        public List<Review> GetAll()
        {
            List<Review> reviews = new List<Review>();
            using (var context = new Context())
            {
                reviews = context.Reviews.Include("Image").ToList();
                return reviews;
            }
        }

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

        public Review GetById(int id)
        {
            Review review = null;
            using (var context = new Context())
            {
                review = context.Reviews.Find(id);
            }
            return review;
        }

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