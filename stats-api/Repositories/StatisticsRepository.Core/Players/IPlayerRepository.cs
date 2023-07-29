using Statistics.Domain.Players;

namespace StatisticsRepository.Core.Players;

public interface IPlayerRepository
{
    public PlayerDTO GetPlayerById(string playerId);
    public PlayerDTO CreatePlayer(PlayerDTO player);
    public PlayerDTO UpdatePlayer(PlayerDTO player);
    public Task DeletePlayerById(string playerId);
    public IEnumerable<PlayerDTO> GetTopPlayers();
}
