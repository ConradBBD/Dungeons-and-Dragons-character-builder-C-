using System.ComponentModel.DataAnnotations.Schema;

namespace Dungeons_And_Dragons_Character_Manager_App.Models
{
    public class Character 
    {
        public int ID {get; set;}
        public string Name {get; set;}
        public Race? Race {get; set;}
        public DndClass? CharacterClass {get; set;}
        public ICollection<AbilityScore>? AbilityScores {get; set;}
        public Background? Background { get; set; }
        public int CurrentHitPoints {get; set;}
        public int TemporaryHitPoints {get; set;}
        public int MaxHitPoints {get; set;}
        public ICollection<Item>? Equipment {get; set;}
        public int ProficiencyBonus {get; set;} 
        public int ArmourClass {get; set;} 
        public ICollection<Skill>? Skills {get; set;} 
        public ICollection<Item>? ItemProficiencies {get; set;} 
        public ICollection<Skill>? SkillProficiencies {get; set;} 
        public ICollection<Ability>? SavingProficiencies {get; set;}
        public int CurrentHitDice {get; set;} 
        public int TotalHitDice {get; set;} 
        public ICollection<string>? Languages {get; set;} 
        public int NumGold {get; set;} 
        public int NumSilver {get; set;} 
        public int NumCopper {get; set;} 
        public int NumPlatinum {get; set;} 
        public int NumElectrum {get; set;}
        public List<int>? AsiOnLevel {get; set;}

        public Character(string name)
        {
            Name = name;
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
            if (this.AsiOnLevel.Contains(this.CharacterClass.Level))
            {
                AbilityScore toUpdate = this.AbilityScores.First(score => score.Ability.Equals(ability));

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

            AbilityScore abilityScore = AbilityScores.First(score => score.Ability.Equals(ability));            
            int modifier = abilityScore.Modifier;
            
            total = modifier + rollResult;
            return total;
            
        }

        public int SkillCheck(Skill skill)
        {
            int total = AbilityCheck(skill.parentAbility);

            if (SkillProficiencies.Any(proficiency => proficiency.Equals(skill)))
                total += ProficiencyBonus;

            return total;
            
        }

        public int SavingThrow(Ability ability)
        {
            int total = AbilityCheck(ability);

            if (SavingProficiencies.Any(proficiency => proficiency.Equals(ability)))
                total += ProficiencyBonus;

            return total;
        }

        public string CastSpell(Spell spell, int desiredLevel)
        {
            Wizard wizard = (Wizard)this.CharacterClass;
            var spellcast = spell.castSpell(wizard.SpellSlots, desiredLevel);
            wizard.SpellSlots = spellcast.Item1;
            return spellcast.Item3;
        }

        public string WeaponAttack(Weapon weapon, Ability ability)
        {
            int attack = AbilityCheck(ability);

            if (ItemProficiencies.Any(proficiency => proficiency.Equals(weapon)))
            {
                attack += ProficiencyBonus;
            }
            
            Random random = new Random();
            int damage = 0;
            foreach (var dice in weapon.DamageDice)
            {
                damage += random.Next(1, dice);
            }

            string weaponAttack = $"Weapon: {weapon.Name} / Attack roll: {attack} / Damage roll: {damage}";

            return weaponAttack;
        }
        
    }
}