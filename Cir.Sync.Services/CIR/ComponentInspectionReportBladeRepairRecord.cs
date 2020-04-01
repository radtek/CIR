using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.CIR
{
    public class ComponentInspectionReportBladeRepairRecord
    {
        public long ComponentInspectionReportBladeRepairRecordId
        {
            get;
            set;
        }
        public long ComponentInspectionReportBladeId
        {
            get;
            set;
        }
        public decimal BladeAmbientTemp
        {
            get;
            set;
        }
        public decimal BladeHumidity
        {
            get;
            set;
        }
        public string BladeAdditionalDocumentReference
        {
            get;
            set;
        }
        public string BladeResinType
        {
            get;
            set;
        }
        public string BladeResinTypeBatchNumbers
        {
            get;
            set;
        }
        public DateTime? BladeResinTypeExpiryDate
        {
            get;
            set;
        }
        public string strBladeResinTypeExpiryDate
        {
            get;
            set;
        }

        public string BladeHardenerType
        {
            get;
            set;
        }
        public string BladeHardenerTypeBatchNumbers
        {
            get;
            set;
        }
        public DateTime? BladeHardenerTypeExpiryDate
        {
            get;
            set;
        }
        public string strBladeHardenerTypeExpiryDate
        {
            get;
            set;
        }
        public string BladeGlassSupplier
        {
            get;
            set;
        }
        public string BladeGlassSupplierBatchNumbers
        {
            get;
            set;
        }
        public decimal BladeSurfaceMaxTemperature
        {
            get;
            set;
        }
        public decimal BladeSurfaceMinTemperature
        {
            get;
            set;
        }
        public long BladeResinUsed
        {
            get;
            set;
        }
        public decimal BladePostCureMaxTemperature
        {
            get;
            set;
        }
        public decimal BladePostCureMinTemperature
        {
            get;
            set;
        }
        public DateTime? BladeTurnOffTime
        {
            get;
            set;
        }
        public string strBladeTurnOffTime
        {
            get;
            set;
        }
        public long BladeTotalCureTime
        {
            get;
            set;
        }
    }
}