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
    public partial class ProjectDetails : System.Web.UI.Page
    {
        [Inject]
        public IProjectsService ProjectsService { get; set; }

        [Inject]
        public ICategoriesService CategoriesService { get; set; }

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

        protected void ApplyForWork(object sender, EventArgs e)
        {
            
        }
    }
}