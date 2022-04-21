namespace Dungeons_And_Dragons_Character_Manager_App.Inventory;

using Dungeons_And_Dragons_Character_Manager_App.Models;

public static class ItemInventory{

    private static List<Item> Items { get; set; } = new List<Item>();

    public static List<Item> Generate(){
        Items.AddRange(ArmorInventory.Generate());
        Items.AddRange(ToolInventory.Generate());
        Items.AddRange(WeaponInventory.Generate());

        Items.Add(Shield.shieldItem);
        
        return Items;
    }
}