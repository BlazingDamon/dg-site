using AutoMapper;
using Statistics.Domain.Players;
using Statistics.Domain.Results;
using Statistics.Models.Players;
using StatisticsRepository.Core.Players;

namespace Statistics.API.Services;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;

    public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
    {
        // TODO: wrap repository calls in a Polly re-try
        _playerRepository = playerRepository;
        _mapper = mapper;
    }

    public async Task<PlayerResponse> GetPlayerById(string playerId)
    {
        PlayerDTO player = await _playerRepository.GetPlayerById(playerId);

        return _mapper.Map<PlayerResponse>(player);
    }

    public async Task<PlayerResponse> CreatePlayer(PlayerCreateRequest player)
    {
        PlayerDTO playerDto = _mapper.Map<PlayerDTO>(player);
        playerDto.PlayerId = Guid.NewGuid().ToString();

        PlayerDTO createdPlayer = await _playerRepository.CreatePlayer(playerDto);

        return _mapper.Map<PlayerResponse>(createdPlayer);
    }

    public async Task<PlayerResponse> UpdatePlayer(string playerId, PlayerUpdateRequest player)
    {
        PlayerDTO playerDto = _mapper.Map<PlayerDTO>(player);
        playerDto.PlayerId = playerId;

        PlayerDTO updatedPlayer = await _playerRepository.UpdatePlayer(playerDto);

        return _mapper.Map<PlayerResponse>(updatedPlayer);
    }

    public async Task<DeleteResult> DeletePlayerById(string playerId)
    {
        return await _playerRepository.DeletePlayerById(playerId);
    }
}
