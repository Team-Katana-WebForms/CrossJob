namespace CrossJob.Services
{
    using System;
    using System.Linq;
    using Contracts;
    using Data.Repositories;
    using Models;

    public class UserService : IUserService
    {
        private readonly IRepository<Employer> employers;
        private readonly IRepository<Freelancer> freelancers;


        public UserService(IRepository<Employer> employers, IRepository<Freelancer> freelancers)
        {
            this.employers = employers;
            this.freelancers = freelancers;
        }

        public void DeleteEmployer(string id)
        {
            this.employers.Delete(id);
            this.employers.SaveChanges();
        }

        public void DeleteFreelancerr(string id)
        {
            this.freelancers.Delete(id);
            this.freelancers.SaveChanges();
        }

        public IQueryable<Employer> GetAllEmployers(int skip, int take)
        {
            return this.employers
                .All()
                .Skip(skip)
                .Take(take);
        }

        public IQueryable<Freelancer> GetAllFreelancers(int skip, int take)
        {
            return this.freelancers
                .All()
                .Skip(skip)
                .Take(take);
        }

        public IQueryable<Employer> GetEmployerrDetails(string username)
        {
            return this.employers
                .All()
                .Where(r => r.UserName == username);
        }

        public IQueryable<Freelancer> GetFreelancerDetails(string username)
        {
            return this.freelancers
             .All()
             .Where(r => r.UserName == username);
        }

        public IQueryable<Employer> UpdateProfileEmployer(Employer updatedUser)
        {
            this.employers.Update(updatedUser);
            this.employers.SaveChanges();

            return this.employers
                .All()
                .Where(r => r.Id == updatedUser.Id);
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
