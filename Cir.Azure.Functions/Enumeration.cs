using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    public class Enumeration
    {
        public enum CirState
        {
            Draft = 0,
            Submitted = 1,
            Approved = 2,
            Rejected = 3,
            Error = 4,
            Removed = 5,
            Sync = 6,
            PendingForBa = 7,
            Undefined = 8
        }
        public enum ImageProcessStatus
        {
            NotSynced,
            Syncing,
            Synced
        }
        public enum CirTemplate
        {
            BladeInspection = 1,
            Generator = 2,
            Gearbox = 3,
            Transformer = 4,
            General = 5,
            MainBearing = 6,
            Skiipack = 7,
            SimplifiedCIR = 8,
            BladeRepair = 9
        }
        public enum ReportType
        {
            Inspection = 1,
            Failure = 2,
            Repair = 3,
            Replacement = 4,
            Retrofit = 5,
            CMSInspection = 6
        }
    }
}
