using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.CIR
{
    public class ComponentInspectionReportBlade
    {
        public long ComponentInspectionReportBladeId
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
        public long BladeLengthId
        {
            get;
            set;
        }
        public long BladeColorId
        {
            get;
            set;
        }
        public long? BladeManufacturerId
        {
            get;
            set;
        }
        public string BladeSerialNumber
        {
            get;
            set;
        }
        public long BladePicturesIncludedBooleanAnswerId
        {
            get;
            set;
        }
        public string BladeOtherSerialNumber1
        {
            get;
            set;
        }
        public string BladeOtherSerialNumber2
        {
            get;
            set;
        }
        public bool BladeDamageIdentified
        {
            get;
            set;
        }
        public long? BladeFaultCodeClassificationId
        {
            get;
            set;
        }
        public long? BladeFaultCodeCauseId
        {
            get;
            set;
        }
        public long? BladeFaultCodeTypeId
        {
            get;
            set;
        }
        public long? BladeFaultCodeAreaId
        {
            get;
            set;
        }
        public long? BladeClaimRelevantBooleanAnswerId
        {
            get;
            set;
        }
        public string BladeLsVtNumber
        {
            get;
            set;
        }
        public DateTime BladeLsCalibrationDate
        {
            get;
            set;
        }
        public string strBladeLsCalibrationDate
        {
            get;
            set;
        }
        public long? BladeLsLeewardSidePreRepairTip
        {
            get;
            set;
        }
        public long? BladeLsLeewardSidePostRepairTip
        {
            get;
            set;
        }

        public long? BladeLsLeewardSidePreRepair2
        {
            get;
            set;
        }

        public long? BladeLsLeewardSidePostRepair2
        {
            get;
            set;
        }

        public long? BladeLsLeewardSidePreRepair3
        {
            get;
            set;
        }
        public long? BladeLsLeewardSidePostRepair3
        {
            get;
            set;
        }
        public long? BladeLsLeewardSidePreRepair4
        {
            get;
            set;
        }
        public long? BladeLsLeewardSidePostRepair4
        {
            get;
            set;
        }
        public long? BladeLsLeewardSidePreRepair5
        {
            get;
            set;
        }
        public long? BladeLsLeewardSidePostRepair5
        {
            get;
            set;
        }
        public long? BladeLsLeewardSidePreRepair6
        {
            get;
            set;
        }
        public long? BladeLsLeewardSidePostRepair6
        {
            get;
            set;
        }
        public long? BladeLsLeewardSidePreRepair7
        {
            get;
            set;
        }
        public long? BladeLsLeewardSidePostRepair7
        {
            get;
            set;
        }
        public long? BladeLsLeewardSidePreRepair8
        {
            get;
            set;
        }
        public long? BladeLsLeewardSidePostRepair8
        {
            get;
            set;
        }
        public long? BladeLsWindwardSidePreRepairTip
        {
            get;
            set;
        }
        public long? BladeLsWindwardSidePostRepairTip
        {
            get;
            set;
        }
        public long? BladeLsWindwardSidePreRepair2
        {
            get;
            set;
        }
        public long? BladeLsWindwardSidePostRepair2
        {
            get;
            set;
        }
        public long? BladeLsWindwardSidePreRepair3
        {
            get;
            set;
        }
        public long? BladeLsWindwardSidePostRepair3
        {
            get;
            set;
        }
        public long? BladeLsWindwardSidePreRepair4
        {
            get;
            set;
        }
        public long? BladeLsWindwardSidePostRepair4
        {
            get;
            set;
        }
        public long? BladeLsWindwardSidePreRepair5
        {
            get;
            set;
        }
        public long? BladeLsWindwardSidePostRepair5
        {
            get;
            set;
        }
        public long? BladeLsWindwardSidePreRepair6
        {
            get;
            set;
        }
        public long? BladeLsWindwardSidePostRepair6
        {
            get;
            set;
        }
        public long? BladeLsWindwardSidePreRepair7
        {
            get;
            set;
        }
        public long? BladeLsWindwardSidePostRepair7
        {
            get;
            set;
        }
        public long? BladeLsWindwardSidePreRepair8
        {
            get;
            set;
        }
        public long? BladeLsWindwardSidePostRepair8
        {
            get;
            set;
        }
        public string BladeInspectionReportDescription
        {
            get;
            set;
        }
        public List<ComponentInspectionReportBladeDamage> DamageData
        {
            get;
            set;

        }
        public ComponentInspectionReportBladeRepairRecord RepairRecordData
        {
            get;
            set;
        }
    }
}