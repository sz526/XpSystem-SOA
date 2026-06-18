namespace XpSystem;

public class PlayerService
{
    private readonly List<PlayerModel> _players = new();
    private int _nextID =1;

  
    public void GainXp(int id, int amount)
    {
        var player = _players.FirstOrDefault(p => p.Id == id);
    }
}