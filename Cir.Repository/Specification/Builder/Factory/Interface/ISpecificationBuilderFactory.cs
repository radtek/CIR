using System;
using System.Collections.Generic;
using System.Text;

namespace Cir.Repository
{
    public interface ISpecificationBuilderFactory
    {
        ISpecificationBuilder Create();
    }
}
