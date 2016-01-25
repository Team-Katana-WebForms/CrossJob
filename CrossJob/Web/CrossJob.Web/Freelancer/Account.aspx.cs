namespace CrossJob.Web.Freelancer
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Microsoft.AspNet.Identity;
    using Ninject;
    using Services.Contracts;
    using WebForms.Utilities.Notifier;

    public partial class Account : Page
    {
        [Inject]
        public IUsersService users { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Country.DataSource = GetCountryList();
                this.Country.DataBind();
                this.Country.Items.Insert(0, "");
                this.LoadUserData();
            }
        }

        private void LoadUserData()
        {
            var userId = this.User.Identity.GetUserId();
            var currentUser = this.users.GetFreelancerDetails(userId);

            this.FirstName.Text = currentUser.FirstName;
            this.LastName.Text = currentUser.LastName;
            this.Country.Text = currentUser.Country;
            this.UserName.Text = currentUser.UserName;
            this.Email.Text = currentUser.Email;
            if (currentUser.Ratings.Count != 0)
            {
                this.Rating.Text = currentUser.Ratings.Select(x => x.Value).Average().ToString();
            }
            else
            {
                this.Rating.Text = "0";
            }

            this.RatePerHour.Text = currentUser.RatePerHour.ToString();
        }

        private List<string> GetCountryList()
        {
            var list = new List<string>();
            foreach (CultureInfo info in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                var infoReg = new RegionInfo(info.LCID);
                if (!list.Contains(infoReg.EnglishName))
                {
                    list.Add(infoReg.EnglishName);
                }
            }

            return list.OrderBy(x => x).ToList();
        }

        protected void UpdateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                var userId = this.User.Identity.GetUserId();
                var currentUser = this.users.GetFreelancerDetails(userId);

                if (this.FirstName.Text != currentUser.FirstName)
                {
                    currentUser.FirstName = this.FirstName.Text;
                }

                if (this.LastName.Text != currentUser.LastName)
                {
                    currentUser.LastName = this.LastName.Text;
                }

                if (this.Country.SelectedValue != currentUser.Country)
                {
                    currentUser.Country = this.Country.SelectedValue;
                }

                if (decimal.Parse(this.RatePerHour.Text) != currentUser.RatePerHour)
                {
                    currentUser.RatePerHour = decimal.Parse(this.RatePerHour.Text);
                }

                var updatedUser = this.users.UpdateProfileFreelancer(currentUser);
                Notifier.Success("Account successfully updated");
                Response.Redirect("~/Freelancer/Account.aspx", true);
            }
            catch (Exception err)
            {
                //TODO catch right exception
                Notifier.Error(err.Message);
            }
        }
    }
}