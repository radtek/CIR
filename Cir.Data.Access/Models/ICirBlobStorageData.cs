namespace Cir.Data.Access.Models
{
    public interface ICirBlobStorageData
    {
        string BlobGuid { get; set; }
        string CirId { get; set; }
        string TemplateId { get; set; }
        string Url { get; set; }
        string BinaryDataUrl { get; set; }
        string BinaryData { get; set; }
        string ContentType { get; }
        string BinaryContentType { get; }
        string TurbineNumber { get; set; }
    }
}
