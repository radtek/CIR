using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;

namespace Cir.Azure.Functions
{
    class GetRepairBrrHandlerMock : IHttpHandler
    {
        public async Task<HttpResponseMessage> HandleAsync(HttpRequest req, ILogger log, string id = null)
        {
            try
            {
                CloudBlobClient blobClient;
                CloudBlobContainer container;
                var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=cirblobstoragedev;AccountKey=MeW/7vHcnbWXi2NU7Fl0r/DgiQK1ARiqfRLXZp8BsrPArm9TG4t1ZH0xWz5ZkXUWmqFmNcIxYBw9k9iXkjGMGA==;EndpointSuffix=core.windows.net");
                blobClient = storageAccount.CreateCloudBlobClient();
                container = blobClient.GetContainerReference("cirdevcontainer");
                if (container.ExistsAsync().Result)
                {
                    string birDirectoryName = $"12345/BIR/PDF/069b290f-f6cb-4d54-9236-6b8dd3a65e92.pdf";
                    var sasBlobUri = GetBlobSasUri.GetByBlobName(birDirectoryName, container);
                    CloudBlockBlob blob = new CloudBlockBlob(sasBlobUri);
                    await blob.FetchAttributesAsync();

                    long pdfByteLength = blob.Properties.Length;
                    Byte[] pdfByteArray = new Byte[pdfByteLength];
                    await blob.DownloadToByteArrayAsync(pdfByteArray, 0);
                    String pdfDataString = Convert.ToBase64String(pdfByteArray);

                    var response = new RepairBrrDto
                    {
                        Brrs = new List<RepairBrr>
                        {
                            new RepairBrr
                            {
                                RepairId = "3",
                                Filename = blob.Metadata.ContainsKey("fileName") ? blob.Metadata["fileName"] + ".pdf" : "bir.pdf",
                                BrrDataString = pdfDataString
                            }
                        }
                    };
                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ObjectContent<RepairBrrDto>(response, new JsonMediaTypeFormatter())
                    };
                }
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            catch (QueryParameterException e)
            {
                log.LogError(e.StackTrace, e);
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(e.Message)
                };
            }
            catch (Exception e)
            {
                log.LogError(e.StackTrace, e);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(e.Message)
                };
            }
        }
    }
}
