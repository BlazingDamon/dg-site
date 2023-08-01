using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Statistics.Domain.Exceptions;
using Statistics.Domain.Players;
using Statistics.Entities.Players;
using StatisticsRepository.Core.Players;
using StatisticsRepository.MongoDB.Scaffolding;
using Domain = Statistics.Domain;

namespace StatisticsRepository.MongoDB.Players;

// TODO: pass CancellationToken from controller layer down through repo layer
public class PlayerRepository : IPlayerRepository
{
    private readonly IMongoCollection<Player> _playersCollection;
    private readonly IMapper _mapper;

    public PlayerRepository(MongoClient mongoClient, IOptions<MongoSettings> mongoSettings, IMapper mapper)
    {
        IMongoDatabase database = mongoClient.GetDatabase(mongoSettings.Value.DatabaseName);
        _playersCollection = database.GetCollection<Player>(mongoSettings.Value.PlayersCollectionName);

        _mapper = mapper;
    }

    public async Task<PlayerDTO> CreatePlayer(PlayerDTO player)
    {
        Player playerToSave = _mapper.Map<Player>(player);

        await _playersCollection.InsertOneAsync(playerToSave);

        return player;
    }

    // TODO: soft delete instead of hard delete
    public async Task<Domain.Results.DeleteResult> DeletePlayerById(string playerId)
    {
        FilterDefinition<Player> filter = Builders<Player>.Filter.Where(p => p.PlayerId == playerId);
        var result = await _playersCollection.DeleteOneAsync(filter);

        if (result.DeletedCount == 0)
            throw new PlayerNotFoundException($"No player found with {nameof(Player.PlayerId)} matching {playerId}.");

        return new Domain.Results.DeleteResult { DeletedCount = result.DeletedCount };
    }

    public async Task<PlayerDTO> GetPlayerById(string playerId)
    {
        Player? player = await _playersCollection.AsQueryable()
            .Where(p => p.PlayerId == playerId)
            .FirstOrDefaultAsync();

        if (player is null)
            throw new PlayerNotFoundException($"No player found with {nameof(Player.PlayerId)} matching {playerId}.");

        return _mapper.Map<PlayerDTO>(player);
    }

    public async Task<IEnumerable<PlayerDTO>> GetTopPlayers()
    {
        throw new NotImplementedException();
    }

    public async Task<PlayerDTO> UpdatePlayer(PlayerDTO player)
    {
        Player playerToUpdate = _mapper.Map<Player>(player);

        var filter = Builders<Player>.Filter.Where(p => p.PlayerId == playerToUpdate.PlayerId);

        var result = await _playersCollection.ReplaceOneAsync(filter, playerToUpdate);

        if (result.MatchedCount == 0)
            throw new PlayerNotFoundException($"No player found with {nameof(Player.PlayerId)} matching {playerToUpdate.PlayerId}.");

        return player;
    }
}