using System;
using System.Collections.Generic;
using Cir.Data.Access.DataAccess;
using Cir.Data.Access.Models;
using LightInject;

namespace Cir.Data.Access.Services
{
    internal class UserDataService : IUserDataService
    {
        private readonly IList<IUserTable> userTableRepositories;

        public UserDataService(ICirSubmissionDataRepository cirSubmissionDataRepository,
            ICirTemplateRepository cirTemplateRepository)
        {
            userTableRepositories = new List<IUserTable>();
            userTableRepositories.Add(cirSubmissionDataRepository);
            userTableRepositories.Add(cirTemplateRepository);
        }

        public IEnumerable<UserData> GetData(string userId)
        {
            var userDataList = new List<UserData>();

            foreach(var repo in userTableRepositories)
            {
                var userData = new UserData()
                {
                    TableName = repo.TableName,
                    DataList = repo.GetTableData(userId)
                };
                userDataList.Add(userData);
            }

            return userDataList;
        }
    }
}
