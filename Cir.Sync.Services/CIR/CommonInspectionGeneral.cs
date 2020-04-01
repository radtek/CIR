using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.CIR
{
    public class CommonInspectionGeneral
    {

         public long ComponentInspectionReportGeneralId	{get;set;}
         public long ComponentInspectionReportId	{get;set;}
         public long? GeneralComponentGroupId	{get;set;}
         public string GeneralComponentType	{get;set;}
         public string  VestasUniqueIdentifier	{get;set;}
         public string  GeneralComponentManufacturer {get;set;}
         public string  GeneralOtherGearboxType	{get;set;}
         public long? GeneralClaimRelevantBooleanAnswerId	{get;set;}
         public string GeneralOtherGearboxManufacturer	{get;set;}
         public string GeneralComponentSerialNumber	{get;set;}
         public long? GeneralGeneratorManufacturerId	{get;set;}
         public long? GeneralTransformerManufacturerId	{get;set;}
         public long? GeneralGearboxManufacturerId	{get;set;}
         public long? GeneralTowerTypeId	{get;set;}
         public long? GeneralTowerHeightId	{get;set;}
         public string GeneralBlade1SerialNumber	{get;set;}
         public string  GeneralBlade2SerialNumber	{get;set;}
         public string GeneralBlade3SerialNumber	{get;set;}
         public long? GeneralControllerTypeId	{get;set;}
         public string GeneralSoftwareRelease	{get;set;}
         public long? GeneralRamDumpNumber	{get;set;}
         public long? GeneralVDFTrackNumber	{get;set;}
         public long GeneralPicturesIncludedBooleanAnswerId	{get;set;}
         public string GeneralInitiatedBy1	{get;set;}
         public string GeneralInitiatedBy2	{get;set;}
         public string GeneralInitiatedBy3	{get;set;}
         public string GeneralInitiatedBy4	{get;set;}
         public string GeneralMeasurementsConducted1	{get;set;}
         public string GeneralMeasurementsConducted2	{get;set;}
         public string GeneralMeasurementsConducted3	{get;set;}
         public string GeneralMeasurementsConducted4	{get;set;}
         public string GeneralExecutedBy1	{get;set;}
         public string GeneralExecutedBy2	{get;set;}
         public string GeneralExecutedBy3	{get;set;}
         public string GeneralExecutedBy4	{get;set;}
         public string GeneralPositionOfFailedItem { get; set; }
    }
}