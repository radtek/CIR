using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Cir.Sync.Services.ServiceContracts;
using Cir.Sync.Services.DataContracts;
using Cir.Sync.Services.BLL;
using Cir.Sync.Services.CIR;
using Cir.Sync.Services.ErrorHandling;
using Newtonsoft.Json;
using System.Globalization;
using System.Web.Hosting;
using System.IO;
using System.Web;
using Newtonsoft.Json.Linq;
using Cir.Sync.Services.Models;
using Cir.Sync.Services.Notification;
using Cir.Sync.Services.DAL;

namespace Cir.Sync.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [GlobalErrorBehaviorAttribute(typeof(GlobalErrorHandler))]
    public class SyncService : ISyncService
    {
        /// <summary>
        /// Get cir master data service method
        /// </summary>
        /// <param name="Active"></param>
        /// <returns></returns>
        public List<CirMasterData> GetMasterData()
        {
            return BLL.BLMasterData.GetMasterData();
        }

        public List<MasterKeyData> GetMasterDataForCIRReport()
        {
            return DACIRReport.GetMasterDataForCIRReport();
        }
        /// <summary>
        /// Get cir's pdf data
        /// </summary>
        /// <param name="cirId"></param>
        /// <returns></returns>
        public DataContracts.PDFModel GetCirPDFData(string cirId)
        {
            return BLL.BLMasterData.GetCirPDFData(cirId);
        }

        public List<CirMasterTable> GetMasterDataByName(string TableName, string UserId)
        {
            return BLL.BLMasterData.GetMasterDataByName(TableName, UserId);
        }

        public List<CirCIMCaseTable> GetCIMCaseData()
        {
            return BLL.BLMasterData.GetCIMCaseData();
        }

        /// <summary>
        /// Save cir DATA
        /// </summary>
        /// <param name="Active"></param>
        /// <returns></returns>
        public CirResponse SaveCIRData(ComponentInspectionReport CIRList)
        {
            CirResponse oCirResponse;
            if ((null != CIRList))
            {
                oCirResponse = BLL.BLCIRData.SaveCIRData(CIRList);
            }
            else
            {
                oCirResponse = new CirResponse() { Status = false, StatusMessage = ErrorCode.GetEnumDescription(ErrorCode.ReturnCodeVal.Null) };
            }

            return oCirResponse;
        }

        /// <summary>
        /// Save cir DATA
        /// </summary>
        /// <param name="Active"></param>
        /// <returns></returns>
        public CirResponse UpdatePDFData()
        {
            CirResponse oCirResponse;
            oCirResponse = BLL.BLCIRData.UpdatePDFData();

            return oCirResponse;
        }
        /// <summary>
        /// Cir Validation
        /// </summary>
        /// <param name="CIRList"></param>
        /// <returns></returns>
        public bool BladeDataValid(ComponentInspectionReport CIRList)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(CIRList.BladeData.BladeSerialNumber) || float.Parse(CIRList.BladeData.BladeSerialNumber) == 0)
            {
                isValid = false;
            }
            if (CIRList.BladeData.BladeFaultCodeClassificationId == 0)
            {
                isValid = false;
            }
            if (string.IsNullOrEmpty(CIRList.BladeData.BladeOtherSerialNumber1) || float.Parse(CIRList.BladeData.BladeOtherSerialNumber1) == 0)
            {
                isValid = false;
            }
            if (string.IsNullOrEmpty(CIRList.BladeData.BladeOtherSerialNumber2) || float.Parse(CIRList.BladeData.BladeOtherSerialNumber2) == 0)
            {
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// Get cir master data service method
        /// </summary>
        /// <param name="Active"></param>
        /// <returns></returns>
        public ComponentInspectionReport GetCIRDatabyCIRID(Int64 CIRID)
        {
            if (CIRID > 0)
            {
                return BLL.BLCIRData.GetCIRDatabyCIRID(CIRID);
            }
            else
            {
                ComponentInspectionReport objComp = new ComponentInspectionReport();
                objComp.ErrorMessage = ErrorCode.GetEnumDescription(ErrorCode.ReturnCodeVal.Blank);
                return objComp;
            }

        }

        /// <summary>
        /// Get cir master data service method
        /// </summary>
        /// <param name="Active"></param>
        /// <returns></returns>
        public List<ComponentInspectionReport> CirQuickSearch(CirQuickSearch Search)
        {
            if (!ReferenceEquals(Search, null))
            {
                return BLL.BLCIRData.CirQuickSearch(
                    Search: Search
                    );
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Get standard text data service method by ID
        /// </summary>
        /// <param name="Active"></param>
        /// <returns></returns>
        public void SaveandUpdate(StandardTexts StandardText)
        {
            BLStandardText.SaveStandardText(StandardText);
        }

        #region Manage Standard Text
        public List<ComponentInspectionReportType> GetComponentInspectionReportType()
        {
            return BLL.BLStandardText.GetCommonInspectionReportType();
        }

        public List<StandardTexts> GetStandardText(Int32 CommonInspectionReportID)
        {
            return BLL.BLStandardText.GetStandardText(CommonInspectionReportID);
        }

        public StandardTexts GetStandardTextbyID(Int64 SID)
        {
            return BLL.BLStandardText.GetStandardTextbyID(SID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StandardText"></param>
        /// <returns></returns>
        public StandardTexts SaveStandardTextData(StandardTexts StandardText)
        {
            return BLL.BLStandardText.SaveStandardText(StandardText);
        }

        #endregion

        #region BIR List
        /// <summary>
        /// Service method for Bir Search
        /// </summary>
        /// <param name="oSearchAttributes"></param>
        /// <returns></returns>
        public List<Bir> BirSearch(Bir bir)
        {
            return BLL.BirBLL.Search(
                bir: bir
                );
        }
        /// <summary>
        /// Delete bir by id
        /// </summary>
        /// <param name="BirID"></param>
        /// <returns></returns>
        public bool DeleteBir(long BirID)
        {
            return BLL.BirBLL.DeleteBir(BirID);
        }
        /// <summary>
        /// Get bir file bytes
        /// </summary>
        /// <param name="BirID"></param>
        /// <returns></returns>
        public Bir BirFile(long BirID)
        {
            return BirBLL.BirFileBytes(
                BirID: BirID
                );
        }



        /// <summary>
        /// Get bir file bytes
        /// </summary>
        /// <param name="BirID"></param>
        /// <returns></returns>
        public Bir GetBirDataByCirID(string CirIDs)
        {
            return BLL.BirBLL.GetBirDataByCirID(
                CirIDs
                );
        }

        /// <summary>
        /// Get related cirs by cird id
        /// </summary>
        /// <param name="cirid"></param>
        /// <returns></returns>
        public string GetRelatedCirsByCirId(string cirId)
        {
            return BLL.BirBLL.GeRelatedCirsByCirId(cirId);
        }

        /// <summary>
        /// Service method for Bir Search
        /// </summary>
        /// <param name="oSearchAttributes"></param>
        /// <returns></returns>
        public Bir SaveBirData(Bir bir)
        {
            return BLL.BirBLL.SaveBirData(
                bir
                );
        }


        public Dictionary<string, string> GetCirDataIdByCirID(string CirIDs)
        {
            return BLL.BirBLL.GetCirDataIdByCirID(
               CirIDs
               );
        }

        #endregion

        #region GIR List
        /// <summary>
        /// Service method for Gir Search
        /// </summary>
        /// <param name="oSearchAttributes"></param>
        /// <returns></returns>
        public List<Gir> GirSearch(Gir gir)
        {
            return BLL.GirBLL.Search(
                gir: gir
                );
        }
        /// <summary>
        /// Delete gir by id
        /// </summary>
        /// <param name="GirID"></param>
        /// <returns></returns>
        public bool DeleteGir(long GirID)
        {
            return BLL.GirBLL.DeleteGir(GirID);
        }
        /// <summary>
        /// Get gir file bytes
        /// </summary>
        /// <param name="GirID"></param>
        /// <returns></returns>
        public Gir GirFile(long GirID)
        {
            return GirBLL.GirFileBytes(
                GirID: GirID
                );
        }



        /// <summary>
        /// Get gir file bytes
        /// </summary>
        /// <param name="GirID"></param>
        /// <returns></returns>
        public Gir GetGirDataByCirID(string CirIDs)
        {
            return BLL.GirBLL.GetGirDataByCirID(
                CirIDs
                );
        }

        /// <summary>
        /// Service method for Gir Search
        /// </summary>
        /// <param name="oSearchAttributes"></param>
        /// <returns></returns>
        public Gir SaveGirData(Gir gir)
        {
            return BLL.GirBLL.SaveGirData(
                gir
                );
        }

        #endregion

        #region GBXIR List

        public List<Gbx> GBXirSearch(Gbx gbx)
        {
            return BLL.GBXirBLL.Search(
                 gbx
                );
        }

        public bool DeleteGBXir(long GBXirID)
        {
            return BLL.GBXirBLL.DeleteGBXir(GBXirID);
        }


        public Gbx GBXirFile(long GBXirID)
        {
            return GBXirBLL.GBXirFileBytes(
                GBXirID
                );
        }

        public Gbx GetGBXirDataByCirID(string CirIDs)
        {
            return BLL.GBXirBLL.GetGBXirDataByCirID(
                CirIDs
                );
        }

        public Gbx SaveGBXirData(Gbx gbx)
        {
            return BLL.GBXirBLL.SaveGBXirData(
                gbx
                );
        }

        #endregion

        #region Logger
        /// <summary>
        /// System log service
        /// </summary>
        /// <param name="message"></param>
        /// <param name="detail"></param>
        /// <param name="type"></param>
        public bool Log(string message, string detail, LogType type)
        {
            BLL.BLSystemLog.Log(message, detail, type, string.Empty);
            return true;
        }
        /// <summary>
        /// Get sync logs
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// 
        public LogList GetLog(LogList log)
        {
            return BLL.BLSystemLog.GetLog(log);
        }
        #endregion

        #region Feedback
        public List<FeedbackType> GetFeedbackType()
        {
            return BLL.BLFeedback.GetFeedbackType();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Feedback"></param>
        /// <returns></returns>
        public Feedback SaveFeedback(Feedback FeedbackData)
        {
            return BLL.BLFeedback.SaveFeedback(FeedbackData);
        }

        public List<Feedback> GetAllFeedbacks()
        {
            return BLL.BLFeedback.GetAllFeedbacks();
        }

        public bool DeleteFeedback(long id)
        {
            return BLL.BLFeedback.DeleteFeedback(id);
        }
        #endregion

        #region Service Informations
        public List<Severity> GetSeverity()
        {
            return BLL.BLServiceInformation.GetSeverity();
        }

        public List<ServiceInformations> GetServiceInformation(bool All)
        {
            return BLL.BLServiceInformation.GetServiceInformation(All);
        }

        public ServiceInformations GetServiceInformationbyID(Int64 SID)
        {
            return BLL.BLServiceInformation.GetServiceInformationbyID(SID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StandardText"></param>
        /// <returns></returns>
        public ServiceInformations SaveServiceInformation(ServiceInformations strJsnServiceInformations)
        {
            return BLL.BLServiceInformation.SaveServiceInformation(strJsnServiceInformations);
        }

        #endregion

        #region Cir View
        /// <summary>
        /// Gets all view.
        /// </summary>
        /// <returns></returns>     
        public List<CirViewData> GetAllView()
        {

            return BLL.BLCIRViewData.GetAllView();
        }

        public CirViewData GetAllViewList(string initials = "")
        {

            return BLL.BLCIRViewData.GetAllViewList(initials);
        }

        /// <summary>
        /// Gets selected view.
        /// </summary>
        /// <returns></returns>       
        public CirViewData GetView(int ViewId)
        {

            return BLL.BLCIRViewData.GetView(ViewId);
        }

        /// <summary>
        /// Creates the view.
        /// </summary>
        /// <param name="cirViewData">The cir view data.</param>
        /// <param name="createdBy">The created by.</param>
        /// <returns></returns>        
        public int CreateView(CirViewData cirViewData)
        {
            return BLL.BLCIRViewData.CreateView(cirViewData);
        }

        /// <summary>
        /// Deletes the view.
        /// </summary>
        /// <param name="ViewId">The view identifier.</param>
        /// <returns></returns>        
        public bool DeleteView(int ViewId)
        {
            return BLL.BLCIRViewData.DeleteView(ViewId);
        }

        public CIRList GetCirList(CIRList cirList)
        {

            return BLL.BLCIRViewData.GetCirList(cirList);
        }

        public CirDataActionResponse CirProcess(CirDataDetail cirDataDetail)
        {
            return BLL.BLCIRViewData.CirProcess(cirDataDetail);
        }
        public bool SetApproved(long cirDataId, int State, int Progress, string modifiedBy, string comment)
        {
            return DAL.DACIRView.SetApproved(cirDataId, State, Progress, modifiedBy, comment);
        }
        public CirDataActionResponse LockUnlockCir(CirDataDetail cirDataDetail)
        {
            return BLL.BLCIRViewData.LockUnlockCir(cirDataDetail);
        }

        public CirDataDetail GetCirDataDetails(long CirDataId)
        {
            return BLL.BLCIRViewData.GetCirDataDetails(CirDataId);
        }

        public List<CirLogs> GetCIRLog(long CirDataId)
        {

            return BLL.BLCIRLog.GetCIRLog(CirDataId);
        }

        public CirDataDetails GetCirDataDetail(long CirDataId)
        {

            return BLL.BLCirDataDetail.GetCirDataDetail(CirDataId);
        }

        public List<CirCommentHistorys> GetCirCommentHistory(long CirDataId)
        {

            return BLL.BLCirCommentHistory.GetCirCommentHistory(CirDataId);
        }

        public List<CirCommentHistorys> GetCirCommentHistoryByCirId(long CirId)
        {

            return BLL.BLCirCommentHistory.GetCirCommentHistoryByCirId(CirId);
        }

        public CirCommentHistorys SaveCirCommentHistory(CirCommentHistorys CirCommentHistory)
        {
            return BLL.BLCirCommentHistory.SaveCirCommentHistory(CirCommentHistory);
        }

        public bool GenerateBIRReport(long BirDataID)
        {
            return BLL.BLBIRReport.GenerateBIRReport(BirDataID);
        }

        public BirFile GenerateNewBIRReport(long BirDataID, int languageId)
        {
            return BLL.BLBIRReport.GenerateNewBIRReport(BirDataID, languageId);
        }

        public Bir GetBirPDF(long BirDataID)
        {
            return BLL.BLBIRReport.GetBirPDF(BirDataID);
        }

        public bool GenerateGIRReport(long GirDataID)
        {
            return BLL.BLGIRReport.GenerateGIRReport(GirDataID);
        }

        public bool GenerateGBXIRReport(long GbxirDataID)
        {
            return BLL.BLGBXReport.GenerateGBXIRReport(GbxirDataID);
        }

        public Gir GetGirPDF(long GirDataID)
        {
            return BLL.BLGIRReport.GetGirPDF(GirDataID);
        }

        public Gbx GetGBXirPDF(long GBXirDataID)
        {
            return BLL.BLGBXReport.GetGbxPDF(GBXirDataID);
        }


        public bool SendFirstNotification(long CirDataID, long CirId)
        {
            return BLL.BLCIRData.SendFirstNotification(CirDataID, CirId);
        }

        public bool IsValidServiceReportNumber(string serviceReportNumber, string turbineNumber)
        {
            return BLL.BLCirValidator.IsValidServiceReportNumber(serviceReportNumber, turbineNumber);
        }

        public bool IsValidNotificationNumber(string notificationNumber, string turbineNumber)
        {
            return BLL.BLCirValidator.IsValidNotificationNumber(notificationNumber, turbineNumber);
        }

        public bool SaveCIRPdf(string uid, int state, string html = "", string name = "")
        {
            return BLL.BLBIRReport.SaveCIRPdf(uid, state, html, name);

        }
        public Bir GetCIRPdf(long CirDataId, long CirId = 0)
        {
            return BLL.BLBIRReport.GetCIRPdf(CirDataId, CirId);

        }

        public CirPDFResponse GetCIRPdfForSQL(long CirId)
        {
            return BLL.BLBIRReport.GetCIRPdfForSQL(CirId);
        }

        public Bir GetCIRPdfZip(string CirDataIds)
        {
            return BLL.BLBIRReport.GetCIRPdfZip(CirDataIds);

        }

        public bool SaveCIRPdfGIR(string uid, int state, string html = "", string name = "")
        {
            return BLL.BLGIRReport.SaveCIRPdf(uid, state, html, name);

        }
        public Gir GetCIRPdfGIR(long CirDataId, long CirId = 0)
        {
            return BLL.BLGIRReport.GetCIRPdf(CirDataId, CirId);

        }

        public bool SaveCIRPdfGBX(string uid, int state, string html = "", string name = "")
        {
            return BLL.BLGBXReport.SaveCIRPdf(uid, state, html, name);

        }
        public Gbx GetCIRPdfGBX(long CirDataId, long CirId = 0)
        {
            return BLL.BLGBXReport.GetCIRPdf(CirDataId, CirId);

        }

        public Gir GetCIRPdfZipGIR(string CirDataIds)
        {
            return BLL.BLGIRReport.GetCIRPdfZip(CirDataIds);

        }

        public Gbx GetCIRPdfZipGBX(string CirDataIds)
        {
            return BLL.BLGBXReport.GetCIRPdfZip(CirDataIds);

        }

        public bool RenderCirReport(long CirID)
        {
            return BLL.BLCIRReport.RenderCirReport(CirID);
        }

        public int GetBIRViewId()
        {
            return BLL.BLCIRViewData.GetBIRViewId();
        }

        public int GetGIRViewId()
        {
            return BLL.BLCIRViewData.GetGIRViewId();
        }

        public int GetGBXIRViewId()
        {
            return BLL.BLCIRViewData.GetGBXIRViewId();
        }

        public bool ResendSecondMails()
        {
            return BLL.BLCIRViewData.ResendSecondMails();

        }

        public List<CirDataDetail> GetMigrationCirList()
        {
            return BLL.BLCIRViewData.GetMigrationCirList();

        }
        public void SaveBirDataDetailstoCosmosDb(BirDataDetails oBirDetails, string birDataDocumentId)
        {
            BLL.BirBLL.SaveBirDataDetailstoCosmosDb(oBirDetails, birDataDocumentId);

        }
        #endregion

        #region CirRevision
        /// <summary>
        /// Added By : Siddharth Chauhan
        /// Date : 26-05-2016
        /// Description : To show and get data of Cir Revision.
        /// Task No. : 72518, 72519, 72520
        /// </summary>
        //Task No. : 72518, 72519 & 72520, 
        public List<CirRevision> GetCirRevision(long CirDataId)
        {
            return BLL.BLCirRevision.GetCirRevision(CirDataId);
        }

        public CIR.ComponentInspectionReport GetCirRevisionData(long CirDataId)
        {
            return BLL.BLCirRevision.GetCirRevisionData(CirDataId);
        }


        #endregion

        #region AdvanceSearch

        public List<Cir.Sync.Services.AdvanceSearch.Brand> GetBrandList()
        {
            return Cir.Sync.Services.AdvanceSearch.AdvanceSearch.GetBrandList();
        }
        public Cir.Sync.Services.AdvanceSearch.AdvanceSearchModel DoAdvanceSearch(Cir.Sync.Services.AdvanceSearch.AdvanceSearchModel advanceSearchModel)
        {
            return Cir.Sync.Services.AdvanceSearch.AdvanceSearch.DoAdvanceSearch(advanceSearchModel);
        }

        public Cir.Sync.Services.AdvanceSearch.AdvanceSearchModel LoadProfile(long ProfileId)
        {
            return Cir.Sync.Services.AdvanceSearch.AdvanceSearch.LoadProfile(ProfileId);
        }

        public Cir.Sync.Services.AdvanceSearch.AdvanceSearchModel DeleteProfile(long ProfileId)
        {
            return Cir.Sync.Services.AdvanceSearch.AdvanceSearch.DeleteProfile(ProfileId);
        }

        public Cir.Sync.Services.AdvanceSearch.AdvanceSearchModel SaveProfile(Cir.Sync.Services.AdvanceSearch.AdvanceSearchModel advanceSearchModel)
        {

            return Cir.Sync.Services.AdvanceSearch.AdvanceSearch.SaveProfile(advanceSearchModel);
        }

        //public Cir.Sync.Services.AdvanceSearch.AdvanceSearchModel GetBirAdvanceSearchData(Cir.Sync.Services.AdvanceSearch.AdvanceSearchModel advanceSearchModel)
        //{
        //    return Cir.Sync.Services.AdvanceSearch.AdvanceSearch.GetBirAdvanceSearchData(advanceSearchModel);
        //}
        #endregion

        #region Online Validation

        public bool ValidateTurbineNumber(string TurbineNumber)
        {
            return BLL.BLOnlineValidation.ValidateTurbineNumber(TurbineNumber);
        }

        public CIR.TurbineProperties ValidateGetTurbineData(string TurbineNumber)
        {
            return BLL.BLOnlineValidation.ValidateGetTurbineData(TurbineNumber);
        }

        public bool ValidateCIMCaseNumber(string CIMCaseNumber)
        {
            return BLL.BLOnlineValidation.ValidateCIMCaseNumber(CIMCaseNumber);
        }

        public bool ValidateServiceReportNumber(string ServiceReportNumber, string TurbineNumber)
        {
            return BLL.BLOnlineValidation.ValidateServiceReportNumber(ServiceReportNumber, TurbineNumber);
        }

        public bool ValidateServiceNotificationNumber(string ServiceNotificationNumber, string TurbineNumber)
        {
            return BLL.BLOnlineValidation.ValidateServiceNotificationNumber(ServiceNotificationNumber, TurbineNumber);
        }

        #endregion

        #region Unlock CIR Data

        public bool UnlockCirDataByCirID(long CirID)
        {
            return BLL.BLCIRData.UnlockCirDataByCirID(CirID);
        }

        public bool LockCirDataByCirID(long CirID, string modifiedby)
        {
            return BLL.BLCIRData.LockCirDataByCirID(CirID, modifiedby);
        }

        #endregion

        #region Get CIR State

        public List<Cir.Sync.Services.CIR.CirStateResponse> GetCirStateByCirIDs(List<Cir.Sync.Services.CIR.CirStateResponse> CirIDs)
        {
            return BLL.BLCIRData.GetCirStateByCirIDs(CirIDs);
        }

        #endregion

        #region Manufacturer
        public Manufacturer GetManufacturer(int type, int id)
        {
            return BLL.BLLManufacturer.GetManufacturer(type, id);
        }

        public ManufacturerList GetManufacturerList(int type)
        {
            return BLL.BLLManufacturer.GetManufacturerList(type);
        }

        public bool DeleteManufacturer(int type, int id)
        {
            return BLL.BLLManufacturer.DeleteManufacturer(type, id);
        }

        public bool SaveManufacturer(Manufacturer m)
        {
            return BLL.BLLManufacturer.SaveManufacturer(m);
        }
        #endregion

        #region Hotlist
        public DataContracts.Hotlist GetHotlist(int id)
        {
            return BLL.BLLHotList.GetHotlist(id);
        }

        public List<DataContracts.Hotlist> GetAllHotlist()
        {
            return BLL.BLLHotList.GetAllHotlist();
        }

        public bool SaveHotList(Hotlist hotlist)
        {
            return DAL.DAHotlist.SaveHotList(hotlist);
        }

        public bool DeleteHotList(int id)
        {
            return DAL.DAHotlist.DeleteHotList(id);
        }
        #endregion

        #region DefectCategorization
        public CirDefectCategorization UploadDefectCategotization(CirDefectCategorization dc)
        {
            return BLL.BLDefectCategorization.UploadDefectCategotization(dc);
        }
        #endregion

        #region Attachments
        public bool SaveAttachment(CirAttachments attachment)
        {
            return BLL.BLCirAttachments.SaveAttachment(attachment);
        }

        public List<CirAttachments> GetAttachments(long cirId)
        {
            return BLL.BLCirAttachments.GetAttachments(cirId).ToList();
        }

        public bool DeleteAttachment(long cirAttachmentId)
        {
            return BLL.BLCirAttachments.Delete(cirAttachmentId);
        }

        public CirAttachments GetAttachment(long cirAttachmentId)
        {
            return BLL.BLCirAttachments.Get(cirAttachmentId);
        }
        #endregion

        #region SQL Migration Logs
        /// <summary>
        /// This is used to step(s)\exception logging into sql server
        /// </summary>
        /// <returns></returns>
        public bool SqlToCosmosDBMigrationLog(MigrationStepLogging objMigrationLogging)
        {
            return BLL.BLSystemLog.MigrationLog(objMigrationLogging);
        }
        #endregion

        #region BIR Migration List
        /// <summary>
        /// This is used to step(s)\exception logging into sql server
        /// </summary>
        /// <returns></returns>
        public List<Bir> GetBirMigrationData()
        {
            return BLL.BirBLL.GetBirMigrationData();
        }
        #endregion

        #region GIR Migration List
        /// <summary>
        /// This is used to fetch GIR SQL Table Data
        /// </summary>
        /// <returns></returns>
        public List<Gir> GetGirMigrationData()
        {
            return BLL.GirBLL.GetGirMigrationData();
        }
        #endregion

        #region Save GIR data(s) into Azure Blob with cosmosDB
        /// <summary>
        /// Save GIR data(s) into Azure Blob with cosmosDB
        /// </summary>
        /// <param name="objGirDataDetails"></param>
        /// <param name="strGirDataDocumentId"></param>
        /// <returns></returns>
        public bool SaveGirDataDetailstoCosmosDb(GirDataDetails objGirDataDetails, string strGirDataDocumentId)
        {
           return BLL.GirBLL.SaveGirDataDetailstoCosmosDb(objGirDataDetails, strGirDataDocumentId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="GirDataID"></param>
        /// <param name="languageId"></param>
        /// <returns></returns>
        public GirFile GenerateNewGIRReport(long GirDataID, int languageId)
        {
            return BLL.BLGIRReport.GenerateNewGIRReport(GirDataID, languageId);
        }

        #endregion

        #region GBXIR Migration List
        /// <summary>
        /// This is used to fetch GBXIR SQL Table Data
        /// </summary>
        /// <returns></returns>
        public List<Gbx> GetGBXirMigrationData()
        {
            return BLL.GBXirBLL.GetGBXirMigrationData();
        }
        #endregion

        #region Save GBXIR data(s) into Azure Blob with cosmosDB
        /// <summary>
        /// Save GBXIR data(s) into Azure Blob with cosmosDB
        /// </summary>
        /// <param name="objGirDataDetails"></param>
        /// <param name="strGirDataDocumentId"></param>
        /// <returns></returns>
        public bool SaveGBXirDataDetailstoCosmosDb(GBXirDataDetails objGirDataDetails, string strGirDataDocumentId)
        {
            return BLL.GBXirBLL.SaveGBXirDataDetailstoCosmosDb(objGirDataDetails, strGirDataDocumentId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="GbxirDataID"></param>
        /// <param name="languageId"></param>
        /// <returns></returns>
        public GbxFile GenerateNewGBXIRReport(long GbxirDataID, int languageId)
        {
            return BLL.BLGBXReport.RenderGBXirReport(GbxirDataID, languageId);
        }

        #endregion


        #region Notification Mail 

        /// <summary>
        /// First Notification Mail
        /// </summary>
        /// <returns></returns>
        public List<FirstNotificationDetails> GetNotifications()
        {
            return BLL.BLMigrate.GetNotifications();
        }

        public bool SaveFirstNotificationDataDetailstoCosmosDb(FirstNotificationDetails objFN, string fnDataDocumentId)
        {
           return BLL.BLMigrate.SaveFirstNotificationDataDetailstoCosmosDb(objFN, fnDataDocumentId);

        }



        /// <summary>
        /// Second Notification Mail
        /// </summary>
        /// <returns></returns>
        public List<SecondNotificationDetails> GetSecondNotificationList()
        {
            return BLL.BLMigrate.GetSecondNotificationList();
        }

        public bool SaveSecondNotificationDataDetailstoCosmosDb(SecondNotificationDetails objSN, string fnDataDocumentId)
        {
           return BLL.BLMigrate.SaveSecondNotificationDataDetailstoCosmosDb(objSN, fnDataDocumentId);

        }


        /// <summary>
        /// Reject Notification Mail
        /// </summary>
        /// <returns></returns>
        public List<RejectNotificationDetails> GetRejectNotificationList()
        {
            return BLL.BLMigrate.GetRejectNotificationList();
        }

        public bool SaveRejectNotificationDataDetailstoCosmosDb(RejectNotificationDetails objRN, string fnDataDocumentId)
        {
           return BLL.BLMigrate.SaveRejectNotificationDataDetailstoCosmosDb(objRN, fnDataDocumentId);

        }


        #endregion

        public void SendMail(string cirName, long cirId, string CurrentUser,int type)
        {
            BLL.BLCirNotifications.SendMail(cirName, cirId, CurrentUser, type);
        }

        //public void SendCirNotificationMails(List<string> ToEMail, List<string> CCEMail, string subject, string body, string messageId, long cirId, string notificationType)
        //{
        //    BLL.BLCirNotifications.SendNotificationMails(ToEMail, CCEMail, subject, body, messageId, cirId, notificationType);
        //}

        public void SendCirNotificationMails(List<string> ToEmails, List<string> CCEmails, string json)
        {
            SendData data = JsonConvert.DeserializeObject<SendData>(json);
            BLL.BLCirNotifications.SendNotificationMails(ToEmails, CCEmails, data);
        }

        public void SendMails(string ToEmail, string CcEmail, string body, string subject)
        {
            BLL.BLCirNotifications.SendMail(ToEmail, CcEmail, body, subject);
        }


    }
}
