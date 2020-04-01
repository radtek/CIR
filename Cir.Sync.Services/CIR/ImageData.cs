using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.CIR
{
    public class DyanamicDecision
    {
        public int DecisionId { get; set; }
        public int Decision { get; set; }
        public string ImidiateActions { get; set; }
        public int RepeatedInspections { get; set; }
        public int AffectedBolts { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public long CirId { get; set; }
        public Nullable<int> FlangNo { get; set; }
        public bool FlangeDamageIdentified { get; set; }
        public string InspectionDesc { get; set; }
    }
    public class ImageData
    {
        public int ImageId { get; set; }
        public string ImageDataString { get; set; }
        public string ImageDescription { get; set; }
        public int ImageOrder { get; set; }
        public string InspectionDesc { get; set; }
        public bool IsPlateType { get; set; }
        public string ImageUrl { get; set; }
        public int FlangNo { get; set; }
        public string FormIOImageGUID { get; set; }
        public bool IsNewImageControl { get; set; }
    }
    public class ImageDataInfo
    {
        public bool IsPlateTypeNotPossible { get; set; }
        public string PlateTypeNotPossibleReason { get; set; }
    }
}