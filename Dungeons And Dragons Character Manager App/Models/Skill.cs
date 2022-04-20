namespace Dungeons_And_Dragons_Character_Manager_App.Models
{
    public class Skill
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Ability ParentAbility { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return this == null;
            if (obj.GetType() != typeof(Ability)) return false;

            Ability other = (Ability)obj;
            return Name == other.Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

}
