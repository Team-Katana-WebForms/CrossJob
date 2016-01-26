namespace CrossJob.Web.Employer
{
    using Models;
    using Ninject;
    using Services.Contracts;
    using System;
    using System.Linq;
    using System.Web.ModelBinding;
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

        protected void imgStartDate_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void FormViewProjectDetails_UpdateItem(int ID)
        {
            Project item = this.ProjectsService.GetById(ID);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", ID));
                return;
            }

            TryUpdateModel(item);

            if (ModelState.IsValid)
            {
                this.ProjectsService.SaveChanges();
            }
        }

        protected void calStartDate_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void calStartDate_DayRender(object sender, DayRenderEventArgs e)
        {

        }
    }
}