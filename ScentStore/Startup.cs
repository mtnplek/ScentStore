using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ScentStore.Startup))]
namespace ScentStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
