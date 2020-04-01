namespace Cir.Data.Access.Models
{
    /// <summary>
    /// Consists properties not needed for Report object from buisness point, 
    /// but required by Azure CosmnosDB
    /// </summary>
    interface ICosmosDbIDataModel
    {
        string Partition { get; }
    }
}
