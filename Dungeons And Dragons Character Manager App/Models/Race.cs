namespace Dungeons_And_Dragons_Character_Manager_App.Models
{

    public enum Language
    {
    }

    public class Race
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaturityAge { get; set; }
        public int Lifespan { get; set; }
        public string Alignment { get; set; }
        public string Size { get; set; }
        public int Speed { get; set; }

        public ICollection<Language> Languages { get; set; }
        public ICollection<AbilityScoreIncrease> AbilityScoreIncreases { get; set; }

        public ICollection<string> SpecialProperties { get; set; }
    
    }
}
