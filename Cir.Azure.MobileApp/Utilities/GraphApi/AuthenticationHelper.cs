using System;
using System.Threading.Tasks;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Configuration;
using Microsoft.Azure.Mobile.Server;

namespace Cir.Azure.MobileApp.Utilities.GraphApi
{
    public class AuthenticationHelper
    {
        //public static readonly string TenantId = (new Microsoft.Azure.Mobile.Server.Config.MobileAppConfiguration()).MobileAppSettingsProvider.GetMobileAppSettings()["AAD_TENANT_DOMAIN"].ToString();//  ConfigurationManager.AppSettings["AzureADTenant"];
        //public static readonly string ClientId = (new Microsoft.Azure.Mobile.Server.Config.MobileAppConfiguration()).MobileAppSettingsProvider.GetMobileAppSettings()["AAD_CLIENT_ID"].ToString();//ConfigurationManager.AppSettings["ida:ClientID"];
        //public static readonly string ClientSecret = (new Microsoft.Azure.Mobile.Server.Config.MobileAppConfiguration()).MobileAppSettingsProvider.GetMobileAppSettings()["AAD_CLIENT_KEY"].ToString();//ConfigurationManager.AppSettings["ida:Password"];
        //public static readonly string ClientIdForUserAuthn = (new Microsoft.Azure.Mobile.Server.Config.MobileAppConfiguration()).MobileAppSettingsProvider.GetMobileAppSettings()["AAD_CLIENT_ID"].ToString();//ConfigurationManager.AppSettings["ida:ClientID"];
        //public static readonly string AuthString = "https://login.microsoftonline.com/" + TenantId;
        //public static readonly string ResourceUrl = "https://graph.windows.net";

        public static string TenantId;
        public static string ClientId;
        public static string ClientSecret;
        public static string ClientIdForUserAuthn;
        public static string AuthString;
        public static string ResourceUrl = "https://graph.windows.net";

        public static string TokenForUser;
        public static string TokenForApplication;



        /// <summary>
        /// Async task to acquire token for Application.
        /// </summary>
        /// <returns>Async Token for application.</returns>
        public static async Task<string> AcquireTokenAsyncForApplication()
        {
            return await Task.Run(() => GetTokenForApplication());
        }

        /// <summary>
        /// Get Token for Application.
        /// </summary>
        /// <returns>Token for application.</returns>
        public static string GetTokenForApplication()
        {
            AuthenticationContext authenticationContext = new AuthenticationContext(AuthString, false);
            // Config for OAuth client credentials 
            ClientCredential clientCred = new ClientCredential(ClientId, ClientSecret);
            AuthenticationResult authenticationResult = authenticationContext.AcquireToken(ResourceUrl,
                clientCred);
            string token = authenticationResult.AccessToken;
            TokenForApplication = token;
            return token;
        }

        /// <summary>
        /// Get Active Directory Client for Application.
        /// </summary>
        /// <returns>ActiveDirectoryClient for Application.</returns>
        public static ActiveDirectoryClient GetActiveDirectoryClientAsApplication(MobileAppSettingsDictionary Settings)
        {
            if ((Settings.TryGetValue("AAD_CLIENT_ID", out ClientId) &
                     Settings.TryGetValue("AAD_CLIENT_KEY", out ClientSecret) &
                     Settings.TryGetValue("AAD_CLIENT_ID", out ClientIdForUserAuthn) &
                     Settings.TryGetValue("AAD_TENANT_DOMAIN", out TenantId)))
            {
                AuthString = "https://login.microsoftonline.com/" + TenantId;
            }
            Uri servicePointUri = new Uri(ResourceUrl);
            Uri serviceRoot = new Uri(servicePointUri, TenantId);
            ActiveDirectoryClient activeDirectoryClient = new ActiveDirectoryClient(serviceRoot,
                async () => await AcquireTokenAsyncForApplication());
            return activeDirectoryClient;
        }

        /// <summary>
        /// Async task to acquire token for User.
        /// </summary>
        /// <returns>Token for user.</returns>
        public static async Task<string> AcquireTokenAsyncForUser()
        {
            return await Task.Run(() => GetTokenForUser());
        }

        /// <summary>
        /// Get Token for User.
        /// </summary>
        /// <returns>Token for user.</returns>
        public static string GetTokenForUser()
        {
            if (TokenForUser == null)
            {
                var redirectUri = new Uri("https://localhost");
                AuthenticationContext authenticationContext = new AuthenticationContext(AuthString, false);
                AuthenticationResult userAuthnResult = authenticationContext.AcquireToken(ResourceUrl,
                    ClientIdForUserAuthn, redirectUri, PromptBehavior.Always);
                TokenForUser = userAuthnResult.AccessToken;

            }
            return TokenForUser;
        }

        /// <summary>
        /// Get Active Directory Client for User.
        /// </summary>
        /// <returns>ActiveDirectoryClient for User.</returns>
        public static ActiveDirectoryClient GetActiveDirectoryClientAsUser()
        {
            Uri servicePointUri = new Uri(ResourceUrl);
            Uri serviceRoot = new Uri(servicePointUri, TenantId);
            ActiveDirectoryClient activeDirectoryClient = new ActiveDirectoryClient(serviceRoot,
                async () => await AcquireTokenAsyncForUser());
            return activeDirectoryClient;
        }
    }
}