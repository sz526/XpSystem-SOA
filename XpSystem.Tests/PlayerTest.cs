using Xunit;
using XpSystem;
using System.ComponentModel.Design;

namespace XpSystem.Tests;

public class PlayerTests
{
    [Fact]
    public void CreatePlayer_ShouldInitializeWithUniqueIdLevelOneAndZeroXp()
    {
        // Arrange
        var service = new PlayerService();

        // Act
        var player1 = service.CreatePlayer("Hero");
        var player2 = service.CreatePlayer("Mage");

        // Assert
        Assert.Equal(1, player1.Id);
        Assert.Equal(2, player2.Id);
        Assert.Equal(1, player1.Level);
        Assert.Equal(0, player1.Xp);
    }
    [Fact]
    public void GainXp_SpecificPlayerId_ShouldIncreaseXpAndLevelUp()
    {
        // Arrange
        var service = new PlayerService();
        var player = service.CreatePlayer("Hero");

        // Act & Assert Flow 1: Gain normal XP
        service.GainXp(player.Id, 40);
        Assert.Equal(40, player.Xp);

        // Act & Assert Flow 2: Trigger Level Up
        service.GainXp(player.Id, 60); // Total 100 XP
        Assert.Equal(2, player.Level);
        Assert.Equal(0, player.Xp);
    }   
    [Fact]
    public void GetAllPlayers_ShouldReturnAllStoredPlayers()
    {
        // Arrange
        var service = new PlayerService();
        service.CreatePlayer("Hero");
        service.CreatePlayer("Mage");

        // Act
        var allPlayers = service.GetAllPlayers();

        // Assert
        Assert.Equal(2, allPlayers.Count);
    }
    [Fact]
    public void GainXp_NegativeAmount_ShouldThrowArgumentOutOfRangeException()
    {
    // Arrange
    var service = new PlayerService();
    var player = service.CreatePlayer("Hero");

    // Act & Assert
    // Assert.Throws 
    var exception = Assert.Throws<ArgumentOutOfRangeException>(() => 
    {
        service.GainXp(player.Id, -50); // Intentionally passing in negative numbers
    });

    // Also check if the error message contains the parameter name "amount"
    Assert.Contains("amount", exception.Message);
    }
}