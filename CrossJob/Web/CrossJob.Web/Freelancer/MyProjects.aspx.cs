using CrossJob.Models;
using CrossJob.Services.Contracts;
using Microsoft.AspNet.Identity;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrossJob.Web.Freelancer
{
    public partial class MyProjects : System.Web.UI.Page
    {
        [Inject]
        public IProjectsService ProjectsService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Project> ViewMyProjects_GetData()
        {
            var Id = this.User.Identity.GetUserId();
            var projects = this.ProjectsService
                .GetAllProjectsOfUser(Id, false);

            return projects;
        }
    }
}