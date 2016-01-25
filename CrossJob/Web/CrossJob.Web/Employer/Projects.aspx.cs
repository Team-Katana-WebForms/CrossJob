namespace CrossJob.Web
{
    using Services.Contracts;
    using Ninject;
    using System;
    using System.Web.UI;
    using Models;
    using System.Linq;
    using Microsoft.AspNet.Identity;

    public partial class Projects : Page
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
                .GetAllByEmployer(employerId);

            return projects;
        }

        protected string GetCategory(int projectId)
        {
            return null;
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
    }
}