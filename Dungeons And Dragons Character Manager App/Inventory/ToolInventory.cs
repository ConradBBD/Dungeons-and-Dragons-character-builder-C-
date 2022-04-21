namespace Dungeons_And_Dragons_Character_Manager_App.Inventory;

using Dungeons_And_Dragons_Character_Manager_App.Models;

public static class ToolInventory{

    private static List<Tool> ListOfTools { get; set; } = new List<Tool>();

    public static List<Tool> Generate(){
        generateAmmo();
        generateArcaneFocus();
        generateDruidicFocus();
        generateHolySymbols();
        generateUsables();
        generateKits();
        generateClothes();
        generateCommonItems();
        
        return ListOfTools;
    }

    public static List<Tool> getAllTools(){
        if (ListOfTools.Count() == 0)
            Generate();
        
        return ListOfTools;
    }

    public static void generateAmmo(){
        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 3, weight: 2,
            count: 10, name: "Bullets"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 1, weight: 1,
            count: 20, name: "Arrows"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 1, weight: 1,
            count: 50, name: "Blowgun Needles"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 1, weight: 2,
            count: 20, name: "Crossbow Bolts"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 2, weight: 2,
            count: 20, name: "Sling Bullets"
         )
        );
    }

      public static void generateCommonItems(){
        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 2, weight: 5,
            count: 1, name: "Blanket"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 25, weight: 5,
            count: 1, name: "Book"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 5, weight: 10,
            count: 1, name: "Chain (10 ft)"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 25, weight: 2,
            count: 1, name: "Component's Pouch"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 2, weight: 5,
            count: 1, name: "Crowbar"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 20, weight: 20,
            count: 10, name: "Rations (1 day)"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 1000, weight: 1,
            count: 1, name: "Spyglass"
         )
        );
      }

    public static void generateUsables(){
        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 25, weight: 1,
            count: 1, name: "Acid (vial)"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 50, weight: 1,
            count: 1, name: "Alchemist's Fire (flask)"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 50, weight: 0,
            count: 1, name: "Antitoxin (vial)"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 1, weight: 2,
            count: 100, name: "Ball Bearing (bag)"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 1, weight: 2,
            count: 20, name: "Caltrop (bag)"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 25, weight: 1,
            count: 1, name: "Holy Water (flask)"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 1, weight: 1,
            count: 1, name: "Oil (flask)"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 100, weight: 0,
            count: 1, name: "Poison, basic (vial)"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 50, weight: 1,
            count: 1, name: "Potion of Healing"
         )
        );
    }

    public static void generateClothes(){
        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 5, weight: 3,
            count: 1, name: "Common Clothes"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 5, weight: 4,
            count: 1, name: "Costume"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 15, weight: 6,
            count: 1, name: "Fine Clothes"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 1, weight: 4,
            count: 1, name: "Robes"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 2, weight: 4,
            count: 1, name: "Traveler's Clothes"
         )
        );
      }

        public static void generateKits(){
        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 25, weight: 12,
            count: 1, name: "Climber's Kit"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 25, weight: 3,
            count: 1, name: "Disguise Kit"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 15, weight: 5,
            count: 1, name: "Forgery Kit"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 5, weight: 3,
            count: 1, name: "Herbalism Kit"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 5, weight: 3,
            count: 1, name: "Healer's Kit"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 2, weight: 1,
            count: 1, name: "Mess Kit"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 50, weight: 2,
            count: 1, name: "Poisoner's Kit"
         )
        );
    }

    public static void generateArcaneFocus(){
        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 10, weight: 1,
            count: 1, name: "Crystal"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 20, weight: 3,
            count: 1, name: "Orb"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 10, weight: 2,
            count: 1, name: "Rod"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 5, weight: 4,
            count: 1, name: "Staff"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 10, weight: 1,
            count: 1, name: "Wand"
         )
        );
    }   

    public static void generateDruidicFocus(){
        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 1, weight: 0,
            count: 1, name: "Sprig of Mistletoe"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 1, weight: 0,
            count: 1, name: "Totem"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 5, weight: 4,
            count: 1, name: "Wooden Staff"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 10, weight: 1,
            count: 1, name: "Yew Wand"
         )
        );
      } 

    public static void generateHolySymbols(){
        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 5, weight: 1,
            count: 1, name: "Amulet"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 5, weight: 0,
            count: 1, name: "Emblem"
         )
        );

        ListOfTools.Add( new Tool(
            ability: new AbilityScore(), cost: 5, weight: 2,
            count: 1, name: "Reliquary"
         )
        );
      }
}