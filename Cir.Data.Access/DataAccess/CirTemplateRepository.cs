using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Cir.Data.Access.Models;
using Microsoft.Azure.Documents;
using System.Threading.Tasks;

namespace Cir.Data.Access.DataAccess
{
    internal class CirTemplateRepository : ICirTemplateRepository
    {
        private readonly BaseRepository _baseRepo;
        private readonly DataRepositoryConfig _config;
        private readonly Uri _documentCollectionUri;

        public CirTemplateRepository(DataRepositoryConfig config, BaseRepository baseRepo)
        {
            _config = config;
            _baseRepo = baseRepo;
            _documentCollectionUri = UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId);
        }

        public async Task<List<CirTemplateDataModel>> GetTemplatesByBrandIds(IList<string> brandIds)
        {
            try
            {
                var resultList = new List<CirTemplateDataModel>();

                var result = (from doc in _baseRepo.DocumentClient.CreateDocumentQuery<CirTemplateDataModel>(
                                UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
                                new FeedOptions { EnableCrossPartitionQuery = true  }) 
                              where brandIds.Contains(doc.CirBrand.Id) 
                              select doc).AsDocumentQuery();              
               

                while (result.HasMoreResults)
                {
                    FeedResponse<CirTemplateDataModel> res = await result.ExecuteNextAsync<CirTemplateDataModel>();
                    if (res.Any())
                    {
                        //var orderedRes = res.OrderByDescending(x => x.VersionNumber).ToList();
                        //var finalres= orderedRes.GroupBy(x => x.CirBrandCollectionName).Select(y => y.First()).ToList() ;
                        resultList.AddRange(res);
                    }
                }

                return resultList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
                
        public void Add(CirTemplateDataModel cirTemplateDataModel)
        {
            try
            {
                _baseRepo.Insert(cirTemplateDataModel, _config.DatabaseId, _config.CollectionId).Wait();
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

        public CirTemplateDataModel Get(string templateId)
        {
            return _baseRepo.DocumentClient.CreateDocumentQuery<CirTemplateDataModel>(
                _documentCollectionUri,
                new FeedOptions { MaxItemCount = 1, EnableCrossPartitionQuery = true })
                .Where(t => t.Id == templateId).AsEnumerable().First();
        }

        public CirTemplateDataModel GetHighestRevisionByBrandCollectionName(string brandCollectionName)
        {
            return _baseRepo.DocumentClient.CreateDocumentQuery<CirTemplateDataModel>(
                    _documentCollectionUri,
                    new FeedOptions {MaxItemCount = -1, EnableCrossPartitionQuery = true})
                .Where(t => t.CirBrandCollectionName == brandCollectionName)
                .AsEnumerable()
                .OrderByDescending(x => x.VersionNumber)
                .First();
        }
        public CirTemplateDataModel GetOldVersionByBrandCollectionName(string templateId)
        {
            return _baseRepo.DocumentClient.CreateDocumentQuery<CirTemplateDataModel>(
                    _documentCollectionUri,
                    new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .Where(t => t.Id == templateId)
                .AsEnumerable()
                //.OrderByDescending(x => x.VersionNumber)
                .First();
        }

        
    }
}
