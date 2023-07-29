using Statistics.Models.Players;

namespace Statistics.API.Services;
public interface IPlayerService
{
    Player GetPlayerById(string playerId);
}