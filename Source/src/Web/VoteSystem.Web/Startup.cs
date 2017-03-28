using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VoteSystem.Web.Startup))]
namespace VoteSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
