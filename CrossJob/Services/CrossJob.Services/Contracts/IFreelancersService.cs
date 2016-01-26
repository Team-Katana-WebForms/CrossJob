namespace CrossJob.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface IFreelancersService
    {
        IQueryable<Freelancer> GetAllFreelancers();

        IQueryable<Freelancer> GetTopFreelancersByRating(int top);

        Freelancer GetFreelancerDetails(string userId);

        void DeleteFreelancer(string id);

        IQueryable<Freelancer> UpdateProfileFreelancer(Freelancer updatedUser);
    }
}