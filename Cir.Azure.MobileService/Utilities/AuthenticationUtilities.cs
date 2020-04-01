using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Security;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Globalization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Cir.Azure.MobileService.DataObjects;

namespace Cir.Azure.MobileService.Utilities
{
    public class AuthenticationUtilities
    {
        private ApiServices Services { get; set; }
        private ServiceUser serviceUser { get; set; }
        private const string AadInstance = "https://login.windows.net/{0}";
        private const string GraphResourceId = "https://graph.windows.net/";
        private const string APIVersion = "?api-version=2013-04-05";

        private string tenantdomain;
        private string clientid;
        private string clientkey;
        private string token = null;
       
        public AuthenticationUtilities(ApiServices apiServices)
        {
            Services = apiServices;
        }

        /// <summary>
        /// Get Access token from Azure Active Directory to use Graph API
        /// </summary>
        /// <returns>string</returns>
        /// <createdBy>Mukul Keshari</createdBy>
        public async Task<string> GetAADToken()
        {
            // Try to get the AAD app settings from the mobile service.  
            if (!(Services.Settings.TryGetValue("AAD_CLIENT_ID", out clientid) &
                  Services.Settings.TryGetValue("AAD_CLIENT_KEY", out clientkey) &
                  Services.Settings.TryGetValue("AAD_TENANT_DOMAIN", out tenantdomain)))
            {
                Services.Log.Error("GetAADToken() : Could not retrieve mobile service app settings.");
                return null;
            }

            ClientCredential clientCred = new ClientCredential(clientid, clientkey);
            string authority = String.Format(CultureInfo.InvariantCulture, AadInstance, tenantdomain);
            AuthenticationContext authContext = new AuthenticationContext(authority);
            AuthenticationResult result = await authContext.AcquireTokenAsync(GraphResourceId, clientCred);

            if (result != null)
                token = result.AccessToken;
            else
                Services.Log.Error("GetAADToken() : Failed to return a token.");

            return token;
        }
        /// <summary>
        /// Get User informaion from AAD of current logged in user
        /// </summary>
        /// <param name="User">ServiceUser: current logged in user</param>
        /// <returns>UserInformation</returns>
        /// <createdBy>Mukul Keshari</createdBy>
        public async Task<UserInformation> GetAADUser(ServiceUser User)
        {
            ServiceUser serviceUser = User;

            // Need a user
            if (serviceUser == null || serviceUser.Level != AuthorizationLevel.User)
            {
                Services.Log.Error("GetAADUser() : No ServiceUser or wrong Authorizationlevel");
                return null;
            }

            // Get the user's AAD object id
            var idents = serviceUser.GetIdentitiesAsync().Result;
            var clientAadCredentials = idents.OfType<AzureActiveDirectoryCredentials>().FirstOrDefault();
            if (clientAadCredentials == null)
            {
                Services.Log.Error("GetAADUser() : Could not get AAD credientials for the logged in user.");
                return null;
            }

            if (token == null)
                await GetAADToken();

            if (token == null)
            {
                Services.Log.Error("GetAADUser() : No token.");
                return null;
            }

            // User the AAD Graph REST API to get the user's information
            string url = GraphResourceId + tenantdomain + "/users/" + clientAadCredentials.ObjectId + APIVersion;
            Services.Log.Info("GetAADUser() : Request URL : " + url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", token);
            UserInformation userinfo = null;
            try
            {
                WebResponse response = await request.GetResponseAsync();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                string userjson = sr.ReadToEnd();
                Services.Log.Info("GetAADUser user json : " + userjson.ToString());
                userinfo = JsonConvert.DeserializeObject<UserInformation>(userjson);
                Services.Log.Info("GetAADUser user : " + userinfo.ToString());
            }
            catch (Exception e)
            {
                Services.Log.Error("GetAADUser exception : " + e.Message);
            }

            return userinfo;
        }

        // private class used to serialize the Graph REST API web response
        private class MembershipResponse
        {
            public bool value;
        }
        
        /// <summary>
        /// check membership against the group associated with the role.
        /// </summary>
        /// <param name="memberId">UserId</param>
        /// <param name="groupId">GroupId</param>
        /// <returns>bool</returns>
        /// <createdBy>Mukul Keshari</createdBy>
        public async Task<bool> CheckMembership(string memberId, string groupId)
        {
            bool membership = false;
            if (token == null)
                await GetAADToken();

            if (token == null)
            {
                Services.Log.Error("GetAADUser() : No token.");
                return false;
            }
            string url = GraphResourceId + tenantdomain + "/isMemberOf" + APIVersion;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // Use the Graph REST API to check group membership in the AAD
            try
            {
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Headers.Add("Authorization", token);
                using (var sw = new StreamWriter(request.GetRequestStream()))
                {
                    // Request body must have the group id and a member id to check for membership
                    string body = String.Format("\"groupId\":\"{0}\",\"memberId\":\"{1}\"",
                        groupId, memberId);
                    sw.Write("{" + body + "}");
                }

                WebResponse response = request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                string json = sr.ReadToEnd();
                MembershipResponse membershipResponse = JsonConvert.DeserializeObject<MembershipResponse>(json);
                membership = membershipResponse.value;
            }
            catch (Exception e)
            {
                Services.Log.Error("OnAuthorization() exception : " + e.Message);
            }

            return membership;
        }
     }
}