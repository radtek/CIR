using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cir.Common.Cir
{
    public class GearboxDetail
    {
        public int GearboxDefectCategorizationId { get; set; }
        public int PartName { get; set; }
        public int PartType { get; set; }
        public string ItemNumber { get; set; }
        public string BearingType { get; set; }
        public int Error1Id { get; set; }
        public int Error2Id { get; set; }
        public string Comments { get; set; }
        public int DamageDecisionId { get; set; }
    }
}
