namespace CrossJob.Services
{
    using System;
    using System.Linq;
    using Contracts;
    using Data.Repositories;
    using Models;

    public class CategoriesService : ICategoriesService
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

        public void DeleteCategory(int id)
        {
            this.categories.Delete(id);
        }

        public IQueryable<Category> GetAll()
        {
            return this.categories
                .All()
                .OrderBy(c => c.Name);
        }

        public Category GetById(int id)
        {
            return this.categories
                .All()
                .Where(r => r.ID == id)
                .FirstOrDefault();
        }

        public Category GetByName(string name)
        {
            return this.categories
                .All()
                .Where(c => c.Name == name)
                .FirstOrDefault();
        }

        public IQueryable<Category> UpdateCategory(Category updatedCategory)
        {
            this.categories.Update(updatedCategory);
            this.categories.SaveChanges();

            return this.categories
                .All()
                .Where(r => r.ID == updatedCategory.ID);
        }
    }
}
