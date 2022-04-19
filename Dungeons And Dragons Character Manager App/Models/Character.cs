using System.ComponentModel.DataAnnotations.Schema;

namespace Dungeons_And_Dragons_Character_Manager_App.Models
{
    public class Character 
    {
        public int ID {get; set;}
        public string name {get; set;}
        public string playerName {get; set;}
        public Race Race {get; set;}
        public DndClass characterClass {get; set;}
        public ICollection<AbilityScore> abilityScores {get; set;}
        //public Background background {get; set;}
        public int currentHitPoints {get; set;}
        public int temporaryHitPoints {get; set;}
        public int maxHitPoints {get; set;}
        //public ICollection<Item> equipment {get; set;}
        public int proficiencyBonus {get; set;} 
        public int armourClass {get; set;} 
        //public ICollection<Skills> skills {get; set;} 
        //public ICollection<Item> itemProficiencies {get; set;} 
        public ICollection<Skills> skillProficiencies {get; set;} 
        public ICollection<Ability> savingProficiencies {get; set;} 
        public int experiencePoints {get; set;} 
        public int currentHitDice {get; set;} 
        public int totalHitDice {get; set;} 
        //public ICollection<Language> languages {get; set;} 
        public int numGold {get; set;} 
        public int numSilver {get; set;} 
        public int numCopper {get; set;} 
        public int numPlatinum {get; set;} 
        public int numElectrum {get; set;}


        public int AbilityCheck(string abilityName, int bonusOrPenalty=0,
                                bool advantage=false, bool disadvantage=false,
                                string skillName = "")
        {
            Random random = new Random();
            int total;
            int rollResult = random.Next(1, 21);

            if (advantage)
            {
                int secondRoll = random.Next(1, 21);
                rollResult = Math.Max(rollResult, secondRoll);
            }
            if (disadvantage)
            {
                int secondRoll = random.Next(1, 21);
                rollResult = Math.Min(secondRoll, rollResult);
            }

            AbilityScore abilityScore = abilityScores.First(score => score.Ability.Name == abilityName);            
            int modifier = abilityScore.GetModifier();
            
            total = modifier + rollResult + bonusOrPenalty;

            if (!skillName.Equals(""))
            {
                if (skillProficiencies.Any(proficiency => proficiency.Name == skillName))
                    total += proficiencyBonus;
            }

            return total;
            
        }

        public int SavingThrow(string abilityName, int bonusOrPenalty = 0, bool advantage = false, bool disadvantage = false)
        {
            int total = AbilityCheck(abilityName, bonusOrPenalty:bonusOrPenalty, advantage:advantage, disadvantage:disadvantage);

            if (savingProficiencies.Any(proficiency => proficiency.Name == abilityName))
                total += proficiencyBonus;

            return total;
        }
    }
}