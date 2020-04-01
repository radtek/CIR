using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cir.Common.Cir
{
    public class GeneratorDetail
    {
        public long GeneratorDefectCategorizationId { get; set; }
        public string Component { get; set; }
        public string FailureDamage { get; set; }
        public string IsDamaged { get; set; }
        public string Repair { get; set; }
        public string FailureMode { get; set; }
    }
}
