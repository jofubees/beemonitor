using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Beemonitor.Startup))]
namespace Beemonitor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
