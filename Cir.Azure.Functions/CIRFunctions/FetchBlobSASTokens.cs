using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions.CIRFunctions
{
    public static class FetchBlobSASTokens
    {
        [FunctionName("FetchBlobSASTokens")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequest req, ILogger log)
        {
            try
            {
                
                string guid = req.Query.FirstOrDefault(q => string.Compare(q.Key, "cirGuid", true) == 0).Value;
                string turbineNumber = req.Query.FirstOrDefault(q => string.Compare(q.Key, "turbineNumber", true) == 0).Value;
                string docType = req.Query.FirstOrDefault(q => string.Compare(q.Key, "docType", true) == 0).Value;
                CloudStorageAccount defaultStorageAccount = CloudStorageAccount.Parse(Environment.GetEnvironmentVariable("AzureStorageConnectionString"));
                CloudBlobClient defaultBlobClient = defaultStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = defaultBlobClient.GetContainerReference(Environment.GetEnvironmentVariable("AzureStorageContainerName"));
                string BlobUrl = string.Empty;
                var getBlobLists = await container.ListBlobsSegmentedAsync($"{turbineNumber}/{docType}/{guid}/", true, BlobListingDetails.Metadata, null, null, null, null);
                if (getBlobLists.Results.Count() > 0 )
                {
                    BlobUrl = System.Environment.GetEnvironmentVariable("BlobStorage0");
                }
                else
                {
                    // selection of Blob Storage Account
                    int blobStorageNumber = GetHashValue(guid);
                    if (blobStorageNumber >= 0)
                    {
                        BlobUrl = System.Environment.GetEnvironmentVariable("BlobStorage" + blobStorageNumber);
                    }
                    else
                    {
                           return new HttpResponseMessage(HttpStatusCode.BadRequest)
                        {
                            Content = new StringContent("Cannot find the Blob Storage")
                        };                         
                    }

                }
                string sasBlobToken = string.Empty;
                var storageAccount = CloudStorageAccount.Parse(BlobUrl);
                var blobClient = storageAccount.CreateCloudBlobClient();
                var binaryDataFileName = $"{turbineNumber}/{docType}/{guid}";
                switch (storageAccount.BlobEndpoint.Host.ToString())
                {
                    case "cirprodblobstorage.blob.core.windows.net":
                        sasBlobToken = "?sv=2018-03-28&ss=bfqt&srt=sco&sp=rwdlacup&se=2025-06-08T02:42:07Z&st=2019-06-07T18:42:07Z&spr=https,http&sig=Pdu5IjKyu8WUc7DUPrkamKvXOu4Ng0SIgA9xVjUzmK0%3D";
                        break;
                    case "cirprodblobstorage1.blob.core.windows.net":
                        sasBlobToken = "?sv=2018-03-28&ss=bfqt&srt=sco&sp=rwdlacup&se=2025-06-08T00:08:48Z&st=2019-06-07T16:08:48Z&spr=https,http&sig=m9aEkTvA6vFJB25iMRmtlqsOLt2Rw1JclpqtBWLStD0%3D";
                        break;
                    case "cirprodblobstorage2.blob.core.windows.net":
                        sasBlobToken = "?sv=2018-03-28&ss=bfqt&srt=sco&sp=rwdlacup&se=2025-06-08T00:08:03Z&st=2019-06-07T16:08:03Z&spr=https,http&sig=%2BmdUJ1kUrb7vmoZLK3nngV5LNTbNaABMO1FKFu84d8A%3D";
                        break;
                    case "cirprodblobstorage3.blob.core.windows.net":
                        sasBlobToken = "?sv=2018-03-28&ss=bfqt&srt=sco&sp=rwdlacup&se=2025-06-08T00:07:33Z&st=2019-06-07T16:07:33Z&spr=https,http&sig=TmQrYkqlb8cPK3KnI9c3yIC2QlY%2F8RteU3GGtpAxZMs%3D";
                        break;
                    case "cirprodblobstorage4.blob.core.windows.net":
                        sasBlobToken = "?sv=2018-03-28&ss=bfqt&srt=sco&sp=rwdlacup&se=2025-06-08T00:06:58Z&st=2019-06-07T16:06:58Z&spr=https,http&sig=1eS3RXDozAYDq9KNZ9AEGa9zhBPgrtC1AcR4a%2Bc%2Beww%3D";
                        break;
                    case "cirprodblobstorage5.blob.core.windows.net":
                        sasBlobToken = "?sv=2018-03-28&ss=bfqt&srt=sco&sp=rwdlacup&se=2025-06-08T00:06:22Z&st=2019-06-07T16:06:22Z&spr=https,http&sig=tKrbJzAKYQaELBlYxqNe7sBvc39UhoCgFBqeYhZ%2FAsk%3D";
                        break;
                    case "cirprodblobstorage6.blob.core.windows.net":
                        sasBlobToken = "?sv=2018-03-28&ss=bfqt&srt=sco&sp=rwdlacup&se=2025-06-08T00:05:35Z&st=2019-06-07T16:05:35Z&spr=https,http&sig=opPXLIT17hzaD01VRifYtoRiTlV189RBkizeO7P0%2Fj8%3D";
                        break;
                    case "cirprodblobstorage7.blob.core.windows.net":
                        sasBlobToken = "?sv=2018-03-28&ss=bfqt&srt=sco&sp=rwdlacup&se=2025-06-08T00:06:04Z&st=2019-06-07T16:06:04Z&spr=https,http&sig=lDg4SAcF%2BF6Qw8oBDJs%2FQSVclg79XVyZ%2BiXdCUNWtG8%3D";
                        break;
                    case "cirprodblobstorage8.blob.core.windows.net":
                        sasBlobToken = "?sv=2018-03-28&ss=bfqt&srt=sco&sp=rwdlacup&se=2025-06-08T00:04:54Z&st=2019-06-07T16:04:54Z&spr=https,http&sig=JLQd5u1aXfkGlqFK1fo%2B44QxfqmGtY8x2mbUjxqoAaw%3D";
                        break;
                    case "cirprodblobstorage9.blob.core.windows.net":
                        sasBlobToken = "?sv=2018-03-28&ss=bfqt&srt=sco&sp=rwdlacup&se=2025-06-08T00:03:32Z&st=2019-06-07T16:03:32Z&spr=https,http&sig=fz9FfA7Y1t7DZJaVJR7DJXQd858xqrztvd8uw2wTOf8%3D";
                        break;
                    case "cirprodblobstorage10.blob.core.windows.net":
                        sasBlobToken = "?sv=2018-03-28&ss=bfqt&srt=sco&sp=rwdlacup&se=2025-06-08T00:02:32Z&st=2019-06-07T16:02:32Z&spr=https,http&sig=kCzM4UxGsi3QrmUxspTUp47p%2BI1T3x%2F9SSFlHhWVE%2Bs%3D";
                        break;
                    case "cirprodblobstorage11.blob.core.windows.net":
                        sasBlobToken = "?sv=2018-03-28&ss=bfqt&srt=sco&sp=rwdlacup&se=2025-06-08T00:01:01Z&st=2019-06-07T16:01:01Z&spr=https,http&sig=rhLuWJgpBE7nh2skFLgvTrUdZFUY7IiBzDZneAlkg6E%3D";
                        break;
                    case "cirprodblobstorage12.blob.core.windows.net":
                        sasBlobToken = "?sv=2018-03-28&ss=bfqt&srt=sco&sp=rwdlacup&se=2025-06-08T00:00:03Z&st=2019-06-07T16:00:03Z&spr=https,http&sig=q3REZlYfB1xxVHgYYZ9REb2%2B2QDLFsYZAD2eVYo4O8I%3D";
                        break;
                    case "cirprodblobstorage13.blob.core.windows.net":
                        sasBlobToken = "?sv=2018-03-28&ss=bfqt&srt=sco&sp=rwdlacup&se=2025-06-07T23:59:03Z&st=2019-06-07T15:59:03Z&spr=https,http&sig=AAFCYmBE%2B%2FYDwDe7lUuZhS97CF2iVKbQNa6nOyNHqiU%3D";
                        break;
                    case "cirprodblobstorage14.blob.core.windows.net":
                        sasBlobToken = "?sv=2018-03-28&ss=bfqt&srt=sco&sp=rwdlacup&se=2025-06-07T23:56:10Z&st=2019-06-07T15:56:10Z&spr=https,http&sig=ZRjtl9ek7hBZQEQWB0E3faJLbEBOk5fIcl883YWE2h0%3D";
                        break;
                    case "cirprodblobstorage15.blob.core.windows.net":
                        sasBlobToken = "?sv=2018-03-28&ss=bfqt&srt=sco&sp=rwdlacup&se=2025-06-07T23:54:32Z&st=2019-06-07T15:54:32Z&spr=https,http&sig=RQ0A5IcPtN4bZCLnaPgF0s3KZeRpR3yPuxzS2QyncBY%3D";
                        break;
                    default:
                        break;
                }
                BlobResponseModel responseSas = new BlobResponseModel();
                responseSas.SASKey = sasBlobToken;
                responseSas.BlobUri = storageAccount.BlobEndpoint;
                responseSas.ContainerName = container;
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new  ObjectContent<BlobResponseModel>(responseSas                       
                    , new JsonMediaTypeFormatter())
                };                
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.Message)
                };                
            }
        }
        public static int GetHashValue(string guid)
        {
            try
            {
                byte[] tmpSource;
                byte[] tmpHash;
                tmpSource = ASCIIEncoding.ASCII.GetBytes(guid);
                //Compute hash based on source data.
                tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
                //compute integer values from hash 
                int intVal = Math.Abs(BitConverter.ToInt32(tmpHash, 0));
                //calculate storage partitions 0-15
                int strgPart = intVal % 15;
                return strgPart;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }
    }
}
