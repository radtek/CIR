using Cir.CloudConvert.Wrapper;
using Cir.Data.Access.CirSyncService;
using Cir.Data.Access.Enumerations;
using Cir.Data.Access.Helpers;
using Cir.Data.Access.Models;
using Microsoft.Azure.Documents.Client;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Novacode;
using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Document = Spire.Doc.Document;
using Paragraph = Spire.Doc.Documents.Paragraph;

namespace Cir.Data.Access.DataAccess
{
    public class CreateCIRPdf
    {
        public string DatabaseId;
        public string EndPointURI;
        public string PrimaryKey;
        public CloudStorageAccount storageAccount;
        public CloudBlobClient blobClient;
        public CloudBlobContainer sourceContainer;
        public CloudBlobContainer destinationContainer;
        public CloudBlobContainer imageContainer;
        private SyncServiceClient _serviceClient;

        //Added
        private string _containerName = ConfigurationManager.AppSettings["AzureStorageContainerName"];

        public CreateCIRPdf()
        {
            DatabaseId = ConfigurationManager.AppSettings["Database"];
            EndPointURI = ConfigurationManager.AppSettings["EndPointUrl"];
            PrimaryKey = ConfigurationManager.AppSettings["PrimaryKey"];
            storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["AzureStorageConnectionString"]);
            blobClient = storageAccount.CreateCloudBlobClient();
            sourceContainer = blobClient.GetContainerReference(ConfigurationManager.AppSettings["AzureStorageTemplateContainerName"]);
            destinationContainer = blobClient.GetContainerReference(ConfigurationManager.AppSettings["AzureStorageContainerName"]);
            imageContainer = blobClient.GetContainerReference(ConfigurationManager.AppSettings["AzureStorageContainerName"]);
            _serviceClient = new SyncServiceClient("WSHttpBinding_ISyncService");
        }
        public async Task<Byte[]> callRenderReport(CirSubmissionData cirData)
        {
            Byte[] retVal = null;
            if (cirData != null)
                try
                {
                    retVal = await RenderCirReport(cirData);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            return retVal;
        }
        public async Task<Byte[]> RenderCirReport(CirSubmissionData cirData)
        {
            string destinationCIRTemplate = string.Empty;
            byte[] PdfDocBytes = null;
            string spireLicenseKey = ConfigurationManager.AppSettings["SpireLicenseKey"];
            Spire.License.LicenseProvider.SetLicenseKey(spireLicenseKey);
            try
            {
                Dictionary<string, string> keyValues = new Dictionary<string, string>();
                keyValues.Add("_CIRID", cirData.CirId.ToString());
                long ComponentType = 1;
                string fileName = string.Empty, cirId = cirData.CirId.ToString();
                string stTemplateVersion = string.Empty;
                if (cirData.templateVersion < 1 && cirData.templateVersion.ToString(System.Globalization.CultureInfo.InvariantCulture).Contains('.'))
                    stTemplateVersion = cirData.templateVersion.ToString(System.Globalization.CultureInfo.InvariantCulture).Split('.')[1];
                else if (cirData.templateVersion == 0)
                    stTemplateVersion = "9";
                else

                    stTemplateVersion = Convert.ToString(cirData.templateVersion + 8);
                keyValues.Add("_version", "v" + stTemplateVersion);
                keyValues.Add("_CreatedBy", cirData.CreatedBy);
                ComponentType = (int)Enum.Parse(typeof(Enumeration.CirTemplate), cirData.CirTemplateName);
                string turbineNumber = CirDataValue(cirData, "txtTurbineNumber");
                string cimCase = CirDataValue(cirData, "ddlCimCaseNumber") == "" ? CirDataValue(cirData, "txtCimCaseNumber") : CirDataValue(cirData, "ddlCimCaseNumber");
                string serviceEngineerTechnician = CirDataValue(cirData, "txtServiceEngineerTechnician");
                keyValues.Add("_FormIOGUID", cirData.Id);
                keyValues.Add("_TurbineNumber", turbineNumber);
                keyValues.Add("_CIMCaseNumber", cimCase);
                keyValues.Add("_ComponentInspectionReportTypeId", cirData.CirTemplateName == "BladeInspection" ? "Blade" : cirData.CirTemplateName);
                keyValues.Add("_FlangDescription", "");
                fileName = getCirName(Convert.ToString(CirDataValue(cirData, "txtSiteName")), cirData.CirTemplateName, turbineNumber, cimCase, cirData.CreatedOn);
                fileName = fileName.Replace(".xml", "");
                fileName = fileName.Replace('/', '_').Replace('\\', '_');
                string sourceCIRTemplate = string.Empty, docType = "CIR", contentType = "PDF";
                string guid = Guid.NewGuid().ToString(), docExtn = ".docx";
                //Added for Multiple blob storages
                if (!(destinationContainer.GetDirectoryReference($"{turbineNumber}/{docType}/{cirData.Id}").ListBlobs().Count() > 0))
                {
                    CloudStorageAccount storageAccount = GetStorageHash.GetStorageAccount(cirData.Id);
                    blobClient = storageAccount.CreateCloudBlobClient();
                    destinationContainer = blobClient.GetContainerReference(_containerName);
                    imageContainer = blobClient.GetContainerReference(_containerName);
                }
                destinationCIRTemplate = $"{turbineNumber}/{docType}/{cirData.Id}/{contentType}/{guid}{docExtn}";
                bool isrepair = ComponentType == 9 ? true : false;
                string reportTypeid = CirDataValue(cirData, "rbReportType") == "" ? CirDataValue(cirData, "ddlReportType") : CirDataValue(cirData, "rbReportType");
                reportTypeid = ComponentType == 8 ? "1" : reportTypeid;
                string ReportTypeName = "";
                if (reportTypeid.Length > 0)
                {
                    ReportTypeName = Enum.GetName(typeof(Enumeration.ReportType), Convert.ToInt16(ComponentType == 1 ? (Convert.ToInt16(reportTypeid) == 4 ? 5 : Convert.ToInt16(reportTypeid)) : Convert.ToInt16(reportTypeid)));
                }
                keyValues.Add("_ReportTypeId", ReportTypeName);
                keyValues.Add("modifiedOn", Convert.ToDateTime(cirData.ModifiedOn).ToString("yyyy-MM-dd HH:mm:ss"));
                ComponentType = ComponentType == 9 ? 1 : ComponentType;
                CirTemplateDataModel cirTemplate = GetTemplateSchema(cirData.CirTemplateId);
                if (cirTemplate != null)
                {
                    AddKeyValuePair(cirData.Data.ToString(), ref keyValues, ComponentType, cirTemplate);
                    switch (ComponentType)
                    {
                        case 1:
                            if (reportTypeid == "3" || isrepair)
                                sourceCIRTemplate = "CIR_Template_v7_Blade.docx";
                            else
                                sourceCIRTemplate = "CIR_Template_v7_BladeExceptRepair.docx";
                            AddKeyValueByName(ref keyValues, "_ComponentTypeId", "Blade");
                            AddKeyValueByName(ref keyValues, "#$BladePicturesIncludedBooleanAnswerId$#", "Yes");
                            if (keyValues.ContainsKey("#$ctbDamageIdentified$#")) { keyValues["#$ctbDamageIdentified$#"] = (keyValues["#$ctbDamageIdentified$#"] == "Yes" ? "True" : "False"); }
                            serviceEngineerTechnician = string.IsNullOrEmpty(serviceEngineerTechnician) ? "Vestas" : serviceEngineerTechnician;
                            if (keyValues.ContainsKey("#$txtServiceEngineerTechnician$#")) { keyValues["#$txtServiceEngineerTechnician$#"] = serviceEngineerTechnician; } else { keyValues.Add("#$txtServiceEngineerTechnician$#", serviceEngineerTechnician); };
                            break;
                        case 2:
                            sourceCIRTemplate = "CIR_Template_v7_Generator.docx";
                            AddKeyValueByName(ref keyValues, "_ComponentTypeId", "Generator");
                            keyValues["#$undefinedColumns2FieldsetGeneratorrewoundlocally$#"] = (keyValues["#$undefinedColumns2FieldsetGeneratorrewoundlocally$#"] == "Yes" ? "True" : "False");
                            keyValues["#$chkInsulationComments$#"] = (keyValues["#$chkInsulationComments$#"] == "Yes" ? "True" : "False");
                            break;
                        case 3:
                            sourceCIRTemplate = "CIR_Template_v7_Gearbox.docx";
                            AddKeyValueByName(ref keyValues, "_ComponentTypeId", "Gearbox");
                            if (!keyValues.ContainsKey("GearboxDefectCategorizationScore"))
                            {
                                string pagetext = CirDataValue(cirData, "page2TextField");
                                if (pagetext.Contains("Defect Categorization Score "))
                                {
                                    pagetext = pagetext.Split(new char[] { '\t' })[1].ToString();
                                }
                                else
                                {
                                    pagetext = "";
                                }
                                AddKeyValueByName(ref keyValues, "#$GearboxDefectCategorizationScore$#", pagetext);
                            }
                            break;
                        case 4:
                            sourceCIRTemplate = "CIR_Template_v7_Transformer.docx";
                            AddKeyValueByName(ref keyValues, "_ComponentTypeId", "Transformer");
                            break;
                        case 5:
                            sourceCIRTemplate = "CIR_Template_v7_General.docx";
                            AddKeyValueByName(ref keyValues, "_ComponentTypeId", "General");
                            break;
                        case 6:
                            sourceCIRTemplate = "CIR_Template_v7_Mainbearing.docx";
                            AddKeyValueByName(ref keyValues, "_ComponentTypeId", "Mainbearing");
                            break;
                        case 7:
                            sourceCIRTemplate = "CIR_Template_v7_Skiip.docx";
                            AddKeyValueByName(ref keyValues, "_ComponentTypeId", "Skiipack");
                            break;
                        case 8:
                            if (cimCase == "3664" || cimCase == "3550" || cimCase == "3800" || cimCase == "3921")
                                sourceCIRTemplate = "CIR_Template_v7_Simplifieds.docx";
                            else
                                sourceCIRTemplate = "CIR_Template_v7_Simplified_withoutFlange.docx";
                            AddKeyValueByName(ref keyValues, "_ComponentTypeId", "Simplified");
                            break;
                        default:
                            break;
                    }

                    Document pdfDocument = GetDocument(sourceCIRTemplate, sourceContainer, docType);
                    if (pdfDocument != null)
                    {
                        if (ComponentType == 1)
                        {
                            pdfDocument = AddBladeDamageData(pdfDocument, cirData);
                        }
                        if (ComponentType == 7)
                        {
                            if (cirData.Data["ddlNumberOfComponents"] != null && Convert.ToInt16(cirData.Data["ddlNumberOfComponents"].Value) > 0)
                            {
                                JObject jsonSkii = JObject.Parse(cirData.Data.ToString());
                                pdfDocument = AddSkiipNewComponent(pdfDocument, jsonSkii, Convert.ToInt16(cirData.Data["ddlNumberOfComponents"].Value));
                                pdfDocument = AddSkiipFailedComponent(pdfDocument, jsonSkii, Convert.ToInt16(cirData.Data["ddlNumberOfComponents"].Value));
                            }
                        }
                        if (ComponentType == 8)
                        {
                            if (cimCase == "3664" || cimCase == "3550" || cimCase == "3800" || cimCase == "3921")
                                pdfDocument = AddDynamicFlange(pdfDocument, cirId.ToString(), cimCase, cirData);
                        }
                        else
                        {
                            if (cirData.ImageReferences != null && cirData.ImageReferences.Count > 0)
                            {
                                JObject submissionData = JObject.Parse(cirData.Data.ToString());
                                IList<ImageDataModel> lstRefrences = cirData.ImageReferences;

                                pdfDocument = AddPicturesTable(pdfDocument, cirData);
                            }
                            else
                            {
                                AddKeyValueByName(ref keyValues, "##PICTURES##", "");
                            }
                            if (cirData.ImageReferences != null && cirData.ImageReferences.Count > 0)
                            {
                                keyValues.Add("#$IsPlateTypeNotPossible$#", ((cirData.Data["tbPlateTypePictureNotPossibleReason"] != null) ? ((cirData.Data["tbPlateTypePictureNotPossibleReason"].Value.ToString().ToLower() == "true") ? "Yes" : "No") : "No"));
                                keyValues.Add("#$PlateTypeNotPossibleReason$#", cirData.Data["tbPlateTypePictureNotPossibleReason"] == null ? "" : cirData.Data["tbPlateTypePictureNotPossibleReason"].Value);
                            }
                            else
                            {
                                keyValues.Add("#$IsPlateTypeNotPossible$#", "No");
                                keyValues.Add("#$PlateTypeNotPossibleReason$#", "");
                            }

                            pdfDocument = AddDynamicTable(pdfDocument, cirId, cimCase, cirData, destinationCIRTemplate, destinationContainer);
                            pdfDocument = AddRevisionTable(pdfDocument, cirData);
                        }

                        PdfDocBytes = CreateCIRDoc(pdfDocument, keyValues, ComponentType, fileName, destinationContainer, destinationCIRTemplate, cirData.Revision.ToString());
                        return PdfDocBytes;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return PdfDocBytes;
        }

        public Document AddRevisionTable(Document pdfDocument, CirSubmissionData cirdata)
        {
            try
            {
                using (MemoryStream pdfDocStream = new MemoryStream())
                {
                    pdfDocument.SaveToStream(pdfDocStream, FileFormat.Docx);
                    using (DocX document = DocX.Load(pdfDocStream))
                    {

                        if (cirdata.RevisionHistory != null && cirdata.RevisionHistory.Count > 0)
                        {
                            int tableindex = 0;
                            tableindex++;

                            var table = document.AddTable(cirdata.RevisionHistory.Count + 1, 3);
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
                            foreach (RevisionHistory rev in cirdata.RevisionHistory)
                            {
                                string editedon = rev.editedOn == null ? "" : Convert.ToDateTime(rev.editedOn).ToString("dd/MM/yyyy");
                                table.Rows[row].Cells[0].Paragraphs.First().Append(editedon);
                                table.Rows[row].Cells[1].Paragraphs.First().Append(rev.editedBy);
                                table.Rows[row].Cells[2].Paragraphs.First().Append(rev.Comments);
                                row++;
                            }
                            foreach (var paragraph in document.Paragraphs)
                            {
                                paragraph.FindAll("##REVISION##").ForEach(index => paragraph.InsertTableAfterSelf(table));
                            }
                        }
                        document.ReplaceText("##REVISION##", "");
                        document.Save();

                        document.SaveAs(pdfDocStream);
                        pdfDocument = new Document(pdfDocStream);
                        return pdfDocument;
                    }
                }
            }
            catch (Exception oException)
            {
                throw oException;
            }
        }
        public Document GetDocument(string sourceDocument, CloudBlobContainer sourceContainer, string DocType)
        {
            try
            {
                sourceDocument = $"{DocType}/{sourceDocument}";
                var sourceBlob = sourceContainer.GetBlockBlobReference(sourceDocument);
                if (sourceBlob.Exists())
                {
                    MemoryStream docStream = new MemoryStream();
                    sourceBlob.DownloadToStream(docStream);
                    Document document = new Document(docStream);
                    return document;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string getCirName(string site, string comptype, string turbineno, string CIMCaseNumber, DateTime d)
        {
            try
            {
                var cirname = "";
                cirname = ((site == null) ? " " : site);
                cirname = cirname.Length > 17 ? cirname.Substring(0, 17) : cirname;
                cirname = cirname + "_" + (comptype == "BladeInspection" ? "Blade" : comptype) + "_" + turbineno + "_" + d.Year.ToString() + "-" + d.Month.ToString().PadLeft(2, '0') + "-" + d.Day.ToString().PadLeft(2, '0') + "_" + CIMCaseNumber;
                return cirname;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Document AddBladeDamageData(Document pdfDocument, CirSubmissionData cirdata)
        {
            try
            {
                using (MemoryStream pdfDocStream = new MemoryStream())
                {
                    pdfDocument.SaveToStream(pdfDocStream, FileFormat.Docx);
                    using (DocX document = DocX.Load(pdfDocStream))
                    {
                        Dictionary<int, string> dict = new Dictionary<int, string>();
                        var table = document.Tables[2];
                        int row = 1;
                        JObject dataBlade = JObject.Parse(cirdata.Data.ToString());
                        if (cirdata.Data["imagecomponentKey"] != null)
                        {
                            JObject cirBladeDamages = JObject.Parse(cirdata.Data["imagecomponentKey"].ToString());
                            JToken Damages = cirBladeDamages.SelectToken("uploadedImagesCache");
                            foreach (JToken d in Damages)
                            {
                                if (d.SelectToken("damageIdentified") != null && d.SelectToken("damageIdentified").ToString().ToLower() == "true")
                                {
                                    if (((JArray)d.SelectToken("damageDetails")) == null || !dict.ContainsValue(((JArray)d.SelectToken("damageDetails"))[0]["damageId"].ToString()))
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
                                        table.Rows[row].Cells[1].Paragraphs.First().Append(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(GetPropValue(d, "damagePlacement").ToLower()));
                                        row++;
                                        table.Rows[row].Cells[0].Paragraphs.First().Append("Damage Type").Bold().Direction = Direction.RightToLeft; ;
                                        table.Rows[row].Cells[1].Paragraphs.First().Append(GetPropValue(d, "damageType"));
                                        row++;
                                        table.Rows[row].Cells[0].Paragraphs.First().Append("Radius (m)").Bold().Direction = Direction.RightToLeft; ;
                                        table.Rows[row].Cells[1].Paragraphs.First().Append(GetPropValue(d, "radius"));
                                        row++;
                                        table.Rows[row].Cells[0].Paragraphs.First().Append("Blade Edge").Bold().Direction = Direction.RightToLeft; ;
                                        table.Rows[row].Cells[1].Paragraphs.First().Append(GetPropValue(d, "side"));
                                        row++;
                                        table.Rows[row].Cells[0].Paragraphs.First().Append("Description").Bold().Direction = Direction.RightToLeft; ;
                                        table.Rows[row].Cells[1].Paragraphs.First().Append(GetPropValue(d, "damageDescription"));
                                        row++;
                                        table.Rows[row].Cells[0].Paragraphs.First().Append("Picture no").Bold().Direction = Direction.RightToLeft; ;
                                        table.Rows[row].Cells[1].Paragraphs.First().Append(GetPropValue(d, "imageNumber"));
                                        if (((JArray)d.SelectToken("damageDetails")) != null)
                                        {
                                            dict.Add(row, ((JArray)d.SelectToken("damageDetails"))[0]["damageId"].ToString());
                                        }
                                        row++;
                                    }
                                    else
                                    {
                                        var myKey = dict.FirstOrDefault(x => x.Value == ((JArray)d.SelectToken("damageDetails"))[0]["damageId"].ToString()).Key;
                                        table.Rows[myKey].Cells[1].Paragraphs.First().Append(" ," + GetPropValue(d, "imageNumber"));
                                    }
                                }
                            }
                        }
                        else
                        {
                            string damagecount = CirDataValue(cirdata, "ddlBladeDamageCount");
                            JObject d = dataBlade;
                            CirTemplateDataModel cirTemplate = GetTemplateSchema(cirdata.CirTemplateId);
                            for (int i = 1; i <= Convert.ToInt32(damagecount == "" ? "0" : damagecount); i++)
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
                                string damageplacement = GetTextFromSchema("ddldamagePlacement" + i.ToString(), cirTemplate.Schema.ToString(), GetPropValue(d, "ddldamagePlacement" + i.ToString()), "");
                                table.Rows[row].Cells[0].Paragraphs.First().Append("Damage Placement").Bold().Direction = Direction.RightToLeft;
                                table.Rows[row].Cells[1].Paragraphs.First().Append(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(damageplacement.ToLower()));
                                row++;
                                string DamageType = GetTextFromSchema("ddldamageType" + i.ToString(), cirTemplate.Schema.ToString(), GetPropValue(d, "ddldamageType" + i.ToString()), "");
                                table.Rows[row].Cells[0].Paragraphs.First().Append("Damage Type").Bold().Direction = Direction.RightToLeft; ;
                                table.Rows[row].Cells[1].Paragraphs.First().Append(DamageType);
                                row++;
                                table.Rows[row].Cells[0].Paragraphs.First().Append("Radius (m)").Bold().Direction = Direction.RightToLeft; ;
                                table.Rows[row].Cells[1].Paragraphs.First().Append(GetPropValue(d, "txtBladeRadius" + i.ToString()));
                                row++;
                                string bladeEdge = GetTextFromSchema("ddlbladeEdge" + i.ToString(), cirTemplate.Schema.ToString(), GetPropValue(d, "ddlbladeEdge" + i.ToString()), "");
                                table.Rows[row].Cells[0].Paragraphs.First().Append("Blade Edge").Bold().Direction = Direction.RightToLeft; ;
                                table.Rows[row].Cells[1].Paragraphs.First().Append(bladeEdge);
                                row++;
                                table.Rows[row].Cells[0].Paragraphs.First().Append("Description").Bold().Direction = Direction.RightToLeft; ;
                                table.Rows[row].Cells[1].Paragraphs.First().Append(GetPropValue(d, "txtDamageDescription" + i.ToString()));
                                row++;
                                table.Rows[row].Cells[0].Paragraphs.First().Append("Picture no").Bold().Direction = Direction.RightToLeft; ;
                                table.Rows[row].Cells[1].Paragraphs.First().Append(GetPropValue(d, "txtDamagePictureno" + i.ToString()));
                                row++;
                            }
                        }
                        document.SaveAs(pdfDocStream);
                        pdfDocument = new Document(pdfDocStream);
                        return pdfDocument;
                    }
                }
            }
            catch (Exception oException)
            {
                throw oException;
            }
        }
        private Document AddSkiipNewComponent(Document pdfDocument, JObject d, int numberOfComponet)
        {
            try
            {
                using (MemoryStream pdfDocStream = new MemoryStream())
                {
                    pdfDocument.SaveToStream(pdfDocStream, FileFormat.Docx);
                    using (DocX document = DocX.Load(pdfDocStream))
                    {
                        var table = document.Tables[4];
                        int row = 1;
                        for (int i = 1; i <= numberOfComponet; i++)
                        {
                            if (row > 1)
                            {
                                table.InsertRow();
                                table.InsertRow();
                                table.InsertRow();
                            }
                            table.Rows[row].Cells[0].Paragraphs.First().Append("Serial Number").Bold().Direction = Direction.RightToLeft;
                            if (d.SelectToken("NewModule" + i.ToString() + "SerialNumber") != null)
                                table.Rows[row].Cells[1].Paragraphs.First().Append(d.SelectToken("NewModule" + i.ToString() + "SerialNumber").ToString());
                            else
                                table.Rows[row].Cells[1].Paragraphs.First().Append("");

                            row++;
                            table.Rows[row].Cells[0].Paragraphs.First().Append("Vestas Unique Identifier").Bold().Direction = Direction.RightToLeft; ;
                            if (d.SelectToken("NewModule" + i.ToString() + "VestasUniqueIdentifier") != null)
                                table.Rows[row].Cells[1].Paragraphs.First().Append(d.SelectToken("NewModule" + i.ToString() + "VestasUniqueIdentifier").ToString());
                            else
                                table.Rows[row].Cells[1].Paragraphs.First().Append("");
                            row++;
                            table.Rows[row].Cells[0].Paragraphs.First().Append("Item No.").Bold().Direction = Direction.RightToLeft; ;
                            if (d.SelectToken("NewModule" + i.ToString() + "ItemNo") != null)
                                table.Rows[row].Cells[1].Paragraphs.First().Append(d.SelectToken("NewModule" + i.ToString() + "ItemNo").ToString());
                            else
                                table.Rows[row].Cells[1].Paragraphs.First().Append("");
                            row++;
                        }
                        document.SaveAs(pdfDocStream);
                        pdfDocument = new Document(pdfDocStream);
                        return pdfDocument;
                    }
                }
            }
            catch (Exception oException)
            {
                throw oException;
            }
        }
        private Document AddSkiipFailedComponent(Document pdfDocument, JObject d, int numberOfComponet)
        {
            try
            {
                using (MemoryStream pdfDocStream = new MemoryStream())
                {
                    pdfDocument.SaveToStream(pdfDocStream, FileFormat.Docx);
                    using (DocX document = DocX.Load(pdfDocStream))
                    {
                        var table = document.Tables[2];
                        int row = 1;
                        for (int i = 1; i <= numberOfComponet; i++)
                        {
                            if (row > 1)
                            {
                                table.InsertRow();
                                table.InsertRow();
                                table.InsertRow();
                            }
                            table.Rows[row].Cells[0].Paragraphs.First().Append("Serial Number").Bold().Direction = Direction.RightToLeft;
                            if (d.SelectToken("ComponentId" + i.ToString() + "SerialNumber") != null)
                                table.Rows[row].Cells[1].Paragraphs.First().Append(d.SelectToken("ComponentId" + i.ToString() + "SerialNumber").ToString());
                            else
                                table.Rows[row].Cells[1].Paragraphs.First().Append("");

                            row++;
                            table.Rows[row].Cells[0].Paragraphs.First().Append("Vestas Unique Identifier").Bold().Direction = Direction.RightToLeft; ;
                            if (d.SelectToken("ComponentId" + i.ToString() + "VestasUniqueIdentifier") != null)
                                table.Rows[row].Cells[1].Paragraphs.First().Append(d.SelectToken("ComponentId" + i.ToString() + "VestasUniqueIdentifier").ToString());
                            else
                                table.Rows[row].Cells[1].Paragraphs.First().Append("");
                            row++;
                            table.Rows[row].Cells[0].Paragraphs.First().Append("Item No.").Bold().Direction = Direction.RightToLeft; ;
                            if (d.SelectToken("ComponentId" + i.ToString() + "ItemNo") != null)
                                table.Rows[row].Cells[1].Paragraphs.First().Append(d.SelectToken("ComponentId" + i.ToString() + "ItemNo").ToString());
                            else
                                table.Rows[row].Cells[1].Paragraphs.First().Append("");
                            row++;
                        }
                        document.SaveAs(pdfDocStream);
                        pdfDocument = new Document(pdfDocStream);
                        return pdfDocument;
                    }
                }
            }
            catch (Exception oException)
            {
                throw oException;
            }
        }
        private byte[] CreateCIRDoc(Document pdfDocument, Dictionary<string, string> keyValues, long ComponentType, string fileName, CloudBlobContainer destinationContainer, string destinationDocument, string revision)
        {
            byte[] PDFByteArray = null;
            string spireLicenseKey = ConfigurationManager.AppSettings["SpireLicenseKey"];
            Spire.License.LicenseProvider.SetLicenseKey(spireLicenseKey);
            try
            {
                #region Create document
                pdfDocument = CreateCirWordDoc
                        (
                            pdfDocument: pdfDocument,
                            keyValues: keyValues
                        );
                #endregion

                for (int j = 0; j < pdfDocument.Sections[0].Paragraphs.Count; j++)
                {
                    Paragraph p = pdfDocument.Sections[0].Paragraphs[j];
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
                Uri wordDoctFilepath = UploadDocumentToBlob(pdfDocument, destinationDocument, destinationContainer);
                string modified = keyValues["modifiedOn"].ToString();
                PDFByteArray = CreatePDF(destinationDocument, fileName, modified, pdfDocument, wordDoctFilepath, destinationContainer, revision).Result;
            }
            catch (Exception e)
            {
                throw e;
            }
            return PDFByteArray;
        }
        public Uri UploadDocumentToBlob(Document pdfDocument, string destinationDocument, CloudBlobContainer destinationContainer)
        {
            try
            {
                var destinationBlob = destinationContainer.GetBlockBlobReference(destinationDocument);
                byte[] myByteArray = null;
                using (MemoryStream stream = new MemoryStream())
                {
                    pdfDocument.SaveToStream(stream, FileFormat.Docx);
                    myByteArray = stream.ToArray();
                    destinationBlob.UploadFromByteArray(myByteArray, 0, myByteArray.Length);
                }
                return destinationBlob.Uri;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Document CreateCirWordDoc(Document pdfDocument, Dictionary<string, string> keyValues)
        {
            try
            {
                using (MemoryStream pdfDocStream = new MemoryStream())
                {
                    pdfDocument.SaveToStream(pdfDocStream, FileFormat.Docx);
                    using (DocX document = DocX.Load(pdfDocStream))
                    {
                        // Load the document.
                        foreach (Novacode.Paragraph item in document.Paragraphs)
                        {
                            if (item.Text.Length > 0)
                            {
                                Regex regex = new Regex(@"#\$(.*?)\$#");
                                Match match = regex.Match(item.Text);
                                if (match.Success)
                                {
                                    if (keyValues.ContainsKey(item.Text))
                                    {
                                        string text = item.Text;
                                        document.ReplaceText(text, (keyValues[item.Text] != null ? keyValues[item.Text] : " "), false, RegexOptions.None, null, null, MatchFormattingOptions.ExactMatch);
                                        keyValues.Remove(text);
                                    }
                                    else
                                    {
                                        if (item.Text.Length == match.Length)
                                        {
                                            document.ReplaceText(item.Text, "", false, RegexOptions.None, null, null, MatchFormattingOptions.ExactMatch);
                                        }
                                    }
                                }
                            }
                        }
                        var sortedkeyValues = keyValues.OrderByDescending(k => k.Key);
                        foreach (KeyValuePair<string, string> item in sortedkeyValues)
                        {
                            document.ReplaceText(item.Key, item.Value, false, RegexOptions.None, null, null, MatchFormattingOptions.ExactMatch);
                        }
                        // These fields exist with text in template Not get replaced above  
                        document.ReplaceText("#$GearboxDefectCategorizationScore$#", "", false, RegexOptions.None, null, null, MatchFormattingOptions.ExactMatch);
                        document.ReplaceText("#$ddlMainBearingRevision$#", "", false, RegexOptions.None, null, null, MatchFormattingOptions.ExactMatch);
                        //
                        document.SaveAs(pdfDocStream);
                        pdfDocument = new Document(pdfDocStream);
                        return pdfDocument;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<byte[]> CreatePDF(string destinationDocName, string fileName, string modified, Document pdfDocument, Uri wordDoctFilepath, CloudBlobContainer destinationContainer, string revision)
        {
            try
            {
                var destinationDocBlob = destinationContainer.GetBlockBlobReference(destinationDocName);
                if (destinationDocBlob.Exists())
                {
                    var sasBlobUri = GetBlobSASUri(wordDoctFilepath.OriginalString.ToString().Split('/')[2].Split(':')[0]);
                    string wordBlobUri = wordDoctFilepath.OriginalString.ToString() + sasBlobUri;
                    ConverterWrapper objPdf = new ConverterWrapper();
                    var res = await objPdf.CreatePDFAsync(wordBlobUri, destinationDocName).ConfigureAwait(false);
                    var destinationPdfName = destinationDocName.Replace("docx", "pdf");
                    var pdfBlobkBlob = destinationContainer.GetBlockBlobReference(destinationPdfName);
                    pdfBlobkBlob.Metadata.Add("modified", modified);
                    pdfBlobkBlob.Metadata.Add("revision", revision);
                    byte[] pdfBytes = Convert.FromBase64String(res.ResponseString);
                    pdfBlobkBlob.UploadFromByteArray(pdfBytes, 0, pdfBytes.Length);
                    return pdfBytes;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Document AddPicturesTable(Document pdfDocument, CirSubmissionData submissionData)
        {
            try
            {
                using (MemoryStream pdfDocStream = new MemoryStream())
                {
                    pdfDocument.SaveToStream(pdfDocStream, FileFormat.Docx);
                    using (DocX document = DocX.Load(pdfDocStream))
                    {
                        int tableindex = 0;
                        tableindex++;
                        var table = document.AddTable(1, 1);
                        table.Alignment = Alignment.center;
                        table.AutoFit = AutoFit.Window;
                        int row = 0;
                        var imageComponentKey = submissionData.Data.SelectToken("imagecomponentKey");
                        var page3UploadImages = submissionData.Data.SelectToken("page3UploadImages");
                        IList<ImageDataModel> lstRefrences = submissionData.ImageReferences;
                        if (imageComponentKey != null)
                        {
                            JObject imageData = JObject.Parse(imageComponentKey.ToString());
                            foreach (JToken img in imageData.SelectToken("uploadedImagesCache").OrderBy(order => order.SelectToken("imageNumber")))
                            {
                                string imageId = GetPropValue(img, "imageId");
                                if (imageId == null)
                                {
                                    continue;
                                }
                                var imgData = lstRefrences.Where(x => x.ImageId == imageId).FirstOrDefault();
                                if (imgData != null)
                                {
                                    MemoryStream ms = new MemoryStream();
                                    if (row > 0)
                                        table.InsertRow();
                                    table.InsertRow();
                                    var sasBlobUri = GetBlobSASUri(imgData.Url.Split('/')[2].Split(':')[0]);
                                    Uri blobUri = new Uri(imgData.Url + sasBlobUri);
                                    CloudBlockBlob imageBlob = new CloudBlockBlob(blobUri);

                                    try
                                    {
                                        imageBlob.DownloadToStream(ms);
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                    Novacode.Image imag;
                                    imag = document.AddImage(ms);
                                    Novacode.Picture picture = imag.CreatePicture();
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

                                    Int32 imageNumber = Convert.ToInt32(img.SelectToken("imageNumber").ToString());
                                    table.InsertRow();
                                    if (imageNumber != 0)
                                    {
                                        var _description = SetImageDescriptionforBlade(img.SelectToken("region").ToString(), img.SelectToken("damageDescription").ToString());
                                        table.Rows[row + 1].Cells[0].Paragraphs.First().Append("Picture " + imageNumber + " : " + img.SelectToken("imageName").ToString());
                                        table.Rows[row + 2].Cells[0].Paragraphs.First().Append("Description " + " : " + _description);
                                        table.Rows[row + 1].Cells[0].SetBorder(TableCellBorderType.Top, new Border(Novacode.BorderStyle.Tcbs_double, BorderSize.one, 1, Color.Transparent));
                                        table.Rows[row + 1].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(Novacode.BorderStyle.Tcbs_single, BorderSize.four, 1, Color.LightGray));
                                        table.Rows[row + 2].Cells[0].SetBorder(TableCellBorderType.Top, new Border(Novacode.BorderStyle.Tcbs_double, BorderSize.one, 1, Color.Transparent));
                                        table.Rows[row + 2].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(Novacode.BorderStyle.Tcbs_thick, BorderSize.one, 1, Color.Black));
                                        row = row + 3;
                                    }
                                    else
                                    {
                                        table.Rows[row + 1].Cells[0].Paragraphs.First().Append("Picture " + imageNumber + " : " + img.SelectToken("imageName").ToString());
                                        table.Rows[row + 2].Cells[0].Paragraphs.First().Append("Description " + " : " + " ");
                                        table.Rows[row + 1].Cells[0].SetBorder(TableCellBorderType.Top, new Border(Novacode.BorderStyle.Tcbs_double, BorderSize.one, 1, Color.Transparent));
                                        table.Rows[row + 1].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(Novacode.BorderStyle.Tcbs_single, BorderSize.four, 1, Color.LightGray));
                                        table.Rows[row + 2].Cells[0].SetBorder(TableCellBorderType.Top, new Border(Novacode.BorderStyle.Tcbs_double, BorderSize.one, 1, Color.Transparent));
                                        table.Rows[row + 2].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(Novacode.BorderStyle.Tcbs_thick, BorderSize.one, 1, Color.Black));
                                        row = row + 3;
                                    }
                                }
                            }
                        }
                        else if (page3UploadImages != null)
                        {
                            int imageNumber = 0;

                            foreach (JToken img in page3UploadImages)
                            {
                                string imageId = GetPropValue(img, "imageId");
                                if (imageId == null)
                                {
                                    continue;
                                }
                                ImageDataModel imgData = lstRefrences.Where(x => x.ImageId == imageId).FirstOrDefault();
                                if (imgData != null)
                                {
                                    MemoryStream ms = new MemoryStream();

                                    if (row > 0)
                                        table.InsertRow();
                                    table.InsertRow();
                                    var sasBlobUri = GetBlobSASUri(imgData.Url.Split('/')[2].Split(':')[0]);
                                    Uri blobUri = new Uri(imgData.Url + sasBlobUri);
                                    CloudBlockBlob imageBlob = new CloudBlockBlob(blobUri);
                                    imageBlob.DownloadToStream(ms);
                                    Novacode.Image imag;
                                    imag = document.AddImage(ms);
                                    Novacode.Picture picture = imag.CreatePicture();
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
                                    var imgDesc = GetPropValue(img, "description");
                                    table.InsertRow();
                                    if (imgDesc != "")
                                    {
                                        table.Rows[row + 1].Cells[0].Paragraphs.First().Append("Picture " + imageNumber + " : " + GetPropValue(img, "fileInfo.name"));// exist in general Template in this format
                                        table.Rows[row + 2].Cells[0].Paragraphs.First().Append("Description " + " : " + imgDesc);
                                        table.Rows[row + 1].Cells[0].SetBorder(TableCellBorderType.Top, new Border(Novacode.BorderStyle.Tcbs_double, BorderSize.one, 1, Color.Transparent));
                                        table.Rows[row + 1].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(Novacode.BorderStyle.Tcbs_single, BorderSize.four, 1, Color.LightGray));
                                        table.Rows[row + 2].Cells[0].SetBorder(TableCellBorderType.Top, new Border(Novacode.BorderStyle.Tcbs_double, BorderSize.one, 1, Color.Transparent));
                                        table.Rows[row + 2].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(Novacode.BorderStyle.Tcbs_thick, BorderSize.one, 1, Color.Black));
                                        row = row + 3;
                                    }
                                    else
                                    {
                                        table.Rows[row + 1].Cells[0].Paragraphs.First().Append("Picture " + imageNumber + " : " + GetPropValue(img, "fileInfo.name"));// exist in general Template in this format
                                        table.Rows[row + 2].Cells[0].Paragraphs.First().Append("Description " + " : " + " ");
                                        table.Rows[row + 1].Cells[0].SetBorder(TableCellBorderType.Top, new Border(Novacode.BorderStyle.Tcbs_double, BorderSize.one, 1, Color.Transparent));
                                        table.Rows[row + 1].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(Novacode.BorderStyle.Tcbs_single, BorderSize.four, 1, Color.LightGray));
                                        table.Rows[row + 2].Cells[0].SetBorder(TableCellBorderType.Top, new Border(Novacode.BorderStyle.Tcbs_double, BorderSize.one, 1, Color.Transparent));
                                        table.Rows[row + 2].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(Novacode.BorderStyle.Tcbs_thick, BorderSize.one, 1, Color.Black));
                                        row = row + 3;
                                    }
                                    imageNumber++;
                                }
                            }
                        }
                        foreach (var paragraph in document.Paragraphs)
                        {
                            paragraph.FindAll("##PICTURES##").ForEach(index => paragraph.InsertTableAfterSelf((table)));
                        }
                        document.ReplaceText("##TABLE##", "");
                        document.ReplaceText("##PICTURES##", "");
                        document.SaveAs(pdfDocStream);
                        pdfDocument = new Document(pdfDocStream);
                        return pdfDocument;
                    }
                }
            }
            catch (Exception oException)
            {
                throw oException;
            }
        }
        public string GetBlobSASUri(string blobName)
        {
            string sasBlobToken = string.Empty;
            switch (blobName.ToString())
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
        public string SetImageDescriptionforBlade(string region, string damageDesc)
        {
            string imageDescription = string.Empty;
            string imageSide = string.Empty;
            string area = string.Empty;
            try
            {
                switch (region)
                {
                    case "2":
                    case "6":
                    case "10":
                        imageSide = "LW";
                        break;
                    case "3":
                    case "7":
                    case "11":
                        imageSide = "LE";
                        break;
                    case "1":
                    case "5":
                    case "9":
                        imageSide = "TE";
                        break;
                    case "section4":
                    case "section8":
                    case "section12":
                        imageSide = "WW";
                        break;
                    default:
                        break;
                }
                switch (region)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                        area = "Root";
                        break;
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                        area = "Mid";
                        break;
                    case "9":
                    case "10":
                    case "11":
                    case "12":
                        area = "Tip";
                        break;
                    default:
                        break;
                }

                if (string.IsNullOrEmpty(damageDesc))
                    damageDesc = "no damage";
                imageDescription = imageSide + " " + area + " - " + damageDesc;
                return imageDescription;
            }
            catch (Exception oException)
            {
                throw oException;
            }
        }
        public Document AddDynamicFlange(Document pdfDocument, string cirId, string cimcase, CirSubmissionData cirData)
        {
            try
            {
                var masterData = _serviceClient.GetMasterDataForCIRReport();
                var TemplateDynamicTableDef = masterData.Where(m => m.KeyName == "TemplateDynamicTableDef");
                JObject jsonCIrData = JObject.Parse(cirData.Data.ToString());
                List<dynamic> dtable = new List<dynamic>();
                foreach (var d in TemplateDynamicTableDef)
                {
                    dtable.Add(JToken.Parse(d.KeyValue));
                }
                var dynamictable = dtable.Where(d => d.CIMcaseNo == cimcase).FirstOrDefault();
                using (MemoryStream pdfDocStream = new MemoryStream())
                {
                    pdfDocument.SaveToStream(pdfDocStream, FileFormat.Docx);
                    using (DocX document = DocX.Load(pdfDocStream))
                    {
                        int maxRow = 12;
                        int maxflange = 6;
                        document.ReplaceText("_Dy_nmic_Flan_ge_", dynamictable["TableHeader"].ToString(), false, RegexOptions.None, null, null, MatchFormattingOptions.ExactMatch);
                        for (int flange = 1; flange <= maxflange; flange++)
                        {
                            string dynamicFieldValues = jsonCIrData.SelectToken("chkDamageIdentifiedSimplifiedFlange" + flange).ToString().ToLower();
                            switch (dynamicFieldValues)
                            {
                                case "true":
                                    string picPlaceholder = "##PICTURES" + flange + "##";
                                    document.InsertParagraphs("");
                                    document.InsertParagraph("Flange" + " " + flange, false).Bold().Direction = Direction.LeftToRight;
                                    document.InsertParagraphs("");
                                    document.InsertParagraph("##DYN_AMIC_FLAN_GE" + flange + "##", false).Direction = Direction.LeftToRight;
                                    document.InsertParagraphs("");
                                    document.InsertParagraph(picPlaceholder, false).Direction = Direction.LeftToRight;
                                    document.InsertParagraphs("");
                                    document.Save();
                                    int index = 0;
                                    var _tableFlange = document.AddTable(maxRow, 2);
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
                                    _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(GetPropValue(jsonCIrData, "ddlBoltmanufacture-Flange" + flange));
                                    _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(GetPropValue(jsonCIrData, "ddlBoltsizeMxx-Flange" + flange));
                                    _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(GetPropValue(jsonCIrData, "txtVUIBoltplate-Flange" + flange));
                                    _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(GetPropValue(jsonCIrData, "txtBrokenbolts-Flange" + flange));
                                    _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(GetPropValue(jsonCIrData, "ddlMovingFlanges-Flange" + flange));
                                    _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(GetPropValue(jsonCIrData, "txtSealantingres-Flange" + flange));
                                    _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(GetPropValue(jsonCIrData, "txtCrackedPaint-Flange" + flange));
                                    _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(GetPropValue(jsonCIrData, "txtMetallizationdust-Flange" + flange));
                                    _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(GetPropValue(jsonCIrData, "txtOutsideSigns-Flange" + flange));
                                    _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(GetPropValue(jsonCIrData, "ddlCorrosionmarksonplatform-Flange" + flange) == "-1" ? " " : (GetPropValue(jsonCIrData, "ddlCorrosionmarksonplatform-Flange" + flange)));
                                    _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(GetPropValue(jsonCIrData, "txtSignofserviceloosebolts-Flange" + flange));
                                    _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(GetPropValue(jsonCIrData, "txtWateringressbetweenflanges-Flange" + flange));
                                    _tableFlange.Rows[index++].Cells[1].Paragraphs.First().Append(GetPropValue(jsonCIrData, "txtWateringressonboltheads-Flange" + flange));
                                    _tableFlange.Rows[index].Cells[1].Paragraphs.First().Append(GetPropValue(jsonCIrData, "txtObviousloosebolts-Flange" + flange));

                                    var imgData = jsonCIrData.SelectToken("imageUploader-Flange" + flange);
                                    if (imgData != null)
                                    {
                                        AddFlangePicturesTable(document, cirData, imgData, picPlaceholder);
                                    }
                                    else
                                    {
                                        document.ReplaceText("##PICTURES" + flange + "##", "");
                                    }
                                    foreach (var paragraph in document.Paragraphs)
                                    {
                                        paragraph.FindAll("##DYN_AMIC_FLAN_GE" + flange + "##").ForEach(x => paragraph.InsertTableAfterSelf((_tableFlange)));
                                    }

                                    document.InsertParagraph("Decision for Flange No: " + " " + flange, false).Bold().Direction = Direction.LeftToRight;
                                    document.InsertParagraphs(" ");
                                    document.InsertParagraph("##DECISION_SECTION" + flange + "##", false).Direction = Direction.LeftToRight;

                                    var _tableDecision = document.AddTable(3, 2);
                                    _tableDecision.Alignment = Alignment.center;
                                    _tableDecision.AutoFit = AutoFit.Window;
                                    _tableDecision.Design = TableDesign.TableGrid;

                                    _tableDecision.Rows[0].Cells[0].Paragraphs.First().Append("Decision");
                                    _tableDecision.Rows[1].Cells[0].Paragraphs.First().Append("Repeated inspection");
                                    _tableDecision.Rows[2].Cells[0].Paragraphs.First().Append("Replace affected Bolts");

                                    string decision = GetPropValue(jsonCIrData, "ddlDecision-Flange" + flange);
                                    _tableDecision.Rows[0].Cells[1].Paragraphs.First().Append(decision == null ? "" : decision);

                                    string RepeatedInspection = GetPropValue(jsonCIrData, "ddlRepeatedinspection-Flange" + flange);
                                    _tableDecision.Rows[1].Cells[1].Paragraphs.First().Append(RepeatedInspection == null ? "" : RepeatedInspection);

                                    string replaceaffectedBolts = GetPropValue(jsonCIrData, "chkReplaceaffectedBolts-Flange" + flange).ToLower();
                                    _tableDecision.Rows[2].Cells[1].Paragraphs.First().Append(replaceaffectedBolts == "true" ? "Yes" : "No");
                                    foreach (var paragraph in document.Paragraphs)
                                    {
                                        paragraph.FindAll("##DECISION_SECTION" + flange + "##").ForEach(x => paragraph.InsertTableAfterSelf((_tableDecision)));
                                    }
                                    document.ReplaceText("##DECISION_SECTION" + flange + "##", "");
                                    document.ReplaceText("##DYN_AMIC_FLAN_GE" + flange + "##", "");
                                    break;
                                default:
                                    break;
                            }

                        }

                        // SBU RECOMMENDATION
                        document.InsertParagraphs(" ");
                        document.InsertParagraph("##SBU_RECOMMENDATION##", false).Direction = Direction.LeftToRight;

                        var _tableSBURecommendation = document.AddTable(1, 2);
                        _tableSBURecommendation.Alignment = Alignment.center;
                        _tableSBURecommendation.AutoFit = AutoFit.Window;
                        _tableSBURecommendation.Design = TableDesign.TableGrid;

                        _tableSBURecommendation.Rows[0].Cells[0].Paragraphs.First().Append("SBU Recommendation");
                        _tableSBURecommendation.Rows[0].Cells[1].Paragraphs.First().Append(GetPropValue(jsonCIrData, "txtSBURecommendation"));

                        foreach (var paragraph in document.Paragraphs)
                        {
                            paragraph.FindAll("##SBU_RECOMMENDATION##").ForEach(x => paragraph.InsertTableAfterSelf((_tableSBURecommendation)));
                        }
                        document.ReplaceText("##SBU_RECOMMENDATION##", "");

                        document.SaveAs(pdfDocStream);
                        pdfDocument = new Document(pdfDocStream);
                        return pdfDocument;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetPropValue(dynamic jsonCIrData, string proprtyname)
        {
            try
            {
                return jsonCIrData.SelectToken(proprtyname) == null ? "" : jsonCIrData.SelectToken(proprtyname).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Document AddDynamicTable(Document pdfDocument, string cirId, string cimcase, CirSubmissionData cirData, string destinationDocument, CloudBlobContainer destinationContainer)
        {
            try
            {
                var masterData = _serviceClient.GetMasterDataForCIRReport();
                var TemplateDynamicTableDef = masterData.Where(m => m.KeyName == "TemplateDynamicTableDef");
                JObject jsonCIrData = JObject.Parse(cirData.Data.ToString());
                List<dynamic> dtable = new List<dynamic>();
                foreach (var d in TemplateDynamicTableDef)
                {
                    dtable.Add(JToken.Parse(d.KeyValue));
                }
                var dynamictable = dtable.Where(d => d.CIMcaseNo == cimcase).FirstOrDefault();
                if (dynamictable != null)
                {
                    int maxRow = 16;
                    int maxCol = 6;
                    for (int i = maxRow; i >= 1; i--)
                    {
                        if (dynamictable["RowHeader" + i] == null || string.IsNullOrEmpty(dynamictable["RowHeader" + i].ToString()))
                            maxRow--;
                        else
                            break;
                    }
                    for (int i = maxCol; i >= 1; i--)
                    {
                        if (dynamictable["ColHeader" + i] == null || string.IsNullOrEmpty(dynamictable["ColHeader" + i].ToString()))
                            maxCol--;
                        else
                            break;
                    }
                    using (MemoryStream pdfDocStream = new MemoryStream())
                    {
                        pdfDocument.SaveToStream(pdfDocStream, FileFormat.Docx);
                        using (DocX document = DocX.Load(pdfDocStream))
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
                            string dynamicFieldValues = jsonCIrData.SelectToken("page5DynamicFields") != null ? jsonCIrData.SelectToken("page5DynamicFields").ToString() : null;
                            var dynamicFields = dynamicFieldValues != null ? JsonConvert.DeserializeObject<IDictionary<string, object>>(dynamicFieldValues) : null;
                            if (dynamicFieldValues != null)
                            {
                                for (int rw = 1; rw <= maxRow; rw++)
                                {
                                    for (int col = 1; col <= maxCol; col++)
                                    {
                                        string fieldName = string.Empty;
                                        switch (col)
                                        {
                                            case 1:
                                                fieldName = "A" + rw;
                                                break;
                                            case 2:
                                                fieldName = "B" + rw;
                                                break;
                                            case 3:
                                                fieldName = "C" + rw;
                                                break;
                                            case 4:
                                                fieldName = "D" + rw;
                                                break;
                                            case 5:
                                                fieldName = "E" + rw;
                                                break;
                                            case 6:
                                                fieldName = "F" + rw;
                                                break;
                                            default:
                                                break;
                                        }
                                        var val = dynamicFields.ContainsKey(fieldName) ? dynamicFields[fieldName] : null;

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
                            document.SaveAs(pdfDocStream);
                            pdfDocument = new Document(pdfDocStream);
                            return pdfDocument;
                        }
                    }
                }
                using (MemoryStream pdfDocStream = new MemoryStream())
                {
                    pdfDocument.SaveToStream(pdfDocStream, FileFormat.Docx);
                    using (DocX document = DocX.Load(pdfDocStream))
                    {
                        document.ReplaceText("##DYN_AMIC_TAB_LE##", "");
                        document.ReplaceText("_Dy_nmic_Tab_le_", "");
                        document.SaveAs(pdfDocStream);
                        pdfDocument = new Document(pdfDocStream);
                        return pdfDocument;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddFlangePicturesTable(DocX document, CirSubmissionData submissionData, JToken imageData, string PicPlaceHolder)
        {
            try
            {
                int tableindex = 0;
                tableindex++;
                var table = document.AddTable(1, 1);
                table.Alignment = Alignment.center;
                table.AutoFit = AutoFit.Window;
                int row = 0;
                int imageNumber = 0;
                var imageReferences = submissionData.ImageReferences;
                foreach (var img in imageData)
                {

                    string imageId = img.SelectToken("imageId").ToString();
                    if (imageId == null)
                    {
                        continue;
                    }
                    var imgData = imageReferences.Where(a => a.ImageId == imageId).FirstOrDefault();
                    if (imgData != null)
                    {
                        if (row > 0)
                            table.InsertRow();
                        table.InsertRow();
                        var sasBlobUri = GetBlobSASUri(imgData.Url.Split('/')[2].Split(':')[0]);
                        Uri blobUri = new Uri(imgData.Url + sasBlobUri);
                        CloudBlockBlob imageBlob = new CloudBlockBlob(blobUri);
                        MemoryStream ms = new MemoryStream();
                        imageBlob.DownloadToStream(ms);
                        Novacode.Image imag;
                        imag = document.AddImage(ms);
                        Novacode.Picture picture = imag.CreatePicture();
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
                        table.InsertRow();
                        var imgDesc = GetPropValue(img, "description");
                        if (!string.IsNullOrEmpty(imgDesc))
                        {

                            table.Rows[row + 1].Cells[0].Paragraphs.First().Append("Picture " + imageNumber + " : " + GetPropValue(img, "fileInfo.name"));// HttpUtility.UrlDecode(img.ImageDescription
                            table.Rows[row + 2].Cells[0].Paragraphs.First().Append("Description " + " : " + GetPropValue(img, "description"));
                            table.Rows[row + 1].Cells[0].SetBorder(TableCellBorderType.Top, new Border(Novacode.BorderStyle.Tcbs_double, BorderSize.one, 1, Color.Transparent));
                            table.Rows[row + 1].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(Novacode.BorderStyle.Tcbs_single, BorderSize.four, 1, Color.LightGray));
                            table.Rows[row + 2].Cells[0].SetBorder(TableCellBorderType.Top, new Border(Novacode.BorderStyle.Tcbs_double, BorderSize.one, 1, Color.Transparent));
                            table.Rows[row + 2].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(Novacode.BorderStyle.Tcbs_thick, BorderSize.one, 1, Color.Black));
                            row = row + 3;
                        }
                        else
                        {
                            table.Rows[row + 1].Cells[0].Paragraphs.First().Append("Picture " + imageNumber + " : " + GetPropValue(img, "fileInfo.name").ToString());
                            table.Rows[row + 2].Cells[0].Paragraphs.First().Append("Description " + " : " + " ");
                            table.Rows[row + 1].Cells[0].SetBorder(TableCellBorderType.Top, new Border(Novacode.BorderStyle.Tcbs_double, BorderSize.one, 1, Color.Transparent));
                            table.Rows[row + 1].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(Novacode.BorderStyle.Tcbs_single, BorderSize.four, 1, Color.LightGray));
                            table.Rows[row + 2].Cells[0].SetBorder(TableCellBorderType.Top, new Border(Novacode.BorderStyle.Tcbs_double, BorderSize.one, 1, Color.Transparent));
                            table.Rows[row + 2].Cells[0].SetBorder(TableCellBorderType.Bottom, new Border(Novacode.BorderStyle.Tcbs_thick, BorderSize.one, 1, Color.Black));
                            row = row + 3;
                        }
                        imageNumber++;
                    }
                }
                foreach (var paragraph in document.Paragraphs)
                {
                    paragraph.FindAll(PicPlaceHolder).ForEach(index => paragraph.InsertTableAfterSelf((table)));
                }
                //Remove tag
                document.ReplaceText("##TABLE##", "");
                document.ReplaceText(PicPlaceHolder, "");
            }
            catch (Exception oException)
            {
                throw oException;
            }
        }

        public void AddKeyValueByName(ref Dictionary<string, string> keyValues, string name, string value)
        {
            if (!keyValues.ContainsKey(name))
            {
                keyValues.Add(name, value);
            }
        }
        public void AddKeyValuePair(string Data, ref Dictionary<string, string> keyValues, long ComponentType, CirTemplateDataModel cirTemplate)
        {
            JObject objData = JObject.Parse(Data.ToString());
            // string[] add2zero = { "txtTransformerMaxTemp", "txtGeneratorMaxTemp", "txtOilTemperatureatoillevelcheck", "txtBearing1", "txtBearing2", "txtBearing3", "txtOilSump" };
            //string[] add3zero = { "txtVoltage", "txtRotorDiameter" };
            foreach (KeyValuePair<string, JToken> keyValuePair in objData)
            {
                try
                {
                    var name = keyValuePair.Key.ToString();
                    var value = keyValuePair.Value;
                    if (value.Type.ToString().ToLower() == "object")
                    {
                        if (name.Contains("ddlDamageClass"))
                        {
                            keyValues.Add("#$" + name + "$#", GetPropValue(value, "label"));
                        }

                        AddKeyValuePair(value.ToString(), ref keyValues, ComponentType, cirTemplate);
                    }
                    else if (value.Type.ToString().ToLower() != "array")
                    {
                        if (!keyValues.ContainsKey(name))
                        {
                            if (name.ToLower().Contains("ddl"))
                            {
                                string Text = GetTextFromSchema(name, cirTemplate.Schema.ToString(), value.ToString(), "");
                                Text = (Text == null ? "" : Text);
                                if (!keyValues.ContainsKey("#$" + name + "$#"))
                                {
                                    Text = (Text == "" ? (value.ToString() != "" ? value.ToString() : "") : Text);
                                    if (Text == "url")
                                    {
                                        keyValues.Add("#$" + name + "$#", ((value == null) ? " " : value.ToString()));
                                    }
                                    else
                                    {
                                        //Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Text.ToLower());
                                        if (name.Contains("ddlGearboxType"))
                                        {
                                            keyValues.Add("#$GearboxType$#", ((Text == null) ? " " : Text));
                                        }
                                        else
                                        {
                                            keyValues.Add("#$" + name + "$#", ((Text == null) ? " " : Text));
                                        }
                                    }
                                }
                            }
                            else if ((name.ToLower().Contains("date") && name.ToLower().Contains("dt")) || value.Type.ToString().ToLower() == "date")
                            {
                                if (value != null && !string.IsNullOrEmpty(value.ToString()))
                                {
                                    CultureInfo ci = new CultureInfo("en-NZ");
                                    string date = Convert.ToDateTime(value).ToString("R", ci);
                                    DateTime convertedDate = DateTime.Parse(date);
                                    if (!keyValues.ContainsKey("#$" + name + "$#"))
                                    {
                                        if (name.ToLower() == "dtheaterinsulationandvacuumoff")
                                        {
                                            keyValues.Add("#$" + name + "$#", ((value == null) ? " " : convertedDate.ToString("dd/MM/yyyy HH:mm:ss")));

                                        }
                                        else
                                        {
                                            keyValues.Add("#$" + name + "$#", ((value == null) ? " " : convertedDate.ToString("dd/MM/yyyy")));
                                        }
                                    }
                                }
                            }
                            else if (name.ToLower() == "frequency")
                            {
                                if (!keyValues.ContainsKey("#$" + name + "$#"))
                                    keyValues.Add("#$" + name + "$#", ((value == null) ? " " : value.ToString().Replace(".000", "")));
                            }
                            else if (value.Type.ToString().ToLower() == "boolean")
                            {
                                if (!keyValues.ContainsKey("#$" + name + "$#"))
                                    keyValues.Add("#$" + name + "$#", ((value == null) ? " " : (Convert.ToBoolean(value) == false ? (ComponentType == 3 ? "False" : "No") : (ComponentType == 3 ? "True" : "Yes"))));

                            }
                            else if (name.ToLower() == "ddloutsidesign")
                            {
                                if (!keyValues.ContainsKey("#$" + name + "$#"))
                                    keyValues.Add("#$" + name + "$#", ((value == null) ? " " : (Convert.ToString(value) == "0" ? "No" : "Yes")));
                            }
                            else
                            {
                                //value = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToString().ToLower());
                                if (!keyValues.ContainsKey("#$" + name + "$#"))
                                {
                                    //if (Array.IndexOf(add2zero, name) >= 0 || name.Contains("dtheaterinsulationandvacuumoff"))
                                    //{
                                    //    value = (value.ToString() == "" ? "0" : value.ToString()) + ".00";
                                    //}
                                    //if (Array.IndexOf(add3zero, name) >= 0)
                                    //{
                                    //    value = (value.ToString() == "" ? "0" : value.ToString()) + ".000";
                                    //}
                                    //if (name == "ddlBladeLength")
                                    //{ value = (value.ToString() == "" ? "0" : value.ToString()) + ",0"; }
                                    keyValues.Add("#$" + name + "$#", ((value == null) ? " " : value.ToString()));
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;

                }
            }
        }
        public string GetTextFromSchema(string name, string schema, string selected, string result)
        {
            if (result.Length > 0)
            {
                return result;
            }
            JObject objData = null;
            try
            {
                objData = JObject.Parse(schema);
                if (objData != null)
                {
                    IEnumerable<JToken> jto = objData.SelectTokens("$..components[?(@.key == '" + name + "')].data.values");
                    foreach (JToken item in jto)
                    {
                        if (name == "ddlCimCaseNumber")
                        { return "url"; }
                        string findvalue = item.Where(x => GetPropValue(x, "value") == selected).Select(x => GetPropValue(x, "label")).FirstOrDefault();
                        return findvalue;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public string CirDataValue(dynamic data, string propname)
        {
            try
            {
                return data.Data[propname] == null ? "" : Convert.ToString(data.Data[propname].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CirMasterKeyModel> GetMasterDataForCIRReport()
        {
            try
            {
                List<CirMasterKeyModel> MasterKeyDataList = new List<CirMasterKeyModel>();
                DataSet dsMasterData = new DataSet();
                var storageAccount = ConfigurationManager.ConnectionStrings["CIM_MasterDataConn"].ConnectionString;
                using (SqlConnection objCon = new SqlConnection(storageAccount))
                {
                    using (SqlCommand cmd = new SqlCommand("spCIRMasterDataAllForCIRReport", objCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dsMasterData);

                            MasterKeyDataList = (from DataRow dr in dsMasterData.Tables[0].Rows
                                                 select new CirMasterKeyModel()
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CirTemplateDataModel GetTemplateSchema(string id)
        {
            try
            {
                DocumentClient _documentClient = new DocumentClient(new Uri(EndPointURI), PrimaryKey);
                Uri _documentCollectionUri = UriFactory.CreateDocumentCollectionUri(DatabaseId, "CirTemplates");
                StringBuilder stQry = new StringBuilder("SELECT * FROM CirTemplates c where LOWER(c.id) = '" + id.ToLower() + "'");
                List<CirTemplateDataModel> cirTemplate = _documentClient.CreateDocumentQuery<CirTemplateDataModel>(
                              UriFactory.CreateDocumentCollectionUri(DatabaseId, "CirTemplates"),
                        stQry.ToString(), new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true }).ToList<CirTemplateDataModel>();
                if (cirTemplate != null)
                    return cirTemplate[0];
                else
                    return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

