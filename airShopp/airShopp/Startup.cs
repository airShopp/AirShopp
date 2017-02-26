using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(airShopp.Startup))]
namespace airShopp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
