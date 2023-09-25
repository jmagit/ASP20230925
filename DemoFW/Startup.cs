using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoFW.Startup))]
namespace DemoFW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
