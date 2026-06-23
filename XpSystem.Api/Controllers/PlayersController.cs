using Microsoft.AspNetCore.Mvc;
using XpSystem; 

namespace XpSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class PlayersController : ControllerBase
{
    private readonly PlayerService _playerService;

    public PlayersController(PlayerService playerService)
    {
        _playerService = playerService;
        
        // Seed a default player for testing and Swagger UI convenience
        if (!_playerService.GetAllPlayers().Any())
        {
            _playerService.CreatePlayer("Default Hero"); // Will get Id: 1
        }
    }

    // Contract Requirement: GET /api/players
    [HttpGet]
    public IActionResult GetAllPlayers()
    {
        var players = _playerService.GetAllPlayers();
        return Ok(players);
    }

    // Contract Requirement: POST /api/players/{id}/xp
    [HttpPost("{id}/xp")]
    public IActionResult GainXp(int id, [FromBody] XpRequest request)
    {
        try
        {
            _playerService.GainXp(id, request.Amount);
            return Ok(new { message = "XP updated successfully." });
        }
        catch (ArgumentOutOfRangeException ex)
        {
            // Contract: Returns 400 Bad Request on invalid input
            return BadRequest(new { error = ex.Message });
        }
        catch (KeyNotFoundException ex)
        {
            // Contract: Returns 404 Not Found when entity missing
            return NotFound(new { error = ex.Message });
        }
    }
}

public record XpRequest(int Amount);