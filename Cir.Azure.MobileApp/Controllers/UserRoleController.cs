using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using System.Threading.Tasks;
using Cir.Azure.MobileApp.DataObjects;
using Cir.Azure.MobileApp.Utilities;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server;
using System.Web.Http.Tracing;
using System.Web.Http.Cors;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Azure.ActiveDirectory.GraphClient;


namespace Cir.Azure.MobileApp.Controllers
{
    [MobileAppController]
    [Authorize]

    public class UserRoleController : ApiController
    {
        private AuthenticationUtilities AuthUtil { get; set; }

        [AuthorizeAadRole(Roles = "Administrator")]
        [Route("api/UserRoles/{UserId}")]
        public List<AppRole> GetUserRoles(string UserId)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered UserRole/Get custom controller!");
            AuthUtil = new AuthenticationUtilities(this);
            return AuthUtil.GetAppRolesAssignment(UserId);
        }
        [AuthorizeAadRole(Roles = "Administrator")]
        public bool Post(UserRoleMap userRoleMap)
        {
            try
            {
                this.Configuration.Services.GetTraceWriter().Info("Entered UserRole/Get custom controller!");
                AuthUtil = new AuthenticationUtilities(this);
                return AuthUtil.AddAppRolesAssignment(userRoleMap);

            }
            catch (Exception ex)
            {
                //return ex.Message + " \n " + ex.StackTrace;
                throw new Exception(ex.Message + " \n " + ex.StackTrace, ex);

            }
        }
        [AuthorizeAadRole(Roles = "Administrator")]
        public bool Delete(UserRoleMap userRoleMap)
        {
            try
            {
                this.Configuration.Services.GetTraceWriter().Info("Entered UserRole/Get custom controller!");
                AuthUtil = new AuthenticationUtilities(this);
                return AuthUtil.RemoveAppRolesAssignment(userRoleMap);
            }
            catch (Exception ex)
            {
                //return ex.Message + " \n " + ex.StackTrace;
                throw new Exception(ex.Message + " \n " + ex.StackTrace, ex);

            }
        }
        [AuthorizeAadRole(Roles = "Administrator")]
        [Route("api/AppRoles/")]
        public List<AppRole> GetAppRoles()
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered UserRole/GetAppRoles custom controller!");
            AuthUtil = new AuthenticationUtilities(this);
            return AuthUtil.GetAADAppRole();
        }
        [AuthorizeAadRole(Roles = "Administrator")]
        [Route("api/Users/{userSearchKeywrod}")]
        public List<ExtUserMap> GetUsers(string userSearchKeywrod)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered UserRole/GetAppRoles custom controller!");
            AuthUtil = new AuthenticationUtilities(this);
            return AuthUtil.GetAADUserList(userSearchKeywrod);
        }

        [AuthorizeAadRole(Roles = "Administrator")]
        [Route("api/GetUsersAssignedRolesData/{RoleId}/{userName}/{searchType}")]
        public List<UserDisplayModel> GetUsersAssignedRolesData(string RoleId, string userName, int searchType = 1)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered UserRole/GetUsersAssignedRolesData custom controller!");
            AuthUtil = new AuthenticationUtilities(this);
            return AuthUtil.GetUsersAssignedRolesData(RoleId, userName, searchType);
        }
        [AuthorizeAadRole(Roles = "Administrator")]
        [Route("api/GetUsersAssignedRoles/{RoleId}/{userName}")]
        public List<UserDisplayModel> GetUsersAssignedRoles(string RoleId, string userName)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered UserRole/GetUsersAssignedRoles custom controller!");
            AuthUtil = new AuthenticationUtilities(this);
            return AuthUtil.GetUsersAssignedRoles(RoleId, userName);
        }

        [AuthorizeAadRole(Roles = "Administrator")]
        [Route("api/GetGroupsAssignedRoles/{RoleId}")]
        public List<GroupDisplayModel> GetGroupsAssignedRoles(string RoleId)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered UserRole/GetUsersAssignedRoles custom controller!");
            AuthUtil = new AuthenticationUtilities(this);
            return AuthUtil.GetGroupAssignedRolesData(RoleId, "");
        }
        [AuthorizeAadRole(Roles = "Administrator")]
        [Route("api/GetAssignRole/{userName}/{roleId}/{uId}/{roleToDisplay}")]
        public UserDisplayModel GetAssignRole(string userName, string roleId, string uId = "0", string roleToDisplay = "0")
        {
            uId = (uId == "0") ? "" : uId;
            this.Configuration.Services.GetTraceWriter().Info("Entered UserRole/AssignRole custom controller!");
            AuthUtil = new AuthenticationUtilities(this);
            return AuthUtil.AssignRole(userName, roleId, uId, roleToDisplay);
        }
        [AuthorizeAadRole(Roles = "Administrator")]
        [Route("api/GetAssignRoleToGroup/{groupName}/{roleId}/{gId}/{roleToDisplay}")]
        public GroupDisplayModel GetAssignRoleToGroup(string groupName, string roleId, string gId = "0", string roleToDisplay = "0")
        {
            gId = (gId == "0") ? "" : gId;
            this.Configuration.Services.GetTraceWriter().Info("Entered UserRole/AssignRole custom controller!");
            AuthUtil = new AuthenticationUtilities(this);
            return AuthUtil.AssignRoleToGroup(groupName, roleId, gId, roleToDisplay);
        }
        [AuthorizeAadRole(Roles = "Administrator")]
        [Route("api/GetUnAssignAllRole/{uid}/{userName}/{roleToDisplay}")]
        public UserDisplayModel GetUnAssignAllRole(string uid, string userName, string roleToDisplay = "0")
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered UserRole/UnAssignAllRole custom controller!");
            AuthUtil = new AuthenticationUtilities(this);
            return AuthUtil.UnAssignAllRole(uid, userName, roleToDisplay);
        }
        [AuthorizeAadRole(Roles = "Administrator")]
        [Route("api/GetUnAssignAllRoleToGroup/{gid}/{groupName}/{roleToDisplay}")]
        public GroupDisplayModel GetUnAssignAllRoleToGroup(string gid, string groupName, string roleToDisplay = "0")
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered UserRole/UnAssignAllRole custom controller!");
            AuthUtil = new AuthenticationUtilities(this);
            return AuthUtil.UnAssignAllRoleToGroup(gid, groupName, roleToDisplay);
        }

        [Route("api/GetUnAssignRole/{uid}/{roleIdToRemove}/{roleIdToDisplay}")]
        public UserDisplayModel GetUnAssignRole(string uid, string roleIdToRemove, string roleIdToDisplay)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered UserRole/UnAssignRole custom controller!");
            AuthUtil = new AuthenticationUtilities(this);
            return AuthUtil.UnAssignRole(uid, roleIdToRemove, roleIdToDisplay, "");
        }
        [AuthorizeAadRole(Roles = "Administrator")]
        [Route("api/GetUnAssignRoleToGroup/{gid}/{roleIdToRemove}/{roleIdToDisplay}")]
        public GroupDisplayModel GetUnAssignRoleToGroup(string gid, string roleIdToRemove, string roleIdToDisplay)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered UserRole/UnAssignRole custom controller!");
            AuthUtil = new AuthenticationUtilities(this);
            return AuthUtil.UnAssignRoleToGroup(gid, roleIdToRemove, roleIdToDisplay, "");
        }
        [AuthorizeAadRole(Roles = "Administrator")]
        [Route("api/GetUsersRoles/{uid}")]
        public UserDisplayModel GetUsersRoles(string uid)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered UserRole/GetUsersRoles custom controller!");
            AuthUtil = new AuthenticationUtilities(this);
            return AuthUtil.GetUsersRoles(uid);
        }
        [AuthorizeAadRole(Roles = "Administrator")]
        [Route("api/GetSearchUser/{SearchUser}/{searchType}")]
        public List<UserDisplayModel> GetSearchUser(string SearchUser, int searchType = 1)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered UserRole/GetUsersRoles custom controller!");
            AuthUtil = new AuthenticationUtilities(this);
            return AuthUtil.SearchUser(SearchUser, searchType);
        }
        [AuthorizeAadRole(Roles = "Administrator")]
        [Route("api/GetSearchGroup/{SearchGroup}")]
        public List<GroupDisplayModel> GetSearchGroup(string SearchGroup)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered UserRole/GetUsersRoles custom controller!");
            AuthUtil = new AuthenticationUtilities(this);
            return AuthUtil.SearchGroup(SearchGroup);
        }
        [AuthorizeAadRole(Roles = "Administrator")]
        [Route("api/GetLastSeen/{userId}")]
        public string GetLastSeen(string userId)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered UserRole/FetchUserRole custom controller!");
            AuthUtil = new AuthenticationUtilities(this);
            return AuthUtil.GetLastSeen(userId);
        }

        //[HttpPut]
        //[Route("api/SetLastSeen")]
        //public void PutLastSeen()
        //{

        //    AzureActiveDirectoryCredentials userInfo = null;
        //    var getUserInfo = System.Threading.Tasks.Task.Run(async () => { userInfo = await ((MobileAppUser)this.User).GetIdentityAsync<AzureActiveDirectoryCredentials>(); });
        //    getUserInfo.Wait();

        //    this.Configuration.Services.GetTraceWriter().Info("Entered UserRole/FetchUserRole custom controller!");
        //    AuthUtil = new AuthenticationUtilities(this);
        //    AuthUtil.SetLastSeen(userInfo.ObjectId);
        //}
        [AuthorizeAadRole(Roles = "Administrator")]
        [Route("api/GetFetchUserRole/{userId}")]
        public List<AppRole> GetFetchUserRole(string userId)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered UserRole/FetchUserRole custom controller!");
            AuthUtil = new AuthenticationUtilities(this);
            return AuthUtil.FetchUserRole(userId);
        }

        [AuthorizeAadRole(Roles = "*")]
        [Route("api/GetAssignedUser/{userToSearch}")]
        public List<ExtUserMap> GetSearchAssignedUser(string userToSearch)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered UserRole/SearchAssignedUser custom controller!");
            AuthUtil = new AuthenticationUtilities(this);
            return AuthUtil.SearchAssignedUserToDelegate(userToSearch);
        }
        [AuthorizeAadRole(Roles = "Administrator")]
        [Route("api/Groups/{groupSearchKeywrod}")]
        public List<Group> GetGroups(string groupSearchKeywrod)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered UserRole/GetAppRoles custom controller!");
            AuthUtil = new AuthenticationUtilities(this);
            return AuthUtil.GetAADGroupList(groupSearchKeywrod);
        }

    }
}
