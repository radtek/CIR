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
using System.IO;
using Spire.Pdf;
using Spire.Pdf.HtmlConverter;
using ICSharpCode.SharpZipLib.Zip;
using System.Data.Objects.SqlClient;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.Documents.Client;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Cir.CloudConvert.Wrapper;
using System.Threading.Tasks;

namespace Cir.Sync.Services.DAL
{
    public class DABIRReport
    {
        public delegate bool GeneratePDFDelegate(long cirid, string path, string licpath);

        public static bool RenderBirReport(long BirId)
        {
            byte[] wordBytes = null;
            BIRView birView = new BIRView();
            string RelatedCIR = string.Empty;

            wordBytes = GetPdf(BirId);

            if (ReferenceEquals(wordBytes, null))
            {

                #region Retrieving placeholders
                //  List<Cir.Common.BirPdf.Placeholders> Placeholder = GetPlaceholders(1);
                #endregion

                #region Retrieving Standard texts
                IEnumerable<StandardTexts> lstStandardText = GetStandardTexts(1);
                #endregion

                #region Retrieving BIR data
                birView = GetBirDataByID(BirId, out RelatedCIR
                            );
                #endregion


                if (!string.IsNullOrEmpty(RelatedCIR))
                {
                    birView.BladeRotors = new List<string>();
                    birView.Cirs = new List<long>();
                    long cirDataID = -1;
                    foreach (var CirDataID in RelatedCIR.Split(','))
                        if (long.TryParse(CirDataID, out cirDataID))
                        {
                            birView.Cirs.Add(cirDataID);
                            GetBladeRotor(cirDataID, ref birView);

                        }
                }


                CIR.TurbineProperties oTurbineData = GetTurbineData(birView.TurbineNumber);

                string ContractName = GetContractName(Convert.ToInt64(birView.TurbineNumber));

                wordBytes = GenerateWordDocument
               (
                   Bir: birView,
                   StandardTexts: lstStandardText,
                   TurbineData: oTurbineData,
                   ContractName: ContractName
               );
                if (!ReferenceEquals(wordBytes, null))

                {
                    SaveGeneratePdf
                        (
                            BirDataId: birView.BirDataId,
                            BirCode: birView.BirCode,
                            pdfFile: wordBytes
                        );
                }
            }
            return true;
        }

        public static byte[] RenderBirReportforCosmos(long BirId, HttpContext context)
        {
            HttpContext.Current = context;
            byte[] wordBytes = null;
            BIRView birView = new BIRView();
            string RelatedCIR = string.Empty;

            wordBytes = GetPdf(BirId);

            if (ReferenceEquals(wordBytes, null))
            {

                #region Retrieving placeholders
                //  List<Cir.Common.BirPdf.Placeholders> Placeholder = GetPlaceholders(1);
                #endregion

                #region Retrieving Standard texts
                IEnumerable<StandardTexts> lstStandardText = GetStandardTexts(1);
                #endregion

                #region Retrieving BIR data
                birView = GetBirDataByID(BirId, out RelatedCIR
                            );
                #endregion


                if (!string.IsNullOrEmpty(RelatedCIR))
                {
                    birView.BladeRotors = new List<string>();
                    birView.Cirs = new List<long>();
                    long cirDataID = -1;
                    foreach (var CirDataID in RelatedCIR.Split(','))
                        if (long.TryParse(CirDataID, out cirDataID))
                        {
                            birView.Cirs.Add(cirDataID);
                            GetBladeRotor(cirDataID, ref birView);

                        }
                }


                CIR.TurbineProperties oTurbineData = GetTurbineData(birView.TurbineNumber);

                string ContractName = GetContractName(Convert.ToInt64(birView.TurbineNumber));

                wordBytes = GenerateWordDocument
               (
                   Bir: birView,
                   StandardTexts: lstStandardText,
                   TurbineData: oTurbineData,
                   ContractName: ContractName
               );
                if (!ReferenceEquals(wordBytes, null))

                {
                    SaveGeneratePdf
                        (
                            BirDataId: birView.BirDataId,
                            BirCode: birView.BirCode,
                            pdfFile: wordBytes
                        );
                }
            }
            return wordBytes;
        }

        public static BirFile RenderBirReport(long BirId, int laguangeId)
        {
            byte[] wordBytes = null;
            BIRView birView = new BIRView();
            string RelatedCIR = string.Empty;
            BirFile oBir = new BirFile();
            //wordBytes = GetPdf(BirId);
            if (ReferenceEquals(wordBytes, null))
            {

                #region Retrieving placeholders
                //  List<Cir.Common.BirPdf.Placeholders> Placeholder = GetPlaceholders(1);
                #endregion

                #region Retrieving Standard texts
                IEnumerable<StandardTexts> lstStandardText = GetStandardTexts(1);
                #endregion

                #region Retrieving BIR data
                birView = GetBirDataByID(BirId, out RelatedCIR
                            );
                #endregion


                if (!string.IsNullOrEmpty(RelatedCIR))
                {
                    birView.BladeRotors = new List<string>();
                    birView.Cirs = new List<long>();
                    long cirDataID = -1;
                    foreach (var CirDataID in RelatedCIR.Split(','))
                        if (long.TryParse(CirDataID, out cirDataID))
                        {
                            birView.Cirs.Add(cirDataID);
                            GetBladeRotor(cirDataID, ref birView);

                        }
                }


                CIR.TurbineProperties oTurbineData = GetTurbineData(birView.TurbineNumber);

                string ContractName = GetContractName(Convert.ToInt64(birView.TurbineNumber));

                DocumentClient _documentClient = new DocumentClient(new Uri(DABir.endPointURI), DABir.primaryKey);
                BirDataDetails existingBirDataDetails = _documentClient.CreateDocumentQuery<BirDataDetails>(
                       UriFactory.CreateDocumentCollectionUri(DABir.databaseId, DABir.collectionName),
                       new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                   .Where(x => x.BirDataID == BirId).AsEnumerable().FirstOrDefault();
                if (existingBirDataDetails != null)
                {
                    wordBytes = GetWordBytes(existingBirDataDetails.WordBytesUrl.ToString());
                }
                else
                {
                    wordBytes = GenerateWordDocument
                   (
                       Bir: birView,
                       StandardTexts: lstStandardText,
                       TurbineData: oTurbineData,
                       ContractName: ContractName,
                       langangeid: laguangeId
                   );
                }

                if (!ReferenceEquals(wordBytes, null))
                {

                    oBir.FileBytes = wordBytes;
                    oBir.FileName = birView.BirCode;
                    string SpireLicensePath = HttpContext.Current.Server.MapPath("~/SpireLicense");
                    Spire.License.LicenseProvider.SetLicenseFileName("license.lic");
                    Spire.License.LicenseProvider.SetLicenseFileFullPath(Path.Combine(SpireLicensePath, "license.lic"));
                    Spire.License.LicenseProvider.LoadLicense();

                    using (MemoryStream ms1 = new MemoryStream(oBir.FileBytes))
                    {
                        Document doc = new Document(ms1);

                        using (MemoryStream ms2 = new MemoryStream())
                        {
                            doc.SaveToStream(ms2, Spire.Doc.FileFormat.PDF);
                            //save to byte array
                            byte[] toArray = ms2.ToArray();
                            oBir.FileBytes = toArray;
                        }
                    }
                }
            }
            return oBir;
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
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error Generating CIR PDF : " + ex.Message, LogType.Error, "");

            }
            return data;
        }

        // To get the pdf from ManageBIR/ CIR Download and Approve
        public static Bir GetCIRPdf(long CirDataId, long CirId = 0)
        {

            Bir oBir = new Bir();

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
                        oBir.File = new BirFile() { Id = CirDataId, FileName = pdf.CIRName, FileBytes = pdf.PDFData };

                    }
                    else
                    {
                        if (CirId == 0)
                        {
                            CirId = context.CirData.Where(x => x.CirDataId == CirDataId && x.Deleted == false).Select(x => x.CirId).FirstOrDefault();
                        }
                        string DocumentPath = HttpContext.Current.Server.MapPath("CIRTemplates");
                        string SpireLicensePath = HttpContext.Current.Server.MapPath("~/SpireLicense");
                        GeneratePDFDelegate d = null;
                        d = new GeneratePDFDelegate(DACIRReport.RenderCirReport);
                        IAsyncResult R = null;
                        R = d.BeginInvoke(CirId, DocumentPath, SpireLicensePath, null, null); //invoking the method
                    }
                }
            }
            return oBir;
        }

        public static CirPDFResponse GetCIRPdfForSQL(long CirId)
        {
            CirPDFResponse oBir = new CirPDFResponse();
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                string Guid = context.CirData.Where(x => x.CirId == CirId && x.Deleted == false).OrderByDescending(z => z.CirDataId).Select(x => x.Guid).FirstOrDefault();
                if (Guid != null)
                {
                    PDF pdf = context.PDF.Where(x => x.CIRTemplateGUID == Guid).OrderByDescending(x => x.PDFId).FirstOrDefault();
                    if (pdf != null)
                    {
                        oBir = new CirPDFResponse() { FileName = pdf.CIRName, DownloadUrl = Convert.ToBase64String(pdf.PDFData) };

                    }
                }
            }
            return oBir;
        }

        public static Bir GetCIRPdfZip(string CirDataIds)
        {
            Bir oBirOutput = new Bir();
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
                        Bir oBir = GetCIRPdf(CirDataId);
                        if (oBir.File != null)
                        {
                            byte[] fileBytes = oBir.File.FileBytes;
                            ZipEntry fileEntry = new ZipEntry(oBir.File.FileName + ".pdf");
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
                oBirOutput.File = new BirFile() { Id = 0, FileName = "CIR.zip", FileBytes = byteArrayOut };


            }
            return oBirOutput;

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

            doc.IsUpdateFields = false;

            doc.UpdateTableOfContents();
            doc.SaveToFile(filename);
        }

        public static Bir GetBirPDF(long BirID)
        {
            Bir oBir = new Bir();
            try
            {
                string dataType = "BIR";

                DocumentClient _documentClient = new DocumentClient(new Uri(DABir.endPointURI), DABir.primaryKey);
                BirDataDetails existingBirDataDetails = _documentClient.CreateDocumentQuery<BirDataDetails>(
                       UriFactory.CreateDocumentCollectionUri(DABir.databaseId, DABir.collectionName),
                       new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                   .Where(x => x.BirDataID == BirID).AsEnumerable().FirstOrDefault();
                if (existingBirDataDetails != null)
                {
                    oBir.File = new BirFile { FileName = existingBirDataDetails.BirCode };
                    if (existingBirDataDetails.PDFStatus == "NotGenerated" && existingBirDataDetails.WordDocStatus == "Generated")
                    {
                        oBir.File.FileBytes = GetPdfBytes(existingBirDataDetails.WordBytesUrl.ToString()).Result;
                        DABir.SaveWordBytesToBlob(oBir.File.FileBytes, existingBirDataDetails.WordBytesUrl.ToString(), existingBirDataDetails.TurbineId, existingBirDataDetails.BirCode, dataType, existingBirDataDetails.Modified, existingBirDataDetails.IsAnnualInspection.ToString(), existingBirDataDetails.CirIDs, "pdf");
                        existingBirDataDetails.PDFStatus = "Generated";
                        DABir.SaveBirDatatoCosmosDb(existingBirDataDetails, existingBirDataDetails.Id);
                    }
                    else if (existingBirDataDetails.PDFStatus == "Generated")
                    {
                        oBir = DABir.ReadBirDetailsFromBlob(oBir, existingBirDataDetails, "pdf");
                    }

                    else if (existingBirDataDetails.PDFStatus == "NotGenerated" && existingBirDataDetails.WordDocStatus == "NotGenerated")
                    {
                        oBir.File.FileStatus = "NotGenerated";
                    }

                    else if (existingBirDataDetails.PDFStatus == "NotGenerated" && existingBirDataDetails.WordDocStatus.Contains("Error"))
                    {
                        oBir.File.FileStatus = "Error";
                    }

                    else if (existingBirDataDetails.PDFStatus == null)
                    {
                        oBir.File.FileBytes = DABIRReport.RenderBirReportforCosmos(BirID, HttpContext.Current);
                        oBir = GenerateNewPdf(oBir, dataType, existingBirDataDetails);
                    }
                }

                else
                {
                    string birDataDocumentId = string.Empty;
                    oBir = DABir.CheckBirSQLEntries(BirID, oBir);
                    BirDataDetails objBirDetails = DABir.GetBirDataByID(BirID);
                    if (oBir.File.FileBytes == null)
                        oBir.File.FileBytes = DABIRReport.RenderBirReportforCosmos(BirID, HttpContext.Current);
                    oBir = GenerateNewPdf(oBir, dataType, objBirDetails);
                }


            }
            catch (Exception ex)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", string.Format("BIRPdfReport Error:{0} ", ex.InnerException), LogType.Error, "");
                oBir.File.FileStatus = "Error";
            }
            return oBir;
        }

        private static Bir GenerateNewPdf(Bir oBir, string dataType, BirDataDetails existingBirDataDetails)
        {
            try
            {
                if (existingBirDataDetails != null)
                {
                    existingBirDataDetails.WordBytesUrl = DABir.SaveWordBytesToBlob(oBir.File.FileBytes, "", existingBirDataDetails.TurbineId, existingBirDataDetails.BirCode, dataType, DateTime.Today, fileType: "Doc");
                    existingBirDataDetails.WordDocStatus = "Generated";
                    oBir.File.FileBytes = GetPdfBytes(existingBirDataDetails.WordBytesUrl.ToString()).Result;
                    DABir.SaveWordBytesToBlob(oBir.File.FileBytes, existingBirDataDetails.WordBytesUrl.ToString(), existingBirDataDetails.TurbineId, existingBirDataDetails.BirCode, dataType, existingBirDataDetails.Modified, existingBirDataDetails.IsAnnualInspection.ToString(), existingBirDataDetails.CirIDs, "pdf");
                    existingBirDataDetails.PDFStatus = "Generated";
                    DABir.SaveBirDatatoCosmosDb(existingBirDataDetails, existingBirDataDetails.Id);
                }
            }
            catch (Exception ex)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", string.Format("BIRPdfReport Error:{0} ", ex.InnerException), LogType.Error, "");
                oBir.File.FileStatus = "Error";
            }
            return oBir;
        }

        public static async Task<byte[]> GetPdfBytes(string birDataUri)
        {
            
            CloudBlockBlob Blob = new CloudBlockBlob(new Uri(birDataUri));

            ConverterWrapper objPdf = new ConverterWrapper();
            var res = await objPdf.CreatePDFAsync(Blob.Uri.OriginalString.ToString() + DABir.GetBlobSASUri(birDataUri) + "&sr=b", Blob.Name);

            return Convert.FromBase64String(res.ResponseString);
        }

        public static byte[] GetWordBytes(string birDataUri)
        {
            birDataUri = birDataUri + DABir.GetBlobSASUri(birDataUri);
            CloudBlockBlob Blob = new CloudBlockBlob(new Uri(birDataUri + "&sr=b"));   
            Blob.FetchAttributes();
            long fileByteLength = Blob.Properties.Length;
            Byte[] myByteArray = new Byte[fileByteLength];
            Blob.DownloadToByteArray(myByteArray, 0);
            return myByteArray;
        }

        public static void SaveGeneratePdf(long BirDataId, string BirCode, byte[] pdfFile)
        {
            // save PDF to database (update existing if applicable)
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                var entity = context.BirWordDocument.Where(x => x.BirDataID == BirDataId).FirstOrDefault();

                if (entity == null)
                {
                    entity = new BirWordDocument();
                    entity.BirDataID = BirDataId;
                    entity.BirCode = BirCode;
                    entity.WordDocBytes = pdfFile;
                    context.BirWordDocument.Add(entity);
                }
                else
                {
                    entity.BirCode = BirCode;
                    entity.WordDocBytes = pdfFile;

                }
                // save
                context.SaveChanges();
            }
        }

        public static byte[] GenerateWordDocument(BIRView Bir, IEnumerable<StandardTexts> StandardTexts, CIR.TurbineProperties TurbineData, string ContractName, int langangeid = 0)
        {
            byte[] wordDocBytes = null;
            try
            {
                Dictionary<string, string> keyValuesPairs = new Dictionary<string, string>();
                string DocumentPath = HttpContext.Current.Server.MapPath("BIRTemplates");

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

                #region [Select Word Template]
                string sourceBladeTemplate = string.Empty;
                var birTemplateVersion = ConfigurationManager.AppSettings["birTemplateVersion"];
                bool newCIR = IsNewCIR(Bir);
                if (newCIR)
                {
                    if (langangeid == 4)
                    {
                        if (Bir.Cirs.Count == 1)
                            sourceBladeTemplate = Path.Combine(DocumentPath, @"Templates\DC_Inspection_Template_1Blades_CH.docx");
                        else if (Bir.Cirs.Count == 2)
                            sourceBladeTemplate = Path.Combine(DocumentPath, @"Templates\DC_Inspection_Template_2Blades_CH.docx");
                        else
                            sourceBladeTemplate = Path.Combine(DocumentPath, @"Templates\DC_Inspection_Template_3Blades_CH.docx");

                    }
                    else
                    {
                        if (Bir.Cirs.Count == 1)
                            sourceBladeTemplate = Path.Combine(DocumentPath, @"Templates\DC_Inspection_Template_1Blades_v3.1.docx");
                        else if (Bir.Cirs.Count == 2)
                            sourceBladeTemplate = Path.Combine(DocumentPath, @"Templates\DC_Inspection_Template_2Blades_v3.1.docx");
                        else
                            sourceBladeTemplate = Path.Combine(DocumentPath, @"Templates\DC_Inspection_Template_3Blades_v3.1.docx");
                    }
                }
                else
                {
                    if (langangeid == 4)
                    {
                        if (Bir.Cirs.Count == 1)
                            sourceBladeTemplate = Path.Combine(DocumentPath, @"Templates\DC_Inspection_Template_1Blades_CH.docx");
                        else if (Bir.Cirs.Count == 2)
                            sourceBladeTemplate = Path.Combine(DocumentPath, @"Templates\DC_Inspection_Template_2Blades_CH.docx");
                        else
                            sourceBladeTemplate = Path.Combine(DocumentPath, @"Templates\DC_Inspection_Template_3Blades_CH.docx");

                    }
                    else
                    {
                        if (Bir.Cirs.Count == 1)
                            sourceBladeTemplate = Path.Combine(DocumentPath, @"Templates\DC_Inspection_Template_1Blades.docx");
                        else if (Bir.Cirs.Count == 2)
                            sourceBladeTemplate = Path.Combine(DocumentPath, @"Templates\DC_Inspection_Template_2Blades.docx");
                        else
                            sourceBladeTemplate = Path.Combine(DocumentPath, @"Templates\DC_Inspection_Template_3Blades.docx");
                    }
                }
                //if (birTemplateVersion == "v3.1")
                //{
                //    if (langangeid != 4)
                //    {
                //        if (Bir.Cirs.Count == 1)
                //            sourceBladeTemplate = Path.Combine(DocumentPath, @"Templates\DC_Inspection_Template_1Blades_v3.1.docx");
                //        else if (Bir.Cirs.Count == 2)
                //            sourceBladeTemplate = Path.Combine(DocumentPath, @"Templates\DC_Inspection_Template_2Blades_v3.1.docx");
                //        else
                //            sourceBladeTemplate = Path.Combine(DocumentPath, @"Templates\DC_Inspection_Template_3Blades_v3.1.docx");
                //    }
                //}
                string destinationBladeTemplate = Path.Combine(DocumentPath, Bir.BirCode.Replace("/", string.Empty).Replace(@"\", string.Empty).Trim() + ".docx");

                // Create a copy of the template file and open the copy 
                File.Copy(sourceBladeTemplate, destinationBladeTemplate, true);
                #endregion [Select Word Template]

                // create key value pair, key represents words to be replace and 
                //values represent values in document in place of keys.
                Dictionary<string, string> keyValues = new Dictionary<string, string>();

                #region [Blade Overall Damage BIR3.1]
                //keyValues = AddBladeDamageTable(destinationBladeTemplate, Bir.Cirs);
                if (newCIR)
                {
                    keyValues = AddBladeDamageTable(destinationBladeTemplate, Bir.Cirs);
                }
                else
                {
                    keyValues = AddBladeDamageTable_old(Bir.Cirs);
                }
                #endregion [Blade Overall Damage BIR3.1]

                #region Component specific
                keyValues.Add("#BIRNAME#", Bir.BirCode);
                keyValues.Add("#REPAIRINGSOLUTION#", Bir.RepairingSol);
                keyValues.Add("#RAWMATERIALS#", Bir.RawMaterial);
                keyValues.Add("#CONCLUSIONRECOMMENDATION#", Bir.ConculsionRecomm);
                //keyValues.Add("#CREATED#", string.Format("{0:dd MMMM yyyy}", Bir.Created));
                keyValues.Add("#CREATED#", Bir.Created.ToString("dd.MM.yyyy"));
                keyValues.Add("#CREATEDBY#", Bir.Createdby);
                keyValues.Add("#MASTERAUTHOR#", Bir.Createdby);
                keyValues.Add("#CUSTOMER#", ContractName);
                #endregion

                #region Turbine specific
                if (!ReferenceEquals(TurbineData, null))
                {
                    keyValues.Add("#WTG#", TurbineData.Turbine + " " + TurbineData.NominelPower);
                    keyValues.Add("#WTGNO#", Bir.TurbineType);
                    keyValues.Add("#WTGLOCALID#", TurbineData.LocalTurbineId);
                }
                #endregion

                #region Component serials
                string BladeRotors = string.Empty;
                for (int ComponentCounts = 1; ComponentCounts <= Bir.Cirs.Count; ComponentCounts++)
                {
                    if (ComponentCounts <= Bir.BladeRotors.Count)
                    {
                        keyValues.Add("#BLSL" + ComponentCounts.ToString() + "#", Bir.BladeRotors[ComponentCounts - 1].ToString());
                        if (!string.IsNullOrEmpty(BladeRotors))
                            BladeRotors += ", ";
                        BladeRotors += Bir.BladeRotors[ComponentCounts - 1].ToString();
                    }
                }
                keyValues.Add("#BLADEROTOR#", BladeRotors);
                #endregion

                #region [Cir specific]
                using (CIM_CIREntities context = new CIM_CIREntities())
                {
                    var cir = context.CirData.Where(x => x.CirId == Bir.CIRId && x.Deleted == false).FirstOrDefault();
                    if (cir != null)
                    {
                        keyValues.Add("#ISSUDEDBY#", cir.CreatedBy);
                        keyValues.Add("#REVIEWDBY#", cir.CreatedBy);
                        keyValues.Add("#APPROVEDBY#", cir.CreatedBy);
                    }
                }

                keyValues.Add("#TURBINENO#", Bir.TurbineNumber);
                keyValues.Add("#COUNTRY#", Bir.Country);
                keyValues.Add("#SITE#", Bir.SiteAddress);
                keyValues.Add("#COMMDATE#", Bir.CommisionDate.ToString());


                #region [Blade Pictures and Damages]
                if (newCIR)
                {
                    AddBladePicturesTable(destinationBladeTemplate, Bir);
                }
                else
                {
                    AddBladePicturesTable_Old(destinationBladeTemplate, Bir);
                }
                #endregion [Blade Pictures and Damages]

                #endregion [Cir specific]

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

                //    if (Bir.Cirs.Count == 1)
                //        docText = Cir.WebApp.Old_App_Code.BIRTemplates.BladeTemplate1; // Reading template from resource file
                //    else if (Bir.Cirs.Count == 2)
                //        docText = Cir.WebApp.Old_App_Code.BIRTemplates.BladeTemplate2; // Reading template from resource file
                //    else
                //        docText = Cir.WebApp.Old_App_Code.BIRTemplates.BladeTemplate3; // Reading template from resource file

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

                try
                {
                    #region Create document
                    CreateBirWordDoc
                            (
                                WordFile: destinationBladeTemplate,
                                keyValues: keyValues
                            );
                    #endregion
                    UpdateTOC(destinationBladeTemplate);
                }
                catch (Exception ex)
                {
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "BIRPdfReport [Create Doc ] Error" + ex.Message, LogType.Error, "");

                }
                try
                {
                    #region Converting word to byte array
                    wordDocBytes = System.IO.File.ReadAllBytes(destinationBladeTemplate);
                    #endregion
                }
                catch (Exception ex)
                {

                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "BIRPdfReport [Byte array] Error" + ex.Message, LogType.Error, "");


                }
            }
            catch (Exception oException)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "BIRPdfReport generation Error : " + oException.Message + " Locked", LogType.Error, "");


            }
            return wordDocBytes;

        }

        /// <summary>
        /// Trace out whether cir created using new or old templates. For new cirs use bir v3.1 and for older one use bir v3.0
        /// </summary>
        /// <param name="bir"></param>
        /// <returns></returns>
        public static bool IsNewCIR(BIRView birView)
        {
            bool result = true;
            Dictionary<long, bool> cirStatus = new Dictionary<long, bool>();
            try
            {
                using (CIM_CIREntities context = new CIM_CIREntities())
                {
                    foreach (var cirDataId in birView.Cirs)
                    {
                      string templateversion = context.CirData.Where(x => x.CirDataId == cirDataId).Select(x => x.TemplateVersion).FirstOrDefault();
                        if (int.Parse(templateversion) < 9)
                        {
                            result = false;
                            break;
                        }
                        long? CirId = context.CirData.Where(x => x.CirDataId == cirDataId).Select(x => x.CirId).FirstOrDefault();
                        if (CirId == null)
                            continue;
                        var IsCirContainsImages = context.ImageData.Where(x => x.ComponentInspectionReportId == CirId).Count() > 0 ? true : false;
                        if (IsCirContainsImages)
                        {
                            var ImageGuid = context.ImageData.Any(x => x.ComponentInspectionReportId == CirId && (x.FormIOImageGUID == null || x.FormIOImageGUID == ""));
                            //cirStatus.Add(cirId, ImageGuid);
                            if (ImageGuid)
                            {
                                result = false;
                                break;
                            }
                        }
                    }
                    //cirStatus true means old cir
                }
            }
            catch (Exception ex)
            {
                ErrorHandling.SystemLog.Log("Error at IsNewCIR method", ex.Message, LogType.Error);
            }
            return result;
        }

        public static Dictionary<string, string> AddBladeDamageTable_old(List<long> cirDataId)
        {
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            try
            {
                using (CIM_CIREntities context = new CIM_CIREntities())
                {
                    int tableindex = 0;

                    foreach (long cirid in cirDataId)
                    {
                        ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "BIRPdfReport blade Damnage [Create Doc ] cir id" + cirid, LogType.Information, "");
                        var cir = (
                            from cr in context.ComponentInspectionReport
                            join cd in context.CirData on cr.ComponentInspectionReportId equals cd.CirId
                            join crb in context.ComponentInspectionReportBlade on cr.ComponentInspectionReportId equals crb.ComponentInspectionReportId
                            join crbd in context.ComponentInspectionReportBladeDamage on crb.ComponentInspectionReportBladeId equals crbd.ComponentInspectionReportBladeId into crbds
                            from crbd in crbds.DefaultIfEmpty()
                            join edge in context.BladeEdge on crbd.BladeEdgeId equals edge.BladeEdgeId into edges
                            from edge in edges.DefaultIfEmpty()
                            join bladedamage in context.BladeInspectionData on crbd.BladeInspectionDataId equals bladedamage.BladeInspectionDataId into bladedamages
                            from bladedamage in bladedamages.DefaultIfEmpty()
                            where cd.CirDataId == cirid

                            select new BIRDamangeData()
                            {
                                BladeDescription = crbd == null ? "" : crbd.BladeDescription,
                                BladeEdge = edge == null ? "" : edge.Name,
                                BladeRadius = crbd == null ? "" : SqlFunctions.StringConvert((double)crbd.BladeRadius),
                                SBURecommendation = cr.SBURecommendation,
                                BladeDamageType = bladedamage == null ? "" : bladedamage.Name,
                                BladeFaultCodeClassificationId = crb.BladeFaultCodeClassificationId,
                            }).ToList();

                        tableindex++;

                        if (cir.Count == 0)
                        {
                            keyValues.Add("#BLSL" + tableindex + "DamageType1#", "");
                            keyValues.Add("#BLSL" + tableindex + "Radius1#", "");
                            keyValues.Add("#BLSL" + tableindex + "BladeEdge1#", "");

                            keyValues.Add("#BLSL" + tableindex + "DamageType2#", "");
                            keyValues.Add("#BLSL" + tableindex + "Radius2#", "");
                            keyValues.Add("#BLSL" + tableindex + "BladeEdge2#", "");

                            keyValues.Add("#BLSL" + tableindex + "DamageType3#", "");
                            keyValues.Add("#BLSL" + tableindex + "Radius3#", "");
                            keyValues.Add("#BLSL" + tableindex + "BladeEdge3#", "");

                            keyValues.Add("#BLSL" + tableindex + "Cate1#", "");
                            keyValues.Add("#SBURecommendation" + tableindex + "#", "");

                            continue;
                        }


                        int damagedataindex = 0;
                        string category = "";
                        string SBURecommendation = "";
                        foreach (BIRDamangeData bladeDamageData in cir)
                        {
                            if (bladeDamageData != null)
                            {
                                damagedataindex++;

                                keyValues.Add("#BLSL" + tableindex + "DamageType" + damagedataindex + "#", bladeDamageData.BladeDescription);
                                keyValues.Add("#BLSL" + tableindex + "Radius" + damagedataindex + "#", bladeDamageData.BladeRadius);
                                keyValues.Add("#BLSL" + tableindex + "BladeEdge" + damagedataindex + "#", bladeDamageData.BladeEdge);
                                category = Convert.ToString(bladeDamageData.BladeFaultCodeClassificationId);
                                SBURecommendation = bladeDamageData.SBURecommendation;
                            }
                        }


                        if (damagedataindex == 1)
                        {
                            keyValues.Add("#BLSL" + tableindex + "DamageType2#", "");
                            keyValues.Add("#BLSL" + tableindex + "Radius2#", "");
                            keyValues.Add("#BLSL" + tableindex + "BladeEdge2#", "");
                        }

                        if (damagedataindex == 1 || damagedataindex == 2)
                        {
                            keyValues.Add("#BLSL" + tableindex + "DamageType3#", "");
                            keyValues.Add("#BLSL" + tableindex + "Radius3#", "");
                            keyValues.Add("#BLSL" + tableindex + "BladeEdge3#", "");
                        }
                        keyValues.Add("#BLSL" + tableindex + "Cate1#", category);
                        keyValues.Add("#SBURecommendation" + tableindex + "#", SBURecommendation);

                    }
                }
            }


            catch (Exception ex)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "AddBladeDamageTable blade Damnage Error" + ex.Message, LogType.Error, "");
            }
            return keyValues;
        }

        public static void AddBladePicturesTable_Old(string WordFileName, BIRView birview)
        {

            try
            {
                // Load the document.
                using (DocX document = DocX.Load(WordFileName))
                {
                    int tableindex = 0;
                    using (CIM_CIREntities context = new CIM_CIREntities())
                    {
                        foreach (long CirDataId in birview.Cirs)
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
                                    List<BIRImageData> imagelist = new List<BIRImageData>();
                                    foreach (var img in cirImages)
                                    {
                                        string imgString = img.ImageDataString;
                                        string imgdata = string.Empty;
                                        if (imgString.ToLower().Contains("http:") || imgString.ToLower().Contains("https:"))
                                        {
                                            CloudBlockBlob imgBlob = DABir.GetBlobByImageUrl(imgString);
                                            imgdata = imgBlob.DownloadText();
                                        }
                                        else
                                        {
                                            imgdata = img.ImageDataString.Substring("data:image/jpeg;base64,".Length);
                                        }
                                        imagelist.Add(new BIRImageData { Order = img.ImageOrder, Comment = img.ImageDescription, ImageData = Convert.FromBase64String(imgdata) });
                                    }

                                    foreach (BIRImageData img in imagelist.OrderBy(z => z.Order))
                                    {
                                        if (img.ImageData.Length == 0)
                                            continue;

                                        if (row > 0)
                                            table.InsertRow();

                                        table.InsertRow();

                                        Novacode.Image imag;
                                        using (MemoryStream ms = new MemoryStream(img.ImageData))
                                        {
                                            imag = document.AddImage(ms);
                                        }

                                        Novacode.Picture picture = imag.CreatePicture();
                                        int maxWidth = 600;
                                        int maxHeight = 700;
                                        int newHeight = picture.Height;
                                        int newWidth = picture.Width;
                                        Decimal adjustedLineSpacing = 42.78M;
                                        if (maxWidth > 0 && newWidth > maxWidth) //WidthResize
                                        {
                                            Decimal divider = Math.Abs((Decimal)newWidth / (Decimal)maxWidth);
                                            newWidth = maxWidth;
                                            newHeight = (int)Math.Round((Decimal)(newHeight / divider));
                                        }
                                        if (maxHeight > 0 && newHeight > maxHeight) //HeightResize
                                        {
                                            Decimal divider = Math.Abs((Decimal)newHeight / (Decimal)maxHeight);
                                            newHeight = maxHeight;
                                            newWidth = (int)Math.Round((Decimal)(newWidth / divider));

                                        }
                                        if (newHeight < maxHeight)
                                        {
                                            Decimal divider = Math.Abs((Decimal)newHeight / (Decimal)maxHeight);
                                            adjustedLineSpacing = (Decimal)(adjustedLineSpacing * divider);
                                        }
                                        float lineSpacing = (float)adjustedLineSpacing;
                                        picture.Height = newHeight;
                                        picture.Width = newWidth;
                                        table.Rows[row].Height = newHeight + 12;
                                        //int maxWidth = 635;
                                        //int newWidth = picture.Width;
                                        //if (maxWidth > 0 && newWidth > maxWidth) //WidthResize
                                        //{
                                        //    newWidth = maxWidth;
                                        //}

                                        //picture.Height = 520;
                                        //picture.Width = newWidth;
                                        //table.Rows[row].Height = 526;
                                        table.Rows[row].Cells[0].Paragraphs.First().SetLineSpacing(LineSpacingType.Before, lineSpacing);
                                        table.Rows[row].Cells[0].Paragraphs.First().InsertPicture(picture); // need to cpmplete
                                        table.Rows[row].Cells[0].Paragraphs.First().Alignment = Alignment.center;
                                        string imagedesc = Regex.Split(img.Comment, "##")[1];
                                        table.Rows[row + 1].Cells[0].Paragraphs.First().Append("Picture " + img.Order + " : " + imagedesc);

                                        row = row + 2;
                                    }
                                    foreach (var paragraph in document.Paragraphs)
                                    {
                                        paragraph.FindAll("#TABLE" + tableindex.ToString() + "#").ForEach(index => paragraph.InsertTableAfterSelf((table)));
                                    }
                                }
                                //Remove tag
                                document.ReplaceText("#TABLE" + tableindex.ToString() + "#", "");
                            }
                        }
                        document.Save();
                    }
                }
            }
            catch (Exception oException)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "BIRPdfReport [Inserting Image ] Error:" + oException.Message, LogType.Error, "");
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

        public static void CreateBirWordDoc(string WordFile, Dictionary<string, string> keyValues)
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

        public static byte[] GetPdf(long BirDataId)
        {
            byte[] pdfFile = null;
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                var bir = context.BirWordDocument.Where(x => x.BirDataID == BirDataId).FirstOrDefault();
                if (bir != null)
                {
                    pdfFile = bir.WordDocBytes;
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

        private static void GetBladeRotor(long CirDataId, ref BIRView birview)
        {

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                var cir = context.CirData.Where(x => x.CirDataId == CirDataId && x.Deleted == false).FirstOrDefault();
                if (cir != null)
                {
                    var bladeSerial = context.ComponentInspectionReportBlade.Where(x => x.ComponentInspectionReportId == cir.CirId).Select(x => x.BladeSerialNumber).ToList();
                    foreach (string b in bladeSerial)
                        birview.BladeRotors.Add(b);
                }


            }

        }

        public static BIRView GetBirDataByID(long BirID, out string relatedCIRs)
        {
            BIRView objBIRView = new BIRView();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                var cmd = new SqlCommand { Connection = conn };
                SqlDataReader reader = null;
                relatedCIRs = string.Empty;

                string whereClauseOrder = "";
                whereClauseOrder += "bd.Deleted = 0 AND bd.BirDataID = " + BirID.ToString();

                try
                {
                    cmd.CommandText = string.Format(@"
                                    SELECT [BirDataID],[BirCode], [RevisionNumber],CirDataId, CirId,Created,Createdby,SiteAddress,TurbineNumber,TurbineType,Country,SBU,BladeSerialNos,RepairingSolutions,RawMaterials,ConclusionsAndRecommendations,CommisioningDate
                                    FROM (
	                                    SELECT BD.[BirDataID],BD.[BirCode], BD.[RevisionNumber],
                                    cd.CirDataId, cd.CirId,  CMI.InspectionDate as Created, bd.Createdby, isnull(td.[Site],'')SiteAddress,CMI.TurbineNumber, td.TurbineType,td.Country,sbu.[Name] as SBU,bd.BladeSerialNos,RepairingSolutions,RawMaterials,ConclusionsAndRecommendations,
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
                        objBIRView = new BIRView
                        {
                            BirDataId = reader["BirDataId"] == DBNull.Value ? 0 : Convert.ToInt64(reader["BirDataId"]),
                            BirCode = Convert.ToString(reader["BirCode"]),
                            RevisionNumber = Convert.ToInt32(reader["RevisionNumber"]),
                            CIRDataId = reader["CirDataId"] == DBNull.Value ? 0 : Convert.ToInt64(reader["CirDataId"]),
                            CIRId = reader["CirId"] == DBNull.Value ? 0 : Convert.ToInt64(reader["CirId"]),
                            SiteAddress = Convert.ToString(reader["SiteAddress"]),
                            Created = reader.GetDateTime(reader.GetOrdinal("Created")),
                            Createdby = reader.GetString(reader.GetOrdinal("Createdby")),
                            TurbineNumber = Convert.ToString(reader["TurbineNumber"]),//reader.GetString(reader.GetOrdinal("TurbineNumber")),
                            TurbineType = reader.GetString(reader.GetOrdinal("TurbineType")),
                            Country = reader.GetString(reader.GetOrdinal("Country")),
                            BladeSln = Convert.ToString(reader["BladeSerialNos"]),
                            RepairingSol = Convert.ToString(reader["RepairingSolutions"]),
                            RawMaterial = Convert.ToString(reader["RawMaterials"]),
                            ConculsionRecomm = Convert.ToString(reader["ConclusionsAndRecommendations"]),
                            CommisionDate = reader.GetDateTime(reader.GetOrdinal("CommisioningDate"))
                        };
                    }

                    reader.Close();

                    cmd = new SqlCommand()
                    {
                        Connection = conn,
                        CommandText = string.Format(@"SELECT Cirs FROM (
                                SELECT MAP.BirDataID, STUFF(
                                (SELECT ',' + LTRIM(RTRIM(M.CirDataId))
                                FROM MapBirCir M
                                WHERE MAP.BirDataID = M.BirDataID AND M.Deleted = 0 ORDER BY M.CirDataId
                                FOR XML PATH('')),1,1,'') AS Cirs
                                FROM MapBirCir AS MAP WHERE MAP.DELETED = 0
                                GROUP BY MAP.BirDataID
                                ) BIRMAP WHERE BirDataID = {0}", BirID)
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
                    throw new Exception("Error getting BIR Data");
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

                //objTurbine = DACIRData.GetTurbineRecord(turbineId, context);
                objTurbine = (from c in context.TurbineData.Where(x => x.TurbineId == turbineId)
                              select new CIR.TurbineProperties
                              {
                                  Turbine = c.TurbineId,
                                  // NominelPower =  DBNull.Value,
                                  LocalTurbineId = c.LocalTurbineId
                              }).FirstOrDefault();
            }
            return objTurbine;

        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CIM_MasterDataConn"].ConnectionString;
        }

        #region [BIR 3.1 Changes]

        #region [Add Overall Blade Damage Details in BIR 3.1]

        /// <summary>
        /// Add overall blade damage details in BIR3.1
        /// </summary>
        /// <param name="cirDataId"></param>
        /// <returns></returns>
        public static Dictionary<string, string> AddBladeDamageTable(string wordFileName, List<long> cirDataId)
        {
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            try
            {
                using (CIM_CIREntities context = new CIM_CIREntities())
                {
                    #region [Fetch blades damage data details]

                    int tableindex = 0;
                    List<BIRDamangeData> lstBirDamageData = new List<BIRDamangeData>();
                    foreach (long cirid in cirDataId)
                    {
                        ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "BIRPdfReport blade Damnage [Create Doc ] cir id" + cirid, LogType.Information, "");
                        var cir = (
                            from cr in context.ComponentInspectionReport
                            join cd in context.CirData on cr.ComponentInspectionReportId equals cd.CirId
                            join crb in context.ComponentInspectionReportBlade on cr.ComponentInspectionReportId equals crb.ComponentInspectionReportId
                            join crbd in context.ComponentInspectionReportBladeDamage on crb.ComponentInspectionReportBladeId equals crbd.ComponentInspectionReportBladeId into crbds
                            from crbd in crbds.DefaultIfEmpty()
                            join edge in context.BladeEdge on crbd.BladeEdgeId equals edge.BladeEdgeId into edges
                            from edge in edges.DefaultIfEmpty()
                            join bladedamage in context.BladeInspectionData on crbd.BladeInspectionDataId equals bladedamage.BladeInspectionDataId into bladedamages
                            from bladedamage in bladedamages.DefaultIfEmpty()
                            where cd.CirDataId == cirid

                            select new BIRDamangeData()
                            {
                                CirId = cr.ComponentInspectionReportId,
                                BladeDescription = crbd == null ? "" : crbd.BladeDescription,
                                BladeEdge = edge == null ? "" : edge.Name,
                                BladeRadius = crbd == null ? "" : SqlFunctions.StringConvert((double)crbd.BladeRadius),
                                SBURecommendation = cr.SBURecommendation,
                                BladeDamageType = bladedamage == null ? "" : bladedamage.Name,
                                BladeFaultCodeClassificationId = crb.BladeFaultCodeClassificationId,
                                DamageSeverity = crbd.DamageSeverity,
                                FORMIOImageGUID = crbd.FormIOImageGUID
                            }).ToList();
                        lstBirDamageData.AddRange(cir);
                        tableindex++;
                    }
                    int totalNumberOfCIR = lstBirDamageData.Select(x => x.CirId).Distinct().Count();
                    List<long> lstCirs = lstBirDamageData.Select(x => x.CirId).Distinct().ToList();

                    #endregion [Fetch blades damage data details]

                    //Fetch image and associated blade damage details BIR3.1
                    foreach (var birdamagedata in lstBirDamageData)
                    {
                        birdamagedata.BladeEdge = SetProperBladeEdgeName(birdamagedata.BladeEdge);
                    }
                    try
                    {
                        if (totalNumberOfCIR == 1)
                        {
                            PopulateWordDocumentforFirstCIR(wordFileName, keyValues, context, lstBirDamageData, lstCirs);
                        }
                        else if (totalNumberOfCIR == 2)
                        {
                            PopulateWordDocumentforFirstCIR(wordFileName, keyValues, context, lstBirDamageData, lstCirs);
                            PopulateWordDocumentforSecondCIR(wordFileName, keyValues, context, lstBirDamageData, lstCirs);
                        }
                        else if (totalNumberOfCIR == 3)
                        {
                            PopulateWordDocumentforFirstCIR(wordFileName, keyValues, context, lstBirDamageData, lstCirs);
                            PopulateWordDocumentforSecondCIR(wordFileName, keyValues, context, lstBirDamageData, lstCirs);
                            PopulateWordDocumentforThirdCIR(wordFileName, keyValues, context, lstBirDamageData, lstCirs);
                        }
                    }
                    catch (Exception oException)
                    {
                        ErrorHandling.SystemLog.CirServiceLog("Error occurred in Cir.Sync.Service at AddBladeDamageTable Method", "BIRPdfReport [Inserting Image ] Error" + oException.Message, LogType.Error, "");
                    }

                }
            }
            catch (Exception ex)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "AddBladeDamageTable blade Damnage Error" + ex.Message, LogType.Error, "");
            }
            return keyValues;
        }

        /// <summary>
        /// Populate word document for first CIR
        /// </summary>
        /// <param name="wordFileName"></param>
        /// <param name="imgBytes"></param>
        /// <param name="keyValues"></param>
        /// <param name="context"></param>
        /// <param name="lstBirDamageData"></param>
        /// <param name="lstCirs"></param>
        /// <param name="document"></param>
        private static void PopulateWordDocumentforFirstCIR(string wordFileName, Dictionary<string, string> keyValues, CIM_CIREntities context, List<BIRDamangeData> lstBirDamageData, List<long> lstCirs)
        {
            try
            {
                #region [For First CIR]
                // Load the document.
                using (DocX document = DocX.Load(wordFileName))
                {
                    #region [Set Color in Introduction section of template]

                    document.Tables[2].Rows[0].Cells[1].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                    document.Tables[2].Rows[1].Cells[1].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                    document.Tables[2].Rows[2].Cells[1].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                    document.Tables[2].Rows[3].Cells[1].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                    document.Tables[2].Rows[4].Cells[1].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                    document.Tables[2].Rows[5].Cells[1].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                    document.Tables[2].Rows[6].Cells[1].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                    #endregion [Set Color in Introduction section of template]

                    #region [Displaying blade damages in existing tables]

                    var table = document.AddTable(1, 2);
                    table.AutoFit = AutoFit.Window;
                    table.Alignment = Alignment.left;
                    table.Rows[0].Cells[0].Width = 160;
                    table.Rows[0].Cells[1].Width = 475;

                    table.Rows[0].Cells[0].SetBorder(TableCellBorderType.Left, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table.Rows[0].Cells[0].SetBorder(TableCellBorderType.Right, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table.Rows[0].Cells[0].SetBorder(TableCellBorderType.Top, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table.Rows[0].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));

                    table.Rows[0].Cells[1].SetBorder(TableCellBorderType.Left, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table.Rows[0].Cells[1].SetBorder(TableCellBorderType.Right, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table.Rows[0].Cells[1].SetBorder(TableCellBorderType.Top, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table.Rows[0].Cells[1].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));


                    var table1 = document.AddTable(1, 5);
                    table1.Alignment = Alignment.left;
                    table1.AutoFit = AutoFit.Window;
                    table1.Design = TableDesign.LightShading;

                    table1.Rows[0].Cells[0].Width = 50;
                    table1.Rows[0].Cells[2].Width = 100;
                    table1.Rows[0].Cells[3].Width = 450;
                    table1.Rows[0].Cells[4].Width = 175;

                    //table headings for overall blade damage details
                    table1.Rows[0].Cells[0].Paragraphs.First().Append("No.");
                    table1.Rows[0].Cells[0].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                    table1.Rows[0].Cells[1].Paragraphs.First().Append("Damage Description");
                    table1.Rows[0].Cells[2].Paragraphs.First().Append("Radius");
                    table1.Rows[0].Cells[2].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                    table1.Rows[0].Cells[3].Paragraphs.First().Append("Blade Edge");
                    table1.Rows[0].Cells[4].Paragraphs.First().Append("Category");
                    table1.Rows[0].Cells[4].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);

                    int row = 0;
                    List<BIRDamangeData> lstDamageDataForCIR = lstBirDamageData.Where(x => x.CirId == lstCirs[0]).ToList();
                    int OCOB1 = 0;
                    foreach (BIRDamangeData bdd in lstDamageDataForCIR)
                    {
                        if (bdd.FORMIOImageGUID != null)
                        {


                            Row newRow = table1.InsertRow();
                            string formioImageId = bdd.FORMIOImageGUID.ToString().ToUpper();
                            string imageId = Convert.ToString(context.ImageData.Where(x => (x.FormIOImageGUID != null || x.FormIOImageGUID != "") && x.FormIOImageGUID.ToUpper() == formioImageId).Select(x => x.ImageId).FirstOrDefault());
                            bool? isPlateType = IsPlateType(context, formioImageId);
                            if (Convert.ToBoolean(isPlateType))
                                continue;
                            newRow.Cells[0].Paragraphs.First().Append((row + 1).ToString());
                            newRow.Cells[0].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                            var uri = new Uri("#" + imageId, UriKind.Relative);
                            var hyperLink = document.AddHyperlink(bdd.BladeDescription, uri);
                            newRow.Cells[1].Paragraphs.First().AppendHyperlink(hyperLink).UnderlineStyle(UnderlineStyle.none);
                            //  AddCrossReference(document, newRow.Cells[1].Paragraphs.First(), bdd.BladeDescription, imageId);
                            newRow.Cells[2].Paragraphs.First().Append(bdd.BladeRadius);
                            newRow.Cells[2].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                            newRow.Cells[3].Paragraphs.First().Append(SetProperBladeEdgeName(bdd.BladeEdge));
                            newRow.Cells[4].Paragraphs.First().Append(bdd.DamageSeverity.ToString() + "  ");
                            newRow.Cells[4].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                            if (OCOB1 < bdd.DamageSeverity)
                            {
                                OCOB1 = Convert.ToInt32(bdd.DamageSeverity);
                            }
                            string DocumentPath1 = HttpContext.Current.Server.MapPath("BIRTemplates");
                            try
                            {
                                if (!Directory.Exists(DocumentPath1))
                                {
                                    Directory.CreateDirectory(DocumentPath1);
                                }
                            }
                            catch (Exception ex)
                            {
                                ErrorHandling.SystemLog.CirServiceLog("Error at Cir.Sync.Service", "GetBladeDamageImageWithColoredSeverity Method, Exception Message: " + ex.Message, LogType.Error, "");
                            }

                            Novacode.Image bdsImg;
                            using (MemoryStream bdsMemoryStream = new MemoryStream())
                            {
                                System.Drawing.Image bdsImage = System.Drawing.Image.FromFile(Path.Combine(DocumentPath1, @"Templates\Category" + bdd.DamageSeverity + ".JPG"));
                                bdsImage.Save(bdsMemoryStream, bdsImage.RawFormat);
                                bdsMemoryStream.Seek(0, SeekOrigin.Begin);
                                bdsImg = document.AddImage(bdsMemoryStream); // Create image.
                            }
                            Novacode.Picture dsPic = bdsImg.CreatePicture();
                            dsPic.Height = 10;
                            dsPic.Width = 10;
                            newRow.Cells[4].Paragraphs.First().AppendPicture(dsPic);
                            table1.Rows.Add(newRow);
                            document.Save();
                            row++;
                        }

                    }

                    #endregion [Displaying blade damages in existing tables]

                    #region [Overall Category of Blade]
                    table1.InsertRow();
                    //var OCOB1 = lstDamageDataForCIR.Where(x => x.BladeFaultCodeClassificationId > 0).Select(x => x.BladeFaultCodeClassificationId).FirstOrDefault();
                    table1.Rows.Last().Cells[0].Paragraphs.First().Append("Overall condition of the blade");

                    table1.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Top, new Border(BorderStyle.Tcbs_single, BorderSize.one, 0, System.Drawing.Color.Black));
                    table1.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_single, BorderSize.one, 0, System.Drawing.Color.Black));
                    table1.Rows.Last().Cells[4].Paragraphs.First().Append(OCOB1.ToString() + "  ");
                    table1.Rows.Last().Cells[4].SetBorder(TableCellBorderType.Top, new Border(BorderStyle.Tcbs_single, BorderSize.one, 0, System.Drawing.Color.Black));
                    table1.Rows.Last().Cells[4].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_single, BorderSize.one, 0, System.Drawing.Color.Black));

                    string DocumentPath = HttpContext.Current.Server.MapPath("BIRTemplates");
                    try
                    {
                        if (!Directory.Exists(DocumentPath))
                        {
                            Directory.CreateDirectory(DocumentPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorHandling.SystemLog.CirServiceLog("Error at Cir.Sync.Service", "GetBladeDamageImageWithColoredSeverity Method, Exception Message: " + ex.Message, LogType.Error, "");
                    }

                    Novacode.Image bdsImgOA;
                    using (MemoryStream bdsMemoryStream = new MemoryStream())
                    {
                        System.Drawing.Image bdsImage = System.Drawing.Image.FromFile(Path.Combine(DocumentPath, @"Templates\Category" + OCOB1 + ".JPG"));
                        bdsImage.Save(bdsMemoryStream, bdsImage.RawFormat);
                        bdsMemoryStream.Seek(0, SeekOrigin.Begin);
                        bdsImgOA = document.AddImage(bdsMemoryStream); // Create image.
                    }
                    Novacode.Picture dsPicOA = bdsImgOA.CreatePicture();
                    dsPicOA.Height = 10;
                    dsPicOA.Width = 10;

                    table1.Rows.Last().Cells[4].Paragraphs.First().AppendPicture(dsPicOA);
                    table1.Rows.Last().MergeCells(0, 3);
                    table1.Rows.Last().RemoveParagraphAt(3);
                    table1.Rows.Last().RemoveParagraphAt(2);
                    table1.Rows.Last().RemoveParagraphAt(1);
                    #endregion [Overall Category of Blade]

                    #region [Recommendations]
                    table1.InsertRow();
                    table1.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Left, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Right, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Top, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));

                    table1.InsertRow();
                    table1.Rows.Last().Cells[0].Paragraphs.First().Append("Recommendation");
                    table1.Rows.Last().MergeCells(0, 4);
                    table1.Rows.Last().RemoveParagraphAt(4);
                    table1.Rows.Last().RemoveParagraphAt(3);
                    table1.Rows.Last().RemoveParagraphAt(2);
                    table1.Rows.Last().RemoveParagraphAt(1);

                    table1.InsertRow();
                    table1.Rows.Last().Cells[0].Paragraphs.First().Append(lstDamageDataForCIR[0].SBURecommendation);
                    table1.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().Cells[1].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().Cells[2].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().Cells[3].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().Cells[4].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().MergeCells(0, 4);

                    table1.Rows.Last().RemoveParagraphAt(4);
                    table1.Rows.Last().RemoveParagraphAt(3);
                    table1.Rows.Last().RemoveParagraphAt(2);
                    table1.Rows.Last().RemoveParagraphAt(1);

                    #endregion [Recommendations]

                    #region [Add overall damage image with severity colors]

                    row = 0;
                    byte[] imgBytes = GetBladeInspectionImageWithSeverity(context, lstDamageDataForCIR);
                    Novacode.Image imag;
                    using (MemoryStream ms = new MemoryStream(imgBytes))
                    {
                        imag = document.AddImage(ms);
                    }
                    Novacode.Picture dspicture = imag.CreatePicture();
                    dspicture.Height = 359;
                    dspicture.Width = 153;

                    table.Rows[0].Cells[0].Paragraphs.First().SetLineSpacing(LineSpacingType.Before, 23.83f);
                    //table.Rows[0].Cells[0].Paragraphs.First().SetLineSpacing(LineSpacingType.Before, 22.00f);
                    table.Rows[0].Cells[0].Paragraphs.First().InsertPicture(dspicture);
                    table.Rows[row].Cells[0].Paragraphs.First().Alignment = Alignment.left;

                    table.Rows[0].Cells[1].InsertTable(table1);
                    //Remove tag
                    foreach (var paragraph in document.Paragraphs)
                    {
                        paragraph.FindAll("#BLADEOVERALLDAMAGE1#").ForEach(index => paragraph.InsertTableAfterSelf((table)));
                    }
                    document.ReplaceText("#BLADEOVERALLDAMAGE1#", "");
                    document.Save();

                    #endregion [Add overall damage image with severity colors]
                }
                #endregion [For First CIR]
            }
            catch (Exception ex)
            {
                ErrorHandling.SystemLog.CirServiceLog("Error occurred at PopulateWordDocumentforFirstCIR Method", ex.Message, LogType.Error, string.Empty);
            }
        }

        /// <summary>
        /// Populate BIR word document for second cir
        /// </summary>
        /// <param name="wordFileName"></param>
        /// <param name="imgBytes"></param>
        /// <param name="keyValues"></param>
        /// <param name="context"></param>
        /// <param name="lstBirDamageData"></param>
        /// <param name="lstCirs"></param>
        /// <param name="document"></param>
        private static void PopulateWordDocumentforSecondCIR(string wordFileName, Dictionary<string, string> keyValues, CIM_CIREntities context, List<BIRDamangeData> lstBirDamageData, List<long> lstCirs)
        {
            try
            {
                #region [For Second CIR]
                // Load the document.
                using (DocX document = DocX.Load(wordFileName))
                {
                    #region [Displaying blade damages in existing tables]                   

                    var table = document.AddTable(1, 2);
                    table.AutoFit = AutoFit.Window;
                    table.Alignment = Alignment.left;
                    table.Rows[0].Cells[0].Width = 160;
                    table.Rows[0].Cells[1].Width = 475;

                    table.Rows[0].Cells[0].SetBorder(TableCellBorderType.Left, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table.Rows[0].Cells[0].SetBorder(TableCellBorderType.Right, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table.Rows[0].Cells[0].SetBorder(TableCellBorderType.Top, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table.Rows[0].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));

                    table.Rows[0].Cells[1].SetBorder(TableCellBorderType.Left, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table.Rows[0].Cells[1].SetBorder(TableCellBorderType.Right, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table.Rows[0].Cells[1].SetBorder(TableCellBorderType.Top, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table.Rows[0].Cells[1].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));


                    var table1 = document.AddTable(1, 5);
                    table1.Alignment = Alignment.left;
                    table1.AutoFit = AutoFit.Window;
                    table1.Design = TableDesign.LightShading;
                    table1.Rows[0].Cells[0].Width = 50;
                    table1.Rows[0].Cells[2].Width = 100;
                    table1.Rows[0].Cells[3].Width = 450;
                    table1.Rows[0].Cells[4].Width = 175;
                    //table headings for overall blade damage details
                    table1.Rows[0].Cells[0].Paragraphs.First().Append("No.");
                    table1.Rows[0].Cells[0].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                    table1.Rows[0].Cells[1].Paragraphs.First().Append("Damage Description");
                    table1.Rows[0].Cells[2].Paragraphs.First().Append("Radius");
                    table1.Rows[0].Cells[2].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                    table1.Rows[0].Cells[3].Paragraphs.First().Append("Blade Edge");
                    table1.Rows[0].Cells[4].Paragraphs.First().Append("Category");
                    table1.Rows[0].Cells[4].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);

                    int row = 0;
                    List<BIRDamangeData> lstDamageDataForCIR = lstBirDamageData.Where(x => x.CirId == lstCirs[1]).ToList();
                    int OCOB = 0;
                    foreach (BIRDamangeData bdd in lstDamageDataForCIR)
                    {
                        if (bdd.FORMIOImageGUID != null)
                        {


                            Row newRow = table1.InsertRow();
                            string formioImageId = bdd.FORMIOImageGUID.ToString().ToUpper();
                            string imageId = Convert.ToString(context.ImageData.Where(x => (x.FormIOImageGUID != null || x.FormIOImageGUID != "") && x.FormIOImageGUID.ToUpper() == formioImageId).Select(x => x.ImageId).FirstOrDefault());
                            bool? isPlateType = IsPlateType(context, formioImageId);
                            if (Convert.ToBoolean(isPlateType))
                                continue;

                            newRow.Cells[0].Paragraphs.First().Append((row + 1).ToString());
                            newRow.Cells[0].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                            var uri = new Uri("#" + imageId, UriKind.Relative);
                            var hyperLink = document.AddHyperlink(bdd.BladeDescription, uri);
                            newRow.Cells[1].Paragraphs.First().AppendHyperlink(hyperLink).UnderlineStyle(UnderlineStyle.none);
                            // AddCrossReference(document, newRow.Cells[1].Paragraphs.First(), bdd.BladeDescription, imageId);
                            newRow.Cells[2].Paragraphs.First().Append(bdd.BladeRadius);
                            newRow.Cells[2].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                            newRow.Cells[3].Paragraphs.First().Append(SetProperBladeEdgeName(bdd.BladeEdge));
                            newRow.Cells[4].Paragraphs.First().Append(bdd.DamageSeverity.ToString() + "  ");
                            newRow.Cells[4].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                            newRow.Cells[1].Paragraphs.First().Alignment = Alignment.left;
                            if (OCOB < bdd.DamageSeverity)
                            {
                                OCOB = Convert.ToInt32(bdd.DamageSeverity);
                            }
                            string DocumentPath2 = HttpContext.Current.Server.MapPath("BIRTemplates");
                            try
                            {
                                if (!Directory.Exists(DocumentPath2))
                                {
                                    Directory.CreateDirectory(DocumentPath2);
                                }
                            }
                            catch (Exception ex)
                            {
                                ErrorHandling.SystemLog.CirServiceLog("Error at Cir.Sync.Service", "GetBladeDamageImageWithColoredSeverity Method, Exception Message: " + ex.Message, LogType.Error, "");
                            }
                            Novacode.Image bdsImg;
                            using (MemoryStream bdsMemoryStream = new MemoryStream())
                            {
                                System.Drawing.Image bdsImage = System.Drawing.Image.FromFile(Path.Combine(DocumentPath2, @"Templates\Category" + bdd.DamageSeverity + ".JPG"));
                                bdsImage.Save(bdsMemoryStream, bdsImage.RawFormat);
                                bdsMemoryStream.Seek(0, SeekOrigin.Begin);
                                bdsImg = document.AddImage(bdsMemoryStream); // Create image.
                            }
                            Novacode.Picture dsPic = bdsImg.CreatePicture();
                            dsPic.Height = 10;
                            dsPic.Width = 10;
                            newRow.Cells[4].Paragraphs.First().AppendPicture(dsPic);
                            table1.Rows.Add(newRow);
                            document.Save();
                            row++;
                        }

                    }

                    #endregion [Displaying blade damages in existing tables]

                    #region [Overall Category of Blade]
                    table1.InsertRow();
                    //var OCOB = lstDamageDataForCIR.Where(x => x.BladeFaultCodeClassificationId > 0).Select(x => x.BladeFaultCodeClassificationId).FirstOrDefault();
                    table1.Rows.Last().Cells[0].Paragraphs.First().Append("Overall condition of the blade");
                    table1.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Top, new Border(BorderStyle.Tcbs_single, BorderSize.one, 0, System.Drawing.Color.Black));
                    table1.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_single, BorderSize.one, 0, System.Drawing.Color.Black));
                    table1.Rows.Last().Cells[4].Paragraphs.First().Append(OCOB.ToString() + "  ");
                    table1.Rows.Last().Cells[4].SetBorder(TableCellBorderType.Top, new Border(BorderStyle.Tcbs_single, BorderSize.one, 0, System.Drawing.Color.Black));
                    table1.Rows.Last().Cells[4].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_single, BorderSize.one, 0, System.Drawing.Color.Black));
                    string DocumentPath = HttpContext.Current.Server.MapPath("BIRTemplates");
                    try
                    {
                        if (!Directory.Exists(DocumentPath))
                        {
                            Directory.CreateDirectory(DocumentPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorHandling.SystemLog.CirServiceLog("Error at Cir.Sync.Service", "GetBladeDamageImageWithColoredSeverity Method, Exception Message: " + ex.Message, LogType.Error, "");
                    }
                    Novacode.Image bdsImgOA;
                    using (MemoryStream bdsMemoryStream = new MemoryStream())
                    {
                        System.Drawing.Image bdsImage = System.Drawing.Image.FromFile(Path.Combine(DocumentPath, @"Templates\Category" + OCOB + ".JPG"));
                        bdsImage.Save(bdsMemoryStream, bdsImage.RawFormat);
                        bdsMemoryStream.Seek(0, SeekOrigin.Begin);
                        bdsImgOA = document.AddImage(bdsMemoryStream); // Create image.
                    }
                    Novacode.Picture dsPicOA = bdsImgOA.CreatePicture();
                    dsPicOA.Height = 10;
                    dsPicOA.Width = 10;

                    table1.Rows.Last().Cells[4].Paragraphs.First().AppendPicture(dsPicOA);
                    table1.Rows.Last().MergeCells(0, 3);

                    table1.Rows.Last().RemoveParagraphAt(3);
                    table1.Rows.Last().RemoveParagraphAt(2);
                    table1.Rows.Last().RemoveParagraphAt(1);
                    #endregion [Overall Category of Blade]

                    #region [Recommendations]
                    table1.InsertRow();
                    table1.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Left, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Right, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Top, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));

                    table1.InsertRow();
                    table1.Rows.Last().Cells[0].Paragraphs.First().Append("Recommendation");
                    table1.Rows.Last().MergeCells(0, 4);

                    table1.Rows.Last().RemoveParagraphAt(4);
                    table1.Rows.Last().RemoveParagraphAt(3);
                    table1.Rows.Last().RemoveParagraphAt(2);
                    table1.Rows.Last().RemoveParagraphAt(1);

                    table1.InsertRow();
                    table1.Rows.Last().Cells[0].Paragraphs.First().Append(lstDamageDataForCIR[0].SBURecommendation);
                    table1.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().Cells[1].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().Cells[2].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().Cells[3].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().Cells[4].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().MergeCells(0, 4);

                    table1.Rows.Last().RemoveParagraphAt(4);
                    table1.Rows.Last().RemoveParagraphAt(3);
                    table1.Rows.Last().RemoveParagraphAt(2);
                    table1.Rows.Last().RemoveParagraphAt(1);
                    #endregion [Recommendations]

                    #region [Add overall damage image with severity colors]

                    row = 0;
                    byte[] imgBytes = GetBladeInspectionImageWithSeverity(context, lstDamageDataForCIR);
                    Novacode.Image imag;
                    using (MemoryStream ms = new MemoryStream(imgBytes))
                    {
                        imag = document.AddImage(ms);
                    }
                    Novacode.Picture dspicture = imag.CreatePicture();
                    dspicture.Height = 359;
                    dspicture.Width = 153;

                    table.Rows[0].Cells[0].Paragraphs.First().SetLineSpacing(LineSpacingType.Before, 23.83f);
                    //table.Rows[0].Cells[0].Paragraphs.First().SetLineSpacing(LineSpacingType.Before, 22.00f);
                    table.Rows[0].Cells[0].Paragraphs.First().InsertPicture(dspicture);
                    table.Rows[row].Cells[0].Paragraphs.First().Alignment = Alignment.left;

                    table.Rows[0].Cells[1].InsertTable(table1);
                    //Remove tag
                    foreach (var paragraph in document.Paragraphs)
                    {
                        paragraph.FindAll("#BLADEOVERALLDAMAGE2#").ForEach(index => paragraph.InsertTableAfterSelf((table)));
                    }
                    document.ReplaceText("#BLADEOVERALLDAMAGE2#", "");
                    document.Save();

                    #endregion [Add overall damage image with severity colors]
                }
                #endregion [For Second CIR]
            }
            catch (Exception ex)
            {
                ErrorHandling.SystemLog.CirServiceLog("Error occurred at PopulateWordDocumentforSecondCIR Method", ex.Message, LogType.Error, string.Empty);
            }
        }

        /// <summary>
        /// Populate BIR word document for third CIR
        /// </summary>
        /// <param name="wordFileName"></param>
        /// <param name="imgBytes"></param>
        /// <param name="keyValues"></param>
        /// <param name="context"></param>
        /// <param name="lstBirDamageData"></param>
        /// <param name="lstCirs"></param>
        /// <param name="document"></param>
        private static void PopulateWordDocumentforThirdCIR(string wordFileName, Dictionary<string, string> keyValues, CIM_CIREntities context, List<BIRDamangeData> lstBirDamageData, List<long> lstCirs)
        {
            try
            {
                #region [For Third CIR]
                // Load the document.
                using (DocX document = DocX.Load(wordFileName))
                {
                    #region [Displaying blade damages in existing tables]

                    var table = document.AddTable(1, 2);
                    table.AutoFit = AutoFit.Window;
                    table.Alignment = Alignment.left;
                    table.Rows[0].Cells[0].Width = 160;
                    table.Rows[0].Cells[1].Width = 475;

                    table.Rows[0].Cells[0].SetBorder(TableCellBorderType.Left, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table.Rows[0].Cells[0].SetBorder(TableCellBorderType.Right, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table.Rows[0].Cells[0].SetBorder(TableCellBorderType.Top, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table.Rows[0].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));

                    table.Rows[0].Cells[1].SetBorder(TableCellBorderType.Left, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table.Rows[0].Cells[1].SetBorder(TableCellBorderType.Right, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table.Rows[0].Cells[1].SetBorder(TableCellBorderType.Top, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table.Rows[0].Cells[1].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));


                    var table1 = document.AddTable(1, 5);
                    table1.Alignment = Alignment.left;
                    table1.AutoFit = AutoFit.Window;
                    table1.Design = TableDesign.LightShading;

                    table1.Rows[0].Cells[0].Width = 50;
                    table1.Rows[0].Cells[2].Width = 100;
                    table1.Rows[0].Cells[3].Width = 450;
                    table1.Rows[0].Cells[4].Width = 175;

                    //table headings for overall blade damage details
                    table1.Rows[0].Cells[0].Paragraphs.First().Append("No.");
                    table1.Rows[0].Cells[0].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                    table1.Rows[0].Cells[1].Paragraphs.First().Append("Damage Description");
                    table1.Rows[0].Cells[2].Paragraphs.First().Append("Radius");
                    table1.Rows[0].Cells[2].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                    table1.Rows[0].Cells[3].Paragraphs.First().Append("Blade Edge");
                    table1.Rows[0].Cells[4].Paragraphs.First().Append("Category");
                    table1.Rows[0].Cells[4].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);

                    int row = 0;
                    List<BIRDamangeData> lstDamageDataForCIR = lstBirDamageData.Where(x => x.CirId == lstCirs[2]).ToList();
                    int OCOB = 0;
                    foreach (BIRDamangeData bdd in lstDamageDataForCIR)
                    {
                        if (bdd.FORMIOImageGUID != null)
                        {
                            Row newRow = table1.InsertRow();
                            string formioImageId = bdd.FORMIOImageGUID.ToString().ToUpper();
                            string imageId = Convert.ToString(context.ImageData.Where(x => (x.FormIOImageGUID != null || x.FormIOImageGUID != "") && x.FormIOImageGUID.ToUpper() == formioImageId).Select(x => x.ImageId).FirstOrDefault());
                            bool? isPlateType = IsPlateType(context, formioImageId);
                            if (Convert.ToBoolean(isPlateType))
                                continue;

                            newRow.Cells[0].Paragraphs.First().Append((row + 1).ToString());
                            newRow.Cells[0].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                            var uri = new Uri("#" + imageId, UriKind.Relative);
                            var hyperLink = document.AddHyperlink(bdd.BladeDescription, uri);
                            newRow.Cells[1].Paragraphs.First().AppendHyperlink(hyperLink).UnderlineStyle(UnderlineStyle.none);
                            // AddCrossReference(document, newRow.Cells[1].Paragraphs.First(), bdd.BladeDescription, imageId);
                            newRow.Cells[2].Paragraphs.First().Append(bdd.BladeRadius);
                            newRow.Cells[2].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                            newRow.Cells[3].Paragraphs.First().Append(SetProperBladeEdgeName(bdd.BladeEdge));
                            newRow.Cells[4].Paragraphs.First().Append(bdd.DamageSeverity.ToString() + "  ");
                            newRow.Cells[4].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                            newRow.Cells[1].Paragraphs.First().Alignment = Alignment.left;
                            if (OCOB < bdd.DamageSeverity)
                            {
                                OCOB = Convert.ToInt32(bdd.DamageSeverity);
                            }
                            string DocumentPath3 = HttpContext.Current.Server.MapPath("BIRTemplates");
                            try
                            {
                                if (!Directory.Exists(DocumentPath3))
                                {
                                    Directory.CreateDirectory(DocumentPath3);
                                }
                            }
                            catch (Exception ex)
                            {
                                ErrorHandling.SystemLog.CirServiceLog("Error at Cir.Sync.Service", "GetBladeDamageImageWithColoredSeverity Method, Exception Message: " + ex.Message, LogType.Error, "");
                            }
                            Novacode.Image bdsImg;
                            using (MemoryStream bdsMemoryStream = new MemoryStream())
                            {
                                System.Drawing.Image bdsImage = System.Drawing.Image.FromFile(Path.Combine(DocumentPath3, @"Templates\Category" + bdd.DamageSeverity + ".JPG"));
                                bdsImage.Save(bdsMemoryStream, bdsImage.RawFormat);
                                bdsMemoryStream.Seek(0, SeekOrigin.Begin);
                                bdsImg = document.AddImage(bdsMemoryStream); // Create image.
                            }
                            Novacode.Picture dsPic = bdsImg.CreatePicture();
                            dsPic.Height = 10;
                            dsPic.Width = 10;
                            newRow.Cells[4].Paragraphs.First().AppendPicture(dsPic);
                            table1.Rows.Add(newRow);
                            document.Save();
                            row++;
                        }

                    }

                    #endregion [Displaying blade damages in existing tables]

                    #region [Overall Category of Blade]
                    table1.InsertRow();
                    // var OCOB = lstDamageDataForCIR.Where(x => x.BladeFaultCodeClassificationId > 0).Select(x => x.BladeFaultCodeClassificationId).FirstOrDefault();
                    table1.Rows.Last().Cells[0].Paragraphs.First().Append("Overall condition of the blade");
                    table1.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Top, new Border(BorderStyle.Tcbs_single, BorderSize.one, 0, System.Drawing.Color.Black));
                    table1.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_single, BorderSize.one, 0, System.Drawing.Color.Black));
                    table1.Rows.Last().Cells[4].Paragraphs.First().Append(OCOB.ToString() + "  ");
                    table1.Rows.Last().Cells[4].SetBorder(TableCellBorderType.Top, new Border(BorderStyle.Tcbs_single, BorderSize.one, 0, System.Drawing.Color.Black));
                    table1.Rows.Last().Cells[4].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_single, BorderSize.one, 0, System.Drawing.Color.Black));
                    string DocumentPath = HttpContext.Current.Server.MapPath("BIRTemplates");
                    try
                    {
                        if (!Directory.Exists(DocumentPath))
                        {
                            Directory.CreateDirectory(DocumentPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorHandling.SystemLog.CirServiceLog("Error at Cir.Sync.Service", "GetBladeDamageImageWithColoredSeverity Method, Exception Message: " + ex.Message, LogType.Error, "");
                    }

                    Novacode.Image bdsImgOA;
                    using (MemoryStream bdsMemoryStream = new MemoryStream())
                    {
                        System.Drawing.Image bdsImage = System.Drawing.Image.FromFile(Path.Combine(DocumentPath, @"Templates\Category" + OCOB + ".JPG"));
                        bdsImage.Save(bdsMemoryStream, bdsImage.RawFormat);
                        bdsMemoryStream.Seek(0, SeekOrigin.Begin);
                        bdsImgOA = document.AddImage(bdsMemoryStream); // Create image.
                    }
                    Novacode.Picture dsPicOA = bdsImgOA.CreatePicture();
                    dsPicOA.Height = 10;
                    dsPicOA.Width = 10;

                    table1.Rows.Last().Cells[4].Paragraphs.First().AppendPicture(dsPicOA);
                    table1.Rows.Last().MergeCells(0, 3);

                    table1.Rows.Last().RemoveParagraphAt(3);
                    table1.Rows.Last().RemoveParagraphAt(2);
                    table1.Rows.Last().RemoveParagraphAt(1);
                    #endregion [Overall Category of Blade]

                    #region [Recommendations]
                    table1.InsertRow();
                    table1.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Left, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Right, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Top, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));

                    table1.InsertRow();
                    table1.Rows.Last().Cells[0].Paragraphs.First().Append("Recommendation");
                    table1.Rows.Last().MergeCells(0, 4);

                    table1.Rows.Last().RemoveParagraphAt(4);
                    table1.Rows.Last().RemoveParagraphAt(3);
                    table1.Rows.Last().RemoveParagraphAt(2);
                    table1.Rows.Last().RemoveParagraphAt(1);

                    table1.InsertRow();
                    table1.Rows.Last().Cells[0].Paragraphs.First().Append(lstDamageDataForCIR[0].SBURecommendation);
                    table1.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().Cells[1].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().Cells[2].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().Cells[3].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().Cells[4].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                    table1.Rows.Last().MergeCells(0, 4);

                    table1.Rows.Last().RemoveParagraphAt(4);
                    table1.Rows.Last().RemoveParagraphAt(3);
                    table1.Rows.Last().RemoveParagraphAt(2);
                    table1.Rows.Last().RemoveParagraphAt(1);

                    #endregion [Recommendations]

                    #region [Add overall damage image with severity colors]

                    row = 0;
                    byte[] imgBytes = GetBladeInspectionImageWithSeverity(context, lstDamageDataForCIR);
                    Novacode.Image imag;
                    using (MemoryStream ms = new MemoryStream(imgBytes))
                    {
                        imag = document.AddImage(ms);
                    }
                    Novacode.Picture dspicture = imag.CreatePicture();
                    dspicture.Height = 359;
                    dspicture.Width = 153;

                    table.Rows[0].Cells[0].Paragraphs.First().SetLineSpacing(LineSpacingType.Before, 23.83f);
                    //table.Rows[0].Cells[0].Paragraphs.First().SetLineSpacing(LineSpacingType.Before, 22.00f);
                    table.Rows[0].Cells[0].Paragraphs.First().InsertPicture(dspicture);
                    table.Rows[row].Cells[0].Paragraphs.First().Alignment = Alignment.left;

                    table.Rows[0].Cells[1].InsertTable(table1);
                    //Remove tag
                    foreach (var paragraph in document.Paragraphs)
                    {
                        paragraph.FindAll("#BLADEOVERALLDAMAGE3#").ForEach(index => paragraph.InsertTableAfterSelf((table)));
                    }
                    document.ReplaceText("#BLADEOVERALLDAMAGE3#", "");
                    document.Save();

                    #endregion [Add overall damage image with severity colors]
                }
                #endregion [For Third CIR]
            }
            catch (Exception ex)
            {
                ErrorHandling.SystemLog.CirServiceLog("Error occurred at PopulateWordDocumentforThirdCIR Method", ex.Message, LogType.Error, string.Empty);
            }
        }

        /// <summary>
        /// Check whether picture is plate type or not
        /// </summary>
        /// <param name="context"></param>
        /// <param name="formioImageId"></param>
        /// <returns></returns>
        private static bool? IsPlateType(CIM_CIREntities context, string formioImageId)
        {
            bool? result = false;
            try
            {
                result = context.ImageData.Where(x => (x.FormIOImageGUID != null || x.FormIOImageGUID != "") && x.FormIOImageGUID.ToUpper() == formioImageId).Select(x => x.IsPlateType).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ErrorHandling.SystemLog.CirServiceLog("Error occurred at IsPlateType Method", ex.Message, LogType.Error, string.Empty);
            }
            return result;
        }

        /// <summary>
        /// Add cross reference in the word document
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="p"></param>
        /// <param name="crossreftext"></param>
        /// <param name="destination"></param>
        public static void AddCrossReference(DocX doc, Paragraph p, string crossreftext, string destination)
        {
            XNamespace ns = doc.Xml.Name.NamespaceName;
            XNamespace xmlSpace = doc.Xml.GetNamespaceOfPrefix("xml");
            p = p.Append("");
            p.Xml.Add(new XElement(ns + "r", new XElement(ns + "fldChar", new XAttribute(ns + "fldCharType", "begin"))));
            p.Xml.Add(new XElement(ns + "r", new XElement(ns + "instrText", new XAttribute(xmlSpace + "space", "preserve"), String.Format(" PAGEREF {0} \\h ", destination))));
            p.Xml.Add(new XElement(ns + "r", new XElement(ns + "fldChar", new XAttribute(ns + "fldCharType", "separate"))));
            p.Xml.Add(new XElement(ns + "r", new XElement(ns + "rPr", new XElement(ns + "noProof")), new XElement(ns + "t", crossreftext)));
            p.Xml.Add(new XElement(ns + "r", new XElement(ns + "fldChar", new XAttribute(ns + "fldCharType", "end"))));
            //p = p.Append(")");
        }

        #endregion [Add Overall Blade Damage Details in BIR 3.1]

        #region [Add Blade Pictures in BIR3.1]

        /// <summary>
        /// Add blade pictures and damages in BIR3.1 template
        /// </summary>
        /// <param name="WordFileName"></param>
        /// <param name="birview"></param>
        public static void AddBladePicturesTable(string WordFileName, BIRView birview)
        {
            //Fetch image and associated blade damage details BIR3.1
            try
            {
                // Load the document.
                using (DocX document = DocX.Load(WordFileName))
                {
                    int tableindex = 0;
                    using (CIM_CIREntities context = new CIM_CIREntities())
                    {
                        foreach (long CirDataId in birview.Cirs)
                        {
                            var cir = context.CirData.Where(x => x.CirDataId == CirDataId && x.Deleted == false).FirstOrDefault();
                            if (cir != null)
                            {
                                tableindex++;
                                #region [Add Table to show blade inspection image details]
                                var table = document.AddTable(1, 1);
                                table.Alignment = Alignment.left;
                                table.AutoFit = AutoFit.Window;

                                int row = 0;
                                #endregion [Add Table to show blade inspection image details]

                                var cirImages = context.ImageData.Where(x => (x.FormIOImageGUID != null || x.FormIOImageGUID != "") && x.ComponentInspectionReportId == cir.CirId).ToList();
                                if (cirImages.Count > 0)
                                {
                                    #region [Get BIR Image Data]

                                    List<BIRImageData> imagelist = new List<BIRImageData>();
                                    foreach (var img in cirImages)
                                    {
                                        if (string.IsNullOrEmpty(img.FormIOImageGUID))
                                            continue;
                                        string imgString = img.ImageDataString;
                                        string imgdata = string.Empty;
                                        if (imgString.ToLower().Contains("http:") || imgString.ToLower().Contains("https:"))
                                        {

                                            string wordBlobUri = imgString.ToString() + DABir.GetBlobSASUri(imgString);
                                            CloudBlockBlob imgBlob = new CloudBlockBlob(new Uri(wordBlobUri + "&sr=b"));
                                            imgdata = imgBlob.DownloadText();
                                        }
                                        else
                                        {
                                            imgdata = img.ImageDataString.Substring("data:image/jpeg;base64,".Length);
                                        }
                                        Guid formioImageId = new Guid(img.FormIOImageGUID);
                                        var bladedata = context.ComponentInspectionReportBlade.Where(x => x.ComponentInspectionReportId == cir.CirId).FirstOrDefault();
                                        var imgDamage = context.ComponentInspectionReportBladeDamage.Where(x => x.FormIOImageGUID == formioImageId).FirstOrDefault();
                                        if (imgDamage == null && img.IsPlateType == false)
                                        {
                                            int isDamage = -1;
                                            var damageData = context.ComponentInspectionReportBladeDamage.Where(x => (x.ComponentInspectionReportBladeId == bladedata.ComponentInspectionReportBladeId)).ToList();
                                            foreach (ComponentInspectionReportBladeDamage damage in damageData)
                                            {
                                                string[] picures = damage.BladePictureNumber.Split(',');
                                                int index = Array.FindIndex(picures, x => x.Equals(Convert.ToString(img.ImageOrder)));
                                                if (index > -1)
                                                { isDamage = index; break; }
                                            }

                                            string bladeSection = img.ImageDescription != null ? (Regex.Split(Regex.Split(Regex.Split(img.ImageDescription, "##")[1], "-")[0], " ")[1]) : "";
                                            string edgeName = img.ImageDescription != null ? (Regex.Split(Regex.Split(Regex.Split(img.ImageDescription, "##")[1], "-")[0], " ")[0]) : "";
                                            string BlEdge = edgeName == "WW" ? WW : (edgeName == "LW" ? LW : (edgeName == "TE" ? TE : (edgeName == "LE" ? LE : string.Empty)));
                                            imagelist.Add(new BIRImageData
                                            {
                                                Order = img.ImageOrder,
                                                Comment = img.ImageDescription,
                                                ImageData = Convert.FromBase64String(imgdata),
                                                DamageIdentified = isDamage < 0 ? "No" : "Existing",
                                                Radius = 0,
                                                BladeEdge = BlEdge,
                                                BladeEdgeId = 0,
                                                DamageDescription = "N/A",
                                                Category = 0,
                                                BladeSection = img.IsPlateType == false ? bladeSection : string.Empty,
                                                FormIOImageGUID = img.FormIOImageGUID,
                                                ImageId = img.ImageId,
                                                IsPlateType = img.IsPlateType
                                            });
                                        }
                                        else
                                        {
                                            imagelist.Add(new BIRImageData
                                            {
                                                Order = img.ImageOrder,
                                                Comment = img.IsPlateType == false ? img.ImageDescription : string.Empty,
                                                ImageData = Convert.FromBase64String(imgdata),
                                                DamageIdentified = img.IsPlateType == false ? (imgDamage.DamageSeverity > 0 ? "Yes" : "No") : string.Empty,
                                                Radius = img.IsPlateType == false ? imgDamage.BladeRadius : 0,
                                                BladeEdge = img.IsPlateType == false ? SetProperBladeEdgeName(context.BladeEdge.Where(x => x.BladeEdgeId == imgDamage.BladeEdgeId).Select(x => x.Name).FirstOrDefault()) : string.Empty,
                                                BladeEdgeId = img.IsPlateType == false ? imgDamage.BladeEdgeId : 0,
                                                DamageDescription = img.IsPlateType == false ? imgDamage.BladeDescription : string.Empty,
                                                Category = img.IsPlateType == false ? imgDamage.DamageSeverity : 0,
                                                BladeSection = (img.IsPlateType == false && img.ImageDescription != null) ? (Regex.Split(Regex.Split(Regex.Split(img.ImageDescription, "##")[1], "-")[0], " ")[1]) : string.Empty,
                                                FormIOImageGUID = img.FormIOImageGUID,
                                                ImageId = img.ImageId,
                                                IsPlateType = img.IsPlateType
                                            });
                                        }

                                    }

                                    #endregion [Get BIR Image Data]
                                    imagelist = imagelist.OrderBy(x => x.Order).ToList();
                                    foreach (BIRImageData img in imagelist.OrderBy(z => z.ImageOrder))
                                    {
                                        #region [Adding 3 Rows in the table]

                                        if (img.ImageData.Length == 0)
                                            continue;
                                        //Insert rows in table
                                        if (row > 0)
                                            table.InsertRow();
                                        table.InsertRow();
                                        table.InsertRow();

                                        #endregion [Adding 3 Rows in the table]

                                        #region [Row 1: Insert Blade Inspection Image]

                                        Novacode.Image imag;
                                        using (MemoryStream ms = new MemoryStream(img.ImageData))
                                        {
                                            imag = document.AddImage(ms);
                                        }
                                        Novacode.Picture picture = imag.CreatePicture();
                                        //int maxWidth = 600;
                                        //int maxHeight = 382;
                                        //int newHeight = picture.Height;
                                        //int newWidth = picture.Width;
                                        //if (maxWidth > 0 && newWidth > maxWidth) //WidthResize
                                        //{
                                        //    Decimal divider = Math.Abs((Decimal)newWidth / (Decimal)maxWidth);
                                        //    newWidth = maxWidth;
                                        //    newHeight = (int)Math.Round((Decimal)(newHeight / divider));
                                        //}
                                        //if (maxHeight > 0 && newHeight > maxHeight) //HeightResize
                                        //{
                                        //    Decimal divider = Math.Abs((Decimal)newHeight / (Decimal)maxHeight);
                                        //    newHeight = maxHeight;
                                        //    newWidth = (int)Math.Round((Decimal)(newWidth / divider));
                                        //}

                                        //picture.Height = newHeight;
                                        //picture.Width = newWidth;
                                        //table.Rows[row].Height = newHeight + 2;

                                        int maxWidth = 635;
                                        int newWidth = picture.Width;
                                        if (maxWidth > 0 && newWidth > maxWidth)
                                        {
                                            newWidth = maxWidth;
                                        }

                                        picture.Height = 382;
                                        picture.Width = newWidth;

                                        //Configure table row settings
                                        table.Rows[row].Height = 384;
                                        table.Rows[row].Cells[0].Paragraphs.First().AppendBookmark(img.ImageId.ToString());
                                        table.Rows[row].Cells[0].Paragraphs.First().SetLineSpacing(LineSpacingType.Before, 23.331f);
                                        table.Rows[row].Cells[0].Paragraphs.First().InsertPicture(picture);
                                        table.Rows[row].Cells[0].MarginBottom = 5;
                                        table.Rows[row].Cells[0].Paragraphs.First().Alignment = Alignment.center;
                                        #endregion [Row 1: Insert Blade Inspection Image]

                                        #region [Row 2: Insert Blade Inspection Image Description]


                                        string imagedesc = (img.IsPlateType == false && img.Comment != null) ? (Regex.Split(img.Comment, "##")[1]) : "Plate Type";
                                        table.Rows[row + 1].Cells[0].Paragraphs.First().Append("Picture " + img.Order + " : " + imagedesc);

                                        #endregion [Row 2: Insert Blade Inspection Image Description]

                                        #region [Set borders]

                                        table.Rows[row].Cells[0].SetBorder(TableCellBorderType.Top, new Border(BorderStyle.Tcbs_single, BorderSize.one, 0, System.Drawing.Color.Black));
                                        table.Rows[row].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_single, BorderSize.one, 0, System.Drawing.Color.Black));
                                        table.Rows[row].Cells[0].SetBorder(TableCellBorderType.Left, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                                        table.Rows[row].Cells[0].SetBorder(TableCellBorderType.Right, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));

                                        table.Rows[row + 1].Cells[0].SetBorder(TableCellBorderType.Top, new Border(BorderStyle.Tcbs_single, BorderSize.one, 0, System.Drawing.Color.Black));
                                        table.Rows[row + 1].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_single, BorderSize.one, 0, System.Drawing.Color.Black));
                                        table.Rows[row + 1].Cells[0].SetBorder(TableCellBorderType.Left, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                                        table.Rows[row + 1].Cells[0].SetBorder(TableCellBorderType.Right, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));


                                        table.Rows[row + 2].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                                        table.Rows[row + 2].Cells[0].SetBorder(TableCellBorderType.Left, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                                        table.Rows[row + 2].Cells[0].SetBorder(TableCellBorderType.Right, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                                        table.Rows[row + 2].Cells[0].SetBorder(TableCellBorderType.Top, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));

                                        #endregion [Set borders]

                                        if (img.IsPlateType == false && img.DamageIdentified != "Existing")
                                        {
                                            #region [Row 3: Add Damage Image and Damage Description]

                                            #region [Row 3: Insert Blade Damage Image With Severity]

                                            var diTable = document.AddTable(1, 2);
                                            diTable.AutoFit = AutoFit.Window;
                                            diTable.Alignment = Alignment.center;

                                            //set borders
                                            diTable.Rows[0].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                                            diTable.Rows[0].Cells[0].SetBorder(TableCellBorderType.Left, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                                            diTable.Rows[0].Cells[0].SetBorder(TableCellBorderType.Right, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                                            diTable.Rows[0].Cells[0].SetBorder(TableCellBorderType.Top, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));

                                            diTable.Rows[0].Cells[1].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                                            diTable.Rows[0].Cells[1].SetBorder(TableCellBorderType.Left, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                                            diTable.Rows[0].Cells[1].SetBorder(TableCellBorderType.Right, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                                            diTable.Rows[0].Cells[1].SetBorder(TableCellBorderType.Top, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                                            byte[] imgBytes = GetBladeInspectionImageWithSeverity(img);
                                            Novacode.Image bdsImg;
                                            using (MemoryStream ms = new MemoryStream(imgBytes))
                                            {
                                                bdsImg = document.AddImage(ms);
                                            }
                                            Novacode.Picture dspicture = bdsImg.CreatePicture();
                                            dspicture.Height = 330;
                                            dspicture.Width = 153;

                                            diTable.Rows[0].Height = 340;
                                            diTable.Rows[0].Cells[0].Paragraphs.First().SetLineSpacing(LineSpacingType.Before, 21.692f);
                                            // diTable.Rows[0].Cells[0].Paragraphs.First().SetLineSpacing(LineSpacingType.Before, 22.00f);
                                            //insert damage image
                                            diTable.Rows[0].Cells[0].Paragraphs.First().InsertPicture(dspicture);
                                            diTable.Rows[0].Cells[0].Paragraphs.First().Alignment = Alignment.left;

                                            #endregion [Row 3: Insert Blade Damage Image With Severity]

                                            #region [Row 3: Insert Blade Damage Details]

                                            var ddTable = document.AddTable(1, 2);
                                            ddTable.Design = TableDesign.LightShading;
                                            ddTable.Alignment = Alignment.left;
                                            ddTable.AutoFit = AutoFit.Window;

                                            ddTable.InsertRow();
                                            ddTable.InsertRow();
                                            ddTable.InsertRow();
                                            ddTable.InsertRow();

                                            ddTable.Rows[0].Cells[0].Paragraphs.First().Append("Damage Identified");
                                            ddTable.Rows[0].Cells[1].Paragraphs.First().Append(img.DamageIdentified);
                                            ddTable.Rows[0].Cells[1].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                                            ddTable.Rows[1].Cells[0].Paragraphs.First().Append("Blade Edge");
                                            ddTable.Rows[1].Cells[1].Paragraphs.First().Append(SetProperBladeEdgeName(img.BladeEdge));
                                            ddTable.Rows[1].Cells[1].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                                            ddTable.Rows[2].Cells[0].Paragraphs.First().Append("Radius");
                                            ddTable.Rows[2].Cells[1].Paragraphs.First().Append(img.Radius.ToString());
                                            ddTable.Rows[2].Cells[1].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                                            ddTable.Rows[3].Cells[0].Paragraphs.First().Append("Damage Description");
                                            ddTable.Rows[3].Cells[1].Paragraphs.First().Append(img.DamageDescription);
                                            ddTable.Rows[3].Cells[1].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);
                                            ddTable.Rows[4].Cells[0].Paragraphs.First().Append("Category");
                                            ddTable.Rows[4].Cells[1].Paragraphs.First().Append(img.Category.ToString());
                                            ddTable.Rows[4].Cells[1].FillColor = System.Drawing.Color.FromArgb(218, 234, 247);

                                            //insert damage data table
                                            diTable.Rows[0].Cells[1].InsertTable(ddTable);
                                            diTable.Rows[0].Cells[0].Width = 160;
                                            diTable.Rows[0].Cells[1].Width = 475;

                                            //add damage image and data in parent table
                                            table.Rows[row + 2].Cells[0].InsertTable(diTable);
                                            #endregion [Row 3: Insert Blade Damage Details]

                                            #endregion [Row 3: Add Damage Image and Damage Description]
                                        }

                                        table.InsertRow();
                                        //set borders
                                        table.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                                        table.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Left, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                                        table.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Right, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                                        table.Rows.Last().Cells[0].SetBorder(TableCellBorderType.Top, new Border(BorderStyle.Tcbs_none, BorderSize.one, 0, System.Drawing.Color.Transparent));
                                        row = row + 4;
                                    }
                                    foreach (var paragraph in document.Paragraphs)
                                    {
                                        paragraph.FindAll("#TABLE" + tableindex.ToString() + "#").ForEach(index => paragraph.InsertTableAfterSelf((table)));

                                    }
                                }
                                //Remove tag and save the document
                                document.ReplaceText("#TABLE" + tableindex.ToString() + "#", "");
                                document.Save();
                            }
                        }
                        document.Save();
                    }
                    // Save changes made to this document.
                } // Release this document from memory.
            }
            catch (Exception oException)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "BIRPdfReport [Inserting Image ] Error" + oException.Message, LogType.Error, "");
            }
        }

        /// <summary>
        /// Set proper blade edge name
        /// </summary>
        /// <param name="bladeEdge"></param>
        /// <returns></returns>
        private static string SetProperBladeEdgeName(string bladeEdge)
        {
            string properBladeEdge = string.Empty;
            if (bladeEdge.Trim() == "Leeward Side (low pressure side)")
            {
                properBladeEdge = "Leeward Side";
            }
            else if (bladeEdge.Trim() == "Windward Side (pressure side)")
            {
                properBladeEdge = "Windward Side";
            }
            else
            {
                properBladeEdge = bladeEdge;
            }
            return properBladeEdge;
        }

        /// <summary>
        /// Get blade inspection image with severity
        /// </summary>
        /// <param name="context"></param>
        /// <param name="imageData"></param>
        /// <returns></returns>
        private static byte[] GetBladeInspectionImageWithSeverity(BIRImageData imageData)
        {
            List<Cir.ComponentTemplates.Models.Section> bladeSectionsWithSeverity = new List<Cir.ComponentTemplates.Models.Section>();

            Cir.ComponentTemplates.Models.Section objBladeSection = new ComponentTemplates.Models.Section();
            objBladeSection.Id = GetBladeSectionId(imageData.BladeSection, SetProperBladeEdgeName(imageData.BladeEdge));
            objBladeSection.Color = GetBladeSectionColor(imageData.Category);
            objBladeSection.DamageSeverity = imageData.Category;
            bladeSectionsWithSeverity.Add(objBladeSection);

            byte[] imgBytes = GetBladeDamageImageWithColoredSeverity(bladeSectionsWithSeverity);
            return imgBytes;
        }

        /// <summary>
        /// Get blade inspection image with severity
        /// </summary>
        /// <param name="context"></param>
        /// <param name="lstDamageDataForFirstCIR"></param>
        /// <returns></returns>
        private static byte[] GetBladeInspectionImageWithSeverity(CIM_CIREntities context, List<BIRDamangeData> lstDamageDataForCIR)
        {
            byte[] imgBytes = null;
            try
            {
                List<Cir.ComponentTemplates.Models.Section> bladeSectionsWithSeverity = new List<Cir.ComponentTemplates.Models.Section>();
                foreach (var bladeDamages in lstDamageDataForCIR)
                {
                    Cir.ComponentTemplates.Models.Section objBladeSection = new ComponentTemplates.Models.Section();
                    if (bladeDamages.FORMIOImageGUID == null)
                        continue;
                    string formioImageGuid = bladeDamages.FORMIOImageGUID.ToString();
                    var bladeImage = context.ImageData.Where(x => (x.FormIOImageGUID != null || x.FormIOImageGUID != "") && x.FormIOImageGUID == formioImageGuid).FirstOrDefault();
                    string bladeSide = Regex.Split(Regex.Split(Regex.Split(bladeImage.ImageDescription, "##")[1], "-")[0], " ")[1];
                    objBladeSection.Id = GetBladeSectionId(bladeSide, SetProperBladeEdgeName(bladeDamages.BladeEdge));
                    objBladeSection.Color = GetBladeSectionColor(bladeDamages.DamageSeverity);
                    objBladeSection.DamageSeverity = bladeDamages.DamageSeverity;
                    bladeSectionsWithSeverity.Add(objBladeSection);
                }
                imgBytes = GetBladeDamageImageWithColoredSeverity(bladeSectionsWithSeverity);
            }
            catch (Exception ex)
            {
                ErrorHandling.SystemLog.CirServiceLog("GetBladeInspectionImageWithSeverity", ex.Message, LogType.Error, "");
                imgBytes = null;
            }
            return imgBytes;
        }

        /// <summary>
        /// Get blade section color
        /// </summary>
        /// <param name="damageSeverity"></param>
        /// <returns>string</returns>
        private static string GetBladeSectionColor(int? damageSeverity)
        {
            string sectionColor = string.Empty;
            switch (damageSeverity)
            {
                case 1:
                    sectionColor = Cir.ComponentTemplates.Models.SeverityColors.Severity1;
                    break;
                case 2:
                    sectionColor = Cir.ComponentTemplates.Models.SeverityColors.Severity2;
                    break;
                case 3:
                    sectionColor = Cir.ComponentTemplates.Models.SeverityColors.Severity3;
                    break;
                case 4:
                    sectionColor = Cir.ComponentTemplates.Models.SeverityColors.Severity4;
                    break;
                case 5:
                    sectionColor = Cir.ComponentTemplates.Models.SeverityColors.Severity5;
                    break;
                default:
                    sectionColor = Cir.ComponentTemplates.Models.SeverityColors.Severity0;
                    break;
            }
            return sectionColor;
        }

        /// <summary>
        /// Get blade section id
        /// </summary>
        /// <param name="bladeSide"></param>
        /// <param name="bladeEdge"></param>
        /// <returns></returns>
        private static int GetBladeSectionId(string bladeSide, string bladeEdge)
        {
            bladeEdge = SetProperBladeEdgeName(bladeEdge);
            if (string.IsNullOrEmpty(bladeSide) || string.IsNullOrEmpty(bladeEdge))
                return 0;
            int sectionId = 0;
            if (bladeEdge == "Trailing Edge" && bladeSide == BladeSectionEnum.Root.ToString())
            {
                sectionId = 1;
            }
            else if (bladeEdge == "Leeward Side" && bladeSide == BladeSectionEnum.Root.ToString())
            {
                sectionId = 2;
            }
            else if (bladeEdge == "Leading Edge" && bladeSide == BladeSectionEnum.Root.ToString())
            {
                sectionId = 3;
            }
            else if (bladeEdge == "Windward Side" && bladeSide == BladeSectionEnum.Root.ToString())
            {
                sectionId = 4;
            }
            else if (bladeEdge == "Trailing Edge" && bladeSide == BladeSectionEnum.Mid.ToString())
            {
                sectionId = 5;
            }
            else if (bladeEdge == "Leeward Side" && bladeSide == BladeSectionEnum.Mid.ToString())
            {
                sectionId = 6;
            }
            else if (bladeEdge == "Leading Edge" && bladeSide == BladeSectionEnum.Mid.ToString())
            {
                sectionId = 7;
            }
            else if (bladeEdge == "Windward Side" && bladeSide == BladeSectionEnum.Mid.ToString())
            {
                sectionId = 8;
            }
            else if (bladeEdge == "Trailing Edge" && bladeSide == BladeSectionEnum.Tip.ToString())
            {
                sectionId = 9;
            }
            else if (bladeEdge == "Leeward Side" && bladeSide == BladeSectionEnum.Tip.ToString())
            {
                sectionId = 10;
            }
            else if (bladeEdge == "Leading Edge" && bladeSide == BladeSectionEnum.Tip.ToString())
            {
                sectionId = 11;
            }
            else if (bladeEdge == "Windward Side" && bladeSide == BladeSectionEnum.Tip.ToString())
            {
                sectionId = 12;
            }
            return sectionId;
        }

        /// <summary>
        /// Get overall blade damage image with colored severity
        /// </summary>
        /// <param name="lstBirImageData">blade image damage data</param>
        /// <returns></returns>
        private static byte[] GetBladeDamageImageWithColoredSeverity(List<Cir.ComponentTemplates.Models.Section> sectionsWithSeverity)
        {
            byte[] imgBytes = null;
            try
            {
                string DocumentPath = HttpContext.Current.Server.MapPath("BIRTemplates");
                try
                {
                    if (!Directory.Exists(DocumentPath))
                    {
                        Directory.CreateDirectory(DocumentPath);
                    }
                }
                catch (Exception ex)
                {
                    ErrorHandling.SystemLog.CirServiceLog("Error at Cir.Sync.Service", "GetBladeDamageImageWithColoredSeverity Method, Exception Message: " + ex.Message, LogType.Error, "");
                    return null;
                }

                var pixelsJson = Path.Combine(DocumentPath, @"Templates\pixels.json");
                var pixelJsonStr = File.ReadAllText(pixelsJson);
                dynamic jsonObj = JsonConvert.DeserializeObject(pixelJsonStr);
                var pixels = jsonObj.pixels.ToObject<int[][][]>();

                var labelsJson = Path.Combine(DocumentPath, @"Templates\labels.json");
                var labelsJsonStr = File.ReadAllText(labelsJson);
                var labels = (Cir.ComponentTemplates.Models.Label[])JsonConvert.DeserializeObject(labelsJsonStr, new Cir.ComponentTemplates.Models.Label[0].GetType());

                //List<Cir.ComponentTemplates.Models.Section> sections = new List<Cir.ComponentTemplates.Models.Section>();
                //sections.Add(new Cir.ComponentTemplates.Models.Section { Id = -2, Color = Cir.ComponentTemplates.Models.SeverityColors.AssignedColor });
                //sections.Add(new Cir.ComponentTemplates.Models.Section { Id = 1, Color = Cir.ComponentTemplates.Models.SeverityColors.Severity1 });
                //sections.Add(new Cir.ComponentTemplates.Models.Section { Id = 5, Color = Cir.ComponentTemplates.Models.SeverityColors.Severity5 });

                //if (sectionsWithSeverity == null || sectionsWithSeverity.Count == 0)
                //    sectionsWithSeverity = sections;
                imgBytes = new ComponentTemplates.TemplateImageParser().ToImage(pixels, sectionsWithSeverity, labels);
            }
            catch (Exception ex)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "AddBladeDamageTable blade Damnage Error" + ex.Message, LogType.Error, "");
            }
            return imgBytes;
        }

        /// <summary>
        /// Blade Edge Enumerator
        /// </summary>
        enum BladeEdgeEnum
        {
            LE = 1,
            TE = 2,
            NA = 3,
            TIP = 4,
            LS = 5,
            WS = 6
        }

        public static readonly string LW = "Leeward Side";
        public static readonly string TE = "Trailing Edge";
        public static readonly string LE = "Leading Edge";
        public static readonly string WW = "Windward Side";

        /// <summary>
        /// Blade Sections Enumerator
        /// </summary>
        enum BladeSectionEnum
        {
            Root = 1,
            Mid = 2,
            Tip = 3
        }
        #endregion [Add Pictures in BIR3.1]

        #endregion [BIR 3.1 Changes]
    }
}