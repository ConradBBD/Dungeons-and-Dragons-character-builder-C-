namespace Dungeons_And_Dragons_Character_Manager_App.Models
{
    public class Character 
    {
        public int ID {get; set;}
        public string name {get; set;}
        public string playerName {get; set;}
        public Race? Race {get; set;}
        public DndClass? characterClass {get; set;}
        public ICollection<AbilityScore>? abilityScores {get; set;}
        //public Background background {get; set;}
        public int currentHitPoints {get; set;}
        public int temporaryHitPoints {get; set;}
        public int maxHitPoints {get; set;}
        public ICollection<Item> equipment {get; set;}
        public int proficiencyBonus {get; set;} 
        public int armourClass {get; set;} 
        //public ICollection<Skills> skills {get; set;} 
        //public ICollection<Item> itemProficiencies {get; set;} 
        public ICollection<Skill> skillProficiencies {get; set;} 
        public ICollection<Ability> savingProficiencies {get; set;} 
        public int experiencePoints {get; set;} 
        public int currentHitDice {get; set;} 
        public int totalHitDice {get; set;} 
        public ICollection<Language> languages {get; set;} 
        public int numGold {get; set;} 
        public int numSilver {get; set;} 
        public int numCopper {get; set;} 
        public int numPlatinum {get; set;} 
        public int numElectrum {get; set;} 
    }
}