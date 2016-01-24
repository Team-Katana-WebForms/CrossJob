namespace CrossJob.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface IUserService
    {
        IQueryable<Freelancer> GetAllFreelancers(int skip, int take);

        IQueryable<Employer> GetAllEmployers(int skip, int take);

        IQueryable<Freelancer> GetFreelancerDetails(string username);

        IQueryable<Employer> GetEmployerrDetails(string username);

        void DeleteEmployer(string id);

        void DeleteFreelancerr(string id);

        IQueryable<Freelancer> UpdateProfileFreelancer(Freelancer updatedUser);

        IQueryable<Employer> UpdateProfileEmployer(Employer updatedUser);
    }
}