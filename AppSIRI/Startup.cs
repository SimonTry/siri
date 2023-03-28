using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppSIRI.Startup))]
namespace AppSIRI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
