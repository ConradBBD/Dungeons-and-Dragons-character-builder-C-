namespace Dungeons_And_Dragons_Character_Manager_App.Models;

public class Armor : Item{
    public int? Strength { get; set; }
    public uint ArmorClass { get; set; }
    public Duration DonTime { get; set; }
    public Duration DoffTime { get; set; }
    public ArmorType ArmorType { get; set; }

    public Armor(
        ArmorType type,        
        Duration don,
        Duration doff,
        uint ac = 13,
        uint cost = 50,
        int? strength = 13,
        uint lbWeight = 100,
        string name = "Just Some Boxes I Wore"
        
    ){
        this.Name = name;
        this.GPCost = cost;
        this.ArmorType = type;
        this.LbWeight = lbWeight;
        this.ArmorClass = ac;
        this.DonTime = don;
        this.DoffTime = doff;
        this.Strength = strength;
    }

    public Armor() { }

    public override string ToString(){
        return String.Format(
            "Name: {0} / Cost: {1}gp / Armor Class: {2} / Armor Type: {3} /\n" +
            "Weight: {4}lbs /\n Strength: {5} /\n" +
            "Don Time: {6} / Doff Time: {7} /",
            new object[] { this.Name, this.GPCost, this.ArmorClass, this.ArmorType,
            this.LbWeight, this.disadvantage(), this.DonTime, this.DoffTime }
        );
    }

    private string disadvantage(){
        if (this.Strength == null)
            return "No disadvantage";
        return "Disadvantaged if STR is below " + this.Strength;
    }
}