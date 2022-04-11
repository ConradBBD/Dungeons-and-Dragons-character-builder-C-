namespace Dungeons_And_Dragons_Character_Manager_App.Models
{
    public class Ability 
    {
        public int ID { get; set; }
    }

    public class AbilityScoreIncreases
    {
        public int RaceID { get; set; }
        public int AbilityID { get; set; }
        public Race Race { get; set; }
        public Ability Ability { get; set; }

        public int Increase { get; set; }

    }
}