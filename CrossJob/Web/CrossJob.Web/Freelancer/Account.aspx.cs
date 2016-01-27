namespace CrossJob.Web.Freelancer
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Common.Constants;
    using Microsoft.AspNet.Identity;
    using Ninject;
    using Services.Contracts;
    using Controls.Notifier;

    public partial class Account : Page
    {
        [Inject]
        public IFreelancersService users { get; set; }

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

            this.Avatar.ImageUrl = currentUser.Avatar;
            this.FirstName.Text = currentUser.FirstName;
            this.LastName.Text = currentUser.LastName;
            this.Country.Text = currentUser.Country;
            this.UserName.Text = currentUser.UserName;
            this.Email.Text = currentUser.Email;
            this.Rating.Text = currentUser.AverageRating.ToString();
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

            if (FileUploadControl.HasFile)
            {
                try
                {
                    if (FileUploadControl.PostedFile.ContentType == "image/jpeg" ||
                        FileUploadControl.PostedFile.ContentType == "image/jpg" ||
                        FileUploadControl.PostedFile.ContentType == "image/png")
                    {
                        if (FileUploadControl.PostedFile.ContentLength < 3 * 102400)
                        {
                            var path = GlobalConstants.ImagesPath + userId + GlobalConstants.DefaultExtension;
                            FileUploadControl.SaveAs(Server.MapPath(path));
                            currentUser.Avatar = path;
                        }
                        else
                            Notifier.Error("Upload status: The file has to be less than 300 kb!");
                    }
                    else
                        Notifier.Error("Invalid file type!");
                }
                catch (Exception ex)
                {
                    Notifier.Error("Upload status: The file could not be uploaded. The following error occured: " + ex.Message);
                }
            }

            var updatedUser = this.users.UpdateProfileFreelancer(currentUser);
            Notifier.Success("Account successfully updated");
            Response.Redirect("~/Freelancer/Account.aspx", true);
        }
    }
}