using MongoDB.Driver;
using Testcontainers.MongoDb;

namespace Statistics.API.Tests.Integration.Fixtures;

public class MongoFixture : IAsyncLifetime
{
    private readonly MongoDbContainer _mongoDbContainer;
    private IMongoClient? _mongoClient;
    public string? DefaultConnectionString { get; set; }

    public MongoFixture()
    {
        _mongoDbContainer = new MongoDbBuilder().Build();
    }

    public async Task InitializeAsync()
    {
        await _mongoDbContainer.StartAsync();

        DefaultConnectionString = _mongoDbContainer.GetConnectionString();
    }

    public async Task DisposeAsync()
    {
        await _mongoDbContainer.DisposeAsync();
    }
}
