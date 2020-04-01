using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cir.Sync.Services;
using Cir.Sync.Services.Edmx;

using Cir.Sync.Services.ErrorHandling;
using Cir.Sync.Services.DataContracts;
using System.Data.Objects;


namespace Cir.Sync.Services.DAL
{
    /// <summary>
    /// Data access for Standard text
    /// </summary>
    public static class DAServiceInformations
    {
        public static List<DataContracts.Severity> GetSeverity()
        {
            List<DataContracts.Severity> lstSeverity = null;

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                List<Edmx.Severity> lstEdSeverity = (from s in context.Severity select s).ToList();

                if (!ReferenceEquals(lstEdSeverity, null))
                {
                    lstSeverity = new List<DataContracts.Severity>();
                    foreach (Edmx.Severity oSeverity in lstEdSeverity)
                    {
                        lstSeverity.Add(new DataContracts.Severity() { id = oSeverity.SeverityId, Name = oSeverity.Name });
                    }
                }
            }

            return lstSeverity;
        }

        public static List<DataContracts.ServiceInformations> GetServiceInformations(bool All)
        {
            List<ServiceInformations> lstServiceInformations = new List<ServiceInformations>();
            try
            {
                CIM_CIREntities context = new CIM_CIREntities();
                IFormatProvider culture = new System.Globalization.CultureInfo("da-DK", true);
                DateTime d = new DateTime();
                DateTime dt = new DateTime();
                DateTime curdate = DateTime.Now;
                var ServiceInformationsCol = context.CirServiceInformation.Where(si => si.Deleted == false).ToList();
                if (All == false)
                {
                    var ServiceInformationsItems = from e in ServiceInformationsCol
                                                   where DateTime.TryParse(e.StrFromDate, culture, System.Globalization.DateTimeStyles.AssumeLocal, out d) && d < curdate && DateTime.TryParse(e.StrToDate, culture, System.Globalization.DateTimeStyles.AssumeLocal, out dt)
                                                   select new ServiceInformations
                                                   {
                                                       Id = e.Id,
                                                       Message = e.Message,
                                                       SeverityId = e.SeverityId,
                                                       SeverityName = e.Severity.Name,
                                                       StrFromDate =  e.StrToDate,
                                                       IsExpired = DateTime.Parse(e.StrToDate, culture, System.Globalization.DateTimeStyles.AssumeLocal) < curdate 

                                                   };
                    lstServiceInformations = ServiceInformationsItems.ToList();
                }
                else
                {
                    var ServiceInformationsItems = from e in ServiceInformationsCol
                                                   select new ServiceInformations
                                                   {
                                                       Id = e.Id,
                                                       Message = e.Message,
                                                       SeverityId = e.SeverityId,
                                                       SeverityName = e.Severity.Name,
                                                       StrFromDate = e.StrFromDate,
                                                       StrToDate = e.StrToDate

                                                   };
                    lstServiceInformations = ServiceInformationsItems.ToList();
                }

            }
            catch (Exception oException)
            {

                string exstr = (oException != null) ? oException.Message + "\n Details : " + oException.StackTrace : "";
                string innerstr = (oException.InnerException != null) ? oException.InnerException.Message + "\n Details : " + oException.InnerException.StackTrace : "";

                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", exstr + "\n  Inner Exception : " + innerstr, LogType.Error, "");
                return lstServiceInformations;
            }
            return lstServiceInformations;
            

        }
        
 
        public static DataContracts.ServiceInformations GetServiceInformationsbyID(Int64 SID)
        {
            ServiceInformations lstServiceInformations = null;
            try
            {
                using (CIM_CIREntities context = new CIM_CIREntities())
                {
                    List<Edmx.CirServiceInformation> lstEdServiceInformations = (from s in context.CirServiceInformation
                                                                                 where s.Id == SID
                                                                                 select s).ToList();

                    if (!ReferenceEquals(lstEdServiceInformations, null))
                    {
                        foreach (Edmx.CirServiceInformation oServiceInformation in lstEdServiceInformations)
                        {
                            lstServiceInformations = new DataContracts.ServiceInformations() { Id = oServiceInformation.Id, Message = oServiceInformation.Message, SeverityId = oServiceInformation.SeverityId, StrFromDate = oServiceInformation.StrFromDate, StrToDate = oServiceInformation.StrToDate };
                        }
                    }
                }
            }
            catch (Exception oException)
            {

                string exstr = (oException != null) ? oException.Message + "\n Details : " + oException.StackTrace : "";
                string innerstr = (oException.InnerException != null) ? oException.InnerException.Message + "\n Details : " + oException.InnerException.StackTrace : "";

                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", exstr + "\n  Inner Exception : " + innerstr, LogType.Error, "");
                return lstServiceInformations;
            }

            return lstServiceInformations;

        }

        /// <summary>
        /// Save and update for Service Informations
        /// </summary>
        /// <param name="ServiceInformations">Object of Service Informations</param>
        /// <returns></returns>
        public static DataContracts.ServiceInformations SaveServiceInformations(DataContracts.ServiceInformations ServiceInformationsData)
        {

            try
            {
                using (CIM_CIREntities context = new CIM_CIREntities())
                {
                    Edmx.CirServiceInformation objServiceInformations = (from s in context.CirServiceInformation
                                                                         where s.Id == ServiceInformationsData.Id                                                                         
                                                                         select s).FirstOrDefault();

                    if (!ReferenceEquals(objServiceInformations, null)) // Updating existing
                    {
                        if (!ReferenceEquals(ServiceInformationsData.Deleted, null) && !ServiceInformationsData.Deleted)
                        {
                            objServiceInformations.Message = ServiceInformationsData.Message;
                            objServiceInformations.SeverityId = ServiceInformationsData.SeverityId;
                            objServiceInformations.Modified = DateTime.Now;
                            objServiceInformations.ModifiedBy = ServiceInformationsData.ModifiedBy;
                            objServiceInformations.Deleted = ServiceInformationsData.Deleted;
                            objServiceInformations.StrFromDate = ServiceInformationsData.StrFromDate;
                            objServiceInformations.StrToDate = ServiceInformationsData.StrToDate;
                            
                        }
                        else
                        {
                            objServiceInformations.Modified = DateTime.Now;
                            objServiceInformations.ModifiedBy = ServiceInformationsData.ModifiedBy;
                            objServiceInformations.Deleted = true;
                        }
                    }
                    else // Adding new
                    {
                        objServiceInformations = new Edmx.CirServiceInformation();
                        objServiceInformations.Id = ServiceInformationsData.Id;
                        objServiceInformations.Message = ServiceInformationsData.Message;
                        objServiceInformations.SeverityId = ServiceInformationsData.SeverityId;
                        objServiceInformations.CreatedBy = ServiceInformationsData.CreatedBy;
                        objServiceInformations.Created = DateTime.Now;
                        objServiceInformations.Deleted = ServiceInformationsData.Deleted;
                        objServiceInformations.StrFromDate = ServiceInformationsData.StrFromDate;
                        objServiceInformations.StrToDate = ServiceInformationsData.StrToDate;

                        context.CirServiceInformation.Add(objServiceInformations);
                    }

                    context.SaveChanges();

                    if (ServiceInformationsData.Id == 0)
                        ServiceInformationsData.Id = objServiceInformations.Id;
                }
            }
            catch (Exception oException)
            {

                string exstr = (oException != null) ? oException.Message + "\n Details : " + oException.StackTrace : "";
                string innerstr = (oException.InnerException != null) ? oException.InnerException.Message + "\n Details : " + oException.InnerException.StackTrace : "";

                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", exstr + "\n  Inner Exception : " + innerstr, LogType.Error, "");
                return ServiceInformationsData;
            }

            return ServiceInformationsData;
        }



    }
}