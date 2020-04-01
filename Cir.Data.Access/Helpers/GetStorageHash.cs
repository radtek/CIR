using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Cir.Data.Access.Helpers
{

    public static class GetStorageHash
    {
        private const string storageConnection = "AzureStorageConnectionString";
        private static readonly string noOfStorages = ConfigurationManager.AppSettings["NoOfStorages"];

        public static CloudStorageAccount GetStorageAccount(string cirId)
        {
            byte[] tmpSource;
            byte[] tmpHash;
            //CloudStorageAccount[] storageBaseUrl = storageAccounts.ToArray();
            tmpSource = ASCIIEncoding.ASCII.GetBytes(cirId);
            //Compute hash based on source data.
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            //compute integer values from hash 
            int intVal = Math.Abs(BitConverter.ToInt32(tmpHash, 0)); 
            int strgPart = intVal % 15;
            if(strgPart>0)
            return CloudStorageAccount.Parse(ConfigurationManager.AppSettings[storageConnection + strgPart]);
            else
            return CloudStorageAccount.Parse(ConfigurationManager.AppSettings[storageConnection]);
        }
    }
}
