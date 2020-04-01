using System;
using System.Collections.Generic;
using System.Text;

namespace Cir.Repository
{
    public class SpecificationBuilderFactory: ISpecificationBuilderFactory
    {
        public ISpecificationBuilder Create()
        {
            return new SpecificationBuilder();
        }
    }
}
