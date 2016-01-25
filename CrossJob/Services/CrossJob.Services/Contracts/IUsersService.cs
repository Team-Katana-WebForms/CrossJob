namespace CrossJob.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface IUsersService
    {
        IQueryable<Freelancer> GetAllFreelancers(int skip, int take);

        IQueryable<Employer> GetAllEmployers(int skip, int take);

        Freelancer GetFreelancerDetails(string userId);

        Employer GetEmployerrDetails(string userId);

        void DeleteEmployer(string id);

        void DeleteFreelancerr(string id);

        IQueryable<Freelancer> UpdateProfileFreelancer(Freelancer updatedUser);

        IQueryable<Employer> UpdateProfileEmployer(Employer updatedUser);
    }
}