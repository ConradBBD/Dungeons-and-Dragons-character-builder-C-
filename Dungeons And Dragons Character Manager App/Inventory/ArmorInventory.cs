namespace Dungeons_And_Dragons_Character_Manager_App.Inventory;

using Dungeons_And_Dragons_Character_Manager_App.Models;

public static class ArmorInventory{

    private static List<Armor> ListOfArmor { get; set; } = new List<Armor>();

    public static List<Armor> Generate(){
        generateLight();
        generateMedium();
        generateHeavy();
        
        return ListOfArmor;
    }

    public static List<Armor> getAllArmor(){
        if (ListOfArmor.Count() == 0)
            Generate();
        
        return ListOfArmor;
    }

    public static Armor getSpecifiedArmor(string armorName){
        if (ListOfArmor.Count() == 0)
            Generate();

        int where = ListOfArmor.FindIndex((armor) => armor.Name == armorName);
        return where > -1 ? ListOfArmor[where] : null;
    }

    // Generate light armor objects
    private static void generateLight(){
        ListOfArmor.Add(new Armor(
            name: "Padded Armor", type: ArmorType.LIGHT, 
            don: new Duration(1, "Minute"), doff: new Duration(1, "Minute"),
            ac: 11, cost: 5, strength: null, lbWeight: 8
          )
        );

        ListOfArmor.Add(new Armor(
            name: "Leather Armor", type: ArmorType.LIGHT, 
            don: new Duration(1, "Minute"), doff: new Duration(1, "Minute"),
            ac: 11, cost: 10, strength: null, lbWeight: 10
          )
        );

        ListOfArmor.Add(new Armor(
            name: "Studded Armor", type: ArmorType.LIGHT, 
            don: new Duration(1, "Minute"), doff: new Duration(1, "Minute"),
            ac: 12, cost: 45, strength: null, lbWeight: 13
          )
        );
    }

    // Generate medium armor objects
    private static void generateMedium(){
        ListOfArmor.Add(new Armor(
            name: "Hide", type: ArmorType.MEDIUM, 
            don: new Duration(5, "Minute"), doff: new Duration(1, "Minute"),
            ac: 12, cost: 10, strength: null, lbWeight: 12
          )
        );

        ListOfArmor.Add(new Armor(
            name: "Chain Shirt", type: ArmorType.MEDIUM, 
            don: new Duration(5, "Minute"), doff: new Duration(1, "Minute"),
            ac: 13, cost: 50, strength: null, lbWeight: 20
          )
        );

        ListOfArmor.Add(new Armor(
            name: "Scale Mail", type: ArmorType.MEDIUM, 
            don: new Duration(5, "Minute"), doff: new Duration(1, "Minute"),
            ac: 14, cost: 50, strength: null, lbWeight: 45
          )
        );

        ListOfArmor.Add(new Armor(
            name: "Spiked Armor", type: ArmorType.MEDIUM, 
            don: new Duration(5, "Minute"), doff: new Duration(1, "Minute"),
            ac: 14, cost: 75, strength: null, lbWeight: 45
          )
        );

        ListOfArmor.Add(new Armor(
            name: "Breastplate", type: ArmorType.MEDIUM, 
            don: new Duration(5, "Minute"), doff: new Duration(1, "Minute"),
            ac: 14, cost: 400, strength: null, lbWeight: 20
          )
        );

        ListOfArmor.Add(new Armor(
            name: "Halfplate", type: ArmorType.MEDIUM, 
            don: new Duration(5, "Minute"), doff: new Duration(1, "Minute"),
            ac: 15, cost: 750, strength: null, lbWeight: 40
          )
        );
    }

    // Generate heavy armor objects
    private static void generateHeavy(){
        ListOfArmor.Add(new Armor(
            name: "Ring Mail", type: ArmorType.HEAVY, 
            don: new Duration(10, "Minute"), doff: new Duration(5, "Minute"),
            ac: 14, cost: 30, strength: null, lbWeight: 40
          )
        );

        ListOfArmor.Add(new Armor(
            name: "Chain Mail", type: ArmorType.HEAVY, 
            don: new Duration(10, "Minute"), doff: new Duration(5, "Minute"),
            ac: 16, cost: 75, strength: 13, lbWeight: 55
          )
        );

        ListOfArmor.Add(new Armor(
            name: "Splint", type: ArmorType.HEAVY, 
            don: new Duration(10, "Minute"), doff: new Duration(5, "Minute"),
            ac: 17, cost: 200, strength: 15, lbWeight: 60
          )
        );

        ListOfArmor.Add(new Armor(
            name: "Plate", type: ArmorType.HEAVY, 
            don: new Duration(10, "Minute"), doff: new Duration(5, "Minute"),
            ac: 18, cost: 1500, strength: 15, lbWeight: 65
          )
        );
    }
}
