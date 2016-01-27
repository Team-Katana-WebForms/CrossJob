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
using CrossJob.Controls.Notifier;

namespace CrossJob.Web
{
    public partial class FreelancerDetails : System.Web.UI.Page
    {
        [Inject]
        public IFreelancersService FreelancersService { get; set; }

        [Inject]
        public IRatingsService RatingsService { get; set; }

        [Inject]
        public IProjectsService ProjectsService { get; set; }

        [Inject]
        public ICommentsService CommentsService { get; set; }

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
                if (textBox.Text == string.Empty)
                {
                    Notifier.Error("Rating cannot be an empty string");
                    return;
                }

                var rate = int.Parse(textBox.Text);
                textBox.Text = "";

                var label = this.loginFreelancer.FindControl("lbRate") as Label;
                var freelancerId = label.Text;

                var employerId = this.User.Identity.GetUserId();

                var employerRatings = this.RatingsService.GetAllByAuthor(employerId);
                var freelancerRating = employerRatings.Any(f => f.FreelancerID == freelancerId);
                if (freelancerRating)
                {
                    Notifier.Error("You already rated this freelancer");
                    return;
                }

                var employerProjects = this.ProjectsService.GetAllProjectsOfUser(employerId);
                var freelancerProjects = employerProjects.Any(f => f.FreelancerID == freelancerId);
                if (freelancerProjects)
                {
                    Notifier.Error("No projects related to this freelancer");
                    return;
                }

                this.RatingsService.AddNew(rate, freelancerId, employerId);
            }
        }

        protected void btnComment_Click(object sender, EventArgs e)
        {

            if (this.User.Identity.IsAuthenticated)
            {
                var textBox = this.loginFreelancer.FindControl("tbComment") as TextBox;
                if (textBox.Text == string.Empty)
                {
                    Notifier.Error("Comment cannot be an empty string");
                    return;
                }

                var comment = textBox.Text;
                textBox.Text = "";

                var label = this.loginFreelancer.FindControl("lbRate") as Label;
                var freelancerId = label.Text;

                var employerId = this.User.Identity.GetUserId();

                this.CommentsService.AddNew(comment, freelancerId, employerId);
            }
        }
    }
}
