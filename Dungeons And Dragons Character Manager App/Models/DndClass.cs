using System;
namespace Dungeons_And_Dragons_Character_Manager_App.Models
{
    public abstract class DndClass
    {
        public int ID {get; set;}
        public int Level {get; set;}
        public int HitDiceType {get; set;}
        public string? SubClass {get; set;}
        public List<string>? SubclassFeatures {get; set;}
        public List<Item>? ItemProficiencies {get; set;}
        public List<Skill>? SkillProficiencies {get; set;}
        public List<Ability>? SavingProficiencies {get; set;}
        public List<Item>? StartingEquipment {get; set;}
        public List<int>? AsiOnLevelUp {get; set;}

        public abstract void ShortRest();
        public abstract void LongRest();
        public abstract void LevelUp();

    }

    public class Fighter: DndClass
    {
        public string FightingStyle1 {get; set;}
        public string FightingStyle2 {get; set;}
        public int AttackCount {get; set;}
        public bool SecondWindUse {get; set;}
        public int ActionSurgeTotal {get; set;}
        public int ActionSurgeCount {get; set;}
        public int IndomnitableCharges {get; set;}
        public int IndomnitableTotal {get; set;}

        public Fighter(
            List<Item> ItemProficiencies,
            List<Skill> SkillProficiencies,
            List<Ability> SavingProficiencies,
            List<Item> StartingEquipment,
            string FightingStyle1
        ) {
            this.Level = 1;
            this.HitDiceType = 10;
            this.ItemProficiencies = ItemProficiencies;
            this.SkillProficiencies = SkillProficiencies;
            this.SavingProficiencies = SavingProficiencies;
            this.StartingEquipment = StartingEquipment;
            this.FightingStyle1 = FightingStyle1;
            this.FightingStyle2 = "";
            this.SecondWindUse = false;
            this.ActionSurgeCount = ActionSurgeCount;
            this.ActionSurgeTotal = 0;
            this.SubClass = "";
            this.SubclassFeatures = new List<string>();
            this.AttackCount = 1;
            this.IndomnitableCharges = 0;
            this.IndomnitableTotal = 0;
            this.AsiOnLevelUp = new List<int>() { 4, 6, 8, 12, 14, 16, 19 };
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

        public override void LevelUp()

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
                case 5:
                {
                    this.AttackCount = 2;
                    break;
                }
                case 7:
                {
                    this.SubclassFeatures.Add("Remarkable Athlete");
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
                case 13:
                {
                    this.IndomnitableTotal = 2;
                    break;
                }
                case 15:
                {
                    this.SubclassFeatures.Add("Superior Critical");
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
        }

    }
    
    public class Wizard: DndClass
    {
        public List<Spell> SpellList {get; set;}
        public List<SpellSlot> SpellSlots {get; set;}
        public AbilityScore SpellCastingAbility { get; set; }
        public int SpellSaveDC {get; set;}
        public int SpellAttack {get; set;}
        public string RitualCasting {get; set;}
        public string SpellCastingFocus {get; set;}
        public int ArcaneRecoveryTotal {get; set;}
        public bool ArcaneRecoveryUsed {get; set;}
        public List<Spell>? SpellMastery {get; set;}
        public List<Spell>? SignatureSpells {get; set;}

        public Wizard(
            int Level,
            string SubClass,
            List<string> SubclassFeatures,
            List<Item> ItemProficiencies,
            List<Skill> SkillProficiencies,
            List<Ability> SavingProficiencies,
            List<Item> StartingEquipment,
            List<Spell> SpellList,
            List<SpellSlot> SpellSlots,
            AbilityScore SpellCastingAbility,
            int SpellSaveDC,
            int SpellAttack,
            string SpellCastingFocus,
            int ArcaneRecoveryTotal,
            List<Spell>? SpellMastery,
            List<Spell>? SignatureSpells
        ) {
            this.Level = Level;
            this.SubClass = SubClass;
            this.SubclassFeatures = SubclassFeatures;
            this.ItemProficiencies = ItemProficiencies;
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
            this.AsiOnLevelUp = new List<int>() { 4, 8, 12, 16, 19 };
        }

        public void ResetSpellSlots()
        {
            foreach (var slot in this.SpellSlots)
            { 
                slot.resetSlot();
            }
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
                        this.SpellSlots[count].resetSlot();
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

        public override void LevelUp()
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