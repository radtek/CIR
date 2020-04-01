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
    public static class DACirDataDetail
    {

        public static DataContracts.CirDataDetails GetCirDataDetail(long CirDataId)
        {
            CirDataDetails lstCirDataDetail = null;
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                try
                {
                    List<Edmx.spGetCirDataDetail_Result> CirDataDetailItems = context.spGetCirDataDetail(CirDataId).ToList();

                    if (!ReferenceEquals(CirDataDetailItems, null))
                    {
                        foreach (Edmx.spGetCirDataDetail_Result e in CirDataDetailItems)
                        {
                            lstCirDataDetail = new DataContracts.CirDataDetails()
                            {
                                CirDataId = e.CirDataId,
                                CirId = e.CirId,
                                CIRstate =  e.CirState,
                                Filename = e.Filename,
                                ComponentType = e.ComponentType,
                                CIMCaseNumber = e.CIMCaseNumber,
                                ReportType = e.ReportType,
                                TurbineNumber = e.TurbineNumber,
                                TurbineType = e.TurbineType
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    throw ex;
                }

            }
            return lstCirDataDetail;
        }



    }
}