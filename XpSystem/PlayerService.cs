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
        //If the number is negative, immediately throw an exception and refuse to execute.
        if (amount < 0)
        {
        throw new ArgumentOutOfRangeException(nameof(amount), "XP amount cannot be negative.");
        /* throw new ArgumentOutOfRangeException(nameof(amount), amount, "XP amount cannot be negative.");
        parameter 3 in" " is for the player,
        parameter 1 and 2 is for the programmer,
        Parameter 1 (ParamName): The name of the parameter that caused the out-of-bounds error (automatically converted to a string using nameof).
        Parameter 2 (ActualValue): the value of the parameter.
        */
        }

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

    public List<PlayerModel> GetAllPlayers()
    {
        return _players.ToList(); // Returns a copy of the list for safety
    }

    public void DeletePlayer(int id)
    {
        // 1. find the player
        var player = _players.FirstOrDefault(p => p.Id == id);
        
        // 2. if can not find it, throw KeyNotFoundException
        if (player == null)
        {
            throw new KeyNotFoundException($"Player with ID {id} does not exist.");
        }
        
        // 3. delte it
        _players.Remove(player);
    }   
}