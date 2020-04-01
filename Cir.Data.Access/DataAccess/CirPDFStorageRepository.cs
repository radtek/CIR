using System;
using Cir.Data.Access.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Cir.Data.Access.Services;

namespace Cir.Data.Access.DataAccess
{
    internal class CirPDFStorageRepository : BlobPDfStorageRepository<PDFModel>, ICirPDFStorageRepository
    {
        public CirPDFStorageRepository(BlobStorageConfig config) : base(config) { }        

        public PDFModel AddPDF(PDFModel pdfData)
        {
            try
            {
                var blobkBlobByte = InsertBlobPdfAsByteArray(pdfData);
                pdfData.Url = blobkBlobByte.Uri.AbsoluteUri;
                pdfData.PDFData = new byte[] { };
                return pdfData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte[] GetPDF(long turbine, string cirGUID, int revision, long cirId = 0)
        {
            byte[] pdfBytes = new byte[0];
            try
            {
                var blobkBloPdfByte = GetPdfBytesFromBlob(turbine, cirGUID, revision, cirId);
                pdfBytes = blobkBloPdfByte;
                return pdfBytes;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<byte[]> GeneratePDF(CirSubmissionData cirData)
        {
            return await new CreateCIRPdf().callRenderReport(cirData).ConfigureAwait(false);
        }
    }
}