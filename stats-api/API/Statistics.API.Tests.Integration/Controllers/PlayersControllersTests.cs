using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Statistics.API.Tests.Integration.Fixtures;
using Statistics.Entities.Players;
using StatisticsRepository.MongoDB.Scaffolding;
using System.Net;

namespace Statistics.API.Tests.Integration.Controllers;

[Collection(nameof(AllApiFixturesCollection))]
public class PlayersControllersTests : IAsyncLifetime
{
    private readonly IMongoCollection<Player> _playersCollection;
    private readonly HttpClient _client; 

    // TODO: add tests for each endpoint
    public PlayersControllersTests(
        WebApplicationFixture webApplicationFixture,
        MongoFixture mongoFixture)
    {
        var fixtureConnectionString = mongoFixture.DefaultConnectionString;
        webApplicationFixture.ConfigurationOverrides[$"{MongoSettings.SectionKey}:{nameof(MongoSettings.ConnectionString)}"] = fixtureConnectionString!;

        _client = webApplicationFixture.CreateClient();

        MongoClient? mongoClient = webApplicationFixture.Services.GetService<MongoClient>();
        ArgumentNullException.ThrowIfNull(mongoClient, nameof(mongoClient));

        IOptions<MongoSettings>? mongoSettings = webApplicationFixture.Services.GetService<IOptions<MongoSettings>>();
        ArgumentNullException.ThrowIfNull(mongoSettings, nameof(mongoSettings));

        IMongoDatabase mongoDatabase = mongoClient.GetDatabase(mongoSettings.Value.DatabaseName);
        _playersCollection = mongoDatabase.GetCollection<Player>(mongoSettings.Value.PlayersCollectionName);
    }

    public async Task DisposeAsync()
    {
        await _playersCollection.DeleteManyAsync(Builders<Player>.Filter.Empty);
    }

    public async Task InitializeAsync()
    {
        await _playersCollection.InsertManyAsync(
            new List<Player>
            {
                new Player
                {
                    PlayerId = "1",
                    FirstName = "Paige",
                    LastName = "Pierce",
                    EventsCompleted = 1000,
                    Wins = 300
                }
            });
    }

    [Fact]
    public async Task GetPlayerById_IdMatches_PlayerReturned()
    {
        // Act
        var response = await _client.GetAsync("/players/1");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        // TODO: expand these asserts
    }

    [Fact]
    public async Task GetPlayerById_IdDoesNotMatch_PlayerNotFound()
    {
        // Act
        var response = await _client.GetAsync("/players/bogus-id");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        
        // TODO: expand these asserts
    }
}