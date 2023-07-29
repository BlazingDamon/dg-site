using Microsoft.AspNetCore.Mvc;
using Statistics.API.Services;
using Statistics.Models.Players;

namespace Statistics.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly ILogger<PlayerController> _logger;
    private readonly IPlayerService _playerService;

    public PlayerController(ILogger<PlayerController> logger, IPlayerService playerService)
    {
        _logger = logger;
        _playerService = playerService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public Player GetByPlayerId(string playerId)
    {
        return _playerService.GetPlayerById(playerId);
    }
}