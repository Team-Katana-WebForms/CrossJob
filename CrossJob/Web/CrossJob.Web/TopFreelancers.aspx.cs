using CrossJob.Services.Contracts;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace CrossJob.Web
{
    public partial class TopFreelancers : System.Web.UI.Page
    {
        [Inject]
        public IUsersService UsersService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Models.Freelancer> ListViewTop10Freelancers_GetData()
        {
            return this.UsersService.GetTopFreelancersByRating(10);
        }
    }
}