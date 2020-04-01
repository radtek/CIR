using Cir.Data.Access.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cir.Data.Access.DataAccess
{
    internal class HotlistRepository : /*BaseRepository<HotlistDataModel>,*/ IHotlistRepository
    {
        private readonly BaseRepository _baseRepo;
        private readonly DataRepositoryConfig _config;

        public HotlistRepository(DataRepositoryConfig config, BaseRepository baseRepo) // : base(config) { }
        {
            _config = config;
            _baseRepo = baseRepo;
        }

        public HotlistDataModel Get(string id)
        {
            return _baseRepo.DocumentClient.CreateDocumentQuery<HotlistDataModel>(
                UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
                new FeedOptions { MaxItemCount = 1, EnableCrossPartitionQuery = true })
                .Where(t => t.Id == id).AsEnumerable().First();
        }

        public List<HotlistDataModel> GetAll()
        {
            return _baseRepo.DocumentClient.CreateDocumentQuery<HotlistDataModel>(
                UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .ToList();
        }

        public void Add(HotlistDataModel hotlist)
        {
            try
            {
                _baseRepo.Insert(hotlist, _config.DatabaseId, _config.CollectionId).Wait();
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

        public void Delete(string id)
        {
            try
            {
                _baseRepo.DeleteDocument(id, _config.DatabaseId, _config.CollectionId).Wait();
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

        public HotlistDataModel GetByHotItemId(long hotItemId)
        {
            return _baseRepo.DocumentClient.CreateDocumentQuery<HotlistDataModel>(
               UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
                new FeedOptions { MaxItemCount = 1, EnableCrossPartitionQuery = true })
                .Where(t => t.HotItemId == hotItemId).AsEnumerable().First();
        }

        public void Update(HotlistDataModel hotlistData)
        {
            try
            {
                _baseRepo.Replace(hotlistData.Id, hotlistData, _config.DatabaseId, _config.CollectionId).Wait();
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
