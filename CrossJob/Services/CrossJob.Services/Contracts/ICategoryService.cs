namespace CrossJob.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface ICategoryService
    {
        IQueryable<Category> GetAll(int skip, int take);

        IQueryable<Category> GetById(int id);

        int AddNew(string name);
    }
}