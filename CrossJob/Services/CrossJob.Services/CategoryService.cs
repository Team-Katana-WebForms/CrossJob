namespace CrossJob.Services
{
    using System.Linq;
    using Contracts;
    using Data.Repositories;
    using Models;

    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categories;

        public CategoryService(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public int AddNew(string name)
        {
            var newCategory = new Category
            {
                Name = name
            };

            this.categories.Add(newCategory);
            this.categories.SaveChanges();

            return newCategory.ID;
        }

        public IQueryable<Category> GetAll()
        {
            return this.categories
                .All();
        }

        public IQueryable<Category> GetById(int id)
        {
            return this.categories
                .All()
                .Where(r => r.ID == id);
        }
    }
}
