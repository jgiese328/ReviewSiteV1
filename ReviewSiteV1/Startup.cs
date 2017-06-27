using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReviewSiteV1.Startup))]
namespace ReviewSiteV1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
