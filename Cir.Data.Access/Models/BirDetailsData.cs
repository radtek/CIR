using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Cir.Data.Access.Models
{
    public class BirDetailsData : ICosmosDbIDataModel,IDataModel
    {
      
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        
        [JsonProperty(PropertyName = "partition")]
        public string Partition { get; set; }  //=> "partition";

        [JsonProperty(PropertyName = "birCode")]
        public string BirCode { get; set; }

        [JsonProperty(PropertyName = "revisionNumber")]
        public int RevisionNumber { get; set; }

        [JsonProperty(PropertyName = "repairingSolutions")]
        public string RepairingSolutions { get ; set; }

        [JsonProperty(PropertyName = "rawMaterials")]
        public string RawMaterials { get ; set; }

        [JsonProperty(PropertyName = "conclusionsAndRecommendations")]
        public string ConclusionsAndRecommendations { get ; set; }

        [JsonProperty(PropertyName = "cirIds")]
        public List<string> CirIDs { get ; set; }
        
        [JsonProperty(PropertyName = "masterId")]
        public string MasterId { get ; set; }
        
        [JsonProperty(PropertyName = "turbineId")]
        public string TurbineId { get ; set; }
        
        [JsonProperty(PropertyName = "created")]
        public DateTime Created { get ; set; }
        
        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get ; set; }
        
        [JsonProperty(PropertyName = "modified")]
        public DateTime Modified { get ; set; }
        
        [JsonProperty(PropertyName = "modifiedBy")]
        public string ModifiedBy { get ; set; }
    
        [JsonProperty(PropertyName = "deleted")]
        public bool Deleted { get ; set; }

        [JsonProperty(PropertyName = "bladeSerialNos")]
        public string BladeSerialNos { get ; set; }

      
    }
}