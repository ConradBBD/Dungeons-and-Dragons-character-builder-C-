using System.ComponentModel.DataAnnotations.Schema;

namespace Dungeons_And_Dragons_Character_Manager_App.Models
{
    public class Character
    {
        public int ID { get; set; }
        public string name { get; set; }
        public Race? Race { get; set; }
        public DndClass? CharacterClass { get; set; }
        public List<AbilityScore>? AbilityScores { get; set; }
        //public Background? Background { get; set; }
        public int currentHitPoints { get; set; }
        public int temporaryHitPoints { get; set; }
        public int maxHitPoints { get; set; }
        [NotMapped]
        public List<Item>? Equipment { get; set; }
        public int proficiencyBonus { get; set; }
        public int armourClass { get; set; }
        [ForeignKey("Skill")]
        public List<Skill>? Skills { get; set; }
        [NotMapped]
        public List<Item>? ItemProficiencies { get; set; }
        [ForeignKey("SkillProf")]
        public List<Skill>? SkillProficiencies { get; set; }
        public List<Ability>? SavingProficiencies { get; set; }
        public int currentHitDice { get; set; }
        public int totalHitDice { get; set; }
        [NotMapped]
        public List<string>? Languages { get; set; }
        public int numGold { get; set; }
        public int numSilver { get; set; }
        public int numCopper { get; set; }
        public int numPlatinum { get; set; }
        public int numElectrum { get; set; }

        [NotMapped]
        public List<int>? AsiOnLevel { get; set; }

        public Character(string name)
        {
            this.name = name;
        }

        public Character() { }

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
            int total = AbilityCheck(skill.ParentAbility);

            if (SkillProficiencies.Any(proficiency => proficiency.Equals(skill)))
                total += proficiencyBonus;

            return total;
            
        }

        public int SavingThrow(Ability ability)
        {
            int total = AbilityCheck(ability);

            if (SavingProficiencies.Any(proficiency => proficiency.Equals(ability)))
                total += proficiencyBonus;

            return total;
        }

        public string CastSpell(Spell spell, int desiredLevel)
        {
            Wizard wizard = (Wizard)this.CharacterClass;
            var spellcast = spell.castSpell(wizard.SpellSlots, desiredLevel);
            wizard.SpellSlots = spellcast.Item1;
            return spellcast.Item2;
        }

        public string WeaponAttack(Weapon weapon, Ability ability)
        {
            int attack = AbilityCheck(ability);

            if (ItemProficiencies.Any(proficiency => ((Weapon)proficiency).Equals(weapon)))
            {
                attack += proficiencyBonus;
            }
            
            Random random = new Random();
            int damage = 0;
            foreach (var dice in weapon.DamageDice)
            {
                damage += random.Next(1, (int)dice);
            }

            string weaponAttack = $"Weapon: {weapon.Name} / Attack roll: {attack} / Damage roll: {damage}";

            return weaponAttack;
        }
    }
}