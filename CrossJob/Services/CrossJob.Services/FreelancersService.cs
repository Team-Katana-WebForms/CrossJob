namespace CrossJob.Services
{
    using System.Linq;
    using Contracts;
    using Data.Repositories;
    using Models;

    public class FreelancersService : IFreelancersService
    {
        private readonly IRepository<Freelancer> freelancers;

        public FreelancersService(IRepository<Freelancer> freelancers)
        {
            this.freelancers = freelancers;
        }

        public void DeleteFreelancer(string id)
        {
            this.freelancers.Delete(id);
            this.freelancers.SaveChanges();
        }

        public IQueryable<Freelancer> GetAllFreelancers()
        {
            return this.freelancers.All();
        }

        public IQueryable<Freelancer> GetTopFreelancersByRating(int top)
        {
            var result = this.freelancers
                .All()
                .ToList()
                .OrderByDescending(f => f.Ratings.Any() ? f.Ratings.Average(r => r.Value) : 0)
                .ThenByDescending(f => f.Projects.Count)
                .Take(top)
                .AsQueryable();
            return result;
        }

        public Freelancer GetFreelancerDetails(string userId)
        {
            return this.freelancers
             .All()
             .Where(r => r.Id == userId)
             .FirstOrDefault();
        }

        public IQueryable<Freelancer> UpdateProfileFreelancer(Freelancer updatedUser)
        {
            this.freelancers.Update(updatedUser);
            this.freelancers.SaveChanges();

            return this.freelancers
                .All()
                .Where(r => r.Id == updatedUser.Id);
        }
    }
}
