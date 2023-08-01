namespace StatisticsRepository.MongoDB.Scaffolding;

public class MongoSettings
{
    public const string SectionKey = "MongoSettings";

    public string? ConnectionString { get; set; }
    public string? DatabaseName { get; set; }
    public string? PlayersCollectionName { get; set; }
}
