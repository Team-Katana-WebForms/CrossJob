﻿namespace CrossJob.Web.Account
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using Common.Constants;
    using Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Models;
    using Controls.Notifier;

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
                UserName = Server.HtmlEncode(UserName.Text),
                CompanyName = Server.HtmlEncode(CompanyName.Text),
                Avatar = GlobalConstants.DefaultAvatar
            };

            IdentityResult result = manager.Create(user, Password.Text);

            if (result.Succeeded)
            {
                manager.AddToRole(user.Id, Role);

                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                Notifier.Success("Registration was successful!");
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                Notifier.Error(result.Errors.FirstOrDefault());
            }
        }

    }
}