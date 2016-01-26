namespace CrossJob.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface ICategoriesService
    {
        IQueryable<Category> GetAll();

        Category GetById(int id);

        IQueryable<Category> UpdateCategory(Category updatedCategory);

        int AddNew(string name);

        void DeleteCategory(int id);
    }
}