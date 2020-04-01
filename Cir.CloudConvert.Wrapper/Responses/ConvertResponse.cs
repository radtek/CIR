using System.IO;

namespace Cir.CloudConvert.Wrapper.Responses
{
    /// <summary>
    /// This represents the convert response entity.
    /// </summary>
    public class ConvertResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the HTTP status code.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the Response Stream.
        /// </summary>
        public string ResponseString { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string Error { get; set; }
    }
}