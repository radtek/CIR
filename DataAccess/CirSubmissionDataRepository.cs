using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Cir.Data.Access.Models;
using System.Text;

namespace Cir.Data.Access.DataAccess
{
    internal class CirSubmissionDataRepository : BaseRepository<CirSubmissionData>, ICirSubmissionDataRepository
    {
        public string TableName => "CirDataJson";

        public CirSubmissionDataRepository(DataRepositoryConfig config) : base (config) { }

        public CirSubmissionData Get(string reportId)
        {
            try
            {
                return _documentClient.CreateDocumentQuery<CirSubmissionData>(
                    UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId),
                    new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                    .Where(f => f.Id == reportId).AsEnumerable().First();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable<CirSubmissionData> GetAll()
        {
            try
            {
                IQueryable<CirSubmissionData> reports = _documentClient.CreateDocumentQuery<CirSubmissionData>(
                    UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId),
                    new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true });

                return reports;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable<CirSubmissionSyncData> GetAllRelatedToUser(string userId)
        {
            try
            {
                IQueryable<CirSubmissionSyncData> reports = _documentClient.CreateDocumentQuery<CirSubmissionData>(
                    UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId),
                    new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                    .Where(r => r.ModifiedBy == userId || r.CreatedBy == userId)
                    .Select(r => new CirSubmissionSyncData
                    {
                        Id = r.Id,
                        ModifiedOn = r.ModifiedOn,
                        ModifiedBy = r.ModifiedBy
                    });

                return reports;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable<CirSubmissionData> GetAllByIds(List<string> ids)
        {
            try
            {
                var stringBuilder = new StringBuilder();

                stringBuilder.Append(string.Join(",", WrapIdsInQuotes(ids)));

                var query = new SqlQuerySpec(
                    string.Format("SELECT * FROM c WHERE c.id IN ({0})",
                    stringBuilder.ToString()));

                return _documentClient.CreateDocumentQuery<CirSubmissionData>(
                    UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId),
                    query,
                    new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Add(CirSubmissionData report)
        {
            try
            {
                Insert(report).Wait();
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

        public void Update(CirSubmissionData report)
        {
            try
            {
                Replace(report.Id, report).Wait();
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

        public void Delete(string reportId)
        {
            try
            {
                DeleteDocument(reportId).Wait();
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

        public IList<object> GetTableData(string userId)
        {
            try
            {
                return GetAll().Where(r => r.ModifiedBy == userId || r.CreatedBy == userId).ToList<object>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private List<string> WrapIdsInQuotes(List<string> ids)
        {
            return ids.Select(id => { id = $"'{id}'"; return id; }).ToList();
        }
    }
}