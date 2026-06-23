namespace XpSystem.Tests;

using Xunit;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Testing;

// This fixture hosts the API project in memory automatically during test execution
public class PlayersControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public PlayersControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetPlayers_Returns200OkWithPlayerList()
    {
        // Act
        var response = await _client.GetAsync("api/players");

        // Assert Contract
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        
        var players = await response.Content.ReadFromJsonAsync<List<PlayerModel>>();
        Assert.NotNull(players);
        Assert.NotEmpty(players); // Verifies our default seeded player exists
    }

    [Fact]
    public async Task GainXp_ValidRequest_Returns200OkWithSuccessMessage()
    {
        // Arrange
        var payload = new { Amount = 50 };

        // Act - Using seeded player ID 1
        var response = await _client.PostAsJsonAsync("api/players/1/xp", payload);

        // Assert Contract
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        
        var content = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
        Assert.NotNull(content);
        Assert.Equal("XP updated successfully.", content["message"]);
    }

    [Fact]
    public async Task GainXp_NegativeAmount_Returns400BadRequest()
    {
        // Arrange (Violating the contract on input)
        var payload = new { Amount = -25 };

        // Act
        var response = await _client.PostAsJsonAsync("api/players/1/xp", payload);

        // Assert Contract
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        
        var content = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
        Assert.NotNull(content);
        Assert.Contains("error", content.Keys);
    }

    [Fact]
    public async Task GainXp_NonExistentPlayer_Returns404NotFound()
    {
        // Arrange
        var payload = new { Amount = 30 };

        // Act - Target an impossible player ID
        var response = await _client.PostAsJsonAsync("api/players/9999/xp", payload);

        // Assert Contract
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}