namespace Rebar.Models
{
    public interface IRebarStoreDatabaseSettings
    {
        string ShakeCollectionName { get; set; }
        string OrderCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
