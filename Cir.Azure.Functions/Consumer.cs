using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class Consumer
    {
        public static CloudStorageAccount storageAccount = CloudStorageAccount.Parse(System.Environment.GetEnvironmentVariable("AzureStorageConnectionString"));
        public static CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
        public static CloudTable table = tableClient.GetTableReference("ConsumerDetails");

        public async static Task<bool> ValidateConsumer(string consumerName, string consumerKey)
        {
            try
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<CirConsumerModel>(consumerName, consumerKey);
                // Execute the operation.
                TableResult retrievedResult = await table.ExecuteAsync(retrieveOperation);
                // Assign the result to a CirAzureConsumerDetail object.
                CirConsumerModel updateEntity = (CirConsumerModel)retrievedResult.Result;

                if (updateEntity != null)
                {
                    //updateEntity.HitCount = updateEntity.HitCount + 1;
                    //// Create the Replace TableOperation.
                    //TableOperation updateOperation = TableOperation.Replace(updateEntity);
                    //// Execute the operation.
                    //table.Execute(updateOperation);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async static Task<bool> CreateConsumer(string consumerName, string adminKey)
        {
            try
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<CirConsumerModel>("Admin", adminKey);
                TableResult retrievedResult = await table.ExecuteAsync(retrieveOperation);
                if (retrievedResult.Result != null)
                {
                    await table.CreateIfNotExistsAsync();
                    CirConsumerModel consumer = new CirConsumerModel(Guid.NewGuid().ToString(), consumerName);
                    consumer.HitCount = 0;
                    consumer.isActive = true;
                    consumer.ModifiedOn = DateTime.Now;

                    // Create the TableOperation that inserts the customer entity.
                    TableOperation insertOperation = TableOperation.Insert(consumer);
                    // Execute the insert operation.
                    await table.ExecuteAsync(insertOperation);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async static Task<bool> ManageConsumer(string consumerName, string consumerKey, string adminKey, string isActive)
        {
            try
            {
                TableOperation retrieveAdmin = TableOperation.Retrieve<CirConsumerModel>("Admin", adminKey);
                TableResult retrievedAdminResult = await table.ExecuteAsync(retrieveAdmin);
                if (retrievedAdminResult.Result != null)
                {
                    TableOperation retrieveOperation = TableOperation.Retrieve<CirConsumerModel>(consumerName, consumerKey);
                    // Execute the operation.
                    TableResult retrievedResult = await table.ExecuteAsync(retrieveOperation);
                    // Assign the result to a CirAzureConsumerDetail object.
                    CirConsumerModel updateEntity = (CirConsumerModel)retrievedResult.Result;
                    if (updateEntity != null)
                    {
                        updateEntity.isActive = (isActive == "true") ? true : false;
                        updateEntity.ModifiedOn = DateTime.Now;
                        // Create the Replace TableOperation.
                        TableOperation updateOperation = TableOperation.Replace(updateEntity);
                        // Execute the operation.
                        await table.ExecuteAsync(updateOperation);
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

