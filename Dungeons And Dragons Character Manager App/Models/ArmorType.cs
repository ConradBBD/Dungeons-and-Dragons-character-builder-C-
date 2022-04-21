using System.ComponentModel.DataAnnotations.Schema;
namespace Dungeons_And_Dragons_Character_Manager_App.Models;
[NotMapped]
public class ArmorType{
    public string Type { get; private set; }
    
    private ArmorType(string type){
        this.Type = type;
    }

    public static ArmorType LIGHT { 
        get { return new ArmorType("Light Armor"); }
    }
    public static ArmorType MEDIUM { 
        get { return new ArmorType("Medium Armor"); }
    }
        
    public static ArmorType HEAVY { 
        get { return new ArmorType("Heavy Armor"); }
    }
}