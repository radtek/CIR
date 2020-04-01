using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Http;

namespace Cir.Azure.MobileApp.Service.Utilities
{
    public class SyncServiceUtilities
    {
        string _ServiceUrl;
        CirSyncService.SyncServiceClient _ServiceClient;
        public string ServiceUrl { get { return _ServiceUrl; } }


        /*  System.ServiceModel.WSHttpBinding SyncServiceBinding = null;
          System.ServiceModel.EndpointAddress SyncServiceEndpoint = null;*/


        CirSyncService.SyncServiceClient ServiceClient
        {
            get
            {
                if (_ServiceClient == null)
                {
                    CirSyncService.SyncServiceClient.CacheSetting = CacheSetting.AlwaysOff;
                    _ServiceClient = new CirSyncService.SyncServiceClient("WSHttpBinding_ISyncService");
                    CirSyncService.SyncServiceClient.CacheSetting = CacheSetting.AlwaysOff;
                    /*
                    SyncServiceBinding = new System.ServiceModel.WSHttpBinding(SecurityMode.None);
                    SyncServiceBinding.SendTimeout = new TimeSpan(00, 05, 00);
                    SyncServiceEndpoint = new System.ServiceModel.EndpointAddress(ServiceUrl);
                    _ServiceClient = new CirSyncService.SyncServiceClient(SyncServiceBinding, SyncServiceEndpoint);*/
                }
                return _ServiceClient;
            }
        }

        public SyncServiceUtilities(ApiController apiController)
        {
            apiController.Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings().TryGetValue("Cir_Sync_Service_Url", out _ServiceUrl);
        }
        public SyncServiceUtilities(string Url)
        {
            _ServiceUrl = Url;
        }

        public List<Cir.Azure.MobileApp.Service.CirSyncService.CirMasterData> GetMasterData()
        {
            try
            {
                return ServiceClient.GetMasterData().ToList<Cir.Azure.MobileApp.Service.CirSyncService.CirMasterData>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Cir.Azure.MobileApp.Service.CirSyncService.CirMasterTable> GetMasterDataByTable(string TableName, string UserId)
        {
            try
            {
                return ServiceClient.GetMasterDataByName(TableName, UserId).ToList<Cir.Azure.MobileApp.Service.CirSyncService.CirMasterTable>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Cir.Azure.MobileApp.Service.CirSyncService.CirCIMCaseTable> GetCIMCaseData()
        {
            try
            {
                return ServiceClient.GetCIMCaseData().ToList<Cir.Azure.MobileApp.Service.CirSyncService.CirCIMCaseTable>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.CirResponse SaveCir(Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReport Cir)
        {
            try
            {
                return ServiceClient.SaveCIRData(Cir);
            }
            catch (Exception e)
            {
                // Log("SaveCIR " + e.Message, e.StackTrace, CirSyncService.LogType.Error);

                return new CirSyncService.CirResponse() { Status = false, StatusMessage = e.Message + "\n Detailed Error: " + e.StackTrace };
            }
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReport GetCir(Int64 CirId)
        {
            try
            {
                return ServiceClient.GetCIRDatabyCIRID(CirId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.CirResponse UpdatePDFData()
        {
            try
            {
                return ServiceClient.UpdatePDFData();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReport> CirQuickSearch(Cir.Azure.MobileApp.Service.CirSyncService.CirQuickSearch SearchItems)
        {
            try
            {
                return ServiceClient.CirQuickSearch(SearchItems).ToList<Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReport>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        #region Manage Standard Text

        public List<Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportType> GetComponentInspectionReportType()
        {
            try
            {
                return ServiceClient.GetComponentInspectionReportType().ToList<Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportType>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.StandardTexts GetStandardTextbyID(Int32 Id)
        {
            try
            {
                return ServiceClient.GetStandardTextbyID(Id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Cir.Azure.MobileApp.Service.CirSyncService.StandardTexts> GetStandardText(Int32 CommonInspectionReportID)
        {
            try
            {
                return ServiceClient.GetStandardText(CommonInspectionReportID).ToList<Cir.Azure.MobileApp.Service.CirSyncService.StandardTexts>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.StandardTexts SaveStandardTextData(Cir.Azure.MobileApp.Service.CirSyncService.StandardTexts lstStandardTexts)
        {
            try
            {
                return ServiceClient.SaveStandardTextData(lstStandardTexts);
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        #endregion Manage Standard Text


        public List<Cir.Azure.MobileApp.Service.CirSyncService.Bir> BirSearch(Cir.Azure.MobileApp.Service.CirSyncService.Bir bir)
        {
            try
            {
                return ServiceClient.BirSearch(bir).ToList<Cir.Azure.MobileApp.Service.CirSyncService.Bir>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Cir.Azure.MobileApp.Service.CirSyncService.Gir> GirSearch(Cir.Azure.MobileApp.Service.CirSyncService.Gir gir)
        {
            try
            {
                return ServiceClient.GirSearch(gir).ToList<Cir.Azure.MobileApp.Service.CirSyncService.Gir>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Cir.Azure.MobileApp.Service.CirSyncService.Gbx> GBXirSearch(Cir.Azure.MobileApp.Service.CirSyncService.Gbx gbx)
        {
            try
            {
                return ServiceClient.GBXirSearch(gbx).ToList<Cir.Azure.MobileApp.Service.CirSyncService.Gbx>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
     
        public bool DeleteBir(long BirID)
        {
            try
            {
                return ServiceClient.DeleteBir(BirID);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public bool DeleteGir(long GirID)
        {
            try
            {
                return ServiceClient.DeleteGir(GirID);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public bool DeleteGBXir(long GBXirID)
        {
            try
            {
                return ServiceClient.DeleteGBXir(GBXirID);
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public Cir.Azure.MobileApp.Service.CirSyncService.Bir BirFile(long BirID)
        {
            try
            {
                return ServiceClient.BirFile(BirID);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public Cir.Azure.MobileApp.Service.CirSyncService.Gir GirFile(long GirID)
        {
            try
            {
                return ServiceClient.GirFile(GirID);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public Cir.Azure.MobileApp.Service.CirSyncService.Gbx GBXirFile(long GbxirID)
        {
            try
            {
                return ServiceClient.GBXirFile(GbxirID);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public Cir.Azure.MobileApp.Service.CirSyncService.Bir GetBirDataByCirID(string CirIDs)
        {
            try
            {
                return ServiceClient.GetBirDataByCirID(CirIDs);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public Cir.Azure.MobileApp.Service.CirSyncService.Bir SaveBirData(Cir.Azure.MobileApp.Service.CirSyncService.Bir bir)
        {
            try
            {
                return ServiceClient.SaveBirData(bir);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Cir.Azure.MobileApp.Service.CirSyncService.Gir GetGirDataByCirID(string CirIDs)
        {
            try
            {
                return ServiceClient.GetGirDataByCirID(CirIDs);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public Cir.Azure.MobileApp.Service.CirSyncService.Gir SaveGirData(Cir.Azure.MobileApp.Service.CirSyncService.Gir gir)
        {
            try
            {
                return ServiceClient.SaveGirData(gir);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.Gbx GetGBXirDataByCirID(string CirIDs)
        {
            try
            {
                return ServiceClient.GetGBXirDataByCirID(CirIDs);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public Cir.Azure.MobileApp.Service.CirSyncService.Gbx SaveGBXirData(Cir.Azure.MobileApp.Service.CirSyncService.Gbx gbx)
        {
            try
            {
                return ServiceClient.SaveGBXirData(gbx);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Log(string message, string details, Cir.Azure.MobileApp.Service.CirSyncService.LogType type)
        {
            ServiceClient.Log(
                message: message,
                detail: details,
                type: type
                );
        }




        #region Cir View

        public List<Cir.Azure.MobileApp.Service.CirSyncService.CirViewData> GetAllView()
        {
            return ServiceClient.GetAllView().ToList<Cir.Azure.MobileApp.Service.CirSyncService.CirViewData>();
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.CirViewData GetAllViewList(string initials = "")
        {
            return ServiceClient.GetAllViewList(initials);
        }


        public Cir.Azure.MobileApp.Service.CirSyncService.CirViewData GetView(int ViewId)
        {
            return ServiceClient.GetView(ViewId);
        }


        public int CreateView(Cir.Azure.MobileApp.Service.CirSyncService.CirViewData cirViewData)
        {
            return ServiceClient.CreateView(cirViewData);
        }


        public bool DeleteView(int ViewId)
        {
            return ServiceClient.DeleteView(ViewId);
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.CIRList GetCirList(Cir.Azure.MobileApp.Service.CirSyncService.CIRList cirList)
        {
            return ServiceClient.GetCirList(cirList);
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.CirDataActionResponse CirProcess(Cir.Azure.MobileApp.Service.CirSyncService.CirDataDetail cirDataDetail)
        {
            return ServiceClient.CirProcess(cirDataDetail);
        }
        public bool SetApproved(long cirDataId, int State, int Progress, string modifiedBy, string comment)
        {
            return ServiceClient.SetApproved(cirDataId, State, Progress, modifiedBy, comment);
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.CirDataActionResponse LockUnlockCir(Cir.Azure.MobileApp.Service.CirSyncService.CirDataDetail cirDataDetail)
        {
            return ServiceClient.LockUnlockCir(cirDataDetail);
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.CirDataDetail GetCirDataDetailForView(long CirDataId)
        {
            return ServiceClient.GetCirDataDetails(CirDataId);
        }


        public int GetBIRViewId(string initials = "")
        {
            return ServiceClient.GetBIRViewId();
        }
        public int GetGIRViewId(string initials = "")
        {
            return ServiceClient.GetGIRViewId();
        }
        public int GetGBXIRViewId(string initials = "")
        {
            return ServiceClient.GetGBXIRViewId();
        }
        #endregion


        public List<Cir.Azure.MobileApp.Service.CirSyncService.CirLogs> GetCirLog(long CirDataId)
        {
            return ServiceClient.GetCIRLog(CirDataId).ToList<Cir.Azure.MobileApp.Service.CirSyncService.CirLogs>();
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.CirDataDetails GetCirDataDetails(long CirDataId)
        {
            return ServiceClient.GetCirDataDetail(CirDataId);
        }

        public List<Cir.Azure.MobileApp.Service.CirSyncService.CirCommentHistorys> GetCirCommentHistorys(long CirDataId)
        {
            return ServiceClient.GetCirCommentHistory(CirDataId).ToList<Cir.Azure.MobileApp.Service.CirSyncService.CirCommentHistorys>();
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.CirCommentHistorys SaveCirCommentHistorys(Cir.Azure.MobileApp.Service.CirSyncService.CirCommentHistorys lstCirCommentHistorys)
        {
            return ServiceClient.SaveCirCommentHistory(lstCirCommentHistorys);
        }
        public List<Cir.Azure.MobileApp.Service.CirSyncService.CirDataDetail> GetMigrationCirList()
        {
            return ServiceClient.GetMigrationCirList().ToList<Cir.Azure.MobileApp.Service.CirSyncService.CirDataDetail>();
        }

        public string GetRelatedCirsByCirId(string cirId)
        {
            return ServiceClient.GetRelatedCirsByCirId(cirId);
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.PDFModel GetCirPDFData(string cirId)
        {
            return ServiceClient.GetCirPDFData(cirId);
        }
        #region Feedback

        public List<Cir.Azure.MobileApp.Service.CirSyncService.FeedbackType> GetFeedbackType()
        {
            try
            {
                return ServiceClient.GetFeedbackType().ToList<Cir.Azure.MobileApp.Service.CirSyncService.FeedbackType>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.Feedback SaveFeedback(Cir.Azure.MobileApp.Service.CirSyncService.Feedback lstFeedback)
        {
            try
            {
                return ServiceClient.SaveFeedback(lstFeedback);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Cir.Azure.MobileApp.Service.CirSyncService.Feedback> GetAllFeedbacks()
        {
            try
            {
                return ServiceClient.GetAllFeedbacks().ToList<Cir.Azure.MobileApp.Service.CirSyncService.Feedback>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool DeleteFeedback(long id)
        {
            try
            {
                return ServiceClient.DeleteFeedback(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion Feedback

        #region Service Information

        public List<Cir.Azure.MobileApp.Service.CirSyncService.Severity> GetSeverity()
        {
            try
            {
                return ServiceClient.GetSeverity().ToList<Cir.Azure.MobileApp.Service.CirSyncService.Severity>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.ServiceInformations GetServiceInformationsbyID(Int64 Id)
        {
            try
            {
                return ServiceClient.GetServiceInformationbyID(Id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Cir.Azure.MobileApp.Service.CirSyncService.ServiceInformations> GetServiceInformations(bool all)
        {
            try
            {
                return ServiceClient.GetServiceInformation(all).ToList<Cir.Azure.MobileApp.Service.CirSyncService.ServiceInformations>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.ServiceInformations SaveServiceInformations(Cir.Azure.MobileApp.Service.CirSyncService.ServiceInformations lstServiceInformations)
        {
            try
            {
                return ServiceClient.SaveServiceInformation(lstServiceInformations);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.Bir GetBirPDF(long BirDataID)
        {
            try
            {
                return ServiceClient.GetBirPDF(BirDataID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.Gir GetGirPDF(long GirDataID)
        {
            try
            {
                return ServiceClient.GetGirPDF(GirDataID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.Gbx GetGBXirPDF(long GBXirDataID)
        {
            try
            {
                return ServiceClient.GetGBXirPDF(GBXirDataID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.Bir GetCirPDF(long CirDataID, long CirID = 0)
        {
            try
            {
                return ServiceClient.GetCIRPdf(CirDataID, CirID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.CirPDFResponse GetCIRPdfForSQL(long CirID = 0)
        {
            try
            {
                return ServiceClient.GetCIRPdfForSQL(CirID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.BirFile GenerateBIRReport(long BirId, int languageId)
        {
            try
            {
                return ServiceClient.GenerateNewBIRReport(BirId, languageId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.Gir GetCIRPdfGIR(long CirDataID, long CirID = 0)
        {
            try
            {
                return ServiceClient.GetCIRPdfGIR(CirDataID, CirID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Cir.Azure.MobileApp.Service.CirSyncService.Gbx GetCIRPdfGBXIR(long CirDataID, long CirID = 0)
        {
            try
            {
                return ServiceClient.GetCIRPdfGBX(CirDataID, CirID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Cir.Azure.MobileApp.Service.CirSyncService.Bir GetCIRPdfZip(string CirDataIDs)
        {
            try
            {
                return ServiceClient.GetCIRPdfZip(CirDataIDs);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Cir.Azure.MobileApp.Service.CirSyncService.Gir GetCIRPdfZipGIR(string CirDataIDs)
        {
            try
            {
                return ServiceClient.GetCIRPdfZipGIR(CirDataIDs);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.Gbx GetCIRPdfZipGBXIR(string CirDataIDs)
        {
            try
            {
                return ServiceClient.GetCIRPdfZipGBX(CirDataIDs);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion Service Information

        #region CirRevision
        /// <summary>
        /// Added By : Siddharth Chauhan
        /// Date : 26-05-2016
        /// Description : To show and get data of Cir Revision.
        /// Task No. : 72518, 72519, 72520
        /// </summary>
        //Task No. : 72518, 72519 & 72520, 
        public List<Cir.Azure.MobileApp.Service.CirSyncService.CirRevision> GetCirRevision(long CirDataId)
        {
            return ServiceClient.GetCirRevision(CirDataId).ToList<Cir.Azure.MobileApp.Service.CirSyncService.CirRevision>();
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReport GetCirRevisionData(long CirDataId)
        {
            return ServiceClient.GetCirRevisionData(CirDataId);
        }
        #endregion

        #region AdvanceSearch

        public Cir.Azure.MobileApp.Service.CirSyncService.AdvanceSearchModel DoAdvanceSearch(Cir.Azure.MobileApp.Service.CirSyncService.AdvanceSearchModel advanceSearchModel)
        {
            return ServiceClient.DoAdvanceSearch(advanceSearchModel);
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.AdvanceSearchModel LoadProfile(long ProfileId)
        {
            return ServiceClient.LoadProfile(ProfileId);
        }
        public List<Cir.Azure.MobileApp.Service.CirSyncService.Brand> GetBrandList()
        {
            return ServiceClient.GetBrandList().ToList <Cir.Azure.MobileApp.Service.CirSyncService.Brand> ();
        }
        public Cir.Azure.MobileApp.Service.CirSyncService.AdvanceSearchModel SaveProfile(Cir.Azure.MobileApp.Service.CirSyncService.AdvanceSearchModel advanceSearchModel)
        {

            return ServiceClient.SaveProfile(advanceSearchModel);
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.AdvanceSearchModel DeleteProfile(long ProfileId)
        {
            return ServiceClient.DeleteProfile(ProfileId);
        }

        #endregion

        #region Online Validation

        public bool ValidateTurbineNumber(string TurbineNumber)
        {
            return ServiceClient.ValidateTurbineNumber(TurbineNumber);
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.TurbineProperties ValidateGetTurbineData(string TurbineNumber)
        {
            return ServiceClient.ValidateGetTurbineData(TurbineNumber);
        }

        public bool ValidateCIMCaseNumber(string CIMCaseNumber)
        {
            return ServiceClient.ValidateCIMCaseNumber(CIMCaseNumber);
        }

        public bool ValidateServiceReportNumber(string ServiceReportNumber, string TurbineNumber)
        {
            return ServiceClient.ValidateServiceReportNumber(ServiceReportNumber, TurbineNumber);
        }

        public bool ValidateServiceNotificationNumber(string ServiceNotificationNumber, string TurbineNumber)
        {
            return ServiceClient.ValidateServiceNotificationNumber(ServiceNotificationNumber, TurbineNumber);
        }

        #endregion


        #region Lock / Unlock CirData

        public bool UnlockCirDataByCirID(long CirID)
        {
            return ServiceClient.UnlockCirDataByCirID(CirID);
        }

        public bool LockCirDataByCirID(long CirID, string ModifiedBy)
        {
            return ServiceClient.LockCirDataByCirID(CirID, ModifiedBy);
        }

        #endregion

        #region Get CIR State

        public Cir.Azure.MobileApp.Service.CirSyncService.CirStateResponse[] GetCirStateByCirIDs(Cir.Azure.MobileApp.Service.CirSyncService.CirStateResponse[] CirIDs)
        {
            return ServiceClient.GetCirStateByCirIDs(CirIDs);
        }

        #endregion

        #region Get CIR Sync Log

        public Cir.Azure.MobileApp.Service.CirSyncService.LogList GetCirSyncLog(Cir.Azure.MobileApp.Service.CirSyncService.LogList Log)
        {
            return ServiceClient.GetLog(Log);
        }

        #endregion

        #region Manufacturer
        public Cir.Azure.MobileApp.Service.CirSyncService.Manufacturer GetManufacturer(int type, int id)
        {
            return ServiceClient.GetManufacturer(type, id);
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.ManufacturerList GetManufacturerList(int type)
        {
            return ServiceClient.GetManufacturerList(type);
        }

        public bool DeleteManufacturer(int type, int id)
        {
            return ServiceClient.DeleteManufacturer(type, id);
        }

        public bool SaveManufacturer(Cir.Azure.MobileApp.Service.CirSyncService.Manufacturer m)
        {
            return ServiceClient.SaveManufacturer(m);
        }
        #endregion

        #region HotList

        public Cir.Azure.MobileApp.Service.CirSyncService.Hotlist GetHotlist(int id)
        {
            return ServiceClient.GetHotlist(id);
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.Hotlist[] GetAllHotlist()
        {
            return ServiceClient.GetAllHotlist();
        }

        public bool SaveHotList(Cir.Azure.MobileApp.Service.CirSyncService.Hotlist hotlist)
        {
            return ServiceClient.SaveHotList(hotlist);
        }
        public bool DeleteHotList(int id)
        {
            return ServiceClient.DeleteHotList(id);
        }
        #endregion

        #region CIRAttachments

        public bool SaveAttachment(Cir.Azure.MobileApp.Service.CirSyncService.CirAttachments attachment)
        {
            return ServiceClient.SaveAttachment(attachment);
        }

        public List<Cir.Azure.MobileApp.Service.CirSyncService.CirAttachments> GetAttachments(long cirId)
        {
            return ServiceClient.GetAttachments(cirId).ToList();
        }

        public bool DeleteAttachment(long cirAttachmentId)
        {
            return ServiceClient.DeleteAttachment(cirAttachmentId);
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.CirAttachments GetAttachment(long cirAttachmentId)
        {
            return ServiceClient.GetAttachment(cirAttachmentId);
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.CirDefectCategorization UploadDefectCategotization(Cir.Azure.MobileApp.Service.CirSyncService.CirDefectCategorization dc)
        {
            return ServiceClient.UploadDefectCategotization(dc);
        }

        #endregion

        public bool SaveSqlToCosmosDBMigrationLog(Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging objMigrationlog)
        {
            return ServiceClient.SqlToCosmosDBMigrationLog(objMigrationlog);
        }
        public List<Cir.Azure.MobileApp.Service.CirSyncService.Bir> GetBirMigrationData()
        {
            return ServiceClient.GetBirMigrationData().ToList<Cir.Azure.MobileApp.Service.CirSyncService.Bir>();
        }

        public void SaveBirDataDetailstoCosmosDb(Cir.Azure.MobileApp.Service.CirSyncService.BirDataDetails objbirdetails, string documentId)
        {
            ServiceClient.SaveBirDataDetailstoCosmosDb(objbirdetails, documentId);
        }
        public List<Cir.Azure.MobileApp.Service.CirSyncService.Gir> GetGirMigrationData()
        {
            return ServiceClient.GetGirMigrationData().ToList<Cir.Azure.MobileApp.Service.CirSyncService.Gir>();
        }

        public bool SaveGirDataDetailstoCosmosDb(Cir.Azure.MobileApp.Service.CirSyncService.GirDataDetails objGirDataDetails, string documentId)
        {
            return ServiceClient.SaveGirDataDetailstoCosmosDb(objGirDataDetails, documentId);
        }

        public List<Cir.Azure.MobileApp.Service.CirSyncService.Gbx> GetGBXirMigrationData()
        {
            return ServiceClient.GetGBXirMigrationData().ToList<Cir.Azure.MobileApp.Service.CirSyncService.Gbx>();
        }

        public bool SaveGBXirDataDetailstoCosmosDb(Cir.Azure.MobileApp.Service.CirSyncService.GBXirDataDetails objGbxDataDetails, string documentId)
        {
            return ServiceClient.SaveGBXirDataDetailstoCosmosDb(objGbxDataDetails, documentId);
        }

        #region Notification

        public List<Cir.Azure.MobileApp.Service.CirSyncService.FirstNotificationDetails> GetNotifications()
        {
            return ServiceClient.GetNotifications().ToList<Cir.Azure.MobileApp.Service.CirSyncService.FirstNotificationDetails>();
        }

        public bool SaveFirstNotificationDataDetailstoCosmosDb(Cir.Azure.MobileApp.Service.CirSyncService.FirstNotificationDetails objFirstNotificationDetails, string documentId)
        {
            return ServiceClient.SaveFirstNotificationDataDetailstoCosmosDb(objFirstNotificationDetails, documentId);
        }

        public List<Cir.Azure.MobileApp.Service.CirSyncService.SecondNotificationDetails> GetSecondNotificationList()
        {
            return ServiceClient.GetSecondNotificationList().ToList<Cir.Azure.MobileApp.Service.CirSyncService.SecondNotificationDetails>();
        }

        public bool SaveSecondNotificationDataDetailstoCosmosDb(Cir.Azure.MobileApp.Service.CirSyncService.SecondNotificationDetails objSecondNotificationDetails, string documentId)
        {
            return ServiceClient.SaveSecondNotificationDataDetailstoCosmosDb(objSecondNotificationDetails, documentId);
        }

        public List<Cir.Azure.MobileApp.Service.CirSyncService.RejectNotificationDetails> GetRejectNotificationList()
        {
            return ServiceClient.GetRejectNotificationList().ToList();
        }

        public bool SaveRejectNotificationDataDetailstoCosmosDb(Cir.Azure.MobileApp.Service.CirSyncService.RejectNotificationDetails objRejectNotificationDetails, string documentId)
        {
            return ServiceClient.SaveRejectNotificationDataDetailstoCosmosDb(objRejectNotificationDetails, documentId);
        }

        #endregion
    }
}