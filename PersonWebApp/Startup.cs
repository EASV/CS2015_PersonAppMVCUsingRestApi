using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PersonWebApp.Startup))]
namespace PersonWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
