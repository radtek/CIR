using System.Linq;
using Microsoft.Azure.Documents.Client;
using Cir.Data.Access.Models;
using Microsoft.Azure.Documents;
using System;

namespace Cir.Data.Access.DataAccess
{
    internal class CirIdRepository : ICirIdRepository
    {
        private readonly BaseRepository _baseRepo;
        private readonly DataRepositoryConfig _config;

        private const string GetNextCirIdProcedureName = "GetNextCirId";

        public CirIdRepository(DataRepositoryConfig config, BaseRepository baseRepo)
        {
            _config = config;
            _baseRepo = baseRepo;
        }

        public CirIdModel GetByCirId(long cirId)
        {
            return _baseRepo.DocumentClient.CreateDocumentQuery<CirIdModel>(
                    UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
                    new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .Where(x => x.CirId == cirId && !x.IsCounter).AsEnumerable().FirstOrDefault();
        }

        public CirIdModel GetCirId(string cirBrandCollectionName)
        {
            return _baseRepo.DocumentClient
                .ExecuteStoredProcedureAsync<CirIdModel>(
                    UriFactory.CreateStoredProcedureUri(_config.DatabaseId, _config.CollectionId, GetNextCirIdProcedureName),
                    new RequestOptions() { PartitionKey = new Microsoft.Azure.Documents.PartitionKey(keyValue: "partition") },
                    cirBrandCollectionName)
                .Result;
        }

        public void Add(CirIdModel cirId)
        {
            try
            {
                _baseRepo.Insert(cirId, _config.DatabaseId, _config.CollectionId).Wait();
            }
            catch (DocumentClientException de)
            {
                throw de;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
