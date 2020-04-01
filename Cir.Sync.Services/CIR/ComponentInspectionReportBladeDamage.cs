using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.CIR
{
    public class ComponentInspectionReportBladeDamage
    {
        public long ComponentInspectionReportBladeDamageId
        {
            get;
            set;
        }
        public long ComponentInspectionReportBladeId
        {
            get;
            set;
        }
        public long BladeDamagePlacementId
        {
            get;
            set;
        }
        public long BladeInspectionDataId
        {
            get;
            set;
        }
        public double BladeRadius
        {
            get;
            set;
        }
        public long BladeEdgeId
        {
            get;
            set;
        }
        public string BladeDescription
        {
            get;
            set;
        }
        public string BladePictureNumber
        {
            get;
            set;
        }
        public int? PictureOrder
        {
            get;
            set;
        }
        public int? DamageSeverity { get; set; }
        public System.Guid? FormIOImageGUID { get; set; }
    }
}