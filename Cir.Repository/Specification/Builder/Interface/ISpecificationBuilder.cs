using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cir.Repository
{
    public interface ISpecificationBuilder
    {
        ISpecificationBuilder BladeInspection();
        ISpecificationBuilder CirId(int? cirId);
        ISpecificationBuilder CirIds(IList<int> cirIds);
        ISpecificationBuilder CirGuid(string cirGuid);
        ISpecificationBuilder Damages(bool? hasDamages);
        ISpecification Build();
    }
}
