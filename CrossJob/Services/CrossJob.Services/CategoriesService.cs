namespace CrossJob.Services
{
    using System.Linq;
    using Contracts;
    using Data.Repositories;
    using Models;

    public class CategoriesService : ICategoryService
    {
        private readonly IRepository<Category> categories;

        public CategoriesService(IRepository<Category> categories)
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

        public IQueryable<Category> GetAll(int skip, int take)
        {
            return this.categories
                .All()
                .Skip(skip)
                .Take(take);
        }

        public IQueryable<Category> GetById(int id)
        {
            return this.categories
                .All()
                .Where(r => r.ID == id);
        }
    }
}
