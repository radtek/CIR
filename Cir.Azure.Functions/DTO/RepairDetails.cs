using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class RepairDetailsDto
    {
        [JsonProperty(PropertyName = "repair")]
        public RepairDetails Repair { get; set; }
    }

    class RepairDetails
    {
        [JsonProperty(PropertyName = "turbineId")]
        public string TurbineId { get; set; }
        [JsonProperty(PropertyName = "bladeId")]
        public string BladeId { get; set; }
        [JsonProperty(PropertyName = "damageId")]
        public string DamageId { get; set; }
        [JsonProperty(PropertyName = "damageGuid")]
        public string DamageGuid { get; set; }
        [JsonProperty(PropertyName = "repairId")]
        public string RepairId { get; set; }
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }
        [JsonProperty(PropertyName = "steps")]
        public List<IRepairStep> Steps { get; set; }
    }

    interface IRepairStep
    {
        string Type { get; set; }
    }

    class LaminationRepairStep : IRepairStep
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("minPostcureSurfaceTemperature")]
        public int MinPostcureSurfaceTemperature { get; set; }
        [JsonProperty("maxPostcureSurfaceTemperature")]
        public int MaxPostcureSurfaceTemperature { get; set; }
        [JsonProperty("heatersInsulationCoverAndVacuumOff")]
        public DateTime HeatersInsulationCoverAndVacuumOff { get; set; }
        [JsonProperty("totalCureTime")]
        public string TotalCureTime { get; set; }
        [JsonProperty("laminatType")]
        public string LaminatType { get; set; }
        [JsonProperty("images")]
        public List<string> Images { get; set; }
    }


    //--------------------------
    class PreRepairAssessment : IRepairStep
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("radialLocation")]
        public string RadialLocation { get; set; }
        [JsonProperty("cwLength")]
        public decimal CWLength { get; set; }
        [JsonProperty("swLength")]
        public decimal SWLength { get; set; }
        [JsonProperty("depth")]
        public decimal Depth { get; set; }
        [JsonProperty("recommendedActivity")]
        public string recommendedActivity { get; set; } // "Repair Uptower / Downtower"
    }

    class PaintOrGelCoatRemoval : IRepairStep
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("maxCWRemoval")]
        public decimal MaxCWRwmoval { get; set; }
        [JsonProperty("maxSWRemoval")]
        public decimal MaxSWRemoval { get; set; }
    }

    class LaminateLayerRemoval : IRepairStep
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("maxCWRemoval")]
        public decimal MaxCWRwmoval { get; set; }
        [JsonProperty("maxSWRemoval")]
        public decimal MaxSWRemoval { get; set; }
    }

    class CoreMaterialRemoval : IRepairStep
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("maxCWRemoval")]
        public decimal MaxCWRwmoval { get; set; }
        [JsonProperty("maxSWRemoval")]
        public decimal MaxSWRemoval { get; set; }
        [JsonProperty("coreThickness")]
        public decimal CoreThickness { get; set; }
    }

    class GlassLamination : IRepairStep
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("ambTemp")]
        public decimal AmbTemp { get; set; }
        [JsonProperty("relTemp")]
        public decimal RelTemp { get; set; }
        [JsonProperty("relHumidity")]
        public decimal RelHumidity { get; set; }
        [JsonProperty("maxCW")]
        public decimal MaxCW { get; set; }
        [JsonProperty("maxSW")]
        public decimal MaxSW { get; set; }
        [JsonProperty("cureTime")]
        public decimal CureTime { get; set; }
        [JsonProperty("cureTempStart")]
        public decimal CureTempStart { get; set; }
        [JsonProperty("cureTempMid")]
        public decimal CureTempMid { get; set; }
        [JsonProperty("cureTempEnd")]
        public decimal CureTempEnd { get; set; }
        [JsonProperty("resinType")]
        public string ResinType { get; set; }
        [JsonProperty("resinBatchNumber")]
        public string ResinBatchNumber { get; set; }
        [JsonProperty("resinExpiration")]
        public DateTime ResinExpiration { get; set; }
        [JsonProperty("hardenerType")]
        public string HardenerType { get; set; }
        [JsonProperty("hardenerBatchNumber")]
        public string HardenerBatchNumber { get; set; }
        [JsonProperty("hardenerExpiration")]
        public DateTime HardenerExpiration { get; set; }
        [JsonProperty("glassSupplier")]
        public string GlassSupplier { get; set; }
        [JsonProperty("glassBatchNumber")]
        public string GlassBatchNumber { get; set; }
        [JsonProperty("numberOfLayers")]
        public int NumberOfLayers { get; set; }
        [JsonProperty("descriptionOfLayers")]
        public string DescriptionOfLaysers { get; set; }
    }

    class CoreReplacement : IRepairStep
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("ambTemp")]
        public decimal AmbTemp { get; set; }
        [JsonProperty("relTemp")]
        public decimal RelTemp { get; set; }
        [JsonProperty("relHumidity")]
        public decimal RelHumidity{ get; set; }
        [JsonProperty("maxCW")]
        public decimal MaxCW { get; set; }
        [JsonProperty("maxSW")]
        public decimal MaxSw { get; set; }
        [JsonProperty("cureTime")]
        public decimal CureTime { get; set; }
        [JsonProperty("cureTempStart")]
        public decimal CureTempStart { get; set; }
        [JsonProperty("cureTempMid")]
        public decimal CureTempMid { get; set; }
        [JsonProperty("cureTempEnd")]
        public decimal CureTempEnd { get; set; }
        [JsonProperty("resinType")]
        public string ResinType { get; set; }
        [JsonProperty("resinBatchNumber")]
        public string ResinBatchNumber { get; set; }
        [JsonProperty("resinExpiration")]
        public DateTime ResinExpiration { get; set; }
        [JsonProperty("hardenerType")]
        public string HardenerType { get; set; }
        [JsonProperty("hardenerBatchNumber")]
        public string HardenerBatchNumber { get; set; }
        [JsonProperty("hardenerExpiration")]
        public DateTime HardenerExpiration { get; set; }
        [JsonProperty("maxCoreThickness")]
        public decimal MaxCoreThickness { get; set; }
    }

    class GlassAndCoreLamination: IRepairStep
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("ambTemp")]
        public decimal AmbTemp { get; set; }
        [JsonProperty("relTemp")]
        public decimal RelTemp { get; set; }
        [JsonProperty("relHumidity")]
        public decimal RelHumidity { get; set; }
        [JsonProperty("cureTime")]
        public decimal CureTime { get; set; }
        [JsonProperty("cureTempStart")]
        public decimal CureTempStart { get; set; }
        [JsonProperty("cureTempMid")]
        public decimal CureTempMid { get; set; }
        [JsonProperty("cureTempEnd")]
        public decimal CureTempEnd { get; set; }
        [JsonProperty("resinType")]
        public string ResinType { get; set; }
        [JsonProperty("resinBatchNumber")]
        public string ResinBatchNumber { get; set; }
        [JsonProperty("resinExpiration")]
        public DateTime ResinExpiration { get; set; }
        [JsonProperty("hardenerType")]
        public string HardenerType { get; set; }
        [JsonProperty("hardenerBatchNumber")]
        public string HardenerBatchNumber { get; set; }
        [JsonProperty("hardenerExpiration")]
        public DateTime HardenerExpiration { get; set; }
        [JsonProperty("glassSupplier")]
        public string GlassSupplier { get; set; }
        [JsonProperty("glassBatchNumber")]
        public string GlassBatchNumber { get; set; }
        [JsonProperty("numberOfLayers")]
        public int NumberOfLayers { get; set; }
        [JsonProperty("coreCW")]
        public decimal CoreCW { get; set; }
        [JsonProperty("coreSW")]
        public decimal CoreSW { get; set; }
        [JsonProperty("glassCW")]
        public decimal GlassCW { get; set; }
        [JsonProperty("glassSW")]
        public decimal GlassSW { get; set; }
        [JsonProperty("maxCoreThickness")]
        public decimal MaxCoreThickness { get; set; }
    }

    class CarbonReplacement: IRepairStep
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("ambTemp")]
        public decimal AmbTemp { get; set; }
        [JsonProperty("relTemp")]
        public decimal RelTemp { get; set; }
        [JsonProperty("relHumidity")]
        public decimal RelHumidity { get; set; }
        [JsonProperty("cw")]
        public decimal CW { get; set; }
        [JsonProperty("sw")]
        public decimal SW { get; set; }
        [JsonProperty("depth")]
        public decimal Depth { get; set; }
        [JsonProperty("pliesOfCarbon")]
        public int PliesOfCarbon{ get; set; }
        [JsonProperty("cureTime")]
        public decimal CureTime { get; set; }
        [JsonProperty("cureTempStart")]
        public decimal CureTempStart { get; set; }
        [JsonProperty("cureTempMid")]
        public decimal CureTempMid { get; set; }
        [JsonProperty("cureTempEnd")]
        public decimal CureTempEnd { get; set; }
    }

    class LaminateCure: IRepairStep
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("ambTemp")]
        public decimal AmbTemp { get; set; }
        [JsonProperty("relTemp")]
        public decimal RelTemp { get; set; }
        [JsonProperty("relHumidity")]
        public decimal RelHumidity { get; set; }
        [JsonProperty("resinUsed")]
        public string ResinUsed { get; set; }
        [JsonProperty("laminateUsed")]
        public string LaminateUsed { get; set; }
        [JsonProperty("qtyOfResinUsed")]
        public decimal QtyOfResinUsed { get; set; }
        [JsonProperty("vacuum")]
        public decimal Vacuum { get; set; }
        [JsonProperty("surfaceTemp")]
        public decimal SurfaceTemp { get; set; }
        [JsonProperty("cureTemp")]
        public decimal CureTemp { get; set; }
        [JsonProperty("cureTime")]
        public decimal CureTime { get; set; }
    }

    class AdhesiveCure: IRepairStep
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("ambTemp")]
        public decimal AmbTemp { get; set; }
        [JsonProperty("relTemp")]
        public decimal RelTemp { get; set; }
        [JsonProperty("relHumidity")]
        public decimal RelHumidity { get; set; }
        [JsonProperty("adhesiveUsed")]
        public string AdhesiveUsed { get; set; }
        [JsonProperty("adhesiveBatch")]
        public string AdhesiveBatch { get; set; }
        [JsonProperty("adhesiveExpiration")]
        public DateTime AdhesiveExpiration{ get; set; }
        [JsonProperty("qtyOfAdhesiveUsed")]
        public decimal QtyOfAdhesiveUsed{ get; set; }
        [JsonProperty("surfaceTemp")]
        public decimal SurfaceTemp { get; set; }
        [JsonProperty("cureTemp")]
        public decimal CureTemp { get; set; }
        [JsonProperty("cureTime")]
        public decimal CureTime { get; set; }
    }

    class LPSTest: IRepairStep
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("calibrationDate")]
        public DateTime CalibrationDate { get; set; }
        [JsonProperty("lw1")]
        public string LW1 { get; set; }
        [JsonProperty("lw2")]
        public string LW2 { get; set; }
        [JsonProperty("lw3")]
        public string LW3 { get; set; }
        [JsonProperty("lw4")]
        public string LW4 { get; set; }
        [JsonProperty("lw5")]
        public string LW5 { get; set; }
        [JsonProperty("lw6")]
        public string LW6 { get; set; }
        [JsonProperty("lw7")]
        public string LW7 { get; set; }
        [JsonProperty("lw8")]
        public string LW8 { get; set; }
        [JsonProperty("ww1")]
        public string WW1 { get; set; }
        [JsonProperty("ww2")]
        public string WW2 { get; set; }
        [JsonProperty("ww3")]
        public string WW3 { get; set; }
        [JsonProperty("ww4")]
        public string WW4 { get; set; }
        [JsonProperty("ww5")]
        public string WW5 { get; set; }
        [JsonProperty("ww6")]
        public string WW6 { get; set; }
        [JsonProperty("ww7")]
        public string WW7 { get; set; }
        [JsonProperty("ww8")]
        public string WW8 { get; set; }
        [JsonProperty("tip")]
        public string Tip { get; set; }
    }

    class EdgeSealerApplication: IRepairStep
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("ambTemp")]
        public decimal AmbTemp { get; set; }
        [JsonProperty("relTemp")]
        public decimal RelTemp { get; set; }
        [JsonProperty("relHumidity")]
        public decimal RelHumidity { get; set; }
        [JsonProperty("edgeSystemUsed")]
        public string EdgeSystemUsed { get; set; }
        [JsonProperty("batchNumber")]
        public string BatchNumber { get; set; }
        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }
        [JsonProperty("surfaceTemp")]
        public decimal SurfaceTemp { get; set; }
        [JsonProperty("cureTemp")]
        public decimal CureTemp { get; set; }
        [JsonProperty("cureTime")]
        public decimal CureTime { get; set; }
    }

    class FillerApplication: IRepairStep
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("ambTemp")]
        public decimal AmbTemp { get; set; }
        [JsonProperty("relTemp")]
        public decimal RelTemp { get; set; }
        [JsonProperty("relHumidity")]
        public decimal RelHumidity { get; set; }
        [JsonProperty("fillingSystemUsed")]
        public string FillingSystemUsed{ get; set; }
        [JsonProperty("batchNumber")]
        public string BatchNumber { get; set; }
        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }
        [JsonProperty("surfaceTemp")]
        public decimal SurfaceTemp { get; set; }
        [JsonProperty("cureTemp")]
        public decimal CureTemp { get; set; }
        [JsonProperty("cureTime")]
        public decimal CureTime { get; set; }
        [JsonProperty("maxThickness")]
        public decimal MaxThickness { get; set; }
    }

    class PaintApplication: IRepairStep
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("ambTemp")]
        public decimal AmbTemp { get; set; }
        [JsonProperty("relTemp")]
        public decimal RelTemp { get; set; }
        [JsonProperty("relHumidity")]
        public decimal RelHumidity { get; set; }
        [JsonProperty("paintSystemUsed")]
        public string PaintSystemUsed { get; set; }
        [JsonProperty("batchNumber")]
        public string BatchNumber { get; set; }
        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }
        [JsonProperty("surfaceTemp")]
        public decimal SurfaceTemp { get; set; }
        [JsonProperty("cureTemp")]
        public decimal CureTemp { get; set; }
        [JsonProperty("cureTime")]
        public decimal CureTime { get; set; }
    }

    class SPLReplacementAndInfusion: IRepairStep
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("ambTemp")]
        public decimal AmbTemp { get; set; }
        [JsonProperty("relTemp")]
        public decimal RelTemp { get; set; }
        [JsonProperty("relHumidity")]
        public decimal RelHumidity { get; set; }
        [JsonProperty("splReplacementCW")]
        public decimal SPLReplacementCW { get; set; }
        [JsonProperty("splReplacementSW")]
        public decimal SPLReplacementSW { get; set; }
        [JsonProperty("dropTestValue")]
        public decimal DropTestValue { get; set; }
        [JsonProperty("vaccum")]
        public decimal Vaccum { get; set; }
        [JsonProperty("resinType")]
        public string ResinType { get; set; }
        [JsonProperty("resinBatchNumber")]
        public string ResinBatchNumber { get; set; }
        [JsonProperty("resinExpiration")]
        public DateTime ResinExpiration { get; set; }
        [JsonProperty("hardenerType")]
        public string HardenerType { get; set; }
        [JsonProperty("hardenerBatchNumber")]
        public string HardenerBatchNumber { get; set; }
        [JsonProperty("hardenerExpiration")]
        public DateTime HardenerExpiration { get; set; }
        [JsonProperty("cureTime")]
        public decimal CureTime { get; set; }
        [JsonProperty("cureTempStart")]
        public decimal CureTempStart { get; set; }
        [JsonProperty("cureTempMid")]
        public decimal CureTempMid { get; set; }
        [JsonProperty("cureTempEnd")]
        public decimal CureTempEnd { get; set; }
    }

    class LEPInstallLEP9: IRepairStep
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("ambTemp")]
        public decimal AmbTemp { get; set; }
        [JsonProperty("relTemp")]
        public decimal RelTemp { get; set; }
        [JsonProperty("relHumidity")]
        public decimal RelHumidity { get; set; }
        [JsonProperty("lep9")]
        public string LEP9 { get; set; }
        [JsonProperty("redBaseBatchNumber")]
        public string RedBaseBatchNumber { get; set; }
        [JsonProperty("redBaseExpirationNumber")]
        public DateTime RedBaseExpiration { get; set; }
        [JsonProperty("whiteBaseBatchNumber")]
        public string WhiteBaseBatchNumber { get; set; }
        [JsonProperty("whiteBaseExpirationNumber")]
        public DateTime WhiteBaseExpiration { get; set; }
        [JsonProperty("grayBaseBatchNumber")]
        public string GrayBaseBatchNumber { get; set; }
        [JsonProperty("grayBaseExpirationNumber")]
        public DateTime GrayBaseExpiration { get; set; }
        [JsonProperty("hardenerBatchNumber")]
        public string HardenerBatchNumber { get; set; }
        [JsonProperty("hardenerExpirationNumber")]
        public DateTime HardenerExpiration { get; set; }
    }

    class LEPInstallLEPTape: IRepairStep
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("ambTemp")]
        public decimal AmbTemp { get; set; }
        [JsonProperty("relTemp")]
        public decimal RelTemp { get; set; }
        [JsonProperty("relHumidity")]
        public decimal RelHumidity { get; set; }
        [JsonProperty("maxTapeWidth")]
        public decimal MaxTapeWidth { get; set; }
        [JsonProperty("minTapeWidth")]
        public decimal MinTapeWidth { get; set; }
        [JsonProperty("lengthOfInstall")]
        public decimal LengthOfInstall { get; set; }
    }
}
