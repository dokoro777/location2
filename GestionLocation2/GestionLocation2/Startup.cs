using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestionLocation2.Startup))]
namespace GestionLocation2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
