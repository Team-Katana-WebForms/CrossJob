namespace CrossJob.Web
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using Ninject;
    using Services.Contracts;

    public partial class _Default : Page
    {
        [Inject]
        public IProjectsService ProjectsService { get; set; }

        [Inject]
        public IFreelancersService FreelancersService { get; set; }

        [Inject]
        public IEmployersService EmployersService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<CrossJob.Models.Freelancer> ListViewTopFreelancers_GetData()
        {
            return this.FreelancersService.GetTopFreelancersByRating(5);
        }

        public IQueryable<CrossJob.Models.Project> ListViewLatestProjects_GetData()
        {
            return this.ProjectsService.GetAllLatest(5);
        }
    }
}