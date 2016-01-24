namespace CrossJob.Services
{
    using System;
    using System.Linq;
    using Contracts;
    using Data.Repositories;
    using Models;

    public class RatingsService : IRatingService
    {
        private readonly IRepository<Rating> ratings;

        public RatingsService(IRepository<Rating> ratings)
        {
            this.ratings = ratings;
        }

        public int AddNew(Rating rating, string userId, string authorId)
        {
            rating.FreelancerID = userId;
            rating.EmployerID = authorId;

            this.ratings.Add(rating);
            this.ratings.SaveChanges();

            return rating.Id;
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
