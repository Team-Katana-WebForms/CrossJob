namespace CrossJob.Services
{
    using System.Linq;
    using Contracts;
    using Data.Repositories;
    using Models;

    public class EmployersService : IEmployersService
    {
        private readonly IRepository<Employer> employers;

        public EmployersService(IRepository<Employer> employers)
        {
            this.employers = employers;
        }

        public void DeleteEmployer(string id)
        {
            this.employers.Delete(id);
            this.employers.SaveChanges();
        }

        public IQueryable<Employer> GetAllEmployers()
        {
            return this.employers.All();
        }

        public Employer GetEmployerrDetails(string userId)
        {
            return this.employers
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
    }
}
