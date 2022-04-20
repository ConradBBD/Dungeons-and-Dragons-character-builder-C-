namespace Dungeons_And_Dragons_Character_Manager_App.Models
{
    public class AbilityScore
    {
        public int ID { get; set; }
        public int CharacterID { get; set; }
        public int AbilityID { get; set; }
        public Character Character { get; set; }
        public Ability Ability { get; set; }
        public int Score { get; set; }

        public int Modifier { get; set; }

        public void SetModifier()
        {
            Modifier = (Score - 10)/2; 
        }


    }
}
