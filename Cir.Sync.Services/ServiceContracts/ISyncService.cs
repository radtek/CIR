using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Cir.Sync.Services.DataContracts;
using Cir.Sync.Services.CIR;
using Cir.Sync.Services.ErrorHandling;
using Newtonsoft.Json.Linq;
using Cir.Sync.Services.Models;
using Cir.Sync.Services.Notification;
using Cir.Sync.Services.DAL;

namespace Cir.Sync.Services.ServiceContracts
{
    /// <summary>
    /// Cir sync service layer
    /// </summary>
    [ServiceContract]
    public interface ISyncService
    {
        /// <summary>
        /// Get all master data.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CirMasterData> GetMasterData();

        /// <summary>
        /// Get all master data for CIR Reports.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<MasterKeyData> GetMasterDataForCIRReport();

        /// <summary>
        /// Get the pdf data of a cir
        /// </summary>
        /// <param name="cirId"></param>
        /// <returns></returns>
        [OperationContract]
        DataContracts.PDFModel GetCirPDFData(string cirId);

        /// <summary>
        /// Get master data by table name.
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        [OperationContract]
        List<CirMasterTable> GetMasterDataByName(string TableName, string UserId);

        /// <summary>
        /// Get CIM Case data.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [OperationContract]
        List<CirCIMCaseTable> GetCIMCaseData();

        /// <summary>
        /// Save CIR data to database
        /// </summary>
        /// <param name="strJsnCir"></param>
        /// <returns></returns>
        [OperationContract]
        CirResponse SaveCIRData(ComponentInspectionReport strJsnCir);

        /// <summary>
        /// Update PDF data to database
        /// </summary>
        /// <param name="CIRID"></param>
        /// <returns></returns>
        [OperationContract]
        CirResponse UpdatePDFData();

        /// <summary>
        /// Get CIR by ID
        /// </summary>
        /// <param name="Active">Active / Inactive parameter</param>
        /// <returns></returns>
        [OperationContract]
        ComponentInspectionReport GetCIRDatabyCIRID(Int64 CIRID);

        /// <summary>
        /// Cir quick search service
        /// </summary>
        /// <param name="SearchItem"></param>
        /// <returns></returns>
        [OperationContract]
        List<ComponentInspectionReport> CirQuickSearch(CirQuickSearch SearchItem);

        /// <summary>
        /// delete standard text
        /// </summary>
        /// <param name="Active">Active / Inactive parameter</param>
        /// <returns></returns>
        //[OperationContract]
        //StandardTexts GetStandardTextbyID(Int32 SID);

        #region Manage Standard Text

        [OperationContract]
        List<ComponentInspectionReportType> GetComponentInspectionReportType();

        [OperationContract]
        List<StandardTexts> GetStandardText(Int32 CommonInspectionReportID);

        [OperationContract]
        StandardTexts GetStandardTextbyID(Int64 SID);

        [OperationContract]
        StandardTexts SaveStandardTextData(StandardTexts strJsnStrTxt);


        #endregion

        #region BIR List
        [OperationContract]
        List<Bir> BirSearch(Bir bir);
        [OperationContract]
        bool DeleteBir(long BirID);
        [OperationContract]
        Bir BirFile(long BirID);

        [OperationContract]
        Bir GetBirDataByCirID(string CirIDs);

        [OperationContract]
        string GetRelatedCirsByCirId(string cirId);

        [OperationContract]
        Bir SaveBirData(Bir bir);

        [OperationContract]
        Dictionary<string, string> GetCirDataIdByCirID(string CirIDs);
        #endregion

        #region GIR List
        [OperationContract]
        List<Gir> GirSearch(Gir gir);
        [OperationContract]
        bool DeleteGir(long GirID);
        [OperationContract]
        Gir GirFile(long GirID);

        [OperationContract]
        Gir GetGirDataByCirID(string CirIDs);

        [OperationContract]
        Gir SaveGirData(Gir gir);
        #endregion

        #region GBXIR List
        [OperationContract]
        List<Gbx> GBXirSearch(Gbx gbx);
        [OperationContract]
        bool DeleteGBXir(long GBXirID);
        [OperationContract]
        Gbx GBXirFile(long GBXirID);

        [OperationContract]
        Gbx GetGBXirDataByCirID(string CirIDs);

        [OperationContract]
        Gbx SaveGBXirData(Gbx gbx);
        #endregion

        /// <summary>
        /// System log 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="detail"></param>
        /// <param name="type"></param>
        [OperationContract]
        bool Log(string message, string detail, LogType type);

        /// <summary>
        /// Get system logs
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [OperationContract]
        LogList GetLog(LogList log);

        #region Manage Feedback

        [OperationContract]
        List<FeedbackType> GetFeedbackType();

        [OperationContract]
        Feedback SaveFeedback(Feedback strJsnFeedback);

        [OperationContract]
        List<Feedback> GetAllFeedbacks();

        [OperationContract]
        bool DeleteFeedback(long id);
        #endregion

        #region Service Informations

        [OperationContract]
        List<Severity> GetSeverity();

        [OperationContract]
        List<ServiceInformations> GetServiceInformation(bool All);

        [OperationContract]
        ServiceInformations GetServiceInformationbyID(Int64 SID);

        [OperationContract]
        ServiceInformations SaveServiceInformation(ServiceInformations strJsnServiceInformations);


        #endregion

        #region Cir View
        /// <summary>
        /// Gets all view.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CirViewData> GetAllView();

        /// <summary>
        /// Gets all view only limited details for dropdown.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        CirViewData GetAllViewList(string initials = "");

        /// <summary>
        /// Gets selected view.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        CirViewData GetView(int ViewId);

        /// <summary>
        /// Creates the view.
        /// </summary>
        /// <param name="cirViewData">The cir view data.</param>
        /// <param name="createdBy">The created by.</param>
        /// <returns></returns>
        [OperationContract]
        int CreateView(CirViewData cirViewData);

        /// <summary>
        /// Deletes the view.
        /// </summary>
        /// <param name="ViewId">The view identifier.</param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteView(int ViewId);

        [OperationContract]
        CIRList GetCirList(CIRList cirList);

        [OperationContract]
        CirDataActionResponse CirProcess(CirDataDetail cirDataDetail);

        [OperationContract]
        bool SetApproved(long cirDataId, int State, int Progress, string modifiedBy, string comment);
        [OperationContract]
        CirDataActionResponse LockUnlockCir(CirDataDetail cirDataDetail);

        [OperationContract]
        CirDataDetail GetCirDataDetails(long CirDataId);

        [OperationContract]
        List<CirLogs> GetCIRLog(long CirDataId);

        [OperationContract]
        CirDataDetails GetCirDataDetail(long CirDataId);

        /// <summary>
        /// Creates CirCommentHistorys.
        /// </summary>
        /// <param name="cirViewData">CirCommentHistorys.</param>
        /// <param name="createdBy">The created by.</param>
        /// <returns></returns>        
        [OperationContract]
        CirCommentHistorys SaveCirCommentHistory(CirCommentHistorys CirCommentHistory);

        /// <summary>
        /// Gets CirCommentHistorys view.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CirCommentHistorys> GetCirCommentHistory(long CirDataId);

        /// <summary>
        /// Gets CirCommentHistorys view.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CirCommentHistorys> GetCirCommentHistoryByCirId(long CirId);
        #endregion

        [OperationContract]
        bool GenerateBIRReport(long BirDataID);

        [OperationContract]
        BirFile GenerateNewBIRReport(long BirDataID, int languageId);

        [OperationContract]
        bool GenerateGIRReport(long GirDataID);

        [OperationContract]
        bool GenerateGBXIRReport(long GBXirDataID);

        [OperationContract]
        Bir GetBirPDF(long BirDataID);

        [OperationContract]
        Gir GetGirPDF(long GirDataID);

        [OperationContract]
        Gbx GetGBXirPDF(long GBXirDataID);

        [OperationContract]
        bool SendFirstNotification(long CirDataID, long CirId);

        [OperationContract]
        bool IsValidServiceReportNumber(string serviceReportNumber, string turbineNumber);

        [OperationContract]
        bool IsValidNotificationNumber(string notificationNumber, string turbineNumber);

        [OperationContract]
        bool SaveCIRPdf(string uid, int state, string html = "", string name = "");

        [OperationContract]
        bool SaveCIRPdfGIR(string uid, int state, string html = "", string name = "");

        [OperationContract]
        bool SaveCIRPdfGBX(string uid, int state, string html = "", string name = "");

        [OperationContract]
        Bir GetCIRPdf(long CirDataId, long CirId = 0);

        [OperationContract]
        CirPDFResponse GetCIRPdfForSQL(long CirId);

        [OperationContract]
        Gir GetCIRPdfGIR(long CirDataId, long CirId = 0);

        [OperationContract]
        Gbx GetCIRPdfGBX(long CirDataId, long CirId = 0);

        [OperationContract]
        Bir GetCIRPdfZip(string CirDataIds);

        [OperationContract]
        Gir GetCIRPdfZipGIR(string CirDataIds);

        [OperationContract]
        Gbx GetCIRPdfZipGBX(string CirDataIds);

        [OperationContract]
        bool RenderCirReport(long CirID);

        [OperationContract]
        int GetBIRViewId();

        [OperationContract]
        int GetGIRViewId();

        [OperationContract]
        int GetGBXIRViewId();

        [OperationContract]
        bool ResendSecondMails();

        [OperationContract]
        List<CirDataDetail> GetMigrationCirList();
        [OperationContract]

        void SaveBirDataDetailstoCosmosDb(BirDataDetails oBirDetails, string birDataDocumentId);

        #region CirRevision
        /// <summary>
        /// Added By : Siddharth Chauhan
        /// Date : 26-05-2016
        /// Description : To show and get data of Cir Revision.
        /// Task No. : 72518, 72519, 72520
        /// </summary>
        //Task No. : 72518, 72519 & 72520, 
        [OperationContract]
        List<CirRevision> GetCirRevision(long CirDataId);

        [OperationContract]
        CIR.ComponentInspectionReport GetCirRevisionData(long CirDataId);
        #endregion

        #region AdvanceSearch
        /// <summary>
        /// Get all Brand List.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<Cir.Sync.Services.AdvanceSearch.Brand> GetBrandList();
        [OperationContract]
        Cir.Sync.Services.AdvanceSearch.AdvanceSearchModel DoAdvanceSearch(Cir.Sync.Services.AdvanceSearch.AdvanceSearchModel advanceSearchModel);

        [OperationContract]
        Cir.Sync.Services.AdvanceSearch.AdvanceSearchModel LoadProfile(long ProfileId);

        [OperationContract]
        Cir.Sync.Services.AdvanceSearch.AdvanceSearchModel DeleteProfile(long ProfileId);

        [OperationContract]
        Cir.Sync.Services.AdvanceSearch.AdvanceSearchModel SaveProfile(Cir.Sync.Services.AdvanceSearch.AdvanceSearchModel advanceSearchModel);

        //[OperationContract]
        //Cir.Sync.Services.AdvanceSearch.AdvanceSearchModel GetBirAdvanceSearchData(Cir.Sync.Services.AdvanceSearch.AdvanceSearchModel advanceSearchModel);

        #endregion

        #region Online Validation

        [OperationContract]
        bool ValidateTurbineNumber(string TurbineNumber);

        [OperationContract]
        CIR.TurbineProperties ValidateGetTurbineData(string TurbineNumber);

        [OperationContract]
        bool ValidateCIMCaseNumber(string CIMCaseNumber);

        [OperationContract]
        bool ValidateServiceReportNumber(string ServiceReportNumber, string TurbineNumber);

        [OperationContract]
        bool ValidateServiceNotificationNumber(string ServiceNotificationNumber, string TurbineNumber);

        #endregion

        #region Unlock CIR Data

        [OperationContract]
        bool UnlockCirDataByCirID(long CirID);


        [OperationContract]
        bool LockCirDataByCirID(long CirID, string modifiedby);

        #endregion

        #region Get CIR State

        [OperationContract]
        List<Cir.Sync.Services.CIR.CirStateResponse> GetCirStateByCirIDs(List<Cir.Sync.Services.CIR.CirStateResponse> CirIDs);

        #endregion

        #region Manufacturer
        [OperationContract]
        Manufacturer GetManufacturer(int type, int id);

        [OperationContract]
        ManufacturerList GetManufacturerList(int type);

        [OperationContract]
        bool DeleteManufacturer(int type, int id);

        [OperationContract]
        bool SaveManufacturer(Manufacturer m);
        #endregion

        #region Hotlist
        [OperationContract]
        DataContracts.Hotlist GetHotlist(int id);

        [OperationContract]
        List<DataContracts.Hotlist> GetAllHotlist();

        [OperationContract]
        bool SaveHotList(Hotlist hotlist);

        [OperationContract]
        bool DeleteHotList(int id);
        #endregion

        #region DefectCategorization
        [OperationContract]
        CirDefectCategorization UploadDefectCategotization(CirDefectCategorization dc);
        #endregion

        #region Attachments
        [OperationContract]
        bool SaveAttachment(CirAttachments attachment);
        [OperationContract]
        List<CirAttachments> GetAttachments(long cirId);
        [OperationContract]
        bool DeleteAttachment(long cirAttachmentId);
        [OperationContract]
        CirAttachments GetAttachment(long cirAttachmentId);

        #endregion

        #region SQL Migration Logs

        [OperationContract]
        bool SqlToCosmosDBMigrationLog(MigrationStepLogging objMigrationLogging);
        #endregion


        #region BIR Migration List

        [OperationContract]
        List<Bir> GetBirMigrationData();
        #endregion

        #region GIR Migration
        [OperationContract]
        List<Gir> GetGirMigrationData();
        [OperationContract]
        bool SaveGirDataDetailstoCosmosDb(GirDataDetails objGirDataDetails, string strGirDataDocumentId);
        [OperationContract]
        GirFile GenerateNewGIRReport(long GirDataID, int languageId);

        #endregion

        #region GBXIR Migration
        [OperationContract]
        List<Gbx> GetGBXirMigrationData();

        [OperationContract]
        bool SaveGBXirDataDetailstoCosmosDb(GBXirDataDetails objGirDataDetails, string strGirDataDocumentId);

        [OperationContract]
        GbxFile GenerateNewGBXIRReport(long GbxirDataID, int languageId);
        #endregion

        #region Notification Mail 

        /// <summary>
        /// First Notification Mail
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<FirstNotificationDetails> GetNotifications();

        /// <summary>
        /// Save Notification to CosmosDB
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        bool SaveFirstNotificationDataDetailstoCosmosDb(FirstNotificationDetails objFN, string fnDataDocumentId);


        /// <summary>
        /// Second Notification Mail
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<SecondNotificationDetails> GetSecondNotificationList();

        /// <summary>
        /// Save Notification to CosmosDB
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        bool SaveSecondNotificationDataDetailstoCosmosDb(SecondNotificationDetails objSN, string fnDataDocumentId);


        /// <summary>
        /// Second Notification Mail
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<RejectNotificationDetails> GetRejectNotificationList();

        /// <summary>
        /// Save Notification to CosmosDB
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        bool SaveRejectNotificationDataDetailstoCosmosDb(RejectNotificationDetails objRN, string fnDataDocumentId);


        /// <summary>
        /// Send mail
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        void SendMail(string cirName, long cirId, string CurrentUser, int type);
        /// <summary>
        /// Send Notification
        /// </summary>
        /// <returns></returns>
        //[OperationContract]
        //void SendCirNotificationMails(List<string> ToEMail, List<string> CCEMail, string subject, string body, string messageId, long cirId, string notificationType);

        [OperationContract]
        void SendMails(string ToEmail, string CcEmail, string body, string subject);

        [OperationContract]
        void SendCirNotificationMails(List<string> ToEmails, List<string> CCEmails, string json);

       
        #endregion


    }
}
