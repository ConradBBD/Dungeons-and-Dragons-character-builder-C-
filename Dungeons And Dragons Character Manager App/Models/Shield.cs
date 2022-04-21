namespace Dungeons_And_Dragons_Character_Manager_App.Models;

public class Shield : Item{
    public uint Quality { get; set; }
    public Duration DonTime { get; set; }
    public Duration DoffTime { get; set; }
    public uint ArmorClassSupplement { get => 2; } 

    // Add this to the character
    public static Shield shieldItem { 
        get {
            Duration oneAction = new Duration(1, "Action");
            return new Shield(don: oneAction, doff: oneAction);
        }
    }

    private Shield(       
        Duration don,
        Duration doff,
        uint quality = 10,
        uint cost = 10,
        uint lbWeight = 6,
        string name = "Shield"
    ){
        this.Name = name;
        this.GPCost = cost;
        this.DonTime = don;
        this.DoffTime = doff;
        this.LbWeight = lbWeight;
        this.Quality = quality;
    }

    public Shield() { }

    public override string ToString(){
        return String.Format(
            "Name: {0} / Cost: {1}gp / AC: +2 / \n" +
            "Weight: {4}lbs /\n Quality: {5} /\n" +
            "Don Time: {6} / Doff Time: {7} /",
            new object[] { this.Name, this.GPCost, this.LbWeight, this.Quality,
            this.DonTime, this.DoffTime }
        );
    }
}