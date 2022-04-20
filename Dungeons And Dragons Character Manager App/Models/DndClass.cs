using System;
namespace Dungeons_And_Dragons_Character_Manager_App.Models
{
    public abstract class DndClass
    {
        public int ID {get; set;}
        public int Level {get; set;}
        public int HitDiceType {get; set;}
        public string SubClass {get; set;}
        public ICollection<string> SubclassFeatures {get; set;}

        // protected ICollection<T> ItemProficiencies {get; set;}
        protected ICollection<string> WeaponProficiencies {get; set;}
        protected ICollection<string> ToolProficiencies {get; set;}
        protected ICollection<string> ArmourProficiencies {get; set;}
        protected ICollection<string> SkillProficiencies {get; set;}
        protected ICollection<string> SavingProficiencies {get; set;}
        protected ICollection<string> StartingEquipment {get; set;}
        protected List<int> AsiOnLevelUp {get; set;}

        public abstract void ShortRest();
        public abstract void LongRest();
        public abstract void LevelUp(string AbilityToIncrease = "");
    }

    public class Fighter: DndClass
    {
        private string FightingStyle1 {get; set;}
        private string FightingStyle2 {get; set;}
        private int AttackCount {get; set;}
        private bool SecondWindUse {get; set;}
        private int ActionSurgeTotal {get; set;}
        private int ActionSurgeCount {get; set;}
        private int IndomnitableCharges {get; set;}
        private int IndomnitableTotal {get; set;}

        // implementation of methods might need to be in a controller instead of model?

        public Fighter(
            int Level,
            ICollection<string> WeaponProficiencies,
            ICollection<string> ToolProficiencies,
            ICollection<string> ArmourProficiencies,
            ICollection<string> SkillProficiencies,
            ICollection<string> SavingProficiencies,
            ICollection<string> StartingEquipment,
            string FightingStyle1,
            string FightingStyle2,
            int ActionSurgeTotal,
            string SubClass,
            List<string> SubclassFeatures,
            int AttackCount,
            int IndomnitableTotal
        ) {
            this.Level = Level;
            this.HitDiceType = 10;
            this.WeaponProficiencies = WeaponProficiencies;
            this.ToolProficiencies = ToolProficiencies;
            this.ArmourProficiencies = ArmourProficiencies;
            this.SkillProficiencies = SkillProficiencies;
            this.SavingProficiencies = SavingProficiencies;
            this.StartingEquipment = StartingEquipment;
            this.FightingStyle1 = FightingStyle1;
            this.FightingStyle2 = FightingStyle2;
            this.SecondWindUse = false;
            this.ActionSurgeCount = ActionSurgeCount;
            this.ActionSurgeTotal = 0;
            this.SubClass = SubClass;
            this.SubclassFeatures = SubclassFeatures;
            this.AttackCount = AttackCount;
            this.IndomnitableCharges = IndomnitableCharges;
            this.IndomnitableTotal = 0;
            this.AsiOnLevelUp = new List<int>();
            this.AsiOnLevelUp.Add(4);
            this.AsiOnLevelUp.Add(6);
            this.AsiOnLevelUp.Add(8);
            this.AsiOnLevelUp.Add(12);
            this.AsiOnLevelUp.Add(14);
            this.AsiOnLevelUp.Add(16);
            this.AsiOnLevelUp.Add(19);
        }

        public override void ShortRest()
        {
            this.SecondWindUse = false;
            this.ActionSurgeCount = 0;
        }

        public override void LongRest()
        {
            this.ShortRest();
            this.IndomnitableCharges = 0;
        }

        public override void LevelUp(string AbilityToIncrease = "")
        {
            this.Level++;
            switch(this.Level)
            {
                case 2:
                {
                    this.ActionSurgeTotal = 1;
                    break;
                }
                case 3:
                {
                    this.SubClass = "Champion";
                    this.SubclassFeatures.Add("Improved Critical");
                    break;
                }
                case 4:
                {
                    break;
                }
                case 5:
                {
                    this.AttackCount = 2;
                    break;
                }
                case 6:
                {
                    break;
                }
                case 7:
                {
                    this.SubclassFeatures.Add("Remarkable Athlete");
                    break;
                }
                case 8:
                {
                    break;
                }
                case 9:
                {
                    this.IndomnitableTotal = 1;
                    break;
                }
                case 10:
                {
                    this.SubclassFeatures.Add("Additional Fighting Style");
                    break;
                }
                case 11:
                {
                    this.AttackCount = 3;
                    break;
                }
                case 12:
                {
                    break;
                }
                case 13:
                {
                    this.IndomnitableTotal = 2;
                    break;
                }
                case 14:
                {
                    break;
                }
                case 15:
                {
                    this.SubclassFeatures.Add("Superior Critical");
                    break;
                }
                case 16:
                {
                    break;
                }
                case 17:
                {
                    this.ActionSurgeTotal = 2;
                    this.IndomnitableTotal = 3;
                    break;
                }
                case 18:
                {
                    this.SubclassFeatures.Add("Survivor");
                    break;
                }
                case 19:
                {
                    break;
                }
                case 20:
                {
                    this.AttackCount = 4;
                    break;
                }
            }
        }

        public void useSecondWind() 
        {
            if (!this.SecondWindUse) 
            {
                this.SecondWindUse = true;
            }
            else
            {
                Console.Write("Second Wind already used.\n");

            }
            // else throw message/exception that it was already used
        }

    }

    // Will do wizard once the spells are done
    
    public class Wizard: DndClass
    {
        private ICollection<Spell> SpellList {get; set;}
        private ICollection<SpellSlot> SpellSlots {get; set;}
        private AbilityScore SpellCastingAbility;
        private int SpellSaveDC {get; set;}
        private int SpellAttack {get; set;}
        private string RitualCasting {get; set;}
        private string SpellCastingFocus {get; set;}
        private int ArcaneRecoveryTotal {get; set;}
        private bool ArcaneRecoveryUsed {get; set;}
        private ICollection<Spell> SpellMastery {get; set;}
        private ICollection<Spell> SignatureSpells {get; set;}

        public Wizard(
            int Level,
            string SubClass,
            ICollection<string> SubclassFeatures,
            ICollection<string> WeaponProficiencies,
            ICollection<string> ToolProficiencies,
            ICollection<string> ArmourProficiencies,
            ICollection<string> SkillProficiencies,
            ICollection<string> SavingProficiencies,
            ICollection<string> StartingEquipment,
            ICollection<Spell> SpellList,
            ICollection<SpellSlot> SpellSlots,
            AbilityScore SpellCastingAbility,
            int SpellSaveDC,
            int SpellAttack,
            string SpellCastingFocus,
            int ArcaneRecoveryTotal,
            ICollection<Spell> SpellMastery,
            ICollection<Spell> SignatureSpells
        ) {
            this.Level = Level;
            this.SubClass = SubClass;
            this.SubclassFeatures = SubclassFeatures;
            this.WeaponProficiencies = WeaponProficiencies;
            this.ToolProficiencies = ToolProficiencies;
            this.ArmourProficiencies = ArmourProficiencies;
            this.SkillProficiencies = SkillProficiencies;
            this.SavingProficiencies = SavingProficiencies;
            this.StartingEquipment = StartingEquipment;
            this.SpellList = SpellList;
            this.SpellSlots = SpellSlots;
            this.SpellCastingAbility = SpellCastingAbility;
            this.SpellSaveDC = SpellSaveDC;
            this.SpellAttack = SpellAttack;
            this.RitualCasting = "You can cast a wizard spell as a ritual if that spell has the ritual tag and you have the spell in your spellbook. You don't need to have the spell prepared.";
            this.SpellCastingFocus = SpellCastingFocus;
            this.ArcaneRecoveryTotal = (this.Level/2) + (this.Level % 2);
            this.SpellMastery = SpellMastery;
            this.SignatureSpells = SignatureSpells;
            this.AsiOnLevelUp = new List<int>();
            this.AsiOnLevelUp.Add(4);
            this.AsiOnLevelUp.Add(8);
            this.AsiOnLevelUp.Add(12);
            this.AsiOnLevelUp.Add(16);
            this.AsiOnLevelUp.Add(19);
        }

        public void ResetSpellSlots()
        {
            for (int i = 0; i < this.SpellSlots.Count; i++)
            {
                this.SpellSlots[i].resetSlot();
            }
        }

        public bool ArcaneRecoveryHigh()
        {
            if (!ArcaneRecoveryUsed)
            {
                int HalfLevel = (this.Level/2) + (this.Level % 2);
                int count = this.SpellSlots.Count;
                while (HalfLevel > 0)
                {
                    if ((!this.SpellSlots[count].usedUp) & (this.SpellSlots[count].level <= HalfLevel))
                    {
                        this.SpellSlots.resetSlot();
                    }
                    count--;
                }
            }
            else 
            {
                Console.Write("Arcane Recovery already used.");
            }
            return true;
        }

        public bool ArcaneRecoveryLow()
        {
            if (!ArcaneRecoveryUsed)
            {
                int HalfLevel = (this.Level/2) + (this.Level % 2);
                int count = 0;
                while (HalfLevel > 0)
                {
                    if ((!this.SpellSlots[count].usedUp) & (this.SpellSlots[count].level <= HalfLevel))
                    {
                        this.SpellSlots.resetSlot();
                    }
                    count++;
                }
            }
            else 
            {
                Console.Write("Arcane Recovery already used.");
            }
            return true;
        }

        public override void ShortRest()
        {
            this.ArcaneRecoveryUsed = this.ArcaneRecoveryLow();
        }

        public override void LongRest()
        {
            this.ShortRest();
            this.ResetSpellSlots();
        }

        public override void LevelUp(string AbilityToIncrease = "")
        {
            this.Level++;
            switch(this.Level)
            {
                case 2:
                {
                    this.ArcaneRecoveryTotal = (this.Level/2) + (this.Level % 2);
                    this.SpellSlots.Add(new SpellSlot(1));
                    this.SubClass = "School of Evocation";
                    this.SubclassFeatures.Add("Evocation Savant");
                    this.SubclassFeatures.Add("Sculpt Spells");
                    break;
                }
                case 3:
                {
                    this.ArcaneRecoveryTotal = (this.Level/2) + (this.Level % 2);
                    this.SpellSlots.Add(new SpellSlot(1));
                    this.SpellSlots.Add(new SpellSlot(2));
                    this.SpellSlots.Add(new SpellSlot(2));
                    break;
                }
                case 4:
                {
                    this.ArcaneRecoveryTotal = (this.Level/2) + (this.Level % 2);
                    this.SpellSlots.Add(new SpellSlot(2));
                    break;
                }
                case 5:
                {
                    this.ArcaneRecoveryTotal = (this.Level/2) + (this.Level % 2);
                    this.SpellSlots.Add(new SpellSlot(3));
                    this.SpellSlots.Add(new SpellSlot(3));
                    break;
                }
                case 6:
                {
                    this.ArcaneRecoveryTotal = (this.Level/2) + (this.Level % 2);
                    this.SpellSlots.Add(new SpellSlot(3));
                    this.SubclassFeatures.Add("Potent Cantrip");
                    break;
                }
                case 7:
                {
                    this.ArcaneRecoveryTotal = (this.Level/2) + (this.Level % 2);
                    this.SpellSlots.Add(new SpellSlot(4));
                    break;
                }
                case 8:
                {
                    this.ArcaneRecoveryTotal = (this.Level/2) + (this.Level % 2);
                    this.SpellSlots.Add(new SpellSlot(4));
                    break;
                }
                case 9:
                {
                    this.ArcaneRecoveryTotal = (this.Level/2) + (this.Level % 2);
                    this.SpellSlots.Add(new SpellSlot(4));
                    this.SpellSlots.Add(new SpellSlot(5));
                    break;
                }
                case 10:
                {
                    this.ArcaneRecoveryTotal = (this.Level/2) + (this.Level % 2);
                    this.SpellSlots.Add(new SpellSlot(5));
                    this.SubclassFeatures.Add("Empowered Evocation");
                    break;
                }
                case 11:
                {
                    this.ArcaneRecoveryTotal = (this.Level/2) + (this.Level % 2);
                    this.SpellSlots.Add(new SpellSlot(6));
                    break;
                }
                case 12:
                {
                    this.ArcaneRecoveryTotal = (this.Level/2) + (this.Level % 2);
                    break;
                }
                case 13:
                {
                    this.ArcaneRecoveryTotal = (this.Level/2) + (this.Level % 2);
                    this.SpellSlots.Add(new SpellSlot(7));
                    break;
                }
                case 14:
                {
                    this.ArcaneRecoveryTotal = (this.Level/2) + (this.Level % 2);
                    this.SubclassFeatures.Add("Overchannel");
                    break;
                }
                case 15:
                {
                    this.ArcaneRecoveryTotal = (this.Level/2) + (this.Level % 2);
                    this.SpellSlots.Add(new SpellSlot(8));
                    break;
                }
                case 16:
                {
                    this.ArcaneRecoveryTotal = (this.Level/2) + (this.Level % 2);
                    break;
                }
                case 17:
                {
                    this.ArcaneRecoveryTotal = (this.Level/2) + (this.Level % 2);
                    this.SpellSlots.Add(new SpellSlot(9));
                    break;
                }
                case 18:
                {
                    this.ArcaneRecoveryTotal = (this.Level/2) + (this.Level % 2);
                    this.SpellSlots.Add(new SpellSlot(5));
                    break;
                }
                case 19:
                {
                    this.ArcaneRecoveryTotal = (this.Level/2) + (this.Level % 2);
                    this.SpellSlots.Add(new SpellSlot(6));
                    break;
                }
                case 20:
                {
                    this.ArcaneRecoveryTotal = (this.Level/2) + (this.Level % 2);
                    this.SpellSlots.Add(new SpellSlot(7));
                    break;
                }
            }
        }

    }

}
