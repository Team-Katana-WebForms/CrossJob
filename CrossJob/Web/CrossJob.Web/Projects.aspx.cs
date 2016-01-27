namespace CrossJob.Web
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using Ninject;
    using Services.Contracts;

    public partial class Projects : Page
    {
        [Inject]
        public IProjectsService ProjectsService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<CrossJob.Models.Project> GridViewProjects_GetData()
        {
            return this.ProjectsService.GetAll().Where(p => p.FinishOn > DateTime.Now);
        }
    }
}