using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PracticaSessionMVC.Startup))]
namespace PracticaSessionMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
