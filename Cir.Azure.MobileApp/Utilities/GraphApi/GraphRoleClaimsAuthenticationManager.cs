
using Microsoft.Azure.ActiveDirectory.GraphClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Web;

namespace Cir.Azure.MobileApp.Utilities.GraphApi
{
    public class GraphRoleClaimsAuthenticationManager : ClaimsAuthenticationManager
    {
        private const string ObjectIdentifierClaim = "http://schemas.microsoft.com/identity/claims/objectidentifier";
        public override ClaimsPrincipal  Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
        {
            if (incomingPrincipal != null &&
                incomingPrincipal.Identity.IsAuthenticated == true)
            {
                // get a token for calling the Graph
                GraphApiClient graphApi = new GraphApiClient((new Microsoft.Azure.Mobile.Server.Config.MobileAppConfiguration()).MobileAppSettingsProvider.GetMobileAppSettings());

                Claim objectIdentifierClaim = incomingPrincipal.FindFirst(ObjectIdentifierClaim);
                if (objectIdentifierClaim == null)
                {
                    throw new NotSupportedException("Object identifier claim not available, role authentication is not supported");
                }


                string currentUserObjectId = objectIdentifierClaim.Value;
                // query the Graph for the current user's memberships
                User currentUser = graphApi.getUser(currentUserObjectId);
              
                if (currentUser == null)
                {
                    throw new SecurityException("User cannot be found in graph");
                }
                // add a role claim for every membership found
                List<AppRole> currentRoles = graphApi.UserApplicationRoleFetcher(currentUser);
                if (currentRoles.Count == 0)
                {
                    ((ClaimsIdentity)incomingPrincipal.Identity).AddClaim(new Claim(ClaimTypes.Role, "Anonymous", ClaimValueTypes.String, "DefaultRoleIssuer"));
                }
                else
                {
                    foreach (AppRole role in currentRoles)
                    {
                        ((ClaimsIdentity)incomingPrincipal.Identity).AddClaim(new Claim(ClaimTypes.Role, role.DisplayName, ClaimValueTypes.String, "DefaultRoleIssuer"));
                    }
                }
            }
            return incomingPrincipal;
        }
    }
}