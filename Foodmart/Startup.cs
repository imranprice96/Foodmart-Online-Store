using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Foodmart.Startup))]
namespace Foodmart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
