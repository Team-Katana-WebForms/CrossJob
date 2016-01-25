namespace CrossJob.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface ICategoryService
    {
        IQueryable<Category> GetAll();

        IQueryable<Category> GetById(int id);

        int AddNew(string name);
    }
}