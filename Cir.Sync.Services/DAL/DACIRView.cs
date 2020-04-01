using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Linq;
using Cir.Sync.Services.DataContracts;
using Cir.Sync.Services.CIR;
using Cir.Sync.Services.Edmx;
using Cir.Sync.Services.ErrorHandling;
using System.Globalization;
using System.Data.SqlTypes;
using System.Data.Objects;
using System.Web.Hosting;
using System.IO;
using Cir.Common.Utilities;
using System.Collections;
using System.Xml.Serialization;
using Cir.Common.Notification;
using Cir.Sync.Services.Notification;
using System.Web;

namespace Cir.Sync.Services.DAL
{
    public class DACIRView
    {

        private static Dictionary<int, CirViewData> _views = null;
        private static CirViewData _defaultView = null;
        private static CirViewData _errorView = null;

        public delegate bool GeneratePDFDelegate(long cirid, string path, string licpath);

        public delegate bool NotificationResendDelegate();
        public static List<CirFieldMappings> DAFieldMappings()
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                return context.CirFieldMappings.Where(x => !String.IsNullOrEmpty(x.TableName)).ToList();
            }
        }

        public static CIRList GetCirList(CIRList cirList)
        {

            DataSet cList = new DataSet();
            CIRList _CIRList = new CIRList();
            try
            {
                using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("Stp_Cir_List", objCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@ViewID", SqlDbType.BigInt);
                        cmd.Parameters["@ViewID"].Value = cirList.ViewId;
                        cmd.Parameters.Add("@State", SqlDbType.Int);
                        cmd.Parameters["@State"].Value = cirList.State;
                        cmd.Parameters.Add("@SortColumnIndex", SqlDbType.Int);
                        cmd.Parameters["@SortColumnIndex"].Value = cirList.SortColumnIndex;
                        cmd.Parameters.Add("@SortDirection", SqlDbType.Int);
                        cmd.Parameters["@SortDirection"].Value = cirList.SortDirection;

                        cmd.Parameters.Add("@CurrentPageNumber", SqlDbType.BigInt);
                        cmd.Parameters["@CurrentPageNumber"].Value = cirList.CurrentPageNumber;

                        cmd.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                        cmd.Parameters["@RecordsPerPage"].Value = cirList.RecordsPerPage;
                        cmd.Parameters["@RecordsPerPage"].Direction = ParameterDirection.InputOutput;

                        cmd.Parameters.Add("@TotalRecordCount", SqlDbType.Int);
                        cmd.Parameters["@TotalRecordCount"].Value = 0;
                        cmd.Parameters["@TotalRecordCount"].Direction = ParameterDirection.InputOutput;

                        cmd.Parameters.Add("@TotalRecordCountApprove", SqlDbType.Int);
                        cmd.Parameters["@TotalRecordCountApprove"].Value = 0;
                        cmd.Parameters["@TotalRecordCountApprove"].Direction = ParameterDirection.InputOutput;

                        cmd.Parameters.Add("@TotalRecordCountReject", SqlDbType.Int);
                        cmd.Parameters["@TotalRecordCountReject"].Value = 0;
                        cmd.Parameters["@TotalRecordCountReject"].Direction = ParameterDirection.InputOutput;

                        //Added By Siddharth Chauhan on 14-06-2016.            
                        //Below parameters added to perform quick search on CIR remote data.
                        //TaskNo. : 75301
                        cmd.Parameters.Add("@CirId", SqlDbType.BigInt);
                        cmd.Parameters["@CirId"].Value = cirList.CirId;

                        cmd.Parameters.Add("@CirName", SqlDbType.NVarChar);
                        cmd.Parameters["@CirName"].Value = cirList.CirName;

                        cmd.Parameters.Add("@CimCase", SqlDbType.BigInt);
                        cmd.Parameters["@CimCase"].Value = cirList.CimCase;

                        cmd.Parameters.Add("@ComponentType", SqlDbType.BigInt);
                        cmd.Parameters["@ComponentType"].Value = cirList.ComponentType;

                        cmd.Parameters.Add("@ReportType", SqlDbType.BigInt);
                        cmd.Parameters["@ReportType"].Value = cirList.ReportType;

                        cmd.Parameters.Add("@Country", SqlDbType.NVarChar);
                        cmd.Parameters["@Country"].Value = cirList.Country;

                        cmd.Parameters.Add("@TurbineType", SqlDbType.NVarChar);
                        cmd.Parameters["@TurbineType"].Value = cirList.TurbineType;

                        cmd.Parameters.Add("@BrandType", SqlDbType.NVarChar);
                        cmd.Parameters["@BrandType"].Value = cirList.BrandType;

                        cmd.Parameters.Add("@TurbineNumber", SqlDbType.BigInt);
                        cmd.Parameters["@TurbineNumber"].Value = cirList.TurbineNumber;

                        cmd.Parameters.Add("@RunStatus", SqlDbType.BigInt);
                        cmd.Parameters["@RunStatus"].Value = cirList.RunStatus;

                        cmd.Parameters.Add("@SBU", SqlDbType.NVarChar);
                        cmd.Parameters["@SBU"].Value = cirList.SBU;

                        cmd.Parameters.Add("@Created", SqlDbType.DateTime);
                        cmd.Parameters["@Created"].Value = cirList.Created;

                        cmd.Parameters.Add("@Modified", SqlDbType.DateTime);
                        cmd.Parameters["@Modified"].Value = cirList.Modified;

                        cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                        cmd.Parameters["@ModifiedBy"].Value = cirList.ModifiedBy;

                        cmd.Parameters.Add("@SiteName", SqlDbType.NVarChar);
                        cmd.Parameters["@SiteName"].Value = cirList.SiteName;


                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            try
                            {
                                da.Fill(cList);
                            }
                            catch (Exception ex)
                            {
                                string err = ex.Message;
                            }
                        }
                        var CLIST = cList.Tables[0];

                        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                        Dictionary<string, object> row;
                        foreach (DataRow dr in CLIST.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in CLIST.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        _CIRList = new CIRList { CurrentPageNumber = cirList.CurrentPageNumber, RecordsPerPage = Convert.ToInt32(cmd.Parameters["@RecordsPerPage"].Value), ViewId = cirList.ViewId, State = cirList.State, TotalRecordCount = Convert.ToInt32(cmd.Parameters["@TotalRecordCount"].Value), TotalRecordCountApprove = Convert.ToInt32(cmd.Parameters["@TotalRecordCountApprove"].Value), TotalRecordCountReject = Convert.ToInt32(cmd.Parameters["@TotalRecordCountReject"].Value), Data = serializer.Serialize(rows), SortColumnIndex = cirList.SortColumnIndex, SortDirection = cirList.SortDirection };


                    }

                }
            }
            catch (Exception ex)
            {
                DACIRLog.SaveCirLog(_CIRList.CirId, "GetCirList is failed" + ex.Message, LogType.Error, cirList.ModifiedBy);
            }

            return _CIRList;

        }

        public static int GetBIRViewId()
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                return context.CirView.Where(x => x.InspectionApplicable.HasValue && x.InspectionApplicable == true).OrderByDescending(o => o.CirViewId).Select(z => z.CirViewId).FirstOrDefault();
            }
        }

        public static int GetGIRViewId()
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                return context.CirView.Where(x => x.GeneralInspectionApplicable.HasValue && x.GeneralInspectionApplicable == true).OrderByDescending(o => o.CirViewId).Select(z => z.CirViewId).FirstOrDefault();
            }
        }

        public static int GetGBXIRViewId()
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                return context.CirView.Where(x => x.GBXInspectionApplicable.HasValue && x.GBXInspectionApplicable == true).OrderByDescending(o => o.CirViewId).Select(z => z.CirViewId).FirstOrDefault();
            }
        }

        private static bool LockCir(long cirDataId, string modifiedBy)
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                CirData cirData = new CirData();
                long cirID = context.CirData.Where(x => x.CirDataId == cirDataId).Select(x => x.CirId).FirstOrDefault();
                cirData = context.CirData.Where(x => x.CirId == cirID && x.Deleted == false).OrderByDescending(x => x.CirDataId).FirstOrDefault();

                if (cirData != null)
                {
                    if (cirData.Locked == 1 && modifiedBy != cirData.LockedBy)
                    {

                        return false;
                    }
                    else
                    {
                        cirData.Locked = 1;
                        cirData.LockedBy = modifiedBy;
                        context.SaveChanges();
                        //AddComment(cirDataId, modifiedBy, "Locked by " + modifiedBy , CommentType.Locked);
                        // ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "CirDataId : " + cirData.CirDataId.ToString() + " Locked", LogType.Information, "");
                        DACIRLog.SaveCirLog(cirDataId, "CIR Locked", LogType.Information, modifiedBy);
                        return true;
                    }

                }
            }

            return true;
        }

        private static bool UnLockCir(long cirDataId, string modifiedBy)
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                CirData cirData = new CirData();
                cirData = context.CirData.Where(x => x.CirDataId == cirDataId).FirstOrDefault();
                if (cirData != null)
                {
                    cirData.Locked = null;
                    cirData.LockedBy = null;
                    context.SaveChanges();
                    //AddComment(cirDataId, modifiedBy, "UnLocked by " + modifiedBy, CommentType.Locked);
                    DACIRLog.SaveCirLog(cirDataId, "CIR is UnLocked", LogType.Information, modifiedBy);
                }
            }

            return true;
        }

        public static CirDataDetail GetCirDataDetails(long CirDataId)
        {
            DataSet cList = new DataSet();
            CirDataDetail cirDataDetail = null;
            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("spGetCirDataDetailForView", objCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CirDataId", SqlDbType.BigInt);
                    cmd.Parameters["@CirDataId"].Value = CirDataId;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(cList);
                    }
                    if (cList.Tables[0].Rows.Count > 0)
                    {
                        cirDataDetail = new CirDataDetail()
                        {
                            CirDataId = Convert.ToInt64(cList.Tables[0].Rows[0]["CirDataId"].ToString()),
                            CirId = cList.Tables[0].Rows[0]["CirId"].ToString(),
                            CirState = Convert.ToInt16(cList.Tables[0].Rows[0]["CirState"].ToString()),
                            Filename = cList.Tables[0].Rows[0]["Filename"].ToString(),
                            ComponentType = cList.Tables[0].Rows[0]["ComponentType"].ToString(),
                            CIMCaseNumber = cList.Tables[0].Rows[0]["CIMCaseNumber"].ToString(),
                            ReportType = cList.Tables[0].Rows[0]["ReportType"].ToString(),
                            TurbineType = cList.Tables[0].Rows[0]["TurbineType"].ToString(),
                            TurbineNumber = cList.Tables[0].Rows[0]["TurbineNumber"].ToString(),
                            Progress = Convert.ToInt32(cList.Tables[0].Rows[0]["Progress"].ToString()),
                            Locked = (Convert.ToString(cList.Tables[0].Rows[0]["Locked"]).Length > 0) ? Convert.ToInt32(cList.Tables[0].Rows[0]["Locked"].ToString()) : 0,
                            LockedBy = (Convert.ToString(cList.Tables[0].Rows[0]["LockedBy"]).Length > 0) ? cList.Tables[0].Rows[0]["LockedBy"].ToString() : "0"
                        };
                    }
                }
            }
            return cirDataDetail;
        }

        private static bool Delete(long cirDataId, string deletedBy, string comment)
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                CirData cirData = new CirData();
                cirData = context.CirData.Where(x => x.CirDataId == cirDataId).FirstOrDefault();
                if (cirData != null)
                {
                    cirData.Deleted = true;
                    cirData.Modified = DateTime.Now;
                    cirData.ModifiedBy = deletedBy;
                    context.SaveChanges();
                    AddComment(cirDataId, deletedBy, comment, CommentType.Deleted);
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "CirDataId : " + cirData.CirDataId.ToString() + " Deleted", LogType.Information, "");
                    DACIRLog.SaveCirLog(cirDataId, "CIR Deleted", LogType.Information, deletedBy);
                }
            }

            return true;
        }

        private static void AddComment(long cirDataId, string initials, string comment, CommentType type)
        {
            if (comment == null)
            {
                return;
            }
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                CirCommentHistory entity = new CirCommentHistory();
                entity.Date = DateTime.Now;
                entity.CirDataId = cirDataId;
                entity.Initials = initials;
                entity.Comment = comment;
                entity.Type = (byte)type;
                context.CirCommentHistory.Add(entity);
                context.SaveChanges();
            }

        }
        public static bool SetApproved(long cirDataId, int State, int Progress, string modifiedBy, string comment)
        {

            {
                bool updated = false;
                State newState = (State)State;
                Progress newProgress = (Progress)Progress;
                using (CIM_CIREntities context = new CIM_CIREntities())
                {
                    CirData entity = new CirData();
                    entity = context.CirData.Where(x => x.CirDataId == cirDataId).FirstOrDefault();

                    if (entity != null)
                    {
                        entity.State = (byte)newState;
                        entity.Progress = (byte)newProgress;
                        entity.Modified = DateTime.Now;
                        entity.ModifiedBy = modifiedBy;
                        entity.Locked = null;
                        entity.LockedBy = null;
                        if (comment != null)
                        {
                            var commentType = CommentType.Approve;
                            DACIRLog.SaveCirLog(cirDataId, "Approval Process Started", LogType.Information, modifiedBy);
                            AddComment(cirDataId, modifiedBy, comment, commentType);
                        }
                        context.SaveChanges();
                        ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "CirDataId : " + entity.CirDataId.ToString() + " Status/Progress updated to " + newState + "/" + newProgress, LogType.Information, "");

                        updated = true;
                    }
                }
                return updated;
            }
        }

        private static bool SetStatus(long cirDataId, State newState, Progress newProgress, string modifiedBy, string comment, long CirID = 0)
        {
            bool updated = false;
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                CirData entity = new CirData();
                entity = context.CirData.Where(x => x.CirDataId == cirDataId).FirstOrDefault();

                if (entity != null)
                {
                    entity.State = (byte)newState;
                    entity.Progress = (byte)newProgress;
                    entity.Modified = DateTime.Now;
                    entity.ModifiedBy = modifiedBy;
                    entity.Locked = null;
                    entity.LockedBy = null;
                    if (comment != null)
                    {
                        var commentType = CommentType.General;
                        switch (newProgress)
                        {
                            case Progress.PendingInitial:
                                commentType = CommentType.MoveToInitial;
                                DACIRLog.SaveCirLog(cirDataId, "Move to Initial Process Started", LogType.Information, modifiedBy);
                                break;
                            case Progress.PendingApprove:
                                commentType = CommentType.Approve;
                                DACIRLog.SaveCirLog(cirDataId, "Approval Process Started", LogType.Information, modifiedBy);
                                break;
                            case Progress.PendingReject:
                                commentType = CommentType.Reject;
                                DACIRLog.SaveCirLog(cirDataId, "Rejection Process Started", LogType.Information, modifiedBy);
                                break;
                        }
                        AddComment(cirDataId, modifiedBy, comment, commentType);
                    }
                    context.SaveChanges();
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "CirDataId : " + entity.CirDataId.ToString() + " Status/Progress updated to " + newState + "/" + newProgress, LogType.Information, "");

                    updated = true;
                }
            }
            return updated;
        }

        public static CirDataActionResponse LockUnlockCir(CirDataDetail cirDataDetail)
        {
            CirDataActionResponse cirDataActionResponse = new CirDataActionResponse();
            cirDataActionResponse.error = 0;
            cirDataActionResponse.message = "";
            if (cirDataDetail.Locked == 1)
            {
                string lockedBy = cirDataDetail.modifiedBy;

                if (!LockCir(cirDataDetail.CirDataId,lockedBy))
                {
                    cirDataActionResponse.error = 1;
                    cirDataActionResponse.message = "Unable to Lock CIR as its already Locked!" + lockedBy;
                }
            }
            else
            {
                // UnLockCir(cirDataDetail.CirDataId, cirDataDetail.modifiedBy);
            }

            return cirDataActionResponse;
        }

        public static CirDataActionResponse CirProcess(CirDataDetail cirDataDetail, bool callPdfGeneration = true)
        {

            CirDataActionResponse cirDataActionResponse = new CirDataActionResponse();
            cirDataActionResponse.error = 0;
            cirDataActionResponse.message = "";

            long cirDataId = cirDataDetail.CirDataId;
            Progress newProgress = (Progress)cirDataDetail.Progress;
            State newState = (State)cirDataDetail.CirState;
            string modifiedBy = cirDataDetail.modifiedBy;
            string comment = cirDataDetail.comment;

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                CirData cirData = new CirData();
                cirData = context.CirData.Where(x => x.CirDataId == cirDataId).FirstOrDefault();
                if (cirData != null)
                {
                    if (newProgress == Progress.PendingLock)
                    {
                        string lockedBy = cirDataDetail.modifiedBy;

                        if (!LockCir(cirDataDetail.CirDataId, lockedBy))
                        {
                            cirDataActionResponse.error = 1;
                            cirDataActionResponse.message = "Unable to Edit CIR as its already Locked!";
                            return cirDataActionResponse;
                        }
                        return cirDataActionResponse;
                    }

                    if (cirData.Locked == 1)
                    {
                        cirDataActionResponse.error = 1;
                        cirDataActionResponse.message = "Unable to Process as this CIR is Locked!";
                        return cirDataActionResponse;
                    }

                    if (newProgress == Progress.PendingDelete)
                    {
                        Delete(cirDataId, modifiedBy, comment);

                    }
                    else
                    {

                        if (cirData.Progress == (int)Progress.InitialError && newProgress == Progress.PendingReject)
                        {
                            if (!SetStatus(cirDataId, (State)cirData.State, (Progress)newProgress, modifiedBy, comment))
                            {
                                cirDataActionResponse.error = 1;
                                cirDataActionResponse.message = "Error occurred: Unable to reject the CIR!";
                            }

                        }
                        if (!(newProgress == Progress.PendingApprove && newState == State.Initial))
                        {
                            //// don't accept progress changes that would lead to the item's current state (e.g. PendingApprove on an approved item)
                            if ((newProgress == Progress.PendingApprove && cirData.State == (int)State.Approved) ||
                                (newProgress == Progress.PendingReject && cirData.State == (int)State.Rejected) ||
                                (newProgress == Progress.PendingInitial && cirData.State == (int)State.Initial))
                            {
                                cirDataActionResponse.error = 1;
                                cirDataActionResponse.message = "Error occurred: Cannot accept progress changes that would lead to the item's current state!";
                            }

                            //// don't accept progress changes that would cause a "jump" in the item's current state (e.g. from approve directly to reject)
                            if ((newProgress == Progress.PendingApprove || newProgress == Progress.PendingReject) && cirData.State != (int)State.Initial)
                            {
                                cirDataActionResponse.error = 1;
                                cirDataActionResponse.message = "Error occurred: Cannot accept  progress changes that would cause a jump in the item's current state!";

                            }
                        }
                        //// update CIR in DB


                    }
                    if (cirDataActionResponse.error != 1)
                    {
                        State oldState = (State)cirData.State;
                        Progress oldProgress = (Progress)cirData.Progress;
                        if (!(cirData.Progress == (int)Progress.InitialError && newProgress == Progress.PendingReject))
                        {
                            SetStatus(cirDataId, (State)cirData.State, (Progress)newProgress, modifiedBy, comment, cirData.CirId);
                        }

                        try
                        {
                            cirDataActionResponse = Process(cirDataId, cirDataDetail, callPdfGeneration);

                        }
                        catch (Exception ex)
                        {
                            SetStatus(cirDataId, (State)oldState, (Progress)oldProgress, modifiedBy, null);
                            DACIRLog.SaveCirLog(cirDataId, "CIR State Reverted back to " + oldState.ToString(), LogType.Information, modifiedBy);
                            cirDataActionResponse.error = 1;
                            cirDataActionResponse.message = "Error occurred: Unable to process the CIR!";
                        }

                    }

                }
            }
            return cirDataActionResponse;
        }

        private static CirDataActionResponse Process(long cirDataId, CirDataDetail cirDataDetail, bool callPdfGeneration = true)
        {
            long hdnCirId = Convert.ToInt64(System.Configuration.ConfigurationManager.AppSettings["hdnCirId"]);
            CirDataActionResponse cirDataActionResponse = new CirDataActionResponse();
            cirDataActionResponse.error = 0;
            cirDataActionResponse.message = "Success";
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                CirData cirData = new CirData();
                string fileName = "No Name";
                cirData = context.CirData.Where(x => x.CirDataId == cirDataId).FirstOrDefault();
                fileName = cirData.Filename;
                Cir.Sync.Services.Edmx.ComponentInspectionReport componentInspectionReport = new Cir.Sync.Services.Edmx.ComponentInspectionReport();
                componentInspectionReport = context.ComponentInspectionReport.Where(x => x.ComponentInspectionReportId == cirData.CirId).FirstOrDefault();
                if (componentInspectionReport == null)
                {

                    cirDataActionResponse.error = 1;
                    cirDataActionResponse.message = "Unable to process as the CIR data is not yet migrated!";
                    return cirDataActionResponse;
                }
                if (cirData != null)
                {

                    if (cirData.Progress == (int)Progress.PendingApprove)
                    {

                        try
                        {
                            if (String.IsNullOrEmpty(componentInspectionReport.CIMCaseNumber.ToString()))
                            {
                                SetStatus(cirData.CirDataId, State.Initial, Progress.ProcessError, cirData.ModifiedBy, "Unable to process as CIMCaseNumber not found");
                                cirDataActionResponse.error = 1;
                                cirDataActionResponse.message = "Unable to process as CIMCaseNumber not found";
                                return cirDataActionResponse;
                            }
                            SetStatus(cirData.CirDataId, State.Approved, Progress.Done, cirData.ModifiedBy, string.Format("{0} by {1} on {2}", "Approved", cirData.ModifiedBy, DateTime.Now.ToString("dd/MM/yyyy")));

                            if (Convert.ToInt64(cirData.CirId) < hdnCirId)
                            {
                                UpdatePdfState(cirData.Guid, State.Approved);
                                DACIRLog.SaveCirLog(cirData.CirDataId, "PDF State Updated", LogType.Information, cirData.ModifiedBy);
                                //Notification GENERATOR = 4, GEARBOX = 2, BLADE = 1,TRANSFORMER = 5 AND ReportType is of Type = FAILURE
                                List<long> NotificationFor = new List<long> { 1, 2, 4, 5 };
                                if (NotificationFor.Contains(componentInspectionReport.ComponentInspectionReportTypeId) && componentInspectionReport.ReportTypeId == 2 &&
                   ((componentInspectionReport.ComponentInspectionReportGearbox != null && componentInspectionReport.ComponentInspectionReportGearbox.Count > 0 && componentInspectionReport.ComponentInspectionReportGearbox.FirstOrDefault().GearboxAuxEquipmentId == 1) ||
                                     (componentInspectionReport.ComponentInspectionReportTransformer != null && componentInspectionReport.ComponentInspectionReportTransformer.Count > 0 && componentInspectionReport.ComponentInspectionReportTransformer.FirstOrDefault().TransformerClaimRelevantBooleanAnswerId == 1) ||
                   (componentInspectionReport.ComponentInspectionReportGenerator != null && componentInspectionReport.ComponentInspectionReportGenerator.Count > 0 && (componentInspectionReport.ComponentInspectionReportGenerator.FirstOrDefault().GeneratorClaimRelevantBooleanAnswerId == 1 || componentInspectionReport.MountedOnMainComponentBooleanAnswerId == 1)) ||
                   (componentInspectionReport.ComponentInspectionReportBlade != null && componentInspectionReport.ComponentInspectionReportBlade.Count > 0 && (componentInspectionReport.ComponentInspectionReportBlade.FirstOrDefault().BladeClaimRelevantBooleanAnswerId == 1 || componentInspectionReport.MountedOnMainComponentBooleanAnswerId == 1))))
                                {
                                    DANotification da = new DANotification();
                                    da.SendNotification(DANotification.NotificationType.SecondNotification, cirData.CirDataId);
                                    SecondNotificationData secondNotificationData = da.SecondNotifications(cirData.CirDataId, cirData.CirId);
                                    if (!string.IsNullOrEmpty(secondNotificationData.AttachmentName))
                                    {
                                        da.SendNotifications(secondNotificationData);
                                        DACIRLog.SaveCirLog(cirData.CirDataId, "Second Notification sent to manufacturer", LogType.Information, cirData.ModifiedBy);
                                    }
                                }
                            }

                            DACIRLog.SaveCirLog(cirData.CirDataId, "Approval Process Completed", LogType.Information, cirData.ModifiedBy);

                        }
                        catch (Exception ex)
                        {
                            cirDataActionResponse.error = 1;
                            cirDataActionResponse.message = "Unable to Approve : " + ex.ToString();
                            SetStatus(cirData.CirDataId, State.Initial, Progress.PendingApprove, cirData.ModifiedBy, string.Format("{0} by {1} on {2}", "Approved", cirData.ModifiedBy, DateTime.Now.ToString("dd/MM/yyyy")));
                            DACIRLog.SaveCirLog(cirData.CirDataId, "Approval Process Failed. State reverted to " + State.Initial.ToString(), LogType.Information, cirData.ModifiedBy);
                        }
                    }

                    if (cirData.Progress == (int)Progress.PendingReject)
                    {
                        State s = (State)cirData.State;
                        try
                        {

                            SetStatus(cirData.CirDataId, State.Rejected, Progress.Done, cirData.ModifiedBy, string.Format("{0} by {1} on {2}", "Rejected", cirData.ModifiedBy, DateTime.Now.ToString("dd/MM/yyyy")));
                            if (Convert.ToInt64(cirData.CirId) < hdnCirId)
                            {
                                UpdatePdfState(cirData.Guid, State.Rejected);
                                DACIRLog.SaveCirLog(cirData.CirDataId, "PDF State Updated", LogType.Information, cirData.ModifiedBy);
                                DANotification da = new DANotification();
                                long id = da.SendRejectNotification(cirData, cirDataDetail.comment);
                                RejectNotificationData rejectNotificationData = da.RejectNotifications(id);
                                da.SendNotifications(rejectNotificationData);
                                DACIRLog.SaveCirLog(cirData.CirDataId, "Rejection Notification sent to manufacturer", LogType.Information, cirData.ModifiedBy);
                            }
                            DACIRLog.SaveCirLog(cirData.CirDataId, "Rejection Process Completed", LogType.Information, cirData.ModifiedBy);

                        }
                        catch (Exception ex)
                        {
                            cirDataActionResponse.error = 1;
                            cirDataActionResponse.message = "Unable to Reject : " + ex.ToString();
                            SetStatus(cirData.CirDataId, s, Progress.PendingReject, cirData.ModifiedBy, string.Format("{0} by {1} on {2}", "Approved", cirData.ModifiedBy, DateTime.Now.ToString("dd/MM/yyyy")));
                            DACIRLog.SaveCirLog(cirData.CirDataId, "Rejection Process Failed. State reverted to " + s.ToString(), LogType.Information, cirData.ModifiedBy);
                        }

                    }
                    if (cirData.Progress == (int)Progress.PendingInitial)
                    {
                        State s = (State)cirData.State;
                        try
                        {

                            SetStatus(cirData.CirDataId, State.Initial, Progress.Done, cirData.ModifiedBy, string.Format("{0} by {1} on {2}", "Move to Submitted", cirData.ModifiedBy, DateTime.Now.ToString("dd/MM/yyyy")));
                            if (Convert.ToInt64(cirData.CirId) < hdnCirId)
                            {
                                UpdatePdfState(cirData.Guid, State.Initial);
                                DACIRLog.SaveCirLog(cirData.CirDataId, "CIR PDF State Updated", LogType.Information, cirData.ModifiedBy);
                                DANotification da = new DANotification();
                                long id = da.SendSbuRejectNotification(cirData, cirDataDetail.comment);
                                SBURejectNotificationData sbuRejectNotificationData = da.SBURejectNotifications(id);
                                da.SendNotifications(sbuRejectNotificationData);
                                DACIRLog.SaveCirLog(cirData.CirDataId, "Notification sent to SBU", LogType.Information, cirData.ModifiedBy);
                            }
                            DACIRLog.SaveCirLog(cirData.CirDataId, "Move to Initial Process Completed", LogType.Information, cirData.ModifiedBy);
                        }
                        catch (Exception ex)
                        {
                            cirDataActionResponse.error = 1;
                            cirDataActionResponse.message = "Unable to Reject : " + ex.ToString();
                            SetStatus(cirData.CirDataId, s, Progress.PendingInitial, cirData.ModifiedBy, string.Format("{0} by {1} on {2}", "Approved", cirData.ModifiedBy, DateTime.Now.ToString("dd/MM/yyyy")));
                            DACIRLog.SaveCirLog(cirData.CirDataId, "Move to Initial Process Failed. CIR State reverted to " + s.ToString(), LogType.Information, cirData.ModifiedBy);
                        }
                    }


                    if (callPdfGeneration && Convert.ToInt64(cirData.CirId) < hdnCirId)
                    {
                        string DocumentPath = HttpContext.Current.Server.MapPath("CIRTemplates");
                        string SpireLicensePath = HttpContext.Current.Server.MapPath("~/SpireLicense");
                        GeneratePDFDelegate d = null;
                        d = new GeneratePDFDelegate(DACIRReport.RenderCirReport);
                        IAsyncResult R = null;
                        R = d.BeginInvoke(cirData.CirId, DocumentPath, SpireLicensePath, null, null); //invoking the method
                    }
                }
                return cirDataActionResponse;
            }
          
        }

        private static void UpdatePdfState(string uid, State state)
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {

                PDF pdf = context.PDF.Where(x => x.CIRTemplateGUID == uid).FirstOrDefault();
                if (pdf != null)
                {
                    pdf.CIRState = (int)state;

                }
                context.SaveChanges();
            }

        }
        

        public static bool SendFirstNotification(long CirDataId, long CirID)
        {
            DANotification da = new DANotification();
            da.SendNotification(DANotification.NotificationType.FirstNotification, CirDataId);
            FirstNotificationData firstNotificationData = da.FirstNotifications(CirDataId, CirID);
            da.SendNotifications(firstNotificationData);
            return true;
        }

        public static List<CirViewData> DAGetAllViews()
        {
            List<CirViewData> _allViews = new List<CirViewData>();
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                var allList = context.CirView.Where(x => x.CirViewData != null).OrderBy(x => x.Type).ToList();
                _allViews.Add(DefaultView);

                foreach (var v in allList)
                {
                    try
                    {
                        _allViews.Add(SerializeView(v));
                    }
                    catch (Exception ex)
                    {
                        string s = ex.Message.ToString();
                    }
                }
                _allViews.Add(ErrorView);
            }
            return _allViews;
            //else


        }

        public static CirViewData GetAllViewList(string initials = "")
        {
            var list = ApplicableViews(initials).Values.ToList();
            CirViewData view = new CirViewData();
            view.ViewDetailList = new List<CirViewDDList>();
            foreach (var v in list)
            {
                CirViewDDList c = new CirViewDDList();
                c.ViewId = v.ViewId;
                c.Type = v.Type.ToString();
                c.CreatedBy = v.CreatedBy;
                c.Name = v.Name;
                c.InspectionAvailable = v.InspectionApplicable;
                c.GeneralInspectionApplicable = v.GeneralInspectionApplicable;
                c.GBXInspectionApplicable = v.GBXInspectionApplicable;
                view.ViewDetailList.Add(c);
            }
            view.ViewDetailList = view.ViewDetailList.OrderBy(x => x.ViewId != -1).ThenBy(x => x.Type).ThenBy(x => x.Name).ToList();
            return view;
        }

        private static void LoadViews()
        {
            var views = DAGetAllViews();
            //foreach (var v in views)
            //{
            //    if (v.QuickFilterId != "")
            //    {
            //        v.QuickFilter = QuickFilters.FirstOrDefault(f => f.Value == v.QuickFilterId);
            //    }
            //    v.FieldMapping = DAFieldMappings().Select(x => new FieldItem { ColumnName = x.ColumnName, TableName = x.TableName, ColumnDisplayName = x.ColumnDisplayName }).ToList();
            //    v.QuickFilterList = QuickFilters;
            //}

            _views = views.ToDictionary(v => v.ViewId);
            // _views[DefaultView.ViewId] = DefaultView;

        }

        public static Dictionary<int, CirViewData> Views
        {
            get
            {
                LoadViews();
                return _views;
            }
        }

        public static Dictionary<int, CirViewData> ApplicableViews(string initials = "")
        {
            return Views.Values.Where(v => v.Type != CirViewData.ViewType.Private || v.CreatedBy.Replace("#EXT#", "").ToLower() == initials.Replace("#EXT#", "").ToLower()).ToDictionary(v => v.ViewId);
        }

        public static CirViewData DAGetView(int viewId)
        {
            var views = DAGetAllViews();
            return views.FirstOrDefault(v => v.ViewId == viewId);
        }

        public static CirViewData GetView(int viewId)
        {
            var view = DAGetView(viewId);
            if (view != null && view.ViewId > 0)
            {
                if (view.QuickFilterId != "")
                {
                    view.QuickFilter = QuickFilters.FirstOrDefault(f => f.Value == view.QuickFilterId);
                }
                view.FieldMapping = DAFieldMappings().Select(x => new FieldItem { ColumnName = x.ColumnName, TableName = x.TableName, ColumnDisplayName = x.ColumnDisplayName }).OrderBy(x => x.ColumnDisplayName).ToList();
                view.QuickFilterList = QuickFilters;
                return view;
            }
            else
            {
                view = DefaultView;
                view.FieldMapping = DAFieldMappings().Where(x => x.isDefault != 1).Select(x => new FieldItem { ColumnName = x.ColumnName, TableName = x.TableName, ColumnDisplayName = x.ColumnDisplayName }).OrderBy(x => x.ColumnDisplayName).ToList();
                view.Fields.FieldItems = DAFieldMappings().Where(x => x.isDefault == 1).Select(x => new FieldItem { ColumnName = x.ColumnName, TableName = x.TableName, ColumnDisplayName = x.ColumnDisplayName }).OrderBy(x => x.ColumnDisplayName).ToList();
                view.QuickFilterList = QuickFilters;


            }
            return view;
        }

        private static CirViewData SerializeView(CirView CirViewentity)
        {
            if (CirViewentity == null)
            {
                return null;
            }
            CirViewData view;
            if (string.IsNullOrEmpty(CirViewentity.CirViewData))
            {
                view = new CirViewData();
            }
            else
            {
                view = Serializer.FromXml<CirViewData>(CirViewentity.CirViewData);
            }
            view.ViewId = CirViewentity.CirViewId;
            view.Type = (CirViewData.ViewType)CirViewentity.Type;
            view.Created = CirViewentity.Created;
            view.CreatedBy = CirViewentity.CreatedBy;
            view.InspectionApplicable = CirViewentity.InspectionApplicable;
            view.GeneralInspectionApplicable = CirViewentity.GeneralInspectionApplicable;
            view.GBXInspectionApplicable = CirViewentity.GBXInspectionApplicable;
            return view;
        }


        public static int CreateView(CirViewData view)
        {
            int returnValue = -1;
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                CirView entity = new CirView();

                if (view.ViewId > 0)
                {
                    //CirViewentity.CirViewId = view.ViewId;
                    entity = context.CirView.Where(x => x.CirViewId == view.ViewId).FirstOrDefault();
                }
                entity.Created = DateTime.Now;
                entity.CreatedBy = view.CreatedBy;
                if (entity.Type != 3)
                {
                    entity.Type = (short)view.Type;
                }
                else
                {
                    entity.Type = entity.Type;
                }
                entity.InspectionApplicable = view.InspectionApplicable;
                entity.GeneralInspectionApplicable = view.GeneralInspectionApplicable;
                entity.GBXInspectionApplicable = view.GBXInspectionApplicable;
                if (view.InspectionApplicable == true)
                {
                    UpdatePreviousView("InspectionApplicable");
                }
                else if (view.GeneralInspectionApplicable == true)
                {
                    UpdatePreviousView("GeneralInspectionApplicable");
                }
                else if (view.GBXInspectionApplicable == true)
                {
                    UpdatePreviousView("GBXInspectionApplicable");
                }

                entity.InspectionApplicable = view.InspectionApplicable;
                entity.GeneralInspectionApplicable = view.GeneralInspectionApplicable;
                entity.GBXInspectionApplicable = view.GBXInspectionApplicable;

                entity.CirViewData = Serializer.ToXml<CirViewData>(view);
                if (view.ViewId <= 0)
                {
                    entity.ViewData = "";
                    context.CirView.Add(entity);
                }
                context.SaveChanges();

                returnValue = entity.CirViewId;

            }
            return returnValue;
        }

        public static void UpdatePreviousView(string chkparam)
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                CirView entity = new CirView();
                List<CirView> lstCirView = new List<CirView>();
                switch (chkparam)
                {
                    case "InspectionApplicable":
                        lstCirView = context.CirView.Where(x => x.InspectionApplicable == true).ToList();
                        if (lstCirView != null)
                        {
                            foreach (CirView objCirView in lstCirView)
                            {
                                objCirView.InspectionApplicable = false;
                            }
                        }
                        //entity = context.CirView.Where(x => x.InspectionApplicable == true).FirstOrDefault();
                        //entity.InspectionApplicable = false;
                        break;
                    case "GeneralInspectionApplicable":
                        lstCirView = context.CirView.Where(x => x.GeneralInspectionApplicable == true).ToList();
                        if (lstCirView != null)
                        {
                            foreach (CirView objCirView in lstCirView)
                            {
                                objCirView.GeneralInspectionApplicable = false;
                            }
                        }
                        //entity = context.CirView.Where(x => x.GeneralInspectionApplicable == true).FirstOrDefault();
                        //entity.GeneralInspectionApplicable = false;
                        break;
                    case "GBXInspectionApplicable":
                        lstCirView = context.CirView.Where(x => x.GBXInspectionApplicable == true).ToList();
                        if (lstCirView != null)
                        {
                            foreach (CirView objCirView in lstCirView)
                            {
                                objCirView.GBXInspectionApplicable = false;
                            }
                        }
                        //entity = context.CirView.Where(x => x.GBXInspectionApplicable == true).FirstOrDefault();
                        //entity.GBXInspectionApplicable = false;
                        break;
                    default:
                        break;
                }
                context.SaveChanges();
            }
        }

        public static bool DeleteView(int viewId)
        {

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                CirView entity = new CirView();
                entity.CirViewId = viewId;
                entity = context.CirView.Where(x => x.CirViewId == viewId).FirstOrDefault();
                if (entity.Type == 3)
                {
                    return false;
                }
                else
                {
                    context.CirView.Remove(entity);
                }
                context.SaveChanges();
            }
            return true;
        }

        public static List<ViewQuickFilter> QuickFilters
        {
            get
            {
                // TODO: Get quick filters from DB?
                FieldItem field = MetadataItem.SystemFields.SystemFieldItems.Where(x => x.ColumnName == "LookupSbu").FirstOrDefault();
                return new List<ViewQuickFilter> {
                                                     new ViewQuickFilter(1, "SBU: Vestas Americas", field, "AME"),
                                                    //new ViewQuickFilter(2, "SBU: Central - and Latin - America ", field, "CSA"),
                                                    new ViewQuickFilter(2, "SBU: Latin - America ", field, "CSA"),
                                                     new ViewQuickFilter(3, "SBU: Northern Europe", field, "SE - NEU"),
                                                     new ViewQuickFilter(4, "SBU: Asia Pacific", field, "ASP"),
                                                     new ViewQuickFilter(5, "SBU: Mediterranean", field, "MED"),
                                                     new ViewQuickFilter(6, "SBU: Vestas Central Europe", field, "CEU"),
                                                     new ViewQuickFilter(7, "SBU: Vestas Offshore A/S", field, "OFS"),
                                                     new ViewQuickFilter(8, "SBU: Vestas China", field, "CHI"),
                                                     new ViewQuickFilter(9, "SBU: 3MW Gearbox", field, "3MW"),
                                                    new ViewQuickFilter(10, "SBU: Error", field, "ERR")
                                                 };
            }
        }


        public static CirViewData DefaultView
        {
            get
            {
                if (_defaultView == null)
                {
                    _defaultView = new CirViewData
                    {
                        Fields = new CirViewFields
                        {
                            FieldItems = new List<FieldItem>
                                                {
                                    new FieldItem{ ColumnName = "FileName", ColumnDisplayName="Name",TableName = "Filename"},
                                    new FieldItem{ ColumnName = "ComponentInspectionReportId", ColumnDisplayName="CIR ID",TableName = "ComponentInspectionReport"},
                                    new FieldItem{ ColumnName = "CimCaseNumber", ColumnDisplayName="CIM Case Number",TableName = "ComponentInspectionReport"},
                                    new FieldItem{ ColumnName = "Name", ColumnDisplayName="Component Type",TableName = "ComponentInspectionReportType"},
                                    new FieldItem{ ColumnName = "Reporttype", ColumnDisplayName="Report Type",TableName = "ComponentInspectionReport"},
                                    new FieldItem{ ColumnName = "Name", ColumnDisplayName="Country",TableName = "CountryISO"},
                                    new FieldItem{ ColumnName = "TurbineType", ColumnDisplayName="Turbine Type",TableName = "ComponentInspectionReport"},
                                    new FieldItem{ ColumnName = "TurbineNumber", ColumnDisplayName="Turbine Number",TableName = "ComponentInspectionReport"},
                                    new FieldItem{ ColumnName = "RunStatus", ColumnDisplayName="Run Status After Inspection",TableName = "ComponentInspectionReport"},
                                    new FieldItem{ ColumnName = "SBU", ColumnDisplayName="SBU",TableName = "ComponentInspectionReport"},
                                    new FieldItem{ ColumnName = "Created", ColumnDisplayName="Created",TableName = "ComponentInspectionReport"},
                                    new FieldItem{ ColumnName = "Modified", ColumnDisplayName="Modified",TableName = "CirData"},
                                    new FieldItem{ ColumnName = "Brand", ColumnDisplayName="Brand",TableName = "ComponentInspectionReport"}
                                      }



                        },
                        Filter = new ViewFilter
                        {
                            MatchAll = false,
                            FilterItems = new List<ViewFilterItem>
                            {
                            },
                        },
                        Sort = new ViewSorter
                        {
                            Ascending = false,
                            FieldItem = new FieldItem { ColumnName = "Modified", ColumnDisplayName = "Modified", TableName = "ComponentInspectionReport" }
                        },
                        ResultsPerPage = 50,
                        Name = "Default",
                        ViewId = -1
                    };
                }
                return _defaultView.Clone() as CirViewData;
            }
        }

        public static CirViewData ErrorView
        {
            get
            {
                if (_errorView == null)
                {
                    _errorView = new CirViewData
                    {
                        Fields = new CirViewFields
                        {
                            FieldItems = new List<FieldItem>
                                                {
                                    new FieldItem{ ColumnName = "FileName", ColumnDisplayName="Name",TableName = "Filename"},
                                    new FieldItem{ ColumnName = "ComponentInspectionReportId", ColumnDisplayName="CIR ID",TableName = "ComponentInspectionReport"},
                                    new FieldItem{ ColumnName = "CimCaseNumber", ColumnDisplayName="CIM Case Number",TableName = "ComponentInspectionReport"},
                                    new FieldItem{ ColumnName = "Name", ColumnDisplayName="Component Type",TableName = "ComponentInspectionReportType"},
                                    new FieldItem{ ColumnName = "Reporttype", ColumnDisplayName="Report Type",TableName = "ComponentInspectionReport"},
                                    new FieldItem{ ColumnName = "Name", ColumnDisplayName="Country",TableName = "CountryISO"},
                                    new FieldItem{ ColumnName = "TurbineType", ColumnDisplayName="Turbine Type",TableName = "ComponentInspectionReport"},
                                    new FieldItem{ ColumnName = "TurbineNumber", ColumnDisplayName="Turbine Number",TableName = "ComponentInspectionReport"},
                                    new FieldItem{ ColumnName = "RunStatus", ColumnDisplayName="Run Status After Inspection",TableName = "ComponentInspectionReport"},
                                    new FieldItem{ ColumnName = "SBU", ColumnDisplayName="SBU",TableName = "ComponentInspectionReport"},
                                    new FieldItem{ ColumnName = "Created", ColumnDisplayName="Created",TableName = "ComponentInspectionReport"},
                                    new FieldItem{ ColumnName = "Modified", ColumnDisplayName="Modified",TableName = "CirData"},
                                    new FieldItem{ ColumnName = "Brand", ColumnDisplayName="Brand",TableName = "ComponentInspectionReport"}
                }



                        },
                        Filter = new ViewFilter
                        {
                            MatchAll = false,
                            FilterItems = new List<ViewFilterItem>
                            {
                            },
                        },
                        Sort = new ViewSorter
                        {
                            Ascending = false,
                            FieldItem = new FieldItem { ColumnName = "Modified", ColumnDisplayName = "Modified", TableName = "ComponentInspectionReport" }
                        },
                        ResultsPerPage = 50,
                        Name = "Migration Error",
                        ViewId = -2,
                        Type = CirViewData.ViewType.MigrationError
                    };
                }
                return _errorView.Clone() as CirViewData;
            }
        }

        /// <summary>
        ///  Return Connection string
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CIM_MasterDataConn"].ConnectionString;
        }

        private static bool ResendSecondNotification()
        {
            bool retval = false;
            DataSet CIRList = new DataSet();
            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                string query = @"SELECT TOBESENT.CirId, TOBESENT.CirDataId FROM (select Distinct CD.CirId, CD.CirDataId From (select CirDataId, CirId from CirData
                                    where Modified >= '2016-10-24 00:00:00'
                                    AND DELETED = 0) CD
                                    Left outer join SecondNotification SN
                                    ON CD.CirDataId = SN.CirDataId    
                                    where SN.SecondNotificationId is not null) TOBESENT
                                    LEFT OUTER JOIN (select Distinct CD.CirId From (select CirDataId, CirId from CirData
                                    where Modified >= '2016-10-24 00:00:00'
                                    AND DELETED = 0) CD
                                    Left outer join CirMailArchive CA
                                    ON CD.CirDataId = CA.CirDataId
                                    where CA.Type  = 3
                                    AND Ca.CirMailArchiveId is not null ) SENTSUCCESS
                                    ON TOBESENT.CirId = SENTSUCCESS.CirId
                                    WHERE SENTSUCCESS.CirId IS  NULL";

                using (SqlCommand cmd = new SqlCommand(query, objCon))
                {
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataAdapter sqlda = new SqlDataAdapter(cmd))
                    {
                        sqlda.Fill(CIRList);
                    }
                    var CLIST = CIRList.Tables[0];
                    DANotification da = new DANotification();
                    foreach (DataRow c in CLIST.Rows)
                    {
                        try
                        {
                            long cirdataid = Convert.ToInt64(c["CirDataId"]);
                            long cirid = Convert.ToInt64(c["CirId"]);

                            SecondNotificationData secondNotificationData = da.SecondNotifications(cirdataid, cirid);
                            da.SendNotifications(secondNotificationData);
                            DACIRLog.SaveCirLog(cirdataid, "Second Notification sent to manufacturer", LogType.Information, "System");
                        }
                        catch (Exception e)
                        {
                            DACIRLog.SaveCirLog(Convert.ToInt64(c["CirDataId"]), "Second Notification ERROR", LogType.Error, "System");
                        }
                    }
                }

            }

            return retval;
        }

        public static bool ResendSecondMails()
        {
            NotificationResendDelegate d = null;
            d = new NotificationResendDelegate(ResendSecondNotification);
            IAsyncResult R = null;
            R = d.BeginInvoke(null, null); //invoking the method
            return true;
        }
    }

    [Serializable]
    public class MetadataItem : ICloneable, ISerializable
    {
        #region System field Ids

        public static class SystemFields
        {

            public static readonly List<FieldItem> SystemFieldItems = new List<FieldItem>{
                    new FieldItem{ ColumnName = "Created", ColumnDisplayName="Created",TableName = "ComponentInspectionReport"},
                    new FieldItem{ ColumnName = "CreatedBy", ColumnDisplayName="Created By",TableName = "ComponentInspectionReport"},
                    new FieldItem{ ColumnName = "Modified", ColumnDisplayName="Modified",TableName = "ComponentInspectionReport"},
                    new FieldItem{ ColumnName = "ModifiedBy", ColumnDisplayName="Modified By",TableName = "ComponentInspectionReport"},
                    new FieldItem{ ColumnName = "Name", ColumnDisplayName="Name",TableName = "ComponentInspectionReport"},
                    new FieldItem{ ColumnName = "CirId", ColumnDisplayName="CIR ID",TableName = "ComponentInspectionReport"},
                    new FieldItem{ ColumnName = "CimCaseNumber", ColumnDisplayName="CimCaseNumber",TableName = "ComponentInspectionReport"},
                    new FieldItem{ ColumnName = "TurbineId", ColumnDisplayName="Turbine Number",TableName = "ComponentInspectionReport"},
                    new FieldItem{ ColumnName = "LookupSbu", ColumnDisplayName="SBU",TableName = "ComponentInspectionReport"}
            };


        }

        #endregion

        public MetadataItem()
        {

        }

        #region ISerializable members

        protected MetadataItem(SerializationInfo info, StreamingContext context)
        {
            _x_FieldValues = info.GetValue("_x_FieldValues", typeof(DictionaryEntry[])) as DictionaryEntry[];
            _x_FieldIntegerValues = info.GetValue("_x_FieldIntegerValues", typeof(DictionaryEntry[])) as DictionaryEntry[];
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("_x_FieldValues", _x_FieldValues);
            info.AddValue("_x_FieldIntegerValues", _x_FieldIntegerValues);
        }

        #endregion

        [XmlIgnore]
        public SafeDictionary<string> FieldValues = new SafeDictionary<string>();

        [XmlIgnore]
        public SafeDictionary<int> FieldIntegerValues = new SafeDictionary<int>();

        [XmlIgnore]
        public State State = State.Initial;

        [XmlIgnore]
        public Progress Progress = Progress.Done;

        [XmlIgnore]
        public bool Deleted = false;

        [XmlIgnore]
        public long CirDataId;

        [XmlIgnore]
        public long BirDataId;

        [XmlIgnore]
        public int RevisionNumber;

        [XmlIgnore]
        public string Site;

        [XmlIgnore]
        private DateTime _created = DateTime.MinValue;

        [XmlIgnore]
        public DateTime Created
        {
            get
            {
                return _created;
            }
            set
            {
                _created = value;
                FieldValues[SystemFields.SystemFieldItems[0].ColumnName] = _created.ToString("dd/MM/yyyy HH:mm");
            }
        }

        [XmlIgnore]
        public string CreatedBy
        {
            get
            {
                return FieldValues[SystemFields.SystemFieldItems[1].ColumnName];
            }
            set
            {
                FieldValues[SystemFields.SystemFieldItems[1].ColumnName] = value;
            }
        }


        [XmlIgnore]
        private DateTime _modified = DateTime.MinValue;

        [XmlIgnore]
        public DateTime Modified
        {
            get
            {
                return _modified;
            }
            set
            {
                _modified = value;
                FieldValues[SystemFields.SystemFieldItems[2].ColumnName] = _modified.ToString("dd/MM/yyyy HH:mm");
            }
        }

        [XmlIgnore]
        public string ModifiedBy
        {
            get
            {
                return FieldValues[SystemFields.SystemFieldItems[3].ColumnName];
            }
            set
            {
                FieldValues[SystemFields.SystemFieldItems[3].ColumnName] = value;
            }
        }

        [XmlIgnore]
        public string Name
        {
            get
            {
                return FieldValues[SystemFields.SystemFieldItems[4].ColumnName];
            }
            set
            {
                FieldValues[SystemFields.SystemFieldItems[4].ColumnName] = value;
            }
        }

        [XmlIgnore]
        public long CirId
        {
            get
            {
                return (long)FieldIntegerValues[SystemFields.SystemFieldItems[5].ColumnName];
            }
            set
            {
                FieldValues[SystemFields.SystemFieldItems[5].ColumnName] = value.ToString();
            }
        }

        #region XML Serializer help

        // this region makes it possible to serialize and deserialize the FieldValues dictionaries

        [XmlArray("FieldValues")]
        [XmlArrayItem("FieldValuesLine", Type = typeof(DictionaryEntry))]
        public DictionaryEntry[] _x_FieldValues
        {
            get
            {
                return SerializableDictionary<string>(FieldValues);
            }
            set
            {
                FieldValues.Clear();
                for (int i = 0; i < value.Length; i++)
                {
                    FieldValues.Add((string)value[i].Key, (string)value[i].Value);
                }
            }
        }

        [XmlArray("FieldIntegerValues")]
        [XmlArrayItem("FieldIntegerValuesLine", Type = typeof(DictionaryEntry))]
        public DictionaryEntry[] _x_FieldIntegerValues
        {
            get
            {
                return SerializableDictionary<int>(FieldIntegerValues);
            }
            set
            {
                FieldIntegerValues.Clear();
                for (int i = 0; i < value.Length; i++)
                {
                    FieldIntegerValues.Add((string)value[i].Key, (int)value[i].Value);
                }
            }
        }

        private DictionaryEntry[] SerializableDictionary<T>(SafeDictionary<T> dictionary)
        {
            //Make an array of DictionaryEntries to return   
            DictionaryEntry[] ret = new DictionaryEntry[dictionary.Count];
            int i = 0;
            DictionaryEntry de;
            //Iterate through Stuff to load items into the array.   
            foreach (var kvp in dictionary)
            {
                de = new DictionaryEntry();
                de.Key = kvp.Key;
                de.Value = kvp.Value;
                ret[i] = de;
                i++;
            }
            return ret;
        }

        #endregion

        public object Clone()
        {
            var clone = this.MemberwiseClone() as MetadataItem;
            clone.FieldIntegerValues = new SafeDictionary<int>();
            foreach (var kvp in this.FieldIntegerValues)
            {
                clone.FieldIntegerValues.Add(kvp.Key, kvp.Value);
            }
            clone.FieldValues = new SafeDictionary<string>();
            foreach (var kvp in this.FieldValues)
            {
                clone.FieldValues.Add(kvp.Key, kvp.Value);
            }
            return clone;
        }

        /// <summary>
        /// We need this "safe" dictionary when indexing for not existing field UUIDs 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class SafeDictionary<T> : Dictionary<string, T>
        {
            public new T this[string key]
            {
                get
                {
                    if (base.ContainsKey(key))
                    {
                        return base[key];
                    }
                    return default(T);
                }
                set
                {
                    base[key] = value;
                }
            }

            public SafeDictionary()
                : base()
            {
            }

            public SafeDictionary(IDictionary<string, T> dictionary)
                : base(dictionary)
            {
            }
        }
    }

    public enum State
    {
        Initial = 1,
        Approved = 2,
        Rejected = 3

        //		Failed = 4
    }

    public enum Progress
    {
        Done = 1,
        PendingApprove = 2,
        PendingReject = 3,
        PendingInitial = 4,
        ProcessError = 5,
        InitialError = 6,
        PendingDelete = 7,
        PendingLock = 8
    }
    public enum CommentType
    {
        General = 0,
        Approve = 1,
        Reject = 2,
        MoveToInitial = 3,
        Deleted = 4,
        Locked = 5
    }

}