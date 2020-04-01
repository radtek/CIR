using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.DataContracts
{
    /// <summary>
    /// Entity of FeedbackType
    /// </summary>
    public class ServiceInformations
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public Nullable<long> SeverityId { get; set; }
        public string SeverityName { get; set; }
        public string StrFromDate { get; set; }
        public string StrToDate { get; set; }
        public System.DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public bool IsExpired { get; set; }
    }
}