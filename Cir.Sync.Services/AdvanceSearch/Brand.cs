using System.Runtime.Serialization;

namespace Cir.Sync.Services.AdvanceSearch
{
    /// <summary>
    /// Entity of Brand
    /// </summary>
    [DataContract]
    public class Brand
    {
        [DataMember]
        public string BrandId { get; set; }

        [DataMember]
        public string BrandName { get; set; }
    }
}