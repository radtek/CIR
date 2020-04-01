using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Documents.Client;
using Cir.Data.Access.Models;
using Microsoft.Azure.Documents;

namespace Cir.Data.Access.DataAccess
{
    internal class BrandDataRepository : IBrandDataRepository
    {
        private readonly BaseRepository _baseRepo;
        private readonly DataRepositoryConfig _config;

        public BrandDataRepository(DataRepositoryConfig config, BaseRepository baseRepo)
        {
            _config = config;
            _baseRepo = baseRepo;
        }

        public BrandDataModel Get(string id)
        {
            return _baseRepo.DocumentClient.CreateDocumentQuery<BrandDataModel>(
               UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
                new FeedOptions { MaxItemCount = 1, EnableCrossPartitionQuery = true })
                .Where(t => t.Id == id).AsEnumerable().First();
        }

        public List<BrandDataModel> GetAll()
        {
            return _baseRepo.DocumentClient.CreateDocumentQuery<BrandDataModel>(
                UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
                new FeedOptions { MaxItemCount = 1000, EnableCrossPartitionQuery = true })
                .ToList();
        }

        public void Add(BrandDataModel brandDataModel)
        {
            try
            {
                _baseRepo.Insert(brandDataModel, _config.DatabaseId, _config.CollectionId).Wait();
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

        public List<BrandDataModel> GetByIds(IList<string> brandIds)
        {
            try
            {
                return _baseRepo.DocumentClient.CreateDocumentQuery<BrandDataModel>(
                    UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
                    _baseRepo.GenerateQueryWithListFilterOnStringProperty("c.id", brandIds.ToList()),
                    new FeedOptions { MaxItemCount = 1000, EnableCrossPartitionQuery = true })
                    .ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
