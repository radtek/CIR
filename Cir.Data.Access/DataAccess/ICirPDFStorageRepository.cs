using Cir.Data.Access.Models;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cir.Data.Access.DataAccess
{
    internal interface ICirPDFStorageRepository
    {       
        PDFModel AddPDF(PDFModel imgData);
        byte[] GetPDF(long turbine, string cirGUID, int revision, long cirId = 0);
        Task<byte[]> GeneratePDF(CirSubmissionData cirData);
    };
}
