using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Cir.Data.Access.Services.Integration
{
    internal class InspecToolsHttpClient
    {
        private static HttpClient _client;

        public static async Task<HttpClient> GetInspecToolsHttpClient()
        {
            if (_client == null)
            {
                _client = await CreateInstance();
            }
            else
            {
                _client.DefaultRequestHeaders.Authorization = await CreateInspecToolsAuthHeader();
            }

            return _client;
        }

        private static async Task<HttpClient> CreateInstance()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(InspecToolsIntegrationConfig.BaseAdress),
                DefaultRequestHeaders =
                {
                    Authorization = await CreateInspecToolsAuthHeader()
                },
                Timeout = TimeSpan.FromSeconds(InspecToolsIntegrationConfig.TimeoutInSeconds)
            };

            return _client;
        }

        private static async Task<AuthenticationHeaderValue> CreateInspecToolsAuthHeader()
        {
            return new AuthenticationHeaderValue("Bearer", await InspecToolsAuthorization.GetInspecToolsAccessToken());
        }
    }
}
