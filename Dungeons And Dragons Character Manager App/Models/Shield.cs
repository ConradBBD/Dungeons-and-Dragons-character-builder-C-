namespace Dungeons_And_Dragons_Character_Manager_App.Models;

public class Shield : Item{
    public int Quality { get; set; }
    public Duration DonTime { get; set; }
    public Duration DoffTime { get; set; }
    public int ArmorClassSupplement { get => 2; } 

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
        int quality = 10,
        int cost = 10,
        int lbWeight = 6,
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
            "Weight: {2}lbs /\n Quality: {3} /\n" +
            "Don Time: {4} / Doff Time: {5} /",
            new object[] { this.Name, this.GPCost, this.LbWeight, this.Quality,
            this.DonTime, this.DoffTime }
        );
    }
}