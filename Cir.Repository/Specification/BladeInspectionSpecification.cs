using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Repository
{
    public class BladeInspectionSpecification : Specification
    {
        public override System.Linq.Expressions.Expression<Func<JObject, bool>> ToExpression()
        {
            return cir =>
                (cir != null) &&
                (cir.Type == JTokenType.Object) &&
                (cir["cirSubmissionData"] != null) &&
                (cir["cirSubmissionData"].Type == JTokenType.Object) &&
                (cir["cirSubmissionData"]["cirTemplateName"] != null) &&
                (cir["cirSubmissionData"]["cirTemplateName"].Type == JTokenType.String) &&
                (cir["cirSubmissionData"]["cirTemplateName"].Value<string>() == "BladeInspection");
        }

        public override string ToString()
        {
            return "BladeInspection()";
        }
    }
}
