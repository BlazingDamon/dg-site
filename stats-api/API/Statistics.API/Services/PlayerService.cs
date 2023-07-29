using AutoMapper;
using Statistics.Domain.Players;
using Statistics.Models.Players;
using StatisticsRepository.Core.Players;

namespace Statistics.API.Services;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;

    public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
    }

    public Player GetPlayerById(string playerId)
    {
        PlayerDTO player = _playerRepository.GetPlayerById(playerId);

        return _mapper.Map<Player>(player);
    }
}
