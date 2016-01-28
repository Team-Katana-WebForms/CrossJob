namespace CrossJob.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Caching;
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
            this.Statistics.DataSource = this.Cache["statistics"];
            this.Statistics.DataBind();

            if (this.Cache["statistics"] == null)
            {
                var data = ListViewStatistics_GetData();
                this.Statistics.DataSource = data;
                this.Statistics.DataBind();
                Cache.Insert(
                    "statistics",                     // key
                    data,                             // value
                    null,                             // dependencies
                    DateTime.Now.AddSeconds(60),      // absolute exp.
                    TimeSpan.Zero,                    // sliding exp.
                    CacheItemPriority.Default,        // priority
                    this.OnCacheItemRemovedCallback); // callback delegate
            }
        }

        private void OnCacheItemRemovedCallback(string key, object value, CacheItemRemovedReason reason)
        {
            this.Statistics.DataSource = ListViewStatistics_GetData();
            this.Statistics.DataBind();
        }

        public IQueryable<Models.Freelancer> ListViewTopFreelancers_GetData()
        {
            return this.FreelancersService.GetTopFreelancersByRating(5);
        }

        public IQueryable<Models.Project> ListViewLatestProjects_GetData()
        {
            return this.ProjectsService.GetAllLatest(5);
        }

        public List<int> ListViewStatistics_GetData()
        {
            List<int> statistics = new List<int>();
            statistics.Add(this.FreelancersService.GetAllFreelancers().ToList().Count);
            statistics.Add(this.EmployersService.GetAllEmployers().ToList().Count);
            statistics.Add(this.ProjectsService.GetAll().ToList().Count);

            return statistics;
        }
    }
}