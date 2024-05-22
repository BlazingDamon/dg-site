using Microsoft.AspNetCore.Mvc;
using Statistics.API.Services;
using Statistics.Domain.Results;
using Statistics.Models.Players;

namespace Statistics.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayersController : ControllerBase
{
    private readonly ILogger<PlayersController> _logger;
    private readonly IPlayerService _playerService;

    // TODO: implement a JSON Patch or JSON Merge Patch endpoint to take advantage of partial document updates
    public PlayersController(ILogger<PlayersController> logger, IPlayerService playerService)
    {
        _logger = logger;
        _playerService = playerService;
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{playerId}", Name = "GetByPlayerId")]
    public async Task<PlayerResponse> GetByPlayerId(string playerId)
    {
        return await _playerService.GetPlayerById(playerId);
    }

    [HttpPost(Name = "CreatePlayer")]
    public async Task<PlayerResponse> CreatePlayer(PlayerCreateRequest player)
    {
        return await _playerService.CreatePlayer(player);
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPut("{playerId}", Name = "UpdatePlayer")]
    public async Task<PlayerResponse> UpdatePlayer(string playerId, PlayerUpdateRequest player)
    {
        return await _playerService.UpdatePlayer(playerId, player);
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{playerId}", Name = "DeletePlayerById")]
    public async Task<IActionResult> DeletePlayerById(string playerId)
    {
        DeleteResult result = await _playerService.DeletePlayerById(playerId);

        if (result.DeletedCount == 0)
            return NotFound();

        return NoContent();
    }
}