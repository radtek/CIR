using Newtonsoft.Json;

namespace Cir.Azure.Functions
{
    public class BoundingBox
    {
        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }

        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }

        [JsonProperty(PropertyName = "top")]
        public int Top { get; set; }

        [JsonProperty(PropertyName = "left")]
        public int Left { get; set; }

    }
}
