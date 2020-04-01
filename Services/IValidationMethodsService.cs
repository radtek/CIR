using Cir.Data.Access.Models;
using System.Collections.Generic;

namespace Cir.Data.Access.Services
{
    public interface IValidationMethodsService
    {
        IList<ValidationMethodsModel> GetValidationMethods();
    }
}
