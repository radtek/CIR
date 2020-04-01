using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class CustomerAuthorizer : IHttpAuthorizer
    {
        private readonly IHeaderParameterGetter parameterGetter;
        private readonly CloudTable table;

        public CustomerAuthorizer(IHeaderParameterGetter parameterGetter)
        {
            this.parameterGetter = parameterGetter;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Environment.GetEnvironmentVariable("AzureStorageConnectionString"));
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            table = tableClient.GetTableReference(Environment.GetEnvironmentVariable("CustomerAuthorizerTableName"));
        }


        public async Task<bool> IsAuthorizedAsync(HttpRequest req)
        {
            try
            {
                var consumerName = parameterGetter.GetString("X-Consumer-Name", req);
                var consumerKey = parameterGetter.GetString("X-Consumer-Key", req);

                var retrieveOperation = TableOperation.Retrieve<CirConsumerModel>(consumerName, consumerKey);
                var retrievedResult = await table.ExecuteAsync(retrieveOperation);
                var consumer = (CirConsumerModel)retrievedResult.Result;

                if (consumer != null)
                {
                    return true;
                }
            }
            catch (Exception)
            {}
            return false;
        }
    }
}
