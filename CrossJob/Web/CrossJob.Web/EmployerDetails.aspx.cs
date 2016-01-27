using CrossJob.Services.Contracts;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrossJob.Web
{
    public partial class EmployerDetails : System.Web.UI.Page
    {
        [Inject]
        public IEmployersService EmployersService { get; set; }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                this.Response.Redirect("~/Account/Login");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Models.Employer ListViewEmployerDetails_GetData([QueryString]string ID)
        {
                return EmployersService.GetEmployerrDetails(ID);
        }
    }
}