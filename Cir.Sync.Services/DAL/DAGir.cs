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
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Azure.Documents.Client;
using Cir.CloudConvert.Wrapper;

namespace Cir.Sync.Services.DAL
{
    /// <summary>
    /// Data access entity for GIR
    /// </summary>
    public static class DAGir
    {
        public static string databaseId = ConfigurationManager.AppSettings["Database"];
        public static string endPointURI = ConfigurationManager.AppSettings["EndPointUrl"];
        public static string primaryKey = ConfigurationManager.AppSettings["PrimaryKey"];
        public static string collectionName = ConfigurationManager.AppSettings["GIRGBXIRCollectionName"];
        /// <summary>
        /// Get gir details
        /// </summary>
        /// <param name="gir"></param>
        /// <returns></returns>
        public static List<Gir> Search(Gir gir)
        {
            List<Gir> lstGir = new List<Gir>();
            DataSet dsGirData = new DataSet();

            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("Stp_Search_GirData", objCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (!ReferenceEquals(gir, null))
                    {
                        if (gir.GirDataID > 0)
                        {
                            cmd.Parameters.Add("@GirDataID", SqlDbType.BigInt);
                            cmd.Parameters["@GirDataID"].Value = gir.GirDataID;
                        }
                        if (!string.IsNullOrEmpty(gir.GeneralSerialNos))
                        {
                            cmd.Parameters.Add("@GeneratorSerial", SqlDbType.NVarChar);
                            cmd.Parameters["@GeneratorSerial"].Value = gir.GeneralSerialNos;
                        }
                        if (!ReferenceEquals(gir.ComponentInspectionReport, null) && gir.ComponentInspectionReport.TurbineNumber > 0)
                        {
                            cmd.Parameters.Add("@TurbineNumber", SqlDbType.BigInt);
                            cmd.Parameters["@TurbineNumber"].Value = gir.ComponentInspectionReport.TurbineNumber;
                        }
                        if (ParseDatetime(gir.strCreated).Year > 1900)
                        {
                            cmd.Parameters.Add("@Created", SqlDbType.DateTime);
                            cmd.Parameters["@Created"].Value = ParseDatetime(gir.strCreated);
                        }
                        if (!string.IsNullOrEmpty(gir.CreatedBy))
                        {
                            cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                            cmd.Parameters["@CreatedBy"].Value = gir.CreatedBy;
                        }
                        try
                        {
                            if (!string.IsNullOrEmpty(gir.ComponentInspectionReport.SBUName))
                            {
                                cmd.Parameters.Add("@SBU", SqlDbType.NVarChar);
                                cmd.Parameters["@SBU"].Value = gir.ComponentInspectionReport.SBUName;
                            }
                        }
                        catch { }
                        try
                        {
                            if (!string.IsNullOrEmpty(gir.ComponentInspectionReport.SiteName))
                            {
                                cmd.Parameters.Add("@Site", SqlDbType.NVarChar);
                                cmd.Parameters["@Site"].Value = gir.ComponentInspectionReport.SiteName;
                            }
                        }
                        catch { }
                        if (!ReferenceEquals(gir.Search, null))
                        {
                            if (gir.Search.CurrentPageNumber > 0)
                            {
                                cmd.Parameters.Add("@CurrentPageNumber", SqlDbType.Int);
                                cmd.Parameters["@CurrentPageNumber"].Value = gir.Search.CurrentPageNumber;
                            }
                            if (gir.Search.RecordsPerPage > 0)
                            {
                                cmd.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                                cmd.Parameters["@RecordsPerPage"].Value = gir.Search.RecordsPerPage;
                            }
                        }
                    }

                    cmd.Parameters.Add("@TotalRecordCount", SqlDbType.Int);
                    cmd.Parameters["@TotalRecordCount"].Value = 0;
                    cmd.Parameters["@TotalRecordCount"].Direction = ParameterDirection.InputOutput;

                    //ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Gir Quick Search - " + Convert.ToString(gir.strCreated) + '/' + Convert.ToString(ParseDatetime(gir.strCreated)), LogType.Error, "");

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsGirData);
                        gir.Search.TotalRecordCount = Convert.ToInt32(cmd.Parameters["@TotalRecordCount"].Value);
                        if (dsGirData.Tables.Count > 0)
                        {
                            foreach (DataRow drH in dsGirData.Tables[0].Rows)
                            {
                                Gir oGir = new Gir();
                                oGir.GirCode = Convert.ToString(drH["GirCode"]);
                                oGir.GirDataID = Convert.ToInt64(drH["GirDataID"]);
                                oGir.GeneralSerialNos = Convert.ToString(drH["GeneralSerialNos"]);
                                oGir.Created = Convert.ToDateTime(drH["Created"]);
                                oGir.CreatedBy = Convert.ToString(drH["CreatedBy"]);
                                oGir.RevisionNumber = Convert.ToInt32(drH["RevisionNumber"]);
                                oGir.Search = gir.Search;

                                oGir.ComponentInspectionReport = new CIR.ComponentInspectionReport()
                                {
                                    ComponentInspectionReportId = Convert.ToInt64(drH["CirId"]),
                                    CirDataID = Convert.ToInt64(drH["CirDataId"]),
                                    TurbineNumber = Convert.ToInt64(drH["TurbineNumber"]),
                                    TurbineType = Convert.ToString(drH["TurbineType"]),
                                    SiteName = Convert.ToString(drH["SiteAddress"]),
                                    SBUName = Convert.ToString(drH["SBU"])
                                };

                                if (dsGirData.Tables.Count > 1)
                                {
                                    oGir.ComponentInspectionReportDetails = new List<CIR.ComponentInspectionReport>();
                                    foreach (DataRow drM in dsGirData.Tables[1].Select("GirDataID=" + drH["GirDataID"].ToString()))
                                    {
                                        oGir.ComponentInspectionReportDetails.Add(
                                            new CIR.ComponentInspectionReport()
                                            {
                                                ComponentInspectionReportId = Convert.ToInt64(drM["CirId"]),
                                                CirDataID = Convert.ToInt64(drM["CirDataId"]),
                                                CIMCaseNumber = Convert.ToInt64(drM["CIMCaseNumber"]),
                                                ComponentInspectionReportName = Convert.ToString(drM["Name"]),
                                                CirName = Convert.ToString(drM["FileName"]),
                                                Created = Convert.ToDateTime(drM["Created"]),
                                                Modified = Convert.ToDateTime(drM["Modified"]),
                                                Generator = new CIR.ComponentInspectionReportGenerator() { GeneratorSerialNumber = Convert.ToString(drM["GeneratorSerialNumber"]) }
                                            }
                                        );
                                    }
                                }
                                lstGir.Add(oGir);
                            }
                        }
                    }
                }
            }
            return lstGir;
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
        /// Delete gir by id
        /// </summary>
        /// <param name="GirID"></param>
        /// <returns></returns>
        public static bool DeleteGir(long GirID)
        {
            bool Return = false;
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                Edmx.GirData objGirData = (from s in context.GirData
                                           where s.GirDataID == GirID
                                           select s).FirstOrDefault();
                if (!ReferenceEquals(objGirData, null))
                {
                    objGirData.Deleted = true;
                    context.SaveChanges();
                    Return = true;
                }
            }

            return Return;

        }
        /// <summary>
        /// Gir Pdf and word bytes
        /// </summary>
        /// <param name="GirID"></param>
        /// <returns></returns>
        public static Gir GirFileBytes(long GirID)
        {
            Gir oGir = new Gir();
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                Edmx.GirWordDocument objGirData = (from s in context.GirWordDocument
                                                   where s.GirDataID == GirID
                                                   select s).FirstOrDefault();

                if (!ReferenceEquals(objGirData, null))
                {
                    oGir.GirDataID = (long)objGirData.GirDataID;
                    oGir.GirCode = objGirData.GirCode;
                    oGir.File = new GirFile() { Id = objGirData.GirWordDocumentID, FileName = objGirData.GirCode, FileBytes = objGirData.WordDocBytes };

                }
                else
                {
                    var b = DAGIRReport.RenderGirReport(GirID);
                    Edmx.GirWordDocument objGirData2 = (from s in context.GirWordDocument
                                                        where s.GirDataID == GirID
                                                        select s).FirstOrDefault();

                    if (!ReferenceEquals(objGirData2, null))
                    {
                        oGir.GirDataID = (long)objGirData2.GirDataID;
                        oGir.GirCode = objGirData2.GirCode;
                        oGir.File = new GirFile() { Id = objGirData2.GirWordDocumentID, FileName = objGirData2.GirCode, FileBytes = objGirData2.WordDocBytes };

                    }
                }
                DocumentClient _documentClient = new DocumentClient(new Uri(DAGir.endPointURI), DAGir.primaryKey);
                GirDataDetails existingGirDataDetails = _documentClient.CreateDocumentQuery<GirDataDetails>(
                       UriFactory.CreateDocumentCollectionUri(DAGir.databaseId, DAGir.collectionName),
                       new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                   .Where(x => x.GirDataID == GirID).AsEnumerable().FirstOrDefault();
                if (existingGirDataDetails != null)
                {
                    oGir.File.FileBytes = DAL.DABIRReport.GetWordBytes(Convert.ToString(existingGirDataDetails.WordBytesUrl));
                }
            }
            return oGir;
        }

        public static Gir GetGirDataByCirID(string CirIDs)
        {
            Gir oGir = new Gir();
            DataSet dsGirData = new DataSet();

            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("GetGirDataByCirIDs", objCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (!ReferenceEquals(CirIDs, null))
                    {

                        cmd.Parameters.Add("@StrCirIDs", SqlDbType.NVarChar);
                        cmd.Parameters["@StrCirIDs"].Value = CirIDs;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dsGirData);
                            if (dsGirData.Tables.Count > 0)
                            {
                                foreach (DataRow drH in dsGirData.Tables[0].Rows)
                                {

                                    oGir.GirCode = Convert.ToString(drH["GirCode"]);
                                    oGir.GirDataID = Convert.ToInt64(drH["GirDataID"]);
                                    oGir.GeneralSerialNos = Convert.ToString(drH["GeneralSerialNos"]);
                                    oGir.CirIDs = Convert.ToString(drH["CirIDs"]);
                                    oGir.ClassificationOfDamage = Convert.ToString(drH["ClassificationOfDamage"]);
                                    oGir.AnalysisOfMeasurments = Convert.ToString(drH["AnalysisOfMeasurments"]);
                                    oGir.AnalysisOfPicture = Convert.ToString(drH["AnalysisOfPicture"]);
                                    oGir.ConclusionsAndRecommendations = Convert.ToString(drH["ConclusionsAndRecommendations"]);
                                    oGir.RevisionNumber = Convert.ToInt32(drH["RevisionNumber"]);


                                }
                            }
                        }
                    }
                }
            }
            return oGir;
        }

        /// <summary>
        /// Save and update for Gir Data
        /// </summary>
        /// <param name="StandardText">Object of Gir text</param>
        /// <returns></returns>
        public static Gir SaveGirData(Gir GirDate)
        {
            GirDataDetails objGirDataDetails = new GirDataDetails();
            Gir oGir = new Gir();
            DataSet dsGirData = new DataSet();

            byte[] wordBytes = null;
            long girDataId = 0;
            string girDataDocumentId = string.Empty, girDataUri = string.Empty;

            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("SaveGIRCIRValueinDatabase", objCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (!ReferenceEquals(GirDate, null))
                    {


                        cmd.Parameters.Add("@MasterCIRID", SqlDbType.BigInt);
                        cmd.Parameters["@MasterCIRID"].Value = GirDate.GirDataID;

                        cmd.Parameters.Add("@CIRIDs", SqlDbType.NVarChar);
                        cmd.Parameters["@CIRIDs"].Value = GirDate.CirIDs;

                        cmd.Parameters.Add("@ClassificationOfDamage", SqlDbType.NVarChar);
                        cmd.Parameters["@ClassificationOfDamage"].Value = GirDate.ClassificationOfDamage;

                        cmd.Parameters.Add("@AnalysisOfPicture", SqlDbType.NVarChar);
                        cmd.Parameters["@AnalysisOfPicture"].Value = GirDate.AnalysisOfPicture;

                        cmd.Parameters.Add("@AnalysisOfMeasurments", SqlDbType.NVarChar);
                        cmd.Parameters["@AnalysisOfMeasurments"].Value = GirDate.AnalysisOfMeasurments;

                        cmd.Parameters.Add("@ConculsionRecomm", SqlDbType.NVarChar);
                        cmd.Parameters["@ConculsionRecomm"].Value = GirDate.ConclusionsAndRecommendations;

                        cmd.Parameters.Add("@TurbineID", SqlDbType.BigInt);
                        cmd.Parameters["@TurbineID"].Value = GirDate.TurbineID;

                        cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                        cmd.Parameters["@CreatedBy"].Value = GirDate.CreatedBy;

                        cmd.Parameters.Add("@RETURNVALUE", SqlDbType.BigInt);
                        cmd.Parameters["@RETURNVALUE"].Direction = ParameterDirection.Output;


                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dsGirData); string dataType = "GIR";
                            girDataId = Convert.ToInt64(cmd.Parameters["@RETURNVALUE"].Value);
                            ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Generating GIRPdfReport for GIRDataID: " + girDataId.ToString(), LogType.Information, "");
                            try
                            {
                                wordBytes = DAL.DAGIRReport.RenderGirReportforCosmos(girDataId);
                                objGirDataDetails = GetGirDataByID(girDataId);

                                DocumentClient _documentClient = new DocumentClient(new Uri(endPointURI), primaryKey);

                                GirDataDetails existingGirDataDetails = _documentClient.CreateDocumentQuery<GirDataDetails>(
                                       UriFactory.CreateDocumentCollectionUri(databaseId, collectionName),
                                       new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                                   .Where(x => x.GirDataID == girDataId).AsEnumerable().FirstOrDefault();
                                if (existingGirDataDetails != null)
                                {
                                    girDataUri = Convert.ToString(existingGirDataDetails.WordBytesUrl);
                                    girDataDocumentId = existingGirDataDetails.Id;
                                }
                                objGirDataDetails.WordBytesUrl = SaveWordBytesToBlob(wordBytes, girDataUri, objGirDataDetails.TurbineId, objGirDataDetails.GirCode, dataType, objGirDataDetails.Modified, null, objGirDataDetails.CirIDs);
                                bool flag = SaveGirDataDetailstoCosmosDb(objGirDataDetails, girDataDocumentId);
                            }
                            catch (Exception ex)
                            {
                                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "GIRPdfReport Error Generating GIR Report", LogType.Error, "");

                            }

                            if (dsGirData.Tables.Count > 0)
                            {
                                //return oGir;


                            }
                        }
                    }
                }
            }


            return oGir;
        }

        #region GIR MigrationData    
        public static List<Gir> GetGirMigrationData()
        {
            List<Gir> lstGir = null;
            using (SqlConnection objConn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand sqlCmd = new SqlCommand("GetGIRMigrationData", objConn))
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
                            Gir objGir = null;
                            lstGir = new List<Gir>();// Create the list of Gir Object
                            foreach (DataRow drGir in dt.Rows)
                            {
                                objGir = new Gir();
                                objGir.GirDataID = Convert.ToInt64(drGir["GirDataID"]);
                                objGir.GirCode = Convert.ToString(drGir["GirCode"]);
                                objGir.RevisionNumber = Convert.ToInt32(drGir["RevisionNumber"]);
                                objGir.ConclusionsAndRecommendations = Convert.ToString(drGir["ConclusionsAndRecommendations"]);
                                objGir.CirIDs = Convert.ToString(drGir["CirIDs"]);
                                objGir.Created = Convert.ToDateTime(drGir["Created"]);
                                objGir.CreatedBy = Convert.ToString(drGir["CreatedBy"]);
                                objGir.TurbineID = Convert.ToInt32(drGir["TurbineNumber"]);
                                objGir.Modified = Convert.ToDateTime(drGir["Modified"]);
                                objGir.ModifiedBy = Convert.ToString(drGir["ModifiedBy"]);
                                objGir.Deleted = Convert.ToBoolean(drGir["Deleted"]);
                                objGir.GeneralSerialNos = Convert.ToString(drGir["GeneralSerialNos"]);
                                objGir.ClassificationOfDamage = Convert.ToString(drGir["ClassificationOfDamage"]);
                                objGir.AnalysisOfPicture = Convert.ToString(drGir["AnalysisOfPicture"]);
                                objGir.AnalysisOfMeasurments = Convert.ToString(drGir["AnalysisOfMeasurments"]);

                                lstGir.Add(objGir);
                            }
                        }

                    }

                }
            }
            return lstGir;
        }


        public static GirDataDetails GetGirDataByID(long GirID)
        {
            GirDataDetails objGIRView = new GirDataDetails();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                var cmd = new SqlCommand { Connection = conn };
                SqlDataReader reader = null;
                string whereClauseOrder = "";
                whereClauseOrder += "GD.Deleted = 0 AND GD.GirDataID = " + GirID.ToString();

                try
                {
                    cmd.CommandText = string.Format(@"
                        SELECT [GirDataID],[GirCode],[RevisionNumber], CirIDs,CirDataId,
                               Created,CreatedBy,Modified,ModifiedBy,SiteAddress,TurbineNumber,TurbineType,
                               Country,SBU,GeneralSerialNos,ConclusionsAndRecommendations, ClassificationOfDamage,
                               AnalysisOfPicture,AnalysisOfMeasurments, CommisioningDate FROM (                  
            
	                    SELECT GD.[GirDataID],GD.[GirCode], GD.[RevisionNumber], GD.CirIDs,
                               CD.CirDataId,  GD.Created Created, GD.CreatedBy CreatedBy,GD.Modified Modified,GD.ModifiedBy ModifiedBy,
							   isnull(td.[Site],'') SiteAddress,CMI.TurbineNumber, td.TurbineType,td.Country,sbu.[Name] as SBU,
							   GD.GeneralSerialNos,GD.ConclusionsAndRecommendations,
							   GD.ClassificationOfDamage,GD.AnalysisOfPicture,GD.AnalysisOfMeasurments,
							   CMI.CommisioningDate as CommisioningDate,
                               ROW_NUMBER() OVER(ORDER BY GD.[Created] DESC ) AS RowNumber                      
	                                   
	                     FROM  [dbo].[GirData]   GD   WITH(NOLOCK)     INNER  JOIN
                               [dbo].[MapGirCir] MPC  WITH(NOLOCK)
                                     ON MPC.GirDataID = GD.GirDataID 
									 AND MPC.Master = 1                INNER JOIN 
                                    
                               [dbo].[CIRData] CD  WITH(NOLOCK) 
							         ON CD.[CirDataId] = MPC.CirDataID LEFT JOIN
                               [dbo].[ComponentInspectionReport] CMI 
							         ON CMI.ComponentInspectionReportId = CD.[CirId] LEFT JOIN 
                               [dbo].[SBU] sbu WITH(NOLOCK) 
							         ON CMI.SBUId = sbu.[SBUId] LEFT JOIN
                               [dbo].[TurbineData] td 
							         ON  td.TurbineId = CONVERT(VARCHAR(50),CMI.TurbineNumber)
	                                    WHERE {0} 
		                                    ) As CirDataPage
                                    ", whereClauseOrder);

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objGIRView = new GirDataDetails
                        {
                            GirDataID = reader["GirDataId"] == DBNull.Value ? 0 : Convert.ToInt64(reader["GirDataId"]),
                            GirCode = Convert.ToString(reader["GirCode"]),
                            RevisionNumber = Convert.ToInt32(reader["RevisionNumber"]),
                            ConclusionsAndRecommendations = Convert.ToString(reader["ConclusionsAndRecommendations"]),
                            CirIDs = Convert.ToString(reader["CirIDs"]),
                            Created = reader.GetDateTime(reader.GetOrdinal("Created")),
                            CreatedBy = reader.GetString(reader.GetOrdinal("Createdby")),
                            TurbineId = Convert.ToString(reader["TurbineNumber"]),
                            Modified = reader.GetDateTime(reader.GetOrdinal("Modified")),
                            ModifiedBy = reader.GetString(reader.GetOrdinal("ModifiedBy")),
                            Deleted = Convert.ToBoolean(reader["Deleted"]),
                            GeneralSerialNos = Convert.ToString(reader["GeneralSerialNos"]),
                            ClassificationOfDamage = Convert.ToString(reader["ClassificationOfDamage"]),
                            AnalysisOfPicture = Convert.ToString(reader["AnalysisOfPicture"]),
                            AnalysisOfMeasurments = Convert.ToString(reader["AnalysisOfMeasurments"])

                        };
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting GIR Data: " + ex.Message.ToString());
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                    conn.Close();
                }
            }
            return objGIRView;
        }

        /// <summary>
        /// Save Gir data details in Azure Container/CosmosDb
        /// </summary>
        /// <param name="objGirDataDetails"></param>
        /// <param name="birDataDocumentId"></param>
        /// <returns></returns>
        public static bool SaveGirDataDetailstoCosmosDb(GirDataDetails objGirDataDetails, string girDataDocumentId)
        {
            bool flag = false;
            try
            {
                DocumentClient _documentClient = new DocumentClient(new Uri(endPointURI), primaryKey);

                //Get the doc back as a Document so you have access to doc.SelfLink
                var retObjGirDataDetails = _documentClient.CreateDocumentQuery<GirDataDetails>(
                                          UriFactory.CreateDocumentCollectionUri(databaseId, collectionName),
                                           new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                                          .Where(x => x.GirDataID == objGirDataDetails.GirDataID)
                                          .AsEnumerable().FirstOrDefault();
                string girDataUri = string.Empty;

                if (retObjGirDataDetails != null)
                {
                    girDataDocumentId = retObjGirDataDetails.Id;
                    girDataUri = Convert.ToString(retObjGirDataDetails.WordBytesUrl.AbsoluteUri) ?? default(string);
                }
                if (objGirDataDetails.WordBytesUrl == null)
                {
                    Gir oBir = new Gir(); string dataType = "GIR";
                    using (CIM_CIREntities context = new CIM_CIREntities())
                    {
                        Edmx.GirWordDocument objGirData = (from s in context.GirWordDocument
                                                           where s.GirDataID == objGirDataDetails.GirDataID
                                                           select s).FirstOrDefault();
                        objGirDataDetails.WordBytesUrl = SaveWordBytesToBlob(objGirData.WordDocBytes, girDataUri, Convert.ToString(objGirDataDetails.TurbineId), objGirDataDetails.GirCode, dataType, objGirDataDetails.Modified, null, objGirDataDetails.CirIDs);
                        flag = true;
                    }
                }
                if (string.IsNullOrEmpty(girDataDocumentId))
                    _documentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseId, collectionName), objGirDataDetails).ConfigureAwait(false);
                else
                    _documentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseId, collectionName, girDataDocumentId), objGirDataDetails).ConfigureAwait(false);

                flag = true;
            }
            catch (Exception ex)
            {
                return flag = false;
            }
            return flag;
        }

        /// <summary>
        /// save word bytes to blob
        /// </summary>
        /// <param name="wordBytes"></param>
        /// <param name="birDataUri"></param>
        /// <param name="turbineNumber"></param>
        /// <returns></returns>
        public static Uri SaveWordBytesToBlob(byte[] wordBytes, string birDataUri, string turbineNumber, string fileName, string dataType, DateTime modified, string IsAnnualInspection = null, string RelatedCIRs = null)
        {
            CloudBlobClient blobClient;
            CloudBlobContainer container;

            string containerName = System.Configuration.ConfigurationManager.AppSettings["AzureStorageImgContainerName"];
            var storageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse(System.Configuration.ConfigurationManager.AppSettings["AzureStorageConnectionString"]);
            blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference(containerName);
            //container.CreateIfNotExists();
            string blobId, directoryName, directoryNamePdf = string.Empty;

            blobId = GetKey(container);
            string docFolder = "Doc", pdfFolder = "PDF";
            directoryName = $"{turbineNumber}/{dataType}/{docFolder}/{blobId}";
            directoryNamePdf = $"{turbineNumber}/{dataType}/{pdfFolder}/{blobId}";
            if (directoryName.IndexOf(".doc") == -1)
            {
                directoryName = directoryName + ".docx";
            }
            if (directoryNamePdf.IndexOf(".pdf") == -1)
            {
                directoryNamePdf = directoryNamePdf + ".pdf";
            }
            string relatedCirs = "", isAnnual = "";
            if (!string.IsNullOrEmpty(RelatedCIRs))
            {
                relatedCirs = RelatedCIRs.Replace('/', ',');
                relatedCirs = relatedCirs.Substring(relatedCirs.IndexOf(',') + 1);
                isAnnual = (relatedCirs.Split(',').Count() == 3) ? "true" : "false";
            }
            CloudBlockBlob objBlockBlobDoc = container.GetBlockBlobReference(directoryName);

            if (!objBlockBlobDoc.Exists())
            {
                objBlockBlobDoc.Metadata.Add("fileName", fileName);
                if (!string.IsNullOrEmpty(relatedCirs))
                {
                    objBlockBlobDoc.Metadata.Add("relatedCirs", relatedCirs);
                    objBlockBlobDoc.Metadata.Add("isAnnual", isAnnual);
                }
                objBlockBlobDoc.Metadata.Add("modified", modified.ToString("yyyy-MM-dd HH:mm:ss"));
                objBlockBlobDoc.UploadFromByteArray(wordBytes, 0, wordBytes.Length);
            }
            // Code for pdf 
            ConverterWrapper objPdf = new ConverterWrapper();
            var res = objPdf.CreatePDFAsync(Convert.ToString(objBlockBlobDoc.Uri.OriginalString), directoryName);

            CloudBlockBlob objBlockBlobPdf = container.GetBlockBlobReference(directoryNamePdf);
            if (!objBlockBlobPdf.Exists())
            {
                objBlockBlobPdf.Metadata.Add("fileName", fileName);
                if (!string.IsNullOrEmpty(relatedCirs))
                {
                    objBlockBlobPdf.Metadata.Add("relatedCirs", relatedCirs);
                    objBlockBlobPdf.Metadata.Add("isAnnual", isAnnual);
                }
                objBlockBlobPdf.Metadata.Add("modified", modified.ToString("yyyy-MM-dd HH:mm:ss"));
                byte[] pdfBytes = Convert.FromBase64String(res.Result.ResponseString);
                objBlockBlobPdf.UploadFromByteArray(pdfBytes, 0, pdfBytes.Length);
            }
            return objBlockBlobDoc.Uri;
        }

        /// <summary>
        /// Get key
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public static string GetKey(CloudBlobContainer container)
        {
            try
            {
                string key = Guid.NewGuid().ToString();
                CloudBlockBlob blockBlob = new CloudBlockBlob(GetBlobSASUri(key, "CreateBlob"));
                return (!blockBlob.Exists()) ? key : GetKey(container);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// get blob as uri
        /// </summary>
        /// <param name="blobName"></param>
        /// <param name="policyName"></param>
        /// <returns></returns>
        public static Uri GetBlobSASUri(string blobName, string policyName)
        {
            CloudBlobClient blobClient;
            CloudBlobContainer container;

            string containerName = string.Empty;
            containerName = System.Configuration.ConfigurationManager.AppSettings["AzureStorageImgContainerName"];
            var storageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse(System.Configuration.ConfigurationManager.AppSettings["AzureStorageConnectionString"]);
            blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference(containerName);
            //container.CreateIfNotExists();
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
            //var storedPolicy = new SharedAccessBlobPolicy()
            //{
            //    SharedAccessExpiryTime = DateTime.UtcNow.AddHours(1),
            //    Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.Create | SharedAccessBlobPermissions.Delete
            //};
            //var permissions = container.GetPermissions();
            //permissions.SharedAccessPolicies.Clear();
            //permissions.SharedAccessPolicies.Add(policyName, storedPolicy);
            //container.SetPermissions(permissions);
            //var sasBlobToken = blockBlob.GetSharedAccessSignature(null, policyName);
            //Uri blobUri = new Uri(blockBlob.Uri + sasBlobToken);
            //return blobUri;
            return blockBlob.Uri;

        }

        /// <summary>
        /// Get by image url
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <param name="containerType"></param>
        /// <returns></returns>
        public static string GetByImageUrl(string imageUrl, string containerType)
        {
            try
            {
                string retVal = string.Empty;
                CloudBlockBlob Blob = new CloudBlockBlob(new Uri(imageUrl));
                Uri sasBlobUri = GetBlobSASUri(Blob.Name, "ReadBlob");
                return sasBlobUri.AbsoluteUri;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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