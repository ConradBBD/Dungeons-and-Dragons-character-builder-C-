namespace Dungeons_And_Dragons_Character_Manager_App.Models
{
    public class Character 
    {
        public int ID {get; set;}
        public string Name {get; set;}
        public string PlayerName {get; set;}
        public Race Race {get; set;}
        public DndClass CharacterClass {get; set;}
        public ICollection<AbilityScore> AbilityScores {get; set;}
        public Background Background {get; set;}
        public int CurrentHitPoints {get; set;}
        public int TemporaryHitPoints {get; set;}
        public int MaxHitPoints {get; set;}
        public ICollection<Item> Equipment {get; set;}
        public int ProficiencyBonus {get; set;} 
        public int ArmourClass {get; set;} 
        public ICollection<Skills> Skills {get; set;} 
        public ICollection<Item> ItemProficiencies {get; set;} 
        public ICollection<Skills> SkillProficiencies {get; set;} 
        public ICollection<AbilityScore> SavingProficiencies {get; set;} 
        public int ExperiencePoints {get; set;} 
        public int CurrentHitDice {get; set;} 
        public int TotalHitDice {get; set;} 
        public ICollection<Language> Languages {get; set;} 
        public int NumGold {get; set;} 
        public int NumSilver {get; set;} 
        public int NumCopper {get; set;} 
        public int NumPlatinum {get; set;} 
        public int NumElectrum {get; set;}
        public List<int> AsiOnLevel {get; set;}

        public Character(
            int ID,
            string Name,
            string PlayerName,
            Race Race,
            DndClass CharacterClass,
            ICollection<AbilityScore> AbilityScores,
            Background Background,
            int CurrentHitPoints,
            int TemporaryHitPoints,
            int MaxHitPoints,
            ICollection<Item> Equipment,
            int ProficiencyBonus,
            int ArmourClass,
            ICollection<Skills> Skills,
            ICollection<Item> ItemProficiencies,
            ICollection<Skills> SkillProficiencies,
            ICollection<AbilityScore> SavingProficiencies,
            int ExperiencePoints,
            int CurrentHitDice,
            int TotalHitDice,
            ICollection<Language> Languages,
            int NumGold,
            int NumSilver,
            int NumCopper,
            int NumPlatinum,
            int NumElectrum
        )
        {
            this.ID = ID;
            this.Name = Name;
            this.PlayerName = PlayerName;
            this.Race = Race;
            this.CharacterClass = CharacterClass;
            this.AbilityScores = AbilityScores;
            this.Background = Background;
            this.CurrentHitPoints = CurrentHitPoints;
            this.TemporaryHitPoints = TemporaryHitPoints;
            this.MaxHitPoints = MaxHitPoints;
            this.Equipment = Equipment;
            this.ProficiencyBonus = ProficiencyBonus;
            this.ArmourClass = ArmourClass;
            this.Skills = Skills;
            this.ItemProficiencies = ItemProficiencies;
            this.SkillProficiencies = SkillProficiencies;
            this.SavingProficiencies = SavingProficiencies;
            this.ExperiencePoints = ExperiencePoints;
            this.CurrentHitDice = CurrentHitDice;
            this.TotalHitDice = TotalHitDice;
            this.Languages = Languages;
            this.NumGold = NumGold;
            this.NumSilver = NumSilver;
            this.NumCopper = NumCopper;
            this.NumElectrum = NumElectrum;
            this.NumPlatinum = NumPlatinum;
            this.AsiOnLevel = this.CharacterClass.AsiOnLevelUp;
        }

        public void ShortRest()
        {
            this.CharacterClass.ShortRest();
        }

        public void LongRest()
        {
            this.CharacterClass.LongRest();
        }

        public void LevelUp(string AbilityToIncrease)
        {
            if (this.AsiOnLevel.Contains(this.CharacterClass.Level))
            {
                for (int i = 0; i < 6; i++)
                {
                    if (this.AbilityScores[i].Ability.Name.Equals(AbilityToIncrease))
                    {
                        this.AbilityScores[i].Score++;
                    }
                }
            }
            this.CharacterClass.LevelUp();
        }
    }
}