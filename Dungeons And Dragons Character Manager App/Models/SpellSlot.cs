namespace Dungeons_And_Dragons_Character_Manager_App.Models;

public class SpellSlot{
    public bool usedUp { get; set; }
    public int level { get; }

    SpellSlot(int level){
        this.level = level;
        this.usedUp = false;
    }

    public void resetSlot(){
        this.usedUp = false;
    }
}