using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrossJob.Web.Startup))]
namespace CrossJob.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
