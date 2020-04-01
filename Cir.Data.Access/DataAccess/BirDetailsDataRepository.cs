using System.Linq;
using Cir.Data.Access.Models;
using Microsoft.Azure.Documents.Client;
using Cir.Data.Access.CirSyncService;
using System.Collections.Generic;
using System;

namespace Cir.Data.Access.DataAccess
{
    internal class BirDetailsDataRepository: IBirDetailsDataRepository
    {
        private readonly BaseRepository _baseRepo;
        private readonly DataRepositoryConfig _config;
        private readonly SyncServiceClient _serviceClient;

        public BirDetailsDataRepository(DataRepositoryConfig config, BaseRepository baseRepo)
        {
            _config = config;
            _baseRepo = baseRepo;
            _serviceClient = new SyncServiceClient("WSHttpBinding_ISyncService");
        }

        public BirDetailsData Get(string id)
        {
            return _baseRepo.DocumentClient.CreateDocumentQuery<BirDetailsData>(
                    UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
                    new FeedOptions {MaxItemCount = -1, EnableCrossPartitionQuery = true})
                .Where(f => f.Id == id).AsEnumerable().First();
        }

        public IQueryable<BirDetailsData> GetAll()
        {           
                IQueryable<BirDetailsData> reports = _baseRepo.DocumentClient.CreateDocumentQuery<BirDetailsData>(
                    UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
                    new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true });

                return reports;
        }

        public void Add(BirDetailsData report)
        {
            _baseRepo.Insert(report, _config.DatabaseId, _config.CollectionId).Wait();
        }

        public void Update(BirDetailsData report)
        {
            _baseRepo.Replace(report.Id, report, _config.DatabaseId, _config.CollectionId).Wait();
        }

        public void Delete(string reportId)
        {
            _baseRepo.DeleteDocument(reportId, _config.DatabaseId, _config.CollectionId).Wait();
        }


        public void SaveBirData(Bir bir)
        {
            //Dictionary<string, string> cirDataIds = _serviceClient.GetCirDataIdByCirID(bir.CirIDs);
            //bir.BirDataID = Int32.Parse(cirDataIds.Single(x => x.Key == "MasterCirDataId").Value);
            //bir.CirIDs = cirDataIds.Single(x => x.Key == "CirDataIds").Value;
            //_serviceClient.SaveBirData(bir);
        }



    }
}