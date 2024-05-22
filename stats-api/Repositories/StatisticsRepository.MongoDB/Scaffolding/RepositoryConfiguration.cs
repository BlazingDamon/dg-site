using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using StatisticsRepository.Core.Players;
using StatisticsRepository.MongoDB.Players;

namespace StatisticsRepository.MongoDB.Scaffolding;
public static class RepositoryConfiguration
{
    public static IServiceCollection AddMongoRepositories(this IServiceCollection services, MongoSettings mongoSettings)
    {
        services.AddSingleton(new MongoClient(mongoSettings.ConnectionString));
        services.AddScoped<IPlayerRepository, PlayerRepository>();

        var camelCaseConvention = new ConventionPack { new CamelCaseElementNameConvention() };
        ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);

        return services;
    }
}
