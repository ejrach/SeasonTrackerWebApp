using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SeasonTracker.Startup))]
namespace SeasonTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
