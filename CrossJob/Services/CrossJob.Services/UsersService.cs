﻿namespace CrossJob.Services
{
    using System;
    using System.Linq;
    using Contracts;
    using Data.Repositories;
    using Models;

    public class UsersService : IUsersService
    {
        private readonly IRepository<Employer> employers;
        private readonly IRepository<Freelancer> freelancers;
        private readonly IRepository<User> users;


        public UsersService(IRepository<Employer> employers, IRepository<Freelancer> freelancers, IRepository<User> users)
        {
            this.employers = employers;
            this.freelancers = freelancers;
            this.users = users;
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

        public IQueryable<Employer> GetAllEmployers()
        {
            return this.employers.All();
        }

        public IQueryable<Freelancer> GetAllFreelancers()
        {
            return this.freelancers.All();
        }

        public IQueryable<Freelancer> AllFreelancers()
        {
            return this.freelancers
                .All();
        }

        public IQueryable<Freelancer> GetTopFreelancersByRating(int top)
        {
            var result = this.freelancers
                .All()
                .ToList()
                .OrderByDescending(f => f.AverageRating)
                .ThenByDescending(f => f.Projects.Count)
                .Take(top)
                .AsQueryable();
            return result;
        }

        public Employer GetEmployerrDetails(string userId)
        {
            return this.employers
                .All()
                .Where(r => r.Id == userId)
                .FirstOrDefault();
        }

        public Freelancer GetFreelancerDetails(string userId)
        {
            return this.freelancers
             .All()
             .Where(r => r.Id == userId)
             .FirstOrDefault();
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
