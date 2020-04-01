using System.Linq;
using Cir.Data.Access.Models;
using Microsoft.Azure.Documents.Client;

namespace Cir.Data.Access.DataAccess
{
    internal class MessageDataRepository: IMessageDataRepository
    {
        private readonly BaseRepository _baseRepo;
        private readonly DataRepositoryConfig _config;

        public MessageDataRepository(DataRepositoryConfig config, BaseRepository baseRepo)
        {
            _config = config;
            _baseRepo = baseRepo;
        }

        public MessageData Get(string id)
        {
            return _baseRepo.DocumentClient.CreateDocumentQuery<MessageData>(
                    UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
                    new FeedOptions {MaxItemCount = -1, EnableCrossPartitionQuery = true})
                .Where(f => f.Id == id).AsEnumerable().First();
        }

        public IQueryable<MessageData> GetAll()
        {           
            var reports = _baseRepo.DocumentClient.CreateDocumentQuery<MessageData>(
                UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true });

            return reports;
        }

        public void Add(MessageData report)
        {
            _baseRepo.Insert(report, _config.DatabaseId, _config.CollectionId).Wait();
        }

        public void Update(MessageData report)
        {
            _baseRepo.Replace(report.Id, report, _config.DatabaseId, _config.CollectionId).Wait();
        }

        public void Delete(string reportId)
        {
            _baseRepo.DeleteDocument(reportId, _config.DatabaseId, _config.CollectionId).Wait();
        }
    }
}