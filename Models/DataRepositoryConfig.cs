namespace Cir.Data.Access.Models
{
    internal class DataRepositoryConfig
    {
        public string EndpointUri { get; private set; }
        public string PrimaryKey { get; private set; }
        public string DatabaseId { get; private set; }
        public string CollectionId { get; private set; }

        public DataRepositoryConfig(string endpointUri, string primaryKey, string databaseId, string collectionId)
        {
            EndpointUri = endpointUri;
            PrimaryKey = primaryKey;
            DatabaseId = databaseId;
            CollectionId = collectionId;
        }
    }
}
