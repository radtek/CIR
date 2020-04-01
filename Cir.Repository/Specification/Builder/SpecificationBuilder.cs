using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cir.Repository
{
    public class SpecificationBuilder: ISpecificationBuilder
    {
        private ISpecification spec;


        public ISpecificationBuilder BladeInspection()
        {
            var newSpec = new BladeInspectionSpecification();
            Add(newSpec);
            return this;
        }

        public ISpecificationBuilder CirId(int? cirId)
        {
            if (cirId != null)
            {
                var newSpec = new CirIdSpecification(cirId.Value);
                Add(newSpec);
            }
            return this;
        }

        public ISpecificationBuilder CirIds(IList<int> cirIds)
        {
            if (cirIds != null)
            {
                var newSpec = new CirIdSpecification(cirIds);
                Add(newSpec);
            }
            return this;
        }

        public ISpecificationBuilder CirGuid(string cirGuid)
        {
            if (cirGuid != null)
            {
                var newSpec = new CirGuidSpecification(cirGuid);
                Add(newSpec);
            }
            return this;
        }

        public ISpecificationBuilder Damages(bool? hasDamages)
        {
            if (hasDamages != null)
            {
                var newSpec = new DamagesSpecification(hasDamages.Value);
                Add(newSpec);
            }
            return this;
        }

        public ISpecification Build()
        {
            return spec;
        }

        private void Add(ISpecification specToAdd)
        {
            if (spec == null)
            {
                spec = specToAdd;
            }
            else
            {
                spec = new AndSpecification(
                    spec,
                    specToAdd);
            }
        }
    }
}
