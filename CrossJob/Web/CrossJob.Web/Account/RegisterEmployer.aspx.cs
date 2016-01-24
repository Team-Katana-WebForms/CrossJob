namespace CrossJob.Web.Account
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Models;

    public partial class RegisterEmployer : Page
    {
        private const string Role = "Employer";

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new Employer()
            {
                Email = Email.Text,
                UserName = UserName.Text,
                CompanyName = CompanyName.Text
            };

            IdentityResult result = manager.Create(user, Password.Text);

            if (result.Succeeded)
            {
                manager.AddToRole(user.Id, Role);

                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

    }
}