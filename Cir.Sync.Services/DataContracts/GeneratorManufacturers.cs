using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.DataContracts
{
    public class GeneratorManufacturers
    {
        public long GeneratorManufacturerId { get; set; }
        public string Name { get; set; }
        public long LanguageId { get; set; }
        public Nullable<long> ParentGeneratorManufacturerId { get; set; }
        public long Sort { get; set; }
        public string Email { get; set; }
        public string Cc { get; set; }
        public string EmailContactName { get; set; }
    }
}