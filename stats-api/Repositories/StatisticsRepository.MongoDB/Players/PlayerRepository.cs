using Statistics.Domain.Players;
using StatisticsRepository.Core.Players;

namespace StatisticsRepository.MongoDB.Players;

public class PlayerRepository : IPlayerRepository
{
    public PlayerDTO CreatePlayer(PlayerDTO player)
    {
        throw new NotImplementedException();
    }

    public Task DeletePlayerById(string playerId)
    {
        throw new NotImplementedException();
    }

    public PlayerDTO GetPlayerById(string playerId)
    {
        return new PlayerDTO();
    }

    public IEnumerable<PlayerDTO> GetTopPlayers()
    {
        throw new NotImplementedException();
    }

    public PlayerDTO UpdatePlayer(PlayerDTO player)
    {
        throw new NotImplementedException();
    }
}