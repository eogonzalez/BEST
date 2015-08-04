using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BEST.Startup))]
namespace BEST
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}