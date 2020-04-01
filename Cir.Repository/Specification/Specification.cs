using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Repository
{
    
    public abstract class Specification : ISpecification
    {
        public abstract Expression<Func<JObject, bool>> ToExpression();
        public Func<JObject, bool> ToFunc() => ToExpression().Compile();

        public bool IsSatisfiedBy(JObject entity)
        {
            Func<JObject, bool> predicate = ToFunc();
            return predicate(entity);
        }
    }
}
