using Statistics.Domain.Results;
using Statistics.Models.Players;

namespace Statistics.API.Services;
public interface IPlayerService
{
    Task<PlayerResponse> GetPlayerById(string playerId);
    Task<PlayerResponse> CreatePlayer(PlayerCreateRequest player);
    Task<PlayerResponse> UpdatePlayer(string playerId, PlayerUpdateRequest player);
    Task<DeleteResult> DeletePlayerById(string playerId);
}