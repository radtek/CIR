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
using Microsoft.Azure.Documents.Client;

namespace Cir.Sync.Services.DAL
{
    public class DAGIRReport
    {


        public static bool RenderGirReport(long GirId)
        {
            byte[] wordBytes = null;
            GIRView girView = new GIRView();
            string RelatedCIR = string.Empty;

            wordBytes = GetPdf(GirId);
            if (ReferenceEquals(wordBytes, null))
            {

                #region Retrieving placeholders
                //  List<Cir.Common.GirPdf.GirPlaceholders> Placeholder = GetPlaceholders(1);
                #endregion

                #region Retrieving Standard texts
                IEnumerable<StandardTexts> lstStandardText = GetStandardTexts(1);
                #endregion

                #region Retrieving GIR data
                girView = GetGirDataByID(GirId, out RelatedCIR
                            );
                #endregion


                if (!string.IsNullOrEmpty(RelatedCIR))
                {
                    //girView.BladeRotors = new List<string>();
                    girView.Cirs = new List<long>();
                    long cirDataID = -1;
                    foreach (var CirDataID in RelatedCIR.Split(','))
                        if (long.TryParse(CirDataID, out cirDataID))
                        {
                            girView.Cirs.Add(cirDataID);
                            //GetBladeRotor(cirDataID, ref girView);

                        }
                }

                CIR.TurbineProperties oTurbineData = GetTurbineData(girView.TurbineNumber);

                string ContractName = GetContractName(Convert.ToInt64(girView.TurbineNumber));

                wordBytes = GenerateWordDocument
               (
                   Gir: girView,
                   StandardTexts: lstStandardText,
                   TurbineData: oTurbineData,
                   ContractName: ContractName
               );
                if (!ReferenceEquals(wordBytes, null))
                {
                    SaveGeneratePdf
                        (
                            GirDataId: girView.GirDataId,
                            GirCode: girView.GirCode,
                            pdfFile: wordBytes
                        );
                }
            }
            return true;
        }


        public static byte[] RenderGirReportforCosmos(long GirId)
        {
            byte[] wordBytes = null;
            GIRView birView = new GIRView();
            string RelatedCIR = string.Empty;

            wordBytes = GetPdf(GirId);

            if (ReferenceEquals(wordBytes, null))
            {

                #region Retrieving placeholders
                //  List<Cir.Common.GirPdf.Placeholders> Placeholder = GetPlaceholders(1);
                #endregion

                #region Retrieving Standard texts
                IEnumerable<StandardTexts> lstStandardText = GetStandardTexts(1);
                #endregion

                #region Retrieving GIR data
                birView = GetGirDataByID(GirId, out RelatedCIR
                            );
                #endregion


                if (!string.IsNullOrEmpty(RelatedCIR))
                {
                    //birView.BladeRotors = new List<string>();
                    birView.Cirs = new List<long>();
                    long cirDataID = -1;
                    foreach (var CirDataID in RelatedCIR.Split(','))
                        if (long.TryParse(CirDataID, out cirDataID))
                        {
                            birView.Cirs.Add(cirDataID);
                            //GetBladeRotor(cirDataID, ref birView);

                        }
                }


                CIR.TurbineProperties oTurbineData = GetTurbineData(birView.TurbineNumber);

                string ContractName = GetContractName(Convert.ToInt64(birView.TurbineNumber));

                wordBytes = GenerateWordDocument
               (
                   Gir: birView,
                   StandardTexts: lstStandardText,
                   TurbineData: oTurbineData,
                   ContractName: ContractName
               );
                if (!ReferenceEquals(wordBytes, null))

                {
                    SaveGeneratePdf
                        (
                            GirDataId: birView.GirDataId,
                            GirCode: birView.GirCode,
                            pdfFile: wordBytes
                        );
                }
            }
            return wordBytes;
        }

        public static GirFile RenderGirReport(long GirId, int laguangeId)
        {
            byte[] wordBytes = null;
            GIRView girView = new GIRView();
            string RelatedCIR = string.Empty;
            GirFile oGir = new GirFile();
                        
            if (ReferenceEquals(wordBytes, null))
            {

                #region Retrieving placeholders
                //  List<Cir.Common.BirPdf.Placeholders> Placeholder = GetPlaceholders(1);
                #endregion

                #region Retrieving Standard texts
                IEnumerable<StandardTexts> lstStandardText = GetStandardTexts(1);
                #endregion

                #region Retrieving GIR data
                girView = GetGirDataByID(GirId, out RelatedCIR
                            );
                #endregion


                if (!string.IsNullOrEmpty(RelatedCIR))
                {
                    
                    girView.Cirs = new List<long>();
                    long cirDataID = -1;
                    foreach (var CirDataID in RelatedCIR.Split(','))
                        if (long.TryParse(CirDataID, out cirDataID))
                        {
                            girView.Cirs.Add(cirDataID);
                            
                        }
                }

                CIR.TurbineProperties oTurbineData = GetTurbineData(girView.TurbineNumber);

                string ContractName = GetContractName(Convert.ToInt64(girView.TurbineNumber));

                DocumentClient _documentClient = new DocumentClient(new Uri(DAGir.endPointURI), DAGir.primaryKey);
                GirDataDetails existingGirDataDetails = _documentClient.CreateDocumentQuery<GirDataDetails>(
                       UriFactory.CreateDocumentCollectionUri(DAGir.databaseId, DAGir.collectionName),
                       new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                   .Where(x => x.GirDataID == GirId).AsEnumerable().FirstOrDefault();
                if (existingGirDataDetails != null)
                {
                    wordBytes = DABIRReport.GetWordBytes(existingGirDataDetails.WordBytesUrl.ToString());
                }
                else
                {
                    wordBytes = GenerateWordDocument
                   (
                       Gir: girView,
                       StandardTexts: lstStandardText,
                       TurbineData: oTurbineData,
                       ContractName: ContractName
                   );
                }

                if (!ReferenceEquals(wordBytes, null))
                {

                    oGir.FileBytes = wordBytes;
                    oGir.FileName = girView.GirCode;
                    string SpireLicensePath = HttpContext.Current.Server.MapPath("~/SpireLicense");
                    Spire.License.LicenseProvider.SetLicenseFileName("license.lic");
                    Spire.License.LicenseProvider.SetLicenseFileFullPath(Path.Combine(SpireLicensePath, "license.lic"));
                    Spire.License.LicenseProvider.LoadLicense();

                    using (MemoryStream ms1 = new MemoryStream(oGir.FileBytes))
                    {
                        Document doc = new Document(ms1);

                        using (MemoryStream ms2 = new MemoryStream())
                        {
                            doc.SaveToStream(ms2, Spire.Doc.FileFormat.PDF);
                            //save to byte array
                            byte[] toArray = ms2.ToArray();
                            oGir.FileBytes = toArray;
                        }
                    }
                }
            }
            return oGir;
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

        // To get the pdf from ManageGIR/ CIR Download and Approve
        public static Gir GetCIRPdf(long CirDataId, long CirId = 0)
        {

            Gir oGir = new Gir();

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
                        oGir.File = new GirFile() { Id = CirDataId, FileName = pdf.CIRName, FileBytes = pdf.PDFData };

                    }
                }
            }
            return oGir;
        }

        public static Gir GetCIRPdfZip(string CirDataIds)
        {
            Gir oGirOutput = new Gir();
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
                        Gir oGir = GetCIRPdf(CirDataId);
                        if (oGir.File != null)
                        {
                            byte[] fileBytes = oGir.File.FileBytes;
                            ZipEntry fileEntry = new ZipEntry(oGir.File.FileName + ".pdf");
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
                oGirOutput.File = new GirFile() { Id = 0, FileName = "CIR.zip", FileBytes = byteArrayOut };


            }
            return oGirOutput;

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

        public static Gir GetGirPDF(long GirID)
        {
            Gir oGir = DAL.DAGir.GirFileBytes(GirID);

            string SpireLicensePath = HttpContext.Current.Server.MapPath("~/SpireLicense");
            Spire.License.LicenseProvider.SetLicenseFileName("license.lic");
            Spire.License.LicenseProvider.SetLicenseFileFullPath(Path.Combine(SpireLicensePath, "license.lic"));
            Spire.License.LicenseProvider.LoadLicense();

            DocumentClient _documentClient = new DocumentClient(new Uri(DAGir.endPointURI), DAGir.primaryKey);
            GirDataDetails existingGirDataDetails = _documentClient.CreateDocumentQuery<GirDataDetails>(
                   UriFactory.CreateDocumentCollectionUri(DAGir.databaseId, DAGir.collectionName),
                   new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
               .Where(x => x.GirDataID == GirID).AsEnumerable().FirstOrDefault();
            if (existingGirDataDetails != null)
            {
                oGir.File.FileBytes = DABIRReport.GetWordBytes(existingGirDataDetails.WordBytesUrl.ToString());
            }

            using (MemoryStream ms1 = new MemoryStream(oGir.File.FileBytes))
            {
                Document doc = new Document(ms1);
                using (MemoryStream ms2 = new MemoryStream())
                {
                    doc.SaveToStream(ms2, Spire.Doc.FileFormat.PDF);
                    //save to byte array
                    byte[] toArray = ms2.ToArray();
                    oGir.File.FileBytes = toArray;
                }
            }
            return oGir;
        }

        public static void SaveGeneratePdf(long GirDataId, string GirCode, byte[] pdfFile)
        {
            // save PDF to database (update existing if applicable)
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                var entity = context.GirWordDocument.Where(x => x.GirDataID == GirDataId).FirstOrDefault();

                if (entity == null)
                {
                    entity = new GirWordDocument();
                    entity.GirDataID = GirDataId;
                    entity.GirCode = GirCode;
                    entity.WordDocBytes = pdfFile;
                    context.GirWordDocument.Add(entity);
                }
                else
                {
                    entity.GirCode = GirCode;
                    entity.WordDocBytes = pdfFile;

                }
                // save
                context.SaveChanges();
            }
        }

        public static byte[] GenerateWordDocument(GIRView Gir, IEnumerable<StandardTexts> StandardTexts, CIR.TurbineProperties TurbineData, string ContractName)
        {
            byte[] wordDocBytes = null;
            try
            {
                Dictionary<string, string> keyValuesPairs = new Dictionary<string, string>();
                string DocumentPath = HttpContext.Current.Server.MapPath("GIRTemplates");

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

                string sourceGeneratorTemplate = string.Empty;
                if (Gir.Cirs.Count == 1)
                    sourceGeneratorTemplate = Path.Combine(DocumentPath, @"Templates\DC_Inspection_Template_Generator.docx");
                string destinationGeneratorTemplate = Path.Combine(DocumentPath, Gir.GirCode.Replace("/", string.Empty).Replace(@"\", string.Empty).Trim() + ".docx");

                // Create a copy of the template file and open the copy 
                File.Copy(sourceGeneratorTemplate, destinationGeneratorTemplate, true);

                #region Generator pictures
                AddGeneratorPicturesTable(
                           destinationGeneratorTemplate,
                          Gir);
                #endregion

                // create key value pair, key represents words to be replace and 
                //values represent values in document in place of keys.
                Dictionary<string, string> keyValues = new Dictionary<string, string>();

                #region Component specific
                keyValues.Add("#GIRNAME#", Gir.GirCode);
                keyValues.Add("#CLASSIFICATIONOFDAMAGE#", Gir.ClassificationOfDamage);
                keyValues.Add("#ANALYSISOFPICTURE#", Gir.AnalysisOfPicture);
                keyValues.Add("#ANALYSISOFMEASURMENTS#", Gir.AnalysisOfMeasurments);
                keyValues.Add("#CONCLUSIONRECOMMENDATION#", Gir.ConculsionRecomm);
                keyValues.Add("#CREATED#", string.Format("{0:dd MMMM, yyyy}", Gir.Created));
                keyValues.Add("#CREATEDBY#", Gir.Createdby);
                keyValues.Add("#MASTERAUTHOR#", Gir.Createdby);
                keyValues.Add("#CUSTOMER#", ContractName);
                keyValues.Add("#GENSERIALNO#", Gir.GeneratorSln);
                keyValues.Add("#ReasonForService#", Gir.ReasonForService);
                keyValues.Add("#Description#", Gir.Description);
                keyValues.Add("#SBURecommendation#", Gir.SBURecommendation);
                keyValues.Add("#AdditionalInformation#", Gir.AdditionalInfo);
                keyValues.Add("#UGROUND#", Convert.ToString(Gir.UGround));
                keyValues.Add("#VGROUND#", Convert.ToString(Gir.VGround));
                keyValues.Add("#WGROUND#", Convert.ToString(Gir.WGround));
                keyValues.Add("#UV#", Convert.ToString(Gir.UV));
                keyValues.Add("#UW#", Convert.ToString(Gir.UW));
                keyValues.Add("#VW#", Convert.ToString(Gir.VW));
                keyValues.Add("#U1U2#", Convert.ToString(Gir.U1U2));
                keyValues.Add("#V1V2#", Convert.ToString(Gir.V1V2));
                keyValues.Add("#W1W2#", Convert.ToString(Gir.W1W2));
                keyValues.Add("#KGROUND#", Convert.ToString(Gir.KGround));
                keyValues.Add("#LGROUND#", Convert.ToString(Gir.LGround));
                keyValues.Add("#MGROUND#", Convert.ToString(Gir.MGround));
                keyValues.Add("#K1M1#", Convert.ToString(Gir.K1M1));
                keyValues.Add("#K1L1#", Convert.ToString(Gir.K1L1));
                keyValues.Add("#L1M1#", Convert.ToString(Gir.L1M1));
                keyValues.Add("#K2M2#", Convert.ToString(Gir.K2M2));
                keyValues.Add("#K2L2#", Convert.ToString(Gir.K2L2));
                keyValues.Add("#L2M2#", Convert.ToString(Gir.L2M2));
                keyValues.Add("#MANUFACTURER#", Convert.ToString(Gir.ManufecturerName));
                //keyValues.Add("#TurbineType#", Gir.TurbineType);




                #endregion

                #region Turbine specific
                if (!ReferenceEquals(TurbineData, null))
                {
                    keyValues.Add("#WTG#", TurbineData.Turbine + " " + TurbineData.NominelPower);
                    keyValues.Add("#TurbineType#", Gir.TurbineType + "-" + TurbineData.NominelPower + "-" + TurbineData.Frequency + "-" + TurbineData.Voltage + "-" + TurbineData.MarkVersion);
                    keyValues.Add("#WTGNO#", Gir.TurbineNumber);
                    keyValues.Add("#WTGLOCALID#", TurbineData.LocalTurbineId);
                    keyValues.Add("#COMMDATE#", string.Format("{0:dd MMMM, yyyy}", Gir.CommisionDate));
                    keyValues.Add("#FAILUREDATE#", string.Format("{0:dd MMMM, yyyy}", Gir.FailureDate));
                    keyValues.Add("#InspectionDate#", string.Format("{0:dd MMMM, yyyy}", Gir.InspectionDate));

                }
                #endregion



                #region Cir specific
                //using (CIM_CIREntities context = new CIM_CIREntities())
                //{
                //    var cir = context.CirData.Where(x => x.CirId == Gir.CIRId && x.Deleted == false).FirstOrDefault();
                //    if (cir != null)
                //    {
                //        keyValues.Add("#ISSUDEDBY#", cir.CreatedBy);
                //        keyValues.Add("#REVIEWDBY#", cir.CreatedBy);
                //        keyValues.Add("#APPROVEDBY#", cir.CreatedBy);
                //    }
                //}

                keyValues.Add("#TURBINENO#", Gir.TurbineNumber);
                keyValues.Add("#COUNTRY#", Gir.Country);
                keyValues.Add("#SITE#", Gir.SiteAddress);



                //foreach (GirPlaceholders oPlaceholders in Placeholder)
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
                //if (!ReferenceEquals(StandardTexts, null))
                //    foreach (StandardTexts oStandardTexts in StandardTexts)
                //    {
                //        if (!keyValues.ContainsKey("#" + oStandardTexts.Title + "#"))
                //            keyValues.Add("#" + oStandardTexts.Title + "#", oStandardTexts.Title);
                //        if (!keyValues.ContainsKey("#" + oStandardTexts.Title + " desc#"))
                //            keyValues.Add("#" + oStandardTexts.Title + " desc#", oStandardTexts.Description);
                //    }
                #endregion

                #region Generating Word document
                //using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(destinationBladeTemplate, true))
                //{
                //    string docText = null;

                //    using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                //    {
                //        docText = sr.ReadToEnd();
                //    }

                //    if (Gir.Cirs.Count == 1)
                //        docText = Cir.WebApp.Old_App_Code.GIRTemplates.BladeTemplate1; // Reading template from resource file
                //    else if (Gir.Cirs.Count == 2)
                //        docText = Cir.WebApp.Old_App_Code.GIRTemplates.BladeTemplate2; // Reading template from resource file
                //    else
                //        docText = Cir.WebApp.Old_App_Code.GIRTemplates.BladeTemplate3; // Reading template from resource file

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
                    CreateGirWordDoc
                            (
                                WordFile: destinationGeneratorTemplate,
                                keyValues: keyValues
                            );
                    #endregion
                    //  UpdateTOC(destinationGeneratorTemplate);
                }
                catch
                {
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "GIRPdfReport [Create Doc ] Error", LogType.Error, "");

                }
                try
                {
                    #region Converting word to byte array
                    wordDocBytes = System.IO.File.ReadAllBytes(destinationGeneratorTemplate);
                    #endregion
                }
                catch
                {

                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "GIRPdfReport [Byte array] Error", LogType.Error, "");


                }
            }
            catch (Exception oException)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "GIRPdfReport generation Error : " + oException.Message + " Locked", LogType.Error, "");


            }
            return wordDocBytes;

        }

        public static void AddGeneratorPicturesTable(string WordFileName, GIRView girview)
        {

            try
            {
                // Load the document.
                using (DocX document = DocX.Load(WordFileName))
                {
                    int tableindex = 0;
                    using (CIM_CIREntities context = new CIM_CIREntities())
                    {
                        foreach (long CirDataId in girview.Cirs)
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
                                    List<GIRImageData> imagelist = new List<GIRImageData>();
                                    foreach (var img in cirImages)
                                    {
                                        img.ImageDataString = img.ImageDataString.ToString() + DABir.GetBlobSASUri(img.ImageDataString);
                                        string imgdata = img.ImageDataString.Substring("data:image/jpeg;base64,".Length);
                                        imagelist.Add(new GIRImageData { Order = img.ImageOrder, Comment = img.ImageDescription, ImageData = Convert.FromBase64String(imgdata) });
                                    }

                                    foreach (GIRImageData img in imagelist.OrderBy(z => z.Order))
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
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "GIRPdfReport [Inserting Image ] Error", LogType.Error, "");
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


        public static void CreateGirWordDoc(string WordFile, Dictionary<string, string> keyValues)
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

        public static byte[] GetPdf(long GirDataId)
        {
            byte[] pdfFile = null;
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                var gir = context.GirWordDocument.Where(x => x.GirDataID == GirDataId).FirstOrDefault();
                if (gir != null)
                {
                    pdfFile = gir.WordDocBytes;
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
        private static void GetBladeRotor(long CirDataId, ref GIRView girview)
        {

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                var cir = context.CirData.Where(x => x.CirDataId == CirDataId && x.Deleted == false).FirstOrDefault();
                if (cir != null)
                {
                    var bladeSerial = context.ComponentInspectionReportBlade.Where(x => x.ComponentInspectionReportId == cir.CirId).Select(x => x.BladeSerialNumber).ToList();
                    foreach (string b in bladeSerial)
                        girview.BladeRotors.Add(b);
                }


            }

        }
        public static GIRView GetGirDataByID(long GirID, out string relatedCIRs)
        {
            GIRView objGIRView = new GIRView();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                var cmd = new SqlCommand { Connection = conn };
                SqlDataReader reader = null;
                relatedCIRs = string.Empty;

                string whereClauseOrder = "";
                whereClauseOrder += "bd.Deleted = 0 AND bd.GirDataID = " + GirID.ToString();

                try
                {
                    cmd.CommandText = string.Format(@"
                                     SELECT [GirDataID],[GirCode], [RevisionNumber],CirDataId, CirId,Created,Createdby,SiteAddress,TurbineNumber,TurbineType,Country,SBU,GeneralSerialNos,ClassificationOfDamage,AnalysisOfPicture,AnalysisOfMeasurments,ConclusionsAndRecommendations,CommisioningDate,InspectionDate,FailureDate,ReasonForService,Description,SBURecommendation,AdditionalInfo,UGround,VGround,WGround,UV,UW,VW,U1U2,V1V2,W1W2,KGround,LGround,MGround,K1M1,K1L1,L1M1,K2L2,L2M2,K2M2,ManufecturerName
                                    FROM (
	                                    SELECT BD.[GirDataID],BD.[GirCode], BD.[RevisionNumber],
                                    cd.CirDataId, cd.CirId,  bd.Created, bd.Createdby, isnull(td.[Site],'')SiteAddress,CMI.TurbineNumber, td.TurbineType,td.Country,sbu.[Name] as SBU,bd.GeneralSerialNos,ClassificationOfDamage,AnalysisOfPicture,AnalysisOfMeasurments,ConclusionsAndRecommendations,
                                        CMI.CommisioningDate as CommisioningDate,
                                        CMI.InspectionDate as InspectionDate,
										CMI.FailureDate as FailureDate,
										CMI.AdditionalInfo as AdditionalInfo,
										CMI.SBURecommendation as SBURecommendation,
										CMI.ReasonForService as ReasonForService,
										CMI.[Description] as [Description],
                                             CMIG.UGround as UGround,
											 CMIG.VGround as VGround,
											  CMIG.WGround as WGround,
											  CMIG.UV as UV, CMIG.UW as UW,
											  CMIG.VW as VW,
											   CMIG.U1U2 as U1U2,
											   CMIG.V1V2 as V1V2,
                                             CMIG.W1W2 as W1W2,
											  CMIG.KGround as KGround,
											 CMIG.LGround as LGround,
											 CMIG.MGround as MGround ,
											 CMIG.K1M1 as K1M1, 
											 CMIG.K1L1 as K1L1,
											 CMIG.L1M1 as L1M1,
                                                CMIG.K2L2 as K2L2,
												CMIG.L2M2 as L2M2,
												CMIG.K2M2 as K2M2,
										GM.Name as ManufecturerName,
										 ROW_NUMBER() OVER(
		                                    ORDER BY  BD.[Created] desc
	                                    ) AS RowNumber
	                                    FROM
	                                    [dbo].[GirData] BD  WITH(NOLOCK)
                                    inner  join [dbo].[MapGirCir] MPC  WITH(NOLOCK)
                                    on MPC.GirDataID = BD.GirDataID and MPC.Master = 1
                                    inner join 
                                    dbo.CIRData cd  WITH(NOLOCK) on cd.[CirDataId] = MPC.CirDataID
                                    left join ComponentInspectionReport CMI on CMI.ComponentInspectionReportId = cd.[CirId]
									left join [dbo].ComponentInspectionReportGenerator CMIG on CMI.ComponentInspectionReportId =  CMIG.[ComponentInspectionReportId]
									left join [dbo].GeneratorManufacturer GM on CMIG.GeneratorManufacturerId = GM.GeneratorManufacturerId 
                                    left  JOIN [dbo].[SBU] sbu WITH(NOLOCK) ON CMI.SBUId = sbu.[SBUId]
                                    left join TurbineData td on  td.TurbineId = CONVERT(VARCHAR(50),CMI.TurbineNumber)
	                                    WHERE {0} 
		                                    ) CirDataPage
                                    ", whereClauseOrder);

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objGIRView = new GIRView
                        {
                            GirDataId = reader["GirDataId"] == DBNull.Value ? 0 : Convert.ToInt64(reader["GirDataId"]),
                            GirCode = Convert.ToString(reader["GirCode"]),
                            RevisionNumber = Convert.ToInt32(reader["RevisionNumber"]),
                            CIRDataId = reader["CirDataId"] == DBNull.Value ? 0 : Convert.ToInt64(reader["CirDataId"]),
                            CIRId = reader["CirId"] == DBNull.Value ? 0 : Convert.ToInt64(reader["CirId"]),
                            SiteAddress = Convert.ToString(reader["SiteAddress"]),
                            Created = reader.GetDateTime(reader.GetOrdinal("Created")),
                            Createdby = reader.GetString(reader.GetOrdinal("Createdby")),
                            TurbineNumber = Convert.ToString(reader["TurbineNumber"]),//reader.GetString(reader.GetOrdinal("TurbineNumber")),
                            TurbineType = reader.GetString(reader.GetOrdinal("TurbineType")),
                            Country = reader.GetString(reader.GetOrdinal("Country")),
                            GeneratorSln = Convert.ToString(reader["GeneralSerialNos"]),
                            ClassificationOfDamage = Convert.ToString(reader["ClassificationOfDamage"]),
                            AnalysisOfPicture = Convert.ToString(reader["AnalysisOfPicture"]),
                            AnalysisOfMeasurments = Convert.ToString(reader["AnalysisOfMeasurments"]),
                            ConculsionRecomm = Convert.ToString(reader["ConclusionsAndRecommendations"]),
                            CommisionDate = reader.GetDateTime(reader.GetOrdinal("CommisioningDate")),
                            FailureDate = reader["FailureDate"] == DBNull.Value ? "" : reader.GetDateTime(reader.GetOrdinal("FailureDate")).ToString(),
                            InspectionDate = reader.GetDateTime(reader.GetOrdinal("InspectionDate")),
                            AdditionalInfo = Convert.ToString(reader["AdditionalInfo"]),
                            SBURecommendation = Convert.ToString(reader["SBURecommendation"]),
                            ReasonForService = Convert.ToString(reader["ReasonForService"]),
                            Description = Convert.ToString(reader["Description"]),
                            UGround = reader["UGround"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["UGround"]),
                            VGround = reader["VGround"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["VGround"]),
                            WGround = reader["WGround"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["WGround"]),
                            UV = reader["UV"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["UV"]),
                            UW = reader["UW"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["UW"]),
                            VW = reader["VW"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["VW"]),
                            U1U2 = reader["U1U2"] == DBNull.Value ? 0 : Convert.ToInt64(reader["U1U2"]),
                            V1V2 = reader["V1V2"] == DBNull.Value ? 0 : Convert.ToInt64(reader["V1V2"]),
                            W1W2 = reader["W1W2"] == DBNull.Value ? 0 : Convert.ToInt64(reader["W1W2"]),
                            KGround = reader["KGround"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["KGround"]),
                            LGround = reader["LGround"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["LGround"]),
                            MGround = reader["MGround"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["MGround"]),
                            K1M1 = reader["K1M1"] == DBNull.Value ? 0 : Convert.ToInt64(reader["K1M1"]),
                            K1L1 = reader["K1L1"] == DBNull.Value ? 0 : Convert.ToInt64(reader["K1L1"]),
                            L1M1 = reader["L1M1"] == DBNull.Value ? 0 : Convert.ToInt64(reader["L1M1"]),
                            K2L2 = reader["K2L2"] == DBNull.Value ? 0 : Convert.ToInt64(reader["K2L2"]),
                            L2M2 = reader["L2M2"] == DBNull.Value ? 0 : Convert.ToInt64(reader["L2M2"]),
                            K2M2 = reader["K2M2"] == DBNull.Value ? 0 : Convert.ToInt64(reader["K2M2"]),
                            ManufecturerName = Convert.ToString(reader["ManufecturerName"])

                        };
                    }

                    reader.Close();

                    cmd = new SqlCommand()
                    {
                        Connection = conn,
                        CommandText = string.Format(@"SELECT Cirs FROM (
                                SELECT MAP.GirDataID, STUFF(
                                (SELECT ',' + LTRIM(RTRIM(M.CirDataId))
                                FROM MapGirCir M
                                WHERE MAP.GirDataID = M.GirDataID AND M.Deleted = 0 ORDER BY M.CirDataId
                                FOR XML PATH('')),1,1,'') AS Cirs
                                FROM MapGirCir AS MAP WHERE MAP.DELETED = 0
                                GROUP BY MAP.GirDataID
                                ) GIRMAP WHERE GirDataID = {0}", GirID)
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
                    throw new Exception("Error getting GIR Data");
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