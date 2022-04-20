namespace Dungeons_And_Dragons_Character_Manager_App.Models;

public class Item{
    public int Id { get; set; }
    public string Name { get; set; }
    public uint LbWeight { get; set; }
    public uint GPCost { get; set; }

    public Item(
        string Name
        )
    {
        this.Name = Name;

    }
}