using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.DataContracts
{
    /// <summary>
    /// Entity of FeedbackType
    /// </summary>
    public class Feedback
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public Nullable<long> FeedbackTypeId { get; set; }
        public System.DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public string Enviroment { get; set; }
        public string FeedbackType { get; set; }
    }
}