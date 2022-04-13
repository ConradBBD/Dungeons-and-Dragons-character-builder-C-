namespace Dungeons_And_Dragons_Character_Manager_App.Models;

public class Weapon{
    public int Id { get; set; }
    public string Name { get; set; } = "Greataxe";
    public List<int> DamageDice { get; set; } = new List<int>{12};
    public List<string> DamageTypes { get; set; } = new List<string>{"Slashing"};
    public bool Magic { get; set; } = false;
    public bool Finnesse { get; set; } = false;
    public int Quality { get; set; } = 10;
    public bool Light { get; set; } = false;
    public bool Heavy { get; set; } = true;
    
    public bool Reach { get; set; } = false;
    public int RangeNear { get; set; } = 5;
    public int RangeFar { get; set; } = 10;
    public bool Thrown { get; set; } = false;
    public bool Versatile { get; set; } = false;
}