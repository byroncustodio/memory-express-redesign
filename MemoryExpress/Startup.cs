using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MemoryExpress.Web.Startup))]
namespace MemoryExpress.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
