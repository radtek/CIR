using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Http;

namespace Cir.Azure.MobileApp.Utilities
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

        public List<Cir.Azure.MobileApp.CirSyncService.CirMasterData> GetMasterData()
        {
            try
            {
                return ServiceClient.GetMasterData().ToList<Cir.Azure.MobileApp.CirSyncService.CirMasterData>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Cir.Azure.MobileApp.CirSyncService.CirMasterTable> GetMasterDataByTable(string TableName, string UserId)
        {
            try
            {
                return ServiceClient.GetMasterDataByName(TableName, UserId).ToList<Cir.Azure.MobileApp.CirSyncService.CirMasterTable>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Cir.Azure.MobileApp.CirSyncService.CirCIMCaseTable> GetCIMCaseData()
        {
            try
            {
                return ServiceClient.GetCIMCaseData().ToList<Cir.Azure.MobileApp.CirSyncService.CirCIMCaseTable>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cir.Azure.MobileApp.CirSyncService.CirResponse SaveCir(Cir.Azure.MobileApp.CirSyncService.ComponentInspectionReport Cir)
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

        public Cir.Azure.MobileApp.CirSyncService.ComponentInspectionReport GetCir(Int64 CirId)
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

        public List<Cir.Azure.MobileApp.CirSyncService.ComponentInspectionReport> CirQuickSearch(Cir.Azure.MobileApp.CirSyncService.CirQuickSearch SearchItems)
        {
            try
            {
                return ServiceClient.CirQuickSearch(SearchItems).ToList<Cir.Azure.MobileApp.CirSyncService.ComponentInspectionReport>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        #region Manage Standard Text

        public List<Cir.Azure.MobileApp.CirSyncService.ComponentInspectionReportType> GetComponentInspectionReportType()
        {
            try
            {
                return ServiceClient.GetComponentInspectionReportType().ToList<Cir.Azure.MobileApp.CirSyncService.ComponentInspectionReportType>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cir.Azure.MobileApp.CirSyncService.StandardTexts GetStandardTextbyID(Int32 Id)
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

        public List<Cir.Azure.MobileApp.CirSyncService.StandardTexts> GetStandardText(Int32 CommonInspectionReportID)
        {
            try
            {
                return ServiceClient.GetStandardText(CommonInspectionReportID).ToList<Cir.Azure.MobileApp.CirSyncService.StandardTexts>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cir.Azure.MobileApp.CirSyncService.StandardTexts SaveStandardTextData(Cir.Azure.MobileApp.CirSyncService.StandardTexts lstStandardTexts)
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


        public List<Cir.Azure.MobileApp.CirSyncService.Bir> BirSearch(Cir.Azure.MobileApp.CirSyncService.Bir bir)
        {
            try
            {
                return ServiceClient.BirSearch(bir).ToList<Cir.Azure.MobileApp.CirSyncService.Bir>();
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
        public Cir.Azure.MobileApp.CirSyncService.Bir BirFile(long BirID)
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

        public Cir.Azure.MobileApp.CirSyncService.Bir GetBirDataByCirID(string CirIDs)
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
        public Cir.Azure.MobileApp.CirSyncService.Bir SaveBirData(Cir.Azure.MobileApp.CirSyncService.Bir bir)
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

        public void Log(string message, string details, Cir.Azure.MobileApp.CirSyncService.LogType type)
        {
            ServiceClient.Log(
                message: message,
                detail: details,
                type: type
                );
        }




        #region Cir View

        public List<Cir.Azure.MobileApp.CirSyncService.CirViewData> GetAllView()
        {
            return ServiceClient.GetAllView().ToList <Cir.Azure.MobileApp.CirSyncService.CirViewData>();
        }

        public Cir.Azure.MobileApp.CirSyncService.CirViewData GetAllViewList(string initials = "")
        {
            return ServiceClient.GetAllViewList(initials);
        }


        public Cir.Azure.MobileApp.CirSyncService.CirViewData GetView(int ViewId)
        {
            return ServiceClient.GetView(ViewId);
        }


        public int CreateView(Cir.Azure.MobileApp.CirSyncService.CirViewData cirViewData)
        {
            return ServiceClient.CreateView(cirViewData);
        }


        public bool DeleteView(int ViewId)
        {
            return ServiceClient.DeleteView(ViewId);
        }

        public Cir.Azure.MobileApp.CirSyncService.CIRList GetCirList(Cir.Azure.MobileApp.CirSyncService.CIRList cirList)
        {
            return ServiceClient.GetCirList(cirList);
        }
      
        public Cir.Azure.MobileApp.CirSyncService.CirDataActionResponse CirProcess(Cir.Azure.MobileApp.CirSyncService.CirDataDetail cirDataDetail)
        {
            return ServiceClient.CirProcess(cirDataDetail);
        }

        public Cir.Azure.MobileApp.CirSyncService.CirDataActionResponse LockUnlockCir(Cir.Azure.MobileApp.CirSyncService.CirDataDetail cirDataDetail)
        {
            return ServiceClient.LockUnlockCir(cirDataDetail);
        }

        public Cir.Azure.MobileApp.CirSyncService.CirDataDetail GetCirDataDetailForView(long CirDataId)
        {
            return ServiceClient.GetCirDataDetails(CirDataId);
        }

        #endregion


        public List<Cir.Azure.MobileApp.CirSyncService.CirLogs> GetCirLog(long CirDataId)
        {
            return ServiceClient.GetCIRLog(CirDataId).ToList<Cir.Azure.MobileApp.CirSyncService.CirLogs>();
        }

        public Cir.Azure.MobileApp.CirSyncService.CirDataDetails GetCirDataDetails(long CirDataId)
        {
            return ServiceClient.GetCirDataDetail(CirDataId);
        }

        public List<Cir.Azure.MobileApp.CirSyncService.CirCommentHistorys> GetCirCommentHistorys(long CirDataId)
        {
            return ServiceClient.GetCirCommentHistory(CirDataId).ToList<Cir.Azure.MobileApp.CirSyncService.CirCommentHistorys>();
        }

        public Cir.Azure.MobileApp.CirSyncService.CirCommentHistorys SaveCirCommentHistorys(Cir.Azure.MobileApp.CirSyncService.CirCommentHistorys lstCirCommentHistorys)
        {
            return ServiceClient.SaveCirCommentHistory(lstCirCommentHistorys);
        }

        #region Feedback

        public List<Cir.Azure.MobileApp.CirSyncService.FeedbackType> GetFeedbackType()
        {
            try
            {
                return ServiceClient.GetFeedbackType().ToList<Cir.Azure.MobileApp.CirSyncService.FeedbackType>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cir.Azure.MobileApp.CirSyncService.Feedback SaveFeedback(Cir.Azure.MobileApp.CirSyncService.Feedback lstFeedback)
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
        public List<Cir.Azure.MobileApp.CirSyncService.Feedback> GetAllFeedbacks()
        {
            try
            {
                return ServiceClient.GetAllFeedbacks().ToList<Cir.Azure.MobileApp.CirSyncService.Feedback>();
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

        public List<Cir.Azure.MobileApp.CirSyncService.Severity> GetSeverity()
        {
            try
            {
                return ServiceClient.GetSeverity().ToList<Cir.Azure.MobileApp.CirSyncService.Severity>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cir.Azure.MobileApp.CirSyncService.ServiceInformations GetServiceInformationsbyID(Int64 Id)
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

        public List<Cir.Azure.MobileApp.CirSyncService.ServiceInformations> GetServiceInformations(bool all)
        {
            try
            {
                return ServiceClient.GetServiceInformation(all).ToList<Cir.Azure.MobileApp.CirSyncService.ServiceInformations>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cir.Azure.MobileApp.CirSyncService.ServiceInformations SaveServiceInformations(Cir.Azure.MobileApp.CirSyncService.ServiceInformations lstServiceInformations)
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

        public Cir.Azure.MobileApp.CirSyncService.Bir GetBirPDF(long BirDataID)
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

        public Cir.Azure.MobileApp.CirSyncService.Bir GetCirPDF(long CirDataID, long CirID = 0)
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

        public Cir.Azure.MobileApp.CirSyncService.Bir GetCIRPdfZip(string CirDataIDs)
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
        #endregion Service Information

        #region CirRevision
        /// <summary>
        /// Added By : Siddharth Chauhan
        /// Date : 26-05-2016
        /// Description : To show and get data of Cir Revision.
        /// Task No. : 72518, 72519, 72520
        /// </summary>
        //Task No. : 72518, 72519 & 72520, 
        public List<Cir.Azure.MobileApp.CirSyncService.CirRevision> GetCirRevision(long CirDataId)
        {
            return ServiceClient.GetCirRevision(CirDataId).ToList<Cir.Azure.MobileApp.CirSyncService.CirRevision>();
        }

        public Cir.Azure.MobileApp.CirSyncService.ComponentInspectionReport GetCirRevisionData(long CirDataId)
        {
            return ServiceClient.GetCirRevisionData(CirDataId);
        }
        #endregion

        #region AdvanceSearch

        public Cir.Azure.MobileApp.CirSyncService.AdvanceSearchModel DoAdvanceSearch(Cir.Azure.MobileApp.CirSyncService.AdvanceSearchModel advanceSearchModel)
        {
            return ServiceClient.DoAdvanceSearch(advanceSearchModel);
        }

        public Cir.Azure.MobileApp.CirSyncService.AdvanceSearchModel LoadProfile(long ProfileId)
        {
            return ServiceClient.LoadProfile(ProfileId);
        }

        public Cir.Azure.MobileApp.CirSyncService.AdvanceSearchModel SaveProfile(Cir.Azure.MobileApp.CirSyncService.AdvanceSearchModel advanceSearchModel)
        {

            return ServiceClient.SaveProfile(advanceSearchModel);
        }

        public Cir.Azure.MobileApp.CirSyncService.AdvanceSearchModel DeleteProfile(long ProfileId)
        {
            return ServiceClient.DeleteProfile(ProfileId);
        }

        #endregion

        #region Online Validation

        public bool ValidateTurbineNumber(string TurbineNumber)
        {
            return ServiceClient.ValidateTurbineNumber(TurbineNumber);
        }

        public Cir.Azure.MobileApp.CirSyncService.TurbineProperties ValidateGetTurbineData(string TurbineNumber)
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

        public Cir.Azure.MobileApp.CirSyncService.CirStateResponse[] GetCirStateByCirIDs(Cir.Azure.MobileApp.CirSyncService.CirStateResponse[] CirIDs)
        {
            return ServiceClient.GetCirStateByCirIDs(CirIDs);
        }

        #endregion

        #region Get CIR Sync Log

        public Cir.Azure.MobileApp.CirSyncService.LogList GetCirSyncLog(Cir.Azure.MobileApp.CirSyncService.LogList Log)
        {
            return ServiceClient.GetLog(Log);
        }

        #endregion

        #region Manufacturer
        public Cir.Azure.MobileApp.CirSyncService.Manufacturer GetManufacturer(int type, int id)
        {
            return ServiceClient.GetManufacturer(type, id);
        }

        public Cir.Azure.MobileApp.CirSyncService.ManufacturerList GetManufacturerList(int type)
        {
            return ServiceClient.GetManufacturerList(type);
        }

         public bool DeleteManufacturer(int type, int id)
        {
            return ServiceClient.DeleteManufacturer(type, id);
        }

         public bool SaveManufacturer(Cir.Azure.MobileApp.CirSyncService.Manufacturer m)
        {
            return ServiceClient.SaveManufacturer(m);
        }
        #endregion

        #region HotList

         public Cir.Azure.MobileApp.CirSyncService.Hotlist GetHotlist(int id)
         {
             return ServiceClient.GetHotlist(id);
         }

         public Cir.Azure.MobileApp.CirSyncService.Hotlist[] GetAllHotlist()
         {
             return ServiceClient.GetAllHotlist();
         }

         public bool SaveHotList(Cir.Azure.MobileApp.CirSyncService.Hotlist hotlist)
         {
             return ServiceClient.SaveHotList(hotlist);
         }
         public bool DeleteHotList(int id)
         {
             return ServiceClient.DeleteHotList(id);
         }
        #endregion

         #region CIRAttachments

         public bool SaveAttachment(Cir.Azure.MobileApp.CirSyncService.CirAttachments attachment)
         {
             return ServiceClient.SaveAttachment(attachment);
         }

         public List<Cir.Azure.MobileApp.CirSyncService.CirAttachments> GetAttachments(long cirId)
         {
             return ServiceClient.GetAttachments(cirId).ToList();
         }

         public bool DeleteAttachment(long cirAttachmentId)
         {
             return ServiceClient.DeleteAttachment(cirAttachmentId);
         }

         public Cir.Azure.MobileApp.CirSyncService.CirAttachments GetAttachment(long cirAttachmentId)
         {
             return ServiceClient.GetAttachment(cirAttachmentId);
         }

         public Cir.Azure.MobileApp.CirSyncService.CirDefectCategorization UploadDefectCategotization(Cir.Azure.MobileApp.CirSyncService.CirDefectCategorization dc)
         {
             return ServiceClient.UploadDefectCategotization(dc);
         }

         #endregion
    }
}