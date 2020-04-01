using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Cir.Azure.MobileApp.Service.Startup))]
namespace Cir.Azure.MobileApp.Service
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}