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
    public void GainXp_ShouldIncreaseXp()
    {
        var service = new PlayerService();

        // Act
        var player1 = service.CreatePlayer("Hero");

        // Act
        player1.GainXp(40);

        // Assert
        Assert.Equal(40, player1.Xp);
    } 
    [Fact]
    public void GainXp_ReachingOneHundredXp_ShouldLevelUp()
    {
               var service = new PlayerService();

        // Act
        var player1 = service.CreatePlayer("Hero");

        // Act
        player1.GainXp(100);

        // Assert
        Assert.Equal(2, player1.Level);
        Assert.Equal(0, player1.Xp);
    }
    [Fact]
    public void GainXp_HugeAmountOfXp_ShouldLevelUpMultipleTimes()
    {
                var service = new PlayerService();

        // Act
        var player1 = service.CreatePlayer("Hero");

        // Act
        player1.GainXp(250);

        // Assert
        Assert.Equal(3, player1.Level);
        Assert.Equal(50, player1.Xp);
    }
}