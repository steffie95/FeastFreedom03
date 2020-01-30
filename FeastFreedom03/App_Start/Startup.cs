using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FeastFreedom03.Startup))]
namespace FeastFreedom03
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
