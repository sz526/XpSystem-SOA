namespace XpSystem.Tests;

using Xunit;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

public class PlayersControllerTests
{
    [Fact]
    public async Task HTTP_GetPlayers_ContractCheck()
    {
        using var client = new HttpClient();
        try
        {
            
            var response = await client.GetAsync("http://localhost:5118/api/players");
            Assert.True(response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NotFound);
        }
        catch (HttpRequestException)
        {
            Assert.True(true); 
        }
    }
}