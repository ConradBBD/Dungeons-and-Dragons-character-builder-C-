namespace Dungeons_And_Dragons_Character_Manager_App.Models;

public class Tool : Item{
    public uint Count { get; set; }

    public AbilityScore AbilityScore { get; set; }

    public Tool(
        AbilityScore ability,
        uint cost = 5,
        uint count = 20,
        uint weight = 5,
        string name = "Arrow"
    ){
        this.Name = name;
        this.Count = count;
        this.GPCost = cost;
        this.LbWeight = weight;
        this.AbilityScore = ability;
    }

    public bool useInstance(){
        if (this.Count == 0)
            return false;
        this.Count--;
        return true;
    }

    public override string ToString()
    {
        return String.Format(
            "Name: {0} / Count: {1} / Weight: {2}lbs / Cost: {3} /",
            new Object[] {this.Name, this.Count, this.LbWeight, this.GPCost}
        );
    }
}