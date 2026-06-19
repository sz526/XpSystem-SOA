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
        var player = _players.FirstOrDefault(p => p.Id == id);
    }
}