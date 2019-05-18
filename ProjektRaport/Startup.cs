using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjektRaport.Startup))]
namespace ProjektRaport
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
