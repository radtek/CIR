using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cir.Sync.Services.Edmx;
using Cir.Sync.Services.DataContracts;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Cir.Sync.Services.ErrorHandling;
using Novacode;
using Spire.Doc;
using Spire.Doc.Documents;
using System.IO;
using Spire.Pdf;
using Spire.Pdf.HtmlConverter;
using ICSharpCode.SharpZipLib.Zip;
using System.Reflection;
using Microsoft.Azure.Documents.Client;

namespace Cir.Sync.Services.DAL
{
    public class DAGBXReport
    {
        static List<MasterKeyData> masterData = null;
        public static bool RenderGbxReport(long GbxId)
        {
            byte[] wordBytes = null;
            GbxView gbxView = new GbxView();
            string RelatedCIR = string.Empty;

            wordBytes = GetPdf(GbxId);
            if (ReferenceEquals(wordBytes, null))
            {

                #region Retrieving placeholders
                //  List<Cir.Common.GbxPdf.Placeholders> Placeholder = GetPlaceholders(1);
                #endregion

                #region Retrieving Standard texts
                IEnumerable<StandardTexts> lstStandardText = GetStandardTexts(2);
                #endregion

                #region Retrieving GBX data
                gbxView = GetGbxDataByID(GbxId, out RelatedCIR
                            );
                #endregion


                if (!string.IsNullOrEmpty(RelatedCIR))
                {
                    gbxView.Cirs = new List<long>();
                    long cirDataID = -1;
                    foreach (var CirDataID in RelatedCIR.Split(','))
                        if (long.TryParse(CirDataID, out cirDataID))
                        {
                            gbxView.Cirs.Add(cirDataID);


                        }
                }


                CIR.TurbineProperties oTurbineData = GetTurbineData(gbxView.TurbineNumber);

                string ContractName = GetContractName(Convert.ToInt64(gbxView.TurbineNumber));

                wordBytes = GenerateWordDocument
               (
                   Gbx: gbxView,
                   StandardTexts: lstStandardText,
                   TurbineData: oTurbineData,
                   ContractName: ContractName
               );
                if (!ReferenceEquals(wordBytes, null))
                {
                    SaveGeneratePdf
                        (
                            GbxDataId: gbxView.GbxDataId,
                            GbxCode: gbxView.GbxCode,
                            pdfFile: wordBytes
                        );
                }
            }
            return true;
        }

        public static byte[] RenderGbxirReportforCosmos(long GbxId)
        {
            byte[] wordBytes = null;
            GbxView gbxView = new GbxView();
            string RelatedCIR = string.Empty;

            wordBytes = GetPdf(GbxId);
            if (ReferenceEquals(wordBytes, null))
            {

                #region Retrieving placeholders
                //  List<Cir.Common.GbxPdf.Placeholders> Placeholder = GetPlaceholders(1);
                #endregion

                #region Retrieving Standard texts
                IEnumerable<StandardTexts> lstStandardText = GetStandardTexts(2);
                #endregion

                #region Retrieving GBX data
                gbxView = GetGbxDataByID(GbxId, out RelatedCIR
                            );
                #endregion


                if (!string.IsNullOrEmpty(RelatedCIR))
                {
                    gbxView.Cirs = new List<long>();
                    long cirDataID = -1;
                    foreach (var CirDataID in RelatedCIR.Split(','))
                        if (long.TryParse(CirDataID, out cirDataID))
                        {
                            gbxView.Cirs.Add(cirDataID);
                        }
                }

                CIR.TurbineProperties oTurbineData = GetTurbineData(gbxView.TurbineNumber);

                string ContractName = GetContractName(Convert.ToInt64(gbxView.TurbineNumber));

                wordBytes = GenerateWordDocument
               (
                   Gbx: gbxView,
                   StandardTexts: lstStandardText,
                   TurbineData: oTurbineData,
                   ContractName: ContractName
               );
                if (!ReferenceEquals(wordBytes, null))
                {
                    SaveGeneratePdf
                        (
                            GbxDataId: gbxView.GbxDataId,
                            GbxCode: gbxView.GbxCode,
                            pdfFile: wordBytes
                        );
                }
            }
            return wordBytes;
        }

        public static GbxFile RenderGBXirReport(long GbxId, int laguangeId)
        {
            byte[] wordBytes = null;
            GbxView gbxView = new GbxView();
            string RelatedCIR = string.Empty;
            GbxFile objGbxFile = new GbxFile();


            if (ReferenceEquals(wordBytes, null))
            {

                #region Retrieving placeholders
                //  List<Cir.Common.BirPdf.Placeholders> Placeholder = GetPlaceholders(1);
                #endregion

                #region Retrieving Standard texts
                IEnumerable<StandardTexts> lstStandardText = GetStandardTexts(1);
                #endregion

                #region Retrieving GBX data
                gbxView = GetGbxDataByID(GbxId, out RelatedCIR
                            );
                #endregion

                if (!string.IsNullOrEmpty(RelatedCIR))
                {
                    gbxView.Cirs = new List<long>();
                    long cirDataID = -1;
                    foreach (var CirDataID in RelatedCIR.Split(','))
                        if (long.TryParse(CirDataID, out cirDataID))
                        {
                            gbxView.Cirs.Add(cirDataID);
                        }
                }

                CIR.TurbineProperties oTurbineData = GetTurbineData(gbxView.TurbineNumber);

                string ContractName = GetContractName(Convert.ToInt64(gbxView.TurbineNumber));

                DocumentClient _documentClient = new DocumentClient(new Uri(DAGir.endPointURI), DAGir.primaryKey);
                GBXirDataDetails existingGbxDataDetails = _documentClient.CreateDocumentQuery<GBXirDataDetails>(
                       UriFactory.CreateDocumentCollectionUri(DAGir.databaseId, DAGir.collectionName),
                       new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                   .Where(x => x.GbxDataID == GbxId).AsEnumerable().FirstOrDefault();
                if (existingGbxDataDetails != null)
                {
                    wordBytes = DABIRReport.GetWordBytes(Convert.ToString(existingGbxDataDetails.WordBytesUrl));
                }
                else
                {
                    wordBytes = GenerateWordDocument
                   (
                       Gbx: gbxView,
                       StandardTexts: lstStandardText,
                       TurbineData: oTurbineData,
                       ContractName: ContractName
                   );
                }
                if (!ReferenceEquals(wordBytes, null))
                {

                    objGbxFile.FileBytes = wordBytes;
                    objGbxFile.FileName = gbxView.GbxCode;
                    string SpireLicensePath = HttpContext.Current.Server.MapPath("~/SpireLicense");
                    Spire.License.LicenseProvider.SetLicenseFileName("license.lic");
                    Spire.License.LicenseProvider.SetLicenseFileFullPath(Path.Combine(SpireLicensePath, "license.lic"));
                    Spire.License.LicenseProvider.LoadLicense();

                    using (MemoryStream ms1 = new MemoryStream(objGbxFile.FileBytes))
                    {
                        Document doc = new Document(ms1);

                        using (MemoryStream ms2 = new MemoryStream())
                        {
                            doc.SaveToStream(ms2, Spire.Doc.FileFormat.PDF);
                            //save to byte array
                            byte[] toArray = ms2.ToArray();
                            objGbxFile.FileBytes = toArray;
                        }
                    }
                }
            }
            return objGbxFile;
        }

        public static byte[] GeneratePDFFromHTML(string html)
        {
            byte[] data = null;

            try
            {
                string SpireLicensePath = HttpContext.Current.Server.MapPath("~/SpireLicense");
                Spire.License.LicenseProvider.SetLicenseFileName("license.lic");
                Spire.License.LicenseProvider.SetLicenseFileFullPath(Path.Combine(SpireLicensePath, "license.lic"));
                Spire.License.LicenseProvider.LoadLicense();
                Spire.Pdf.PdfDocument pdf = new PdfDocument();
                PdfHtmlLayoutFormat htmlLayoutFormat = new Spire.Pdf.HtmlConverter.PdfHtmlLayoutFormat();
                htmlLayoutFormat.IsWaiting = false;
                PdfPageSettings seting = new PdfPageSettings();
                seting.Size = PdfPageSize.A4;
                System.Threading.Thread thread = new System.Threading.Thread(() => { pdf.LoadFromHTML(html, true, seting, htmlLayoutFormat); });
                thread.SetApartmentState(System.Threading.ApartmentState.STA);
                thread.Start();
                thread.Join();

                using (MemoryStream ms2 = new MemoryStream())
                {
                    pdf.SaveToStream(ms2, Spire.Pdf.FileFormat.PDF);
                    //save to byte array
                    data = ms2.ToArray();
                }
            }
            catch (Exception ex)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error Generating GBX PDF : " + ex.Message, LogType.Error, "");

            }
            return data;
        }

        // To get the pdf from ManageGBX/ CIR Download and Approve
        public static Gbx GetCIRPdf(long CirDataId, long CirId = 0)
        {

            Gbx oGbx = new Gbx();

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                string Guid = string.Empty;
                if (CirDataId > 0)
                    Guid = context.CirData.Where(x => x.CirDataId == CirDataId && x.Deleted == false).Select(x => x.Guid).FirstOrDefault();
                else
                    Guid = context.CirData.Where(x => x.CirId == CirId && x.Deleted == false).OrderByDescending(z => z.CirDataId).Select(x => x.Guid).FirstOrDefault();
                if (Guid != null)
                {
                    PDF pdf = context.PDF.Where(x => x.CIRTemplateGUID == Guid).OrderByDescending(x => x.PDFId).FirstOrDefault();
                    if (pdf != null)
                    {
                        oGbx.File = new GbxFile() { Id = CirDataId, FileName = pdf.CIRName, FileBytes = pdf.PDFData };

                    }
                }
            }
            return oGbx;
        }

        public static Gbx GetCIRPdfZip(string CirDataIds)
        {
            Gbx oGbxOutput = new Gbx();
            string[] CirDataIdArray = CirDataIds.Split(',');
            MemoryStream outputMemStream = new MemoryStream();
            ZipConstants.DefaultCodePage = System.Text.Encoding.Default.CodePage;
            using (ZipOutputStream zipstream = new ZipOutputStream(outputMemStream))
            {
                foreach (string Id in CirDataIdArray)
                {
                    long CirDataId = 0;
                    long.TryParse(Id, out CirDataId);
                    if (CirDataId > 0)
                    {
                        Gbx oGbx = GetCIRPdf(CirDataId);
                        if (oGbx.File != null)
                        {
                            byte[] fileBytes = oGbx.File.FileBytes;
                            ZipEntry fileEntry = new ZipEntry(oGbx.File.FileName + ".pdf");
                            fileEntry.IsUnicodeText = true;
                            if (fileBytes == null || fileBytes.Length == 0)
                            {
                                zipstream.PutNextEntry(fileEntry);
                                zipstream.SetComment("Data Not Found");
                            }
                            else
                            {
                                zipstream.PutNextEntry(fileEntry);
                                zipstream.Write(fileBytes, 0, fileBytes.Length);
                                zipstream.CloseEntry();

                            }
                        }
                    }
                }

                zipstream.IsStreamOwner = false;
                zipstream.Finish();
                zipstream.Close();

                outputMemStream.Position = 0;
                // GetBuffer returns a raw buffer raw and so you need to account for the true length yourself.
                byte[] byteArrayOut = outputMemStream.ToArray();
                // string ss = System.Text.Encoding.UTF8.GetString(byteArrayOut);
                oGbxOutput.File = new GbxFile() { Id = 0, FileName = "CIR.zip", FileBytes = byteArrayOut };


            }
            return oGbxOutput;

        }


        public static bool SaveCIRPdf(string uid, int state, string html = "", string name = "")
        {
            try
            {
                byte[] data = null;
                if (!string.IsNullOrEmpty(html))
                {
                    data = GeneratePDFFromHTML(html);
                }


                using (CIM_CIREntities context = new CIM_CIREntities())
                {

                    PDF pdf = context.PDF.Where(x => x.CIRTemplateGUID == uid).FirstOrDefault();
                    if (pdf == null && data != null)
                    {
                        pdf = new PDF();
                        pdf.CIRTemplateGUID = uid;
                        pdf.CIRState = (int)state;
                        pdf.CIRName = name;
                        pdf.PDFData = data;
                        context.PDF.Add(pdf);
                    }
                    else
                    {
                        pdf.CIRState = (int)state;
                        pdf.CIRName = name;
                        if (data != null)
                        {
                            pdf.PDFData = data;
                        }
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "uid :" + uid + ":state:" + state.ToString() + ":name:" + name + ":html:" + html, LogType.Error, "");

            }
            return true;

        }

        public static void UpdateTOC(string filename)
        {


            string SpireLicensePath = HttpContext.Current.Server.MapPath("~/SpireLicense");
            Spire.License.LicenseProvider.SetLicenseFileName("license.lic");
            Spire.License.LicenseProvider.SetLicenseFileFullPath(Path.Combine(SpireLicensePath, "license.lic"));
            Spire.License.LicenseProvider.LoadLicense();

            Document doc = new Document();
            doc.LoadFromFile(filename);
            doc.UpdateTableOfContents();
            doc.SaveToFile(filename);
        }

        public static Gbx GetGbxPDF(long GbxID)
        {
            Gbx oGbx = DAL.DAGbx.GbxFileBytes(GbxID);

            string SpireLicensePath = HttpContext.Current.Server.MapPath("~/SpireLicense");
            Spire.License.LicenseProvider.SetLicenseFileName("license.lic");
            Spire.License.LicenseProvider.SetLicenseFileFullPath(Path.Combine(SpireLicensePath, "license.lic"));
            Spire.License.LicenseProvider.LoadLicense();

            DocumentClient _documentClient = new DocumentClient(new Uri(DAGir.endPointURI), DAGir.primaryKey);
            GBXirDataDetails existingGBXirDataDetails = _documentClient.CreateDocumentQuery<GBXirDataDetails>(
                   UriFactory.CreateDocumentCollectionUri(DAGir.databaseId, DAGir.collectionName),
                   new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
               .Where(x => x.GbxDataID == GbxID).AsEnumerable().FirstOrDefault();
            if (existingGBXirDataDetails != null)
            {
                oGbx.File.FileBytes = DABIRReport.GetWordBytes(Convert.ToString(existingGBXirDataDetails.WordBytesUrl));
            }
            using (MemoryStream ms1 = new MemoryStream(oGbx.File.FileBytes))
            {
                Document doc = new Document(ms1);
                using (MemoryStream ms2 = new MemoryStream())
                {
                    doc.SaveToStream(ms2, Spire.Doc.FileFormat.PDF);
                    //save to byte array
                    byte[] toArray = ms2.ToArray();
                    oGbx.File.FileBytes = toArray;
                }
            }
            return oGbx;
        }

        public static void SaveGeneratePdf(long GbxDataId, string GbxCode, byte[] pdfFile)
        {
            // save PDF to database (update existing if applicable)
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                var entity = context.GBXirWordDocument.Where(x => x.GBXirDataID == GbxDataId).FirstOrDefault();

                if (entity == null)
                {
                    entity = new GBXirWordDocument();
                    entity.GBXirDataID = GbxDataId;
                    entity.GBXirCode = GbxCode;
                    entity.WordDocBytes = pdfFile;
                    context.GBXirWordDocument.Add(entity);
                }
                else
                {
                    entity.GBXirCode = GbxCode;
                    entity.WordDocBytes = pdfFile;

                }
                // save
                context.SaveChanges();
            }
        }

        public static string GetMasterKeyName(string name)
        {
            if (name == "BeforeInspectionTurbineRunStatusId" || name == "AfterInspectionTurbineRunStatusId") return "TurbineRunStatus";
            if (name == "ComponentUpTowerSolutionID") return "ComponentUpTowerSolution";
            if (name == "HVCoilConditionId" || name == "LVCoilConditionId") return "CoilCondition";
            if (name == "HVCableConditionId" || name == "LVCableConditionId") return "CableCondition";
            if (name.Contains("ArcDetectionId")) return "ArcDetection";
            if (name.Contains("AuxEquipmentId") || name.Contains("OffLineFilterId") || name.Contains("BooleanAnswerId")) return "BooleanAnswer";
            if (name.Contains("OilTypeId")) return "OilType";
            if (name.Contains("MechanicalOilPumpId")) return "MechanicalOilPump";
            if (name.Contains("OilLevelId")) return "OilLevel";
            if (name.Contains("GearboxActionToBeTakenOnGearboxId")) return "ActionToBeTakenOnGearbox";
            if (name.Contains("GearboxDebrisGearBoxId")) return "DebrisGearbox";
            if (name.Contains("GearboxShaftsTypeofDamage") && name.Contains("ShaftErrorId")) return "ShaftError";
            if (name.Contains("GearboxTypeofDamage") && name.Contains("GearErrorId")) return "GearDamageCategory";
            if (name.Contains("GearboxGearDamageClass") && name.Contains("DamageId")) return "GearDamageClass";
            if (name.Contains("GearboxGearDecision") && name.Contains("DamageDecisionId")) return "DamageDecision";
            if (name.Contains("GearboxBearingDecision") && name.Contains("DamageDecisionId")) return "GearDamageClass";
            if (name.Contains("UpTowerSolution")) return "ComponentUpTowerSolution";
            if (name.Contains("GeneratorManufacturerId2")) return "GeneratorManufacturer";
            if (name.Contains("MainBearingType")) return "MainBearingManufacturer";
            if (name.Contains("MainBearingErrorLocation")) return "MainBearingErrorLocation";


            else return name;
        }
        private static void GetNamePropertyFromID(string name, string idValue, ref Dictionary<string, string> keyValues)
        {
            string oldName = name;
            name = GetMasterKeyName(name);
            string value;
            if (name == "MainBearingErrorLocation")
            {
                value = masterData.Where(x => name.ToLower().StartsWith(x.KeyName.ToLower()) && x.KeyID == idValue.ToString()).Select(x => x.KeyValue).FirstOrDefault();
            }
            else
            {
                value = masterData.Where(x => name.ToLower().Contains(x.KeyName.ToLower()) && x.KeyID == idValue.ToString()).Select(x => x.KeyValue).FirstOrDefault();
            }
            if (!String.IsNullOrEmpty(value))
            {
                if (keyValues.ContainsKey("_" + oldName))
                    keyValues.Remove("_" + oldName);
                keyValues.Add("_" + oldName, value.ToString());
            }
            else
            {
                if (keyValues.ContainsKey("_" + oldName))
                    keyValues.Remove("_" + oldName);
                keyValues.Add("_" + oldName, " ");
            }
        }

        private static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }
        private static void FillProperties(object o, ref Dictionary<string, string> keyValues)
        {
            if (o != null)
            {
                var properties = GetProperties(o);

                foreach (var p in properties)
                {
                    try
                    {
                        string name = p.Name;
                        if (!(p.PropertyType.FullName.IndexOf("Edmx") > 0))
                        {
                            var value = p.GetValue(o, null);
                            if ((name.EndsWith("Id", StringComparison.OrdinalIgnoreCase) || name.EndsWith("Id2", StringComparison.OrdinalIgnoreCase)) && name != "BladeFaultCodeClassificationId" && name != "LocalTurbineId")
                            {
                                //  AddIdProperty(o, name, ref keyValues);
                                GetNamePropertyFromID(name, ((value == null) ? "" : value.ToString()), ref keyValues);
                            }
                            else
                            {
                                if (keyValues.ContainsKey("_" + name))
                                    keyValues.Remove("_" + name);
                                if (name.ToLower().Contains("Date".ToLower()))
                                {
                                    keyValues.Add("_" + name, ((value == null) ? " " : value.ToString().Replace("00:00:00", "")));
                                }
                                else if (name.ToLower() == ("Frequency".ToLower()))
                                {
                                    keyValues.Add("_" + name, ((value == null) ? " " : value.ToString().Replace(".000", "")));
                                }
                                else
                                {
                                    keyValues.Add("_" + name, ((value == null) ? " " : value.ToString()));
                                }
                            }
                        }

                    }
                    catch (Exception ex) { }


                }
            }
        }

        private static List<MasterKeyData> GetMasterDataForCIRReport()
        {
            List<MasterKeyData> MasterKeyDataList = new List<MasterKeyData>();
            DataSet dsMasterData = new DataSet();


            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("spCIRMasterDataAllForCIRReport", objCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsMasterData);

                        MasterKeyDataList = (from DataRow dr in dsMasterData.Tables[0].Rows
                                             select new MasterKeyData()
                                             {
                                                 KeyName = dr[0].ToString(),
                                                 KeyID = dr[1].ToString(),
                                                 KeyValue = dr[2].ToString()

                                             }).ToList();
                    }
                }
            }

            return MasterKeyDataList;
        }

        public static byte[] GenerateWordDocument(GbxView Gbx, IEnumerable<StandardTexts> StandardTexts, CIR.TurbineProperties TurbineData, string ContractName)
        {
            byte[] wordDocBytes = null;
            try
            {
                Dictionary<string, string> keyValuesPairs = new Dictionary<string, string>();
                string DocumentPath = HttpContext.Current.Server.MapPath("GBXTemplates");

                try
                {
                    if (!Directory.Exists(DocumentPath))
                    {
                        Directory.CreateDirectory(DocumentPath);
                    }
                }
                catch { return null; }

                #region Deleting existing contents
                DeleteDirectoryContents(DocumentPath);
                #endregion

                string sourceGearboxTemplate = string.Empty;
                if (Gbx.Cirs.Count == 1)
                    sourceGearboxTemplate = Path.Combine(DocumentPath, @"Templates\DC_Inspection_Template_Gearbox.docx");

                string destinationGearboxTemplate = Path.Combine(DocumentPath, Gbx.GbxCode.Replace("/", string.Empty).Replace(@"\", string.Empty).Trim() + ".docx");

                // Create a copy of the template file and open the copy 
                File.Copy(sourceGearboxTemplate, destinationGearboxTemplate, true);

                #region Gearbox pictures
                AddGearboxPicturesTable(
                destinationGearboxTemplate,
                 Gbx);
                #endregion

                // create key value pair, key represents words to be replace and 
                //values represent values in document in place of keys.
                Dictionary<string, string> keyValues = new Dictionary<string, string>();

                masterData = GetMasterDataForCIRReport();

                #region Component specific
                keyValues.Add("#GBXNAME#", Gbx.GbxCode);
                keyValues.Add("#OILANALYSIS#", Gbx.OilAnalysis);
                keyValues.Add("#CMSANALYSIS#", Gbx.CMSAnalysis);
                keyValues.Add("#ANALYSIS#", Gbx.Analysis);
                keyValues.Add("#CONCLUSIONRECOMMENDATION#", Gbx.ConculsionRecomm);
                keyValues.Add("#CREATED#", string.Format("{0:dd MMMM, yyyy}", Gbx.Created));
                keyValues.Add("#CREATEDBY#", Gbx.Createdby);
                keyValues.Add("#MASTERAUTHOR#", Gbx.Createdby);
                keyValues.Add("#CUSTOMER#", ContractName);
                keyValues.Add("#GEARBOXTYPE#", Gbx.GearboxType);
                keyValues.Add("#GEARBOXREVISION#", Gbx.GearboxRevision);
                keyValues.Add("#GEARBOXSERIALNO#", Gbx.GearboxSerialNos);
                keyValues.Add("#INSTALLATIONDATE#", string.Format("{0:dd MMMM, yyyy}", Gbx.InstallationDate));
                keyValues.Add("#INSPECTIONDATE#", string.Format("{0:dd MMMM, yyyy}", Gbx.InspectionDate));
                keyValues.Add("#REASONFORSERVICE#", Gbx.ReasonForService);
                keyValues.Add("#DESCRIPTION#", Gbx.Description);
                keyValues.Add("#SBURecommendation#", Gbx.SBURecommendation);
                keyValues.Add("#AdditionalInformation#", Gbx.AdditionalInfo);
                keyValues.Add("#GearboxLSSNRend#", Gbx.gearboxLSSNRend);
                keyValues.Add("#GearboxIMSNRend#", Gbx.GearboxIMSNRend);
                keyValues.Add("#GearboxHSSNRend#", Gbx.GearboxHSSNRend);
                keyValues.Add("#GearboxHSSRend#", Gbx.GearboxHSSRend);
                keyValues.Add("#GearboxIMSRend#", Gbx.GearboxIMSRend);

                #endregion

                #region Turbine specific
                if (!ReferenceEquals(TurbineData, null))
                {
                    keyValues.Add("#WTG#", TurbineData.Turbine + " " + TurbineData.NominelPower);
                    keyValues.Add("#TurbineType#", Gbx.TurbineType + "-" + TurbineData.NominelPower + "-" + TurbineData.Frequency + "-" + TurbineData.Voltage + "-" + TurbineData.MarkVersion);
                    keyValues.Add("#WTGNO#", Gbx.TurbineNumber);
                    keyValues.Add("#WTGLOCALID#", TurbineData.LocalTurbineId);
                    keyValues.Add("#TURBINETYPEVNM#", Gbx.TurbineType);
                    keyValues.Add("#NOMINELPOWER#", Convert.ToString(TurbineData.NominelPower));
                    keyValues.Add("#WINDTURBINE#", Convert.ToString(TurbineData.Turbine));
                }
                #endregion

                #region Component serials
                //string BladeRotors = string.Empty;
                //for (int ComponentCounts = 1; ComponentCounts <= Gbx.Cirs.Count; ComponentCounts++)
                //{
                //    if (ComponentCounts <= Gbx.BladeRotors.Count)
                //    {
                //        keyValues.Add("#BLSL" + ComponentCounts.ToString() + "#", Gbx.BladeRotors[ComponentCounts - 1].ToString());
                //        if (!string.IsNullOrEmpty(BladeRotors))
                //            BladeRotors += " ,";
                //        BladeRotors += Gbx.BladeRotors[ComponentCounts - 1].ToString();
                //    }
                //}
                //keyValues.Add("#BLADEROTOR#", BladeRotors);
                #endregion


                #region Cir specific
                using (CIM_CIREntities context = new CIM_CIREntities())
                {
                    var cir = context.CirData.Where(x => x.CirId == Gbx.CIRId && x.Deleted == false).FirstOrDefault();
                    if (cir != null)
                    {
                        keyValues.Add("#ISSUDEDBY#", cir.CreatedBy);
                        keyValues.Add("#REVIEWDBY#", cir.CreatedBy);
                        keyValues.Add("#APPROVEDBY#", cir.CreatedBy);
                    }
                }

                keyValues.Add("#TURBINENO#", Gbx.TurbineNumber);
                keyValues.Add("#COUNTRY#", Gbx.Country);
                keyValues.Add("#SITE#", Gbx.SiteAddress);
                keyValues.Add("#COMMDATE#", Gbx.CommisionDate.ToString());


                //foreach (Placeholders oPlaceholders in Placeholder)
                //{
                //    string fieldValue = string.Empty;
                //    foreach (var item in masteritem)
                //        if (item.FieldValues.ContainsKey(oPlaceholders.Field))
                //        {
                //            fieldValue = item.FieldValues[oPlaceholders.Field];
                //        }

                //    keyValues.Add(oPlaceholders.Placeholder, fieldValue);
                //}
                #endregion

                #region Standard texts
                if (!ReferenceEquals(StandardTexts, null))
                    foreach (StandardTexts oStandardTexts in StandardTexts)
                    {
                        if (!keyValues.ContainsKey("#" + oStandardTexts.Title + "#"))
                            keyValues.Add("#" + oStandardTexts.Title + "#", oStandardTexts.Title);
                        if (!keyValues.ContainsKey("#" + oStandardTexts.Title + " desc#"))
                            keyValues.Add("#" + oStandardTexts.Title + " desc#", oStandardTexts.Description);
                    }
                #endregion

                #region Generating Word document
                //using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(destinationBladeTemplate, true))
                //{
                //    string docText = null;

                //    using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                //    {
                //        docText = sr.ReadToEnd();
                //    }

                //    if (Gbx.Cirs.Count == 1)
                //        docText = Cir.WebApp.Old_App_Code.GBXTemplates.BladeTemplate1; // Reading template from resource file
                //    else if (Gbx.Cirs.Count == 2)
                //        docText = Cir.WebApp.Old_App_Code.GBXTemplates.BladeTemplate2; // Reading template from resource file
                //    else
                //        docText = Cir.WebApp.Old_App_Code.GBXTemplates.BladeTemplate3; // Reading template from resource file

                //    foreach (KeyValuePair<string, string> item in keyValues)
                //    {
                //        Regex regexText = new Regex(item.Key);
                //        docText = regexText.Replace(docText, item.Value);
                //    }

                //    using (StreamWriter sw = new StreamWriter(
                //              wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                //    {
                //        sw.Write(docText);
                //    }

                //}
                #endregion

                #region Generating header
                //using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(destinationBladeTemplate, true))
                //{
                //    foreach (HeaderPart oHPart in wordDoc.MainDocumentPart.HeaderParts)
                //        foreach (var currentParagraph in oHPart.RootElement.Descendants<DocumentFormat.OpenXml.Wordprocessing.Paragraph>())
                //            foreach (var currentRun in currentParagraph.Descendants<DocumentFormat.OpenXml.Wordprocessing.Run>())
                //                foreach (var currentText in currentRun.Descendants<DocumentFormat.OpenXml.Wordprocessing.Text>())
                //                    foreach (KeyValuePair<string, string> item in keyValues)
                //                    {
                //                        Regex regexText = new Regex(item.Key);
                //                        currentText.Text = regexText.Replace(currentText.Text, item.Value);
                //                    }
                //}Oaxaca
                #endregion

                #region GBX Fields
                using (CIM_CIREntities context = new CIM_CIREntities())
                {
                    Edmx.ComponentInspectionReportGearbox cirGearBox = context.ComponentInspectionReportGearbox.Where(x => x.ComponentInspectionReportId == Gbx.CIRId).FirstOrDefault();
                    if (cirGearBox != null)
                    {
                        keyValues.Add("_ComponentTypeId", "Gearbox");
                        FillProperties(cirGearBox, ref keyValues);
                    }

                }
                #endregion

                try
                {
                    #region Create document
                    CreateGbxWordDoc
                            (
                                WordFile: destinationGearboxTemplate,
                                keyValues: keyValues
                            );
                    #endregion
                    // UpdateTOC(destinationGearboxTemplate);
                }
                catch
                {
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "GBXPdfReport [Create Doc ] Error", LogType.Error, "");

                }
                try
                {
                    #region Converting word to byte array
                    wordDocBytes = System.IO.File.ReadAllBytes(destinationGearboxTemplate);
                    #endregion
                }
                catch
                {

                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "GBXPdfReport [Byte array] Error", LogType.Error, "");


                }
            }
            catch (Exception oException)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "GBXPdfReport generation Error : " + oException.Message + " Locked", LogType.Error, "");


            }
            return wordDocBytes;

        }

        public static void AddGearboxPicturesTable(string WordFileName, GbxView gbxview)
        {

            try
            {
                // Load the document.
                using (DocX document = DocX.Load(WordFileName))
                {
                    int tableindex = 0;
                    using (CIM_CIREntities context = new CIM_CIREntities())
                    {
                        foreach (long CirDataId in gbxview.Cirs)
                        {
                            var cir = context.CirData.Where(x => x.CirDataId == CirDataId && x.Deleted == false).FirstOrDefault();
                            if (cir != null)
                            {
                                tableindex++;

                                var table = document.AddTable(1, 1);
                                table.Alignment = Alignment.center;
                                table.AutoFit = AutoFit.Window;
                                int row = 0;

                                var cirImages = context.ImageData.Where(x => x.ComponentInspectionReportId == cir.CirId).ToList();
                                if (cirImages.Count > 0)
                                {
                                    List<GBXImageData> imagelist = new List<GBXImageData>();
                                    foreach (var img in cirImages)
                                    {
                                        img.ImageDataString = img.ImageDataString.ToString() + DABir.GetBlobSASUri(img.ImageDataString);
                                        string imgdata = img.ImageDataString.Substring("data:image/jpeg;base64,".Length);
                                        imagelist.Add(new GBXImageData { Order = img.ImageOrder, Comment = img.ImageDescription, ImageData = Convert.FromBase64String(imgdata) });
                                    }

                                    foreach (GBXImageData img in imagelist.OrderBy(z => z.Order))
                                    {
                                        if (img.ImageData.Length == 0)
                                            continue;
                                        if (row > 0)
                                            table.InsertRow();
                                        table.InsertRow();


                                        // Add content to this Table.

                                        Novacode.Image imag;
                                        using (MemoryStream ms = new MemoryStream(img.ImageData))
                                        {
                                            imag = document.AddImage(ms);
                                        }

                                        Novacode.Picture picture = imag.CreatePicture();
                                        picture.Height = 512;
                                        picture.Width = 600;

                                        table.Rows[row].Cells[0].Paragraphs.First().AppendPicture(picture); // need to cpmplete
                                        table.Rows[row].Cells[0].Paragraphs.First().Alignment = Alignment.center;
                                        table.Rows[row + 1].Cells[0].Paragraphs.First().Append("Picture " + img.Order + " : " + img.Comment);

                                        row = row + 2;
                                    }

                                }

                                // Insert table at index where tag #TABLE# is in document.
                                //document.InsertTable(table);
                                foreach (var paragraph in document.Paragraphs)
                                {
                                    paragraph.FindAll("#TABLE" + tableindex.ToString() + "#").ForEach(index => paragraph.InsertTableAfterSelf((table)));
                                }

                                //Remove tag
                                document.ReplaceText("#TABLE" + tableindex.ToString() + "#", "");

                            }

                        }

                        document.Save();
                    }
                    // Save changes made to this document.




                } // Release this document from memory.
            }
            catch (Exception oException)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "GBXPdfReport [Inserting Image ] Error", LogType.Error, "");
            }
        }


        static void DeleteDirectoryContents(string DirectoryPath)
        {
            try
            {
                System.IO.DirectoryInfo directoryInfo = new DirectoryInfo(DirectoryPath);

                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
                {
                    if (dir.Name != "Templates")
                        dir.Delete(true);
                }
            }
            catch { }
        }


        public static void CreateGbxWordDoc(string WordFile, Dictionary<string, string> keyValues)
        {
            foreach (KeyValuePair<string, string> item in keyValues)
            {
                Replace
                    (
                        WordFileName: WordFile,
                        WordtoReplace: item.Key,
                        ReplaceWith: item.Value
                    );
            }

        }
        /// <summary>
        /// Replace the string a with the string b in filename and save the changes. 
        /// </summary>
        /// <param name="WordFileName"></param>
        /// <param name="WordtoReplace"></param>
        /// <param name="ReplaceWith"></param>
        public static void Replace(string WordFileName, string WordtoReplace, string ReplaceWith)
        {
            try
            {
                // Load the document.
                using (DocX document = DocX.Load(WordFileName))
                {
                    // Replace text in this document.
                    document.ReplaceText(WordtoReplace, ReplaceWith);

                    // Save changes made to this document.
                    document.Save();
                } // Release this document from memory.
            }
            catch { }


        }

        public static byte[] GetPdf(long GbxDataId)
        {
            byte[] pdfFile = null;
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                var gbx = context.GBXirWordDocument.Where(x => x.GBXirDataID == GbxDataId).FirstOrDefault();
                if (gbx != null)
                {
                    pdfFile = gbx.WordDocBytes;
                }

            }

            return pdfFile;
        }

        private static void SavePdf(string uid, State state, byte[] PdfData, string name)
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {

                PDF pdf = context.PDF.Where(x => x.CIRTemplateGUID == uid).FirstOrDefault();
                if (pdf == null)
                {
                    pdf = new PDF();
                    pdf.CIRTemplateGUID = uid;
                    pdf.CIRState = (int)state;
                    pdf.CIRName = name;
                    pdf.PDFData = PdfData;
                    context.PDF.Add(pdf);
                }
                else
                {
                    pdf.CIRState = (int)state;
                    pdf.CIRName = name;
                    pdf.PDFData = PdfData;
                }
                context.SaveChanges();
            }

        }
        public static List<StandardTexts> GetStandardTexts(int ComponentInspectionReportTypeId)
        {
            StandardTexts returnValue = null;
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                var users = new List<StandardTexts>();
                var st = context.CirStandardTexts.Where(x => x.ComponentInspectionReportTypeId == ComponentInspectionReportTypeId).ToList();

                foreach (var entity in st)
                {
                    returnValue = CreateStandardTexts(entity);
                    users.Add(returnValue);
                }
                return users;
            }
        }

        private static StandardTexts CreateStandardTexts(CirStandardTexts e)
        {
            var s = new StandardTexts
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                ComponentInspectionReportTypeId = e.ComponentInspectionReportTypeId
            };
            return s;
        }
        private static void GetBladeRotor(long CirDataId, ref GbxView gbxview)
        {

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                var cir = context.CirData.Where(x => x.CirDataId == CirDataId && x.Deleted == false).FirstOrDefault();
                if (cir != null)
                {
                    var bladeSerial = context.ComponentInspectionReportBlade.Where(x => x.ComponentInspectionReportId == cir.CirId).Select(x => x.BladeSerialNumber).ToList();
                    foreach (string b in bladeSerial)
                        gbxview.BladeRotors.Add(b);
                }


            }

        }
        public static GbxView GetGbxDataByID(long GbxID, out string relatedCIRs)
        {
            GbxView objGBXView = new GbxView();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                var cmd = new SqlCommand { Connection = conn };
                SqlDataReader reader = null;
                relatedCIRs = string.Empty;

                string whereClauseOrder = "";
                whereClauseOrder += "bd.Deleted = 0 AND bd.GbxirDataID = " + GbxID.ToString();

                try
                {
                    cmd.CommandText = string.Format(@"
                                    SELECT [GBXirDataID],[GBXirCode], [RevisionNumber],CirDataId, CirId,Created,Createdby,SiteAddress,TurbineNumber,TurbineType,Country,SBU,GearboxSerialNos,OilAnalysis,CMSAnalysis,Analysis,ConclusionsAndRecommendations,CommisioningDate
                                                 ,GearboxType,GearboxRevision,InstallationDate,InspectionDate,ReasonForService,Description,AdditionalInfo,SBURecommendation,gearboxLSSNRend
                                                 ,GearboxIMSNRend,GearboxHSSNRend,GearboxHSSRend,GearboxIMSRend
                                    FROM (
	                                    SELECT BD.[GBXirDataID],BD.[GBXirCode], BD.[RevisionNumber],
                                    cd.CirDataId, cd.CirId,  bd.Created, bd.Createdby, isnull(td.[Site],'')SiteAddress,CMI.TurbineNumber, td.TurbineType,td.Country,sbu.[Name] as SBU,bd.GearboxSerialNos,bd.OilAnalysis,bd.CMSAnalysis,bd.Analysis,ConclusionsAndRecommendations,
                                        CMI.CommisioningDate as CommisioningDate,GT.Name as GearboxType,GBR.Name as GearboxRevision,CMI.InstallationDate as InstallationDate,CMI.InspectionDate AS InspectionDate,
                                              CMI.ReasonForService as ReasonForService,CMI.Description as Description,CMI.AdditionalInfo as AdditionalInfo,CMI.SBURecommendation as SBURecommendation, 
                                              CMIG.gearboxLSSNRend as gearboxLSSNRend, CMIG.GearboxIMSNRend as GearboxIMSNRend,CMIG.GearboxHSSNRend as GearboxHSSNRend,
                                                  CMIG.GearboxHSSRend as GearboxHSSRend,CMIG.GearboxIMSRend as GearboxIMSRend,   ROW_NUMBER() OVER(
		                                    ORDER BY  BD.[Created] desc
	                                    ) AS RowNumber
	                                    FROM
	                                    [dbo].[GBXirData] BD  WITH(NOLOCK)
                                    inner  join [dbo].[MapGBXirCir] MPC  WITH(NOLOCK)
                                    on MPC.GBXirDataID = BD.GBXirDataID and MPC.Master = 1
                                    inner join 
                                    dbo.CIRData cd  WITH(NOLOCK) on cd.[CirDataId] = MPC.CirDataID
                                    left join ComponentInspectionReport CMI on CMI.ComponentInspectionReportId = cd.[CirId] 
                                    left join [dbo].ComponentInspectionReportGearbox CMIG on CMI.ComponentInspectionReportId =  CMIG.[ComponentInspectionReportId]
									left join [dbo].GearboxType GT on CMIG.GearboxTypeId = GT.GearboxTypeId
                                    left join [dbo].GearboxRevision GBR on CMIG.GearboxRevisionId = GBR.GearboxRevisionId
                                    left  JOIN [dbo].[SBU] sbu WITH(NOLOCK) ON CMI.SBUId = sbu.[SBUId]
                                    left join TurbineData td on  td.TurbineId = CONVERT(VARCHAR(50),CMI.TurbineNumber)
	                                    WHERE {0} 
		                                    ) CirDataPage
                                    ", whereClauseOrder);

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objGBXView = new GbxView
                        {
                            GbxDataId = reader["GBXirDataID"] == DBNull.Value ? 0 : Convert.ToInt64(reader["GBXirDataID"]),
                            GbxCode = Convert.ToString(reader["GBXirCode"]),
                            RevisionNumber = Convert.ToInt32(reader["RevisionNumber"]),
                            CIRDataId = reader["CirDataId"] == DBNull.Value ? 0 : Convert.ToInt64(reader["CirDataId"]),
                            CIRId = reader["CirId"] == DBNull.Value ? 0 : Convert.ToInt64(reader["CirId"]),
                            SiteAddress = Convert.ToString(reader["SiteAddress"]),
                            Created = reader.GetDateTime(reader.GetOrdinal("Created")),
                            Createdby = reader.GetString(reader.GetOrdinal("Createdby")),
                            TurbineNumber = Convert.ToString(reader["TurbineNumber"]),//reader.GetString(reader.GetOrdinal("TurbineNumber")),
                            TurbineType = reader.GetString(reader.GetOrdinal("TurbineType")),
                            Country = reader.GetString(reader.GetOrdinal("Country")),
                            GearboxSerialNos = Convert.ToString(reader["GearboxSerialNos"]),
                            OilAnalysis = Convert.ToString(reader["OilAnalysis"]),
                            CMSAnalysis = Convert.ToString(reader["CMSAnalysis"]),
                            Analysis = Convert.ToString(reader["Analysis"]),
                            ConculsionRecomm = Convert.ToString(reader["ConclusionsAndRecommendations"]),
                            CommisionDate = reader.GetDateTime(reader.GetOrdinal("CommisioningDate")),
                            GearboxType = Convert.ToString(reader["GearboxType"]),
                            GearboxRevision = Convert.ToString(reader["GearboxRevision"]),
                            InstallationDate = reader.GetDateTime(reader.GetOrdinal("InstallationDate")),
                            InspectionDate = reader.GetDateTime(reader.GetOrdinal("InspectionDate")),
                            ReasonForService = Convert.ToString(reader["ReasonForService"]),
                            AdditionalInfo = Convert.ToString(reader["AdditionalInfo"]),
                            SBURecommendation = Convert.ToString(reader["SBURecommendation"]),
                            Description = Convert.ToString(reader["Description"]),
                            gearboxLSSNRend = Convert.ToString(reader["gearboxLSSNRend"]),
                            GearboxIMSNRend = Convert.ToString(reader["GearboxIMSNRend"]),
                            GearboxHSSNRend = Convert.ToString(reader["GearboxHSSNRend"]),
                            GearboxHSSRend = Convert.ToString(reader["GearboxHSSRend"]),
                            GearboxIMSRend = Convert.ToString(reader["GearboxIMSRend"])

                        };
                    }

                    reader.Close();

                    cmd = new SqlCommand()
                    {
                        Connection = conn,
                        CommandText = string.Format(@"SELECT Cirs FROM (
                                SELECT MAP.GBXirDataID, STUFF(
                                (SELECT ',' + LTRIM(RTRIM(M.CirDataId))
                                FROM MapGbxirCir M
                                WHERE MAP.GBXirDataID = M.GBXirDataID AND M.Deleted = 0 ORDER BY M.CirDataId
                                FOR XML PATH('')),1,1,'') AS Cirs
                                FROM MapGbxirCir AS MAP WHERE MAP.DELETED = 0
                                GROUP BY MAP.GbxirDataID
                                ) GBXMAP WHERE GbxirDataID = {0}", GbxID)
                    };

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        relatedCIRs = reader.GetString(reader.GetOrdinal("Cirs"));
                    }
                    reader.Close();
                }
                catch
                {
                    throw new Exception("Error getting GBX Data");
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
            return objGBXView;
        }

        public static string GetContractName(long turbineID)
        {
            string ContractName = string.Empty;
            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("GetContractHolder", objCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TurbineId", SqlDbType.BigInt);
                    cmd.Parameters["@TurbineId"].Value = turbineID;
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    if (!ReferenceEquals(dt, null) && dt.Rows.Count > 0)
                    {
                        ContractName = dt.Rows[0][0].ToString();
                    }

                }
            }

            return ContractName;
        }

        public static CIR.TurbineProperties GetTurbineData(string turbineId)
        {
            CIR.TurbineProperties objTurbine = new CIR.TurbineProperties();
            using (CIM_CIREntities context = new CIM_CIREntities())
            {

                objTurbine = DACIRData.GetTurbineRecord(turbineId, context);
            }
            return objTurbine;

        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CIM_MasterDataConn"].ConnectionString;
        }
    }
}