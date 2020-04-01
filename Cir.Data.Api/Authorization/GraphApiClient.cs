using System;
using System.Configuration;
using System.Data.Services.Client;
using System.Threading.Tasks;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Cir.Data.Api.Authorization
{
    public static class GraphApiClient
    {
        private static readonly string ClientId = ConfigurationManager.AppSettings.Get("ClientId");
        private static readonly string GraphUri = ConfigurationManager.AppSettings.Get("GraphApiUri");
        private static readonly string TenantId = ConfigurationManager.AppSettings.Get("AdTenantId");
        private static readonly string ClientSecret = ConfigurationManager.AppSettings.Get("ClientSecret");
        private static readonly string AuthString = string.Format(ConfigurationManager.AppSettings.Get("AadAuthString"), TenantId);
        private static readonly Uri ServicePointUri = new Uri(GraphUri);
        private static readonly Uri ServiceRoot = new Uri(ServicePointUri, TenantId);

        public static ActiveDirectoryClient CreateInstance()
        {
            var client = new ActiveDirectoryClient(ServiceRoot, GetAccessToken);

            client.Context.MergeOption = MergeOption.NoTracking;

            return client;
        }

        private static async Task<string> GetAccessToken()
        {
            var authenticationContext = new AuthenticationContext(AuthString, false);
            var clientCred = new ClientCredential(ClientId, ClientSecret);

            var result = await authenticationContext.AcquireTokenAsync(GraphUri, clientCred);

            return result.AccessToken;
        }
    }
}