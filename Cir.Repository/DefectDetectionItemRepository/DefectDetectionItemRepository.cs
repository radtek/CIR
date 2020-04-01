using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Repository
{
    public class DefectDetectionItemRepository: IDefectDetectionItemRepository
    {
        private readonly DocumentClient client;
        private readonly string databaseId;
        private const string collectionId = "DefectDetectionItems";
        public DefectDetectionItemRepository()
        {
            string endpointUri = Environment.GetEnvironmentVariable("EndPointUrl");
            string primaryKey = Environment.GetEnvironmentVariable("PrimaryKey");
            databaseId = Environment.GetEnvironmentVariable("Database");

            client = new DocumentClient(new Uri(endpointUri), primaryKey);
        }
        public async Task SetAsync(DefectDetectionItem item)
        {
            var uri = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
            await client.UpsertDocumentAsync(uri, item);
        }

        public DefectDetectionItem Get(string id)
        {
            var uri = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
            return client
                .CreateDocumentQuery<DefectDetectionItem>(uri)
                .SingleOrDefault(i => i.Id == id);
        }

        public async Task DeleteAsync(string id)
        {
            var uri = UriFactory.CreateDocumentUri(databaseId, collectionId, id);
            var options = new RequestOptions
            {
                PartitionKey = new PartitionKey(id)
            };
            try
            {
                await client.DeleteDocumentAsync(uri, options);
            }
            catch (DocumentClientException e)
            { 
                if (e.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    throw;
                }
            }
        }
    }
}

