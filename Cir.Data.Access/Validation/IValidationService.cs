using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Data.Access.Validation
{
    public interface IValidationService
    {
        bool Validate<T>(params string[] parameters) where T: class;
    }
}
