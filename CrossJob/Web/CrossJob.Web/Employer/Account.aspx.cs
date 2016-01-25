﻿namespace CrossJob.Web.Employer
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
                this.LoadEmployerData();
            }
        }

        private void LoadEmployerData()
        {
            var userId = this.User.Identity.GetUserId();
            var currentUser = this.users.GetEmployerrDetails(userId);

            this.Email.Text = currentUser.Email;
            this.UserName.Text = currentUser.UserName;
            this.Country.Text = currentUser.Country;
            this.CompanyName.Text = currentUser.CompanyName;
            this.Address.Text = currentUser.Address;
            this.Website.Text = currentUser.WebSite;
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
                var currentUser = this.users.GetEmployerrDetails(userId);

                if (this.CompanyName.Text != currentUser.CompanyName)
                {
                    currentUser.CompanyName = this.CompanyName.Text;
                }

                if (this.Country.SelectedValue != currentUser.Country)
                {
                    currentUser.Country = this.Country.SelectedValue;
                }

                if (this.Address.Text != currentUser.Address)
                {
                    currentUser.Address = this.Address.Text;
                }

                if (this.Website.Text != currentUser.WebSite)
                {
                    currentUser.WebSite = this.Website.Text;
                }

                var updatedUser = this.users.UpdateProfileEmployer(currentUser);
                Notifier.Success("Account successfully updated");
                Response.Redirect("~/Employer/Account.aspx", true);
            }
            catch (Exception err)
            {
                //TODO catch right exception
                Notifier.Error(err.Message);
            }
        }
    }
}