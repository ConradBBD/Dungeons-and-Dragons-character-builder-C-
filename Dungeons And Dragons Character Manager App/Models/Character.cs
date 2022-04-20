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
        public Background background {get; set;}
        public int currentHitPoints {get; set;}
        public int temporaryHitPoints {get; set;}
        public int maxHitPoints {get; set;}
        public ICollection<Item> equipment {get; set;}
        public int proficiencyBonus {get; set;} 
        public int armourClass {get; set;} 
        public ICollection<Skills> skills {get; set;} 
        public ICollection<Item> itemProficiencies {get; set;} 
        public ICollection<Skill> skillProficiencies {get; set;} 
        public ICollection<Ability> savingProficiencies {get; set;} 
        // public int experiencePoints {get; set;} 
        public int currentHitDice {get; set;} 
        public int totalHitDice {get; set;} 
        //public ICollection<Language> languages {get; set;} 
        public int numGold {get; set;} 
        public int numSilver {get; set;} 
        public int numCopper {get; set;} 
        public int numPlatinum {get; set;} 
        public int numElectrum {get; set;}
        public List<int> asiOnLevel {get; set;}

        public Character(
            int ID,
            string name,
            string playerName,
            Race race,
            DndClass characterClass,
            ICollection<AbilityScore> abilityScores,
            Background background,
            int currentHitPoints,
            int temporaryHitPoints,
            int maxHitPoints,
            ICollection<Item> equipment,
            int proficiencyBonus,
            int armourClass,
            ICollection<Skills> skills,
            ICollection<Item> itemProficiencies,
            ICollection<Skills> skillProficiencies,
            ICollection<AbilityScore> savingProficiencies,
            int experiencePoints,
            int currentHitDice,
            int totalHitDice,
            // ICollection<Language> languages,
            int numGold,
            int numSilver,
            int numCopper,
            int numPlatinum,
            int numElectrum
        )
        {
            this.ID = ID;
            this.name = name;
            this.playerName = playerName;
            this.Race = Race;
            this.characterClass = characterClass;
            this.abilityScores = abilityScores;
            this.background = background;
            this.currentHitPoints = currentHitPoints;
            this.temporaryHitPoints = temporaryHitPoints;
            this.maxHitPoints = maxHitPoints;
            this.equipment = equipment;
            this.proficiencyBonus = proficiencyBonus;
            this.armourClass = armourClass;
            this.skills = skills;
            this.itemProficiencies = itemProficiencies;
            this.skillProficiencies = skillProficiencies;
            this.savingProficiencies = savingProficiencies;
            this.experiencePoints = experiencePoints;
            this.currentHitDice = currentHitDice;
            this.totalHitDice = totalHitDice;
            // this.languages = languages;
            this.numGold = numGold;
            this.numSilver = numSilver;
            this.numCopper = numCopper;
            this.numElectrum = numElectrum;
            this.numPlatinum = numPlatinum;
            this.asiOnLevel = this.characterClass.AsiOnLevelUp;
        }

        public void ShortRest()
        {
            this.CharacterClass.ShortRest();
        }

        public void LongRest()
        {
            this.CharacterClass.LongRest();
        }

        public void LevelUp(Ability ability)
        {
            if (this.asiOnLevel.Contains(this.CharacterClass.Level))
            {
                AbilityScore toUpdate = this.abilityScores.First(score => score.Ability.Equals(Ability));

                toUpdate.Score++;
                if (toUpdate.Score % 2 == 0)
                {
                    toUpdate.Modifier++;
                }
                
            }
            this.CharacterClass.LevelUp();
        }
        

        public int AbilityCheck(Ability ability)
        {
            Random random = new Random();
            int total;
            int rollResult = random.Next(1, 21);

            AbilityScore abilityScore = abilityScores.First(score => score.Ability.Equals(ability));            
            int modifier = abilityScore.Modifier;
            
            total = modifier + rollResult;
            return total;
            
        }

        public int SkillCheck(Skill skill)
        {
            int total = AbilityCheck(skill.parentAbility);

            if (skillProficiencies.Any(proficiency => proficiency.Equals(skill)))
                total += proficiencyBonus;

            return total;
            
        }

        public int SavingThrow(Ability ability)
        {
            int total = AbilityCheck(ability);

            if (savingProficiencies.Any(proficiency => proficiency.Equals(ability)))
                total += proficiencyBonus;

            return total;
        }

        public string CastSpell(Spell spell, int desiredLevel)
        {
            var spellcast = spell.castSpell(this.characterClass.SpellSlots, desiredLevel);
            this.characterClass.SpellSlots = spellcast.Item1;
            return spellcast.Item3;
        }

        public string WeaponAttack(Weapon weapon, Ability ability)
        {
            int attack = AbilityCheck(ability);

            if (itemProficiencies.Any(proficiency => proficiency.Equals(weapon)))
            {
                attack += proficiencyBonus;
            }
            
            Random random = new Random();
            int damage = 0;
            foreach (var dice in weapon.DamageDice)
            {
                damage += random.Next(1, dice);
            }

            string weaponAttack = $"Weapon: {weapon.Name} / Attack roll: {attack} / Damage roll: {damage}";

            return total;
        }
        
    }
}