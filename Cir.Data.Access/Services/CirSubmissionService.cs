using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Cir.Data.Access.DataAccess;
using Cir.Data.Access.Models;
using Cir.Data.Access.DataAccessDynamic;
using Cir.Data.Access.Models.Authorization;
using Cir.Data.Access.Services.Integration;
using System.Threading.Tasks;
using Cir.Data.Access.Helpers;
using static Cir.Data.Access.Enumerations.Enumeration;
using static Cir.Data.Access.Enumerations.NotificationEnumerations;
using Cir.Data.Access.CirSyncService;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using PDFModel = Cir.Data.Access.Models.PDFModel;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.ApplicationInsights;
using CirPDFResponse = Cir.Data.Access.Models.CirPDFResponse;

namespace Cir.Data.Access.Services
{
    internal class CirSubmissionService : ICirSubmissionService
    {
        public string TableName => "CirDataJson";
        private readonly ICirPDFStorageRepository _cirPdfStorageRepository;
        private readonly ICirImageStorageRepository _cirImageStorageRepository;

        private readonly ICirTemplateService _cirTemplateService;
        private readonly ICirTemplateRepository _cirTemplateRepository;
        private readonly ICirValidationService _cirValidation;
        private readonly ICirSubmissionDataDynamicRepository _cirSubmissionDataDynamicRepository;
        private readonly ICirSubmissionHistoricDataRepository _cirHistoryRepository;
        private readonly IInspecToolsIntegrationService _inspecToolsIntegrationService;
        private readonly ICirIdRepository _cirIdRepository;
        private readonly ICirLockService _cirLockService;
        private readonly ICirSyncLogRepository _cirSyncLogRepository;
        private readonly ICirIdGeneratorService _cirIdGeneratorService;
        private readonly ICirNotification _cirNotification;
        private readonly SyncServiceClient _serviceClient;

        public string _cirCommonnBrandCollectionName = ConfigurationManager.AppSettings["CirCommonBrandCollectionName"];
        private static string BladeInspectionTemplateBrandName => ConfigurationManager.AppSettings.Get("BladeInspectionTemplateBrandName");
        private static string BladeInspectionTemplateName => ConfigurationManager.AppSettings.Get("BladeInspectionTemplateName");
        TelemetryClient _telemetryClient = new TelemetryClient();
        public CirSubmissionService(
            ICirTemplateService cirTemplateService,
            ICirTemplateRepository cirTemplateRepository,
            ICirValidationService cirValidation,
            ICirSubmissionDataDynamicRepository cirSubmissionDataDynamicRepository,
            ICirSubmissionHistoricDataRepository cirHistoryRepository,
            IInspecToolsIntegrationService inspecToolsIntegrationService,
            ICirIdRepository cirIdRepository,
            ICirLockService cirLockService,
            ICirSyncLogRepository cirSyncLogRepository,
            ICirIdGeneratorService cirIdGeneratorService,
            ICirPDFStorageRepository cirPdfStorageRepository, ICirImageStorageRepository cirImageStorageRepository, ICirNotification cirNotification

        )
        {
            _cirTemplateService = cirTemplateService;
            _cirTemplateRepository = cirTemplateRepository;
            _cirValidation = cirValidation;
            _cirSubmissionDataDynamicRepository = cirSubmissionDataDynamicRepository;
            _cirHistoryRepository = cirHistoryRepository;
            _inspecToolsIntegrationService = inspecToolsIntegrationService;
            _cirIdRepository = cirIdRepository;
            _cirLockService = cirLockService;
            _cirSyncLogRepository = cirSyncLogRepository;
            _cirIdGeneratorService = cirIdGeneratorService;
            _cirPdfStorageRepository = cirPdfStorageRepository;
            _cirImageStorageRepository = cirImageStorageRepository;
            _cirNotification = cirNotification;
            _serviceClient = new SyncServiceClient("WSHttpBinding_ISyncService");


        }

        #region [SQL to BLOB image data migration]

        /// <summary>
        /// SQL to BLOB image data migration
        /// </summary>
        /// <param name="imgData"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public List<ImageDataModel> Add_Migration(List<ImageDataModel> imgData)
        {
            List<ImageDataModel> lstReturnModel = new List<ImageDataModel>();

            for (int i = 0; i < imgData.Count; i++)
            {
                ImageDataModel objModel = new ImageDataModel();
                objModel = _cirImageStorageRepository.Add(imgData[i]);
                objModel.BinaryData = string.Empty;
                lstReturnModel.Add(objModel);
            }
            return lstReturnModel;
        }

        #endregion [SQL to BLOB image data migration]


        #region [SQL to BLOB PDF data migration]

        /// <summary>
        /// SQL to BLOB PDF data migration
        /// </summary>
        /// <param name="lstPdfData"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public PDFModel AddPDFMigration(PDFModel lstPdfData)
        {

            lstPdfData = _cirPdfStorageRepository.AddPDF(lstPdfData);

            return lstPdfData;
        }

        #endregion [SQL to BLOB PDF data migration]

        public async Task<IList<object>> GetTableData(IList<CirSubmissionData> cirSubmissionData)
        {
            try
            {
                return cirSubmissionData.Where(r => r.State == CirState.Draft).ToList<object>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public CirSubmissionData Get(string id, string templateId)
        {
            var template = _cirTemplateRepository.Get(templateId);

            return _cirSubmissionDataDynamicRepository.Get(id, template.CirBrandCollectionName);
        }

        public CirSubmissionData GetFromCirSyncLog(string id)
        {
            try
            {
                return _cirSyncLogRepository.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CirSubmissionData GetByCirId(long cirId)
        {
            CirSubmissionData cir = new CirSubmissionData();
            cir = _cirSyncLogRepository.GetByCirId(cirId);
            if (cir == null || cir.State == CirState.Removed)
            {
                cir = _cirSubmissionDataDynamicRepository.GetByCirId(cirId, _cirCommonnBrandCollectionName);
            }
            //Added on 26-Sep-18 (add document in cirSyncLog at the time of edit)
            if (cir != null)
            {
                cir.State = CirState.Draft;
                cir.ModifiedOn = DateTime.UtcNow;
                cir.DeletedFromCache = "false";
                cir.SqlProcessStatus = CirSubmissionDataDynamicRepository.SqlNotTransferred;
                _cirSyncLogRepository.Upsert(cir);

            }
            var template = _cirTemplateRepository.Get(cir.CirTemplateId);
            cir.templateVersion = template.VersionNumber;
            cir.Schema = template.Schema;
            cir.DeletedFromCache = "false";
            return cir;
        }
        public IEnumerable<CirSubmissionData> GetAll(string templateId)
        {
            var template = _cirTemplateRepository.Get(templateId);
            return _cirSubmissionDataDynamicRepository.GetAll(template.CirBrandCollectionName).AsEnumerable();
        }

        /// <summary>
        /// Sync Request
        /// </summary>
        /// <param name="user"></param>
        /// <param name="reportsToSync"></param>
        /// <returns></returns>
        public SyncResponse SyncRequest(UserInformation user, IEnumerable<CirSubmissionData> reportsToSync)
        {
            var modifiedThreshhold = TimeSpan.FromMilliseconds(10);
            var reportsToDeleteInBrowser = new List<string>();
            var reportsToInsertInAzure = new List<CirSubmissionData>();
            var reportsToUpdateInAzure = new List<CirSubmissionData>();
            List<CirSubmissionData> cirsToInsrtUpdateInBrowser = new List<CirSubmissionData>();
            List<CirSubmissionData> cirFromMainCollection = new List<CirSubmissionData>();
            List<CirSubmissionData> logRelatedToUser = new List<CirSubmissionData>();
            List<CirSubmissionData> masterTableCirsByCirId = new List<CirSubmissionData>();
            List<CirSubmissionData> reportsToSyncList = new List<CirSubmissionData>();
            List<CirSubmissionData> cirInMasterRelatedtoUser = new List<CirSubmissionData>();

            //Listing User Cached CIRs,Draft CIRs, All Processed CIRs 
            reportsToSyncList = reportsToSync.Count() > 0 ? reportsToSync.ToList() : reportsToSyncList;
            logRelatedToUser = _cirSyncLogRepository.GetAllRelatedToUserForSync(user.DisplayName.ToLower()).ToList();
            cirsToInsrtUpdateInBrowser = logRelatedToUser.Where(r => reportsToSyncList.All(x => x.Id != r.Id)).ToList();

            if (reportsToSyncList.Count() == 0)
            {
                cirInMasterRelatedtoUser = _cirSubmissionDataDynamicRepository.GetAllRelatedToUser(user.DisplayName.ToLower(), _cirCommonnBrandCollectionName).Where(x => x.DeletedFromCache != "true" && x.SqlProcessStatus == "Transferred").ToList();
                cirsToInsrtUpdateInBrowser = cirsToInsrtUpdateInBrowser.Concat(cirInMasterRelatedtoUser.Where(p2 => cirsToInsrtUpdateInBrowser.All(p1 => p1.Id != p2.Id)).ToList()).ToList();
            }
            else
            {
                masterTableCirsByCirId = _cirSyncLogRepository.MainCollctionGetAllByIds(reportsToSyncList.Select(c => c.Id).ToList()).ToList();
            }

            foreach (var report in reportsToSyncList)
            {
                var reportInLog = logRelatedToUser.FirstOrDefault(x => x.Id == report.Id);
                var reportInMasterTable = masterTableCirsByCirId.FirstOrDefault(x => x.Id == report.Id);                
                if ((report.LockedBy == "" && report.State == CirState.Draft) || report.State == CirState.Removed || report.DeletedFromCache == "true")
                {
                    if (reportInLog != null && reportInLog.ModifiedOn.Ticks < report.ModifiedOn.Ticks + modifiedThreshhold.Ticks)
                    {
                        _cirLockService.UnlockCir(report, report.CirTemplateId);
                        _cirLockService.UnlockCIRfromSql(report.CirId);
                    }
                    reportsToDeleteInBrowser.Add(report.Id);
                }

                else
                {
                    if (reportInLog == null && reportInMasterTable != null)
                    {
                        if (report.State != CirState.Draft && report.SqlProcessStatus == "Transferred" && report.ModifiedOn < DateTime.UtcNow.AddDays(-30) && reportInMasterTable.Revision >= report.Revision)
                        {
                            reportsToDeleteInBrowser.Add(report.Id);
                        }
                        else if (reportInMasterTable.Revision > report.Revision)
                        {
                            cirsToInsrtUpdateInBrowser.Add(reportInMasterTable);
                        }
                        else
                        {
                            if (reportInMasterTable.ModifiedOn == report.ModifiedOn)
                            {
                                continue;
                            }
                            else if (reportInMasterTable.ModifiedOn.Ticks > report.ModifiedOn.Ticks + modifiedThreshhold.Ticks)
                            {
                                cirsToInsrtUpdateInBrowser.Add(reportInMasterTable);
                            }
                            else
                            {
                                reportsToUpdateInAzure.Add(report);
                            }
                        }
                    }
                    else if (reportInLog != null && reportInMasterTable != null)
                    {
                        if (reportInMasterTable.Revision > reportInLog.Revision)
                        {
                            if (reportInMasterTable.Revision > report.Revision)
                            {
                                cirsToInsrtUpdateInBrowser.Add(reportInMasterTable);
                            }
                            else
                            {
                                if (reportInMasterTable.ModifiedOn == report.ModifiedOn)
                                {
                                    continue;
                                }
                                else if (reportInMasterTable.ModifiedOn.Ticks > report.ModifiedOn.Ticks + modifiedThreshhold.Ticks)
                                {
                                    cirsToInsrtUpdateInBrowser.Add(reportInMasterTable);
                                }
                                else
                                {
                                    reportsToUpdateInAzure.Add(report);
                                }
                            }
                        }
                        else
                        {
                            if (reportInLog.ModifiedOn == report.ModifiedOn)
                            {
                                continue;
                            }
                            else if (reportInLog.ModifiedOn.Ticks > report.ModifiedOn.Ticks + modifiedThreshhold.Ticks)
                            {
                                cirsToInsrtUpdateInBrowser.Add(reportInLog);
                            }
                            else
                            {
                                reportsToUpdateInAzure.Add(report);
                            }
                        }
                    }
                    else if (reportInLog != null && reportInMasterTable == null)
                    {
                        if (reportInLog.ModifiedOn == report.ModifiedOn)
                        {
                            continue;
                        }
                        else if (reportInLog.ModifiedOn.Ticks > report.ModifiedOn.Ticks + modifiedThreshhold.Ticks)
                        {
                            cirsToInsrtUpdateInBrowser.Add(reportInLog);
                        }
                        else
                        {
                            reportsToUpdateInAzure.Add(report);
                        }
                    }
                    else
                    {
                        reportsToInsertInAzure.Add(report);
                    }
                }
            }
            return new SyncResponse
            {
                ResendCirs = reportsToUpdateInAzure.Concat(reportsToInsertInAzure).Select(x => x.Id),
                UpdateClientCirs = cirsToInsrtUpdateInBrowser,
                RemoveClientCirs = reportsToDeleteInBrowser
            };
        }

        /// <summary>
        /// Sync Update
        /// </summary>
        /// <param name="reportToUpdate"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public long SyncUpdate(CirSubmissionData reportToUpdate, string userName)
        {
            try
            {
                long cirId = 0;
                reportToUpdate.Schema = string.Empty;
                reportToUpdate = ValidateCir(reportToUpdate);
                if (reportToUpdate.SqlProcessStatus == CirSubmissionDataDynamicRepository.SqlNotTransferred)
                {
                    var template = _cirTemplateRepository.Get(reportToUpdate.CirTemplateId);
                    reportToUpdate.CirCollectionName = template.CirBrandCollectionName;
                    reportToUpdate.CirBrandName = template.CirBrand.Name;
                    reportToUpdate.CirTemplateName = template.Name;
                    var componentInspectionReport = reportToUpdate.State == CirState.Draft ? _cirSyncLogRepository.Get(reportToUpdate.Id)
                        : _cirSubmissionDataDynamicRepository.Get(reportToUpdate.Id, reportToUpdate.CirCollectionName);
                    CirMode cirMode = componentInspectionReport == null ? CirMode.New : CirMode.Edit;
                    reportToUpdate = AddOrUpdateCir(componentInspectionReport, reportToUpdate);
                    cirId = reportToUpdate.CirId;
                    PostToInspecTools(reportToUpdate, reportToUpdate.ModifiedBy);
                    if (cirId > 0)
                    {
                        if (_cirSubmissionDataDynamicRepository.CheckCirExistsInCirSyncLog(reportToUpdate.Id) && reportToUpdate.State != CirState.Draft &&
                            reportToUpdate.ImageProcessStatus == ImageProcessStatus.Synced)
                        {
                            _cirSubmissionDataDynamicRepository.DeleteFromCirSyncLog(reportToUpdate);
                        }

                        if (reportToUpdate != null && reportToUpdate.ImageProcessStatus == ImageProcessStatus.Synced &&
                                    (reportToUpdate.State == CirState.Submitted || reportToUpdate.State == CirState.Approved ||
                                    reportToUpdate.State == CirState.Rejected) &&
                                   reportToUpdate.MailStatus == CirMailStatus.NotSent.ToString())
                        {
                            GeneratePdfAsync(reportToUpdate, reportToUpdate.ModifiedBy, cirMode: cirMode, componentInspectionReport: componentInspectionReport).ConfigureAwait(false);
                        }
                    }
                }
                else
                {
                    if (!_cirSubmissionDataDynamicRepository.CheckCirExistsInCirSyncLog(reportToUpdate.Id) && !_cirSubmissionDataDynamicRepository.Exists(reportToUpdate.Id))
                    {
                        reportToUpdate.CirId = _cirIdGeneratorService.GetCirId(reportToUpdate.CirCollectionName).CirId;
                    }
                    reportToUpdate.Partition = CirSubmissionDataDynamicRepository.getPartition(reportToUpdate.CirId);
                    _cirSyncLogRepository.Upsert(reportToUpdate);
                    cirId = reportToUpdate.CirId;
                }
                return cirId;
            }

            catch (Exception e)
            {
                if (!_cirSubmissionDataDynamicRepository.CheckCirExistsInCirSyncLog(reportToUpdate.Id) && !_cirSubmissionDataDynamicRepository.Exists(reportToUpdate.Id))
                {
                    reportToUpdate.CirId = _cirIdGeneratorService.GetCirId(reportToUpdate.CirCollectionName).CirId;
                }
                reportToUpdate.Partition = CirSubmissionDataDynamicRepository.getPartition(reportToUpdate.CirId);
                reportToUpdate.SqlProcessStatus = "ErrorState# " + e.Message;
                _cirSyncLogRepository.Upsert(reportToUpdate);
                throw e;
            }

        }

        private static CirMode checkNotifications(CirSubmissionData reportToUpdate, CirSubmissionData componentInspectionReport)
        {
            var existingReportTypeId = componentInspectionReport == null ? "0" : componentInspectionReport.Data["rbReportType"] == null ? componentInspectionReport.Data["ddlReportType"]?.Value
                       : componentInspectionReport.Data["rbReportType"]?.Value;

            var newReportTypeId = reportToUpdate.Data["rbReportType"] == null ? reportToUpdate.Data["ddlReportType"]?.Value
                          : reportToUpdate.Data["rbReportType"]?.Value;

            var gearboxAux = Convert.ToInt32(reportToUpdate.Data["ddlAuxEquipment"]?.Value);
            var bladeAux = reportToUpdate.Data["ctbAuxEquipment"]?.Value == false ? 1 : 2;
            var generatorAux = Convert.ToInt32(reportToUpdate.Data["ddlGeneratorAuxEquipment"]?.Value);
            var transformerAux = Convert.ToInt32(reportToUpdate.Data["ddlTransformerAuxEquipment"]?.Value);

            var existingGearboxAux = componentInspectionReport == null ? 0 : Convert.ToInt32(componentInspectionReport.Data["ddlAuxEquipment"]?.Value);
            var existingBladeAux = componentInspectionReport == null ? 0 : componentInspectionReport.Data["ctbAuxEquipment"]?.Value == false ? 1 : 2;
            var existingGeneratorAux = componentInspectionReport == null ? 0 : Convert.ToInt32(componentInspectionReport.Data["ddlGeneratorAuxEquipment"]?.Value);
            var existingTransformerAux = componentInspectionReport == null ? 0 : Convert.ToInt32(componentInspectionReport.Data["ddlTransformerAuxEquipment"]?.Value);

            CirMode cirMode = componentInspectionReport == null ? CirMode.New : ((existingReportTypeId != "2" && newReportTypeId == "2")
                || (existingGearboxAux != 1 && gearboxAux == 1)
                 || (existingBladeAux != 1 && bladeAux == 1)
                  || (existingGeneratorAux != 1 && generatorAux == 1)
                  || (existingTransformerAux != 1 && transformerAux == 1) ? CirMode.New : CirMode.Edit);
            return cirMode;
        }

        private async Task GeneratePdfAsync(CirSubmissionData cirSubmissionData, string userName, CirMode cirMode = CirMode.New, NotificationType type = NotificationType.FirstNotification, string comment = null, CirSubmissionData componentInspectionReport = null)
        {
            try
            {
                var pdfbytes = await Task.Run(() => GeneratePDF(cirSubmissionData)).ConfigureAwait(false);
                if (pdfbytes.Length > 0)
                {
                    switch (type)
                    {
                        case NotificationType.FirstNotification:
                            {
                                _cirNotification.SendMail(cirSubmissionData, userName, cirMode);
                                cirMode = checkNotifications(cirSubmissionData, componentInspectionReport);
                                if (cirMode == CirMode.New)
                                {
                                    _cirNotification.SendNotificationMail(cirSubmissionData, NotificationType.FirstNotification);
                                }
                                if (cirSubmissionData.State == CirState.Approved)
                                {
                                    _cirNotification.SendNotificationMail(cirSubmissionData, NotificationType.SecondNotification);
                                }
                                cirSubmissionData.MailStatus = CirMailStatus.Sent.ToString();
                                cirSubmissionData.ModifiedOn = DateTime.UtcNow;
                                _cirSubmissionDataDynamicRepository.UpdateCir(cirSubmissionData, cirSubmissionData.CirCollectionName);

                            }
                            break;
                        case NotificationType.SecondNotification:
                            {
                                _cirNotification.SendNotificationMail(cirSubmissionData, NotificationType.SecondNotification);
                            }
                            break;
                        case NotificationType.RejectNotification:
                            {
                                _cirNotification.SendNotificationMail(cirSubmissionData, NotificationType.RejectNotification, userName, comment);
                            }
                            break;
                        case NotificationType.SBUNotification:
                            {
                                _cirNotification.SendNotificationMail(cirSubmissionData, NotificationType.SBUNotification, userName, comment);
                            }
                            break;
                    }
                }
            }

            catch (Exception ex)
            {
                _telemetryClient.TrackEvent("Unexpected error occured for GeneratePdfAsync  Exception Message: " + ex.Message);
                _telemetryClient.TrackException(ex);
            }
        }
        private CirSubmissionData AddOrUpdateCir(CirSubmissionData componentInspectionReport, CirSubmissionData reportToUpdate)
        {
            string comment = reportToUpdate.State == CirState.Approved ? CirState.Approved.ToString() : CirState.Submitted.ToString();
            if (componentInspectionReport == null)
            {

                //check if it should be added or updated to master table
                if (reportToUpdate.State != CirState.Draft && reportToUpdate.ImageProcessStatus == ImageProcessStatus.Synced)
                {
                    reportToUpdate.RevisionHistory = reportToUpdate.RevisionHistory == null ?
                   reportToUpdate.RevisionHistory = new List<RevisionHistory>() : reportToUpdate.RevisionHistory;
                    reportToUpdate.RevisionHistory.Add(new RevisionHistory() { editedBy = reportToUpdate.ModifiedBy, Comments = comment, editedOn = DateTime.UtcNow });
                    if (reportToUpdate.CirId == 0)
                    {
                        reportToUpdate.CirId = _cirIdGeneratorService.GetCirId(reportToUpdate.CirCollectionName).CirId;
                    }
                    reportToUpdate.Schema = string.Empty;
                    reportToUpdate.Partition = CirSubmissionDataDynamicRepository.getPartition(reportToUpdate.CirId);
                    _cirSubmissionDataDynamicRepository.Add(reportToUpdate, reportToUpdate.CirCollectionName);
                    _cirLockService.UnlockCir(reportToUpdate, reportToUpdate.CirTemplateId);

                }
                else
                {
                    if (reportToUpdate.CirId == 0) //If CIR is creatinf first time
                    {
                        //new draft or during image sync
                        reportToUpdate.LockedBy = reportToUpdate.ModifiedBy;
                        reportToUpdate.CirId = _cirIdGeneratorService.GetCirId(reportToUpdate.CirCollectionName).CirId;
                        reportToUpdate.Schema = string.Empty;
                        //Assign Partition Key to CIR
                        reportToUpdate.Partition = CirSubmissionDataDynamicRepository.getPartition(reportToUpdate.CirId);
                        _cirSyncLogRepository.Upsert(reportToUpdate);
                    }
                }
            }
            else
            {
                reportToUpdate.CirId = componentInspectionReport.CirId;
                if (reportToUpdate.CirId > 0 && reportToUpdate.Partition == null)
                    reportToUpdate.Partition = CirSubmissionDataDynamicRepository.getPartition(reportToUpdate.CirId);
                reportToUpdate.Schema = string.Empty;
                if (reportToUpdate.State != CirState.Draft &&
                    reportToUpdate.ImageProcessStatus == ImageProcessStatus.Synced)
                {
                    if (reportToUpdate.RevisionHistory == null)
                    {
                        reportToUpdate.RevisionHistory = new List<RevisionHistory>();
                        reportToUpdate.RevisionHistory.AddRange(AddRevisonHistory(reportToUpdate.CirId));
                    }
                    reportToUpdate.RevisionHistory.Add(new RevisionHistory() { editedBy = reportToUpdate.ModifiedBy, Comments = comment, editedOn = DateTime.UtcNow });
                    _cirSubmissionDataDynamicRepository.Update(reportToUpdate, reportToUpdate.CirCollectionName);
                    _cirLockService.UnlockCir(reportToUpdate, reportToUpdate.CirTemplateId);
                }
                else
                {
                    _cirSyncLogRepository.Upsert(reportToUpdate);
                    if (reportToUpdate.State == CirState.Draft && reportToUpdate.LockedBy == "")
                    {
                        _cirLockService.UnlockCIRfromSql(reportToUpdate.CirId);
                    }
                }
            }
            return reportToUpdate;
        }

        private List<RevisionHistory> AddRevisonHistory(long CirId)
        {
            List<RevisionHistory> lstRevHistory = new List<RevisionHistory>();
            var rev = _serviceClient.GetCirCommentHistoryByCirId(CirId).ToList();
            foreach (var item in rev)
            {
                RevisionHistory revHistory = new RevisionHistory();
                revHistory.editedBy = item.Initials;
                revHistory.Comments = item.Comment;
                revHistory.editedOn = item.Date;
                lstRevHistory.Add(revHistory);
            }
            return lstRevHistory;

        }

        public CirSubmissionData Add(CirSubmissionData report)
        {
            report = ValidateCir(report);
            if (report.SqlProcessStatus == CirSubmissionDataDynamicRepository.SqlNotTransferred)
            {
                var template = _cirTemplateRepository.Get(report.CirTemplateId);
                report.CirCollectionName = template.CirBrandCollectionName;
                report.CirBrandName = template.CirBrand.Name;
                report.CirTemplateName = template.Name;

                _cirSubmissionDataDynamicRepository.Add(report, template.CirBrandCollectionName);
            }

            return report;
        }
        /// <summary>
        /// Add for migration from SQL to Cosmos
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        public CirSubmissionData AddForMigration(CirSubmissionData report)
        {
            var template = _cirTemplateRepository.Get(report.CirTemplateId);
            report.CirCollectionName = template.CirBrandCollectionName;
            report.CirBrandName = template.CirBrand.Name;
            report.CirTemplateName = template.Name;

            _cirSubmissionDataDynamicRepository.AddForMigration(report, template.CirBrandCollectionName);

            return report;
        }

        public CirSubmissionData Update(CirSubmissionData report, string userName)
        {
            report = ValidateCir(report);
            if (report.SqlProcessStatus == CirSubmissionDataDynamicRepository.SqlNotTransferred)
            {
                _cirSubmissionDataDynamicRepository.Update(report, report.CirCollectionName);
                PostToInspecTools(report, userName);
            }

            return report;
        }

        public CirSubmissionData UpdateSyncLog(CirSubmissionData report, string userName)
        {
            report = ValidateCir(report);
            if (report.SqlProcessStatus == CirSubmissionDataDynamicRepository.SqlNotTransferred)
            {
                _cirSyncLogRepository.Upsert(report);
            }

            return report;
        }

        public CirSubmissionData UpdateSyncLogNoValidate(CirSubmissionData report)
        {
            try
            {
                _cirSyncLogRepository.Upsert(report);
                return report;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetSynced(string reportId, string templateId)
        {
            var cir = GetFromCirSyncLog(reportId);

            _cirSubmissionDataDynamicRepository.Update(cir, cir.CirCollectionName);
        }

        public void SubmitFromApprove(long cirId, string currentUser, string comment)
        {
            var cir = GetFromMasterByCirId(cirId);
            if (cir.State == CirState.Approved)
            {
                if (cir.RevisionHistory != null)
                    cir.RevisionHistory.Add(new RevisionHistory() { editedBy = currentUser, Comments = comment, editedOn = DateTime.UtcNow });
                ChangeCirStatus(cir, currentUser, CirState.Submitted);
                GeneratePdfAsync(cir, currentUser, type: NotificationType.SBUNotification, comment: comment).ConfigureAwait(false);
            }
            else
            {
                throw new InvalidOperationException("Submit operation is not allowed.");
            }
        }

        public void Submit(long cirId, string currentUser)
        {
            var cir = GetFromMasterByCirId(cirId);

            cir.LockedBy = string.Empty;

            UpdateCirStatus(cir, currentUser, CirState.Submitted);

            _cirLockService.UnlockCir(cir, cir.CirTemplateId);
        }

        public void Approve(long cirId, string currentUser, string comment)
        {
            var cir = GetFromMasterByCirId(cirId);

            cir.LockedBy = string.Empty;
            if (cir.RevisionHistory != null)
                cir.RevisionHistory.Add(new RevisionHistory() { editedBy = currentUser, Comments = comment, editedOn = DateTime.UtcNow });
            ChangeCirStatus(cir, currentUser, CirState.Approved);
            _cirLockService.UnlockCir(cir, cir.CirTemplateId);
            GeneratePdfAsync(cir, currentUser, type: NotificationType.SecondNotification).ConfigureAwait(false);
        }

        public CirPDFResponse GetCirPdf(long cirId, string currentUser)
        {
            CirPDFResponse response;
            var cir = GetCirByCirId(cirId);
            if (cir != null)
            {
                if (cir.RevisionHistory == null || (cir.RevisionHistory != null && cir.RevisionHistory.Count == 0))
                {
                    cir.RevisionHistory = new List<RevisionHistory>();
                    cir.RevisionHistory.AddRange(AddRevisonHistory(cir.CirId));
                    _cirSubmissionDataDynamicRepository.Update(cir, cir.CirCollectionName);
                }
                byte[] pdfBytes = GeneratePDF(cir).Result;
                var CIMCaseNumber = cir.Data["ddlCimCaseNumber"] == null ? cir.Data["txtCimCaseNumber"]?.Value.ToString()
                                       : cir.Data["ddlCimCaseNumber"]?.Value.ToString();

                response = new CirPDFResponse();
                response.DownloadUrl = Convert.ToBase64String(pdfBytes);
                response.FileName = CirNotification.GetCirName(cir.Data["txtSiteName"]?.Value.ToString(),
                                 cir.CirTemplateName, cir.Data["txtTurbineNumber"]?.Value.ToString(), CIMCaseNumber);

            }
            else
            {
                Cir.Data.Access.CirSyncService.CirPDFResponse pdfResponse = _serviceClient.GetCIRPdfForSQL(cirId);
                if (pdfResponse != null && pdfResponse.FileName != null && pdfResponse.DownloadUrl != null)
                {
                    response = new CirPDFResponse() { FileName = pdfResponse.FileName.Replace(@"\", "_").Replace("/", "_").Replace(".xml", ".pdf"), DownloadUrl = pdfResponse.DownloadUrl };
                }
                else
                {
                    response = null;
                }
            }

            if (!response.FileName.Contains(".pdf"))
            {
                response.FileName = response.FileName + ".pdf";
            }
            return response;
        }

        public CirPDFResponse GetCirPdfZip(string cirIds, string currentUser)
        {
            string[] CirDataIdArray = cirIds.Split(',');
            MemoryStream outputMemStream = new MemoryStream();
            ZipConstants.DefaultCodePage = System.Text.Encoding.Default.CodePage;
            using (ZipOutputStream zipstream = new ZipOutputStream(outputMemStream))
            {
                foreach (string Id in CirDataIdArray)
                {
                    long cirId = 0;
                    long.TryParse(Id, out cirId);
                    if (cirId > 0)
                    {
                        var cir = GetCirByCirId(cirId);
                        if (cir != null)
                        {
                            byte[] pdfBytes;
                            var CIMCaseNumber = cir.Data["ddlCimCaseNumber"] == null ? cir.Data["txtCimCaseNumber"]?.Value.ToString()
                                   : cir.Data["ddlCimCaseNumber"]?.Value.ToString();
                            ZipEntry fileEntry = new ZipEntry(CirNotification.GetCirName(cir.Data["txtSiteName"]?.Value.ToString(),
                                 cir.CirTemplateName, cir.Data["txtTurbineNumber"]?.Value.ToString(), CIMCaseNumber) + ".pdf");
                            //fileEntry.IsUnicodeText = true;

                            pdfBytes = GeneratePDF(cir).Result;
                            if (pdfBytes.Length == 0)
                            {
                                pdfBytes = _serviceClient.GetCIRPdf(0, cir.CirId).File != null ? _serviceClient.GetCIRPdf(0, cir.CirId).File.FileBytes : new byte[0];
                                if (pdfBytes.Length == 0)
                                {
                                    zipstream.PutNextEntry(fileEntry);
                                    zipstream.SetComment("Data Not Found");
                                }
                            }
                            else
                            {
                                zipstream.PutNextEntry(fileEntry);
                                zipstream.Write(pdfBytes, 0, pdfBytes.Length);
                                zipstream.CloseEntry();
                            }
                        }
                        else
                        {
                            Cir.Data.Access.CirSyncService.CirPDFResponse pdfResponse = _serviceClient.GetCIRPdfForSQL(cirId);
                            if (pdfResponse != null && pdfResponse.FileName != null && pdfResponse.DownloadUrl != null)
                            {
                                if (pdfResponse.FileName.Contains("xml"))
                                    pdfResponse.FileName = pdfResponse.FileName.Replace(@"\", "_").Replace("/", "_").Replace(".xml", ".pdf");
                                else if (pdfResponse.FileName.Contains(".pdf"))
                                    pdfResponse.FileName = pdfResponse.FileName.Replace(@"\", "_").Replace("/", "_");
                                else
                                    pdfResponse.FileName = pdfResponse.FileName.Replace(@"\", "_").Replace("/", "_") + ".pdf";

                                ZipEntry fileEntry = new ZipEntry(pdfResponse.FileName);
                                byte[] pdfBytes = Convert.FromBase64String(pdfResponse.DownloadUrl);
                                if (pdfBytes.Length == 0)
                                {
                                    zipstream.PutNextEntry(fileEntry);
                                    zipstream.SetComment("Data Not Found");
                                }
                                else
                                {
                                    zipstream.PutNextEntry(fileEntry);
                                    zipstream.Write(pdfBytes, 0, pdfBytes.Length);
                                    zipstream.CloseEntry();
                                }
                            }
                        }
                    }
                }
                zipstream.IsStreamOwner = false;
                zipstream.Finish();
                zipstream.Close();

                outputMemStream.Position = 0;
                // GetBuffer returns a raw buffer raw and so you need to account for the true length yourself.
                byte[] byteArrayOut = outputMemStream.ToArray();
                string zipName = "CIR.zip";
                CirPDFResponse response = new CirPDFResponse();
                response.DownloadUrl = Convert.ToBase64String(byteArrayOut);
                response.FileName = zipName;
                return response;
            }
        }

        public void Reject(long cirId, string currentUser, string comment)
        {
            var cir = GetFromMasterByCirId(cirId);

            cir.LockedBy = string.Empty;
            if (cir.RevisionHistory != null)
                cir.RevisionHistory.Add(new RevisionHistory() { editedBy = currentUser, Comments = comment, editedOn = DateTime.Now });

            ChangeCirStatus(cir, currentUser, CirState.Rejected);
            _cirLockService.UnlockCir(cir, cir.CirTemplateId);
            GeneratePdfAsync(cir, currentUser, type: NotificationType.RejectNotification, comment: comment).ConfigureAwait(false);

        }

        public void Delete(long cirId, string currentUser, string OriginalcirId)
        {
            //Get CIR from ComponentInspectionReport Collection
            var cir = GetFromMasterByCirId(cirId);

            //Get CIR from CirSyncLog Collection
            var draftCir = _cirSyncLogRepository.GetByCirId(cirId);
            if (draftCir != null)
            {
                _cirSyncLogRepository.Delete(draftCir);
            }
            if (cir != null)
            {
                cir.LockedBy = string.Empty;
                cir.ModifiedOn = DateTime.UtcNow;
                cir.StatusChangedBy = currentUser;
                cir.Schema = string.Empty;
                if (OriginalcirId.ToString().IndexOf('.') < 0)
                {
                    cir.State = CirState.Removed;
                    cir.DeletedFromCache = "false";
                }
                else
                {
                    cir.DeletedFromCache = "false";
                }
                _cirSubmissionDataDynamicRepository.UpdateState(cir, cir.CirCollectionName);
            }
            //Unlock from SQL 
            _cirLockService.UnlockCIRfromSql(cir.CirId);
        }


        public void Delete(string reportId, string templateId)
        {
            var template = _cirTemplateRepository.Get(templateId);

            _cirSubmissionDataDynamicRepository.Delete(reportId, template.CirBrandCollectionName);
        }

        public CirSubmissionData GetFromMasterByCirId(long cirId)
        {
            var cirIdModel = _cirIdRepository.GetByCirId(cirId);

            return cirIdModel != null
                ? _cirSubmissionDataDynamicRepository.GetByCirId(cirIdModel.CirId, _cirCommonnBrandCollectionName)
                : null;
        }
        public CirSubmissionData GetCirByCirId(long cirId)
        {
            return _cirSubmissionDataDynamicRepository.GetByCirId(cirId, _cirCommonnBrandCollectionName);
        }
        public IEnumerable<CirRevisionDetails> GetRevisionHistory(long turbineNumber, string cirGUID)
        {
            return _cirHistoryRepository.GetCirRevisionItems(turbineNumber, cirGUID).AsEnumerable();
        }

        public CirRevisionDetails GetHistoryCir(string cirId)
        {
            return _cirHistoryRepository.GetCirRevision(cirId);
        }

        public async Task<IList<CirRevisionDetails>> GetRevHistByTurbineNo(long turbineNumber)
        {
            return await _cirHistoryRepository.GetAllCirsRevisionItems(turbineNumber);
        }

        public CirSubmissionData CreateEmptyBladeInspection(string userName)
        {
            var template = _cirTemplateRepository.GetHighestRevisionByBrandCollectionName(BladeInspectionTemplateBrandName);

            long cirId = _cirIdGeneratorService.GetCirId(BladeInspectionTemplateBrandName).CirId;

            var cir = new CirSubmissionData
            {
                CirCollectionName = BladeInspectionTemplateBrandName,
                Schema = template.Schema,
                CirTemplateId = template.Id,
                State = CirState.Draft,
                CirBrandName = template.CirBrand.Name,
                CirTemplateName = template.Name,
                CreatedOn = DateTime.Now,
                CreatedBy = userName,
                ModifiedOn = DateTime.Now,
                ModifiedBy = userName,
                CirId = cirId,
                Partition = CirSubmissionDataDynamicRepository.getPartition(cirId),
                ImageProcessStatus = ImageProcessStatus.Synced
            };
            _cirSubmissionDataDynamicRepository.Add(cir, BladeInspectionTemplateBrandName);
            _cirSyncLogRepository.Upsert(cir);
            return _cirSubmissionDataDynamicRepository.GetByCirId(cir.CirId, BladeInspectionTemplateBrandName);
        }

        private CirSubmissionData ValidateCir(CirSubmissionData report)
        {
            if (report.State != CirState.Draft)
            {
                var errorsList = _cirValidation.ValidateData(report);

                if (errorsList.Any())
                {
                    //report.State = CirState.Error;
                    report.SqlProcessStatus = "ErrorState# " + string.Join(",", errorsList.ToArray());
                    report.Errors = errorsList;
                    report.ModifiedOn = DateTime.UtcNow;
                }
                else if (report.SqlProcessStatus.Contains("Error:"))
                {
                    //report.State = CirState.Error;
                    report.SqlProcessStatus = (report.SqlProcessStatus.Contains("ErrorState#")?"":"ErrorState# ") + report.SqlProcessStatus;
                    report.Errors = errorsList;
                    report.ModifiedOn = DateTime.UtcNow;
                }else {
                    report.SqlProcessStatus = CirSubmissionDataDynamicRepository.SqlNotTransferred;
                    report.Errors = new List<string>();
                    report.ModifiedOn = DateTime.UtcNow;
                }
            }

            return report;

        }

        private void UpdateCirStatus(CirSubmissionData cir, string currentUser, CirState cirState)
        {
            if (cir != null)
            {
                cir.State = cirState;
                cir.ModifiedOn = DateTime.UtcNow;
                cir.StatusChangedBy = currentUser;

                _cirSubmissionDataDynamicRepository.Update(cir, cir.CirCollectionName);

                cir.Schema = string.Empty;

                _cirSyncLogRepository.Upsert(cir);
            }
        }

        private void ChangeSyncLogCirStatus(CirSubmissionData cir, string currentUser, CirState cirState)
        {
            if (cir != null)
            {
                cir.State = cirState;
                cir.ModifiedOn = DateTime.UtcNow;
                cir.StatusChangedBy = currentUser;
                cir.Schema = string.Empty;
                _cirSyncLogRepository.UpsertState(cir);
            }
        }

        private void ChangeCirStatus(CirSubmissionData cir, string currentUser, CirState cirState)
        {
            if (cir != null)
            {
                cir.State = cirState;
                cir.ModifiedOn = DateTime.UtcNow;
                cir.StatusChangedBy = currentUser;

                _cirSubmissionDataDynamicRepository.UpdateState(cir, cir.CirCollectionName);

                cir.Schema = string.Empty;

                // _cirSyncLogRepository.UpsertState(cir);
            }
        }
        private void RemoveCIRFromGreenSection(CirSubmissionData cir, string currentUser)
        {
            if (cir != null)
            {
                cir.ModifiedOn = DateTime.UtcNow;
                cir.StatusChangedBy = currentUser;

                _cirSubmissionDataDynamicRepository.UpdateState(cir, cir.CirCollectionName);

                cir.Schema = string.Empty;

                _cirSyncLogRepository.UpsertState(cir);
            }
        }

        private void PostToInspecTools(CirSubmissionData cir, string userName)
        {
            if (cir.CirTemplateName == BladeInspectionTemplateName &&
                !cir.IsSentToInspecTool &&
                cir.CirBrandName.Contains(_cirTemplateService.WindAmsBrandPostfix) &&
                (cir.State == CirState.PendingForBa ||
                 cir.State == CirState.Submitted ||
                 cir.State == CirState.Approved))
            {
                _inspecToolsIntegrationService.PostCir(cir, userName);

                cir.IsSentToInspecTool = true;

                _cirSubmissionDataDynamicRepository.Update(cir, cir.CirCollectionName);
            }
        }
        public async Task<byte[]> GeneratePDF(CirSubmissionData cirData)
        {
            byte[] pdfBytes = null;
            try
            {
                long turbineNumber = cirData.Data["txtTurbineNumber"] == null ? 0 : Convert.ToInt32(cirData.Data["txtTurbineNumber"]?.Value);
                pdfBytes = _cirPdfStorageRepository.GetPDF(turbineNumber, cirData.Id, cirData.Revision, cirData.CirId);

                if (pdfBytes.Length == 0)
                {
                    pdfBytes = await _cirPdfStorageRepository.GeneratePDF(cirData).ConfigureAwait(false);
                }
            }

            catch (Exception ex)
            {
                _telemetryClient.TrackEvent("Unexpected error occured for GeneratePDF  Exception Message: " + ex.Message);
                _telemetryClient.TrackException(ex);
            }

            return pdfBytes;
        }
    }
}