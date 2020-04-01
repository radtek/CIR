using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Repository
{
    public interface ISpecification
    {
        Expression<Func<JObject, bool>> ToExpression();
        Func<JObject, bool> ToFunc();
        bool IsSatisfiedBy(JObject entity);
    }
}
