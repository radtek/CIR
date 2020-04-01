using System.Configuration;

namespace Cir.Data.Access.Services.Integration
{
    public static class InspecToolsIntegrationConfig
    {
        //http client settings
        public static string LockCirSuffix => ConfigurationManager.AppSettings.Get("InspecToolsLockCirSuffix");
        public static string UnlockCirSuffix => ConfigurationManager.AppSettings.Get("InspecToolsUnlockCirSuffix");
        public static string PostCirSuffix => ConfigurationManager.AppSettings.Get("InspecToolsLockPostCirSuffix");
        public static string BaseAdress => ConfigurationManager.AppSettings.Get("InspecToolsApiUrl");
        public static long TimeoutInSeconds => long.Parse(ConfigurationManager.AppSettings.Get("InspecToolsRequestTimeout"));

        //retry requests settings
        public static int ReqeustRetrySleepTime => int.Parse(ConfigurationManager.AppSettings.Get("InspecToolsReqeustRetrySleepTime"));

        //authorization with inspectool
        public static string AadInstance => ConfigurationManager.AppSettings.Get("AadInstance");
        public static string Tenant => ConfigurationManager.AppSettings.Get("Tenant");
        public static string ClientId => ConfigurationManager.AppSettings.Get("ClientId");
        public static string AppKey => ConfigurationManager.AppSettings.Get("AppKey");
        public static string InspecToolsResourceId => ConfigurationManager.AppSettings.Get("InspecToolsResourceId");
    }
}
