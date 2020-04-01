using Aspose.Cells;
using Cir.Common.Utilities;
using Cir.Data.LLBLGen.DatabaseSpecific;
using Cir.Data.LLBLGen.EntityClasses;
using Cir.Data.LLBLGen.FactoryClasses;
using Cir.Data.LLBLGen.HelperClasses;
using Cir.Sync.Services.DataContracts;
using Cir.Sync.Services.ErrorHandling;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Cir.Sync.Services.DAL
{
    public class GeneratorDetail
    {
        public long GeneratorDefectCategorizationId { get; set; }
        public string Component { get; set; }
        public string FailureDamage { get; set; }
        public string IsDamaged { get; set; }
        public string Repair { get; set; }
        public string FailureMode { get; set; }
    }

    public class GearboxDetail
    {
        public int GearboxDefectCategorizationId { get; set; }
        public int PartName { get; set; }
        public int PartType { get; set; }
        public string ItemNumber { get; set; }
        public string BearingType { get; set; }
        public int Error1Id { get; set; }
        public int Error2Id { get; set; }
        public string Comments { get; set; }
        public int DamageDecisionId { get; set; }
    }

    public class DefectCategorizationResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
    }

    public class DADefectCategorization
    {

        public string SMTPHost = System.Configuration.ConfigurationManager.AppSettings["SMTPHost"];
        public string InboxEmail = System.Configuration.ConfigurationManager.AppSettings["InboxEmail"];

        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CIM_MasterDataConn"].ConnectionString;
        }

        public CirDefectCategorization UploadDefectCategotization(CirDefectCategorization dc)
        {

            if (!(dc.componenttype == 2 || dc.componenttype == 4))
            {
                dc.message = "Invalid Component Type";
                dc.filedata = null;
                dc.status = false;
                dc.path = null;
            }
            else
            {

                string filePath = Path.Combine(dc.path, dc.filename);
                try
                {
                    FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
                    int sizeOfChunk = 4;
                    int startPosition = 0;
                    while (startPosition < dc.filedata.Length)
                    {
                        string tmp = dc.filedata.Substring(startPosition, sizeOfChunk);
                        startPosition = startPosition + sizeOfChunk;
                        byte[] tmpArr = Convert.FromBase64String(tmp);
                        fs.Write(tmpArr, 0, tmpArr.Length);
                    }
                    fs.Close();
                    fs.Dispose();

                }
                catch (Exception ex)
                {
                    dc.message = "Error Reading File: " + ex.Message;
                    dc.filedata = null;
                    dc.status = false;
                    dc.path = null;
                    return dc;

                }
                byte[] fileBytes = Convert.FromBase64String(dc.filedata);
                switch (dc.componenttype)
                {
                    case 2:
                        dc = UploadGearboxDefectCategorization(filePath, dc);
                        break;
                    case 4:
                        dc = UploadGeneratorDefectCategorization(filePath, dc);
                        break;

                }
                File.Delete(filePath);

                if (dc.status == true)
                {
                    try
                    {
                        DACirAttachment a = new DACirAttachment();
                        a.SaveAttachment(-1, dc.cirid, dc.filename, dc.initials, DateTime.Now, fileBytes);
                    }
                    catch (SmtpException ex)
                    {
                        ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error Saving as Attachment", LogType.Error, ex.Message.ToString());
                    }
                    try
                    {
                        SendEmailOnSuccessfulUpload(dc.cirid, dc.cirdataid, dc.initials);
                    }
                    catch (SmtpException ex)
                    {
                        ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error Sending Defect categorization Upload Email", LogType.Error, ex.Message.ToString());
                    }
                }
            }
            dc.filedata = null;
            dc.path = null;
            return dc;
        }

        public CirDefectCategorization UploadGeneratorDefectCategorization(string filePath, CirDefectCategorization dc)
        {
            const int generatorDataColumn = 6;
            const int generatorDataRowStart = 8;

            try
            {
                // read excel file
                var workBook = new Workbook();
                workBook.Open(filePath);

                var genInfoSheet = workBook.Worksheets["General Info"];
                if (genInfoSheet == null)
                {
                    dc.message = "Invalid Excel file Generator Template";
                    dc.status = false;
                    return dc;
                }


                // get data from worksheet
                var vendorName = genInfoSheet.Cells[generatorDataRowStart, generatorDataColumn].StringValue;
                var generetorType = genInfoSheet.Cells[generatorDataRowStart + 1, generatorDataColumn].StringValue;
                var kwType = genInfoSheet.Cells[generatorDataRowStart + 2, generatorDataColumn].StringValue;
                var hz = genInfoSheet.Cells[generatorDataRowStart + 3, generatorDataColumn].StringValue;
                var serialNumber = genInfoSheet.Cells[generatorDataRowStart + 4, generatorDataColumn].StringValue;
                var manufacturer = genInfoSheet.Cells[generatorDataRowStart + 5, generatorDataColumn].StringValue;
                //var cirId = genInfoSheet.Cells[generatorDataRowStart + 6, generatorDataColumn].StringValue;
                var inspectionDate = genInfoSheet.Cells[generatorDataRowStart + 7, generatorDataColumn].StringValue;
                var inspectedBy = genInfoSheet.Cells[generatorDataRowStart + 8, generatorDataColumn].StringValue;
                var email = genInfoSheet.Cells[generatorDataRowStart + 9, generatorDataColumn].StringValue;
                var repairManualNumber = genInfoSheet.Cells[generatorDataRowStart + 10, generatorDataColumn].StringValue;
                var jobNumber = genInfoSheet.Cells[generatorDataRowStart + 11, generatorDataColumn].StringValue;
                var windingsType = genInfoSheet.Cells[generatorDataRowStart + 12, generatorDataColumn].StringValue;

                var bearingManufacturerDE = genInfoSheet.Cells[generatorDataRowStart + 17, generatorDataColumn].StringValue;
                var bearingTypeDE = genInfoSheet.Cells[generatorDataRowStart + 18, generatorDataColumn].StringValue;
                var bearingNumberDE = genInfoSheet.Cells[generatorDataRowStart + 19, generatorDataColumn].StringValue;
                var lubricationTypeDE = genInfoSheet.Cells[generatorDataRowStart + 20, generatorDataColumn].StringValue;

                var bearingManufacturerNDE = genInfoSheet.Cells[generatorDataRowStart + 22, generatorDataColumn].StringValue;
                var bearingTypeNDE = genInfoSheet.Cells[generatorDataRowStart + 23, generatorDataColumn].StringValue;
                var bearingNumberNDE = genInfoSheet.Cells[generatorDataRowStart + 24, generatorDataColumn].StringValue;
                var lubricationTypeNDE = genInfoSheet.Cells[generatorDataRowStart + 25, generatorDataColumn].StringValue;

                var reportSummarySheet = workBook.Worksheets["Report Summary"] ?? workBook.Worksheets["Report Sumary"];
                var failuremodes = reportSummarySheet.Cells[3, 8].StringValue;
                var primaryFailure = reportSummarySheet.Cells[4, 8].StringValue;
                var secondaryFailure = reportSummarySheet.Cells[5, 8].StringValue;
                var consequentialDamage = reportSummarySheet.Cells[6, 8].StringValue;
                var otherFindings = reportSummarySheet.Cells[7, 8].StringValue;

                DateTime? inspectionDateNullable = null;
                DateTime inspectionDateTime;
                if (DateTime.TryParse(inspectionDate, out inspectionDateTime))
                    inspectionDateNullable = inspectionDateTime;

                // save to database

                AddGeneratorDefectCategorization(vendorName, generetorType, kwType, hz, serialNumber, manufacturer,
                                                    dc.cirid, inspectionDateNullable, inspectedBy, email, repairManualNumber,
                                                    jobNumber, windingsType, bearingManufacturerDE,
                                                    bearingTypeDE, bearingNumberDE, lubricationTypeDE,
                                                    bearingManufacturerNDE, bearingTypeNDE, bearingNumberNDE,
                                                    lubricationTypeNDE, primaryFailure, secondaryFailure,
                                                    consequentialDamage, otherFindings, failuremodes,
                                                    GetGeneratorDetails(reportSummarySheet)
                                                    );
                dc.message = "Success";
                dc.status = true;
            }
            catch (Exception ex)
            {
                dc.message = "Error in Uploading GeneratorDefectCategorization";
                dc.status = false;
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error in Uploading GeneratorDefectCategorization", LogType.Error, ex.Message.ToString());


            }
            return dc;
        }

        public void AddGeneratorDefectCategorization(string vendorName, string generatorType, string kwType,
                                   string hz, string serialNumber, string manufacturer, long cirId,
                                   DateTime? inspectionDate, string inspectedBy, string email, string repairManualNumber,
                                   string jobNumber, string windingsType, string bearingManufacturerDe,
                                   string bearingTypeDe, string bearingNumberDe, string lubricationTypeDe,
                                   string bearingManufacturerNde, string bearingTypeNde, string bearingNumberNde,
                                   string lubricationTypeNde, string primaryFailure, string secondaryFailure,
                                   string consequentialDamage, string otherFindings, string failuremodes, IEnumerable<GeneratorDetail> details
           )
        {

            using (var daa = new DataAccessAdapter(GetConnectionString(), false))
            {

                var entity = new GeneratorDefectCategorization2Entity
                {
                    VendorName = vendorName,
                    GeneratorType = generatorType,
                    Kwtype = kwType,
                    Hz = hz,
                    SerialNumber = serialNumber,
                    Manufacturer = manufacturer,
                    CirId = cirId,
                    InspectionDate = inspectionDate,
                    InspectedBy = inspectedBy,
                    Email = email,
                    RepairManualNumber = repairManualNumber,
                    JobNumber = jobNumber,
                    WindingsType = windingsType,
                    BearingManufacturerDe = bearingManufacturerDe,
                    BearingTypeDe = bearingTypeDe,
                    BearingNumberDe = bearingNumberDe,
                    LubricationTypeDe = lubricationTypeDe,
                    BearingManufacturerNde = bearingManufacturerNde,
                    BearingTypeNde = bearingTypeNde,
                    BearingNumberNde = bearingNumberNde,
                    LubricationTypeNde = lubricationTypeNde,
                    PrimaryFailure = primaryFailure,
                    SecondaryFailure = secondaryFailure,
                    ConsequentialDamage = consequentialDamage,
                    OtherFindings = otherFindings,
                    FailureModes = failuremodes

                };

                // get list of generator component damage as lookup
                using (var generatorComponentDamage = new EntityCollection<GeneratorComponentDamageEntity>())
                {
                    daa.FetchEntityCollection(generatorComponentDamage, null);
                    var detailEntities = details.Select(dtl =>
                    {
                        // get component damage id
                        var componentDamage = generatorComponentDamage.FirstOrDefault(cd => cd.Component.ToLower() == dtl.Component.ToLower() 
                                                           && cd.FailureDamage.ToLower() == dtl.FailureDamage.ToLower());

                        // cast to details

                        if (componentDamage != null)
                        {
                            //cast to details
                            return new GeneratorDefectCategorization2DetailsEntity
                            {
                                GeneratorComponentDamage = componentDamage.Id,
                                IsDamage = dtl.IsDamaged,
                                Repair = dtl.Repair,
                                FailureMode = dtl.FailureMode
                            };
                        }
                        return null;
                    });

                    if (detailEntities != null && detailEntities.FirstOrDefault<GeneratorDefectCategorization2DetailsEntity>() != null)
                        entity.GeneratorDefectCategorization2Details.AddRange(detailEntities.ToArray());
                }

                // save
                daa.SaveEntity(entity);
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Generator UploadDefectCategorization uploaded successfully", LogType.Information, "");

            }
        }

        public IEnumerable<GeneratorDetail> GetGeneratorDetails(Worksheet worksheet)
        {
            const int colStart = 6;
            const int rowStart = 13;
            const int rowEnd = 33;

            var generatorDetails = new List<GeneratorDetail>();
            for (int i = rowStart; i <= rowEnd; i++)
            {

                string x = worksheet.Cells[i, colStart + 4].StringValue;
                string y = x;
                if (x.Length > 20)
                {
                    y = x.Remove(19);
                }

                generatorDetails.Add(new GeneratorDetail
                {
                    Component = worksheet.Cells[i, colStart].StringValue,
                    FailureDamage = worksheet.Cells[i, colStart + 1].StringValue,
                    IsDamaged = worksheet.Cells[i, colStart + 2].StringValue,
                    Repair = worksheet.Cells[i, colStart + 3].StringValue,
                    FailureMode = y,

                });
            }

            return generatorDetails.AsEnumerable();
        }

        public CirDefectCategorization UploadGearboxDefectCategorization(string filePath, CirDefectCategorization dc)
        {
            const int gearboxDataColumn = 12;
            const int gearboxReasonColumn = 17;
            const int gearboxDataRowStart = 4;
            try
            {
                // read excel file
                var workBook = new Workbook();

                workBook.Open(filePath);

                var genInfoSheet = workBook.Worksheets["General Info"];
                if (genInfoSheet == null)
                {
                    dc.status = false;
                    dc.message = "Invalid Excel file Gearbox Template";
                    return dc;
                }
                // get data from worksheet
                var vendorName = genInfoSheet.Cells[gearboxDataRowStart, gearboxDataColumn].StringValue;
                var gearboxType = genInfoSheet.Cells[gearboxDataRowStart + 1, gearboxDataColumn].StringValue;
                var serialNumber = genInfoSheet.Cells[gearboxDataRowStart + 2, gearboxDataColumn].StringValue;
                var manufacturer = genInfoSheet.Cells[gearboxDataRowStart + 3, gearboxDataColumn].StringValue;
                var ratio = genInfoSheet.Cells[gearboxDataRowStart + 4, gearboxDataColumn].StringValue;
                var oilType = genInfoSheet.Cells[gearboxDataRowStart + 5, gearboxDataColumn].StringValue;
                var frequency = genInfoSheet.Cells[gearboxDataRowStart + 6, gearboxDataColumn].StringValue;
                //var cirId           = genInfoSheet.Cells[gearboxDataRowStart + 7, gearboxDataColumn].StringValue;
                var inspectionDate = genInfoSheet.Cells[gearboxDataRowStart + 8, gearboxDataColumn].StringValue;
                var inspectedBy = genInfoSheet.Cells[gearboxDataRowStart + 9, gearboxDataColumn].StringValue;
                var email = genInfoSheet.Cells[gearboxDataRowStart + 10, gearboxDataColumn].StringValue;
                var repairManualNo = genInfoSheet.Cells[gearboxDataRowStart + 11, gearboxDataColumn].StringValue;
                var jobNo = genInfoSheet.Cells[gearboxDataRowStart + 12, gearboxDataColumn].StringValue;

                var reportSummarySheet = workBook.Worksheets["Report Summary"];
                var primaryFailure = reportSummarySheet.Cells[3, 2].StringValue;
                var secondaryFailure = reportSummarySheet.Cells[4, 2].StringValue;
                var consequentialDamage = reportSummarySheet.Cells[5, 2].StringValue;
                var otherFindings = reportSummarySheet.Cells[6, 2].StringValue;

                // reason for replacement
                var reasonsForReplacement = new List<bool>();
                for (int i = 0; i < 19; i++)
                {
                    reasonsForReplacement.Add(genInfoSheet
                                                .Cells[gearboxDataRowStart + i, gearboxReasonColumn]
                                                .StringValue
                                                .ToLower().Equals("true"));
                }
                var detailsOfDamage = genInfoSheet.Cells[gearboxDataRowStart + 19, gearboxReasonColumn].StringValue;
                var serviceHistory = genInfoSheet.Cells[gearboxDataRowStart, 22].StringValue;

                // convert to date
                //var inspectionDateTime = Convert.ToDateTime(inspectionDate);
                DateTime inspectionDateTime;
                DateTime? inspectionDateTimeNull = null;
                if (DateTime.TryParse(inspectionDate, out inspectionDateTime))
                {
                    inspectionDateTimeNull = inspectionDateTime;
                }

                // get details
                var details = GetGearboxDefectCategorizationDetails(workBook);

                // save to database               
                AddGearboxDefectCategorization(dc.cirid,
                        vendorName,
                        gearboxType,
                        serialNumber,
                        manufacturer,
                        ratio,
                        oilType,
                        frequency,
                        inspectionDateTimeNull,
                        inspectedBy,
                        email,
                        repairManualNo,
                        jobNo,
                        reasonsForReplacement.ToArray(),
                        detailsOfDamage,
                        serviceHistory,
                        primaryFailure,
                        secondaryFailure,
                        consequentialDamage,
                        otherFindings,
                        details
               );
                dc.status = true;
                dc.message = "Success";
            }
            catch (Exception ex)
            {
                dc.status = false;
                dc.message = "Error in Uploading GearboxDefectCategorization";
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error in Uploading GearboxDefectCategorization", LogType.Error, ex.Message.ToString());
            }
            return dc;
        }

        public void AddGearboxDefectCategorization(long cirId, string vendorName, string gearboxType,
                                               string serialNumber, string manufacturer, string ratio,
                                               string oilType, string frequency, DateTime? inspectionDate,
                                               string inspectedBy, string email,
                                               string repairManualNumber, string jobNo,
                                               bool[] reasons,
                                               string detailsOfDamage,
                                               string serviceHistory,
                                               string primaryFailure,
                                               string secondaryFailure,
                                               string consequentialDamage,
                                               string otherFindings,
                                               IEnumerable<GearboxDetail> details)
        {

            using (var daa = new DataAccessAdapter(GetConnectionString(), false))
            {
                // fetch lookups
                var manufacturerEntity = new GearboxManufacturerEntity();
                daa.FetchEntityUsingUniqueConstraint(manufacturerEntity, new PredicateExpression(GearboxManufacturerFields.Name == manufacturer));
                if (manufacturerEntity.GearboxManufacturerId == 0) throw new ApplicationException("Missing Manufacturer!");

                var gearboxTypeEntity = new GearboxTypeEntity();
                daa.FetchEntityUsingUniqueConstraint(gearboxTypeEntity, new PredicateExpression(GearboxTypeFields.Name == gearboxType));
                if (gearboxTypeEntity.GearboxTypeId == 0) throw new ApplicationException("Missing GearBoxType!");

                var oilEntity = new OilTypeEntity();
                daa.FetchEntityUsingUniqueConstraint(oilEntity, new PredicateExpression(OilTypeFields.Name == oilType));
                if (oilEntity.OilTypeId == 0) throw new ApplicationException("Missing OilType!");

                var cirGearboxEntity = new ComponentInspectionReportGearboxEntity();
                daa.FetchEntityUsingUniqueConstraint(cirGearboxEntity, new PredicateExpression(ComponentInspectionReportGearboxFields.ComponentInspectionReportId == cirId));

                // assign value & save                
                var entity = new GearboxDefectCategorizationEntity
                {
                    ComponentInspectionReportGearboxId = cirGearboxEntity.ComponentInspectionReportGearboxId,
                    VendorName = vendorName,
                    GearboxTypeId = gearboxTypeEntity.GearboxTypeId,
                    SerialNumber = serialNumber,
                    GearBoxManufacturerId = manufacturerEntity.GearboxManufacturerId,
                    Ratio = ratio,
                    OilTypeId = oilEntity.OilTypeId,
                    Frequency = frequency,
                    InspectionDate = inspectionDate,
                    InspectedBy = inspectedBy,
                    Email = email,
                    RepairManualNumber = repairManualNumber,
                    JobNumber = jobNo,
                    Noise = reasons[0],
                    MetalOnMagnet = reasons[1],
                    HighTemperature = reasons[2],
                    Leakage = reasons[3],
                    Painting = reasons[4],
                    Others = reasons[5],
                    None = reasons[6],
                    HssBearingDamage = reasons[7],
                    ImsBearingDamage = reasons[8],
                    LssBearingDamage = reasons[9],
                    PlanetBearingDamage = reasons[10],
                    OtherBearingDamage = reasons[11],
                    NoBearingDamage = reasons[12],
                    HssToothDamage = reasons[13],
                    ImsToothDamage = reasons[14],
                    LssToothDamage = reasons[15],
                    PlanetToothDamage = reasons[16],
                    OtherToothDamage = reasons[17],
                    NoToothDamage = reasons[18],
                    DetailsOfDamage = detailsOfDamage,
                    ServiceHistory = serviceHistory,
                    PrimaryFailure = primaryFailure,
                    SecondaryFailure = secondaryFailure,
                    ConsequentialDamage = consequentialDamage,
                    OtherFindings = otherFindings

                };
                // save collection
                if (details != null)
                {
                    var bearingTypes = new EntityCollection<BearingTypeEntity>();
                    daa.FetchEntityCollection(bearingTypes, null);
                    //Added a condition for vestas brand only to remove the duplicates values from dic
                    var bearingTypeDict = bearingTypes.Where(x => x.Brand == "Vestas").ToDictionary(bt => bt.Name, bt => (long?)bt.BearingTypeId);
                    //var bearingTypeDict = bearingTypes.ToDictionary(bt => bt.Name, bt => (long?)bt.BearingTypeId);
                    bearingTypeDict.Add("", null);

                    var detailsCollection = details.Select(gd => new GearboxDefectCategorizationDetailsEntity
                    {
                        PartName = gd.PartName,
                        GearboxPartTypeId = gd.PartType,
                        ItemNumber = gd.ItemNumber,
                        BearingTypeId = gd.PartType == 2 && !string.IsNullOrEmpty(gd.BearingType) ? (bearingTypeDict[gd.BearingType]) : null,
                        Error1Id = gd.Error1Id,
                        Error2Id = gd.Error2Id,
                        Comments = gd.Comments,
                        DamageDecisionId = gd.DamageDecisionId
                    }).ToList();
                    entity.GearboxDefectCategorizationDetails.AddRange(detailsCollection);
                }

                // save data
                daa.SaveEntity(entity);
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Gearbox UploadDefectCategorization uploaded successfully", LogType.Information, "");

            }
        }


        private IEnumerable<GearboxDetail> GetGearboxDefectCategorizationDetails(Workbook workBook)
        {
            var sheet = workBook.Worksheets["Report Summary"];

            var detailList = new List<GearboxDetail>();

            // get dictionary list of PartName, Error and Damage
            IDictionary<string, long> gearTypeDict,
                                      bearingTypeDict,
                                      shaftTypeDict;
            IDictionary<string, int> gearErrorDict,
                                      bearingErrorDict,
                                      shaftErrorDict,
                                      damageDecision;

            LoadGearboxDictionaries(out gearTypeDict, out bearingTypeDict, out shaftTypeDict,
                                    out gearErrorDict, out bearingErrorDict, out shaftErrorDict, out damageDecision);


            // Get Details and accumulate in detailList
            GetGearboxDetailRow(sheet, 11, 1, 1, gearTypeDict, gearErrorDict, detailList, damageDecision);
            GetGearboxDetailRow(sheet, 11, 10, 2, bearingTypeDict, bearingErrorDict, detailList, damageDecision);
            GetGearboxDetailRow(sheet, 11, 20, 3, shaftTypeDict, shaftErrorDict, detailList, damageDecision);

            return detailList;
        }

        public void LoadGearboxDictionaries(out IDictionary<string, long> gearTypeDict,
                                         out IDictionary<string, long> bearingTypeDict,
                                         out IDictionary<string, long> shaftTypeDict,
                                         out IDictionary<string, int> gearErrorDict,
                                         out IDictionary<string, int> bearingErrorDict,
                                         out IDictionary<string, int> shaftErrorDict,
                                         out IDictionary<string, int> damageDecisionDict)
        {
            using (var daa = new DataAccessAdapter(GetConnectionString(), false))
            {
                // gear type
                var gearTypes = new EntityCollection<GearTypeEntity>();
                daa.FetchEntityCollection(gearTypes, null);
                gearTypeDict = gearTypes.ToDictionary(gt => gt.Name, gt => gt.GearTypeId);

                // bearing type
                var bearingTypes = new EntityCollection<BearingTypeEntity>();
                daa.FetchEntityCollection(bearingTypes, null);
                //Added a condition for vestas brand only to remove the duplicates values from dic
                bearingTypeDict = bearingTypes.Where(x => x.Brand == "Vestas").ToDictionary(c => c.Name, c => c.BearingTypeId);

                //bearingTypeDict = bearingTypes.ToDictionary(gt => gt.Name, gt => gt.BearingTypeId);

                // shaft type
                var shaftTypes = new EntityCollection<ShaftTypeEntity>();
                daa.FetchEntityCollection(shaftTypes, null);
                shaftTypeDict = shaftTypes.ToDictionary(gt => gt.Name, gt => gt.ShaftTypeId);

                // gear error
                var gearError = new EntityCollection<GearErrorVendorEntity>();
                daa.FetchEntityCollection(gearError, null);
                gearErrorDict = gearError.ToDictionary(gt => gt.Name, gt => gt.GearErrorVendorId);

                // bearing error
                var bearingError = new EntityCollection<BearingErrorVendorEntity>();
                daa.FetchEntityCollection(bearingError, null);
                bearingErrorDict = bearingError.ToDictionary(gt => gt.Name, gt => gt.BearingErrorVendorId);

                // shaft error
                var shaftError = new EntityCollection<ShaftErrorVendorEntity>();
                daa.FetchEntityCollection(shaftError, null);
                shaftErrorDict = shaftError.ToDictionary(gt => gt.Name, gt => gt.ShaftErrorVendorId);

                // damage decision
                var damageDecision = new EntityCollection<DamageDecisionEntity>();
                daa.FetchEntityCollection(damageDecision, null);
                damageDecisionDict = damageDecision.ToDictionary(gt => gt.Name, gt => (int)gt.DamageDecisionId);
            }

        }

        private static void GetGearboxDetailRow(Worksheet sheet, int row, int col, int partType,
                                        IDictionary<string, long> partTypeDict,
                                        IDictionary<string, int> partErrorDict,
                                        ICollection<GearboxDetail> detailList,
                                        IDictionary<string, int> damageDecisionDict)
        {
            var partNameCell = sheet.Cells[row, col].StringValue;
            int failureCol = 0;
            switch (partType)
            {
                case 1:
                    failureCol = 2;
                    break;
                case 2:
                    failureCol = 3;
                    break;
                case 3:
                    failureCol = 1;
                    break;

            }


            // check is entry for partname still exist, exit if none
            while (!string.IsNullOrEmpty(partNameCell))
            {
                // check if part name is in dictionary
                if (partTypeDict.Keys.Contains(partNameCell))
                {
                    var cells = sheet.Cells;
                    var detail = new GearboxDetail { PartName = (int)partTypeDict[partNameCell], PartType = partType };
                    detail.Comments = cells[row, col + failureCol + 2].StringValue;

                    // item number exists in PartType 1 & 2 only
                    detail.ItemNumber = partType == 3 ? "" : cells[row, col + 1].StringValue;

                    // BearingType exists in PartType 2 only
                    detail.BearingType = null;
                    if (partType != 2 && string.IsNullOrEmpty(cells[row, col + 2].StringValue))
                    {
                        detail.BearingType = cells[row, col + 2].StringValue;
                    }

                    // nullable fields
                    var error1 = cells[row, col + failureCol].StringValue;
                    var error2 = cells[row, col + failureCol + 1].StringValue;
                    var damageDecision = cells[row, col + failureCol + 3].StringValue;

                    int output;
                    if (partErrorDict.TryGetValue(error1, out output))
                        detail.Error1Id = output;
                    if (partErrorDict.TryGetValue(error2, out output))
                        detail.Error2Id = output;
                    if (damageDecisionDict.TryGetValue(damageDecision, out output))
                        detail.DamageDecisionId = output;

                    detailList.Add(detail);
                }

                // next row
                row++;
                partNameCell = sheet.Cells[row, col].StringValue;
            }
        }


        public void SendEmailOnSuccessfulUpload(long cirId, long cirDataId, string initials)
        {
            try
            {

                var to = initials + "@vestas.com";
                var approver = GetApprover(cirDataId);
                if (!String.IsNullOrEmpty(approver) && approver != initials)
                {
                    approver = approver + "@vestas.com";
                    to += "," + approver;
                }

                const string subject = "Final damage classification and disassembly report";
                var body = "<html><body><h4>Letter of notification</h4>"
                            + "<p>This is a notification to confirm  the upload of the final damage classification and disassembly report to CIR No " + cirId + "</a></p>"
                            + "<p>Vestas has received information from the repair provider after the disassembly and the container has been reviewed and approved by Vestas. The results/findings from the final damage classification, together with disassembly report has been uploaded to the CIR database and are available by opening the information section of the original CIR number.</p>"
                            + "<p>Please check and compare the final disassembly informations with the original internal CIR.</p></body></html>";

                MailMessage mm = new MailMessage();
                mm.From = new MailAddress(InboxEmail);
                mm.To.Add(new MailAddress(to));
                mm.Body = body;
                mm.IsBodyHtml = true;
                mm.Subject = subject;
                mm.Headers.Add("Message-ID", Guid.NewGuid().ToString());
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.None;



                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                // UseDefaultCredentials tells the mail client to use the 
                // Windows credentials of the account (i.e. user account) 
                // being used to run the application
                smtp.UseDefaultCredentials = true;
                smtp.Host = SMTPHost;
                //Send mail
                smtp.Send(mm);
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Upload DefectCategorization Notification send", LogType.Information, "");

            }
            catch (SmtpException ex)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error sending Upload DefectCategorization Notification", LogType.Error, ex.Message.ToString());


            }
            catch (Exception ex)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error sending Upload DefectCategorization Notification", LogType.Error, ex.Message.ToString());


            }
        }

        public string GetApprover(long cirDataId)
        {
            List<DataContracts.CirLogs> logs = DACIRLog.GetCirLog(cirDataId);

            var log = logs.FirstOrDefault(l => l.Text.Contains("Approval Process Completed"));
            if (log != null)
            {
                return log.Initials;
            }

            return string.Empty;
        }


    }
}