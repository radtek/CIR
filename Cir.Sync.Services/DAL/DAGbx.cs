using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cir.Sync.Services.CIR;
using Cir.Sync.Services.DataContracts;
using Cir.Sync.Services.Edmx;
using Cir.Sync.Services.ErrorHandling;
using System.Globalization;
using System.Data.SqlTypes;
using System.Data.Objects;
using System.Web.Hosting;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Azure.Documents.Client;

namespace Cir.Sync.Services.DAL
{
    public static class DAGbx
    {
        public static List<Gbx> Search(Gbx gbx)
        {
            List<Gbx> lstGbx = new List<Gbx>();
            DataSet dsGbxData = new DataSet();

            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("Stp_Search_GbxData", objCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (!ReferenceEquals(gbx, null))
                    {
                        if (gbx.GbxDataID > 0)
                        {
                            cmd.Parameters.Add("@GbxDataID", SqlDbType.BigInt);
                            cmd.Parameters["@GbxDataID"].Value = gbx.GbxDataID;
                        }
                        if (!string.IsNullOrEmpty(gbx.GearboxSerialNos))
                        {
                            cmd.Parameters.Add("@GearboxSerial", SqlDbType.NVarChar);
                            cmd.Parameters["@GearboxSerial"].Value = gbx.GearboxSerialNos;
                        }
                        if (!ReferenceEquals(gbx.ComponentInspectionReport, null) && gbx.ComponentInspectionReport.TurbineNumber > 0)
                        {
                            cmd.Parameters.Add("@TurbineNumber", SqlDbType.BigInt);
                            cmd.Parameters["@TurbineNumber"].Value = gbx.ComponentInspectionReport.TurbineNumber;
                        }
                        if (ParseDatetime(gbx.strCreated).Year > 1900)
                        {
                            cmd.Parameters.Add("@Created", SqlDbType.DateTime);
                            cmd.Parameters["@Created"].Value = ParseDatetime(gbx.strCreated);
                        }
                        if (!string.IsNullOrEmpty(gbx.CreatedBy))
                        {
                            cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                            cmd.Parameters["@CreatedBy"].Value = gbx.CreatedBy;
                        }
                        try
                        {
                            if (!string.IsNullOrEmpty(gbx.ComponentInspectionReport.SBUName))
                            {
                                cmd.Parameters.Add("@SBU", SqlDbType.NVarChar);
                                cmd.Parameters["@SBU"].Value = gbx.ComponentInspectionReport.SBUName;
                            }
                        }
                        catch { }
                        try
                        {
                            if (!string.IsNullOrEmpty(gbx.ComponentInspectionReport.SiteName))
                            {
                                cmd.Parameters.Add("@Site", SqlDbType.NVarChar);
                                cmd.Parameters["@Site"].Value = gbx.ComponentInspectionReport.SiteName;
                            }
                        }
                        catch { }
                        if (!ReferenceEquals(gbx.Search, null))
                        {
                            if (gbx.Search.CurrentPageNumber > 0)
                            {
                                cmd.Parameters.Add("@CurrentPageNumber", SqlDbType.Int);
                                cmd.Parameters["@CurrentPageNumber"].Value = gbx.Search.CurrentPageNumber;
                            }
                            if (gbx.Search.RecordsPerPage > 0)
                            {
                                cmd.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                                cmd.Parameters["@RecordsPerPage"].Value = gbx.Search.RecordsPerPage;
                            }
                        }
                    }

                    cmd.Parameters.Add("@TotalRecordCount", SqlDbType.Int);
                    cmd.Parameters["@TotalRecordCount"].Value = 0;
                    cmd.Parameters["@TotalRecordCount"].Direction = ParameterDirection.InputOutput;

                    //ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Gbx Quick Search - " + Convert.ToString(gbx.strCreated) + '/' + Convert.ToString(ParseDatetime(gbx.strCreated)), LogType.Error, "");

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsGbxData);
                        gbx.Search.TotalRecordCount = Convert.ToInt32(cmd.Parameters["@TotalRecordCount"].Value);
                        if (dsGbxData.Tables.Count > 0)
                        {
                            foreach (DataRow drH in dsGbxData.Tables[0].Rows)
                            {
                                Gbx oGbx = new Gbx();
                                oGbx.GbxCode = Convert.ToString(drH["GBXirCode"]);
                                oGbx.GbxDataID = Convert.ToInt64(drH["GBXirDataID"]);
                                oGbx.GearboxSerialNos = Convert.ToString(drH["GearboxSerialNos"]);
                                oGbx.Created = Convert.ToDateTime(drH["Created"]);
                                oGbx.CreatedBy = Convert.ToString(drH["CreatedBy"]);
                                oGbx.RevisionNumber = Convert.ToInt32(drH["RevisionNumber"]);
                                oGbx.Search = gbx.Search;

                                oGbx.ComponentInspectionReport = new CIR.ComponentInspectionReport()
                                {
                                    ComponentInspectionReportId = Convert.ToInt64(drH["CirId"]),
                                    CirDataID = Convert.ToInt64(drH["CirDataId"]),
                                    TurbineNumber = Convert.ToInt64(drH["TurbineNumber"]),
                                    TurbineType = Convert.ToString(drH["TurbineType"]),
                                    SiteName = Convert.ToString(drH["SiteAddress"]),
                                    SBUName = Convert.ToString(drH["SBU"])
                                };

                                if (dsGbxData.Tables.Count > 1)
                                {
                                    oGbx.ComponentInspectionReportDetails = new List<CIR.ComponentInspectionReport>();
                                    foreach (DataRow drM in dsGbxData.Tables[1].Select("GBXirDataID=" + drH["GBXirDataID"].ToString()))
                                    {
                                        oGbx.ComponentInspectionReportDetails.Add(
                                            new CIR.ComponentInspectionReport()
                                            {
                                                ComponentInspectionReportId = Convert.ToInt64(drM["CirId"]),
                                                CirDataID = Convert.ToInt64(drM["CirDataId"]),
                                                CIMCaseNumber = Convert.ToInt64(drM["CIMCaseNumber"]),
                                                ComponentInspectionReportName = Convert.ToString(drM["Name"]),
                                                CirName = Convert.ToString(drM["FileName"]),
                                                Created = Convert.ToDateTime(drM["Created"]),
                                                Modified = Convert.ToDateTime(drM["Modified"]),
                                                Gearbox = new CIR.ComponentInspectionReportGearbox() { GearboxSerialNumber = Convert.ToString(drM["GearboxSerialNumber"]) }
                                            }
                                        );
                                    }
                                }
                                lstGbx.Add(oGbx);
                            }
                        }
                    }
                }
            }
            return lstGbx;
        }

        private static DateTime ParseDatetime(string dtdateTime)
        {
            DateTime sDateTime;// DateTime dtNdateTime;
            if (!string.IsNullOrEmpty(dtdateTime) && DateTime.TryParse(dtdateTime, out sDateTime))
            {
                return sDateTime;
            }
            else
            {
                return DateTime.Today;
            }
        }
        /// <summary>
        /// Delete gbx by id
        /// </summary>
        /// <param name="GbxID"></param>
        /// <returns></returns>
        public static bool DeleteGbx(long GbxID)
        {
            bool Return = false;
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                Edmx.GBXirData objGbxData = (from s in context.GBXirData
                                             where s.GBXirDataID == GbxID
                                             select s).FirstOrDefault();
                if (!ReferenceEquals(objGbxData, null))
                {
                    objGbxData.Deleted = true;
                    context.SaveChanges();
                    Return = true;
                }
            }

            return Return;

        }
        /// <summary>
        /// Gbx Pdf and word bytes
        /// </summary>
        /// <param name="GbxID"></param>
        /// <returns></returns>
        public static Gbx GbxFileBytes(long GbxID)
        {
            Gbx oGbx = new Gbx();
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                Edmx.GBXirWordDocument objGbxData = (from s in context.GBXirWordDocument
                                                     where s.GBXirDataID == GbxID
                                                     select s).FirstOrDefault();

                if (!ReferenceEquals(objGbxData, null))
                {
                    oGbx.GbxDataID = (long)objGbxData.GBXirDataID;
                    oGbx.GbxCode = objGbxData.GBXirCode;
                    oGbx.File = new GbxFile() { Id = objGbxData.GBXirWordDocumentID, FileName = objGbxData.GBXirCode, FileBytes = objGbxData.WordDocBytes };

                }
                else
                {
                    var b = DAGBXReport.RenderGbxReport(GbxID);
                    Edmx.GBXirWordDocument objGbxData2 = (from s in context.GBXirWordDocument
                                                          where s.GBXirDataID == GbxID
                                                          select s).FirstOrDefault();
                    if (!ReferenceEquals(objGbxData2, null))
                    {
                        oGbx.GbxDataID = (long)objGbxData2.GBXirDataID;
                        oGbx.GbxCode = objGbxData2.GBXirCode;
                        oGbx.File = new GbxFile() { Id = objGbxData2.GBXirWordDocumentID, FileName = objGbxData2.GBXirCode, FileBytes = objGbxData2.WordDocBytes };

                    }
                }
                DocumentClient _documentClient = new DocumentClient(new Uri(DAGir.endPointURI), DAGir.primaryKey);
                GBXirDataDetails existingGBXirDataDetails = _documentClient.CreateDocumentQuery<GBXirDataDetails>(
                       UriFactory.CreateDocumentCollectionUri(DAGir.databaseId, DAGir.collectionName),
                       new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                   .Where(x => x.GbxDataID == GbxID).AsEnumerable().FirstOrDefault();
                if (existingGBXirDataDetails != null)
                {
                    oGbx.File.FileBytes = DABIRReport.GetWordBytes(Convert.ToString(existingGBXirDataDetails.WordBytesUrl));
                }
            }
            return oGbx;
        }

        public static Gbx GetGbxDataByCirID(string CirIDs)
        {
            Gbx oGbx = new Gbx();
            DataSet dsGbxData = new DataSet();

            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("GetGbxDataByCirIDs", objCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (!ReferenceEquals(CirIDs, null))
                    {

                        cmd.Parameters.Add("@StrCirIDs", SqlDbType.NVarChar);
                        cmd.Parameters["@StrCirIDs"].Value = CirIDs;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dsGbxData);
                            if (dsGbxData.Tables.Count > 0)
                            {
                                foreach (DataRow drH in dsGbxData.Tables[0].Rows)
                                {

                                    oGbx.GbxCode = Convert.ToString(drH["GBXirCode"]);
                                    oGbx.GbxDataID = Convert.ToInt64(drH["GBXirDataID"]);
                                    oGbx.GearboxSerialNos = Convert.ToString(drH["GearboxSerialNos"]);
                                    oGbx.CirIDs = Convert.ToString(drH["CirIDs"]);
                                    oGbx.OilAnalysis = Convert.ToString(drH["OilAnalysis"]);
                                    oGbx.CMSAnalysis = Convert.ToString(drH["CMSAnalysis"]);
                                    oGbx.Analysis = Convert.ToString(drH["Analysis"]);
                                    oGbx.ConclusionsAndRecommendations = Convert.ToString(drH["ConclusionsAndRecommendations"]);
                                    oGbx.RevisionNumber = Convert.ToInt32(drH["RevisionNumber"]);


                                }
                            }
                        }
                    }
                }
            }
            return oGbx;
        }
        /// <summary>
        /// Save and update for Gbx Data
        /// </summary>
        /// <param name="StandardText">Object of Gbx text</param>
        /// <returns></returns>
        public static Gbx SaveGbxData(Gbx GbxDate)
        {
            Gbx oGbx = new Gbx();
            DataSet dsGbxData = new DataSet();
            GBXirDataDetails objGbxDataDetails = new GBXirDataDetails();

            byte[] wordBytes = null;
            long gbxDataId = 0;
            string gbxDataDocumentId = string.Empty, gbxDataUri = string.Empty;

            //string[] cirids = GbxDate.CirIDs.Split(new char[] { '/' });
            //CirSubmissionData cirdata = DABir.GetByCirId(Convert.ToInt64(cirids[1]));

            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("SaveGBXCIRValueinDatabase", objCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (!ReferenceEquals(GbxDate, null))
                    {
                        cmd.Parameters.Add("@MasterCIRID", SqlDbType.BigInt);
                        cmd.Parameters["@MasterCIRID"].Value = GbxDate.GbxDataID;

                        cmd.Parameters.Add("@CIRIDs", SqlDbType.NVarChar);
                        cmd.Parameters["@CIRIDs"].Value = GbxDate.CirIDs;

                        cmd.Parameters.Add("@OilAnalysis", SqlDbType.NVarChar);
                        cmd.Parameters["@OilAnalysis"].Value = GbxDate.OilAnalysis;

                        cmd.Parameters.Add("@CMSAnalysis", SqlDbType.NVarChar);
                        cmd.Parameters["@CMSAnalysis"].Value = GbxDate.CMSAnalysis;

                        cmd.Parameters.Add("@Analysis", SqlDbType.NVarChar);
                        cmd.Parameters["@Analysis"].Value = GbxDate.Analysis;

                        cmd.Parameters.Add("@ConculsionRecomm", SqlDbType.NVarChar);
                        cmd.Parameters["@ConculsionRecomm"].Value = GbxDate.ConclusionsAndRecommendations;

                        cmd.Parameters.Add("@TurbineID", SqlDbType.BigInt);
                        cmd.Parameters["@TurbineID"].Value = GbxDate.TurbineID;

                        cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                        cmd.Parameters["@CreatedBy"].Value = GbxDate.CreatedBy;

                        cmd.Parameters.Add("@RETURNVALUE", SqlDbType.BigInt);
                        cmd.Parameters["@RETURNVALUE"].Direction = ParameterDirection.Output;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dsGbxData);
                            string dataType = "GBXIR";
                            gbxDataId = Convert.ToInt64(cmd.Parameters["@RETURNVALUE"].Value);
                            ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Generating GBXIRPdfReport for GBXDataID: " + gbxDataId.ToString(), LogType.Information, "");
                            try
                            {
                                wordBytes = DAL.DAGBXReport.RenderGbxirReportforCosmos(gbxDataId);
                                objGbxDataDetails = GetGBXirDataByID(gbxDataId);

                                DocumentClient _documentClient = new DocumentClient(new Uri(DAGir.endPointURI), DAGir.primaryKey);

                                GBXirDataDetails existingGbxDataDetails = _documentClient.CreateDocumentQuery<GBXirDataDetails>(
                                       UriFactory.CreateDocumentCollectionUri(DAGir.databaseId, DAGir.collectionName),
                                       new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                                   .Where(x => x.GbxDataID == gbxDataId).AsEnumerable().FirstOrDefault();
                                if (existingGbxDataDetails != null)
                                {
                                    gbxDataUri = Convert.ToString(existingGbxDataDetails.WordBytesUrl);
                                    gbxDataDocumentId = existingGbxDataDetails.Id;
                                }
                                //if (cirdata != null && cirdata.Data != null)
                                //{
                                //    objGbxDataDetails.IsAnnualInspection = cirdata.Data.ctbAnnualInspection;
                                //}
                                objGbxDataDetails.WordBytesUrl = DAGir.SaveWordBytesToBlob(wordBytes, gbxDataUri, objGbxDataDetails.TurbineId, objGbxDataDetails.GbxCode, dataType, objGbxDataDetails.Modified, null, objGbxDataDetails.CirIDs);
                                bool flag = SaveGBXirDataDetailstoCosmosDb(objGbxDataDetails, gbxDataDocumentId);
                                ////DAL.DAGBXReport.RenderGbxReport(Convert.ToInt64(cmd.Parameters["@RETURNVALUE"].Value));
                            }
                            catch (Exception ex)
                            {
                                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "GBXPdfReport Error Generating GBX Report", LogType.Error, "");
                            }
                            if (dsGbxData.Tables.Count > 0)
                            {
                                //return oGbx;
                            }
                        }
                    }
                }
            }
            return oGbx;
        }

        #region GBXIR MigrationData 
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public static List<Gbx> GetGBXirMigrationData()
        {
            List<Gbx> lstObjGbx = null;
            using (SqlConnection objConn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand sqlCmd = new SqlCommand("GetGBXIRMigrationData", objConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    DataTable dt = new DataTable();
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd))
                    {
                        sqlDA.Fill(dt);
                    }
                    if (!ReferenceEquals(dt, null))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            Gbx objGbx = null;
                            lstObjGbx = new List<Gbx>();// Create the list of Gir Object
                            foreach (DataRow drGir in dt.Rows)
                            {
                                objGbx = new Gbx();

                                objGbx.GbxDataID = Convert.ToInt64(drGir["GBXirDataID"]);
                                objGbx.GbxCode = Convert.ToString(drGir["GBXirCode"]);
                                objGbx.RevisionNumber = Convert.ToInt32(drGir["RevisionNumber"]);
                                objGbx.ConclusionsAndRecommendations = Convert.ToString(drGir["ConclusionsAndRecommendations"]);
                                objGbx.CirIDs = Convert.ToString(drGir["CirIDs"]);
                                objGbx.Created = Convert.ToDateTime(drGir["Created"]);
                                objGbx.CreatedBy = Convert.ToString(drGir["CreatedBy"]);
                                objGbx.TurbineID = Convert.ToInt32(drGir["TurbineNumber"]);
                                objGbx.Modified = Convert.ToDateTime(drGir["Modified"]);
                                objGbx.ModifiedBy = Convert.ToString(drGir["ModifiedBy"]);
                                objGbx.Deleted = Convert.ToBoolean(drGir["Deleted"]);
                                objGbx.GearboxSerialNos = Convert.ToString(drGir["GearboxSerialNos"]);
                                objGbx.OilAnalysis = Convert.ToString(drGir["OilAnalysis"]);
                                objGbx.CMSAnalysis = Convert.ToString(drGir["CMSAnalysis"]);
                                objGbx.Analysis = Convert.ToString(drGir["Analysis"]);

                                lstObjGbx.Add(objGbx);
                            }
                        }

                    }

                }
            }
            return lstObjGbx;
        }

        /// <summary>
        /// Save GBXir data details in Azure Container/CosmosDb
        /// </summary>
        /// <param name="objGBXirDataDetails"></param>
        /// <param name="strGbxDataDocumentId"></param>
        /// <returns></returns>
        public static bool SaveGBXirDataDetailstoCosmosDb(GBXirDataDetails objGBXirDataDetails, string gbxDataDocumentId)
        {
            bool flag = false;
            try
            {
                DocumentClient _documentClient = new DocumentClient(new Uri(DAGir.endPointURI), DAGir.primaryKey);
                //Get the doc back as a Document so you have access to doc.SelfLink
                var retObjGbxDataDetails = _documentClient.CreateDocumentQuery<GBXirDataDetails>(
                                          UriFactory.CreateDocumentCollectionUri(DAGir.databaseId, DAGir.collectionName),
                                           new FeedOptions { EnableCrossPartitionQuery = true })
                                          .Where(x => x.GbxDataID == objGBXirDataDetails.GbxDataID)
                                          .AsEnumerable().FirstOrDefault();
                string gbxDataUri = string.Empty;
                if (retObjGbxDataDetails != null)
                {
                    gbxDataDocumentId = retObjGbxDataDetails.Id;
                    gbxDataUri = Convert.ToString(retObjGbxDataDetails.WordBytesUrl.AbsoluteUri);
                }
                if (objGBXirDataDetails.WordBytesUrl == null)
                {
                    Gbx oBir = new Gbx(); string dataType = "GBXIR";
                    using (CIM_CIREntities context = new CIM_CIREntities())
                    {
                        Edmx.GBXirWordDocument objGirData = (from s in context.GBXirWordDocument
                                                             where s.GBXirDataID == objGBXirDataDetails.GbxDataID
                                                             select s).FirstOrDefault();
                        objGBXirDataDetails.WordBytesUrl = DAGir.SaveWordBytesToBlob(objGirData.WordDocBytes, gbxDataUri, Convert.ToString(objGBXirDataDetails.TurbineId), objGBXirDataDetails.GbxCode, dataType, objGBXirDataDetails.Modified, null, objGBXirDataDetails.CirIDs);
                        flag = true;
                    }
                }
                if (string.IsNullOrEmpty(gbxDataDocumentId))
                    _documentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DAGir.databaseId, DAGir.collectionName), objGBXirDataDetails).ConfigureAwait(false);
                else
                    _documentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DAGir.databaseId, DAGir.collectionName, gbxDataDocumentId), objGBXirDataDetails).ConfigureAwait(false);

                flag = true;
            }
            catch (Exception ex)
            {
                return flag = false;
            }
            return flag;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="GbxID"></param>
        /// <returns></returns>
        public static GBXirDataDetails GetGBXirDataByID(long GbxID)
        {
            GBXirDataDetails objGbxDataDetails = null;
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                var cmd = new SqlCommand { Connection = conn };
                SqlDataReader sqlDr = null;
                string whereClauseOrder = "";
                whereClauseOrder += "GBXD.Deleted = 0 AND GBXD.GBXirDataID = " + Convert.ToString(GbxID);

                try
                {
                    cmd.CommandText = string.Format(@"
                        SELECT [GBXirDataID], [GBXirCode], [RevisionNumber], CirIDs, CirDataId,
                        Created, CreatedBy, Modified, ModifiedBy, SiteAddress, TurbineNumber, TurbineType,
                        Country, SBU, GearboxSerialNos, ConclusionsAndRecommendations, OilAnalysis,
                        CMSAnalysis, Analysis, CommisioningDate FROM (                  
            
	                    SELECT GBXD.[GBXirDataID], GBXD.[GBXirCode], GBXD.[RevisionNumber], GBXD.CirIDs,
                               CD.CirDataId, GBXD.Created AS Created, GBXD.CreatedBy AS CreatedBy,
							   GBXD.Modified AS Modified, GBXD.ModifiedBy AS ModifiedBy, isnull(TD.[Site],'') SiteAddress,
							   CMI.TurbineNumber, TD.TurbineType,TD.Country,SBU.[Name] AS SBU, GBXD.GearboxSerialNos,							   
							   GBXD.ConclusionsAndRecommendations, GBXD.OilAnalysis,GBXD.CMSAnalysis,GBXD.Analysis,							   
							   CMI.CommisioningDate AS CommisioningDate,
                               ROW_NUMBER() OVER(ORDER BY GBXD.[Created] DESC ) AS RowNumber                      
	                                   
	                     FROM  [dbo].[GBXirData] AS GBXD     WITH(NOLOCK)				INNER  JOIN
                               [dbo].[MapGBXirCir] AS MGBXC  WITH(NOLOCK)
                                     ON MGBXC.GBXirDataID = GBXD.GBXirDataID 
									 AND MGBXC.Master = 1								INNER JOIN 
                                    
                               [dbo].[CIRData] AS CD     WITH(NOLOCK) 
							         ON CD.[CirDataId] = MGBXC.CirDataID				LEFT JOIN
                               [dbo].[ComponentInspectionReport] AS CMI 
							         ON CMI.ComponentInspectionReportId = CD.[CirId]	LEFT JOIN 
                               [dbo].[SBU] AS SBU WITH(NOLOCK) 
							         ON CMI.SBUId = SBU.[SBUId]							LEFT JOIN
                               [dbo].[TurbineData] AS TD 
							         ON  TD.TurbineId = CONVERT(VARCHAR(50),CMI.TurbineNumber)
	                                    WHERE {0} 
		                                    ) As CirDataPage
                                    ", whereClauseOrder);

                    sqlDr = cmd.ExecuteReader();

                    while (sqlDr.Read())
                    {
                        objGbxDataDetails = new GBXirDataDetails
                        {
                            GbxDataID = sqlDr["GbxDataID"] == DBNull.Value ? 0 : Convert.ToInt64(sqlDr["GbxDataID"]),
                            GbxCode = Convert.ToString(sqlDr["GbxCode"]),
                            RevisionNumber = Convert.ToInt32(sqlDr["RevisionNumber"]),
                            ConclusionsAndRecommendations = Convert.ToString(sqlDr["ConclusionsAndRecommendations"]),
                            CirIDs = Convert.ToString(sqlDr["CirIDs"]),
                            Created = Convert.ToDateTime(sqlDr["Created"]),
                            CreatedBy = Convert.ToString(sqlDr["CreatedBy"]),
                            TurbineId = Convert.ToString(sqlDr["TurbineNumber"]),
                            Modified = Convert.ToDateTime(sqlDr["Modified"]),
                            ModifiedBy = Convert.ToString(sqlDr["ModifiedBy"]),
                            Deleted = Convert.ToBoolean(sqlDr["Deleted"]),
                            GearboxSerialNos = Convert.ToString(sqlDr["GearboxSerialNos"]),
                            OilAnalysis = Convert.ToString(sqlDr["OilAnalysis"]),
                            CMSAnalysis = Convert.ToString(sqlDr["CMSAnalysis"]),
                            Analysis = Convert.ToString(sqlDr["Analysis"]),
                        };
                    }
                    sqlDr.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting GBXIR Data: " + ex.Message.ToString());
                }
                finally
                {
                    if (sqlDr != null)
                    {
                        sqlDr.Close();
                    }
                    conn.Close();
                }
            }
            return objGbxDataDetails;
        }

        #endregion
        /// <summary>
        /// Get connection string
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CIM_MasterDataConn"].ConnectionString;
        }

    }
}