namespace CrossJob.Web.Employer
{
    using System;
    using System.Linq;
    using System.Web.ModelBinding;
    using Models;
    using Ninject;
    using Services.Contracts;
    using System.Web.Security;
    using System.Web.UI.WebControls;
    using System.Web;
    using Microsoft.AspNet.Identity;
    using System.Data;
    using System.Collections.Generic;
    public partial class ProjectDetails : System.Web.UI.Page
    {
        [Inject]
        public IProjectsService ProjectsService { get; set; }

        [Inject]
        public ICategoriesService CategoriesService { get; set; }

        [Inject]
        public IFreelancersService FreelancersService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Project FormViewProjectDetails_GetItem([QueryString]int? ID)
        {
            if (ID == null)
            {
                Response.Redirect("~/");
            }

            var projectDetails = this.ProjectsService.GetById((int)ID);

            return projectDetails;
        }

        public IQueryable<Category> GetCategories()
        {
            var categories = this.CategoriesService
                .GetAll();

            return categories;
        }

        protected void ApplyForWork_Click(object sender, CommandEventArgs e)
        {
            LinkButton b = sender as LinkButton;
            var candidateID = this.User.Identity.GetUserId();
            var candidate = FreelancersService.GetFreelancerDetails(candidateID);
            Label label = (Label)b.Parent.Parent.Parent.FindControl("projectId");
            int id = Convert.ToInt32(label.Text);
            var project = ProjectsService.GetById(id);
            project.Candidates.Add(candidate);
            this.ProjectsService.Update(project);
        }

        protected void SeeCandidates_Click(object sender, CommandEventArgs e)
        {
            LinkButton b = sender as LinkButton;
            Label label = (Label)b.Parent.Parent.Parent.FindControl("projectId");
            int id = Convert.ToInt32(label.Text);
            var project = ProjectsService.GetById(id);
            var candidates = project.Candidates;
            var list = b.Parent.FindControl("GridViewCandidates") as ListBox;
            foreach (Freelancer item in candidates)
            {
                list.Items.Add(item.FirstName + "\nEmail: "  + item.Email);
             }
        }

        protected void GridViewCandidates_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //string id = GridViewCandidates.DataKeys[e.RowIndex].Value;
            //FreelancersService.DeleteFreelancer(id);
        }
    }
}