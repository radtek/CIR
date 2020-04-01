namespace Cir.Data.Access.Models
{
    internal class DataRepositoryConfig
    {
        public string DatabaseId { get; private set; }
        public string CollectionId { get; private set; }

        public DataRepositoryConfig(string databaseId, string collectionId)
        {
            DatabaseId = databaseId;
            CollectionId = collectionId;
        }
    }
}
