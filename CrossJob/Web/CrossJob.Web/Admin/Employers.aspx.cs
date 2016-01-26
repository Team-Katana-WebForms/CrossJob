namespace CrossJob.Web.Admin
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using Models;
    using Ninject;
    using Services.Contracts;
    using Utilities.Notifier;

    public partial class Employers : Page
    {
        [Inject]
        public IEmployersService users { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DynamicDataManager1.RegisterControl(this.EmployerListView);
        }

        public IQueryable<Employer> Employers_GetData()
        {
            return this.users.GetAllEmployers();
        }

        public void Employers_UpdateItem(string id)
        {
            Employer user = this.users.GetEmployerrDetails(id);
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
                    this.users.UpdateProfileEmployer(user);
                }
                catch (Exception ex)
                {
                    Notifier.Error("Sorry, cannot update user!" + ex.Message);
                }
            }

            Notifier.Success("Successfully updated the user!");
            Response.Redirect("~/Admin/Employers");
        }

        public void Employers_DeleteItem(string id)
        {
            if (this.users.GetEmployerrDetails(id) == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            try
            {
                this.users.DeleteEmployer(id);
            }
            catch (Exception ex)
            {
                Notifier.Error("Sorry, cannot delete this user." + ex.Message);
            }

            Notifier.Success("Successfully deleted the user!");
            Response.Redirect("~/Admin/Employers");
        }
    }
}