namespace CrossJob.Web.Admin
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using Models;
    using Ninject;
    using Services.Contracts;
    using Utilities.Notifier;

    public partial class Freelancers : Page
    {
        [Inject]
        public IFreelancersService users { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DynamicDataManager1.RegisterControl(this.FreelancerListView);
        }

        public IQueryable<Freelancer> Freelancers_GetData()
        {
            return this.users.GetAllFreelancers();
        }

        public void Freelancers_UpdateItem(string id)
        {
            Freelancer user = this.users.GetFreelancerDetails(id);
            if (user == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            TryUpdateModel(user);
            if (ModelState.IsValid)
            {
                try
                {
                    this.users.UpdateProfileFreelancer(user);
                }
                catch (Exception ex)
                {
                    Notifier.Error("Sorry, cannot update user!" + ex.Message);
                }
            }

            Notifier.Success("Successfully updated the user!");
            Response.Redirect("~/Admin/Freelancers");
        }

        public void Freelancers_DeleteItem(string id)
        {
            if (this.users.GetFreelancerDetails(id) == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            try
            {
                this.users.DeleteFreelancer(id);
            }
            catch (Exception ex)
            {
                Notifier.Error("Sorry, cannot delete this user." + ex.Message);
            }

            Notifier.Success("Successfully deleted the user!");
            Response.Redirect("~/Admin/Freelancers");
        }
    }
}