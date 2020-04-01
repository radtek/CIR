using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Documents.Client;
using Cir.Data.Access.Models;

namespace Cir.Data.Access.DataAccess
{
    internal class CirTemplateRepository : BaseRepository<CirTemplateDataModel>, ICirTemplateRepository
    {
        public string TableName => "CirTemplates";

        public CirTemplateRepository(DataRepositoryConfig config) : base(config) { }

        public IList<object> GetTableData(string userId)
        {
            try
            {
                return _documentClient.CreateDocumentQuery<CirTemplateDataModel>(
                    UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId),
                    new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true }).ToList<object>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
