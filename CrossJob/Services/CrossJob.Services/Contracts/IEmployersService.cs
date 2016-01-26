namespace CrossJob.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface IEmployersService
    {
        IQueryable<Employer> GetAllEmployers();

        Employer GetEmployerrDetails(string userId);

        void DeleteEmployer(string id);

        IQueryable<Employer> UpdateProfileEmployer(Employer updatedUser);
    }
}