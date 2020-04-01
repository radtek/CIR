using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Azure.ActiveDirectory.GraphClient.Extensions;
using Microsoft.Azure.Mobile.Server;
using Cir.Azure.MobileApp.Service.DataObjects;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace Cir.Azure.MobileApp.Service.Utilities.GraphApi
{
    public class GraphApiClient
    {
        ActiveDirectoryClient activeDirectoryClient;
        private static object _lock = new Object();
        private static MemoryCache _cache = new MemoryCache("UserCache");
        public GraphApiClient(MobileAppSettingsDictionary Settings)
        {
            try
            {
                activeDirectoryClient = AuthenticationHelper.GetActiveDirectoryClientAsApplication(Settings);
            }
            catch (AuthenticationException ex)
            {
                string e = ex.ToString();
                throw new Exception("Error occured while acuring Graph API Token!!");

            }

        }
        public List<ExtUserMap> GetUserList(string userToSearch)
        {
            List<ExtUserMap> retrievedUsersList = new List<ExtUserMap>(); ;
            List<IUser> usersList = null;
            IPagedCollection<IUser> searchResults = null;

            try
            {
                IUserCollection userCollection = activeDirectoryClient.Users;
                searchResults = userCollection.Where(user =>
                    user.UserPrincipalName.StartsWith(userToSearch) ||
                    user.DisplayName.StartsWith(userToSearch) ||
                    user.GivenName.StartsWith(userToSearch) ||
                    user.Surname.StartsWith(userToSearch)).ExecuteAsync().Result;
                usersList = searchResults.CurrentPage.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("Error searching user : {0} {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : ""));

            }
            if (usersList != null && usersList.Count > 0)
            {
                do
                {
                    usersList = searchResults.CurrentPage.ToList();
                    foreach (IUser user in usersList)
                    {
                        retrievedUsersList.Add(new ExtUserMap { objectId = user.ObjectId, extName = ((user.UserPrincipalName.Contains("#EXT#") && user.OtherMails != null && user.OtherMails.Count > 0) ? user.OtherMails[0] : user.UserPrincipalName), internalUPN = user.UserPrincipalName });
                    }
                    searchResults = searchResults.GetNextPageAsync().Result;
                } while (searchResults != null);
            }

            return retrievedUsersList;
        }

        //public List<string> GetAssignedUserList(string userToSearch)
        //{
        //    List<User> users = new List<User>();
        //    List<IUser> usersList = null;
        //    IPagedCollection<IUser> searchResults = null;

        //    try
        //    {
        //        IUserCollection userCollection = activeDirectoryClient.Users;
        //        searchResults = userCollection.Where(user =>
        //            user.UserPrincipalName.StartsWith(userToSearch) ||
        //            user.DisplayName.StartsWith(userToSearch) ||
        //            user.GivenName.StartsWith(userToSearch) ||
        //            user.Surname.StartsWith(userToSearch)).ExecuteAsync().Result;
        //        usersList = searchResults.CurrentPage.ToList();
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(String.Format("Error searching user : {0} {1}", e.Message,
        //           e.InnerException != null ? e.InnerException.Message : ""));

        //    }
        //    if (usersList != null && usersList.Count > 0)
        //    {
        //        do
        //        {
        //            usersList = searchResults.CurrentPage.ToList();
        //            foreach (IUser user in usersList)
        //            {
        //                users.Add((User)user);

        //            }
        //            searchResults = searchResults.GetNextPageAsync().Result;
        //        } while (searchResults != null);
        //    }

        //    List<string> retrievedUsersList = new List<string>();
        //    //Add only Users with Admin or Editor Role
        //    foreach (User u in users)
        //    {
        //        List<AppRole> apRole = UserApplicationRoleFetcher(u);

        //        if (apRole != null && apRole.Count > 0)
        //        {
        //            retrievedUsersList.Add(u.UserPrincipalName);
        //        }

        //    }

        //    return retrievedUsersList;
        //}
        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="currentUserObjectId">The current user object identifier.</param>
        /// <returns></returns>
        public User getUser(string currentUserObjectId)
        {

            // User currentUser = null;
            User currentUser = null;
            lock (_lock)
            {
                currentUser = _cache.Get(currentUserObjectId + "_User") as User;
            }

            if (currentUser == null)
            {

                var userTask = System.Threading.Tasks.Task.Run(async () =>
                {
                    var udata = await activeDirectoryClient.DirectoryObjects.OfType<User>().Where(it => (it.ObjectId == currentUserObjectId)).ExecuteAsync();
                    currentUser = udata.CurrentPage.FirstOrDefault();
                    //currentUser = await activeDirectoryClient.Users.GetByObjectId(currentUserObjectId).ExecuteAsync() as User;
                });
                userTask.Wait();
                if (currentUser != null)
                {
                    lock (_lock)
                    {
                        CacheItemPolicy policy = new CacheItemPolicy();
                        policy.AbsoluteExpiration = new DateTimeOffset(DateTime.UtcNow.AddMinutes(30));
                        _cache.Set(currentUserObjectId + "_User", currentUser, policy);
                    }
                }
            }
            //userTask.Wait();
            //return currentUser;
            // return userTask.Result;
            return currentUser;
        }

        /// <summary>
        /// Gets the group.
        /// </summary>
        /// <param name="currentGroupObjectId">The current group object identifier.</param>
        /// <returns></returns>
        public Group getGroup(string currentGroupObjectId)
        {
            Group currentGroup = null;
            var userTask = System.Threading.Tasks.Task.Run(async () =>
            {
                var udata = await activeDirectoryClient.DirectoryObjects.OfType<Group>().Where(it => (it.ObjectId == currentGroupObjectId)).ExecuteAsync();
                currentGroup = udata.CurrentPage.FirstOrDefault();
            });
            userTask.Wait();
            return currentGroup;
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="userPrincipalName">The current user PrincipalName.</param>
        /// <returns></returns>
        public User getUserByPrincipalName(string userPrincipalName)
        {

            User currentUser = null;
            var userTask = System.Threading.Tasks.Task.Run(async () =>
            {
                var udata = await activeDirectoryClient.DirectoryObjects.OfType<User>().Where(it => (it.UserPrincipalName == userPrincipalName)).ExecuteAsync();
                currentUser = udata.CurrentPage.FirstOrDefault();
            });
            userTask.Wait();
            return currentUser;
        }

        public List<Group> GetGroupList(string groupToSearch)
        {
            List<Group> retrievedGroupList = new List<Group>(); ;
            List<IGroup> groupList = null;
            IPagedCollection<IGroup> searchResults = null;

            try
            {
                IGroupCollection groupCollection = activeDirectoryClient.Groups;
                searchResults = groupCollection.Where(group =>
                    group.DisplayName.StartsWith(groupToSearch) ||
                    group.Mail.StartsWith(groupToSearch) ||
                    group.MailNickname.StartsWith(groupToSearch)).ExecuteAsync().Result;
                groupList = searchResults.CurrentPage.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("Error searching user : {0} {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : ""));

            }
            if (groupList != null && groupList.Count > 0)
            {
                do
                {
                    groupList = searchResults.CurrentPage.ToList();
                    foreach (IGroup group in groupList)
                    {
                        retrievedGroupList.Add((Group)group);
                    }
                    searchResults = searchResults.GetNextPageAsync().Result;
                } while (searchResults != null);
            }

            return retrievedGroupList;
        }

        /// <summary>
        /// Assigns the role to user.
        /// </summary>
        /// <param name="currentUserObjectId">The current user object identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        public void AssignRole(string userPrincipalName, AppRole appRole)
        {
            User currentUser = activeDirectoryClient.DirectoryObjects.OfType<User>().Where(it => (it.UserPrincipalName == userPrincipalName)).ExecuteAsync().Result.CurrentPage.FirstOrDefault();

            var principals = activeDirectoryClient.ServicePrincipals
                      .Where(principal => principal.AppId.Equals(AuthenticationHelper.ClientId))
                       .ExecuteAsync().Result.CurrentPage.ToList();
            var sp = principals.FirstOrDefault();

            var appRoleAssignment = new AppRoleAssignment
            {
                Id = appRole.Id,
                ResourceId = Guid.Parse(sp.ObjectId),
                PrincipalType = "User",
                PrincipalId = Guid.Parse(currentUser.ObjectId)
            };

            //if (IsUserInAppRole(user, appRoleAssignment)) return;

            //currentUser.AppRoleAssignments.Add(appRoleAssignment);
            //currentUser.UpdateAsync();
            string appjson = "{ \"id\": \"" + appRole.Id + "\", \"principalId\":  \"" + currentUser.ObjectId + "\", \"principalType\": \"User\", \"resourceId\":  \"" + sp.ObjectId + "\"}";
            //  string requestUrlUserAppRole = AuthenticationHelper.ResourceUrl + "/" + AuthenticationHelper.TenantId + "/users/" + userPrincipalName + "/appRoleAssignments?api-version=1.5";

            string requestUrlUserAppRole = AuthenticationHelper.ResourceUrl + "/" + AuthenticationHelper.TenantId + "/users/" + currentUser.ObjectId + "/appRoleAssignments?api-version=1.5";

            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(requestUrlUserAppRole);
            request.Method = "POST";
            request.ContentType = "application/json";
            using (System.IO.Stream s = request.GetRequestStream())
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s))
                    sw.Write(appjson);
            }
            if (string.IsNullOrEmpty(AuthenticationHelper.TokenForApplication))
                AuthenticationHelper.GetTokenForApplication();
            request.Headers.Add("Authorization", AuthenticationHelper.TokenForApplication);
            string UserAppRole;

            System.Net.WebResponse response = request.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
            UserAppRole = sr.ReadToEnd();
            try
            {
                _cache.Remove(currentUser.ObjectId + "_User_Roles");

            }
            catch { }
        }


        /// <summary>
        /// Unassign role.
        /// </summary>
        /// <param name="currentUserObjectId">The current user object identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        //public void UnAssignRole(string userPrincipalName, Guid appRoleId)
        //{
        //    User currentUser = activeDirectoryClient.DirectoryObjects.OfType<User>().Where(it => (it.UserPrincipalName == userPrincipalName)).ExecuteAsync().Result.CurrentPage.FirstOrDefault();
        //    var userFetcher = currentUser as IUserFetcher;
        //    IPagedCollection rawObjects = (IPagedCollection)userFetcher.AppRoleAssignments.ExecuteAsync().Result;

        //    var aaprole = (from IAppRoleAssignment item in rawObjects.CurrentPage
        //                   select item).Where(a => a.Id == appRoleId).FirstOrDefault();

        //   // string requestUrlUserAppRole = AuthenticationHelper.ResourceUrl + "/" + AuthenticationHelper.TenantId + "/users/" + userPrincipalName + "/appRoleAssignments/" + aaprole.ObjectId + "?api-version=1.5";
        //    string requestUrlUserAppRole = AuthenticationHelper.ResourceUrl + "/" + AuthenticationHelper.TenantId + "/users/" + currentUser.ObjectId + "/appRoleAssignments/" + aaprole.ObjectId + "?api-version=1.5";

        //    System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(requestUrlUserAppRole);
        //    request.Method = "DELETE";
        //    request.ContentType = "application/json";
        //    if (string.IsNullOrEmpty(AuthenticationHelper.TokenForApplication))
        //        AuthenticationHelper.GetTokenForApplication();
        //    request.Headers.Add("Authorization", AuthenticationHelper.TokenForApplication);
        //    string UserAppRole;

        //    System.Net.WebResponse response = request.GetResponse();
        //    System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
        //    UserAppRole = sr.ReadToEnd();
        //}

        //public void UnAssignRole(string userId, Guid appRoleId)
        //{
        //    User currentUser = activeDirectoryClient.DirectoryObjects.OfType<User>().Where(it => (it.ObjectId == userId)).ExecuteAsync().Result.CurrentPage.FirstOrDefault();
        //    var userFetcher = currentUser as IUserFetcher;
        //    IPagedCollection rawObjects = (IPagedCollection)userFetcher.AppRoleAssignments.ExecuteAsync().Result;

        //    var aaprole = (from IAppRoleAssignment item in rawObjects.CurrentPage
        //                   select item).Where(a => a.Id == appRoleId).FirstOrDefault();

        //    string requestUrlUserAppRole = AuthenticationHelper.ResourceUrl + "/" + AuthenticationHelper.TenantId + "/users/" + userId + "/appRoleAssignments/" + aaprole.ObjectId + "?api-version=1.5";

        //    System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(requestUrlUserAppRole);
        //    request.Method = "DELETE";
        //    request.ContentType = "application/json";
        //    if (string.IsNullOrEmpty(AuthenticationHelper.TokenForApplication))
        //        AuthenticationHelper.GetTokenForApplication();
        //    request.Headers.Add("Authorization", AuthenticationHelper.TokenForApplication);
        //    string UserAppRole;

        //    System.Net.WebResponse response = request.GetResponse();
        //    System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
        //    UserAppRole = sr.ReadToEnd();
        //}

        public List<AppRole> UserApplicationRoleFetcher(User currentUser)
        {
            List<AppRole> applicationRoleList = ApplicationRoleList();
            List<AppRole> currentUserRolesList = new List<AppRole>();
            lock (_lock)
            {
                currentUserRolesList = _cache.Get(currentUser.ObjectId + "_User_Roles") as List<AppRole>;
            }

            if (currentUserRolesList == null)
            {
                currentUserRolesList = currentUserRolesList = new List<AppRole>();
                var userFetcher = currentUser as IUserFetcher;
                IPagedCollection rawObjects = (IPagedCollection)userFetcher.AppRoleAssignments.ExecuteAsync().Result;

                foreach (IAppRoleAssignment item in rawObjects.CurrentPage)
                {
                    AppRole appRole = item as AppRole;
                    foreach (AppRole ap in applicationRoleList)
                    {
                        if (ap.Id == item.Id)
                        {
                            currentUserRolesList.Add(ap);
                        }
                    }

                }
                lock (_lock)
                {
                    CacheItemPolicy policy = new CacheItemPolicy();
                    policy.AbsoluteExpiration = new DateTimeOffset(DateTime.UtcNow.AddMinutes(30));
                    _cache.Set(currentUser.ObjectId + "_User_Roles", currentUserRolesList, policy);
                }
            }
            return currentUserRolesList;
        }
        /// <summary>
        /// Gets the list of Application Role
        /// </summary>
        /// <returns></returns>
        public List<AppRole> ApplicationRoleList()
        {
            var principals = activeDirectoryClient.ServicePrincipals
                      .Where(principal => principal.AppId.Equals(AuthenticationHelper.ClientId))
                       .ExecuteAsync().Result.CurrentPage.ToList();
            var sp = principals.FirstOrDefault();
            var roleList = new List<AppRole>();
            foreach (AppRole ap in sp.AppRoles)
            {
                roleList.Add(ap);

            }


            return roleList;
        }

        ///Newly Added 
        ///
        public void RegisterNewExtensionProperty(string propertyName)
        {
            string extPropLookupName = string.Format("extension_{0}_{1}", AuthenticationHelper.ClientId.Replace("-", ""), propertyName);
            IEnumerable<IExtensionProperty> allExtProperties = null;

            var allExtPropertiesTask = System.Threading.Tasks.Task.Run(async () => { allExtProperties = await activeDirectoryClient.GetAvailableExtensionPropertiesAsync(false); });
            allExtPropertiesTask.Wait();
            if (allExtProperties != null)
            {
                IExtensionProperty InfoExtProperty = allExtProperties.Where(
                    extProp => extProp.Name == extPropLookupName).FirstOrDefault();
                if (InfoExtProperty == null)
                {

                    ExtensionProperty extensionProperty = new ExtensionProperty()
                    {
                        Name = propertyName,
                        DataType = "String",
                        TargetObjects = { "User" }
                    };

                    Microsoft.Azure.ActiveDirectory.GraphClient.Application app = null;

                    var appTask = System.Threading.Tasks.Task.Run(async () =>
                    {
                        var iapp = await activeDirectoryClient.Applications.Where(
                                        a => a.AppId == AuthenticationHelper.ClientId).ExecuteSingleAsync();
                        app = (Microsoft.Azure.ActiveDirectory.GraphClient.Application)iapp;
                    });

                    appTask.Wait();

                    if (app == null)
                    {
                        throw new ApplicationException("Unable to get a reference to application in Azure AD.");
                    }
                    app.ExtensionProperties.Add(extensionProperty);


                    var updateTask = System.Threading.Tasks.Task.Run(async () => { await app.UpdateAsync(); });
                    updateTask.Wait();
                    // Apply the change to Azure AD
                    app.GetContext().SaveChanges();
                }
            }
        }

        public void SetUserLastLogin(string upn, string propertyName)
        {

            User user = null;
            IUser iuser = default(User);
            var userTask = System.Threading.Tasks.Task.Run(async () =>
            {
                iuser = await activeDirectoryClient.Users.Where(u => u.UserPrincipalName.Equals(
                    upn, StringComparison.CurrentCultureIgnoreCase)).ExecuteSingleAsync();

            });
            userTask.Wait();
            if (iuser == default(User))
                user = (User)iuser;

            if (user != null)
            {
                string extPropLookupName = string.Format("extension_{0}_{1}", AuthenticationHelper.ClientId.Replace("-", ""), propertyName);
                user.SetExtendedProperty(extPropLookupName, DateTime.Now.ToString());
                var updateTask = System.Threading.Tasks.Task.Run(async () => { await user.UpdateAsync(); });
                updateTask.Wait();
                // Save the extended property value to Azure AD.
                user.GetContext().SaveChanges();
            }
        }

        // public List<ExtUserMap> GetUserList(string userToSearch)
        //public User getUser(string currentUserObjectId)

        public List<User> GetUser(string userToSearch, int searchType = 1)
        {
            List<string> retrievedUsersList = new List<string>(); ;
            List<IUser> usersList = null;
            IPagedCollection<IUser> searchResults = null;
            IUserCollection userCollection = null;
            try
            {
                if (searchType == 1)
                {
                    userCollection = activeDirectoryClient.Users;
                    searchResults = userCollection.Where(user =>
                        user.UserPrincipalName.Equals(userToSearch)).ExecuteAsync().Result;
                }
                else
                {
                    userCollection = activeDirectoryClient.Users;
                    searchResults = userCollection.Where(user =>
                        user.UserPrincipalName.StartsWith(userToSearch)).ExecuteAsync().Result;
                }
                usersList = searchResults.CurrentPage.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("Error searching user : {0} {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : ""));

            }

            List<User> list = new List<User>();
            if (usersList != null && usersList.Count > 0)
            {
                do
                {
                    usersList = searchResults.CurrentPage.ToList();
                    foreach (User user in usersList)
                    {
                        //retrievedUsersList.Add(user.UserPrincipalName);
                        list.Add(user);
                    }
                    searchResults = Task.Run(() => searchResults.GetNextPageAsync()).Result;
                } while (searchResults != null);
            }


            return list;

        }

        public List<Group> GetGroup(string groupToSearch, int searchType = 1)
        {
            List<string> retrievedGroupList = new List<string>(); ;
            List<IGroup> groupsList = null;
            IPagedCollection<IGroup> searchResults = null;
            IGroupCollection groupCollection = null;
            try
            {
                if (searchType == 1)
                {
                    groupCollection = activeDirectoryClient.Groups;
                    searchResults = groupCollection.Where(group =>
                        group.DisplayName.Equals(groupToSearch)).ExecuteAsync().Result;
                }
                else
                {
                    groupCollection = activeDirectoryClient.Groups;
                    searchResults = groupCollection.Where(group =>
                         group.DisplayName.StartsWith(groupToSearch)).ExecuteAsync().Result;
                }
                groupsList = searchResults.CurrentPage.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("Error searching group : {0} {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : ""));

            }

            List<Group> list = new List<Group>();
            if (groupsList != null && groupsList.Count > 0)
            {
                do
                {
                    groupsList = searchResults.CurrentPage.ToList();
                    foreach (Group group in groupsList)
                    {

                        list.Add(group);
                    }
                    searchResults = Task.Run(() => searchResults.GetNextPageAsync()).Result;
                } while (searchResults != null);
            }


            return list;

        }


        public List<ExtUserMap> GetAssignedUserList(string userToSearch)
        {
            List<User> users = new List<User>();
            List<IUser> usersList = null;
            IPagedCollection<IUser> searchResults = null;

            try
            {
                IUserCollection userCollection = activeDirectoryClient.Users;
                searchResults = userCollection.Where(user =>
                    user.UserPrincipalName.StartsWith(userToSearch)).ExecuteAsync().Result;
                usersList = searchResults.CurrentPage.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("Error searching user : {0} {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : ""));

            }
            if (usersList != null && usersList.Count > 0)
            {
                do
                {
                    usersList = searchResults.CurrentPage.ToList();
                    foreach (IUser user in usersList)
                    {
                        users.Add((User)user);

                    }
                    searchResults = Task.Run(() => searchResults.GetNextPageAsync()).Result;
                } while (searchResults != null);
            }

            List<ExtUserMap> retrievedUsersList = new List<ExtUserMap>();
            //Add only Users with Admin or Editor Role
            List<AppRole> applicationRoleList = ApplicationRoleList();
            foreach (User u in users)
            {
                List<AppRole> apRole = UserApplicationRoleFetcher(u, applicationRoleList);

                if (apRole != null)
                {
                    if (apRole.Count > 0)
                    {

                        retrievedUsersList.Add(new ExtUserMap { objectId = u.ObjectId, extName = ((u.UserPrincipalName.Contains("#EXT#") && u.OtherMails != null && u.OtherMails.Count > 0) ? u.OtherMails[0] : u.UserPrincipalName), internalUPN = u.UserPrincipalName });
                    }
                }

            }

            return retrievedUsersList;
        }

        public List<ExtUserMap> GetAssignedUserListToDelegate(string userToSearch)
        {
            List<User> users = new List<User>();
            List<IUser> usersList = null;
            IPagedCollection<IUser> searchResults = null;

            try
            {
                IUserCollection userCollection = activeDirectoryClient.Users;
                searchResults = userCollection.Where(user =>
                    user.UserPrincipalName.StartsWith(userToSearch)).ExecuteAsync().Result;
                usersList = searchResults.CurrentPage.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("Error searching user : {0} {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : ""));

            }
            if (usersList != null && usersList.Count > 0)
            {
                do
                {
                    usersList = searchResults.CurrentPage.ToList();
                    foreach (IUser user in usersList)
                    {
                        users.Add((User)user);

                    }
                    searchResults = Task.Run(() => searchResults.GetNextPageAsync()).Result;
                } while (searchResults != null);
            }

            List<ExtUserMap> retrievedUsersList = new List<ExtUserMap>();
            //Add only Users with Admin or Editor Role
            List<AppRole> applicationRoleList = ApplicationRoleList();
            foreach (User u in users)
            {
                List<AppRole> apRole = UserApplicationRoleFetcher(u, applicationRoleList);

                if (apRole != null)
                {
                    if (apRole.Count > 0)
                    {
                        var viewers = apRole.Where(x => x.Value.ToLower() == "administrator" || x.Value.ToLower() == "BIRCreator".ToLower() ||
                             x.Value.ToLower() == "editor" || x.Value.ToLower() == "member" ||
                            x.Value.ToLower() == "turbinetechnicians" || x.Value.ToLower() == "contractorturbinetechnicians").Count();
                        if (viewers > 0)
                        {
                            retrievedUsersList.Add(new ExtUserMap { objectId = u.ObjectId, extName = ((u.UserPrincipalName.Contains("#EXT#") && u.OtherMails != null && u.OtherMails.Count > 0) ? u.OtherMails[0] : u.UserPrincipalName), internalUPN = u.UserPrincipalName });
                        }
                    }
                }

            }

            return retrievedUsersList;
        }
        public void AssignRole(User u, AppRole appRole)
        {
            // User currentUser = activeDirectoryClient.DirectoryObjects.OfType<User>().Where(it => (it.UserPrincipalName == userPrincipalName)).ExecuteAsync().Result.CurrentPage.FirstOrDefault();

            var principals = activeDirectoryClient.ServicePrincipals
                      .Where(principal => principal.AppId.Equals(AuthenticationHelper.ClientId))
                       .ExecuteAsync().Result.CurrentPage.ToList();
            var sp = principals.FirstOrDefault();

            string appjson = "{ \"id\": \"" + appRole.Id + "\", \"principalId\":  \"" + u.ObjectId + "\", \"principalType\": \"User\", \"resourceId\":  \"" + sp.ObjectId + "\"}";
            string requestUrlUserAppRole = AuthenticationHelper.ResourceUrl + "/" + AuthenticationHelper.TenantId + "/users/" + u.ObjectId + "/appRoleAssignments?api-version=1.5";

            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(requestUrlUserAppRole);
            request.Method = "POST";
            request.ContentType = "application/json";
            using (System.IO.Stream s = request.GetRequestStream())
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s))
                    sw.Write(appjson);
            }
            if (string.IsNullOrEmpty(AuthenticationHelper.TokenForApplication))
                AuthenticationHelper.GetTokenForApplication();
            request.Headers.Add("Authorization", AuthenticationHelper.TokenForApplication);
            string UserAppRole;

            System.Net.WebResponse response = request.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
            UserAppRole = sr.ReadToEnd();
            try
            {
                _cache.Remove(u.ObjectId + "_User_Roles");
            }
            catch { }
        }

        public void AssignRoleToGroup(Group g, AppRole appRole)
        {
            // User currentUser = activeDirectoryClient.DirectoryObjects.OfType<User>().Where(it => (it.UserPrincipalName == userPrincipalName)).ExecuteAsync().Result.CurrentPage.FirstOrDefault();

            var principals = activeDirectoryClient.ServicePrincipals
                      .Where(principal => principal.AppId.Equals(AuthenticationHelper.ClientId))
                       .ExecuteAsync().Result.CurrentPage.ToList();
            var sp = principals.FirstOrDefault();

            string appjson = "{ \"id\": \"" + appRole.Id + "\", \"principalId\":  \"" + g.ObjectId + "\", \"principalType\": \"Group\", \"resourceId\":  \"" + sp.ObjectId + "\"}";
            string requestUrlGroupAppRole = AuthenticationHelper.ResourceUrl + "/" + AuthenticationHelper.TenantId + "/groups/" + g.ObjectId + "/appRoleAssignments?api-version=1.5";

            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(requestUrlGroupAppRole);
            request.Method = "POST";
            request.ContentType = "application/json";
            using (System.IO.Stream s = request.GetRequestStream())
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s))
                    sw.Write(appjson);
            }
            if (string.IsNullOrEmpty(AuthenticationHelper.TokenForApplication))
                AuthenticationHelper.GetTokenForApplication();
            request.Headers.Add("Authorization", AuthenticationHelper.TokenForApplication);
            string GroupAppRole;

            System.Net.WebResponse response = request.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
            GroupAppRole = sr.ReadToEnd();
        }


        public void UnAssignRole(string userId, Guid appRoleId)
        {
            User currentUser = activeDirectoryClient.DirectoryObjects.OfType<User>().Where(it => (it.ObjectId == userId)).ExecuteAsync().Result.CurrentPage.FirstOrDefault();
            var userFetcher = currentUser as IUserFetcher;
            IPagedCollection rawObjects = (IPagedCollection)userFetcher.AppRoleAssignments.ExecuteAsync().Result;

            var aaprole = (from IAppRoleAssignment item in rawObjects.CurrentPage
                           select item).Where(a => a.Id == appRoleId).FirstOrDefault();

            string requestUrlUserAppRole = AuthenticationHelper.ResourceUrl + "/" + AuthenticationHelper.TenantId + "/users/" + userId + "/appRoleAssignments/" + aaprole.ObjectId + "?api-version=1.5";

            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(requestUrlUserAppRole);
            request.Method = "DELETE";
            request.ContentType = "application/json";
            if (string.IsNullOrEmpty(AuthenticationHelper.TokenForApplication))
                AuthenticationHelper.GetTokenForApplication();
            request.Headers.Add("Authorization", AuthenticationHelper.TokenForApplication);
            string UserAppRole;

            System.Net.WebResponse response = request.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
            UserAppRole = sr.ReadToEnd();
            try
            {
                _cache.Remove(currentUser.ObjectId + "_User_Roles");
            }
            catch { }
        }

        public void UnAssignRoleToGroup(string groupId, Guid appRoleId)
        {
            Group currentGroup = activeDirectoryClient.DirectoryObjects.OfType<Group>().Where(it => (it.ObjectId == groupId)).ExecuteAsync().Result.CurrentPage.FirstOrDefault();
            var groupFetcher = currentGroup as IGroupFetcher;
            IPagedCollection rawObjects = (IPagedCollection)groupFetcher.AppRoleAssignments.ExecuteAsync().Result;

            var aaprole = (from IAppRoleAssignment item in rawObjects.CurrentPage
                           select item).Where(a => a.Id == appRoleId).FirstOrDefault();

            string requestUrlGroupAppRole = AuthenticationHelper.ResourceUrl + "/" + AuthenticationHelper.TenantId + "/groups/" + groupId + "/appRoleAssignments/" + aaprole.ObjectId + "?api-version=1.5";

            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(requestUrlGroupAppRole);
            request.Method = "DELETE";
            request.ContentType = "application/json";
            if (string.IsNullOrEmpty(AuthenticationHelper.TokenForApplication))
                AuthenticationHelper.GetTokenForApplication();
            request.Headers.Add("Authorization", AuthenticationHelper.TokenForApplication);
            string GroupAppRole;

            System.Net.WebResponse response = request.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
            GroupAppRole = sr.ReadToEnd();
        }

        public List<AppRole> UserApplicationRoleFetcher(User currentUser, List<AppRole> applicationRoleList)
        {

            List<AppRole> currentUserRolesList = new List<AppRole>();
            var userFetcher = currentUser as IUserFetcher;
            IPagedCollection rawObjects = (IPagedCollection)userFetcher.AppRoleAssignments.ExecuteAsync().Result;
            applicationRoleList = applicationRoleList.OrderBy(x => x.DisplayName).ToList();
            foreach (IAppRoleAssignment item in rawObjects.CurrentPage)
            {
                foreach (AppRole ap in applicationRoleList)
                {
                    if (ap.Id == item.Id)
                    {
                        currentUserRolesList.Add(ap);
                    }
                }

            }
            currentUserRolesList = currentUserRolesList.OrderBy(x => x.DisplayName).ToList();
            return currentUserRolesList;
        }

        public List<AppRole> GroupApplicationRoleFetcher(Group group, List<AppRole> applicationRoleList)
        {

            List<AppRole> currentGroupRolesList = new List<AppRole>();
            var groupFetcher = group as IGroupFetcher;
            IPagedCollection rawObjects = (IPagedCollection)groupFetcher.AppRoleAssignments.ExecuteAsync().Result;
            applicationRoleList = applicationRoleList.OrderBy(x => x.DisplayName).ToList();
            foreach (IAppRoleAssignment item in rawObjects.CurrentPage)
            {
                foreach (AppRole ap in applicationRoleList)
                {
                    if (ap.Id == item.Id)
                    {
                        currentGroupRolesList.Add(ap);
                    }
                }

            }
            currentGroupRolesList = currentGroupRolesList.OrderBy(x => x.DisplayName).ToList();
            return currentGroupRolesList;
        }

        public string getUserRolesInString(string userName)
        {
            User user = getUserByPrincipalName(userName);
            List<AppRole> applicationRoleList = ApplicationRoleList();
            List<AppRole> roles = UserApplicationRoleFetcher(user, applicationRoleList);
            List<string> r = roles.Select(x => "[" + x.DisplayName + "]").ToList();
            return string.Join(",", r);
        }

        public List<string> GetUsersinRoles(string RoleId)
        {
            var guidAppRoleId = Guid.Parse(RoleId);
            var principals = activeDirectoryClient.ServicePrincipals
                     .Where(principal => principal.AppId.Equals(AuthenticationHelper.ClientId))
                      .ExecuteAsync().Result.CurrentPage.ToList();
            var sp = principals.FirstOrDefault();

            var appRoleAssignmentsPaged = activeDirectoryClient.ServicePrincipals
           .GetByObjectId(sp.ObjectId)
           .AppRoleAssignedTo
           .ExecuteAsync().Result;

            var appRoleAssignments = ADExtensions.EnumerateAllAsync(appRoleAssignmentsPaged);
            var userObjectIds = appRoleAssignments
           .Where(a => a.Id == guidAppRoleId && a.PrincipalType == "User")
           .Select(a => a.PrincipalId.ToString())
           .Distinct()
           .ToList();



            return userObjectIds;

        }

        public List<string> GetGroupsinRoles(string RoleId)
        {
            var guidAppRoleId = Guid.Parse(RoleId);
            var principals = activeDirectoryClient.ServicePrincipals
                     .Where(principal => principal.AppId.Equals(AuthenticationHelper.ClientId))
                      .ExecuteAsync().Result.CurrentPage.ToList();
            var sp = principals.FirstOrDefault();

            var appRoleAssignmentsPaged = activeDirectoryClient.ServicePrincipals
           .GetByObjectId(sp.ObjectId)
           .AppRoleAssignedTo
           .ExecuteAsync().Result;

            var appRoleAssignments = ADExtensions.EnumerateAllAsync(appRoleAssignmentsPaged);
            var groupsObjectIds = appRoleAssignments
           .Where(a => a.Id == guidAppRoleId && a.PrincipalType == "Group")
           .Select(a => a.PrincipalId.ToString())
           .Distinct()
           .ToList();



            return groupsObjectIds;

        }


        public string GetUserFromObjectID(string Id)
        {
            string requestUrlUser = AuthenticationHelper.ResourceUrl + "/" + AuthenticationHelper.TenantId + "/users/" + Id + "?api-version=1.5";

            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(requestUrlUser);
            request.Method = "GET";
            request.ContentType = "application/json";
            if (string.IsNullOrEmpty(AuthenticationHelper.TokenForApplication))
                AuthenticationHelper.GetTokenForApplication();
            request.Headers.Add("Authorization", AuthenticationHelper.TokenForApplication);
            string UserString = "";

            System.Net.WebResponse response = request.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
            UserString = sr.ReadToEnd();
            return UserString;
        }
    }

    static class ADExtensions
    {
        public static IEnumerable<T> EnumerateAllAsync<T>(
                this IPagedCollection<T> pagedCollection)
        {
            return EnumerateAllAsync(pagedCollection, Enumerable.Empty<T>());
        }


        private static IEnumerable<T> EnumerateAllAsync<T>(
       this IPagedCollection<T> pagedCollection,
       IEnumerable<T> previousItems)
        {
            var newPreviousItems = previousItems.Concat(pagedCollection.CurrentPage);

            if (pagedCollection.MorePagesAvailable == false)
                return newPreviousItems;

            IPagedCollection<T> newPagedCollection = null;

            var _newPagedCollection = Task.Run(async () => { newPagedCollection = await pagedCollection.GetNextPageAsync(); });
            _newPagedCollection.Wait();
            return EnumerateAllAsync(newPagedCollection, newPreviousItems);
        }


    }
}