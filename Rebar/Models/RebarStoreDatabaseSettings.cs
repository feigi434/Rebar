namespace Rebar.Models
{
    public class RebarStoreDatabaseSettings : IRebarStoreDatabaseSettings
    {
        public string ShakeCollectionName { get; set; } = String.Empty;
        public string OrderCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;   
        public string DatabaseName { get; set; } = String.Empty;
    }
}
