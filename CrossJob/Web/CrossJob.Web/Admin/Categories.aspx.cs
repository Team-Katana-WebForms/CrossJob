namespace CrossJob.Web.Admin
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using Models;
    using Ninject;
    using Services.Contracts;
    using Utilities.Notifier;

    public partial class Categories : Page
    {
        [Inject]
        public ICategoriesService categoriesService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DynamicDataManager1.RegisterControl(this.CategoriesListView);
        }

        public IQueryable<Category> Categories_GetData()
        {
            return this.categoriesService.GetAll();
        }

        public void Categories_UpdateItem(int id)
        {
            Category cat = this.categoriesService.GetById(id);
            if (cat == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            TryUpdateModel(cat);
            if (ModelState.IsValid)
            {
                try
                {
                    this.categoriesService.UpdateCategory(cat);
                }
                catch (Exception ex)
                {
                    Notifier.Error("Sorry, cannot update category!" + ex.Message);
                }
            }

            Notifier.Success("Successfully updated the category!");
            Response.Redirect("~/Admin/Categories");
        }

        public void Categories_DeleteItem(int id)
        {
            if (this.categoriesService.GetById(id) == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            try
            {
                this.categoriesService.DeleteCategory(id);
            }
            catch (Exception ex)
            {
                Notifier.Error("Sorry, cannot delete this category." + ex.Message);
            }

            Notifier.Success("Successfully deleted the user!");
            Response.Redirect("~/Admin/Categories");
        }
    }
}