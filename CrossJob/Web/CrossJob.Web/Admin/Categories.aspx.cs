namespace CrossJob.Web.Admin
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using Models;
    using Ninject;
    using Services.Contracts;
    using Controls.Notifier;

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
            this.HiddenfieldDeleteId.Text = id.ToString();
            this.ModalWindow.Show();
        }

        protected void ModalWindow_OKButtonClicked(object sender, EventArgs e)
        {
            var id = int.Parse(this.HiddenfieldDeleteId.Text);
            var category = this.categoriesService.GetById(id);
            if (category == null)
            {
                Notifier.Warning(String.Format("Item with id {0} was not found", id));
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            if (category.Projects.Count > 0)
            {
                Notifier.Warning("Cannot delete category with projects in it!");
                return;
            }

            try
            {
                this.categoriesService.DeleteCategory(id);
            }
            catch (Exception ex)
            {
                Notifier.Error("Sorry, cannot delete this category." + ex.Message);
                return;
            }

            Notifier.Success("Successfully deleted the category!");
            Response.Redirect("~/Admin/Categories");
        }

        public void Categories_InsertItem(string name)
        {
            var test = this.categoriesService.GetByName(name);
            if (test != null)
            {
                Notifier.Warning("There is already such directory!");
                return;
            }

            try
            {
                this.categoriesService.AddNew(name);
            }
            catch (Exception ex)
            {
                Notifier.Error("Sorry, cannot delete this category." + ex.Message);
                return;
            }

            Notifier.Success("Successfully added new category!");
            Response.Redirect("~/Admin/Categories");
        }
    }
}