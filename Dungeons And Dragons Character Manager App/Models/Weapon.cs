using System.ComponentModel.DataAnnotations.Schema;

namespace Dungeons_And_Dragons_Character_Manager_App.Models;

public class Weapon : Item{
    [NotMapped]
    public List<int> DamageDice { get; set; } // The list of dice i.e 2d4 = {4, 4}
    [NotMapped]
    public List<string> DamageTypes { get; set; }
    public bool Magic { get; set; }
    public bool Finnesse { get; set; }
    public int Quality { get; set; }
    public bool Light { get; set; }
    public bool Heavy { get; set; }
    public bool Reach { get; set; }
    public int RangeNear { get; set; }
    public int RangeFar { get; set; }
    public bool Thrown { get; set; }
    public bool Versatile { get; set; }

    public Weapon(
        List<string> damageTypes,
        List<int> damageDice,
        int quality = 3,
        int rangeNear = 5,
        int rangeFar = 10,
        int lbWeight = 50,
        bool light = true,
        bool magic = false,
        bool heavy = false,
        bool reach = false,
        bool thrown = false,
        bool finnesse = false,
        int gpCost = 1000000,
        string name = "Mehaxe"
    ){
        this.Name = name;
        this.Light = light;
        this.Heavy = heavy;
        this.Magic = magic;
        this.Reach = reach;
        this.GPCost = gpCost;
        this.Thrown = thrown;
        this.Quality = quality;
        this.RangeFar = rangeFar;
        this.LbWeight = lbWeight;
        this.Finnesse = finnesse;
        this.RangeNear = rangeNear;
        this.DamageDice = damageDice;
        this.DamageTypes = damageTypes;

        this.Versatile = this.Heavy && this.Light;
    }

    public Weapon() { }

    public override string ToString(){
        return String.Format(
            "Name: {0} / Damage Types: {1} / Quality: {2} / Weapon Type: {3} /\n" +
            "Weight: {4}lbs /\n Cost: {5}gp /\n Magic Weapon: {6} /\n" +
            "Range (Near-Far): {7}-{8} / Damage Dice: {9} \n" +
            "Thrown: {10} / Finnesse: {11} /",
            new object[] { this.Name, string.Join(',', this.DamageTypes ), this.Quality, 
            this.decideWeaponType(), this.LbWeight, this.GPCost, this.Magic, this.RangeNear,
            this.RangeFar, this.DamageDice, this.Thrown, this.Finnesse }
        );
    }

    private string decideWeaponType(){
        return this.Versatile ? "Versatile" : 
        this.Heavy ? "Heavy" : "Light"; 
    }
}