using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.DataContracts
{
    public class Gbx
    {
        public long GbxDataID { get; set; }
        public string GbxCode { get; set; }
        public int RevisionNumber { get; set; }
        public string OilAnalysis { get; set; }
        public string CMSAnalysis { get; set; }
        public string Analysis { get; set; }
        public string ConclusionsAndRecommendations { get; set; }
        public string CirIDs { get; set; }
        public DateTime Created { get; set; }
        public String strCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public string GearboxSerialNos { get; set; }
        public long TurbineID { get; set; }
        public SearchAttributes Search { get; set; }
        public CIR.ComponentInspectionReport ComponentInspectionReport { get; set; }
        public List<CIR.ComponentInspectionReport> ComponentInspectionReportDetails { get; set; }
        public GbxFile File { get; set; }
    }
}