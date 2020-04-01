using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Globalization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Cir.Azure.MobileApp.DataObjects;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server;
using System.Web.Http.Tracing;
using Cir.Azure.MobileApp.Utilities.GraphApi;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using System.Security;

namespace Cir.Azure.MobileApp.Utilities
{
    public class AuthenticationUtilities
    {

        private MobileAppSettingsDictionary Settings { get; set; }
        private GraphApiClient graphApi;
        private ITraceWriter TraceWriter { get; set; }
        private const string AadInstance = "https://login.windows.net/{0}";
        private const string GraphResourceId = "https://graph.windows.net/";
        private const string APIVersion = "?api-version=2013-04-05";

        private string tenantdomain;
        private string clientid;
        private string clientkey;
        private string token = null;

        public AuthenticationUtilities(ApiController apiController)
        {
            Settings = apiController.Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();
            TraceWriter = apiController.Configuration.Services.GetTraceWriter();
            graphApi = new GraphApiClient(Settings);
            graphApi.RegisterNewExtensionProperty("LastLogin");
        }

        /// <summary>
        /// Get Access token from Azure Active Directory to use Graph API
        /// </summary>
        /// <returns>string</returns>
        /// <createdBy>Mukul Keshari</createdBy>
        public async Task<string> GetAADToken()
        {
            // Try to get the AAD app settings from the mobile service.  
            if (!(Settings.TryGetValue("AAD_CLIENT_ID", out clientid) &
                  Settings.TryGetValue("AAD_CLIENT_KEY", out clientkey) &
                  Settings.TryGetValue("AAD_TENANT_DOMAIN", out tenantdomain)))
            {
                TraceWriter.Error("GetAADToken() : Could not retrieve mobile service app settings.");
                return null;
            }

            ClientCredential clientCred = new ClientCredential(clientid, clientkey);
            string authority = String.Format(CultureInfo.InvariantCulture, AadInstance, tenantdomain);
            AuthenticationContext authContext = new AuthenticationContext(authority);
            AuthenticationResult result = await authContext.AcquireTokenAsync(GraphResourceId, clientCred);

            if (result != null)
                token = result.AccessToken;
            else
                TraceWriter.Error("GetAADToken() : Failed to return a token.");

            return token;
        }
        /// <summary>
        /// Get User informaion from AAD of current logged in user
        /// </summary>
        /// <param name="User">MobileAppUser: current logged in user</param>
        /// <returns>UserInformation</returns>
        /// <createdBy>Mukul Keshari</createdBy>
        public async Task<UserInformation> GetAADUser(MobileAppUser User)
        {
            MobileAppUser mobileAppUser = User;

            // Need a user
            if (mobileAppUser == null || mobileAppUser.MobileAppAuthenticationToken == null)
            {
                TraceWriter.Error("GetAADUser() : No mobileAppUser or wrong MobileAppAuthenticationToken");
                return null;
            }

            // Get the user's AAD object id
            var clientAadCredentials = await mobileAppUser.GetIdentityAsync<AzureActiveDirectoryCredentials>();
            if (clientAadCredentials == null)
            {
                TraceWriter.Error("GetAADUser() : Could not get AAD credientials for the logged in user.");
                return null;
            }

            if (token == null)
                await GetAADToken();

            if (token == null)
            {
                TraceWriter.Error("GetAADUser() : No token.");
                return null;
            }

            // User the AAD Graph REST API to get the user's information
            string url = GraphResourceId + tenantdomain + "/users/" + clientAadCredentials.ObjectId + APIVersion;
            TraceWriter.Info("GetAADUser() : Request URL : " + url);
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
                TraceWriter.Info("GetAADUser user json : " + userjson.ToString());
                userinfo = JsonConvert.DeserializeObject<UserInformation>(userjson);
                TraceWriter.Info("GetAADUser user : " + userinfo.ToString());

                User currentUser = graphApi.getUser(clientAadCredentials.ObjectId);

                if (currentUser == null)
                {
                    TraceWriter.Error("GetAADUser() : User cannot be found in graph");
                    return null;
                }
                // add a role claim for every membership found
                //SetLastSeen(currentUser.ObjectId);
                List<AppRole> currentRoles = graphApi.UserApplicationRoleFetcher(currentUser);
                userinfo.AppRoles = currentRoles.Select(r => r.DisplayName).ToArray();
            }
            catch (Exception e)
            {
                TraceWriter.Error("GetAADUser exception : " + e.Message);
                throw e;
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
        public async Task<bool> CheckMembership(MobileAppUser mobileAppUser, string groupId)
        {
            bool membership = false;
            if (token == null)
                await GetAADToken();

            if (token == null)
            {
                TraceWriter.Error("GetAADUser() : No token.");
                return false;
            }
            string url = GraphResourceId + tenantdomain + "/isMemberOf" + APIVersion;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            var clientAadCredentials = await mobileAppUser.GetIdentityAsync<AzureActiveDirectoryCredentials>();

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
                        groupId, clientAadCredentials.ObjectId);
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
                TraceWriter.Error("OnAuthorization() exception : " + e.Message);
                throw e;
            }

            return membership;
        }

        /// <summary>
        /// check membership against the AppRoles
        /// </summary>
        /// <param name="mobileAppUser">Current Mobile App User</param>
        /// <param name="Roles">Role list to check membership</param>
        /// <returns>bool</returns>
        /// <createdBy>Mukul Keshari</createdBy>
        public async Task<bool> CheckAppRoles(MobileAppUser mobileAppUser, List<string> Roles)
        {
            try
            {
                if (Roles.Any(r => r == "*"))
                    return true;

                var clientAadCredentials = await mobileAppUser.GetIdentityAsync<AzureActiveDirectoryCredentials>();
                User currentUser = graphApi.getUser(clientAadCredentials.ObjectId);

                if (currentUser == null)
                {
                    throw new SecurityException("User cannot be found in graph");
                }
                // add a role claim for every membership found
                List<AppRole> currentRoles = graphApi.UserApplicationRoleFetcher(currentUser);
                var MatchCount = (from cr in currentRoles
                                  join r in Roles
                                  on cr.DisplayName.Trim().ToLower() equals r.Trim().ToLower()
                                  select cr).Count();
                if (MatchCount > 0)
                    return true;
                if (Roles.Where(r => r.ToLower().Trim() == "Visitor".ToLower()).Count() == 0)
                    return true;
            }
            catch (Exception e)
            {
                TraceWriter.Error("OnAuthorization() exception : " + e.Message);
                throw e;
            }

            return false;
        }

        /// <summary>
        /// Get AppRoles of the application
        /// </summary>
        /// <returns>AppRoles of the application</returns>
        /// <createdBy>Mukul Keshari</createdBy>
        public List<AppRole> GetAADAppRole()
        {

            try
            {
                var AppRole = graphApi.ApplicationRoleList();
                return AppRole;
            }
            catch (Exception e)
            {
                TraceWriter.Error("GetAADAppRole() exception : " + e.Message);
                throw e;
            }
        }

        public List<ExtUserMap> GetAADUserList(string keyword)
        {

            try
            {
                var Users = graphApi.GetUserList(keyword);
                return Users;
            }
            catch (Exception e)
            {
                TraceWriter.Error("GetAADUserList() exception : " + e.Message);
                throw e;
            }
        }

        public List<Group> GetAADGroupList(string keyword)
        {

            try
            {
                var Groups = graphApi.GetGroupList(keyword);
                return Groups;
            }
            catch (Exception e)
            {
                TraceWriter.Error("GetAADGroupList() exception : " + e.Message);
                throw e;
            }
        }

        public List<AppRole> GetAppRolesAssignment(string UserID)
        {
            List<AppRole> Roles = new List<AppRole>();
            try
            {



                User currentUser = graphApi.getUserByPrincipalName(UserID);

                if (currentUser == null)
                {
                    throw new SecurityException("User cannot be found in graph");
                }
                // add a role claim for every membership found
                Roles = graphApi.UserApplicationRoleFetcher(currentUser);

            }
            catch (Exception e)
            {
                TraceWriter.Error("OnAuthorization() exception : " + e.Message);
                throw e;
            }

            return Roles;
        }

        public bool AddAppRolesAssignment(UserRoleMap userRoleMap)
        {

            try
            {

                List<AppRole> Roles = graphApi.ApplicationRoleList();

                graphApi.AssignRole(userRoleMap.UserId, Roles.FirstOrDefault(r => r.Id == userRoleMap.AppRoleId));
                return true;

            }
            catch (Exception e)
            {
                TraceWriter.Error("AddAppRolesAssignment() exception : " + e.Message);
                throw e;
            }

        }

        public bool RemoveAppRolesAssignment(UserRoleMap userRoleMap)
        {

            try
            {

                graphApi.UnAssignRole(userRoleMap.UserId, userRoleMap.AppRoleId);
                return true;

            }
            catch (Exception e)
            {
                TraceWriter.Error("SaveAppRolesAssignment() exception : " + e.Message);
                throw e;
            }

        }

        //Newly Added
        public string GetLastSeen(string uid)
        {
            string result = "";
            string extPropLookupName = string.Format("extension_{0}_{1}", AuthenticationHelper.ClientId.Replace("-", ""), "LastLogin");
            string s = graphApi.GetUserFromObjectID(uid); //Call REST API
            Newtonsoft.Json.Linq.JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(s);
            result = (string)jObject[extPropLookupName];
            return result;
        }

        public void SetLastSeen(string uid)
        {
           graphApi.SetUserLastLogin(uid, "LastLogin");
        }

        public List<UserDisplayModel> GetUsersAssignedRolesData(string RoleId, string userName, int searchType = 1)
        {

            // string extPropLookupName = string.Format("extension_{0}_{1}", AuthenticationHelper.ClientId.Replace("-", ""), "LastLogin");        
            List<User> list = null;
            List<string> listOfUserObjectId = null;
            List<AppRole> applicationRoleList = graphApi.ApplicationRoleList();
            List<UserDisplayModel> userList = new List<UserDisplayModel>();
            if (RoleId == "0")
            {
                list = graphApi.GetUser(userName, searchType);
                foreach (User u in list)
                {
                    // string s = graphApi.GetUserFromObjectID(u.ObjectId); //Call REST API
                    UserDisplayModel ur = new UserDisplayModel();
                    // Newtonsoft.Json.Linq.JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(s);
                    //ur.userID = (string)jObject["objectId"];
                    // ur.emailAddress = (string)jObject["userPrincipalName"];
                    // ur.userName = (string)jObject["displayName"];
                    // ur.lastLogin = (string)jObject[extPropLookupName];
                    ur.userID = u.ObjectId;
                    ur.emailAddress = u.UserPrincipalName;
                    ur.userName = u.DisplayName;
                    ur.lastLogin = "";

                    List<AppRole> roleList = graphApi.UserApplicationRoleFetcher(u, applicationRoleList);
                    ur.roleList = roleList;
                    userList.Add(ur);
                }

            }
            else
            {
                listOfUserObjectId = graphApi.GetUsersinRoles(RoleId);
                foreach (string ustr in listOfUserObjectId)
                {
                    //string s = graphApi.GetUserFromObjectID(u); //Call REST API
                    UserDisplayModel ur = new UserDisplayModel();
                    //Newtonsoft.Json.Linq.JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(s);
                    //ur.userID = (string)jObject["objectId"];
                    //ur.emailAddress = (string)jObject["userPrincipalName"];
                    //ur.userName = (string)jObject["displayName"];
                    //ur.lastLogin = (string)jObject[extPropLookupName];
                    User u = graphApi.getUser(ustr);
                    ur.userID = u.ObjectId;
                    ur.emailAddress = u.UserPrincipalName;
                    ur.userName = u.DisplayName;
                    ur.lastLogin = "";

                    List<AppRole> roleList = graphApi.UserApplicationRoleFetcher(u, applicationRoleList);
                    ur.roleList = roleList;
                    userList.Add(ur);
                }

            }

            return userList;
        }

        public List<GroupDisplayModel> GetGroupAssignedRolesData(string RoleId, string groupName)
        {

            List<Group> list = null;
            List<string> listOfGroupObjectId = null;
            List<AppRole> applicationRoleList = graphApi.ApplicationRoleList();
            List<GroupDisplayModel> groupList = new List<GroupDisplayModel>();
            if (RoleId == "0")
            {
                list = graphApi.GetGroupList(groupName);
                foreach (Group g in list)
                {
                    GroupDisplayModel gr = new GroupDisplayModel();
                    gr.objectID = g.ObjectId;
                    gr.emailAddress = g.Mail;
                    gr.groupName = g.DisplayName;

                    List<AppRole> roleList = graphApi.GroupApplicationRoleFetcher(g, applicationRoleList);
                    gr.roleList = roleList;
                    groupList.Add(gr);
                }

            }
            else
            {
                listOfGroupObjectId = graphApi.GetGroupsinRoles(RoleId);
                foreach (string gstr in listOfGroupObjectId)
                {

                    GroupDisplayModel gr = new GroupDisplayModel();

                    Group g = graphApi.getGroup(gstr);
                    gr.objectID = g.ObjectId;
                    gr.emailAddress = g.Mail;
                    gr.groupName = g.DisplayName;

                    List<AppRole> roleList = graphApi.GroupApplicationRoleFetcher(g, applicationRoleList);
                    gr.roleList = roleList;
                    groupList.Add(gr);
                }

            }

            return groupList;
        }


        public List<UserDisplayModel> GetUsersAssignedRoles(string RoleId, string userName)
        {
            List<UserDisplayModel> userList = GetUsersAssignedRolesData(RoleId, userName);
            return userList;
        }

        public UserDisplayModel AssignRole(string userName, string roleId, string uId = "", string roleToDisplay = "0")
        {
            List<UserDisplayModel> result = new List<UserDisplayModel>();

            List<AppRole> applicationRoleList = graphApi.ApplicationRoleList();
            AppRole appRole = applicationRoleList.Where(ar => ar.Id == Guid.Parse(roleId)).FirstOrDefault();
            if (appRole == null)
            {
                // return Json("Selected Role cannot be found!", JsonRequestBehavior.AllowGet);
                //  result.Add(new UserDisplayModel() { status = -1, message = "Selected Role cannot be found!" });
                return new UserDisplayModel() { status = -1, message = "Selected Role cannot be found!" };

            }
            User u = null;
            if (!String.IsNullOrEmpty(uId))
            {
                u = graphApi.getUser(uId);
            }
            else
            {
                u = graphApi.GetUser(userName).FirstOrDefault();
            }


            if (u == null)
            {
                // return Json("User with Email <b>" + userName + "</b> cannot be found!", JsonRequestBehavior.AllowGet);
                // result.Add(new UserDisplayModel() { status = -1, message = "User with Email [" + userName + "] cannot be found!" });
                return new UserDisplayModel() { status = -1, message = "User with Email [" + userName + "] cannot be found!" };
            }


            List<AppRole> roleList = graphApi.UserApplicationRoleFetcher(u, applicationRoleList);
            if (roleList.Where(x => x.Id == appRole.Id).Any())
            {
                //return Json("User already assigned in <b>" + appRole.DisplayName + "</b> role!", JsonRequestBehavior.AllowGet);
                //result.Add(new UserDisplayModel() { status = -1, message = "User already assigned in [" + appRole.DisplayName + "] role!" });
                return new UserDisplayModel() { status = -1, message = "User already assigned in [" + appRole.DisplayName + "] role!" };
            }

            graphApi.AssignRole(u, appRole);
            UserDisplayModel ur = new UserDisplayModel();
            ur.userID = u.ObjectId;
            ur.emailAddress = u.UserPrincipalName;
            ur.userName = u.DisplayName;
            ur.lastLogin = "";
            roleList.Add(appRole);

            ur.roleList = roleList;

            // List<UserDisplayModel> userList = GetUsersAssignedRolesData(roleToDisplay, userName);
            return ur;

        }

        public GroupDisplayModel AssignRoleToGroup(string groupName, string roleId, string gId = "", string roleToDisplay = "0")
        {
            List<GroupDisplayModel> result = new List<GroupDisplayModel>();

            List<AppRole> applicationRoleList = graphApi.ApplicationRoleList();
            AppRole appRole = applicationRoleList.Where(ar => ar.Id == Guid.Parse(roleId)).FirstOrDefault();
            if (appRole == null)
            {
                return new GroupDisplayModel() { status = -1, message = "Selected Role cannot be found!" };
            }
            Group g = null;
            if (!String.IsNullOrEmpty(gId))
            {
                g = graphApi.getGroup(gId);
            }
            else
            {
                g = graphApi.GetGroup(groupName).FirstOrDefault();
            }


            if (g == null)
            {
                return new GroupDisplayModel() { status = -1, message = "Group with object Id [" + groupName + "] cannot be found!" };
            }


            List<AppRole> roleList = graphApi.GroupApplicationRoleFetcher(g, applicationRoleList);
            if (roleList.Where(x => x.Id == appRole.Id).Any())
            {

                return new GroupDisplayModel() { status = -1, message = "Group already assigned in [" + appRole.DisplayName + "] role!" };
            }

            graphApi.AssignRoleToGroup(g, appRole);
            GroupDisplayModel gr = new GroupDisplayModel();
            gr.objectID = g.ObjectId;
            gr.emailAddress = g.Mail;
            gr.groupName = g.DisplayName;
           
            roleList.Add(appRole);

            gr.roleList = roleList;

            return gr;

        }


        public UserDisplayModel UnAssignAllRole(string uid, string userName, string roleToDisplay = "0")
        {

            User user = graphApi.getUser(uid);
            List<AppRole> applicationRoleList = graphApi.ApplicationRoleList();
            List<AppRole> roleList = graphApi.UserApplicationRoleFetcher(user, applicationRoleList);
            foreach (AppRole ap in roleList)
            {
                graphApi.UnAssignRole(uid, ap.Id);

            }
            UserDisplayModel ur = new UserDisplayModel();
            ur.userID = user.ObjectId;
            ur.emailAddress = user.UserPrincipalName;
            ur.userName = user.DisplayName;
            ur.lastLogin = "";
            // List<UserDisplayModel> userList = GetUsersAssignedRolesData(roleToDisplay, userName);
            return ur;

        }


        public GroupDisplayModel UnAssignAllRoleToGroup(string gid, string groupName, string roleToDisplay = "0")
        {

            Group group = graphApi.getGroup(gid);
            List<AppRole> applicationRoleList = graphApi.ApplicationRoleList();
            List<AppRole> roleList = graphApi.GroupApplicationRoleFetcher(group, applicationRoleList);
            foreach (AppRole ap in roleList)
            {
                graphApi.UnAssignRoleToGroup(gid, ap.Id);

            }
            GroupDisplayModel gr = new GroupDisplayModel();
            gr.objectID = group.ObjectId;
            gr.emailAddress = group.Mail;
            gr.groupName = group.DisplayName;
            return gr;

        }

        public UserDisplayModel UnAssignRole(string uid, string roleIdToRemove, string roleIdToDisplay, string UserToSearch = "0")
        {

            User u = graphApi.getUser(uid);
            List<AppRole> applicationRoleList = graphApi.ApplicationRoleList();
            List<AppRole> roleList = graphApi.UserApplicationRoleFetcher(u, applicationRoleList);
            foreach (AppRole ap in roleList)
            {
                if (ap.Id.ToString() == roleIdToRemove)
                    graphApi.UnAssignRole(uid, ap.Id);

            }
            UserDisplayModel ur = new UserDisplayModel();
            ur.userID = u.ObjectId;
            ur.emailAddress = u.UserPrincipalName;
            ur.userName = u.DisplayName;
            ur.lastLogin = "";
            roleList = graphApi.UserApplicationRoleFetcher(u, applicationRoleList);
            ur.roleList = roleList;
            // List<UserDisplayModel> userList = GetUsersAssignedRolesData(roleIdToDisplay, UserToSearch);
            return ur;




        }

        public GroupDisplayModel UnAssignRoleToGroup(string gid, string roleIdToRemove, string roleIdToDisplay, string GroupToSearch = "0")
        {

            Group g = graphApi.getGroup(gid);
            List<AppRole> applicationRoleList = graphApi.ApplicationRoleList();
            List<AppRole> roleList = graphApi.GroupApplicationRoleFetcher(g, applicationRoleList);
            foreach (AppRole ap in roleList)
            {
                if (ap.Id.ToString() == roleIdToRemove)
                    graphApi.UnAssignRoleToGroup(gid, ap.Id);

            }
            GroupDisplayModel gr = new GroupDisplayModel();
            gr.objectID = g.ObjectId;
            gr.emailAddress = g.Mail;
            gr.groupName = g.DisplayName;
            roleList = graphApi.GroupApplicationRoleFetcher(g, applicationRoleList);
            gr.roleList = roleList;
            return gr;

        }

        public UserDisplayModel GetUsersRoles(string uid)
        {
            UserDisplayModel u = new UserDisplayModel();
            User user = graphApi.getUser(uid);
            List<AppRole> applicationRoleList = graphApi.ApplicationRoleList();
            List<AppRole> roleList = graphApi.UserApplicationRoleFetcher(user, applicationRoleList);
            List<AppRole> appRole = graphApi.ApplicationRoleList();
            appRole = appRole.Where(x => !roleList.Any(y => y.Id == x.Id)).ToList();
            u.availableRoleList = roleList;
            u.roleList = appRole;
            return u;
        }


        public List<UserDisplayModel> SearchUser(string userToSearch, int searchType = 1)
        {
            if (String.IsNullOrEmpty(userToSearch.Trim()))
            {
                // throw new Exception("Please provide Email or Initials to search!");
                return null;
            }
            List<UserDisplayModel> userList = GetUsersAssignedRolesData("0", userToSearch, searchType);
            return userList;
        }

        public List<GroupDisplayModel> SearchGroup(string groupToSearch)
        {
            if (String.IsNullOrEmpty(groupToSearch.Trim()))
            {
                // throw new Exception("Please provide Email or Initials to search!");
                return null;
            }
            List<GroupDisplayModel> groupList = GetGroupAssignedRolesData("0", groupToSearch);
            return groupList;
        }

        public List<AppRole> FetchUserRole(string userId)
        {
            if (String.IsNullOrEmpty(userId.Trim()))
            {
                throw new Exception("Please provide Email to search assigned role!");
            }

            List<AppRole> applicationRoleList = graphApi.ApplicationRoleList();
            var AppRoles = graphApi.UserApplicationRoleFetcher(graphApi.getUserByPrincipalName(userId), applicationRoleList);

            return AppRoles;

        }


        public List<ExtUserMap> SearchAssignedUser(string userToSearch)
        {
            if (String.IsNullOrEmpty(userToSearch.Trim()))
            {
                //  throw new Exception("Please provide Email to search!");
                return null;
            }

            List<ExtUserMap> users = graphApi.GetAssignedUserList(userToSearch);

            return users;
        }

        public List<ExtUserMap> SearchAssignedUserToDelegate(string userToSearch)
        {
            if (String.IsNullOrEmpty(userToSearch.Trim()))
            {
                //  throw new Exception("Please provide Email to search!");
                return null;
            }

            List<ExtUserMap> users = graphApi.GetAssignedUserListToDelegate(userToSearch);

            return users;
        }
    }


}