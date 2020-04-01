using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication;
using Polly;

namespace Cir.Data.Access.Services.Integration
{
    internal class InspecToolsAuthorization
    {
        private static string Adconnectionstring => string.Format(
            ConfigurationManager.AppSettings.Get("AdConnectionString"),
            ConfigurationManager.AppSettings.Get("ClientId"),
            ConfigurationManager.AppSettings.Get("AdTenantGuid"),
            ConfigurationManager.AppSettings.Get("ClientSecret"));
        private static string InspecToolsResourceId => ConfigurationManager.AppSettings.Get("InspecToolsResourceId");

        private static readonly AzureServiceTokenProvider AzureServiceTokenProvider =
            new AzureServiceTokenProvider(Adconnectionstring);

        public static async Task<string> GetInspecToolsAccessToken()
        {
            var result = await Policy
                .Handle<Exception>()
                .OrResult<string>(string.IsNullOrEmpty)
                .RetryAsync(5)
                .ExecuteAsync(
                    async () =>
                    {
                        var token = await AzureServiceTokenProvider.GetAccessTokenAsync(InspecToolsResourceId);

                        return token;
                    });

            return result;
        }
    }
}
