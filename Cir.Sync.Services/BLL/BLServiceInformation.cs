using Cir.Sync.Services.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.BLL
{
    public static class BLServiceInformation
    {
        /// <summary>
        /// get Severity 
        /// </summary>
        /// <param name="CommonInspectionReportID"></param>
        /// <returns></returns>
        /// 
        public static List<Severity> GetSeverity()
        {
            return DAL.DAServiceInformations.GetSeverity();

        }

        /// <summary>
        /// Get Service Information
        /// </summary>
        /// <param name="SeverityID"></param>
        /// <returns></returns>
        public static List<ServiceInformations> GetServiceInformation(bool All)
        {
            return DAL.DAServiceInformations.GetServiceInformations(All);

        }

        /// <summary>
        /// Get Service Information by ID
        /// </summary>
        /// <param name="SID"></param>
        /// <returns></returns>
        public static ServiceInformations GetServiceInformationbyID(Int64 SID)
        {
            return DAL.DAServiceInformations.GetServiceInformationsbyID(SID);
        }

        /// <summary>
        /// save DAService Information
        /// </summary>
        /// <param name="ServiceInformationsData"></param>
        /// <returns></returns>
        /// 
        public static ServiceInformations SaveServiceInformation(ServiceInformations ServiceInformationsData)
        {

            return DAL.DAServiceInformations.SaveServiceInformations(ServiceInformationsData);
        }
        
    }
}