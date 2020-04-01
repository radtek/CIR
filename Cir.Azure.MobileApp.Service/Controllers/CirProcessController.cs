using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cir.Azure.MobileApp.Service.Utilities;
using Cir.Azure.MobileApp.Service.DataObjects;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server;

namespace Cir.Azure.MobileApp.Service.Controllers
{
    [MobileAppController]
    ////[Authorize]
   // [AuthorizeAadRole(Roles = "*")]
    public class CirProcessController : ApiController
    {

        public Cir.Azure.MobileApp.Service.CirSyncService.CirDataActionResponse Post(Cir.Azure.MobileApp.Service.CirSyncService.CirDataDetail cirDataDetail)
        {

            this.Configuration.Services.GetTraceWriter().Info("Entered CirProces POST sControllercustom controller!");
            try
            {
                UserInformation userInfo = GetUserInfo();
                Cir.Azure.MobileApp.Service.CirSyncService.CirDataActionResponse cirDataActionResponse = new Cir.Azure.MobileApp.Service.CirSyncService.CirDataActionResponse();
                if (userInfo != null)
                {
                    cirDataDetail.modifiedBy = UserPermission.UserName(userInfo);                 
                    //get lock for EditCir
                    if (cirDataDetail.Progress == 8)
                    {
                         bool hasaccess = UserPermission.EditCir(userInfo.AppRoles);
                         if (hasaccess == true)
                        {
                           // Cir.Azure.MobileApp.Service.CirSyncService.CirDataDetail existingCirData = (new SyncServiceUtilities(this)).GetCirDataDetailForView((cirDataDetail.CirDataId));
                           // if (UserPermission.isAdministrator(userInfo.AppRoles) || cirDataDetail.modifiedBy == existingCirData.LockedBy)
                            {
                                return (new SyncServiceUtilities(this)).CirProcess(cirDataDetail);
                            }
                        }
                    }
                    //Approve,Reject,Delete Cir
                    if (cirDataDetail.Progress == 2)
                    {
                        bool hasaccess = UserPermission.ApproveCir(userInfo.AppRoles);
                        if (hasaccess == true)
                        {
                            return (new SyncServiceUtilities(this)).CirProcess(cirDataDetail);
                        }
                    }
                    if (cirDataDetail.Progress == 3 || cirDataDetail.Progress == 4)
                    {
                        bool hasaccess = UserPermission.RejectCir(userInfo.AppRoles);
                        if (hasaccess == true)
                        {
                            return (new SyncServiceUtilities(this)).CirProcess(cirDataDetail);
                        }
                    }
                    if (cirDataDetail.Progress == 7)
                    {
                        bool hasaccess =  UserPermission.DeleteCir(userInfo.AppRoles);
                        if (hasaccess == true)
                        {
                            return (new SyncServiceUtilities(this)).CirProcess(cirDataDetail);
                        }
                    }
                }

                cirDataActionResponse.error = 1;
                cirDataActionResponse.message = "You do not have permission to perform this operation!";
                return cirDataActionResponse;

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }

        [Route("api/GetCirDetail/{CirDataId}")]
        public Cir.Azure.MobileApp.Service.CirSyncService.CirDataDetail GetCirDataDetail(long CirDataId)
        {
            try
            {
                this.Configuration.Services.GetTraceWriter().Info("Entered GetCirDataDetail Get custom controller!");
               
                return (new SyncServiceUtilities(this)).GetCirDataDetailForView(CirDataId);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }

        public UserInformation GetUserInfo()
        {
            AuthenticationUtilities AuthUtil = new AuthenticationUtilities(this);            
            UserInformation userInfo = null;
            var getUserInfo = System.Threading.Tasks.Task.Run(async () => { userInfo = await AuthUtil.GetAADUser(this); });
            getUserInfo.Wait();
            return userInfo;

        }

       

    }
}