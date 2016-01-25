namespace CrossJob.Web.Employer
{
    using System;
    using Microsoft.AspNet.Identity;
    using Ninject;
    using Services.Contracts;

    public partial class Comments : System.Web.UI.Page
    {
        [Inject]
        public ICommentsService comments { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var userId = this.User.Identity.GetUserId();
            var data = this.comments.GetAllByAuthor(userId, 0, 1000);

            this.ListComments.DataSource = data;
            this.ListComments.DataBind();
        }
    }
}