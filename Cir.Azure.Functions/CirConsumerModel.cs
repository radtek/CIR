using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class CirConsumerModel : TableEntity
    {
        public CirConsumerModel(string ConsumerKey, string ConsumerName)
        {
            this.PartitionKey = ConsumerName;
            this.RowKey = ConsumerKey;
        }

        public CirConsumerModel() { }

        public long HitCount { get; set; }

        public bool isActive { get; set; }

        public DateTime ModifiedOn { get; set; }

    }
}
