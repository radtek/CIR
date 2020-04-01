using Cir.Data.Access.Models;

namespace Cir.Data.Access.Services
{
    public interface ICirValidationService
    {
        bool IsDataValid(CirSubmissionData cirSubmissionData);
    }
}
