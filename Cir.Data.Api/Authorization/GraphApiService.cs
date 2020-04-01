using Cir.Data.Access.Models.Authorization;
using Cir.Data.Api.DataManipulation;
using Microsoft.ApplicationInsights;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.Data.OData;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Caching;
using System.Threading;
using System.Threading.Tasks;

namespace Cir.Data.Api.Authorization
{
    internal class GraphApiService : IGraphApiService
    {
        private readonly string ClientId = ConfigurationManager.AppSettings.Get("ClientId");
        private readonly ActiveDirectoryClient _activeDirectoryClient;
        private readonly MemoryCache _userMemoryCache;
        private TelemetryClient _telemetryClient = new TelemetryClient();
        private readonly string _userCachePostfix;
        private readonly TimeSpan _cacheTtl;

        private static readonly SemaphoreSlim CacheLock = new SemaphoreSlim(1, 1);

        public GraphApiService(ActiveDirectoryClient activeDirectoryClient, MemoryCache userMemoryCache,
            string userCachePostfix, TimeSpan cacheTtl, ILogger log)
        {
            _activeDirectoryClient = activeDirectoryClient;
            _userMemoryCache = userMemoryCache;
            _userCachePostfix = userCachePostfix;
            _cacheTtl = cacheTtl;
        }

        public async Task<UserInformation> GetUserAsync(string userId)
        {
            var userCacheKey = $"{userId}_{_userCachePostfix}";

            var userInformation = _userMemoryCache.Get(userCacheKey) as UserInformation;

            if (userInformation != null)
            {
                _telemetryClient.TrackEvent("Found user" + userId + " in cache");
                return userInformation;
            }

            try
            {
                await CacheLock.WaitAsync();

                userInformation = _userMemoryCache.Get(userCacheKey) as UserInformation;

                if (userInformation != null)
                {
                    _telemetryClient.TrackEvent("Found user" + userId + " in cache");
                    return userInformation;
                }

                var graphUserInformation = await GetUserInformationAsync(userId);

                _userMemoryCache.Set(userCacheKey, graphUserInformation,
                    DateTimeOffset.Now.AddMinutes(_cacheTtl.Minutes));
                return graphUserInformation;
            }
            finally
            {
                CacheLock.Release();
            }
        }

        private async Task<UserInformation> GetUserInformationAsync(string userId)
        {
            try
            {
                IUserFetcher userFetcher = _activeDirectoryClient.Users.GetByObjectId(userId);
                var user = await userFetcher.ExecuteAsync();
                var userGroups = await GetUserGroupsAsync(userFetcher);
                var userRoles = await GetUserAppRolesAsync(userFetcher);

                _telemetryClient.TrackEvent("Got User from GraphApi " + userId);

                return new UserInformation
                {
                    AppRoles = userRoles?.Select(x => x.DisplayName).ToArray(),
                    State = user?.State,
                    City = user?.City,
                    StreetAddress = user?.StreetAddress,
                    UserPrincipalName = user?.UserPrincipalName,
                    PostalCode = user?.PostalCode,
                    Mail = user?.Mail,
                    OtherMails = user?.OtherMails?.ToArray(),
                    DisplayName = UserIdParameterManipulator.ConvertUserIdFromPrincipalNameToInitials(user?.UserPrincipalName),
                    FirstName = user?.GivenName,
                    LastName = user?.Surname,
                    UserName = user?.MailNickname,
                    UserGroups = (userGroups != null) ? userGroups.ToArray() : new string[] { }
                };
            }
            catch (ODataErrorException e)
            {
                _telemetryClient.TrackEvent("Failed to fetch User, trying ServicePrincipal for userid " + userId + "exception: " + e);

                IServicePrincipal service = await _activeDirectoryClient.ServicePrincipals.GetByObjectId(userId).ExecuteAsync();

                _telemetryClient.TrackEvent("Got ServicePrincipal from GraphApi for userid " + userId + "exception: " + e);

                return new UserInformation
                {
                    DisplayName = service.AppDisplayName,
                    AppRoles = service.AppRoles.Select(x => x.DisplayName).ToArray()
                };
            }
        }

        private async Task<List<AppRole>> GetUserAppRolesAsync(IUserFetcher userFetcher)
        {
            var appRoleAssignments = await userFetcher.AppRoleAssignments.ExecuteAsync();
            var applicationRoles = await GetApplicationRoles();

            return applicationRoles.Where(x => appRoleAssignments.CurrentPage.Any(y => y.Id == x.Id)).ToList();
        }

        private async Task<IEnumerable<AppRole>> GetApplicationRoles()
        {
            var principals = await _activeDirectoryClient.ServicePrincipals
                .Where(principal => principal.AppId.Equals(ClientId))
                .ExecuteAsync();
            var currentPrincipal = principals.CurrentPage.FirstOrDefault();

            return currentPrincipal?.AppRoles ?? Enumerable.Empty<AppRole>();
        }

        private async Task<IList<string>> GetUserGroupsAsync(IUserFetcher userFetcher)
        {
            IEnumerable<string> userGroupIds = await userFetcher.GetMemberGroupsAsync(false);
            List<string> userGroupIdList = userGroupIds.ToList();

            if (!userGroupIdList.Any())
            {
                return null;
            }

            IEnumerable<IDirectoryObject> userGroups = await _activeDirectoryClient.GetObjectsByObjectIdsAsync(userGroupIdList, new List<string> { "group" });
            List<string> groupNames = new List<string>();
            foreach (IDirectoryObject directoryObject in userGroups)
            {
                var group = directoryObject as Group;
                if (group != null)
                {
                    groupNames.Add(group.DisplayName);
                }
            }

            return groupNames;
        }
    }
}