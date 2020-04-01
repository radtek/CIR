
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;

namespace Cir.Data.Access.Models.Authorization
{
    public class UserInformation
    {
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Mail { get; set; }
        public string UserPrincipalName { get; set; }
        public string[] OtherMails { get; set; }
        public string[] AppRoles { get; set; }
        public string[] UserGroups { get; set; }
        public static UserInformation getstaticuser(string authToken) {
            UserInformation userinfo = new UserInformation();
            var jwtHandler = new JwtSecurityTokenHandler();
            if (jwtHandler.CanReadToken(authToken))
            {
                var jwtSecurityToken = jwtHandler.ReadToken(authToken) as JwtSecurityToken;
                Dictionary<string, string> claimList = new Dictionary<string, string>();
                List<string> userRoles = new List<string>();
                foreach (var claim in jwtSecurityToken.Claims)
                {
                    if (!claimList.ContainsKey(claim.Type) && claim.Type != "roles")
                        claimList.Add(claim.Type, claim.Value);
                    if (claim.Type == "roles")
                        userRoles.Add(claim.Value);

                }
                //mapping of JWT roles to application
                if (userRoles.Contains("TurbineTechnicians"))
                {
                    userRoles.Add("Turbine Technicians");
                    userRoles.Remove("TurbineTechnicians");
                }
                if (userRoles.Contains("Evaluator"))
                {
                    userRoles.Add("CIR Evaluator");
                    userRoles.Remove("Evaluator");
                }
                if (userRoles.Contains("ContractorTurbineTechnicians"))
                {
                    userRoles.Add("Contractor Turbine Technicians");
                    userRoles.Remove("ContractorTurbineTechnicians");
                }
                if (userRoles.Contains("GIRCreators"))
                {
                    userRoles.Add("GirCreator");
                    userRoles.Remove("GIRCreators");
                }
                if (userRoles.Contains("ReportViewer"))
                {
                    userRoles.Add("Report Viewer");
                    userRoles.Remove("ReportViewer");
                }
                userinfo.AppRoles = userRoles.ToArray();
                //if (userinfo.AppRoles.Length == 0)
                //    userinfo.AppRoles = new[] { "Viewer" };
                userinfo.DisplayName = claimList.ContainsKey("name") ? claimList["name"] : "";
                userinfo.FirstName = claimList.ContainsKey("given_name") ? claimList["given_name"] : "";
                userinfo.LastName = claimList.ContainsKey("family_name") ? claimList["family_name"] : "";
                userinfo.UserName = claimList.ContainsKey("given_name") ? claimList["given_name"] : "";
                userinfo.StreetAddress = "";
                userinfo.City = "";
                userinfo.State = "";
                userinfo.PostalCode = "";
                userinfo.Mail = claimList.ContainsKey("email") ? claimList["email"] : claimList.ContainsKey("upn") ? claimList["upn"] : "";
                string userprincipal = string.Empty;
                if (userinfo.Mail != "" && !userinfo.Mail.Contains("onmicrosoft.com"))
                {
                    userprincipal = userinfo.Mail + ConfigurationManager.AppSettings["userprincipal"];
                }
                else
                {
                    userprincipal = userinfo.Mail;
                }
                userinfo.UserPrincipalName = userprincipal;
            }
            return userinfo;
        }
    }
}