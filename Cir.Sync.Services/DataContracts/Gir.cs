using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Sync.Services.DataContracts
{
    public class Gir
    {
        public long GirDataID { get; set; }
        public string GirCode { get; set; }
        public int RevisionNumber { get; set; }
        public string ClassificationOfDamage { get; set; }
        public string AnalysisOfPicture { get; set; }
        public string AnalysisOfMeasurments { get; set; }
        public string ConclusionsAndRecommendations { get; set; }
        public string CirIDs { get; set; }
        public DateTime Created { get; set; }
        public String strCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public string GeneralSerialNos { get; set; }
        public long TurbineID { get; set; }
        public SearchAttributes Search { get; set; }
        public CIR.ComponentInspectionReport ComponentInspectionReport { get; set; }
        public List<CIR.ComponentInspectionReport> ComponentInspectionReportDetails { get; set; }
        public GirFile File { get; set; }
    }
}
