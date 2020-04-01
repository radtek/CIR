using Cir.Data.Access.DataAccess;
using Cir.Data.Access.Models;
using Polly;
using System;

namespace Cir.Data.Access.Services
{
    internal class ConcurrentUpdateException : Exception
    {
        public ConcurrentUpdateException()
        {
        }
    }

    internal class CirIdGeneratorService : ICirIdGeneratorService
    {
        private readonly ICirIdRepository _cirIdRepository;

        public CirIdGeneratorService(ICirIdRepository cirIdRepository)
        {
            _cirIdRepository = cirIdRepository;
        }

        public CirIdModel GetCirId(string cirBrandCollectionName)
        {
            var policy = Policy
            .Handle<ConcurrentUpdateException>()
            .Retry(10);

            var result = policy.Execute(() => GetNextCirId(cirBrandCollectionName));
            return result;
        }

        private CirIdModel GetNextCirId(string cirBrandCollectionName)
        {
            try
            {
                CirIdModel result = _cirIdRepository.GetCirId(cirBrandCollectionName);
                if (result != null)
                {
                    result.Id = null;
                    result.IsCounter = false;
                    _cirIdRepository.Add(result);
                }
                return result;
            }
            catch(Exception ex)
            {
                if (ex.InnerException.Message.Contains("One of the specified pre-condition is not met"))
                    throw new ConcurrentUpdateException();
                throw;
            }
        }
    }
}
