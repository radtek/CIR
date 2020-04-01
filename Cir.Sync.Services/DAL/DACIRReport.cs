
using Cir.CloudConvert.Wrapper;
using Cir.Sync.Services.Edmx;
using Cir.Sync.Services.ErrorHandling;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json.Linq;
using Novacode;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;

namespace Cir.Sync.Services.DAL
{
    public class PDFModel
    {
        public long PDFId { get; set; }
        public byte[] PDFData { get; set; }
        public int CIRState { get; set; }
        public string CIRTemplateGUID { get; set; }
        public string CIRName { get; set; }
    }
    public class DACIRReport
    {
        static List<MasterKeyData> masterData = null;
        static System.IO.StreamWriter file = null;
        static string destinationCIRTemplate = string.Empty;
        public static bool RenderCirReport(long CirID, string DocumentPath, string SpireLicensePath)
        {
            long hdnCirId = Convert.ToInt64(System.Configuration.ConfigurationManager.AppSettings["hdnCirId"]);
            if (CirID < hdnCirId)
            {
                byte[] PdfDocBytes = null;
                try
                {
                    Dictionary<string, string> keyValuesPairs = new Dictionary<string, string>();
                    //string DocumentPath = HttpContext.Current.Server.MapPath("CIRTemplates");

                    try
                    {
                        if (!Directory.Exists(DocumentPath))
                        {
                            Directory.CreateDirectory(DocumentPath);
                        }
                    }
                    catch { }

                    #region Deleting existing contents
                    //  DeleteDirectoryContents(DocumentPath);
                    #endregion


                    Dictionary<string, string> keyValues = new Dictionary<string, string>();
                    masterData = GetMasterDataForCIRReport();

                    //Static Keys
                    keyValues.Add("_CIRID", CirID.ToString());


                    long ComponentType = 1;
                    string fileName = "";
                    using (CIM_CIREntities context = new CIM_CIREntities())// .OrderByDescending(x => x.CirDataId)
                    {
                        Edmx.CirData cirData = context.CirData.Where(x => x.CirId == CirID && x.Deleted == false).FirstOrDefault();

                        keyValues.Add("_version", "v" + cirData.TemplateVersion);
                        keyValues.Add("_CreatedBy", cirData.CreatedBy);
                        Edmx.ComponentInspectionReport cir = context.ComponentInspectionReport.Where(x => x.ComponentInspectionReportId == CirID).FirstOrDefault();
                        ComponentType = cir.ComponentInspectionReportTypeId;
                        fileName = (cir.ComponentInspectionReportName == null || cir.ComponentInspectionReportName == "") ? cirData.Filename : cir.ComponentInspectionReportName.ToString();
                        fileName = fileName.Replace(".xml", "");
                        FillProperties(cir, ref keyValues);
                        string turbineNumber = cir.TurbineNumber.ToString();
                        string cimCase = Convert.ToString(cir.CIMCaseNumber);
                        Edmx.TemplateDynamicTableDef objIsFlange = context.TemplateDynamicTableDef.Where(x => x.CIMcaseNo == cimCase).FirstOrDefault();
                        Edmx.TurbineData turbineData = context.TurbineData.Where(x => x.TurbineId == turbineNumber).OrderByDescending(z => z.Created).FirstOrDefault();
                        FillProperties(turbineData, ref keyValues);

                        //1	Blade
                        //2	Gearbox
                        //3	General
                        //4	Generator
                        //6	Main Bearing
                        //7	Skiipack
                        //5	Transformer
                        //8 Simplified
                        fileName = fileName.Replace('/', '_').Replace('\\', '_');
                        string sourceCIRTemplate = string.Empty;
                        string guid = Guid.NewGuid().ToString();
                        destinationCIRTemplate = Path.Combine(DocumentPath, guid + ".docx");

                        List<Edmx.ComponentInspectionReportBladeDamage> cirBladeDamages = null;
                        Edmx.ComponentInspectionReport cirSimplified = null;
                        Edmx.ComponentInspectionReportSkiiP cirSkiip = null;
                        ComponentType = ComponentType == 9 ? 1 : ComponentType;
                        switch (ComponentType)
                        {
                            case 1:
                                Edmx.ComponentInspectionReportBlade cirBlade = context.ComponentInspectionReportBlade.Where(x => x.ComponentInspectionReportId == CirID).FirstOrDefault();
                                ComponentInspectionReportBladeRepairRecord cirBladeRepairRecord = context.ComponentInspectionReportBladeRepairRecord.Where(x => x.ComponentInspectionReportBladeId == cirBlade.ComponentInspectionReportBladeId).FirstOrDefault();
                                if (cirBladeRepairRecord != null)
                                {
                                    sourceCIRTemplate = Path.Combine(DocumentPath, @"Templates\CIR_Template_v7_Blade.docx");
                                }
                                else
                                {
                                    sourceCIRTemplate = Path.Combine(DocumentPath, @"Templates\CIR_Template_v7_BladeExceptRepair.docx");
                                }
                                if (cirBlade != null)
                                {
                                    cirBladeDamages = context.ComponentInspectionReportBladeDamage.Where(x => x.ComponentInspectionReportBladeId == cirBlade.ComponentInspectionReportBladeId).ToList();
                                }

                                keyValues.Add("_ComponentTypeId", "Blade");
                                FillProperties(cirBlade, ref keyValues);

                                if (cirBladeRepairRecord != null)
                                    FillProperties(cirBladeRepairRecord, ref keyValues);

                                break;
                            case 2:
                                sourceCIRTemplate = Path.Combine(DocumentPath, @"Templates\CIR_Template_v7_Gearbox.docx");
                                Edmx.ComponentInspectionReportGearbox cirGearBox = context.ComponentInspectionReportGearbox.Where(x => x.ComponentInspectionReportId == CirID).FirstOrDefault();
                                keyValues.Add("_ComponentTypeId", "Gearbox");
                                FillProperties(cirGearBox, ref keyValues);

                                break;
                            case 3:
                                sourceCIRTemplate = Path.Combine(DocumentPath, @"Templates\CIR_Template_v7_General.docx");
                                Edmx.ComponentInspectionReportGeneral cirGeneral = context.ComponentInspectionReportGeneral.Where(x => x.ComponentInspectionReportId == CirID).FirstOrDefault();
                                keyValues.Add("_ComponentTypeId", "General");
                                FillProperties(cirGeneral, ref keyValues);


                                break;
                            case 4:
                                sourceCIRTemplate = Path.Combine(DocumentPath, @"Templates\CIR_Template_v7_Generator.docx");
                                Edmx.ComponentInspectionReportGenerator cirGenerator = context.ComponentInspectionReportGenerator.Where(x => x.ComponentInspectionReportId == CirID).FirstOrDefault();
                                keyValues.Add("_ComponentTypeId", "Generator");
                                FillProperties(cirGenerator, ref keyValues);

                                break;
                            case 5:
                                sourceCIRTemplate = Path.Combine(DocumentPath, @"Templates\CIR_Template_v7_Transformer.docx");
                                Edmx.ComponentInspectionReportTransformer cirTransformer = context.ComponentInspectionReportTransformer.Where(x => x.ComponentInspectionReportId == CirID).FirstOrDefault();
                                keyValues.Add("_ComponentTypeId", "Transformer");
                                FillProperties(cirTransformer, ref keyValues);
                                break;
                            case 6:
                                sourceCIRTemplate = Path.Combine(DocumentPath, @"Templates\CIR_Template_v7_Mainbearing.docx");
                                Edmx.ComponentInspectionReportMainBearing cirMainBearing = context.ComponentInspectionReportMainBearing.Where(x => x.ComponentInspectionReportId == CirID).FirstOrDefault();
                                keyValues.Add("_ComponentTypeId", "Mainbearing");
                                FillProperties(cirMainBearing, ref keyValues);
                                break;
                            case 7:
                                sourceCIRTemplate = Path.Combine(DocumentPath, @"Templates\CIR_Template_v7_Skiip.docx");
                                cirSkiip = context.ComponentInspectionReportSkiiP.Where(x => x.ComponentInspectionReportId == CirID).FirstOrDefault();
                                keyValues.Add("_ComponentTypeId", "Skiipack");
                                FillProperties(cirSkiip, ref keyValues);

                                break;
                            case 8:
                                if (objIsFlange == null)
                                {
                                    sourceCIRTemplate = Path.Combine(DocumentPath, @"Templates\CIR_Template_v7_Simplified_withoutFlange.docx");
                                }
                                else
                                {
                                    sourceCIRTemplate = Path.Combine(DocumentPath, @"Templates\CIR_Template_v7_Simplifieds.docx");
                                }
                                cirSimplified = context.ComponentInspectionReport.Where(x => x.ComponentInspectionReportId == CirID && x.ComponentInspectionReportTypeId == 8).FirstOrDefault();
                                keyValues.Add("_ComponentTypeId", "Simplified");
                                FillProperties(cirSimplified, ref keyValues);

                                break;
                            default:
                                break;
                        }

                        //  AddIdProperty(cir, "ReportType", ref keyValues);
                        //  AddIdProperty(cir, "ComponentInspectionReportType", ref keyValues);
                        //  AddIdProperty(cir, "ServiceReportNumberType", ref keyValues);

                        // Create a copy of the template file and open the copy 
                        File.Copy(sourceCIRTemplate, destinationCIRTemplate, true);

                        if (ComponentType == 1 && cirBladeDamages != null)
                        {
                            AddBladeDamageData(destinationCIRTemplate, cirBladeDamages);
                        }

                        if (ComponentType == 7 && cirSkiip != null && cirSkiip.ComponentInspectionReportSkiiPNewComponent != null && cirSkiip.SkiiPNumberofComponents.HasValue)
                        {
                            AddSkiipNewComponent(destinationCIRTemplate, cirSkiip.ComponentInspectionReportSkiiPNewComponent.Take(Convert.ToInt32(cirSkiip.SkiiPNumberofComponents.Value)).ToList());
                        }
                        if (ComponentType == 7 && cirSkiip != null && cirSkiip.ComponentInspectionReportSkiiPFailedComponent != null && cirSkiip.SkiiPNumberofComponents.HasValue)
                        {
                            AddSkiipFailedComponent(destinationCIRTemplate, cirSkiip.ComponentInspectionReportSkiiPFailedComponent.Take(Convert.ToInt32(cirSkiip.SkiiPNumberofComponents.Value)).ToList());
                        }

                        if (ComponentType == 8 && cirSimplified != null)
                        {
                            if (objIsFlange != null)
                            {
                                AddDynamicFlange(destinationCIRTemplate, CirID.ToString(), cir.CIMCaseNumber, cir.FormIOGUID);
                            }
                        }
                        else
                        {
                            //var imgData = context.ImageData.Where(x => x.ComponentInspectionReportId == CirID).ToList();
                            //if(imgData != null && imgData.Count > 0)
                            if (cir.ImageData != null && cir.ImageData.Count > 0)
                            {
                                AddPicturesTable(destinationCIRTemplate, cir.ImageData.ToList());
                            }
                            else
                            {
                                keyValues.Add("##PICTURES##", "");
                            }
                            if (cir.ImageDataInfo != null && cir.ImageDataInfo.FirstOrDefault() != null)
                            {
                                var iinfo = cir.ImageDataInfo.FirstOrDefault();
                                keyValues.Add("_IsPlateTypeNotPossible", ((iinfo.IsPlateTypeNotPossible.HasValue) ? ((iinfo.IsPlateTypeNotPossible.Value) ? "Yes" : "No") : "No"));
                                keyValues.Add("_PlateTypeNotPossibleReason", iinfo.PlateTypeNotPossibleReason);
                            }
                            else
                            {
                                keyValues.Add("_IsPlateTypeNotPossible", "No");
                                keyValues.Add("_PlateTypeNotPossibleReason", "");
                            }

                            AddDynamicTable(destinationCIRTemplate, CirID.ToString(), cir.CIMCaseNumber);
                            AddRevisionTable(destinationCIRTemplate, CirID);
                        }

                        PdfDocBytes = CreateCIRDoc(destinationCIRTemplate, keyValues, SpireLicensePath, ComponentType, fileName);
                        try
                        {
                            File.Delete(destinationCIRTemplate);
                        }
                        catch { }

                        PDF pdf = context.PDF.Where(x => x.CIRTemplateGUID == cirData.Guid).FirstOrDefault();
                        if (pdf == null)
                        {
                            pdf = new PDF();
                            pdf.CIRTemplateGUID = cirData.Guid;
                            pdf.CIRState = 1;
                            //pdf.CIRState = cirData.State;
                            pdf.CIRName = fileName;
                            pdf.PDFData = PdfDocBytes;
                            context.PDF.Add(pdf);
                        }
                        else
                        {
                            pdf.CIRName = fileName;
                            pdf.CIRTemplateGUID = cirData.Guid;
                            pdf.CIRState = cirData.State;
                            pdf.PDFData = PdfDocBytes;
                        }
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "RenderCirReport [Create PDF ] Error CIRID = " + CirID, LogType.Error, ex.Message + "  ::  " + ex.StackTrace);
                    throw ex;
                }
            }
                return true;
            
        }

        /// <summary>
        /// Fetch the cir's pdf byte data with metadata information for migration
        /// </summary>
        /// <param name="cirId">inspection id</param>
        /// <returns></returns>
        public static PDFModel GetCirPDFData(string cirId)
        {
            PDFModel objPDFData = new PDFModel();
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                long cirid = Convert.ToInt32(cirId);
                Edmx.CirData cirData = context.CirData.Where(x => x.CirId == cirid && x.Deleted == false).FirstOrDefault();
                if (cirData != null)
                {
                    PDF pdf = context.PDF.Where(x => x.CIRTemplateGUID == cirData.Guid).FirstOrDefault();
                    if (pdf != null)
                    {
                        objPDFData.CIRName = pdf.CIRName;
                        objPDFData.CIRState = pdf.CIRState;
                        objPDFData.CIRTemplateGUID = pdf.CIRTemplateGUID;
                        objPDFData.PDFData = pdf.PDFData;
                        objPDFData.PDFId = pdf.PDFId;
                    }
                }
            }
            return objPDFData;
        }

        private static void AddSkiipFailedComponent(string destinationCIRTemplate, List<ComponentInspectionReportSkiiPFailedComponent> collection)
        {
            try
            {
                using (DocX document = DocX.Load(destinationCIRTemplate))
                {
                    var table = document.Tables[2];
                    int row = 1;
                    foreach (Edmx.ComponentInspectionReportSkiiPFailedComponent d in collection)
                    {
                        if (row > 1)
                        {
                            table.InsertRow();
                            table.InsertRow();
                            table.InsertRow();
                        }
                        table.Rows[row].Cells[0].Paragraphs.First().Append("Serial Number").Bold().Direction = Direction.RightToLeft;
                        if (d.SkiiPFailedComponentSerialNumber != null)
                            table.Rows[row].Cells[1].Paragraphs.First().Append(d.SkiiPFailedComponentSerialNumber);
                        else
                            table.Rows[row].Cells[1].Paragraphs.First().Append("");

                        row++;
                        table.Rows[row].Cells[0].Paragraphs.First().Append("Vestas Unique Identifier").Bold().Direction = Direction.RightToLeft; ;
                        if (d.SkiiPFailedComponentVestasUniqueIdentifier != null)
                            table.Rows[row].Cells[1].Paragraphs.First().Append(d.SkiiPFailedComponentVestasUniqueIdentifier);
                        else
                            table.Rows[row].Cells[1].Paragraphs.First().Append("");
                        row++;
                        table.Rows[row].Cells[0].Paragraphs.First().Append("Item No.").Bold().Direction = Direction.RightToLeft; ;
                        if (d.SkiiPFailedComponentVestasItemNumber != null)
                            table.Rows[row].Cells[1].Paragraphs.First().Append(d.SkiiPFailedComponentVestasItemNumber);
                        else
                            table.Rows[row].Cells[1].Paragraphs.First().Append("");
                        row++;
                    }
                    document.Save();
                }
            }
            catch (Exception oException)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "CIRPdfReport [AddSkiipFailedComponent ] Error", LogType.Error, "");
            }
        }

        private static void AddSkiipNewComponent(string WordFileName, List<ComponentInspectionReportSkiiPNewComponent> collection)
        {
            try
            {
                using (DocX document = DocX.Load(WordFileName))
                {
                    var table = document.Tables[4];
                    int row = 1;
                    foreach (Edmx.ComponentInspectionReportSkiiPNewComponent d in collection)
                    {
                        if (row > 1)
                        {
                            table.InsertRow();
                            table.InsertRow();
                            table.InsertRow();
                        }
                        table.Rows[row].Cells[0].Paragraphs.First().Append("Serial Number").Bold().Direction = Direction.RightToLeft;
                        if (d.SkiiPNewComponentSerialNumber != null)
                            table.Rows[row].Cells[1].Paragraphs.First().Append(d.SkiiPNewComponentSerialNumber);
                        else
                            table.Rows[row].Cells[1].Paragraphs.First().Append("");

                        row++;
                        table.Rows[row].Cells[0].Paragraphs.First().Append("Vestas Unique Identifier").Bold().Direction = Direction.RightToLeft; ;
                        if (d.SkiiPNewComponentVestasUniqueIdentifier != null)
                            table.Rows[row].Cells[1].Paragraphs.First().Append(d.SkiiPNewComponentVestasUniqueIdentifier);
                        else
                            table.Rows[row].Cells[1].Paragraphs.First().Append("");
                        row++;
                        table.Rows[row].Cells[0].Paragraphs.First().Append("Item No.").Bold().Direction = Direction.RightToLeft; ;
                        if (d.SkiiPNewComponentVestasItemNumber != null)
                            table.Rows[row].Cells[1].Paragraphs.First().Append(d.SkiiPNewComponentVestasItemNumber);
                        else
                            table.Rows[row].Cells[1].Paragraphs.First().Append("");
                        row++;
                    }
                    document.Save();
                }
            }
            catch (Exception oException)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "CIRPdfReport [AddSkiipNewComponent ] Error", LogType.Error, "");
            }
        }

        private static byte[] CreateCIRDoc(string destinationCIRTemplate, Dictionary<string, string> keyValues, string SpireLicensePath, long ComponentType, string fileName)
        {
            byte[] PDFBysArray = null;

            try
            {
                //string SpireLicensePath = HttpContext.Current.Server.MapPath("~/SpireLicense");
                Spire.License.LicenseProvider.SetLicenseFileName("license.lic");
                Spire.License.LicenseProvider.SetLicenseFileFullPath(Path.Combine(SpireLicensePath, "license.lic"));
                Spire.License.LicenseProvider.LoadLicense();

                #region Create document
                CreateCirWordDoc
                        (
                            WordFile: destinationCIRTemplate,
                            keyValues: keyValues
                        );
                #endregion

                Document doc1 = new Document();
                doc1.LoadFromFile(destinationCIRTemplate);
                BookmarksNavigator bookmarkNavigator = new BookmarksNavigator(doc1);
                //1	Blade
                //2	Gearbox
                //3	General
                //4	Generator
                //6	Main Bearing
                //7	Skiipack
                //5	Transformer

                //switch (ComponentType)
                //{
                //    case 1:
                //        KeepBookmark(bookmarkNavigator, "Blade");
                //        break;
                //    case 2:

                //        KeepBookmark(bookmarkNavigator, "Gearbox");
                //        break;
                //    case 3:
                //        KeepBookmark(bookmarkNavigator, "General");
                //        break;
                //    case 4:

                //        KeepBookmark(bookmarkNavigator, "Generator");
                //        break;
                //    case 6:
                //        KeepBookmark(bookmarkNavigator, "Mainbearing");
                //        break;
                //    case 7:
                //        KeepBookmark(bookmarkNavigator, "Skiip");
                //        break;
                //    case 5:

                //        KeepBookmark(bookmarkNavigator, "Transformer");
                //        break;
                //    default:
                //        break;
                //}
                // Traverse every paragraph of the first section of the document
                for (int j = 0; j < doc1.Sections[0].Paragraphs.Count; j++)
                {
                    Spire.Doc.Documents.Paragraph p = doc1.Sections[0].Paragraphs[j];
                    // Traverse every child object of a paragraph
                    for (int i = 0; i < p.ChildObjects.Count; i++)
                    {
                        DocumentObject obj = p.ChildObjects[i];

                        //Find the page break object
                        if (obj.DocumentObjectType == DocumentObjectType.Break)
                        {
                            Break b = obj as Break;

                            // Remove the page break object from paragraph
                            p.ChildObjects.Remove(b);
                        }
                    }
                }

                doc1.SaveToFile(destinationCIRTemplate, FileFormat.Docx);
                PDFBysArray = CreatePDF(keyValues, fileName, destinationCIRTemplate).Result;

                //byte[] wordDocBytes = System.IO.File.ReadAllBytes(destinationCIRTemplate);
                //if (!ReferenceEquals(wordDocBytes, null))
                //{

                //    using (MemoryStream ms1 = new MemoryStream(wordDocBytes))
                //    {
                //        Document doc = new Document(ms1);
                //        using (MemoryStream ms2 = new MemoryStream())
                //        {
                //            doc.SaveToStream(ms2, Spire.Doc.FileFormat.PDF);
                //            //save to byte array
                //            PDFBysArray = ms2.ToArray();
                //        }
                //    }
                //}

            }
            catch (Exception e)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "CreateCIRDoc [Create Doc ] Error : " + e.Message + " Trace :" + e.StackTrace, LogType.Error, "");
            }
            return PDFBysArray;
        }

        public static async Task<byte[]> CreatePDF(Dictionary<string, string> keyValues, string fileName, string destinationCIRTemplate)
        {
            try
            {
                string cir = "CIR", doc = "Doc", contentType = "docx";
                var fileGuidKey = Guid.NewGuid().ToString();
                var docDirectoryName = $"{keyValues["_TurbineNumber"]}/{cir}/{keyValues["_FormIOGUID"]}/{doc}/{fileGuidKey}.{contentType}";
                // var docBlobSASUri = DABir.GetBlobSASUri(docDirectoryName, "CreateBlob");
                var docBlobkBlob = DABir.GetBlockBlob(docDirectoryName);
                using (var fileStream = File.OpenRead(destinationCIRTemplate))
                {
                    int length = Convert.ToInt32(fileStream.Length);
                    byte[] docFileBytes = new byte[length];
                    fileStream.Read(docFileBytes, 0, length);
                    docBlobkBlob.UploadFromByteArray(docFileBytes, 0, docFileBytes.Length);
                }

                ConverterWrapper objPdf = new ConverterWrapper();
                var res = await objPdf.CreatePDFAsync(docBlobkBlob.Uri.OriginalString.ToString(), docDirectoryName).ConfigureAwait(false);
                
                string pdf = "PDF";
                contentType = "pdf";
                var pdfDirectoryName = $"{keyValues["_TurbineNumber"]}/{cir}/{keyValues["_FormIOGUID"]}/{pdf}/{fileGuidKey}.{contentType}";
                //  var pdfBlobSASUri = DABir.GetBlobSASUri(pdfDirectoryName, "CreateBlob");
                var pdfBlobkBlob = DABir.GetBlockBlob(pdfDirectoryName);
                byte[] pdfBytes = Convert.FromBase64String(res.ResponseString);
                pdfBlobkBlob.UploadFromByteArray(pdfBytes, 0, pdfBytes.Length);

                string isPDFGenerated = (pdfBytes == null) ? "true" : "false";
                return pdfBytes;
            }
            catch(Exception ex)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error in CreatePDF, Exception: " + ex.Message, LogType.Error, "");
                throw ex;
            }
        }

        public static void KeepBookmark(BookmarksNavigator booknav, string bookmarktokeep)
        {
            //1 Blade
            //2	Gearbox
            //3	General
            //4	Generator
            //6	Main Bearing
            //7	Skiipack
            //5	Transformer
            var bookmarks = "Blade,Gearbox,General,Generator,Mainbearing,Skiip,Transformer".Split(',').ToList();
            foreach (string bookmark in bookmarks)
            {
                if (bookmark != bookmarktokeep)
                {
                    booknav.MoveToBookmark(bookmark);
                    booknav.ReplaceBookmarkContent("", false);
                }
            }

        }

        public enum UpTowerSolutionType
        {
            YES_and_up__tower_recommended = 1,
            YES_and_up__tower_NOT_recommended = 2,
            NO, _Component_need_to_be_exchanged = 3,
            NA = 1,
        }

        public enum InstallationDateType
        {
            Not_Known = 1,
            Original_Installation_Date = 2
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
                keyValues.Add("_" + oldName, ((value == null) ? string.Empty : value.ToString()));
            }
            else if (name == "FormIOGUID")
            {
                keyValues.Add("_" + oldName, ((value == null) ? idValue : value.ToString()));
            }
            else
            {
                keyValues.Add("_" + oldName, ((value == null) ? string.Empty : value.ToString()));
            }
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
                                if (name.ToLower().Contains("Date".ToLower()))
                                {
                                    keyValues.Add("_" + name, ((value == null) ? " " : value.ToString().Replace("00:00:00", "") + " GMT"));
                                    // keyValues.Add("_" + name, ((value == null) ? " " : Convert.ToDateTime(value).ToString("dd-MM-yyyy") + " GMT"));
                                }
                                else if (name.ToLower() == ("Frequency".ToLower()))
                                {
                                    keyValues.Add("_" + name, ((value == null) ? " " : value.ToString().Replace(".000", "")));
                                }
                                else if (name.ToLower() == ("OutSideSign".ToLower()))
                                {
                                    keyValues.Add("_" + name, ((value == null) ? " " : (Convert.ToBoolean(value) == false ? "No" : "Yes")));
                                }
                                else
                                {
                                    keyValues.Add("_" + name, ((value == null) ? string.Empty : value.ToString()));
                                }
                            }
                        }

                    }
                    catch (Exception ex) { }


                }
            }
        }

        private static void AddIdProperty(Object o, string name, ref Dictionary<string, string> keyValues)
        {
            try
            {  //ReportTypeId cir.ReportTypeId   cir.ReportType.Name
                string s = GetPropertyValue(o, name.Replace("Id", "") + ".Name").ToString();
                keyValues.Add("_" + name, s);
            }
            catch (Exception ex) { }
        }

        public static void AddBladeDamageData(string WordFileName, List<Edmx.ComponentInspectionReportBladeDamage> cirBladeDamages)
        {

            try
            {
                //    Damage Placement	_BladeDamagePlacement
                //Damage Type	_BladeInspectionData
                //Radius (m)	_BladeRadius
                //Blade Edge	_BladeEdge
                //Description	_BladeDescription
                //Picture no	_BladePictureNumber
                using (DocX document = DocX.Load(WordFileName))
                {
                    var table = document.Tables[2];
                    int row = 1;
                    foreach (Edmx.ComponentInspectionReportBladeDamage d in cirBladeDamages)
                    {
                        if (row > 1)
                        {
                            table.InsertRow();
                            table.InsertRow();
                            table.InsertRow();
                            table.InsertRow();
                            table.InsertRow();
                            table.InsertRow();
                        }
                        table.Rows[row].Cells[0].Paragraphs.First().Append("Damage Placement").Bold().Direction = Direction.RightToLeft;
                        if (d.BladeDamagePlacement != null)
                            table.Rows[row].Cells[1].Paragraphs.First().Append(d.BladeDamagePlacement.Name);
                        else
                            table.Rows[row].Cells[1].Paragraphs.First().Append("");

                        row++;
                        table.Rows[row].Cells[0].Paragraphs.First().Append("Damage Type").Bold().Direction = Direction.RightToLeft; ;
                        if (d.BladeInspectionData != null)
                            table.Rows[row].Cells[1].Paragraphs.First().Append(d.BladeInspectionData.Name);
                        else
                            table.Rows[row].Cells[1].Paragraphs.First().Append("");
                        row++;
                        table.Rows[row].Cells[0].Paragraphs.First().Append("Radius (m)").Bold().Direction = Direction.RightToLeft; ;
                        table.Rows[row].Cells[1].Paragraphs.First().Append(d.BladeRadius.ToString());
                        row++;
                        table.Rows[row].Cells[0].Paragraphs.First().Append("Blade Edge").Bold().Direction = Direction.RightToLeft; ;
                        if (d.BladeEdge != null)
                            table.Rows[row].Cells[1].Paragraphs.First().Append(d.BladeEdge.Name);
                        else
                            table.Rows[row].Cells[1].Paragraphs.First().Append("");
                        row++;
                        table.Rows[row].Cells[0].Paragraphs.First().Append("Description").Bold().Direction = Direction.RightToLeft; ;
                        table.Rows[row].Cells[1].Paragraphs.First().Append(d.BladeDescription);
                        row++;
                        table.Rows[row].Cells[0].Paragraphs.First().Append("Picture no").Bold().Direction = Direction.RightToLeft; ;
                        table.Rows[row].Cells[1].Paragraphs.First().Append(Convert.ToString(d.BladePictureNumber));

                        row++;
                    }
                    document.Save();
                }
            }
            catch (Exception oException)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "CIRPdfReport [CIR Blade Damage Data ] Error", LogType.Error, "");
            }
        }

        //private static string [][] getRevisionData(long CirID)
        //{

        //    //CIM_CIREntities context = new CIM_CIREntities();
        //    //IEnumerable<ListItem>
        //    //var revData = (from x in context.CirData
        //    //              where x.CirId == CirID 
        //    //              orderby x.Created
        //    //               select new string[] {x.Created, x.CreatedBy.ToString() }).ToArray();

        //    //return revData;
        //}

        public static void AddRevisionTable(string WordFileName, long cirId)
        {
            CIM_CIREntities context = new CIM_CIREntities();
            var revData = (from x in context.CirData
                           join c in context.CirCommentHistory on x.CirDataId equals c.CirDataId into cm
                           from c in cm.DefaultIfEmpty()
                           where x.CirId == cirId
                           orderby x.Created
                           select new { x.Created, x.CreatedBy, Comment = ((c == null) ? "" : c.Comment) }).ToArray();

            //string[][] revData = getRevisionData(cirId);

            using (DocX document = DocX.Load(WordFileName))
            {
                if (revData != null)
                {
                    int tableindex = 0;
                    tableindex++;

                    var table = document.AddTable(revData.Length + 1, 3);
                    table.Alignment = Alignment.left;
                    table.AutoFit = AutoFit.Contents;
                    table.Design = TableDesign.LightGridAccent1;
                    int row = 0;
                    table.InsertRow();
                    table.Rows[row].Cells[0].Paragraphs.First().Append("Edited On").Bold().Direction = Direction.LeftToRight;
                    table.Rows[row].Cells[1].Paragraphs.First().Append("Edited By").Bold().Direction = Direction.LeftToRight;
                    table.Rows[row].Cells[2].Paragraphs.First().Append("Comments").Bold().Direction = Direction.LeftToRight;
                    table.Rows[row].Cells[0].Width = 250;
                    table.Rows[row].Cells[1].Width = 250;
                    table.Rows[row].Cells[2].Width = 500;
                    row++;
                    foreach (var s in revData)
                    {
                        table.Rows[row].Cells[0].Paragraphs.First().Append(s.Created.ToString() + " GMT");
                        table.Rows[row].Cells[1].Paragraphs.First().Append(s.CreatedBy);
                        table.Rows[row].Cells[2].Paragraphs.First().Append(s.Comment);
                        row++;
                    }
                    
                    foreach (var paragraph in document.Paragraphs)
                    {
                        paragraph.FindAll("##REVISION##").ForEach(index => paragraph.InsertTableAfterSelf(table));
                    }
                }
                document.ReplaceText("##REVISION##", "");
                document.Save();
            }


        }

        /// <summary>
        /// Adding Dynamic Flange [Surednra 09-06-2017]
        /// </summary>
        /// <param name="WordFileName"></param>
        /// <param name="cirId"></param>
        /// <param name="cimcase"></param>      
        public static void AddDynamicFlange(string WordFileName, string cirId, long cimcase, string formIOGuid)
        {
            try
            {
                //TemplateDynamicTableDef  
                var TemplateDynamicTableDef = masterData.Where(m => m.KeyName == "TemplateDynamicTableDef");
                List<dynamic> dtable = new List<dynamic>();
                int FlangeIndex = 0;
                //DocX document= DocX.Load(WordFileName);
                foreach (var d in TemplateDynamicTableDef)
                {
                    dtable.Add(JToken.Parse(d.KeyValue));
                }
                using (DocX document = DocX.Load(WordFileName))
                {
                    var dynamictable = dtable.Where(d => d.CIMcaseNo == cimcase).FirstOrDefault();
                    if (dynamictable != null)
                    {
                        int maxRow = 12;
                        int maxCol = 2;
                        CIM_CIREntities context = new CIM_CIREntities();

                        Edmx.DynamicTableInput objDynamicTableInput = context.DynamicTableInput.Where(x => x.CirId == cirId).FirstOrDefault();
                        if (objDynamicTableInput != null)
                        {
                            long _CIRID = Convert.ToInt64(cirId);
                            Edmx.ComponentInspectionReport cir = context.ComponentInspectionReport.Where(x => x.ComponentInspectionReportId == _CIRID).FirstOrDefault();
                            document.ReplaceText("_Dy_nmic_Flan_ge_", dynamictable["TableHeader"].ToString());
                            var dynamicValue = context.DynamicFieldsValue.ToList();

                            var _dynamicDetails = context.DynamicDecisionDetails.Where(x => x.CirId == _CIRID & x.FlangeDamageIdentified == true).ToList();

                            for (int i = 1; i <= _dynamicDetails.Count; i++)
                            {
                                int _flangeNo = Convert.ToInt32(_dynamicDetails[i - 1].FlangNo);
                                document.InsertParagraphs("");
                                document.InsertParagraph("Flange" + " " + _flangeNo, false).Bold().Direction = Direction.LeftToRight;
                                document.InsertParagraphs("");
                                document.InsertParagraph("##DYN_AMIC_FLAN_GE" + _flangeNo + "##", false).Direction = Direction.LeftToRight;
                                document.InsertParagraphs("");
                                document.InsertParagraph("##PICTURES" + _flangeNo + "##", false).Direction = Direction.LeftToRight;
                                document.InsertParagraphs("");
                                document.Save();

                                int index = 0;
                                FlangeIndex = i;

                                var _tableFlange = document.AddTable(maxRow, maxCol);
                                _tableFlange.Alignment = Alignment.center;
                                _tableFlange.AutoFit = AutoFit.Contents;
                                _tableFlange.Design = TableDesign.TableGrid;

                                for (int j = 0; j < maxRow; j++)
                                {
                                    _tableFlange.Rows[j].Cells[0].Paragraphs.First().Append(dynamictable["RowHeader" + (j + 1)].ToString());
                                }
                                // Insert row for newly created VUI Bolt plate Field:
                                _tableFlange.InsertRow(2).Cells[0].Paragraphs.First().Append(dynamictable["RowHeader13"].ToString());
                                _tableFlange.InsertRow(8).Cells[0].Paragraphs.First().Append(dynamictable["RowHeader14"].ToString());

                                switch (_flangeNo)
                                {
                                    case 1:
                                        if (string.IsNullOrEmpty(formIOGuid))
                                        {
                                            int MFN_ID = (objDynamicTableInput.Row1Col1.Trim().Length != 0) ? Convert.ToInt32(objDynamicTableInput.Row1Col1) : 0;
                                            var BoltManufacturername = dynamicValue.Where(x => x.ValueId == MFN_ID).FirstOrDefault();

                                            int boltSizeID = (objDynamicTableInput.Row2Col1.Trim().Length != 0) ? Convert.ToInt32(objDynamicTableInput.Row2Col1) : 0;
                                            var BoltSizeText = dynamicValue.Where(x => x.ValueId == boltSizeID).FirstOrDefault();

                                            int movingFlangesID = (objDynamicTableInput.Row4Col1.Trim().Length != 0) ? Convert.ToInt32(objDynamicTableInput.Row4Col1) : 0;
                                            var MovingFlanges = dynamicValue.Where(x => x.ValueId == movingFlangesID).FirstOrDefault();

                                            if (BoltManufacturername != null)
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(BoltManufacturername.Value);
                                            else
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(string.Empty);

                                            if (BoltSizeText != null)
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(BoltSizeText.Value);
                                            else
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(string.Empty);



                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row13Col1);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row3Col1);

                                            if (MovingFlanges != null)
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(MovingFlanges.Value);// == "13" ? "No" : "Yes"
                                            else
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(string.Empty);
                                        }
                                        else
                                        {
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row1Col1);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row2Col1);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row13Col1);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row3Col1);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row4Col1);

                                        }

                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row5Col1);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row6Col1);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row7Col1);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row14Col1);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row8Col1 == "-1" ? " " : (objDynamicTableInput.Row8Col1 == "1" ? "No" : "Yes"));

                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row9Col1);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row10Col1);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row11Col1);
                                        _tableFlange.Rows[index].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row12Col1);

                                        var imgData = context.ImageData.Where(x => x.ComponentInspectionReportId == _CIRID && x.FlangNo == _flangeNo).ToList();
                                        if (imgData != null && imgData.Count > 0)
                                        {
                                            AddFlangePicturesTable(imgData, document, "##PICTURES" + _flangeNo + "##");
                                        }
                                        else
                                        {
                                            document.ReplaceText("##PICTURES" + _flangeNo + "##", "");
                                        }
                                        break;

                                    case 2:
                                        if (string.IsNullOrEmpty(formIOGuid))
                                        {
                                            int MFN_ID2 = (objDynamicTableInput.Row1Col2.Trim().Length != 0) ? Convert.ToInt32(objDynamicTableInput.Row1Col2) : 0;
                                            var BoltManufacturername2 = dynamicValue.Where(x => x.ValueId == MFN_ID2).FirstOrDefault();

                                            int boltSizeID2 = (objDynamicTableInput.Row2Col2.Trim().Length != 0) ? Convert.ToInt32(objDynamicTableInput.Row2Col2) : 0;
                                            var BoltSizeText2 = dynamicValue.Where(x => x.ValueId == boltSizeID2).FirstOrDefault();

                                            int movingFlangesID2 = (objDynamicTableInput.Row4Col2.Trim().Length != 0) ? Convert.ToInt32(objDynamicTableInput.Row4Col2) : 0;
                                            var MovingFlanges2 = dynamicValue.Where(x => x.ValueId == movingFlangesID2).FirstOrDefault();

                                            if (BoltManufacturername2 != null)
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(BoltManufacturername2.Value);
                                            else
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(string.Empty);

                                            if (BoltSizeText2 != null)
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(BoltSizeText2.Value);
                                            else
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(string.Empty);

                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row13Col2);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row3Col2);

                                            if (MovingFlanges2 != null)
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(MovingFlanges2.Value);// == "13" ? "No" : "Yes"
                                            else
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(string.Empty);
                                        }
                                        else
                                        {
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row1Col2);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row2Col2);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row13Col2);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row3Col2);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row4Col2);
                                        }

                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row5Col2);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row6Col2);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row7Col2);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row14Col2);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row8Col2 == "-1" ? " " : (objDynamicTableInput.Row8Col2 == "1" ? "No" : "Yes"));
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row9Col2);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row10Col2);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row11Col2);
                                        _tableFlange.Rows[index].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row12Col2);

                                        var imgData2 = context.ImageData.Where(x => x.ComponentInspectionReportId == _CIRID && x.FlangNo == _flangeNo).ToList();
                                        if (imgData2 != null && imgData2.Count > 0)
                                        {
                                            AddFlangePicturesTable(imgData2, document, "##PICTURES" + _flangeNo + "##");
                                        }
                                        else
                                        {
                                            document.ReplaceText("##PICTURES" + _flangeNo + "##", "");
                                        }
                                        break;

                                    case 3:
                                        if (string.IsNullOrEmpty(formIOGuid))
                                        {
                                            int MFN_ID3 = (objDynamicTableInput.Row1Col3.Trim().Length != 0) ? Convert.ToInt32(objDynamicTableInput.Row1Col3) : 0;
                                            var BoltManufacturername3 = dynamicValue.Where(x => x.ValueId == MFN_ID3).FirstOrDefault();

                                            int boltSizeID3 = (objDynamicTableInput.Row2Col3.Trim().Length != 0) ? Convert.ToInt32(objDynamicTableInput.Row2Col3) : 0;
                                            var BoltSizeText3 = dynamicValue.Where(x => x.ValueId == boltSizeID3).FirstOrDefault();

                                            int movingFlangesID3 = (objDynamicTableInput.Row4Col3.Trim().Length != 0) ? Convert.ToInt32(objDynamicTableInput.Row4Col3) : 0;
                                            var MovingFlanges3 = dynamicValue.Where(x => x.ValueId == movingFlangesID3).FirstOrDefault();

                                            if (BoltManufacturername3 != null)
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(BoltManufacturername3.Value);
                                            else
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(string.Empty);

                                            if (BoltSizeText3 != null)
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(BoltSizeText3.Value);
                                            else
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(string.Empty);

                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row13Col3);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row3Col3);

                                            if (MovingFlanges3 != null)
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(MovingFlanges3.Value);// == "13" ? "No" : "Yes"
                                            else
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(string.Empty);
                                        }
                                        else
                                        {
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row1Col3);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row2Col3);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row13Col3);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row3Col3);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row4Col3);
                                        }

                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row5Col3);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row6Col3);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row7Col3);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row14Col3);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row8Col3 == "-1" ? " " : (objDynamicTableInput.Row8Col3 == "1" ? "No" : "Yes"));
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row9Col3);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row10Col3);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row11Col3);
                                        _tableFlange.Rows[index].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row12Col3);

                                        var imgData3 = context.ImageData.Where(x => x.ComponentInspectionReportId == _CIRID && x.FlangNo == _flangeNo).ToList();
                                        if (imgData3 != null && imgData3.Count > 0)
                                        {
                                            AddFlangePicturesTable(imgData3, document, "##PICTURES" + _flangeNo + "##");
                                        }
                                        else
                                        {
                                            document.ReplaceText("##PICTURES" + _flangeNo + "##", "");
                                        }

                                        break;

                                    case 4:
                                        if (string.IsNullOrEmpty(formIOGuid))
                                        {
                                            int MFN_ID4 = (objDynamicTableInput.Row1Col4.Trim().Length != 0) ? Convert.ToInt32(objDynamicTableInput.Row1Col4) : 0;
                                            var BoltManufacturername4 = dynamicValue.Where(x => x.ValueId == MFN_ID4).FirstOrDefault();

                                            int boltSizeID4 = (objDynamicTableInput.Row2Col4.Trim().Length != 0) ? Convert.ToInt32(objDynamicTableInput.Row2Col4) : 0;
                                            var BoltSizeText4 = dynamicValue.Where(x => x.ValueId == boltSizeID4).FirstOrDefault();

                                            int movingFlangesID4 = (objDynamicTableInput.Row4Col4.Trim().Length != 0) ? Convert.ToInt32(objDynamicTableInput.Row4Col4) : 0;
                                            var MovingFlanges4 = dynamicValue.Where(x => x.ValueId == movingFlangesID4).FirstOrDefault();

                                            if (BoltManufacturername4 != null)
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(BoltManufacturername4.Value);
                                            else
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(string.Empty);

                                            if (BoltSizeText4 != null)
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(BoltSizeText4.Value);
                                            else
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(string.Empty);

                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row13Col4);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row3Col4);

                                            if (MovingFlanges4 != null)
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(MovingFlanges4.Value);// == "13" ? "No" : "Yes"
                                            else
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(string.Empty);
                                        }
                                        else
                                        {
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row1Col4);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row2Col4);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row13Col4);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row3Col4);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row4Col4);
                                        }
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row5Col4);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row6Col4);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row7Col4);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row14Col4);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row8Col4 == "-1" ? " " : (objDynamicTableInput.Row8Col4 == "1" ? "No" : "Yes"));
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row9Col4);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row10Col4);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row11Col4);
                                        _tableFlange.Rows[index].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row12Col4);

                                        var imgData4 = context.ImageData.Where(x => x.ComponentInspectionReportId == _CIRID && x.FlangNo == _flangeNo).ToList();
                                        if (imgData4 != null && imgData4.Count > 0)
                                        {
                                            AddFlangePicturesTable(imgData4, document, "##PICTURES" + _flangeNo + "##");
                                        }
                                        else
                                        {
                                            document.ReplaceText("##PICTURES" + _flangeNo + "##", "");
                                        }
                                        break;

                                    case 5:
                                        if (string.IsNullOrEmpty(formIOGuid))
                                        {
                                            int MFN_ID5 = (objDynamicTableInput.Row1Col5.Trim().Length != 0) ? Convert.ToInt32(objDynamicTableInput.Row1Col5) : 0;
                                            var BoltManufacturername5 = dynamicValue.Where(x => x.ValueId == MFN_ID5).FirstOrDefault();

                                            int boltSizeID5 = (objDynamicTableInput.Row2Col5.Trim().Length != 0) ? Convert.ToInt32(objDynamicTableInput.Row2Col5) : 0;
                                            var BoltSizeText5 = dynamicValue.Where(x => x.ValueId == boltSizeID5).FirstOrDefault();

                                            int movingFlangesID5 = (objDynamicTableInput.Row4Col5.Trim().Length != 0) ? Convert.ToInt32(objDynamicTableInput.Row4Col5) : 0;
                                            var MovingFlanges5 = dynamicValue.Where(x => x.ValueId == movingFlangesID5).FirstOrDefault();

                                            if (BoltManufacturername5 != null)
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(BoltManufacturername5.Value);
                                            else
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(string.Empty);

                                            if (BoltSizeText5 != null)
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(BoltSizeText5.Value);
                                            else
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(string.Empty);

                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row13Col5);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row3Col5);

                                            if (MovingFlanges5 != null)
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(MovingFlanges5.Value);// == "13" ? "No" : "Yes"
                                            else
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(string.Empty);
                                        }
                                        else
                                        {
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row1Col5);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row2Col5);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row13Col5);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row3Col5);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row4Col5);
                                        }

                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row5Col5);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row6Col5);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row7Col5);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row14Col5);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row8Col5 == "-1" ? " " : (objDynamicTableInput.Row8Col5 == "1" ? "No" : "Yes"));
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row9Col5);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row10Col5);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row11Col5);
                                        _tableFlange.Rows[index].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row12Col5);

                                        var imgData5 = context.ImageData.Where(x => x.ComponentInspectionReportId == _CIRID && x.FlangNo == _flangeNo).ToList();
                                        if (imgData5 != null && imgData5.Count > 0)
                                        {
                                            AddFlangePicturesTable(imgData5, document, "##PICTURES" + _flangeNo + "##");
                                        }
                                        else
                                        {
                                            document.ReplaceText("##PICTURES" + _flangeNo + "##", "");
                                        }

                                        break;

                                    case 6:
                                        if (string.IsNullOrEmpty(formIOGuid))
                                        {
                                            int MFN_ID6 = (objDynamicTableInput.Row1Col6.Trim().Length != 0) ? Convert.ToInt32(objDynamicTableInput.Row1Col6) : 0;
                                            var BoltManufacturername6 = dynamicValue.Where(x => x.ValueId == MFN_ID6).FirstOrDefault();

                                            int boltSizeID6 = (objDynamicTableInput.Row2Col6.Trim().Length != 0) ? Convert.ToInt32(objDynamicTableInput.Row2Col6) : 0;
                                            var BoltSizeText6 = dynamicValue.Where(x => x.ValueId == boltSizeID6).FirstOrDefault();

                                            int movingFlangesID6 = (objDynamicTableInput.Row4Col6.Trim().Length != 0) ? Convert.ToInt32(objDynamicTableInput.Row4Col6) : 0;
                                            var MovingFlanges6 = dynamicValue.Where(x => x.ValueId == movingFlangesID6).FirstOrDefault();

                                            if (BoltManufacturername6 != null)
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(BoltManufacturername6.Value);
                                            else
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(string.Empty);

                                            if (BoltSizeText6 != null)
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(BoltSizeText6.Value);
                                            else
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(string.Empty);

                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row13Col6);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row3Col6);

                                            if (MovingFlanges6 != null)
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(MovingFlanges6.Value);
                                            else
                                                _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(string.Empty);
                                        }
                                        else
                                        {
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row1Col6);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row2Col6);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row13Col6);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row3Col6);
                                            _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row4Col6);
                                        }

                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row5Col6);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row6Col6);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row7Col6);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row14Col6);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row8Col6 == "-1" ? " " : (objDynamicTableInput.Row8Col6 == "1" ? "No" : "Yes"));
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row9Col6);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row10Col6);
                                        _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row11Col6);
                                        _tableFlange.Rows[index].Cells[1].Paragraphs.First().Append(objDynamicTableInput.Row12Col6);

                                        var imgData6 = context.ImageData.Where(x => x.ComponentInspectionReportId == _CIRID && x.FlangNo == _flangeNo).ToList();
                                        if (imgData6 != null && imgData6.Count > 0)
                                        {
                                            AddFlangePicturesTable(imgData6, document, "##PICTURES" + _flangeNo + "##");
                                        }
                                        else
                                        {
                                            document.ReplaceText("##PICTURES" + _flangeNo + "##", "");
                                        }
                                        break;

                                    default:
                                        break;
                                }
                                foreach (var paragraph in document.Paragraphs)
                                {
                                    paragraph.FindAll("##DYN_AMIC_FLAN_GE" + _flangeNo + "##").ForEach(x => paragraph.InsertTableAfterSelf((_tableFlange)));
                                }

                                //Decision Section 
                                document.InsertParagraph("Decision for Flange No: " + " " + _flangeNo, false).Bold().Direction = Direction.LeftToRight;
                                document.InsertParagraphs(" ");
                                document.InsertParagraph("##DECISION_SECTION" + _flangeNo + "##", false).Direction = Direction.LeftToRight;

                                var _tableDecision = document.AddTable(3, 2);
                                _tableDecision.Alignment = Alignment.center;
                                _tableDecision.AutoFit = AutoFit.Window;
                                _tableDecision.Design = TableDesign.TableGrid;

                                _tableDecision.Rows[0].Cells[0].Paragraphs.First().Append("Decision");
                                _tableDecision.Rows[1].Cells[0].Paragraphs.First().Append("Repeated inspection");
                                _tableDecision.Rows[2].Cells[0].Paragraphs.First().Append("Replace affected Bolts");

                                int _DecisionID = Convert.ToInt32(_dynamicDetails[i - 1].Decision);
                                DynamicFieldsValue _DecisionValue;
                                if (_DecisionID != -1)
                                {
                                    _DecisionValue = dynamicValue.Where(x => x.ValueId == _DecisionID).FirstOrDefault();
                                    _tableDecision.Rows[0].Cells[1].Paragraphs.First().Append(_DecisionValue.Value == null ? "" : _DecisionValue.Value);
                                }
                                else
                                {
                                    _tableDecision.Rows[0].Cells[1].Paragraphs.First().Append("");
                                }

                                int _RepeatedInspectionsID = Convert.ToInt32(_dynamicDetails[i - 1].RepeatedInspections);
                                DynamicFieldsValue _RepeatedInspectionsValue;
                                if (_RepeatedInspectionsID != -1)
                                {
                                    _RepeatedInspectionsValue = dynamicValue.Where(x => x.ValueId == _RepeatedInspectionsID).FirstOrDefault();
                                    _tableDecision.Rows[1].Cells[1].Paragraphs.First().Append(_RepeatedInspectionsValue.Value == null ? "" : _RepeatedInspectionsValue.Value);
                                }
                                else
                                {
                                    _tableDecision.Rows[1].Cells[1].Paragraphs.First().Append("");
                                }

                                _tableDecision.Rows[2].Cells[1].Paragraphs.First().Append(_dynamicDetails[i - 1].AffectedBolts.ToString() == "1" ? "Yes" : "No");


                                foreach (var paragraph in document.Paragraphs)
                                {
                                    paragraph.FindAll("##DECISION_SECTION" + _flangeNo + "##").ForEach(x => paragraph.InsertTableAfterSelf((_tableDecision)));
                                }

                                document.ReplaceText("##DECISION_SECTION" + _flangeNo + "##", "");
                                document.ReplaceText("##DYN_AMIC_FLAN_GE" + _flangeNo + "##", "");

                            }

                            // SBU RECOMMENDATION
                            document.InsertParagraphs(" ");
                            document.InsertParagraph("##SBU_RECOMMENDATION##", false).Direction = Direction.LeftToRight;

                            var _tableSBURecommendation = document.AddTable(1, 2);
                            _tableSBURecommendation.Alignment = Alignment.center;
                            _tableSBURecommendation.AutoFit = AutoFit.Window;
                            _tableSBURecommendation.Design = TableDesign.TableGrid;

                            _tableSBURecommendation.Rows[0].Cells[0].Paragraphs.First().Append("SBU Recommendation");
                            _tableSBURecommendation.Rows[0].Cells[1].Paragraphs.First().Append(cir.SBURecommendation.ToString());

                            foreach (var paragraph in document.Paragraphs)
                            {
                                paragraph.FindAll("##SBU_RECOMMENDATION##").ForEach(x => paragraph.InsertTableAfterSelf((_tableSBURecommendation)));
                            }
                            document.ReplaceText("##SBU_RECOMMENDATION##", "");
                        }
                        document.Save();
                    }
                }
                using (DocX document = DocX.Load(WordFileName))
                {
                    //document.ReplaceText("##DYN_AMIC_FLAN_GE" + FlangeIndex + "##", "");
                    //document.ReplaceText("_Dy_nmic_Flan_ge_", "");
                    document.Save();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Adding Dynamic Flange Images [Surednra 09-06-2017]
        /// </summary>
        /// <param name="ImageData"></param>
        /// <param name="document"></param>
        /// <param name="Picplaceholder"></param>
        public static void AddFlangePicturesTable(List<Edmx.ImageData> ImageData, DocX document, string PicPlaceHolder)
        {
            try
            {
                int tableindex = 0;
                tableindex++;
                var table = document.AddTable(1, 1);
                table.Alignment = Alignment.center;
                table.AutoFit = AutoFit.Window;
                int row = 0;

                if (ImageData.Count > 0)
                {
                    foreach (var img in ImageData.OrderBy(z => z.ImageOrder))
                    {
                        if (img.ImageDataString.Length == 0)
                            continue;
                        if (row > 0)
                            table.InsertRow();
                        table.InsertRow();

                        // Add content to this Table.

                        Novacode.Image imag;
                        string imgdata = img.ImageDataString.Substring("data:image/jpeg;base64,".Length);
                        using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(imgdata)))
                        {
                            imag = document.AddImage(ms);
                        }

                        Novacode.Picture picture = imag.CreatePicture();
                        // picture.Height = 512;
                        //picture.Width = 600;
                        int maxWidth = 600;
                        int maxHeight = 700;
                        int newHeight = picture.Height;
                        int newWidth = picture.Width;
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

                        picture.Height = newHeight;
                        picture.Width = newWidth;

                        table.Rows[row].Cells[0].Paragraphs.First().AppendPicture(picture); // need to cpmplete
                        table.Rows[row].Cells[0].Paragraphs.First().Alignment = Alignment.center;

                        var _fileName = "";
                        var _description = "";
                        if (img.ImageDescription.Contains("##"))
                        {
                            table.InsertRow();
                            var _newDes = img.ImageDescription.Replace("##", "#");
                            string[] _data = _newDes.Split('#');
                            _fileName = _data[0];
                            _description = _data[1];

                            table.Rows[row + 1].Cells[0].Paragraphs.First().Append("Picture " + img.ImageOrder + " : " + _fileName);// HttpUtility.UrlDecode(img.ImageDescription
                            table.Rows[row + 2].Cells[0].Paragraphs.First().Append("Description " + " : " + _description);

                            table.Rows[row + 1].Cells[0].SetBorder(TableCellBorderType.Top, new Border(Novacode.BorderStyle.Tcbs_double, BorderSize.one, 1, Color.Transparent));
                            table.Rows[row + 1].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(Novacode.BorderStyle.Tcbs_double, BorderSize.one, 1, Color.Transparent));
                            table.Rows[row + 2].Cells[0].SetBorder(TableCellBorderType.Top, new Border(Novacode.BorderStyle.Tcbs_double, BorderSize.one, 1, Color.Transparent));
                            table.Rows[row + 2].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(Novacode.BorderStyle.Tcbs_double, BorderSize.one, 1, Color.Transparent));
                            table.InsertRow();
                            row = row + 4;
                        }
                        else
                        {
                            table.Rows[row + 1].Cells[0].Paragraphs.First().Append("Picture " + img.ImageOrder + " : " + HttpUtility.UrlDecode(img.ImageDescription));// 
                            table.Rows[row + 2].Cells[0].Paragraphs.First().Append("Description " + " : " + " ");

                            table.Rows[row + 1].Cells[0].SetBorder(TableCellBorderType.Top, new Border(Novacode.BorderStyle.Tcbs_double, BorderSize.one, 1, Color.Transparent));
                            table.Rows[row + 1].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(Novacode.BorderStyle.Tcbs_double, BorderSize.one, 1, Color.Transparent));

                            table.InsertRow();
                            row = row + 3;
                        }
                    }
                }
                foreach (var paragraph in document.Paragraphs)
                {
                    paragraph.FindAll(PicPlaceHolder).ForEach(index => paragraph.InsertTableAfterSelf((table)));
                }

                //Remove tag
                document.ReplaceText("##TABLE##", "");
                document.ReplaceText(PicPlaceHolder, "");

                document.Save();

            }
            catch (Exception oException)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "CIRPdfReport [Inserting Image ] Error", LogType.Error, "");
            }
        }

        public static void AddDynamicTable(string WordFileName, string cirId, long cimcase)
        {
            //TemplateDynamicTableDef
            var TemplateDynamicTableDef = masterData.Where(m => m.KeyName == "TemplateDynamicTableDef");
            List<dynamic> dtable = new List<dynamic>();
            foreach (var d in TemplateDynamicTableDef)
            {
                dtable.Add(JToken.Parse(d.KeyValue));
            }
            var dynamictable = dtable.Where(d => d.CIMcaseNo == cimcase).FirstOrDefault();
            if (dynamictable != null)
            {
                int maxRow = 10;
                int maxCol = 6;
                for (int i = maxRow; i >= 1; i--)
                {
                    if (string.IsNullOrEmpty(dynamictable["RowHeader" + i].ToString()))
                        maxRow--;
                    else
                        break;
                }
                for (int i = maxCol; i >= 1; i--)
                {
                    if (string.IsNullOrEmpty(dynamictable["ColHeader" + i].ToString()))
                        maxCol--;
                    else
                        break;
                }

                CIM_CIREntities context = new CIM_CIREntities();


                using (DocX document = DocX.Load(WordFileName))
                {
                    var table = document.AddTable(maxRow + 1, maxCol + 1);
                    table.Alignment = Alignment.center;
                    table.AutoFit = AutoFit.Window;
                    table.Design = TableDesign.LightGridAccent1;
                    document.ReplaceText("_Dy_nmic_Tab_le_", dynamictable["TableHeader"].ToString());
                    for (int i = 1; i <= maxCol; i++)
                    {
                        table.Rows[0].Cells[i].Paragraphs.First().Append(dynamictable["ColHeader" + i].ToString()).Bold();
                    }
                    for (int i = 1; i <= maxRow; i++)
                    {
                        table.Rows[i].Cells[0].Paragraphs.First().Append(dynamictable["RowHeader" + i].ToString()).Bold();
                    }

                    Edmx.DynamicTableInput objDynamicTableInput = context.DynamicTableInput.Where(x => x.CirId == cirId).FirstOrDefault();
                    if (objDynamicTableInput != null)
                    {
                        for (int rw = 1; rw <= maxRow; rw++)
                        {
                            for (int col = 1; col <= maxCol; col++)
                            {
                                var val = objDynamicTableInput.GetType().GetProperty("Row" + rw + "Col" + col).GetValue(objDynamicTableInput, null);
                                if (val != null)
                                {
                                    table.Rows[rw].Cells[col].Paragraphs.First().Append(val.ToString());
                                }
                            }
                        }
                    }

                    foreach (var paragraph in document.Paragraphs)
                    {
                        paragraph.FindAll("##DYN_AMIC_TAB_LE##").ForEach(index => paragraph.InsertTableAfterSelf((table)));
                    }
                    document.ReplaceText("##DYN_AMIC_TAB_LE##", "");
                    document.Save();
                }
            }

            using (DocX document = DocX.Load(WordFileName))
            {
                document.ReplaceText("##DYN_AMIC_TAB_LE##", "");
                document.ReplaceText("_Dy_nmic_Tab_le_", "");
                document.Save();
            }

        }

        public static void AddPicturesTable(string WordFileName, List<Edmx.ImageData> ImageData)
        {
            try
            {
                // Load the document.
                using (DocX document = DocX.Load(WordFileName))
                {
                    int tableindex = 0;

                    tableindex++;

                    var table = document.AddTable(1, 1);
                    table.Alignment = Alignment.center;
                    table.AutoFit = AutoFit.Window;
                    int row = 0;


                    if (ImageData.Count > 0)
                    {

                        foreach (var img in ImageData.OrderBy(z => z.ImageOrder))
                        {
                            if (img.ImageDataString.Length == 0)
                                continue;
                            if (row > 0)
                                table.InsertRow();
                            table.InsertRow();


                            // Add content to this Table.

                            Novacode.Image imag;
                            string imgdata = img.ImageDataString.Substring("data:image/jpeg;base64,".Length);
                            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(imgdata)))
                            {
                                imag = document.AddImage(ms);
                            }

                            Novacode.Picture picture = imag.CreatePicture();
                            // picture.Height = 512;
                            //picture.Width = 600;
                            int maxWidth = 600;
                            int maxHeight = 700;
                            int newHeight = picture.Height;
                            int newWidth = picture.Width;
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

                            picture.Height = newHeight;
                            picture.Width = newWidth;

                            table.Rows[row].Cells[0].Paragraphs.First().AppendLine("");
                            table.Rows[row].Cells[0].Paragraphs.First().AppendPicture(picture); // need to cpmplete
                            table.Rows[row].Cells[0].Paragraphs.First().Alignment = Alignment.center;
                            table.Rows[row].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(Novacode.BorderStyle.Tcbs_single, BorderSize.four, 1, Color.LightGray));

                            var _fileName = "";
                            var _description = "";
                            if (img.ImageDescription != null && img.ImageDescription.Contains("##"))
                            {
                                table.InsertRow();
                                var _newDes = img.ImageDescription.Replace("##", "#");
                                string[] _data = _newDes.Split('#');
                                _fileName = _data[0];
                                _description = _data[1];

                                table.Rows[row + 1].Cells[0].Paragraphs.First().Append("Picture " + img.ImageOrder + " : " + _fileName);// HttpUtility.UrlDecode(img.ImageDescription
                                table.Rows[row + 2].Cells[0].Paragraphs.First().Append("Description " + " : " + _description);

                                table.Rows[row + 1].Cells[0].SetBorder(TableCellBorderType.Top, new Border(Novacode.BorderStyle.Tcbs_double, BorderSize.one, 1, Color.Transparent));
                                table.Rows[row + 1].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(Novacode.BorderStyle.Tcbs_single, BorderSize.four, 1, Color.LightGray));
                                table.Rows[row + 2].Cells[0].SetBorder(TableCellBorderType.Top, new Border(Novacode.BorderStyle.Tcbs_double, BorderSize.one, 1, Color.Transparent));
                                table.Rows[row + 2].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(Novacode.BorderStyle.Tcbs_thick, BorderSize.one, 1, Color.Black));
                                table.InsertRow();
                                row = row + 4;
                            }
                            else
                            {
                                table.InsertRow();
                                if (img.ImageDescription != null)
                                {
                                    table.Rows[row + 1].Cells[0].Paragraphs.First().Append("Picture " + img.ImageOrder + " : " + HttpUtility.UrlDecode(img.ImageDescription));// 
                                }
                                else
                                {
                                    table.Rows[row + 1].Cells[0].Paragraphs.First().Append("Picture " + img.ImageOrder + " : ");
                                }
                                table.Rows[row + 2].Cells[0].Paragraphs.First().Append("Description " + " : " + " ");

                                table.Rows[row + 1].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(Novacode.BorderStyle.Tcbs_single, BorderSize.four, 1, Color.Transparent));
                                table.Rows[row + 2].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(Novacode.BorderStyle.Tcbs_thick, BorderSize.one, 1, Color.Transparent));

                                table.InsertRow();
                                row = row + 3;
                            }
                        }

                    }

                    // Insert table at index where tag #TABLE# is in document.
                    //document.InsertTable(table);
                    foreach (var paragraph in document.Paragraphs)
                    {
                        paragraph.FindAll("##PICTURES##").ForEach(index => paragraph.InsertTableAfterSelf((table)));
                    }

                    //Remove tag
                    document.ReplaceText("##TABLE##", "");
                    document.ReplaceText("##PICTURES##", "");

                    //    }

                    //}

                    document.Save();
                    //    }
                    // Save changes made to this document.




                } // Release this document from memory.
            }
            catch (Exception oException)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "CIRPdfReport [Inserting Image ] Error", LogType.Error, "");
            }
        }

        private static object GetPropertyValue(Object fromObject, string propertyName)
        {
            Type objectType = fromObject.GetType();
            PropertyInfo propInfo = objectType.GetProperty(propertyName);
            if (propInfo == null && propertyName.Contains('.'))
            {
                string firstProp = propertyName.Substring(0, propertyName.IndexOf('.'));
                propInfo = objectType.GetProperty(firstProp);
                if (propInfo == null)//property name is invalid
                {
                    throw new ArgumentException(String.Format("Property {0} is not a valid property of {1}.", firstProp, fromObject.GetType().ToString()));
                }
                return GetPropertyValue(propInfo.GetValue(fromObject, null), propertyName.Substring(propertyName.IndexOf('.') + 1));
            }
            else
            {
                return propInfo.GetValue(fromObject, null);
            }
        }

        private static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
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

        public static List<MasterKeyData> GetMasterDataForCIRReport()
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

        public static void CreateCirWordDoc(string WordFile, Dictionary<string, string> keyValues)
        {

            // Load the document.
            using (DocX document = DocX.Load(WordFile))
            {
                var sortedkeyValues = keyValues.OrderByDescending(k => k.Key);
                // Replace text in this document.
                foreach (KeyValuePair<string, string> item in sortedkeyValues)
                {
                    try
                    {
                        //document.ReplaceText(oldValue: item.Key, newValue: item.Value, fo: MatchFormattingOptions.ExactMatch);
                        document.ReplaceText(item.Key, item.Value, false, RegexOptions.None, null, null, MatchFormattingOptions.ExactMatch);
                    }
                    catch { }
                }

                // Save changes made to this document.

                document.Save();
            } // Release this document from memory.



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

        /// <summary>
        ///  Return Connection string
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CIM_MasterDataConn"].ConnectionString;
        }

        public static string GetMasterKeyName(string name)
        {
            if (name == "BeforeInspectionTurbineRunStatusId" || name == "AfterInspectionTurbineRunStatusId") return "TurbineRunStatus";
            if (name == "ComponentUpTowerSolutionID") return "ComponentUpTowerSolution";
            if (name == "HVCoilConditionId" || name == "LVCoilConditionId") return "CoilCondition";
            if (name == "HVCableConditionId" || name == "LVCableConditionId") return "CableCondition";
            if (name.ToLower() == "skiipcauseid") return "SkiipackFailureCause";
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
            if (name.Contains("OutSideSign")) return "OutSideSign";

            else return name;
        }
    }
    public class MasterKeyData
    {
        public string KeyName { get; set; }
        public string KeyID { get; set; }
        public string KeyValue { get; set; }
    }

}
