using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cir.Sync.Services;
using Cir.Sync.Services.Edmx;

using Cir.Sync.Services.ErrorHandling;
using Cir.Sync.Services.DataContracts;
using System.Data.Objects;
using System.Data;
using System.Data.SqlClient;

namespace Cir.Sync.Services.DAL
{
    /// <summary>
    /// Data access for Standard text
    /// </summary>
    public static class DACirRevision
    {
        /// <summary>
        /// Added By : Siddharth Chauhan
        /// Date : 26-05-2016
        /// Description : To show and get data of Cir Revision.
        /// Task No. : 72518, 72519, 72520
        /// </summary>
        //Task No. : 72518, 72519 & 72520, 

        public static List<DataContracts.CirRevision> GetCirRevision(long CirDataId)
        {
            CirRevision objCirRevision = null;
            List<CirRevision> lstCirRevision = new List<CirRevision>();
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                try
                {
                    //updated by mukul
                    var cirid = (from s2 in context.CirData where s2.CirDataId == CirDataId select s2.CirId).First();
                    var CirDataDetailItems = (from s in context.CirData
                                                  //join s2 in context.CirData on s.CirId equals s2.CirId
                                                  //where s.CirDataId == CirDataId
                                              where s.CirId == cirid
                                              orderby s.Created ascending
                                              //select new { CirId=s.CirId, s.CirDataId, TemplatedRevisionId = s.TemplateVersion, EditedOn = s.Modified, EditedBy = s.ModifiedBy });
                                              select new CirRevision { CirId = s.CirId, CirDataId = s.CirDataId, TemplatedRevisionId = s.TemplateVersion, EditedOn = s.Modified, EditedBy = s.ModifiedBy, CirState = s.State, Progress = s.Progress, Locked = s.Locked, LockedBy = s.LockedBy });

                    //foreach (var e in CirDataDetailItems)
                    //{
                    //    objCirRevision = new DataContracts.CirRevision()
                    //    {
                    //        CirId = e.CirId,
                    //        CirDataId = e.CirDataId,
                    //        TemplatedRevisionId = e.TemplatedRevisionId,
                    //        EditedOn = e.EditedOn,
                    //        EditedBy = e.EditedBy
                    //    };

                    //    lstCirRevision.Add(objCirRevision);
                    //}
                    return CirDataDetailItems.ToList();

                    //updated by mukul
                }
                catch (Exception ex)
                {
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "method GetCirRevision ; " + ex.Message, LogType.Error, "CirDataId" + CirDataId);
                    throw ex;
                }
            }

        }

        public static CIR.ComponentInspectionReport GetCirRevisionData(long CirDataId)
        {
            CIR.ComponentInspectionReport objCirRevision = null;
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                try
                {
                    var cirjson = context.CirJson.Where(c => c.CirDataId == CirDataId).FirstOrDefault();
                    if (cirjson != null && !string.IsNullOrEmpty(cirjson.JSON))
                    {
                        objCirRevision = Newtonsoft.Json.JsonConvert.DeserializeObject<CIR.ComponentInspectionReport>(cirjson.JSON);
                        return objCirRevision;
                    }
                    else
                        throw new Exception("JSON Data not found for the cirdata");

                }
                catch (Exception ex)
                {
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "method GetCirRevisionData ; " + ex.Message, LogType.Error, "CirDataId" + CirDataId);
                    throw ex;
                }
            }

        }
        private static string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["CIM_MasterDataConn"].ConnectionString;
        }
        public static List<CirDataDetail> GetCirRevisionDataByCIRID(long cirId)
        {
            DataSet cList = new DataSet();
            CirDataDetail cirDataDetail = null;
            List<CirDataDetail> lstComponentInspectionReport = new List<CirDataDetail>();
            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("GetCirRevisionDataByCIRID", objCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CirId", SqlDbType.Int);
                    cmd.Parameters["@CirId"].Value = cirId;


                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(cList);
                    }
                    if (cList.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow drH in cList.Tables[0].Rows)
                        {
                            lstComponentInspectionReport.Add(
                                new CirDataDetail()
                                {
                                    CirDataId = Convert.ToInt64(drH["CirDataId"].ToString()),
                                    CirId = drH["CirId"].ToString(),
                                    CirState = Convert.ToInt16(drH["State"].ToString()),
                                    Filename = drH["Filename"].ToString(),
                                    Progress = int.Parse(drH["Progess"].ToString()),
                                    CreatedBy = drH["CreatedBy"].ToString(),
                                    Created = Convert.ToDateTime(drH["Created"].ToString()),
                                    modifiedBy = drH["modifiedBy"].ToString(),
                                    Modified = Convert.ToDateTime(drH["Modified"].ToString()),
                                    TemplateGUID = drH["CIRTemplateGUID"].ToString(),
                                    Locked = Convert.ToInt32(drH["Locked"].ToString()),
                                    LockedBy = drH["LockedBy"].ToString(),
                                    EmailId = drH["EmailId"].ToString(),
                                    FileBytes = Convert.ToString(drH["PDFData"]),
                                }

                           );
                        };
                    }
                }
            }
            return lstComponentInspectionReport;
        }
    }
}