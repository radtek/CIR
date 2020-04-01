using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Cir.Repository
{
    public class CirGuidSpecification : Specification
    {
        private readonly IList<string> cirIds;
        public CirGuidSpecification(string cirId)
        {
            cirIds = new[] { cirId };
        }
        public CirGuidSpecification(IList<string> cirIds)
        {
            this.cirIds = new List<string>(cirIds);
        }
        public override Expression<Func<JObject, bool>> ToExpression()
        {
            return cir =>
                (cir != null) &&
                (cir.Type == JTokenType.Object) &&
                (cir["cirSubmissionData"] != null) &&
                (cir["cirSubmissionData"].Type == JTokenType.Object) &&
                (cir["cirSubmissionData"]["id"] != null) &&
                (cir["cirSubmissionData"]["id"].Type == JTokenType.String) &&
                (cirIds.Contains(cir["cirSubmissionData"]["id"].Value<string>()));
        }

        public override string ToString()
        {
            var ids = cirIds
                .OrderBy(x => x)
                .ToList();
            var text = string.Join(",", ids);
            return $"CirGuidSpecification({text})";
        }
    }
}
