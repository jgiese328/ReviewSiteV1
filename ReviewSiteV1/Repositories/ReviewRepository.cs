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
                reviews = context.Reviews.ToList();
            }

            return reviews;
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
    }
}