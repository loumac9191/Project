using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ECommerceASP.Startup))]
namespace ECommerceASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
