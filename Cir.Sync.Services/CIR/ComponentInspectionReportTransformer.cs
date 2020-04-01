using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.CIR
{
    public class ComponentInspectionReportTransformer
    { 
        public long ComponentInspectionReportTransformerId
        {
            get;
            set;
        }
        public long ComponentInspectionReportId
        {
            get;
            set;
        }
        public string VestasUniqueIdentifier
        {
            get;
            set;
        }
        public long TransformerManufacturerId
        {
            get;
            set;
        }
        public string TransformerSerialNumber
        {
            get;
            set;
        }
        public decimal? MaxTemp
        {
            get;
            set;
        }
        public DateTime MaxTempResetDate
        {
            get;
            set;
        }
        public string strMaxTempResetDate
        {
            get;
            set;
        }
        public long ActionOnTransformerId
        {
            get;
            set;
        }
        public long HVCoilConditionId
        {
            get;
            set;
        }
        public long LVCoilConditionId
        {
            get;
            set;
        }
        public long HVCableConditionId
        {
            get;
            set;
        }
        public long LVCableConditionId
        {
            get;
            set;
        }
        public long BracketsId
        {
            get;
            set;
        }
        public long TransformerArcDetectionId
        {
            get;
            set;
        }
        public long ClimateId
        {
            get;
            set;
        }
        public long SurgeArrestorId
        {
            get;
            set;
        }
        public long ConnectionBarsId
        {
            get;
            set;
        }
        public string Comments
        {
            get;
            set;
        }
        public long? TransformerClaimRelevantBooleanAnswerId
        {
            get;
            set;
        }
       
    }
}