using System.Collections.Generic;
using Cir.Data.Access.Models.Integration;

namespace Cir.Data.Access.DataAccess
{
    internal interface IIntegrationRequestsDataRepository
    {
        IEnumerable<RequestModel> GetAllNonFinished();
        string Add(RequestModel request);
        void Update(RequestModel request);
    }
}
