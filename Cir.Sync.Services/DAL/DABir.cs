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
using Newtonsoft.Json.Linq;
using Microsoft.Azure.Documents.Client;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Azure.Documents;
using Cir.CloudConvert.Wrapper;

namespace Cir.Sync.Services.DAL
{
    /// <summary>
    /// Data access entity for BIR
    /// </summary>
    public static class DABir
    {
        public static string databaseId = ConfigurationManager.AppSettings["Database"];
        public static string endPointURI = ConfigurationManager.AppSettings["EndPointUrl"];
        public static string primaryKey = ConfigurationManager.AppSettings["PrimaryKey"];
        public static string collectionName = ConfigurationManager.AppSettings["CirCollectionName"];
        public static string componentInspectionCollection = ConfigurationManager.AppSettings["CirCollectionComponentInspection"];

        /// <summary>
        /// Get bir details
        /// </summary>
        /// <param name="bir"></param>
        /// <returns></returns>
        public static List<Bir> Search(Bir bir)
        {
            List<Bir> lstBir = new List<Bir>();
            DataSet dsBirData = new DataSet();

            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("Stp_Search_BirData", objCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (!ReferenceEquals(bir, null))
                    {
                        if (bir.BirDataID > 0)
                        {
                            cmd.Parameters.Add("@BirDataID", SqlDbType.BigInt);
                            cmd.Parameters["@BirDataID"].Value = bir.BirDataID;
                        }
                        if (!string.IsNullOrEmpty(bir.BladeSerialNos))
                        {
                            cmd.Parameters.Add("@BladeSerail", SqlDbType.NVarChar);
                            cmd.Parameters["@BladeSerail"].Value = bir.BladeSerialNos;
                        }
                        if (!ReferenceEquals(bir.ComponentInspectionReport, null) && bir.ComponentInspectionReport.TurbineNumber > 0)
                        {
                            cmd.Parameters.Add("@TurbineNumber", SqlDbType.BigInt);
                            cmd.Parameters["@TurbineNumber"].Value = bir.ComponentInspectionReport.TurbineNumber;
                        }
                        if (ParseDatetime(bir.strCreated).Year > 1900)
                        {
                            cmd.Parameters.Add("@Created", SqlDbType.DateTime);
                            cmd.Parameters["@Created"].Value = ParseDatetime(bir.strCreated);
                        }
                        if (!string.IsNullOrEmpty(bir.CreatedBy))
                        {
                            cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                            cmd.Parameters["@CreatedBy"].Value = bir.CreatedBy;
                        }
                        try
                        {
                            if (!string.IsNullOrEmpty(bir.ComponentInspectionReport.SBUName))
                            {
                                cmd.Parameters.Add("@SBU", SqlDbType.NVarChar);
                                cmd.Parameters["@SBU"].Value = bir.ComponentInspectionReport.SBUName;
                            }
                        }
                        catch { }
                        try
                        {
                            if (!string.IsNullOrEmpty(bir.ComponentInspectionReport.SiteName))
                            {
                                cmd.Parameters.Add("@Site", SqlDbType.NVarChar);
                                cmd.Parameters["@Site"].Value = bir.ComponentInspectionReport.SiteName;
                            }
                        }
                        catch { }
                        if (!ReferenceEquals(bir.Search, null))
                        {
                            if (bir.Search.CurrentPageNumber > 0)
                            {
                                cmd.Parameters.Add("@CurrentPageNumber", SqlDbType.Int);
                                cmd.Parameters["@CurrentPageNumber"].Value = bir.Search.CurrentPageNumber;
                            }
                            if (bir.Search.RecordsPerPage > 0)
                            {
                                cmd.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                                cmd.Parameters["@RecordsPerPage"].Value = bir.Search.RecordsPerPage;
                            }
                        }
                    }

                    cmd.Parameters.Add("@TotalRecordCount", SqlDbType.Int);
                    cmd.Parameters["@TotalRecordCount"].Value = 0;
                    cmd.Parameters["@TotalRecordCount"].Direction = ParameterDirection.InputOutput;

                    //ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Bir Quick Search - " + Convert.ToString(bir.strCreated) + '/' + Convert.ToString(ParseDatetime(bir.strCreated)), LogType.Error, "");

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsBirData);
                        bir.Search.TotalRecordCount = Convert.ToInt32(cmd.Parameters["@TotalRecordCount"].Value);
                        if (dsBirData.Tables.Count > 0)
                        {
                            foreach (DataRow drH in dsBirData.Tables[0].Rows)
                            {
                                Bir oBir = new Bir();
                                oBir.BirCode = Convert.ToString(drH["BirCode"]);
                                oBir.BirDataID = Convert.ToInt64(drH["BirDataID"]);
                                oBir.BladeSerialNos = Convert.ToString(drH["BladeSerialNos"]);
                                oBir.Created = Convert.ToDateTime(drH["Created"]);
                                oBir.CreatedBy = Convert.ToString(drH["CreatedBy"]);
                                oBir.RevisionNumber = Convert.ToInt32(drH["RevisionNumber"]);
                                oBir.Search = bir.Search;

                                oBir.ComponentInspectionReport = new CIR.ComponentInspectionReport()
                                {
                                    ComponentInspectionReportId = Convert.ToInt64(drH["CirId"]),
                                    CirDataID = Convert.ToInt64(drH["CirDataId"]),
                                    TurbineNumber = Convert.ToInt64(drH["TurbineNumber"]),
                                    TurbineType = Convert.ToString(drH["TurbineType"]),
                                    SiteName = Convert.ToString(drH["SiteAddress"]),
                                    SBUName = Convert.ToString(drH["SBU"])
                                };

                                if (dsBirData.Tables.Count > 1)
                                {
                                    oBir.ComponentInspectionReportDetails = new List<CIR.ComponentInspectionReport>();
                                    foreach (DataRow drM in dsBirData.Tables[1].Select("BirDataID=" + drH["BirDataID"].ToString()))
                                    {
                                        oBir.ComponentInspectionReportDetails.Add(
                                            new CIR.ComponentInspectionReport()
                                            {
                                                ComponentInspectionReportId = Convert.ToInt64(drM["CirId"]),
                                                CirDataID = Convert.ToInt64(drM["CirDataId"]),
                                                CIMCaseNumber = Convert.ToInt64(drM["CIMCaseNumber"]),
                                                ComponentInspectionReportName = Convert.ToString(drM["Name"]),
                                                CirName = Convert.ToString(drM["FileName"]),
                                                Created = Convert.ToDateTime(drM["Created"]),
                                                Modified = Convert.ToDateTime(drM["Modified"]),
                                                BladeData = new CIR.ComponentInspectionReportBlade() { BladeSerialNumber = Convert.ToString(drM["BladeSerialNumber"]) }
                                            }
                                        );
                                    }
                                }
                                lstBir.Add(oBir);
                            }
                        }
                    }
                }
            }
            return lstBir;
        }

        /// <summary>
        /// parse datetime value
        /// </summary>
        /// <param name="dtdateTime"></param>
        /// <returns></returns>
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
        /// Delete bir by id
        /// </summary>
        /// <param name="BirID"></param>
        /// <returns></returns>
        public static bool DeleteBir(long BirID)
        {
            bool Return = false;
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                Edmx.BirData objBirData = (from s in context.BirData
                                           where s.BirDataID == BirID
                                           select s).FirstOrDefault();
                if (!ReferenceEquals(objBirData, null))
                {
                    objBirData.Deleted = true;
                    context.SaveChanges();
                    Return = true;
                }
            }

            return Return;

        }

        /// <summary>
        /// Bir Pdf and word bytes
        /// </summary>
        /// <param name="BirID"></param>
        /// <returns></returns>
        public static Bir BirFileBytes(long BirID)
        {
            Bir oBir = new Bir();
            string dataType = "BIR";
            try
            {

                DocumentClient _documentClient = new DocumentClient(new Uri(DABir.endPointURI), DABir.primaryKey);
                BirDataDetails existingBirDataDetails = _documentClient.CreateDocumentQuery<BirDataDetails>(
                       UriFactory.CreateDocumentCollectionUri(DABir.databaseId, DABir.collectionName),
                       new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                   .Where(x => x.BirDataID == BirID).AsEnumerable().FirstOrDefault();

                if (existingBirDataDetails != null)
                {
                    oBir.File = new BirFile { FileName = existingBirDataDetails.BirCode };
                    if (existingBirDataDetails.WordDocStatus == null)                   
                        oBir = ReadBirDetailsFromBlob(oBir, existingBirDataDetails);                    
                    else if (existingBirDataDetails.WordDocStatus == "Generated")
                        oBir.File.FileBytes = DAL.DABIRReport.GetWordBytes(existingBirDataDetails.WordBytesUrl.ToString());
                    else if (existingBirDataDetails.WordDocStatus == "Error")
                        oBir.File.FileStatus = "Error";
                    else
                        oBir.File.FileStatus = "NotGenerated";
                }

                else
                {
                    string birDataDocumentId = string.Empty;
                    oBir = CheckBirSQLEntries(BirID, oBir);
                    BirDataDetails objBirDetails = DABir.GetBirDataByID(BirID);
                    if (oBir.File.FileBytes == null)
                        oBir.File.FileBytes = DABIRReport.RenderBirReportforCosmos(BirID, HttpContext.Current);
                    objBirDetails.WordBytesUrl = DABir.SaveWordBytesToBlob(oBir.File.FileBytes, "", objBirDetails.TurbineId, objBirDetails.BirCode, dataType, DateTime.Today, fileType: "Doc");
                    objBirDetails.WordDocStatus = "Generated";
                    if (objBirDetails.PDFStatus == null)
                        objBirDetails.PDFStatus = "NotGenerated";
                    DABir.SaveBirDatatoCosmosDb(objBirDetails, birDataDocumentId);
                }
            }

            catch (Exception ex)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", string.Format("BIRPdfReport Error:{0} ", ex.InnerException), LogType.Error, "");
                oBir.File.FileStatus = "Error";
            }
            return oBir;
        }

        public static Bir ReadBirDetailsFromBlob(Bir oBir, BirDataDetails existingBirDataDetails, string fileType = "Doc")
        {
            try
            {

                CloudBlockBlob Blob = new CloudBlockBlob(new Uri(existingBirDataDetails.WordBytesUrl.ToString()));
                string directoryName = Blob.Name;
                if (fileType == "pdf") directoryName = directoryName.Replace("docx", "pdf").Replace("Doc", "PDF");
                CloudBlockBlob objBlockBlob = DABir.GetBlockBlob(directoryName);
                if (objBlockBlob.Exists())
                {
                    objBlockBlob.FetchAttributes();
                    byte[] byteArray = new byte[objBlockBlob.Properties.Length];
                    objBlockBlob.DownloadToByteArray(byteArray, 0);
                    oBir.File.FileBytes = byteArray;
                    existingBirDataDetails.WordDocStatus = "Generated";
                    if (fileType == "pdf") existingBirDataDetails.PDFStatus = "Generated";
                    DABir.SaveBirDatatoCosmosDb(existingBirDataDetails, existingBirDataDetails.Id);

                }
            }

            catch (Exception ex)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", string.Format("BIRPdfReport Error:{0} ", ex.InnerException), LogType.Error, "");
            }
            return oBir;
        }

        public static Bir CheckBirSQLEntries(long BirID, Bir oBir)
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                Edmx.BirWordDocument objBirData = (from s in context.BirWordDocument
                                                   where s.BirDataID == BirID
                                                   select s).FirstOrDefault();

                if (!ReferenceEquals(objBirData, null))
                {
                    oBir.BirDataID = (long)objBirData.BirDataID;
                    oBir.BirCode = objBirData.BirCode;
                    oBir.File = new BirFile() { Id = objBirData.BirWordDocumentID, FileName = objBirData.BirCode, FileBytes = objBirData.WordDocBytes };
                }
            }

            return oBir;
        }

        /// <summary>
        /// Get bir data by cir id
        /// </summary>
        /// <param name="CirIDs"></param>
        /// <returns></returns>
        public static Bir GetBirDataByCirID(string CirIDs)
        {
            Bir oBir = new Bir();
            DataSet dsBirData = new DataSet();

            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("GetBirDataByCirIDs", objCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (!ReferenceEquals(CirIDs, null))
                    {

                        cmd.Parameters.Add("@StrCirIDs", SqlDbType.NVarChar);
                        cmd.Parameters["@StrCirIDs"].Value = CirIDs;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dsBirData);
                            if (dsBirData.Tables.Count > 0)
                            {
                                foreach (DataRow drH in dsBirData.Tables[0].Rows)
                                {

                                    oBir.BirCode = Convert.ToString(drH["BirCode"]);
                                    oBir.BirDataID = Convert.ToInt64(drH["BirDataID"]);
                                    oBir.BladeSerialNos = Convert.ToString(drH["BladeSerialNos"]);
                                    oBir.CirIDs = Convert.ToString(drH["CirIDs"]);
                                    oBir.RepairingSolutions = Convert.ToString(drH["RepairingSolutions"]);
                                    oBir.RawMaterials = Convert.ToString(drH["RawMaterials"]);
                                    oBir.ConclusionsAndRecommendations = Convert.ToString(drH["ConclusionsAndRecommendations"]);
                                    oBir.RevisionNumber = Convert.ToInt32(drH["RevisionNumber"]);


                                }
                            }
                        }
                    }
                }
            }
            return oBir;
        }

        public static CirSubmissionData GetByCirId(long cirId)
        {
            try
            {
                DocumentClient _documentClient = new DocumentClient(new Uri(endPointURI), primaryKey);
                var data = _documentClient.CreateDocumentQuery<CirSubmissionData>(
                        UriFactory.CreateDocumentCollectionUri(databaseId, componentInspectionCollection),
                       new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true, PartitionKey = new PartitionKey(getPartition(cirId)) })
                    .Where(x => x.CirId == cirId).AsEnumerable().FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public static string getPartition(Int64 cirId)
        {
            string partitionName;
            decimal partitionValue;
            //1 - 99999
            //100000 - 199999
            if (ConfigurationManager.AppSettings["PartitionDivisionValue"] != null)
                partitionValue = (cirId / Convert.ToInt64(ConfigurationManager.AppSettings["PartitionDivisionValue"]));
            else
                partitionValue = (cirId / 50000);
            //cirId = 99999;


            partitionName = "partition" + (int)partitionValue;

            return partitionName;
        }


        /// <summary>
        /// Save and update for Bir Data
        /// </summary>
        /// <param name="StandardText">Object of Bir text</param>
        /// <returns></returns>
        public static Bir SaveBirData(Bir BirDate)
        {
            BirDataDetails objBirDetails = new BirDataDetails();
            Bir oBir = new DataContracts.Bir();
            DataSet dsBirData = new DataSet();
            byte[] wordBytes = null;
            long birDataId = 0;
            string birDataDocumentId = string.Empty, birDataUri = string.Empty;
            string[] cirids = BirDate.CirIDs.Split(new char[] { '/' });
            CirSubmissionData cirdata = new CirSubmissionData();
            if (Convert.ToInt64(cirids[0]) == BirDate.TurbineID)
                cirdata = GetByCirId(Convert.ToInt64(cirids[1]));
            else
                cirdata = GetByCirId(Convert.ToInt64(cirids[0]));

            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("SaveBIRCIRValueinDatabase", objCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (!ReferenceEquals(BirDate, null))
                    {
                        cmd.Parameters.Add("@MasterCIRID", SqlDbType.BigInt);
                        cmd.Parameters["@MasterCIRID"].Value = BirDate.BirDataID;

                        cmd.Parameters.Add("@CIRIDs", SqlDbType.NVarChar);
                        cmd.Parameters["@CIRIDs"].Value = BirDate.CirIDs;

                        cmd.Parameters.Add("@RawMaterial", SqlDbType.NVarChar);
                        cmd.Parameters["@RawMaterial"].Value = BirDate.RawMaterials;

                        cmd.Parameters.Add("@ConculsionRecomm", SqlDbType.NVarChar);
                        cmd.Parameters["@ConculsionRecomm"].Value = BirDate.ConclusionsAndRecommendations;

                        cmd.Parameters.Add("@RepairingSol", SqlDbType.NVarChar);
                        cmd.Parameters["@RepairingSol"].Value = BirDate.RepairingSolutions;

                        cmd.Parameters.Add("@TurbineID", SqlDbType.BigInt);
                        cmd.Parameters["@TurbineID"].Value = BirDate.TurbineID;

                        cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                        cmd.Parameters["@CreatedBy"].Value = BirDate.CreatedBy;

                        cmd.Parameters.Add("@RETURNVALUE", SqlDbType.BigInt);
                        cmd.Parameters["@RETURNVALUE"].Direction = ParameterDirection.Output;


                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dsBirData); string dataType = "BIR";
                            birDataId = Convert.ToInt64(cmd.Parameters["@RETURNVALUE"].Value);
                            ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Generating BIRPdfReport for BIRDataID: " + birDataId.ToString(), LogType.Information, "");
                            try
                            {
                                //wordBytes = DAL.DABIRReport.RenderBirReportforCosmos(birDataId);
                                objBirDetails = GetBirDataByID(birDataId);

                                DocumentClient _documentClient = new DocumentClient(new Uri(endPointURI), primaryKey);
                                BirDataDetails existingBirDataDetails = _documentClient.CreateDocumentQuery<BirDataDetails>(
                                       UriFactory.CreateDocumentCollectionUri(databaseId, collectionName),
                                       new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                                   .Where(x => x.BirDataID == birDataId).AsEnumerable().FirstOrDefault();
                                if (existingBirDataDetails != null)
                                {
                                    birDataUri = existingBirDataDetails.WordBytesUrl.ToString();
                                    birDataDocumentId = existingBirDataDetails.Id;
                                }
                                if (cirdata != null && cirdata.Data != null)
                                {
                                    objBirDetails.IsAnnualInspection = cirdata.Data.ctbAnnualInspection;
                                }
                                
                                //objBirDetails.WordBytesUrl = DAGir.SaveWordBytesToBlob(wordBytes, birDataUri, objBirDetails.TurbineId, objBirDetails.BirCode, dataType, objBirDetails.IsAnnualInspection.ToString(), BirDate.CirIDs);
                                objBirDetails.WordDocStatus = "NotGenerated";
                                objBirDetails.PDFStatus = "NotGenerated";
                                SaveBirDatatoCosmosDb(objBirDetails, birDataDocumentId);

                                try
                                {
                                    //RenderWordBytesAsync(birDataId, objBirDetails, objBirDetails.WordBytesUrl.AbsoluteUri, dataType, birDataDocumentId, BirDate.CirIDs).ConfigureAwait(false);
                                    RenderWordBytesAsync(birDataId, objBirDetails, birDataUri, birDataDocumentId, BirDate.CirIDs).ConfigureAwait(false);
                                }

                                catch (Exception ex)
                                {
                                    objBirDetails.WordDocStatus = string.Format("Error: {0}", ex.InnerException);
                                    SaveBirDatatoCosmosDb(objBirDetails, birDataDocumentId);
                                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "BIRPdfReport Error render words bytes ", LogType.Error, "");
                                }
                            }
                            catch (Exception ex)
                            {
                                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "BIRPdfReport Error Generating BIR Report", LogType.Error, "");

                            }

                            if (dsBirData.Tables.Count > 0)
                            {
                                //return oBir;
                            }


                        }
                    }
                }
            }


            return oBir;
        }



        /// <summary>
        /// Render Word Bytes and save in blob/Cosmos DB
        /// </summary>
        /// <param name="birDataId">birDataId</param>
        /// <returns></returns>
        private static async Task RenderWordBytesAsync(long birDataId, BirDataDetails objBirDetails, string birDataUri, string birDataDocumentId, string cirIds)
        {
            string dataType = "BIR";           
            var context = HttpContext.Current;
            byte[] wordBytes = await Task.Run(() => DABIRReport.RenderBirReportforCosmos(birDataId, context));
            objBirDetails.WordBytesUrl = DABir.SaveWordBytesToBlob(wordBytes, birDataUri, objBirDetails.TurbineId, objBirDetails.BirCode, dataType, objBirDetails.Modified,objBirDetails.IsAnnualInspection.ToString(), cirIds);
            objBirDetails.WordDocStatus = "Generated";
            SaveBirDatatoCosmosDb(objBirDetails, birDataDocumentId);
            await Task.Run(() => DABIRReport.GetBirPDF(birDataId));
        }
        /// <summary>
        /// Get Cir DataId by id
        /// </summary>
        /// <param name="CirIds">Object of Bir text</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetCirDataIdByCirID(string CirIDs)
        {
            Dictionary<string, string> dicCirCollection = new Dictionary<string, string>();
            DataSet CIRList = new DataSet();


            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                string query = string.Format(@"
                               WITH CTE AS (
                               SELECT cirdata.CirId  , cirdata.CirDataId , CirData.Deleted   
                               FROM cirdata
                               where CirData.Deleted =0
                            )
                            SELECT  max(cte.CirDataId) as CirDataId
                            FROM
                            ComponentInspectionReport INNER JOIN cte 
                            ON ComponentInspectionReport.ComponentInspectionReportId = cte.CirId  
                            and ComponentInspectionReport.FormIOGUID in ({0}) 
                            group by cte.CirDataId
	                           ", CirIDs);

                using (SqlCommand cmd = new SqlCommand(query, objCon))
                {
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataAdapter sqlda = new SqlDataAdapter(cmd))
                    {
                        sqlda.Fill(CIRList);
                    }
                    var CLIST = CIRList.Tables[0];
                    DANotification da = new DANotification();
                    List<int> lst = new List<int>();
                    foreach (DataRow c in CLIST.Rows)
                    {
                        lst.Add(Convert.ToInt32(c["CirDataId"]));
                    }

                    dicCirCollection.Add("MasterCirDataId", lst.Max().ToString());
                    dicCirCollection.Add("CirDataIds", string.Join("/", lst.ToArray()));
                }
            }

            return dicCirCollection;
        }

        /// <summary>
        /// Save bir data details in cosmos db
        /// </summary>
        /// <param name="oBirDetails"></param>
        /// <param name="birDataDocumentId"></param>
        public static void SaveBirDataDetailstoCosmosDb(BirDataDetails oBirDetails, string birDataDocumentId)
        {
            DocumentClient objDocClient = new DocumentClient(new Uri(endPointURI), primaryKey);
            //Get the doc back as a Document so you have access to doc.SelfLink
            var retObjBirDataDetails = objDocClient.CreateDocumentQuery<BirDataDetails>(
                                      UriFactory.CreateDocumentCollectionUri(databaseId, collectionName),
                                       new FeedOptions { EnableCrossPartitionQuery = true })
                                      .Where(x => x.BirDataID == oBirDetails.BirDataID)
                                      .AsEnumerable().FirstOrDefault();
            // This is for old data which haven't "/Doc/" folder path in WordBytesUrl.
            var checkBirDataDetails = retObjBirDataDetails?.WordBytesUrl?.AbsoluteUri?? null;
            if (checkBirDataDetails != null)
            {
                if (!(retObjBirDataDetails.WordBytesUrl.AbsoluteUri).Contains("/Doc/") && !(retObjBirDataDetails.WordBytesUrl.AbsoluteUri).Contains(".docx"))
                {
                    objDocClient.DeleteDocumentAsync(UriFactory.CreateDocumentUri(databaseId, collectionName, retObjBirDataDetails.Id));
                    retObjBirDataDetails = null;
                }
            }
            //End
            oBirDetails.WordDocStatus = "Generated"; oBirDetails.PDFStatus = "Generated";
            string birDataUri = string.Empty;
            if (retObjBirDataDetails != null)
            {
                birDataDocumentId = retObjBirDataDetails.Id;
                birDataUri = Convert.ToString(retObjBirDataDetails.WordBytesUrl.AbsoluteUri);
                oBirDetails.WordBytesUrl = retObjBirDataDetails.WordBytesUrl;
                retObjBirDataDetails.WordDocStatus = oBirDetails.WordDocStatus;
                retObjBirDataDetails.PDFStatus = oBirDetails.PDFStatus;
            }
            
            if (oBirDetails.WordBytesUrl == null)
            {
                Bir oBir = new Bir(); string dataType = "BIR";
                using (CIM_CIREntities context = new CIM_CIREntities())
                {
                    Edmx.BirWordDocument objBirData = (from s in context.BirWordDocument
                                                       where s.BirDataID == oBirDetails.BirDataID
                                                       select s).FirstOrDefault();
                    oBirDetails.WordBytesUrl = DAGir.SaveWordBytesToBlob(objBirData.WordDocBytes, birDataUri, Convert.ToString(oBirDetails.TurbineId), oBirDetails.BirCode, dataType, oBirDetails.Modified, null, oBirDetails.CirIDs);
                }
            }

            if (string.IsNullOrEmpty(birDataDocumentId))
                objDocClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseId, collectionName), oBirDetails).ConfigureAwait(false);
            else
                objDocClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseId, collectionName, retObjBirDataDetails.Id), retObjBirDataDetails).ConfigureAwait(false);
            

        }

        /// <summary>
        /// Save bir data details in cosmos db
        /// </summary>
        /// <param name="oBirDetails"></param>
        /// <param name="birDataDocumentId"></param>
        public static void SaveBirDatatoCosmosDb(BirDataDetails oBirDetails, string birDataDocumentId)
        {
            DocumentClient _documentClient = new DocumentClient(new Uri(endPointURI), primaryKey);
            //Get the doc back as a Document so you have access to doc.SelfLink
            var retObjBirDataDetails = _documentClient.CreateDocumentQuery<BirDataDetails>(
                                      UriFactory.CreateDocumentCollectionUri(databaseId, collectionName),
                                       new FeedOptions { EnableCrossPartitionQuery = true })
                                      .Where(x => x.BirDataID == oBirDetails.BirDataID)
                                      .AsEnumerable().FirstOrDefault();

            string birDataUri = string.Empty;
            if (retObjBirDataDetails != null)
            {
                birDataDocumentId = retObjBirDataDetails.Id;
                //birDataUri = Convert.ToString(retObjBirDataDetails.WordBytesUrl.AbsoluteUri);
                retObjBirDataDetails.WordDocStatus = oBirDetails.WordDocStatus;
                retObjBirDataDetails.PDFStatus = oBirDetails.PDFStatus;
                retObjBirDataDetails.WordBytesUrl = oBirDetails.WordBytesUrl;
            }           

            if (string.IsNullOrEmpty(birDataDocumentId))
                _documentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseId, collectionName), oBirDetails).ConfigureAwait(false);
            else
                _documentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseId, collectionName, retObjBirDataDetails.Id), retObjBirDataDetails).ConfigureAwait(false);


        }

        /// <summary>
        /// Get connection string
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CIM_MasterDataConn"].ConnectionString;
        }

        /// <summary>
        /// Get bir data by id
        /// </summary>
        /// <param name="BirID"></param>
        /// <returns></returns>
        public static BirDataDetails GetBirDataByID(long BirID)
        {
            BirDataDetails objBIRView = new BirDataDetails();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                var cmd = new SqlCommand { Connection = conn };
                SqlDataReader reader = null;
                string whereClauseOrder = "";
                whereClauseOrder += "bd.Deleted = 0 AND bd.BirDataID = " + BirID.ToString();

                try
                {
                    cmd.CommandText = string.Format(@"
                                    SELECT [BirDataID],[BirCode], [RevisionNumber],CirDataId, CirIDs,Created,CreatedBy,Modified,ModifiedBy,SiteAddress,TurbineNumber,TurbineType,Country,SBU,BladeSerialNos,RepairingSolutions,RawMaterials,ConclusionsAndRecommendations,CommisioningDate
                                    FROM (
	                                    SELECT BD.[BirDataID],BD.[BirCode], BD.[RevisionNumber], BD.CirIDs,
                                    cd.CirDataId,  bd.Created Created, bd.CreatedBy CreatedBy,bd.Modified Modified,bd.ModifiedBy ModifiedBy,isnull(td.[Site],'')SiteAddress,CMI.TurbineNumber, td.TurbineType,td.Country,sbu.[Name] as SBU,bd.BladeSerialNos,RepairingSolutions,RawMaterials,ConclusionsAndRecommendations,
                                        CMI.CommisioningDate as CommisioningDate, ROW_NUMBER() OVER(
		                                    ORDER BY  BD.[Created] desc
	                                    ) AS RowNumber
	                                    FROM
	                                    [dbo].[BirData] BD  WITH(NOLOCK)
                                    inner  join [dbo].[MapBirCir] MPC  WITH(NOLOCK)
                                    on MPC.BirDataID = BD.BirDataID and MPC.Master = 1
                                    inner join 
                                    dbo.CIRData cd  WITH(NOLOCK) on cd.[CirDataId] = MPC.CirDataID
                                    left join ComponentInspectionReport CMI on CMI.ComponentInspectionReportId = cd.[CirId] 
                                    left  JOIN [dbo].[SBU] sbu WITH(NOLOCK) ON CMI.SBUId = sbu.[SBUId]
                                    left join TurbineData td on  td.TurbineId = CONVERT(VARCHAR(50),CMI.TurbineNumber)
	                                    WHERE {0} 
		                                    ) CirDataPage
                                    ", whereClauseOrder);

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objBIRView = new BirDataDetails
                        {
                            BirDataID = reader["BirDataId"] == DBNull.Value ? 0 : Convert.ToInt64(reader["BirDataId"]),
                            BirCode = Convert.ToString(reader["BirCode"]),
                            RevisionNumber = Convert.ToInt32(reader["RevisionNumber"]),
                            CirIDs = Convert.ToString(reader["CirIDs"]),
                            Created = reader.GetDateTime(reader.GetOrdinal("Created")),
                            CreatedBy = reader.GetString(reader.GetOrdinal("Createdby")),
                            Modified = reader.GetDateTime(reader.GetOrdinal("Modified")),
                            //ModifiedBy = reader.GetString(reader.GetOrdinal("ModifiedBy")),
                            TurbineId = Convert.ToString(reader["TurbineNumber"]),
                            BladeSerialNos = Convert.ToString(reader["BladeSerialNos"]),
                            RepairingSolutions = Convert.ToString(reader["RepairingSolutions"]),
                            RawMaterials = Convert.ToString(reader["RawMaterials"]),
                            ConclusionsAndRecommendations = Convert.ToString(reader["ConclusionsAndRecommendations"])
                            // Id = GenerateKey()

                        };
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting BIR Data: " + ex.Message.ToString());
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
            return objBIRView;
        }

        //private static string GenerateKey()
        //{
        //    Guid g;
        //    g = Guid.NewGuid();

        //    return g.ToString();
        //}

        /// <summary>
        /// save word bytes to blob
        /// </summary>
        /// <param name="wordBytes"></param>
        /// <param name="birDataUri"></param>
        /// <param name="turbineNumber"></param>
        /// <returns></returns>
        public static Uri SaveWordBytesToBlob(byte[] wordBytes, string birDataUri, string turbineNumber, string fileName, string dataType, DateTime modified, string IsAnnualInspection = null, string RelatedCIRs = null, string fileType = "Doc")
        {
            CloudBlobClient blobClient;
            CloudBlobContainer container;

            string containerName = System.Configuration.ConfigurationManager.AppSettings["AzureStorageImgContainerName"];
            var storageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse(System.Configuration.ConfigurationManager.AppSettings["AzureStorageConnectionString"]);
            blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference(containerName);
            //container.CreateIfNotExists();
            string blobId, directoryName, directoryNamePdf = string.Empty;
            if (string.IsNullOrEmpty(birDataUri))
            {
                blobId = GetKey(container);
                if (dataType == "BIR" || dataType == "GIR" || dataType == "GBXIR")
                {
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
                }
                else directoryName = $"{turbineNumber}/{dataType}/{blobId}";
            }
            else
            {
                CloudBlockBlob Blob = new CloudBlockBlob(new Uri(birDataUri));
                //blobId = Blob.Name;
                directoryName = Blob.Name;
                if (fileType == "pdf")               
                    directoryNamePdf = directoryName.Replace("docx", "pdf").Replace("Doc", "PDF");
                    
               
            }
            string relatedCirs = "", isAnnual = "";
            if (!string.IsNullOrEmpty(RelatedCIRs))
            {
                relatedCirs = RelatedCIRs.Replace('/', ',');
                relatedCirs = relatedCirs.Substring(relatedCirs.IndexOf(',') + 1);
                isAnnual = (relatedCirs.Split(',').Count() == 3) ? "true" : "false";
            }
            
            CloudBlockBlob objBlockBlobDoc = container.GetBlockBlobReference(directoryName);
            CloudBlockBlob objBlockBlobPdf = container.GetBlockBlobReference(directoryNamePdf);

            if (fileType == "Doc")
            {
                if (!objBlockBlobDoc.Exists())
                {
                    objBlockBlobDoc.Metadata.Add("fileName", fileName);
                    if (!string.IsNullOrEmpty(relatedCirs))
                    {
                        objBlockBlobDoc.Metadata.Add("relatedCirs", relatedCirs);
                        objBlockBlobDoc.Metadata.Add("isAnnual", isAnnual);
                    }
                    objBlockBlobDoc.Metadata.Add("modified", modified.ToString("yyyy-MM-dd HH:mm:ss"));

                }
                objBlockBlobDoc.UploadFromByteArray(wordBytes, 0, wordBytes.Length);
            }

            if (fileType == "pdf")
            {
                if (!objBlockBlobPdf.Exists())
                {
                    objBlockBlobPdf.Metadata.Add("fileName", fileName);
                    if (!string.IsNullOrEmpty(relatedCirs))
                    {
                        objBlockBlobPdf.Metadata.Add("relatedCirs", relatedCirs);
                        objBlockBlobPdf.Metadata.Add("isAnnual", isAnnual);
                    }
                    objBlockBlobPdf.Metadata.Add("modified", modified.ToString("yyyy-MM-dd HH:mm:ss"));
                }
               
                objBlockBlobPdf.UploadFromByteArray(wordBytes, 0, wordBytes.Length);
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
            string key = Guid.NewGuid().ToString();
            CloudBlockBlob blockBlob = new CloudBlockBlob(GetBlobSASUri(key, "CreateBlob"));
            return (!blockBlob.Exists()) ? key : GetKey(container);
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

        public static CloudBlockBlob GetBlockBlob(string blobName)
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
            return blockBlob;

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
                //   Uri sasBlobUri = GetBlobSASUri(Blob.Name, "ReadBlob");
                var blockBlob = GetBlockBlob(Blob.Name);
                return blockBlob.Uri.AbsoluteUri;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static CloudBlockBlob GetBlobByImageUrl(string imageUrl)
        {
            try
            {
                CloudBlockBlob Blob = new CloudBlockBlob(new Uri(imageUrl));
                var blockBlob = GetBlockBlob(Blob.Name);
                return blockBlob;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetBlobSASUri(string imageUrl)
        {
            string sasBlobUri = (imageUrl.ToString().Split('/')[2].Split(':')[0]);
            string sasBlobToken = string.Empty;
            //CloudBlockBlob Blob = new CloudBlockBlob(new Uri(sasBlobUri));
            switch (sasBlobUri.ToString())
            {
                case "cirprodblobstorage.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken0"];
                    break;
                case "cirprodblobstorage1.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken1"];
                    break;
                case "cirprodblobstorage2.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken2"];
                    break;
                case "cirprodblobstorage3.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken3"];
                    break;
                case "cirprodblobstorage4.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken4"];
                    break;
                case "cirprodblobstorage5.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken5"];
                    break;
                case "cirprodblobstorage6.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken6"];
                    break;
                case "cirprodblobstorage7.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken7"];
                    break;
                case "cirprodblobstorage8.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken8"];
                    break;
                case "cirprodblobstorage9.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken9"];
                    break;
                case "cirprodblobstorage10.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken10"];
                    break;
                case "cirprodblobstorage11.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken11"];
                    break;
                case "cirprodblobstorage12.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken12"];
                    break;
                case "cirprodblobstorage13.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken13"];
                    break;
                case "cirprodblobstorage14.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken14"];
                    break;
                case "cirprodblobstorage15.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken15"];
                    break;
                default:
                    break;
            }
            return sasBlobToken;
        }
        /// <summary>
        /// Get related cirs data by cir id
        /// </summary>
        /// <param name="CirIDs"></param>
        /// <returns></returns>
        public static string GetRelatedCirsIdByCirId(string cirId)
        {
            string relatedCirs = string.Empty;
            DataSet dsRelatedCirs = new DataSet();
            if (!string.IsNullOrEmpty(cirId))
                using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("GetMigrationRelatedCirs", objCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (!ReferenceEquals(cirId, null))
                        {

                            cmd.Parameters.Add("@CirId", SqlDbType.NVarChar);
                            cmd.Parameters["@CirId"].Value = cirId;

                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                da.Fill(dsRelatedCirs);
                                if (dsRelatedCirs != null && dsRelatedCirs.Tables[0].Rows.Count > 0)
                                    relatedCirs = dsRelatedCirs.Tables[0].Rows[0].Field<string>("RelatedCirs");
                            }
                        }
                    }
                }
            return relatedCirs.Trim();
        }
        #region BIR MigrationData    
        public static List<Bir> GetBirMigrationData()
        {
            Bir objBIRView = new Bir();
            List<Bir> lstBir = new List<Bir>();
            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("GetBIRMigrationData", objCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    if (!ReferenceEquals(dt, null) && dt.Rows.Count > 0)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow drH in dt.Rows)
                            {
                                Bir oBir = new Bir();
                                oBir.BirDataID = Convert.ToInt64(drH["BirDataID"]);
                                oBir.BirCode = Convert.ToString(drH["BirCode"]);
                                oBir.RevisionNumber = Convert.ToInt32(drH["RevisionNumber"]);
                                oBir.RepairingSolutions = Convert.ToString(drH["RepairingSolutions"]);
                                oBir.RawMaterials = Convert.ToString(drH["RawMaterials"]);
                                oBir.ConclusionsAndRecommendations = Convert.ToString(drH["ConclusionsAndRecommendations"]);
                                oBir.CirIDs = Convert.ToString(drH["CirIDs"]);
                                oBir.Created = Convert.ToDateTime(drH["Created"]);
                                oBir.CreatedBy = Convert.ToString(drH["CreatedBy"]);
                                oBir.TurbineID = Convert.ToInt32(drH["TurbineNumber"]);
                                oBir.Modified = Convert.ToDateTime(drH["Modified"]);
                                oBir.ModifiedBy = Convert.ToString(drH["ModifiedBy"]);
                                oBir.Deleted = Convert.ToBoolean(drH["Deleted"]);
                                oBir.BladeSerialNos = Convert.ToString(drH["BladeSerialNos"]);
                                lstBir.Add(oBir);
                            }
                        }

                    }

                }
            }
            return lstBir;
        }
        #endregion
    }

    public class CirSubmissionData
    {
        [JsonProperty(PropertyName = "cirId")]
        public long CirId { get; set; }

        [JsonProperty(PropertyName = "schema")]
        public object Schema { get; set; }

        [JsonProperty(PropertyName = "data")]
        public data Data { get; set; }

        [JsonProperty(PropertyName = "partition")]
        public string Partition { get; set; } // { get { return "partition"; } set { } }

        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "errors")]
        public IList<string> Errors { get; set; }

        [JsonProperty(PropertyName = "delegatedBy")]
        public string DelegatedBy { get; set; }

        [JsonProperty(PropertyName = "delegatedTo")]
        public string DelegatedTo { get; set; }

        [JsonProperty(PropertyName = "isLockedByTos")]
        public bool IsLockedByTos { get; set; }

        [JsonProperty(PropertyName = "isSentToInspecTool")]
        public bool IsSentToInspecTool { get; set; }

        [JsonProperty(PropertyName = "statusChangedBy")]
        public string StatusChangedBy { get; set; }

    }

    public class data
    {
        [JsonProperty(PropertyName = "ctbAnnualInspection")]
        public bool ctbAnnualInspection { get; set; }
    }

}



