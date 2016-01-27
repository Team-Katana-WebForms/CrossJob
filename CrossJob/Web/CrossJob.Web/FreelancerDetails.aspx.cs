using CrossJob.Services.Contracts;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

using CrossJob.Models;

namespace CrossJob.Web
{
    public partial class FreelancerDetails : System.Web.UI.Page
    {
        [Inject]
        public IFreelancersService FreelancersService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public Models.Freelancer ListViewFreelancerDetails_GetData([QueryString]string ID)
        {
            return FreelancersService.GetFreelancerDetails(ID);
        }
    }
}