namespace CrossJob.Web.Admin
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using Models;
    using Ninject;
    using Services.Contracts;
    using Controls.Notifier;

    public partial class Projects1 : Page
    {
        [Inject]
        public IProjectsService projectsService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DynamicDataManager1.RegisterControl(this.ProjectListView);
        }

        public IQueryable<Project> Projects_GetData()
        {
            var result = this.projectsService.GetAll();
            return result;
        }

        public void Projects_UpdateItem(int id)
        {
            Project project = this.projectsService.GetById(id);
            if (project == null)
            {
                Notifier.Warning(String.Format("Item with id {0} was not found", id));
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            TryUpdateModel(project);
            if (ModelState.IsValid)
            {
                try
                {
                    this.projectsService.Update(project);
                }
                catch (Exception ex)
                {
                    Notifier.Error("Sorry, cannot update project!" + ex.Message);
                }
            }

            Notifier.Success("Successfully updated the project!");
            Response.Redirect("~/Admin/Projects");
        }

        public void Projects_DeleteItem(int id)
        {
            this.HiddenfieldDeleteId.Text = id.ToString();
            this.ModalWindow.Show();
        }

        protected void ModalWindow_OKButtonClicked(object sender, EventArgs e)
        {
            var id = int.Parse(this.HiddenfieldDeleteId.Text);
            if (this.projectsService.GetById(id) == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            try
            {
                this.projectsService.DeleteProject(id);
            }
            catch (Exception ex)
            {
                Notifier.Error("Sorry, cannot delete this project." + ex.Message);
            }

            Notifier.Success("Successfully deleted the project!");
            Response.Redirect("~/Admin/Projects");
        }
    }
}