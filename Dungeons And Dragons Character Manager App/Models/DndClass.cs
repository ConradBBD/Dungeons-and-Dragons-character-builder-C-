namespace Dungeons_And_Dragons_Character_Manager_App.Models
{
    public abstract class DndClass
    {
        public int ID {get; set;}
        public int level {get; set;}
        public int hitDiceType {get; set;}
        // protected ICollection<T> itemProficiencies {get;}
        // protected ICollection<T> skillProficiencies {get;}
        // protected ICollection<T> savingProficiencies {get;}
        // protected ICollection<T> startingEquipment {get;}

        public abstract void shortRest();
        public abstract void longRest();
        public abstract void levelUp();

        // public AbilityScore abilityScoreImprovement() {

        // }
    }

    public class Fighter: DndClass
    {
        private string fightingStyle1 {get; set;}
        private string fightingStyle2 {get; set;}
        private string subClass {get; set;}
        private ICollection<string> subclassFeatures {get; set;}
        private int attackCount {get; set;}
        private bool secondWindUse {get; set;}
        private int actionSurgeTotal {get; set;}
        private int actionSurgeCount {get; set;}
        private int indomnitableCharges {get; set;}
        private int indomnitableTotal {get; set;}

        // implementation of methods might need to be in a controller instead of model?

        public Fighter() {
            this.level = 1;
            this.hitDiceType = 10;
            // this.itemProficiencies
            // this.skillProficiencies
            // this.savingProficiencies
            // this.startingEquipment
            this.fightingStyle1 = "";
            this.fightingStyle2 = "";
            this.secondWindUse = false;
            this.actionSurgeCount = 0;
            this.actionSurgeTotal = 0;
            this.subClass = "";
            this.subclassFeatures = new List<string>();
            this.attackCount = 1;
            this.indomnitableCharges = 0;
            this.indomnitableTotal = 0;
        }

        public override void shortRest()
        {
            this.secondWindUse = false;
            this.actionSurgeCount = 0;
        }

        public override void longRest()
        {
            this.shortRest();
            this.indomnitableCharges = 0;
        }

        public override void levelUp()
        {
            this.level++;
            switch(this.level)
            {
                case 2:
                {
                    this.actionSurgeTotal = 1;
                    break;
                }
                case 3:
                {
                    this.subClass = "Champion";
                    this.subclassFeatures.Append("Improved Critical");
                    break;
                }
                case 4:
                {
                    // this.abilityScoreImprovement();
                    break;
                }
                case 5:
                {
                    this.attackCount = 2;
                    break;
                }
                case 6:
                {
                    // this.abilityScoreImprovement();
                    break;
                }
                case 7:
                {
                    this.subclassFeatures.Append("Remarkable Athlete");
                    break;
                }
                case 8:
                {
                    // this.abilityScoreImprovement();
                    break;
                }
                case 9:
                {
                    this.indomnitableTotal = 1;
                    break;
                }
                case 10:
                {
                    this.subclassFeatures.Append("Additional Fighting Style");
                    break;
                }
                case 11:
                {
                    this.attackCount = 3;
                    break;
                }
                case 12:
                {
                    // this.abilityScoreImprovement();
                    break;
                }
                case 13:
                {
                    this.indomnitableTotal = 2;
                    break;
                }
                case 14:
                {
                    // this.abilityScoreImprovement();
                    break;
                }
                case 15:
                {
                    this.subclassFeatures.Append("Superior Critical");
                    break;
                }
                case 16:
                {
                    // this.abilityScoreImprovement();
                    break;
                }
                case 17:
                {
                    this.actionSurgeTotal = 2;
                    this.indomnitableTotal = 3;
                    break;
                }
                case 18:
                {
                    this.subclassFeatures.Append("Survivor");
                    break;
                }
                case 19:
                {
                    // this.abilityScoreImprovement();
                    break;
                }
                case 20:
                {
                    this.attackCount = 4;
                    break;
                }
            }
        }

        public void useSecondWind() 
        {
            if (!this.secondWindUse) 
            {
                this.secondWindUse = true;
            }
            // else throw message/exception that it was already used
        }

    }

    // Will do wizard once the spells are done
    
    // public class Wizard: DndClass
    // {
    //     private List<T> spellList {get; set;}
    //     private int spellSaveDC {get; set;}
    //     private List<SpellSlot> spellSlots;
        

    // }

    // public class SpellSlot
    // {
    //     private int slotLevel;
    //     private T spell;
    // }

}
