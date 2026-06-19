using System;
using System.Collections.Generic;
using System.Linq;

namespace XpSystem;

public class PlayerService
{
    private readonly List<PlayerModel> _players = new();
    private int _nextId =1;

  public PlayerModel CreatePlayer(string name)
    {
        var player = new PlayerModel(_nextId++, name);
        _players.Add(player);
        return player;
    }
    public void GainXp(int id, int amount)
    {
        if (amount < 0) return;

        // Find the specific player by their unique ID
        var player = _players.FirstOrDefault(p => p.Id == id);
        if (player == null)
        {
            throw new KeyNotFoundException($"Player with ID {id} was not found.");
        }

        player.Xp += amount;

        while (player.Xp >= 100)
        {
            player.Level++;
            player.Xp -= 100;
        }
    }
}