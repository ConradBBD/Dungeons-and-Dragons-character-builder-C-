using System.ComponentModel.DataAnnotations.Schema;

namespace Dungeons_And_Dragons_Character_Manager_App.Models;

[NotMapped]
public class AreaOfEffect{
    public string Area { get; private set; }
    
    private AreaOfEffect(string area){
        this.Area = area;
    }

    public static AreaOfEffect SELF { 
        get { return new AreaOfEffect("SELF"); }
    }
    public static AreaOfEffect LINE { 
        get { return new AreaOfEffect("LINE"); }
    }
        
    public static AreaOfEffect CUBE { 
        get { return new AreaOfEffect("CUBE"); }
    }

    public static AreaOfEffect SPHERE { 
        get { return new AreaOfEffect("SPHERE"); }
    }
        
    public static AreaOfEffect CONE { 
        get { return new AreaOfEffect("CONE"); }
    }
}