using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MemoryExpress.Startup))]
namespace MemoryExpress
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
