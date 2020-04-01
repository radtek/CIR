using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Cir.Data.Access.Models;

namespace Cir.Data.Access.DataAccess
{
    internal abstract class BaseRepository<T> where T : IDataModel, ICosmosDbIDataModel
    {
        protected string EndpointUri => _config.EndpointUri;
        protected string PrimaryKey => _config.PrimaryKey;
        protected string DatabaseId => _config.DatabaseId;
        protected string CollectionId => _config.CollectionId;

        protected DataRepositoryConfig _config;
        protected DocumentClient _documentClient;
        protected Database _database;

        public BaseRepository(DataRepositoryConfig config)
        {
            _config = config;
            _documentClient = new DocumentClient(new Uri(EndpointUri), PrimaryKey);
            _database = new Database { Id = DatabaseId };
        }

        protected virtual async Task Insert(T report)
        {
            try
            {
                await _documentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId), report).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected virtual async Task Replace(string reportId, T report)
        {
            try
            {
                await _documentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, reportId), report).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected virtual async Task DeleteDocument(string reportId)
        {
            try
            {
                Document report = _documentClient.CreateDocumentQuery(
                    UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId),
                    new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                    .Where(r => r.Id == reportId)
                    .AsEnumerable()
                    .FirstOrDefault();

                await _documentClient.DeleteDocumentAsync(report.SelfLink,
                    new RequestOptions { PartitionKey = new PartitionKey(keyValue: ((T)(dynamic)report).Partition) })
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
