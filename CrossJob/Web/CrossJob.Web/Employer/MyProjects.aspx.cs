namespace CrossJob.Employer
{
    using Services.Contracts;
    using Ninject;
    using System;
    using System.Web.UI;
    using Models;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using System.Web.UI.WebControls;
    using Controls.Notifier;

    public partial class MyProjects : Page
    {
        [Inject]
        public IProjectsService ProjectsService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Project> ViewAllProjects_GetData()
        {
            var employerId = this.User.Identity.GetUserId();
            var projects = this.ProjectsService
                .GetAllProjectsOfUser(employerId, true);

            return projects;
        }

        protected string GetCategory(int projectId)
        {
            return null;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ViewAllProjects_DeleteItem(int id)
        {
            this.ProjectsService.DeleteProject(id);
            Notifier.Success("Project was delete successfully");
        }
    }
}