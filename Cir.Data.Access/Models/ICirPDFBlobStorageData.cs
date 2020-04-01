namespace Cir.Data.Access.Models
{
    public interface ICirPDFBlobStorageData
    {
        long PDFId { get; set; }
        byte[] PDFData { get; set; }
        int CIRState { get; set; }
        string CIRTemplateGUID { get; set; }
        string CIRName { get; set; }
        string CIRID { get; set; }
        string TurbineNumber { get; set; }
        string BlobGuid { get; set; }
        string Url { get; set; }
        string Modified { get; set; }       
        string Revision { get; set; }
    }
}
