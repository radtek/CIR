using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using Cir.Data.Access.Services;
using Cir.Data.Access.Models;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using Cir.Data.Access.Models.Authorization;
using Cir.Data.Api.Authorization;
using Cir.Data.Api.DataManipulation;
using System.Threading.Tasks;
using Serilog;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.ApplicationInsights;
using static Cir.Data.Access.Enumerations.Enumeration;
using static Cir.Data.Access.Enumerations.NotificationEnumerations;
using Cir.Data.Access.Helpers;
using Cir.Data.Access.DataAccessDynamic;
using Cir.Data.Access.DataAccess;

namespace Cir.Data.Api.Controllers
{
    /// <summary>
    /// Cir migration data controller.
    /// </summary>
    ////[AuthorizeRoles]
    [MobileAppController]
    public class CirMigrationDataController : ApiController
    {
        private ICirSubmissionService _cirSubmissionService;
        private ICirBlobImageService _cirBlobStorageService;
        TelemetryClient _telemetryClient = new TelemetryClient();
        private readonly ICirNotification _cirNotification;
        private readonly ICirTemplateRepository _cirTemplateRepository;
        private readonly ICirSubmissionDataDynamicRepository _cirSubmissionDataDynamicRepository;
        private readonly ICirSyncLogRepository _cirSyncLogRepository;
        /// <summary>
        /// Constructor of cir submission data controller
        /// </summary>
        /// <param name="cirSubmissionService"></param>
        /// <param name="log"></param>
        public CirMigrationDataController(ICirSubmissionService cirSubmissionService, ILogger log, ICirNotification cirNotification, ICirSyncLogRepository cirSyncLogRepository, ICirSubmissionDataDynamicRepository cirSubmissionDataDynamicRepository)
        {
            _cirSubmissionService = cirSubmissionService;
            _cirNotification = cirNotification;
            _cirSyncLogRepository = cirSyncLogRepository;
            _cirSubmissionDataDynamicRepository = cirSubmissionDataDynamicRepository;
        }
        /// <summary>
        /// Not needed
        /// </summary>
        /// <param name="cirBlobStorageService"></param>
        /// <param name="log"></param>
        public CirMigrationDataController(  ICirBlobImageService cirBlobStorageService, ILogger log)
        {
            _cirBlobStorageService = cirBlobStorageService;
        }

        /// <summary>
        /// Insert Cir Report
        /// </summary>
        /// <param name="report">Report object in JSON format. Contains Schema, Data, Id (GUID) and Partition(provided by default).</param>
        /// <returns></returns>
        //[SwaggerOperation(Tags = new[] { "CirMigrationData - provides CRUD operations for Cir Report object on Azure CosmosDB." })]
        //[Route("api/CirMigrationData/SubmitForMigration")]
        [HttpPost]
        //[GzipCompression]
        public IHttpActionResult SubmitForMigration([FromBody]CirSubmissionData report)
        {
            try
            {
                return Ok(_cirSubmissionService.AddForMigration(report));
            }
            catch (Exception e)
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                UserInformation user1 = UserInformation.getstaticuser(authToken);
                _telemetryClient.TrackEvent("Unexpected error occured for CirMigrationData/SubmitForMigration for user " + user1.UserName + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// This method is used to upload SQL Imagedata into Azure BLOB
        /// </summary>
        /// <param name="lstImgData"></param>
        /// <returns></returns>
        //[Route("api/CirMigrationData/UploadSQLDataToBlob")]
        [HttpPost]
        public List<ImageDataModel> UploadSQLDataToBlob(List<ImageDataModel> lstImgData)
        {
            List<ImageDataModel> returnImageData = new List<ImageDataModel>();
            try
            {
                if (returnImageData == null)
                {
                    return returnImageData;
                }
                //var user = "chpka@vestas.com";// Request.Properties[AuthorizeRolesAttribute.GraphApiUserKey] as UserInformation;
                //var user = Request.Properties[AuthorizeRolesAttribute.GraphApiUserKey] as UserInformation;
                returnImageData = _cirSubmissionService.Add_Migration(lstImgData);
                return returnImageData;
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured for CirMigrationData/UploadSQLDataToBlob for user " + User + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return returnImageData;
            }
        }

        /// <summary>
        /// This method is used to upload SQL PDFdata into Azure BLOB
        /// </summary>
        /// <param name="lstPdfData"></param>
        /// <returns></returns>
        //[Route("api/CirMigrationData/UploadPDFDataToBlob")]
        [HttpPost]
        public PDFModel UploadPDFDataToBlob(PDFModel lstPdfData)
        {
            PDFModel retPdfData = new PDFModel();
            try
            {
                if (retPdfData == null)
                {
                    return retPdfData;
                }
                //var user = "chpka@vestas.com";// Request.Properties[AuthorizeRolesAttribute.GraphApiUserKey] as UserInformation;
                retPdfData = _cirSubmissionService.AddPDFMigration(lstPdfData);
                return retPdfData;
            }

            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured for CirMigrationData/UploadPDFDataToBlob for user " + User + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return retPdfData;
            }
        }

        /// <summary>
        /// This method is used to Generate pdf into Azure 
        /// </summary>
        /// <param name="cirData"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Byte[]> GeneratePDF(CirSubmissionData cirData)
        {
            Byte[] retVal = null;
            try
            {
                retVal = await _cirSubmissionService.GeneratePDF(cirData).ConfigureAwait(false);
                return retVal;
            }

            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured for CirMigrationData/GeneratePDF for user " + User + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return retVal;
            }
        }
        /// <summary>
        /// This method is used to Generate pdf into Azure 
        /// </summary>
        /// <param name="cirData"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult SendNotificationMail(CirSubmissionData reportToUpdate)
        {
             
            try
            {
                var componentInspectionReport = reportToUpdate.State == CirState.Draft ? _cirSyncLogRepository.Get(reportToUpdate.Id)
                        : _cirSubmissionDataDynamicRepository.Get(reportToUpdate.Id, reportToUpdate.CirCollectionName);

                CirMode cirMode = componentInspectionReport == null ? CirMode.New : CirMode.Edit;
               // GeneratePdfAsync(reportToUpdate, reportToUpdate.ModifiedBy, cirMode: cirMode, componentInspectionReport: componentInspectionReport).ConfigureAwait(false);
                GeneratePdfAsync(reportToUpdate, reportToUpdate.ModifiedBy, cirMode, componentInspectionReport: componentInspectionReport).ConfigureAwait(false);
                // retVal = await _cirSubmissionService.(cirData).ConfigureAwait(false);
                return Ok();
            }

            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured for CirMigrationData/GeneratePDF for user " + User + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
           
        }
        public async Task GeneratePdfAsync(CirSubmissionData cirSubmissionData, string userName, CirMode cirMode = CirMode.New, NotificationType type = NotificationType.FirstNotification, string comment = null, CirSubmissionData componentInspectionReport = null)
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
                               // _cirNotification.SendMail(cirSubmissionData, userName, cirMode);
                                cirMode = checkNotifications(cirSubmissionData, componentInspectionReport);
                                if (cirMode == CirMode.New || cirSubmissionData.State == CirState.Submitted)
                                {
                                    _cirNotification.SendNotificationMail(cirSubmissionData, NotificationType.FirstNotification);
                                }
                                if (cirSubmissionData.State == CirState.Approved)
                                {
                                    _cirNotification.SendNotificationMail(cirSubmissionData, NotificationType.FirstNotification);
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
    }
}
