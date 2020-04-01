using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Cir.Data.Access.Models;
using System.Text;
using System.Collections.Generic;

namespace Cir.Data.Access.DataAccess
{
    internal class BaseRepository
    {
        public DocumentClient DocumentClient;
        public Database _database;
        public readonly Uri _documentCollectionUri;

        public BaseRepository(string endpointUri, string primaryKey)
        {
#if DEBUG
            DocumentClient = new DocumentClient(new Uri(endpointUri), primaryKey);
#else
            DocumentClient = new DocumentClient(new Uri(endpointUri), primaryKey,
                            new ConnectionPolicy()
                            {
                                ConnectionMode = ConnectionMode.Direct,
                                ConnectionProtocol = Protocol.Tcp
                            });
#endif
            DocumentClient.OpenAsync();
        }

        public virtual async Task Insert(object document, string databaseId, string collectionId)
        {
            try
            {
                await DocumentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseId, collectionId), document).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task Replace(string documentId, object document, string databaseId, string collectionId)
        {
            try
            {
                await DocumentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseId, collectionId, documentId), document).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task DeleteDocument(string documentId, string databaseId, string collectionId)
        {
            try
            {
                Document report = DocumentClient.CreateDocumentQuery(
                    UriFactory.CreateDocumentCollectionUri(databaseId, collectionId),
                    new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                    .Where(r => r.Id == documentId)
                    .AsEnumerable()
                    .FirstOrDefault();

                await DocumentClient.DeleteDocumentAsync(report.SelfLink,
                    new RequestOptions { PartitionKey = new PartitionKey(keyValue: "partition") })
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SqlQuerySpec GenerateQueryWithListFilterOnStringProperty(string propertyName, List<string> listWithExpectedPropertyValues, string partition = null)
        {
            if (!listWithExpectedPropertyValues.Any())
            {
                return null;
            }

            var stringBuilder = new StringBuilder();

            stringBuilder.Append(string.Join(",", WrapIdsInQuotes(listWithExpectedPropertyValues)));

            return new SqlQuerySpec(string.IsNullOrEmpty(partition)
                ? $"SELECT * FROM c WHERE {propertyName} IN ({stringBuilder})"
                : $"SELECT * FROM c WHERE {propertyName} IN ({stringBuilder}) and c.partition = \"{partition}\"");
        }

        private static List<string> WrapIdsInQuotes(List<string> ids)
        {
            return ids.Select(id => { id = $"'{id}'"; return id; }).ToList();
        }
    }
}
