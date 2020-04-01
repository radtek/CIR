using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Cir.Repository
{
    public class RepairSpecification : Specification
    {
        public override Expression<Func<JObject, bool>> ToExpression()
        {
            return cir =>
                (cir != null) &&
                (cir.Type == JTokenType.Object) &&
                (cir["cirSubmissionData"] != null) &&
                (cir["cirSubmissionData"].Type == JTokenType.Object) &&
                (cir["cirSubmissionData"]["data"] != null) &&
                (cir["cirSubmissionData"]["data"].Type == JTokenType.Object) &&
                (cir["cirSubmissionData"]["data"]["rbReportType"] != null) &&
                (cir["cirSubmissionData"]["data"]["rbReportType"].Type == JTokenType.String) &&
                ((cir["cirSubmissionData"]["data"]["rbReportType"].Value<string>() == "3" ||
                 (cir["cirSubmissionData"]["data"]["rbReportType"].Value<string>() == "5" )));
        }

        public override string ToString()
        {
            return "Repair()";
        }
    }
}
