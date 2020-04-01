using System;
using Microsoft.Azure.Documents;
using Cir.Data.Access.Models;
using System.Collections.Generic;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System.Linq;
using System.Threading.Tasks;
using Cir.Data.Access.Models.Authorization;

namespace Cir.Data.Access.DataAccess
{
    internal class GroupUserBrandRepository : IGroupUserBrandRepository
    {
        private readonly BaseRepository _baseRepo;
        private readonly DataRepositoryConfig _config;

        public GroupUserBrandRepository(DataRepositoryConfig config, BaseRepository baseRepo)
        {
            _config = config;
            _baseRepo = baseRepo;
        }

        public async Task<List<string>> GetAssignedBrandsIdsByUserEmailOrGroupName(UserInformation user)
        {
            var brand = new List<GroupUserBrand>();
            var groupUser = (from doc in _baseRepo.DocumentClient.CreateDocumentQuery<GroupUserBrand>(
               UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
               new FeedOptions { EnableCrossPartitionQuery = true, MaxBufferedItemCount = -1 })
                             where doc.Email == user.DisplayName || user.UserGroups.Contains(doc.Name)
                             select doc).AsDocumentQuery();
            while (groupUser.HasMoreResults)
            {
                FeedResponse<GroupUserBrand> res = await groupUser.ExecuteNextAsync<GroupUserBrand>();
                if (res.Any())
                {
                    brand.AddRange(res.ToList());
                }
            }

            return brand.SelectMany(x => x.Brands).ToList();
        }

        public async Task<List<string>> GetAssignedBrandsIdsByUserEmail(string userId)
        {
            var brand = new GroupUserBrand();
            var groupUser = (from doc in _baseRepo.DocumentClient.CreateDocumentQuery<GroupUserBrand>(
               UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
               new FeedOptions { MaxItemCount = 1, EnableCrossPartitionQuery = true, MaxBufferedItemCount = -1 })
                             where doc.Email == userId
                             select doc).AsDocumentQuery();
            while (groupUser.HasMoreResults)
            {
                FeedResponse<GroupUserBrand> res = await groupUser.ExecuteNextAsync<GroupUserBrand>();
                if (res.Any())
                {
                    brand = res.FirstOrDefault();
                    break;
                }
            }

            return brand?.Brands?.ToList() ?? new List<string>();
        }

        public async Task<List<string>> GetAssignedBrandsIdsByGroupName(string groupName)
        {
            var brand = new GroupUserBrand();
            var groupUser = (from doc in _baseRepo.DocumentClient.CreateDocumentQuery<GroupUserBrand>(
               UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
               new FeedOptions { MaxItemCount = 1, EnableCrossPartitionQuery = true, MaxBufferedItemCount = -1 })
                             where doc.Name == groupName
                             select doc).AsDocumentQuery();
            while (groupUser.HasMoreResults)
            {
                FeedResponse<GroupUserBrand> res = await groupUser.ExecuteNextAsync<GroupUserBrand>();
                if (res.Any())
                {
                    brand = res.FirstOrDefault();
                    break;
                }
            }

            return brand?.Brands?.ToList() ?? new List<string>();
        }

        public void Add(GroupUserBrand groupUserData)
        {
            try
            {
                _baseRepo.Insert(groupUserData, _config.DatabaseId, _config.CollectionId).Wait();
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

        public GroupUserBrand GetUserGroupByEmailOrGroupName(string userEmailOrGroupName)
        {
            return _baseRepo.DocumentClient.CreateDocumentQuery<GroupUserBrand>(
                UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .Where(userGroup => userGroup.Email  == userEmailOrGroupName || userGroup.Name.ToLower() == userEmailOrGroupName.ToLower())
                .AsEnumerable()
                .FirstOrDefault();
        }

        public GroupUserBrand GetGroupByGroupName(string groupName)
        {
            return _baseRepo.DocumentClient.CreateDocumentQuery<GroupUserBrand>(
                UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .Where(userGroup => userGroup.Name.ToLower() == groupName.ToLower())
                .AsEnumerable()
                .FirstOrDefault();
        }

        public void Update(GroupUserBrand groupUserBrand)
        {
            try
            {
                _baseRepo.Replace(groupUserBrand.Id, groupUserBrand, _config.DatabaseId, _config.CollectionId).Wait();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
