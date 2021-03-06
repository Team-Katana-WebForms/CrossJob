﻿namespace CrossJob.Web.Employer
{
    using System;
    using System.Linq;
    using System.Web.UI.WebControls;
    using Microsoft.AspNet.Identity;
    using Models;
    using Ninject;
    using Services.Contracts;
    using Controls.Notifier;

    public partial class AddProject : System.Web.UI.Page
    {
        [Inject]
        public ICategoriesService CategoryService { get; set; }

        [Inject]
        public IProjectsService ProjectService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.calFinihedOn.Visible = false;
                this.calStartOn.Visible = false;
            }
        }

        public IQueryable<Category> GetCategories()
        {
            var categories = CategoryService
                .GetAll();

            return categories;
        }

        protected void imgFinishOn_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (this.calFinihedOn.Visible)
            {
                this.calFinihedOn.Visible = false;
            }
            else
            {
                this.calFinihedOn.Visible = true;
            }
        }

        protected void calFinihedOn_SelectionChanged(object sender, EventArgs e)
        {
            this.tbFinishOn.Text = this.calFinihedOn.SelectedDate.ToShortDateString();
            this.upTbFinishedOn.Update();
            this.calFinihedOn.Visible = false;
        }

        protected void imgStartOn_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (this.calStartOn.Visible)
            {
                this.calStartOn.Visible = false;
            }
            else
            {
                this.calStartOn.Visible = true;
            }
        }

        protected void calStartOn_SelectionChanged(object sender, EventArgs e)
        {
            this.tbStartOn.Text = this.calStartOn.SelectedDate.ToShortDateString();
            this.upStartOn.Update();
            this.calStartOn.Visible = false;
        }

        protected void calFinihedOn_DayRender(object sender, DayRenderEventArgs e)
        {
            RenderDayOutsideTheCurrentMonth(e);
        }

        protected void calStartOn_DayRender(object sender, DayRenderEventArgs e)
        {
            RenderDayOutsideTheCurrentMonth(e);
        }

        private void RenderDayOutsideTheCurrentMonth(DayRenderEventArgs e)
        {
            if (e.Day.IsOtherMonth)
            {
                e.Day.IsSelectable = false;
            }
        }

        protected void btnAddProject_Click(object sender, EventArgs e)
        {
            Page.Validate("AddProject");
            if (Page.IsValid)
            {
                var projectTitle = this.tbTitle.Text;
                var projectDescription = this.tbDescription.Text;
                var projectCategory = int.Parse(this.ddlCategory.SelectedValue);

                DateTime projectStartDate = DateTime.Now;
                if (!string.IsNullOrEmpty(this.tbStartOn.Text))
                {
                    projectStartDate = DateTime.Parse(this.tbStartOn.Text);
                }


                DateTime projectEndDate = DateTime.Now;
                if (!string.IsNullOrEmpty(this.tbFinishOn.Text))
                {
                    projectEndDate = DateTime.Parse(this.tbFinishOn.Text);
                }


                decimal projectPrice = 0.0M;
                if (!string.IsNullOrEmpty(this.tbPrice.Text))
                {
                    projectPrice = decimal.Parse(this.tbPrice.Text);
                }

                var employerId = this.User.Identity.GetUserId();
                int projectId = this.ProjectService.AddNew(
                    projectTitle,
                    projectDescription,
                    projectCategory,
                    projectPrice,
                    employerId,
                    projectStartDate,
                    projectEndDate);

                Notifier.Success("New project was added successfully!");
                this.Response.Redirect("~/Employer/MyProjects");
            }
        }
    }
}