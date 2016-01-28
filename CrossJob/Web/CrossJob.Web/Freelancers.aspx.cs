using CrossJob.Models;
using CrossJob.Services.Contracts;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrossJob.Web
{
    public partial class Freelancers : System.Web.UI.Page
    {
        [Inject]
        public IFreelancersService UsersService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Models.Freelancer> GridViewFreelancers_GetData([Control] double? displayRating)
        {
            var query = UsersService.GetAllFreelancers();

            switch (DisplayRating.SelectedValue)
            {
                case "1":
                    query = UsersService.GetAllFreelancers().ToList().Where(f => f.Ratings.Count > 0 && f.Ratings.Average(r => r.Value) > 1).AsQueryable();
                    break;
                case "2":
                    query = UsersService.GetAllFreelancers().ToList().Where(f => f.Ratings.Count > 0 && f.Ratings.Average(r => r.Value) > 2).AsQueryable();
                    break;
                case "3":
                    query = UsersService.GetAllFreelancers().ToList().Where(f => f.Ratings.Count > 0 && f.Ratings.Average(r => r.Value) > 3).AsQueryable();
                    break;
                case "4":
                    query = UsersService.GetAllFreelancers().ToList().Where(f => f.Ratings.Count > 0 && f.Ratings.Average(r => r.Value) > 4).AsQueryable();
                    break;
                case "5":
                    query = UsersService.GetAllFreelancers().ToList().Where(f => f.Ratings.Count > 0 && f.Ratings.Average(r => r.Value) == 5).AsQueryable();
                    break;
            }

            return query.ToList().OrderBy(f => f.AverageRating).AsQueryable();
        }
    }
}