namespace CrossJob.Services
{
    using System;
    using System.Linq;
    using Contracts;
    using Data.Repositories;
    using Models;

    public class RatingsService : IRatingsService
    {
        private readonly IRepository<Rating> ratings;

        public RatingsService(IRepository<Rating> ratings)
        {
            this.ratings = ratings;
        }

        public int AddNew(int rating, string userId, string authorId)
        {
            var newRating = new Rating()
            {
                Value = rating,
                FreelancerID = userId,
                EmployerID = authorId
            };

            this.ratings.Add(newRating);
            this.ratings.SaveChanges();

            return newRating.Id;
        }

        public IQueryable<Rating> GetAllByAuthor(string userId, int skip, int take)
        {
            return this.ratings
                .All()
                .Where(r => r.EmployerID == userId)
                .Skip(skip)
                .Take(take);
        }

        public IQueryable<Rating> GetAllByUser(string userId, int skip, int take)
        {
            return this.ratings
              .All()
              .Where(r => r.FreelancerID == userId)
              .Skip(skip)
              .Take(take);
        }

        public IQueryable<Rating> GetById(int id)
        {
            return this.ratings
                .All()
                .Where(r => r.Id == id);
        }
    }
}
