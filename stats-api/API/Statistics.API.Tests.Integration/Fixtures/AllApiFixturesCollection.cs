namespace Statistics.API.Tests.Integration.Fixtures;

[CollectionDefinition(nameof(AllApiFixturesCollection))]
public class AllApiFixturesCollection :
    ICollectionFixture<WebApplicationFixture>,
    ICollectionFixture<MongoFixture>
{
}
