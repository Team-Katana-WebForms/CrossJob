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
    public partial class Freelancers : System.Web.UI.Page
    {
        [Inject]
        public IUsersService UsersService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IQueryable<Models.Freelancer> GridViewFreelancers_GetData()
        {
            var query = UsersService.AllFreelancers();

            switch (DisplayRating.SelectedValue)
            {
                case  "1":
                    query = UsersService.AllFreelancers().ToList().Where(f => f.AverageRating > 1).AsQueryable();
                    break;
                case "2":
                    query = UsersService.AllFreelancers().ToList().Where(f => f.AverageRating > 2).AsQueryable();
                    break;
                case "3":
                    query = UsersService.AllFreelancers().ToList().Where(f => f.AverageRating > 3).AsQueryable();
                    break;
                case  "4":
                    query = UsersService.AllFreelancers().ToList().Where(f => f.AverageRating > 4).AsQueryable();
                    break;
                case "5":
                    query = UsersService.AllFreelancers().ToList().Where(f => f.AverageRating == 5).AsQueryable();
                    break;
            }

            return query.ToList().OrderBy(f => f.AverageRating).AsQueryable();
        }
    }
}