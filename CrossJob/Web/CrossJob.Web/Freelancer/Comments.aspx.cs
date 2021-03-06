﻿namespace CrossJob.Web.Freelancer
{
    using System;
    using System.Web.UI;
    using Microsoft.AspNet.Identity;
    using Ninject;
    using Services.Contracts;

    public partial class Comments : Page
    {
        [Inject]
        public ICommentsService comments { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var userId = this.User.Identity.GetUserId();
            var data = this.comments.GetAllByUser(userId, 0, 1000);

            this.ListComments.DataSource = data;
            this.ListComments.DataBind();
        }
    }
}