using Cir.Data.Access.Helpers;
using Cir.Data.Access.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace CirCosmosDataSync
{
    public class ImageData
    {
        private CloudBlobClient blobClient;
        CloudBlobContainer container;
        private static readonly string containerName = System.Configuration.ConfigurationManager.AppSettings["AzureStorageContainerName"];

        public ImageData()
        {
            var storageAccount = CloudStorageAccount.Parse(System.Configuration.ConfigurationManager.AppSettings["AzureStorageConnectionString"]);
            blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference(containerName);
            //container.CreateIfNotExists();
        }

        //////--------------Code to Insert Revision History in Blob Storage-----------
        public void InsertRevisionHistory(CirSubmissionData cir)
        {
            try
            {
                string dataType = "CIR", blobType = "RevisionHistory", contentType = "json";
                //checked  the directory structure
                if (!(container.GetDirectoryReference($"{cir.Data.txtTurbineNumber}/{dataType}/{cir.Id}").ListBlobs().Count() > 0))
                {
                    CloudStorageAccount storageAccount = GetStorageHash.GetStorageAccount(cir.Id);
                    blobClient = storageAccount.CreateCloudBlobClient();
                    container = blobClient.GetContainerReference(containerName);
                }
                //end
                var cirList = container.ListBlobsSegmented($"{cir.Data.txtTurbineNumber}/{dataType}/{cir.Id}/{blobType}/", true, BlobListingDetails.Metadata, null, null, null, null);
                var latestCirRevision = cirList.Results.OfType<CloudBlob>().Where(b => (b.Metadata.ContainsKey("revision") && Convert.ToInt32(b.Metadata["revision"]) == cir.Revision)).OrderByDescending(b => b.Properties.LastModified).Take(1);
                if (latestCirRevision.Count() > 0)
                {
                    foreach (CloudBlob item in latestCirRevision)
                    {
                        CloudBlockBlob blob = (CloudBlockBlob)item;
                        blob.FetchAttributes();

                        var revision = new CirRevisionDetails
                        {
                            CirSubmissionData = cir
                        };
                        revision.CirSubmissionData.Schema = "";
                        using (var ms = new MemoryStream())
                        {
                            LoadStreamWithJson(ms, revision);
                            blob.UploadFromStream(ms);
                        }
                    }
                }

                else
                {
                    var guidKey = GetKey(container);
                    var binaryDataFileName = $"{cir.Data.txtTurbineNumber}/{dataType}/{cir.Id}/{blobType}/{guidKey}.{contentType}";
                    CloudBlockBlob binaryDataBlockBlob = container.GetBlockBlobReference(binaryDataFileName);
                    var revision = new CirRevisionDetails
                    {
                        CirSubmissionData = cir
                    };
                    binaryDataBlockBlob.Metadata.Add("revision", cir.Revision.ToString());
                    revision.CirSubmissionData.Schema = "";
                    using (var ms = new MemoryStream())
                    {
                        LoadStreamWithJson(ms, revision);
                        binaryDataBlockBlob.UploadFromStream(ms);
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void LoadStreamWithJson(Stream ms, CirRevisionDetails revision)
        {
            var json = JsonConvert.SerializeObject(revision);
            StreamWriter writer = new StreamWriter(ms);
            writer.Write(json);
            writer.Flush();
            ms.Position = 0;
        }

        private string GetKey(CloudBlobContainer container)
        {
            string key = Guid.NewGuid().ToString();
            CloudBlockBlob blockBlob = new CloudBlockBlob(GetBlobSASUri(key, "CreateBlob"));
            return (!blockBlob.Exists()) ? key : GetKey(container);
        }

        ////--------------------- Upload Desktop Application files from Local disk to Blob --------------
        public void InsertBlobAsByteArray()
        {
            //try
            //{
            //    //var blobs = container.ListBlobs();
            //    //foreach (IListBlobItem blobItem in blobs)
            //    //{
            //    //    CloudBlockBlob Blob = new CloudBlockBlob(new Uri(blobItem.Uri.ToString()));
            //    //    CloudBlockBlob blockBlob = new CloudBlockBlob(GetBlobSASUri(Blob.Name, "DeleteBlob"));
            //    //    if (blockBlob.Exists())
            //    //    {
            //    //        blockBlob.DeleteIfExists();
            //    //    }
            //    //}

            //    string[] files = Directory.GetFiles(@"C:\BackUP\New folder\CIR.Electron.App\release-builds\CIR-Installers");
            //    foreach (string file in files)
            //    {
            //        using (var fileStream = File.OpenRead(file))
            //        {
            //            CloudBlockBlob binaryDataBlockBlob = new CloudBlockBlob(GetBlobSASUri(Path.GetFileName(file), "CreateBlob"));
            //            binaryDataBlockBlob.UploadFromStream(fileStream);
            //        }
            //        BlobContainerPermissions permissions = new BlobContainerPermissions();
            //        permissions.PublicAccess = BlobContainerPublicAccessType.Container;
            //        container.SetPermissionsAsync(permissions);
            //    }
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
        }

        public string GetByImageUrl(string imageUrl)
        {
            try
            {
                string retVal = string.Empty;
                CloudBlockBlob Blob = new CloudBlockBlob(new Uri(imageUrl));
                Uri sasBlobUri = GetBlobSASUri(Blob.Name, "ReadBlob");
                return sasBlobUri.AbsoluteUri;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Uri GetBlobSASUri(string blobName, string policyName)
        {
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
            var storedPolicy = new SharedAccessBlobPolicy()
            {
                SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(10),
                Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.Create | SharedAccessBlobPermissions.Delete
            };
            var permissions = container.GetPermissions();
            permissions.SharedAccessPolicies.Clear();
            permissions.SharedAccessPolicies.Add(policyName, storedPolicy);
            container.SetPermissions(permissions);
            var sasBlobToken = blockBlob.GetSharedAccessSignature(null, policyName);
            Uri blobUri = new Uri(blockBlob.Uri + sasBlobToken);
            return blobUri;
        }

        //////--------------------- Upload Template from Local disk to Cosmos --------------
        //public void UpdateTemplate()
        //{
        //    string[] files = Directory.GetFiles(@"C:\CIR Vestas\Sprint6.2-SyncProcess\CIRTemplates_Form.io");
        //    foreach (string file in files)
        //    {
        //        var fileData = File.ReadAllText(file);
        //        CirTemplateDataModel templateData = JsonConvert.DeserializeObject<CirTemplateDataModel>(fileData);
        //        templateData.VersionNumber = 1;
        //        Functions._documentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(Functions.DatabaseId, Functions.CirTemplates, templateData.Id), templateData).ConfigureAwait(false);
        //    }
        //}



        //////--------------------- Migrate Revision History To Blob storage --------------
        //public void MigrateRevisionHistoryToBlob()
        //{
        //    string stQry = "SELECT TOP 10 * FROM CirReportHistory";
        //    List<CirRevisionDetails> reports = Functions._documentClient.CreateDocumentQuery<CirRevisionDetails>(
        //                      UriFactory.CreateDocumentCollectionUri(Functions.DatabaseId, "CirReportHistory"),
        //                stQry, new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true }).ToList<CirRevisionDetails>();
        //    foreach (var report in reports)
        //    {
        //        InsertRevisionHistory(report);
        //    }
        //}

        //protected void InsertRevisionHistory(CirRevisionDetails revisionHistory)
        //{
        //    try
        //    {
        //        string dataType = "CIR", blobType = "RevisionHistory", contentType = "json";
        //        var guidKey = GetKey(container);
        //        var binaryDataFileName = $"{revisionHistory.CirSubmissionData.Data.txtTurbineNumber}/{dataType}/{revisionHistory.CirSubmissionData.Id}/{blobType}/{guidKey}.{contentType}";
        //        CloudBlockBlob binaryDataBlockBlob = new CloudBlockBlob(GetBlobSASUri(binaryDataFileName, "CreateBlob"));
        //        binaryDataBlockBlob.Properties.ContentType = contentType;
        //        revisionHistory.Id = guidKey;
        //        using (var ms = new MemoryStream())
        //        {
        //            LoadStreamWithJson(ms, revisionHistory);
        //            binaryDataBlockBlob.UploadFromStreamAsync(ms).Wait();
        //        }
        //        DeleteDocument(revisionHistory);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        //protected void DeleteDocument(CirRevisionDetails revisionHistory)
        //{
        //    Document report = Functions._documentClient.CreateDocumentQuery(
        //       UriFactory.CreateDocumentCollectionUri(Functions.DatabaseId, "CirReportHistory"),
        //       new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
        //       .Where(r => r.Id == revisionHistory.Id)
        //       .AsEnumerable()
        //       .FirstOrDefault();

        //    Functions._documentClient.DeleteDocumentAsync(report.SelfLink,
        //        new RequestOptions { PartitionKey = new PartitionKey(keyValue: ((CirRevisionDetails)(dynamic)report).Partition) })
        //        .ConfigureAwait(false);
        //}

        //private string GetKey(CloudBlobContainer container)
        //{
        //    string key = Guid.NewGuid().ToString();
        //    CloudBlockBlob blockBlob = new CloudBlockBlob(GetBlobSASUri(key, "CreateBlob"));
        //    return (!blockBlob.Exists()) ? key : GetKey(container);
        //}

        //private void LoadStreamWithJson(Stream ms, CirRevisionDetails revision)
        //{
        //    var json = JsonConvert.SerializeObject(revision);
        //    StreamWriter writer = new StreamWriter(ms);
        //    writer.Write(json);
        //    writer.Flush();
        //    ms.Position = 0;
        //}

        ////--------------------- Migrate BIR data To Blob storage dev container--------------
        //public void MigrateBIRData()
        //{
        //    for (int i = 0; i > -1; i++)
        //    {
        //        List<BirDetailData> reports = Functions._documentClient.CreateDocumentQuery<BirDetailData>(
        //                          UriFactory.CreateDocumentCollectionUri(Functions.DatabaseId, "BirReportData"),
        //                    new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true }).Take(100).ToList<BirDetailData>();
        //        if(reports.Count == 0)
        //        {
        //            i = -5;
        //        }
        //        foreach (var report in reports)
        //        {
        //            MigrateBirFile(report);
        //        }
        //    }
        //}

        //protected void MigrateBirFile(BirDetailData birData)
        //{
        //    try
        //    {
        //        var sourceContainer = blobClient.GetContainerReference("birreportcontainer");
        //        CloudBlockBlob sourceBlob = new CloudBlockBlob(new Uri(birData.WordBytesUrl));

        //        var destinationContainer = blobClient.GetContainerReference("cirdevcontainer");
        //        string blobType = "BIR";
        //        var binaryDataFileName = $"{birData.TurbineId}/{blobType}/{sourceBlob.Name}";
        //        CloudBlockBlob destinationBlob = new CloudBlockBlob(GetBlobSASUri(binaryDataFileName, "CreateBlob"));

        //        destinationBlob.StartCopy(sourceBlob);
        //        //sourceBlob.Delete(DeleteSnapshotsOption.IncludeSnapshots);
        //        birData.WordBytesUrl = destinationBlob.Uri.AbsoluteUri.ToString();
        //        Functions._documentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(Functions.DatabaseId, "BirReportData", birData.Id), birData).ConfigureAwait(false);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
    }

    //public class BirDetailData
    //{

    //    [JsonProperty(PropertyName = "id")]
    //    public string Id { get; set; }

    //    [JsonProperty(PropertyName = "partition")]
    //    public string Partition { get; set; }  //=> "partition";

    //    [JsonProperty(PropertyName = "birCode")]
    //    public string BirCode { get; set; }

    //    [JsonProperty(PropertyName = "birDataID")]
    //    public long BirDataID { get; set; }

    //    [JsonProperty(PropertyName = "revisionNumber")]
    //    public int RevisionNumber { get; set; }

    //    [JsonProperty(PropertyName = "repairingSolutions")]
    //    public string RepairingSolutions { get; set; }

    //    [JsonProperty(PropertyName = "rawMaterials")]
    //    public string RawMaterials { get; set; }

    //    [JsonProperty(PropertyName = "conclusionsAndRecommendations")]
    //    public string ConclusionsAndRecommendations { get; set; }

    //    [JsonProperty(PropertyName = "cirIds")]
    //    public string CirIDs { get; set; }

    //    [JsonProperty(PropertyName = "masterId")]
    //    public string MasterId { get; set; }

    //    [JsonProperty(PropertyName = "turbineId")]
    //    public string TurbineId { get; set; }

    //    [JsonProperty(PropertyName = "created")]
    //    public DateTime Created { get; set; }

    //    [JsonProperty(PropertyName = "createdBy")]
    //    public string CreatedBy { get; set; }

    //    [JsonProperty(PropertyName = "modified")]
    //    public DateTime Modified { get; set; }

    //    [JsonProperty(PropertyName = "modifiedBy")]
    //    public string ModifiedBy { get; set; }

    //    [JsonProperty(PropertyName = "deleted")]
    //    public bool Deleted { get; set; }

    //    [JsonProperty(PropertyName = "bladeSerialNos")]
    //    public string BladeSerialNos { get; set; }

    //    [JsonProperty(PropertyName = "wordBytesUrl")]
    //    public string WordBytesUrl { get; set; }
    //}
}
