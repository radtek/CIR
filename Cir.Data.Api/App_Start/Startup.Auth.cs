using System.Configuration;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Authentication;
using Owin;

namespace Cir.Data.Api
{
    public partial class Startup
    {
        public static void ConfigureAuth(IAppBuilder app, HttpConfiguration httpConfiguration)
        {
            var settings = httpConfiguration.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    SigningKey = ConfigurationManager.AppSettings.Get("MS_SigningKey"),
                    ValidAudiences = new[] { ConfigurationManager.AppSettings.Get("ValidAudience") },
                    ValidIssuers = new[]
                    {
                        ConfigurationManager.AppSettings.Get("ValidIssuer")
                    },
                    TokenHandler = httpConfiguration.GetAppServiceTokenHandler()
                });
            }
        }
    }
}