using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Repository
{
    public class CirIdSpecification : Specification
    {
        private readonly IList<int> cirIds;
        public CirIdSpecification(int cirId)
        {
            cirIds = new[] { cirId };
        }
        public CirIdSpecification(IList<int> cirIds)
        {
            this.cirIds = new List<int>(cirIds);
        }
        public override Expression<Func<JObject, bool>> ToExpression()
        {
            return cir =>
                (cir != null) &&
                (cir.Type == JTokenType.Object) &&
                (cir["cirSubmissionData"] != null) &&
                (cir["cirSubmissionData"].Type == JTokenType.Object) &&
                (cir["cirSubmissionData"]["cirId"] != null) &&
                (cir["cirSubmissionData"]["cirId"].Type == JTokenType.Integer) &&
                (cirIds.Contains(cir["cirSubmissionData"]["cirId"].Value<int>()));
        }

        public override string ToString()
        {
            var ids = cirIds
                .OrderBy(x => x)
                .ToList();
            var text = string.Join(",", ids);
            return $"CirIdSpecification({text})";
        }
    }
}
