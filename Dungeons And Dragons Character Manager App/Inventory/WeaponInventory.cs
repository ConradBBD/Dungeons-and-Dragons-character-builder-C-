namespace Dungeons_And_Dragons_Character_Manager_App.Inventory;

using Dungeons_And_Dragons_Character_Manager_App.Models;

public static class WeaponInventory{

    private static List<Weapon> ListOfWeapons { get; set; } = new List<Weapon>();

    public static List<Weapon> Generate(){
        generateFirearms();
        generateSimpleWeapons();
        generateSimpleRangedWeapons();
        generateMartialWeapons();
        generateMartialRangedWeapons();
        
        return ListOfWeapons;
    }

    public static List<Weapon> getAllWeapons(){
        if (ListOfWeapons.Count() == 0)
            Generate();
        
        return ListOfWeapons;
    }

    public static void generateFirearms(){
        ListOfWeapons.Add( new Weapon(
            damageTypes: new List<string>{"Piercing"}, damageDice: new List<uint>{10}, 
            quality: 10, rangeNear: 30, rangeFar: 90, lbWeight: 3, light: true, 
            magic: false, heavy: false, reach: false, thrown: true,
            finnesse: false, gpCost: 250, name: "Pistol"
            ) 
        );

        ListOfWeapons.Add( new Weapon(
            damageTypes: new List<string>{"Piercing"}, damageDice: new List<uint>{12}, 
            quality: 10, rangeNear: 40, rangeFar: 120, lbWeight: 10, light: false, 
            magic: false, heavy: true, reach: false, thrown: false,
            finnesse: false, gpCost: 500, name: "Musket"
            ) 
        );

        ListOfWeapons.Add( new Weapon(
            damageTypes: new List<string>{"Piercing"}, damageDice: new List<uint>{6, 6}, 
            quality: 10, rangeNear: 50, rangeFar: 150, lbWeight: 3, light: true, 
            magic: false, heavy: false, reach: false, thrown: true,
            finnesse: false, gpCost: 400, name: "Pistol"
            ) 
        );
    }

    public static void generateSimpleWeapons(){
        ListOfWeapons.Add( new Weapon(
            damageTypes: new List<string>{"Bludgeoning"}, damageDice: new List<uint>{4}, 
            quality: 10, rangeNear: 1, rangeFar: 0, lbWeight: 2, light: true, 
            magic: false, heavy: false, reach: false, thrown: false,
            finnesse: false, gpCost: 1, name: "Club"
            ) 
        );

        ListOfWeapons.Add( new Weapon(
            damageTypes: new List<string>{"Piercing"}, damageDice: new List<uint>{14}, 
            quality: 10, rangeNear: 20, rangeFar: 60, lbWeight: 1, light: true, 
            magic: false, heavy: false, reach: true, thrown: true,
            finnesse: true, gpCost: 2, name: "Dagger"
            ) 
        );

        ListOfWeapons.Add( new Weapon(
            damageTypes: new List<string>{"Slashing"}, damageDice: new List<uint>{6}, 
            quality: 10, rangeNear: 20, rangeFar: 60, lbWeight: 2, light: true, 
            magic: false, heavy: false, reach: true, thrown: true,
            finnesse: false, gpCost: 5, name: "Hand-Axe"
            ) 
        );
    }

    public static void generateSimpleRangedWeapons(){
        ListOfWeapons.Add( new Weapon(
            damageTypes: new List<string>{"Piercing"}, damageDice: new List<uint>{8}, 
            quality: 10, rangeNear: 80, rangeFar: 320, lbWeight: 5, light: false, 
            magic: false, heavy: true, reach: false, thrown: false,
            finnesse: false, gpCost: 25, name: "Crossbow (Light)"
            ) 
        );

        ListOfWeapons.Add( new Weapon(
            damageTypes: new List<string>{"Piercing"}, damageDice: new List<uint>{4}, 
            quality: 10, rangeNear: 20, rangeFar: 60, lbWeight: 1, light: true, 
            magic: false, heavy: false, reach: false, thrown: true,
            finnesse: false, gpCost: 2, name: "Dart"
            ) 
        );

        ListOfWeapons.Add( new Weapon(
            damageTypes: new List<string>{"Piercing"}, damageDice: new List<uint>{4}, 
            quality: 10, rangeNear: 80, rangeFar: 320, lbWeight: 2, light: false, 
            magic: false, heavy: true, reach: false, thrown: false,
            finnesse: false, gpCost: 25, name: "Shortbow"
            ) 
        );

        ListOfWeapons.Add( new Weapon(
            damageTypes: new List<string>{"Piercing"}, damageDice: new List<uint>{4}, 
            quality: 10, rangeNear: 30, rangeFar: 120, lbWeight: 0, light: true, 
            magic: false, heavy: false, reach: false, thrown: false,
            finnesse: false, gpCost: 1, name: "Sling"
            ) 
        );
    }

    public static void generateMartialRangedWeapons(){
        ListOfWeapons.Add( new Weapon(
            damageTypes: new List<string>{"Piercing"}, damageDice: new List<uint>{1}, 
            quality: 10, rangeNear: 25, rangeFar: 100, lbWeight: 1, light: true, 
            magic: false, heavy: false, reach: false, thrown: false,
            finnesse: false, gpCost: 10, name: "Blowgun"
            ) 
        );

        ListOfWeapons.Add( new Weapon(
            damageTypes: new List<string>{"Piercing"}, damageDice: new List<uint>{6}, 
            quality: 10, rangeNear: 30, rangeFar: 120, lbWeight: 3, light: true, 
            magic: false, heavy: false, reach: false, thrown: true,
            finnesse: false, gpCost: 75, name: "Crossbow (Hand)"
            ) 
        );

        ListOfWeapons.Add( new Weapon(
            damageTypes: new List<string>{"Piercing"}, damageDice: new List<uint>{10}, 
            quality: 10, rangeNear: 100, rangeFar: 400, lbWeight: 18, light: false, 
            magic: false, heavy: true, reach: false, thrown: false,
            finnesse: false, gpCost: 50, name: "Crossbow (Heavy)"
            ) 
        );

        ListOfWeapons.Add( new Weapon(
            damageTypes: new List<string>{"Piercing"}, damageDice: new List<uint>{8}, 
            quality: 10, rangeNear: 150, rangeFar: 600, lbWeight: 2, light: false, 
            magic: false, heavy: true, reach: false, thrown: false,
            finnesse: false, gpCost: 50, name: "Longbow"
            ) 
        );
    }

    public static void generateMartialWeapons(){
        ListOfWeapons.Add( new Weapon(
            damageTypes: new List<string>{"Slashing"}, damageDice: new List<uint>{8}, 
            quality: 10, rangeNear: 1, rangeFar: 5, lbWeight: 4, light: true, 
            magic: false, heavy: true, reach: true, thrown: false,
            finnesse: false, gpCost: 10, name: "Battleaxe"
            ) 
        );

        ListOfWeapons.Add( new Weapon(
            damageTypes: new List<string>{"Slashing"}, damageDice: new List<uint>{6, 6}, 
            quality: 10, rangeNear: 1, rangeFar: 5, lbWeight: 6, light: false, 
            magic: false, heavy: true, reach: true, thrown: false,
            finnesse: false, gpCost: 50, name: "Great-sword"
            ) 
        );

        ListOfWeapons.Add( new Weapon(
            damageTypes: new List<string>{"Slashing"}, damageDice: new List<uint>{4}, 
            quality: 10, rangeNear: 1, rangeFar: 15, lbWeight: 3, light: false, 
            magic: false, heavy: true, reach: true, thrown: false,
            finnesse: true, gpCost: 2, name: "Whip"
            ) 
        );

        ListOfWeapons.Add( new Weapon(
            damageTypes: new List<string>{"Bludgeoning"}, damageDice: new List<uint>{8}, 
            quality: 10, rangeNear: 150, rangeFar: 600, lbWeight: 2, light: true, 
            magic: false, heavy: true, reach: false, thrown: false,
            finnesse: false, gpCost: 15, name: "War-Hammer"
            ) 
        );
    }
}