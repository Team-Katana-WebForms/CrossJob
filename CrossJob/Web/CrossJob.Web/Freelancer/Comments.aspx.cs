namespace CrossJob.Web.Freelancer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Services.Contracts;
    using Ninject;
    using Microsoft.AspNet.Identity;

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