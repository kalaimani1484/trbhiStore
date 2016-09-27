using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrbhiStore.Startup))]
namespace TrbhiStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
