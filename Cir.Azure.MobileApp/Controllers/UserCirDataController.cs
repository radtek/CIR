using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using Cir.Azure.MobileApp.DataObjects;
using Cir.Azure.MobileApp.Models;
using System.Collections.Generic;
using System;
using Cir.Azure.MobileApp.Utilities;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using System.Net;
using System.Net.Http;

namespace Cir.Azure.MobileApp.Controllers
{
    [MobileAppController]
    public class UserCirDataController : TableController<UserCirData>
    {
        public class DataVersionMapping
        {
            public string CirDataCommonID { get; set; }
            public long RowVersion { get; set; }
        }
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            vestascirmobileappContext context = new vestascirmobileappContext();
            DomainManager = new EntityDomainManager<UserCirData>(context, Request);
        }

        // GET tables/UserCirData
        public IQueryable<UserCirData> GetAllUserCirDatas()
        {
            return Query();
        }

        // GET tables/UserCirData/48D68C86-6EA6-4C25-AA33-223FC9A27959
        [Authorize]
        [AuthorizeAadRole(Roles = "*")]
        public SingleResult<UserCirData> GetUserCirDataItem(string id)
        {
            AuthenticationUtilities AuthUtil = new AuthenticationUtilities(this);
            UserInformation userInfo = null;
            var getUserInfo = System.Threading.Tasks.Task.Run(async () => { userInfo = await AuthUtil.GetAADUser((MobileAppUser)this.User); });
            getUserInfo.Wait();

            var item = Lookup(id);
            if (UserPermission.isAdministrator(userInfo.AppRoles))
                return item;
            else
            {
                if (item.Queryable.First().UserInitial.Trim().ToLower() != userInfo.userPrincipalName.Trim().ToLower())
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Forbidden, "You need permission to access data for other user"));
                else
                    return item;
            }

        }

        // POST tables/UserCirData
        [Authorize]
        [AuthorizeAadRole(Roles = "*")]
        [Route("api/PullCirData/{UserId}")]
        public IList<UserCirData> PullUsersCirDataItems(string UserId, DataVersionMapping[] DataWithClient)
        {
            AuthenticationUtilities AuthUtil = new AuthenticationUtilities(this);
            UserInformation userInfo = null;
            var getUserInfo = System.Threading.Tasks.Task.Run(async () => { userInfo = await AuthUtil.GetAADUser((MobileAppUser)this.User); });
            getUserInfo.Wait();

            if (!UserPermission.isAdministrator(userInfo.AppRoles))
            {
                if (userInfo.userPrincipalName.Trim().ToLower() != UserId.Trim().ToLower())
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Forbidden, "You need permission to access data for other user"));
            }

            var q = Query().Where(z => z.Deleted == false).Where(z => z.UserInitial.Trim().ToLower() == userInfo.userPrincipalName.Trim().ToLower()).ToList();
            if (DataWithClient == null)
                return q;
            var qfilter = from d in q
                          join dc in DataWithClient.ToList()
                          on d.Id equals dc.CirDataCommonID
                          where d.RowVersion <= dc.RowVersion
                          select d;

            return q.Except(qfilter.ToList()).ToList();
        }

        // POST tables/UserCirData
        [Authorize]
        [AuthorizeAadRole(Roles = "*")]
        [Route("api/DeletedCirData/{UserId}")]
        public IList<string> CheckDeleletedUsersCirDataItems(string UserId, DataVersionMapping[] DataWithClient)
        {
            AuthenticationUtilities AuthUtil = new AuthenticationUtilities(this);
            UserInformation userInfo = null;
            var getUserInfo = System.Threading.Tasks.Task.Run(async () => { userInfo = await AuthUtil.GetAADUser((MobileAppUser)this.User); });
            getUserInfo.Wait();

            if (!UserPermission.isAdministrator(userInfo.AppRoles))
            {
                if (userInfo.userPrincipalName.Trim().ToLower() != UserId.Trim().ToLower())
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Forbidden, "You need permission to access data for other user"));
            }
            List<string> clientList = DataWithClient.ToList().Select(z => z.CirDataCommonID).ToList();

            var q = Query().Where(z => z.Deleted == false).Where(z => z.UserInitial.Trim().ToLower() == userInfo.userPrincipalName.Trim().ToLower()).Select(z => z.Id).ToList();

            return clientList.Except(q).ToList();
        }

        //// GET tables/UserCirData/48D68C86-6EA6-4C25-AA33-223FC9A27959
        //public SingleResult<UserCirData> GetUserCirDataItem(string id)
        //{
        //    return Lookup(id);
        //}

        // PATCH tables/UserCirData/48D68C86-6EA6-4C25-AA33-223FC9A27959
        [Authorize]
        [AuthorizeAadRole(Roles = "*")]
        public Task<UserCirData> PatchUserCirDataItem(string id, UserCirData patchItem)
        {
            var newId = "";
            var oldId = "";

            Delta<UserCirData> patch = new Delta<UserCirData>();
            List<UserCirData> list = new List<UserCirData>();
            AuthenticationUtilities AuthUtil = new AuthenticationUtilities(this);
            UserInformation userInfo = null;
            var getUserInfo = System.Threading.Tasks.Task.Run(async () => { userInfo = await AuthUtil.GetAADUser((MobileAppUser)this.User); });
            getUserInfo.Wait();
            var q = Query().Where(z => z.Id.ToLower() == id.ToLower()).FirstOrDefault();
            if (q == null)
            {
                // var item = patch.GetEntity();
                patchItem.RowVersion = DateTime.UtcNow.Ticks;
                patchItem.UpdateBy = UserPermission.UserName(userInfo);// userInfo.userPrincipalName;
                return InsertAsync(patchItem);
            }
            else
            {
                if (userInfo.userPrincipalName.Trim().ToLower() != q.UserInitial.ToLower().Trim())
                {
                    if (!UserPermission.isAdministrator(userInfo.AppRoles))
                    {
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Forbidden, "You need permission to access data for other user"));
                    }
                }

                if (patchItem.Status == 2)
                {
                    if (!String.IsNullOrEmpty(q.RelatedUserCirDataID))
                    {
                        oldId = q.RelatedUserCirDataID;
                        newId = id;
                        id = oldId;
                        var qold = Query().Where(z => z.Id.ToLower() == oldId.ToLower()).FirstOrDefault();
                        patchItem.UserInitial = qold.UserInitial;
                        patchItem.Remarks = "CIR has been submitted by " + q.UserInitial;
                        var delete = System.Threading.Tasks.Task.Run(async () => { await DeleteAsync(newId); });
                        delete.Wait();
                    }
                }


                patch.TrySetPropertyValue("CirDataLocalID", patchItem.CirDataLocalID);
                patch.TrySetPropertyValue("UpdateBy", UserPermission.UserName(userInfo)); // userInfo.userPrincipalName);
                if (!String.IsNullOrEmpty(patchItem.CreatedDate))
                    patch.TrySetPropertyValue("CreatedDate", patchItem.CreatedDate);
                if (patchItem.Status > 0)
                    patch.TrySetPropertyValue("Status", patchItem.Status);
                if (!String.IsNullOrEmpty(patchItem.StatusMessage))
                    patch.TrySetPropertyValue("StatusMessage", patchItem.StatusMessage);
                if (!String.IsNullOrEmpty(patchItem.StatusDetailMessage))
                    patch.TrySetPropertyValue("StatusDetailMessage", patchItem.StatusDetailMessage);
                if (!String.IsNullOrEmpty(patchItem.CirData))
                    patch.TrySetPropertyValue("CirData", patchItem.CirData);
                if (!String.IsNullOrEmpty(patchItem.RelatedUserCirDataID))
                {
                    if (patchItem.RelatedUserCirDataID == "-")
                        patch.TrySetPropertyValue("RelatedUserCirDataID", null);
                    else
                        patch.TrySetPropertyValue("RelatedUserCirDataID", patchItem.RelatedUserCirDataID);
                }
                if (!String.IsNullOrEmpty(patchItem.Remarks))
                    patch.TrySetPropertyValue("Remarks", patchItem.Remarks);
                if (!String.IsNullOrEmpty(patchItem.UserInitial))
                    patch.TrySetPropertyValue("UserInitial", patchItem.UserInitial);
                if (patchItem.CirStatus > 0)
                    patch.TrySetPropertyValue("CirStatus", patchItem.CirStatus);
                patch.TrySetPropertyValue("Deleted", patchItem.Deleted);
                patch.TrySetPropertyValue("RowVersion", DateTime.UtcNow.Ticks);
                return UpdateAsync(id, patch);
            }

        }

        [Authorize]
        [AuthorizeAadRole(Roles = "Administrator")]
        [Route("api/AssignUserCirDataToAdmin/{id}")]
        public Task<UserCirData> AssignUserCirDataToAdmin(string id, UserCirData patchItem)
        {
            Delta<UserCirData> patch = new Delta<UserCirData>();
            List<UserCirData> list = new List<UserCirData>();
            AuthenticationUtilities AuthUtil = new AuthenticationUtilities(this);
            UserInformation userInfo = null;
            var getUserInfo = System.Threading.Tasks.Task.Run(async () => { userInfo = await AuthUtil.GetAADUser((MobileAppUser)this.User); });
            getUserInfo.Wait();
            var q = Query().Where(z => z.Id.ToLower() == id.ToLower()).FirstOrDefault();
            if (q == null)
            {
                // var item = patch.GetEntity();
                patchItem.RowVersion = DateTime.UtcNow.Ticks;
                patchItem.UpdateBy = UserPermission.UserName(userInfo);// userInfo.userPrincipalName;
                return InsertAsync(patchItem);
            }
            else
            {
                (new SyncServiceUtilities(this)).LockCirDataByCirID(q.CirDataLocalID, UserPermission.UserName(userInfo));

                patch.TrySetPropertyValue("CirDataLocalID", patchItem.CirDataLocalID);
                patch.TrySetPropertyValue("UpdateBy", UserPermission.UserName(userInfo));// userInfo.userPrincipalName);
                patch.TrySetPropertyValue("UserInitial", userInfo.userPrincipalName);
                if (!String.IsNullOrEmpty(patchItem.CreatedDate))
                    patch.TrySetPropertyValue("CreatedDate", patchItem.CreatedDate);
                if (patchItem.Status > 0)
                    patch.TrySetPropertyValue("Status", patchItem.Status);
                if (!String.IsNullOrEmpty(patchItem.StatusMessage))
                    patch.TrySetPropertyValue("StatusMessage", patchItem.StatusMessage);
                if (!String.IsNullOrEmpty(patchItem.StatusDetailMessage))
                    patch.TrySetPropertyValue("StatusDetailMessage", patchItem.StatusDetailMessage);
                if (!String.IsNullOrEmpty(patchItem.CirData))
                    patch.TrySetPropertyValue("CirData", patchItem.CirData);
                if (!String.IsNullOrEmpty(patchItem.RelatedUserCirDataID))
                    patch.TrySetPropertyValue("RelatedUserCirDataID", patchItem.RelatedUserCirDataID);
                if (!String.IsNullOrEmpty(patchItem.Remarks))
                    patch.TrySetPropertyValue("Remarks", patchItem.Remarks);
                //if (!String.IsNullOrEmpty(patchItem.UserInitial))
                //    patch.TrySetPropertyValue("UserInitial", patchItem.UserInitial);
                if (patchItem.CirStatus > 0)
                    patch.TrySetPropertyValue("CirStatus", patchItem.CirStatus);
                patch.TrySetPropertyValue("Deleted", patchItem.Deleted);
                patch.TrySetPropertyValue("RowVersion", DateTime.UtcNow.Ticks);
                return UpdateAsync(id, patch);
            }

        }

        //// PATCH tables/UserCirData
        //[Route("api/PushCirData")]
        //public List<UserCirData> PatchUserCirDataItems(List<Delta<UserCirData>> patchitems)
        //{
        //    List<UserCirData> list = new List<UserCirData>();
        //    AuthenticationUtilities AuthUtil = new AuthenticationUtilities(this);
        //    UserInformation userInfo = null;
        //    var getUserInfo = System.Threading.Tasks.Task.Run(async () => { userInfo = await AuthUtil.GetAADUser((MobileAppUser)this.User); });
        //    getUserInfo.Wait();
        //    foreach (var patch in patchitems)
        //    {
        //        object id = string.Empty;
        //        try
        //        {
        //            if (patch.TryGetPropertyValue("Id", out id))
        //            {
        //                var q = Query().Where(z => z.Id.ToLower() == id.ToString().ToLower()).FirstOrDefault();
        //                if (q == null)
        //                {
        //                    var item = patch.GetEntity();
        //                    item.RowVersion = DateTime.UtcNow.Ticks;
        //                    item.UpdateBy = userInfo.userPrincipalName;
        //                    list.Add(InsertAsync(item).Result);
        //                }
        //                else
        //                {
        //                    if (userInfo.userPrincipalName.Trim().ToLower() != q.UserInitial.ToLower().Trim())
        //                    {
        //                        if (!UserPermission.isAdministrator(userInfo.AppRoles))
        //                        {
        //                            throw new Exception("You need permission to access data for other user");
        //                        }
        //                    }
        //                    patch.TrySetPropertyValue("RowVersion", DateTime.UtcNow.Ticks);
        //                    patch.TrySetPropertyValue("UpdateBy", userInfo.userPrincipalName);
        //                    list.Add(UpdateAsync(id.ToString(), patch).Result);
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            var item = patch.GetEntity();
        //            item.StatusMessage = "Error";
        //            item.StatusDetailMessage = ex.Message;
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}


        // POST tables/UserCirData


        [Authorize]
        [AuthorizeAadRole(Roles = "*")]
        public Task<UserCirData> PostUserCirData(UserCirData item)
        {
            AuthenticationUtilities AuthUtil = new AuthenticationUtilities(this);
            UserInformation userInfo = null;
            var getUserInfo = System.Threading.Tasks.Task.Run(async () => { userInfo = await AuthUtil.GetAADUser((MobileAppUser)this.User); });
            getUserInfo.Wait();

            item.RowVersion = DateTime.UtcNow.Ticks;
            item.UpdateBy = UserPermission.UserName(userInfo);
            return InsertAsync(item);
        }

        // DELETE tables/UserCirData/48D68C86-6EA6-4C25-AA33-223FC9A27959
        [Authorize]
        [AuthorizeAadRole(Roles = "*")]
        public Task DeleteUserCirData(string id)
        {
            AuthenticationUtilities AuthUtil = new AuthenticationUtilities(this);
            UserInformation userInfo = null;
            var getUserInfo = System.Threading.Tasks.Task.Run(async () => { userInfo = await AuthUtil.GetAADUser((MobileAppUser)this.User); });
            getUserInfo.Wait();
            var q = Query().Where(z => z.Id.ToLower() == id.ToLower()).FirstOrDefault();
            if (q != null)
            {
                if (userInfo.userPrincipalName.Trim().ToLower() != q.UserInitial.ToLower().Trim())
                {
                    if (!UserPermission.isAdministrator(userInfo.AppRoles))
                    {
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Forbidden, "You need permission to access data for other user"));
                    }
                }
                var qchild = Query().Where(z => z.RelatedUserCirDataID.ToLower() == id.ToLower());
                foreach (var ch in qchild)
                {
                    DeleteAsync(ch.Id);
                }
                //if (!String.IsNullOrEmpty(q.RelatedUserCirDataID))
                // {
                //     UserCirData objUserCirDataOld = new UserCirData();

                //     objUserCirDataOld.CirDataLocalID = q.CirDataLocalID;
                //     objUserCirDataOld.Status = q.Status; //Staus id of "Locked by Admin"
                //     objUserCirDataOld.Remarks = "";
                //     //objUserCirDataOld.CirData = q.CirData;
                //     UserCirData objUserCirDataupdated = null;
                //     var oldatasave = System.Threading.Tasks.Task.Run(async () => { objUserCirDataupdated = await PatchUserCirDataItem(q.RelatedUserCirDataID, objUserCirDataOld); });
                //     oldatasave.Wait();
                //     if (objUserCirDataupdated == null)
                //     {
                //         throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Unable to send update to user."));
                //     }
                // }
                // else

                (new SyncServiceUtilities(this)).UnlockCirDataByCirID((q.CirDataLocalID));
            }
            return DeleteAsync(id);
        }

        //{
        // GET tables/Temp
        //[Route("api/PullCirDataTemp")]
        //public IQueryable<UserCirData> Get()
        //{
        //    return Query();
        //}
        [HttpPost]
        [AuthorizeAadRole(Roles = "Administrator")]
        [Route("api/GetCirSyncErrorData")]
        public IList<UserCirData> GetCirSyncErrorData(UserCirData CirData)
        {
            List<UserCirData> CirDataRow = new List<UserCirData>();

            if (CirData.CirDataLocalID == 0)  //Error
            {
                CirDataRow = Query().Where(z => z.Deleted == false && z.Status == CirData.Status && z.UserInitial.Trim().ToLower().StartsWith(CirData.UserInitial.Trim().ToLower())).ToList();
            }
            else  //Draft
            {
                CirDataRow = Query().Where(z => z.CirDataLocalID == CirData.CirDataLocalID && z.Deleted == false && z.UserInitial.Trim().ToLower().StartsWith(CirData.UserInitial.Trim().ToLower())).ToList();
            }

            return CirDataRow;
        }

        [HttpPost]
        [AuthorizeAadRole(Roles = "*")]
        [Route("api/DelegateCirData/{id}/{assignedUserName}")]
        public bool UpdateUserCirData(string id, string assignedUserName)
        {
            bool retValue = false;
            UserCirData objUserCirDataNew = new UserCirData();
            UserCirData objUserCirDataOld = new UserCirData();

            AuthenticationUtilities AuthUtil = new AuthenticationUtilities(this);
            UserInformation userInfo = null;
            var getUserInfo = System.Threading.Tasks.Task.Run(async () => { userInfo = await AuthUtil.GetAADUser((MobileAppUser)this.User); });
            getUserInfo.Wait();

            var q = Query().Where(z => z.Id.ToLower() == id.ToLower()).FirstOrDefault();

            if (q != null && q.UserInitial.ToLower().Trim() == userInfo.userPrincipalName.ToLower().Trim())
            {

                objUserCirDataNew.UpdateBy = UserPermission.UserName(userInfo);
                objUserCirDataNew.CirDataLocalID = q.CirDataLocalID;
                objUserCirDataNew.CreatedDate = q.CreatedDate;
                objUserCirDataNew.Status = 1;
                objUserCirDataNew.StatusMessage = q.StatusMessage;
                objUserCirDataNew.StatusDetailMessage = q.StatusDetailMessage;
                objUserCirDataNew.CirData = q.CirData;
                objUserCirDataNew.UserInitial = assignedUserName;
                objUserCirDataNew.CirStatus = q.CirStatus;
                objUserCirDataNew.RelatedUserCirDataID = q.Id;
                objUserCirDataNew.Remarks = "This CIR has been delegated to you by " + userInfo.userPrincipalName;
                objUserCirDataNew.RowVersion = DateTime.UtcNow.Ticks;


                var newdatasave = System.Threading.Tasks.Task.Run(async () => { objUserCirDataNew = await InsertAsync(objUserCirDataNew); });
                newdatasave.Wait();
                if (!String.IsNullOrEmpty(objUserCirDataNew.Id))
                {
                    objUserCirDataOld.CirDataLocalID = q.CirDataLocalID;
                    objUserCirDataOld.Status = 7; //Status id Delegated
                    objUserCirDataOld.Remarks = "This CIR has been delegated to " + assignedUserName;
                    UserCirData objUserCirDataupdated = null;
                    var oldatasave = System.Threading.Tasks.Task.Run(async () => { objUserCirDataupdated = await PatchUserCirDataItem(id, objUserCirDataOld); });
                    oldatasave.Wait();
                    if (objUserCirDataupdated != null)
                    {
                        retValue = true;
                    }
                    else
                    {
                        var newdatadetele = System.Threading.Tasks.Task.Run(async () => { await DeleteUserCirData(objUserCirDataNew.Id); });
                        newdatadetele.Wait();
                    }
                }
            }
            else
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Forbidden, "You need permission to access data for other user"));
            }
            return retValue;
        }

        [HttpPost]
        [AuthorizeAadRole(Roles = "*")]
        [Route("api/ChangeCirDelegation/{id}/{IsDelegatedCIRDataRequired}")]
        public bool ChangeCirDelegation(string id, bool IsDelegatedCIRDataRequired)
        {
            bool retValue = false;
            UserCirData objUserCirDataNew = new UserCirData();
            UserCirData objUserCirDataOld = new UserCirData();

            AuthenticationUtilities AuthUtil = new AuthenticationUtilities(this);
            UserInformation userInfo = null;
            var getUserInfo = System.Threading.Tasks.Task.Run(async () => { userInfo = await AuthUtil.GetAADUser((MobileAppUser)this.User); });
            getUserInfo.Wait();

            var q = Query().Where(z => z.Id.ToLower() == id.ToLower()).FirstOrDefault();
            if (q != null && q.UserInitial.ToLower().Trim() != userInfo.userPrincipalName.ToLower().Trim())
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Forbidden, "You need permission to access data for other user"));
            }
            if (q != null && !String.IsNullOrEmpty(q.RelatedUserCirDataID))  //deligated ownner returning back the CIR to original use
            {
                objUserCirDataOld.CirDataLocalID = q.CirDataLocalID;
                objUserCirDataOld.Status = 1; //Status id Delegated
                objUserCirDataOld.Remarks = "CIR returned by " + q.UserInitial; ;
                objUserCirDataOld.RelatedUserCirDataID = "-";
                if (IsDelegatedCIRDataRequired)
                {
                    objUserCirDataOld.CirData = q.CirData;
                }

                UserCirData objUserCirDataupdated = null;
                var oldatasave = System.Threading.Tasks.Task.Run(async () => { objUserCirDataupdated = await PatchUserCirDataItem(q.RelatedUserCirDataID, objUserCirDataOld); });
                oldatasave.Wait();
                if (objUserCirDataupdated != null)
                {
                    var delete = System.Threading.Tasks.Task.Run(async () => { await DeleteAsync(id); });
                    delete.Wait();
                    retValue = true;
                }
                else
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Unable to change Cir Delegation."));
                }
            }
            else if (q != null)  //Original ownner revoking the deligated CIR
            {
                if (q.Status == 7)
                {
                    var NerCir = Query().Where(z => z.RelatedUserCirDataID == q.Id).OrderByDescending(z => z.RowVersion).FirstOrDefault();

                    objUserCirDataOld.CirDataLocalID = q.CirDataLocalID;
                    objUserCirDataOld.Status = 1; //Status id Delegated
                    objUserCirDataOld.Remarks = "CIR Delegation revoked from " + NerCir.UserInitial;
                    objUserCirDataOld.RelatedUserCirDataID = "-";
                    if (IsDelegatedCIRDataRequired)
                    {
                        objUserCirDataOld.CirData = NerCir.CirData;
                    }

                    UserCirData objUserCirDataupdated = null;
                    var oldatasave = System.Threading.Tasks.Task.Run(async () => { objUserCirDataupdated = await PatchUserCirDataItem(id, objUserCirDataOld); });
                    oldatasave.Wait();
                    if (objUserCirDataupdated != null)
                    {
                        var delete = System.Threading.Tasks.Task.Run(async () => { await DeleteAsync(NerCir.Id); });
                        delete.Wait();
                        retValue = true;
                    }
                    else
                    {

                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Unable to change Cir Delegation."));
                    }
                }
                else
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, "CIR is not in delegated state"));
                }
            }
            return retValue;
        }
    }
}
