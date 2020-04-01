namespace Cir.Data.Access.Models
{
    public interface ICirBlobStorageData
    {
        string CirID { get; set; }
        string ImageUrl { get; set; }
        string FileName { get; set; }
        string BinaryData { get; set; }
        string ContentType { get; }
    }
}
