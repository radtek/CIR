using System;
using System.Collections.Generic;
using System.Linq;
using Cir.Data.Access.Models;
using Cir.Data.Access.Models.Integration;
using Microsoft.Azure.Documents.Client;

namespace Cir.Data.Access.DataAccess
{
    internal class IntegrationRequestsDataRepository : IIntegrationRequestsDataRepository
    {
        private readonly BaseRepository _baseRepo;
        private readonly DataRepositoryConfig _config;

        public IntegrationRequestsDataRepository(DataRepositoryConfig config, BaseRepository baseRepo)
        {
            _config = config;
            _baseRepo = baseRepo;
        }

        public IEnumerable<RequestModel> GetAllNonFinished()
        {
            return _baseRepo.DocumentClient.CreateDocumentQuery<RequestModel>(
                    UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
                    new FeedOptions {MaxItemCount = -1, EnableCrossPartitionQuery = true})
                .Where(x => x.RequestState == RequestState.Queued ||
                            x.RequestState == RequestState.InProgress ||
                            x.RequestState == RequestState.Error)
                .ToList();
        }

        public string Add(RequestModel request)
        {
            request.ModifiedOn = DateTime.Now;

            var result = _baseRepo.DocumentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId), request).Result;

            return result.Resource.Id;
        }

        public void Update(RequestModel request)
        {
            request.ModifiedOn = DateTime.Now;

            _baseRepo.Replace(request.Id, request, _config.DatabaseId, _config.CollectionId).Wait();
        }
    }
}
