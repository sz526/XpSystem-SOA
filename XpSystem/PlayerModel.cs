namespace XpSystem;

public class PlayerModel
{
    public int Id { get; set; } // Requirement: unique ID
    public string Name { get; set; }
    public int Level { get; set; }
    public int Xp { get; set; }

    public PlayerModel(int id, string name)
    {
        Id = id;
        Name = name;
        Level = 1;
        Xp = 0;
    }
}