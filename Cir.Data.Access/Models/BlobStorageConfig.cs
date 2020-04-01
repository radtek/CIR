using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Data.Access.Models
{
    internal class BlobStorageConfig
    {
        public string AzureStorageConnectionString { get; private set; }
        public string AzureStorageContainerName { get; private set; }

        public BlobStorageConfig(string azureStorageConnectionString, string azureStorageContainerName)
        {
            AzureStorageConnectionString = azureStorageConnectionString;
            AzureStorageContainerName = azureStorageContainerName;
        }
    }
}
