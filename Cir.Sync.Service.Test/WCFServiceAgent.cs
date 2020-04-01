using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cir.Sync.Services;
using System.ComponentModel;
using Cir.Sync.Services.DataContracts;
using Cir.Sync.Services.BLL;
using Cir.Sync.Services.DAL;
using WCFClient;
using Cir.Sync.Services.ServiceContracts;
using Microsoft.Practices.Unity;
using Cir.Sync.Services.CIR;

namespace WCFClient
{
    public class WCFServiceAgent
    {

        Cir.Sync.Services.ServiceContracts.ISyncService wcfService;

        public WCFServiceAgent()
        {
            this.wcfService = new Cir.Sync.Services.SyncService();
        }

        // constructor for unit test
        public WCFServiceAgent(bool isUnitTest)
        {
            //this.wcfService = new Cir.Sync.Services.SyncService();
            this.wcfService = UnityHelper.IoC.Resolve<Cir.Sync.Services.ServiceContracts.ISyncService>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cirDataId"></param>
        /// <param name="State"></param>
        /// <param name="Progress"></param>
        /// <param name="modifiedBy"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        public bool SetApproved(long cirDataId, int State, int Progress, string modifiedBy, string comment)
        {
            return this.wcfService.SetApproved(cirDataId, State, Progress, modifiedBy, comment);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cirDataDetail"></param>
        /// <returns></returns>
        public CirDataActionResponse  CirProcess(CirDataDetail cirDataDetail)
        {
            return this.wcfService.CirProcess(cirDataDetail);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CIRList"></param>
        /// <returns></returns>
        public CirResponse SaveCIRData(ComponentInspectionReport CIRList)
        {
            return this.wcfService.SaveCIRData(CIRList);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CimCaseNumber"></param>
        /// <returns></returns>
        public bool ValidateCIMCaseNumber(string  CimCaseNumber)
        {
            return this.wcfService.ValidateCIMCaseNumber(CimCaseNumber);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TurbineNumber"></param>
        /// <returns></returns>
        public bool ValidateTurbineNumber(string TurbineNumber)
        {
            return this.wcfService.ValidateTurbineNumber(TurbineNumber);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ServiceReportNumber"></param>
        /// <param name="TurbineNumber"></param>
        /// <returns></returns>
        public bool IsValidServiceReportNumber(string ServiceReportNumber,string TurbineNumber)
        {
            return this.wcfService.IsValidServiceReportNumber(ServiceReportNumber, TurbineNumber);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
       public List<CirMasterData> GetMasterData()
        {
            return this.wcfService.GetMasterData();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<CirMasterTable> GetMasterDataByName(string TableName, string UserId)
        {
            return this.wcfService.GetMasterDataByName(TableName, UserId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CirCIMCaseTable> GetCIMCaseData()
        {
            return this.wcfService.GetCIMCaseData();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CirViewData> GetAllView()
        {
            return this.wcfService.GetAllView();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CirDataId"></param>
        /// <returns></returns>
        public List<Cir.Sync.Services.DataContracts.CirLogs> GetCirLog(long CirDataId)
        {
            return this.wcfService.GetCIRLog(CirDataId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CirDataId"></param>
        /// <returns></returns>
        public List<CirCommentHistorys> GetCirCommentHistory(long CirDataId)
        {
            return this.wcfService.GetCirCommentHistory(CirDataId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cir.Sync.Services.DataContracts.Hotlist GetHotlist(int id)
        {
            return this.wcfService.GetHotlist(id);
        }
        public List<Cir.Sync.Services.AdvanceSearch.Brand> GetBrandList()
        {
            return this.wcfService.GetBrandList();
        }
    }
}