using Microsoft.AspNetCore.Mvc;
using XpSystem; 
namespace XpSystem.Api.Controllers;
//namespace XpSystem;

[ApiController]
[Route("api/[controller]")] // The access path will automatically change to api/players
public class PlayersController : ControllerBase
{
    private readonly PlayerService _playerService;
    //The system will automatically pass in the PlayerService instance.
    public PlayersController(PlayerService playerService)
    {
        _playerService = playerService;
    }
    // Add endpoint：POST /api/players/{id}/xp
    [HttpPost("{id}/xp")]
    public IActionResult GainXp(int id, [FromBody] XpRequest request)
    {
        try
        {
            // the core service logic！
            _playerService.GainXp(id, request.Amount);
            return Ok(new { message = "XP updated successfully." });
        }
        catch (ArgumentOutOfRangeException ex)
        {
            // Contract requirement: If a negative number is out of bounds, return a 400 Bad Request error and the reason for the error.
            return BadRequest(new { error = ex.Message });
        }
        catch (KeyNotFoundException ex)
        {
            // Contract Requirements: If the player ID cannot be found, return a 404 Not Found error.
            return NotFound(new { error = ex.Message });
        }
    }
}

public record XpRequest(int Amount);
 