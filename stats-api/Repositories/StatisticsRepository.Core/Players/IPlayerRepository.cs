using Statistics.Domain.Players;
using Statistics.Domain.Results;

namespace StatisticsRepository.Core.Players;

public interface IPlayerRepository
{
    public Task<PlayerDTO> GetPlayerById(string playerId);
    public Task<PlayerDTO> CreatePlayer(PlayerDTO player);
    public Task<PlayerDTO> UpdatePlayer(PlayerDTO player);
    public Task<DeleteResult> DeletePlayerById(string playerId);
    public Task<IEnumerable<PlayerDTO>> GetTopPlayers();
}
