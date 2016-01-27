using CrossJob.Services.Contracts;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

using CrossJob.Models;
using Microsoft.AspNet.Identity;

namespace CrossJob.Web
{
    public partial class FreelancerDetails : System.Web.UI.Page
    {
        [Inject]
        public IFreelancersService FreelancersService { get; set; }

        [Inject]
        public IRatingsService RatingsService { get; set; }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                this.Response.Redirect("~/Account/Login");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public Models.Freelancer ListViewFreelancerDetails_GetData([QueryString]string ID)
        {
            var label = this.loginFreelancer.FindControl("lbRate") as Label;
            label.Text = ID;

            return FreelancersService.GetFreelancerDetails(ID);
        }

        protected void btnRate_Click(object sender, ImageClickEventArgs e)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var textBox = this.loginFreelancer.FindControl("tbRate") as TextBox;
                var rate = int.Parse(textBox.Text);
                textBox.Text = "";

                var label = this.loginFreelancer.FindControl("lbRate") as Label;
                var freelancerId = label.Text;

                var employerId = this.User.Identity.GetUserId();

                this.RatingsService.AddNew(rate, freelancerId, employerId);
            }
        }
    }
}