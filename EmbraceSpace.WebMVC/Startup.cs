using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmbraceSpace.WebMVC.Startup))]
namespace EmbraceSpace.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
