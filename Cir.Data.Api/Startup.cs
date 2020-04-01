using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Cir.Data.Api.Startup))]

namespace Cir.Data.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}