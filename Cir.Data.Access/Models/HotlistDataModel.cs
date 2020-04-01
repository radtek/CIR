using Newtonsoft.Json;

namespace Cir.Data.Access.Models
{
    public class HotlistDataModel : IDataModel, ICosmosDbIDataModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "partition")]
        public string Partition { get; set; }  //=> "partition";

        /// <summary>
        /// Legacy Field. Curently we use Azure storage and Template field.
        /// </summary>
        [JsonProperty(PropertyName = "reportTypeId")]
        public long? ReportTypeId { get; set; }

        [JsonProperty(PropertyName = "vestasItemNumber")]
        public string VestasItemNumber { get; set; }

        [JsonProperty(PropertyName = "vestasItemName")]
        public string VestasItemName { get; set; }

        [JsonProperty(PropertyName = "manufacturerName")]
        public string ManufacturerName { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "cc")]
        public string Cc { get; set; }

        [JsonProperty(PropertyName = "hotItemDisplay")]
        public string HotItemDisplay { get; set; }

        [JsonProperty(PropertyName = "hotItemId")]
        public long HotItemId { get; set; }

        [JsonProperty(PropertyName = "reportType")]
        public string ReportType { get; set; }

        [JsonProperty(PropertyName = "brand")]
        public BrandDataModel Brand { get; set; }

        [JsonProperty(PropertyName = "CirTemplate")]
        public CirTemplateShortDataModel CirTemplate { get; set; }
    }
}
