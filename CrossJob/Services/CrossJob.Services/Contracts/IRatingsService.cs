namespace CrossJob.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface IRatingsService
    {
        IQueryable<Rating> GetById(int id);

        IQueryable<Rating> GetAllByUser(string userId, int skip, int take);

        IQueryable<Rating> GetAllByAuthor(string userId, int skip, int take);

        int AddNew(Rating rating, string userId, string authorId);
    }
}