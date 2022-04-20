using Dungeons_And_Dragons_Character_Manager_App.Models;

namespace Dungeons_And_Dragons_Character_Manager_App.Data
{
    public class DbInitializer
    {

        public static void Initialize(CharacterManagerContext context)
        {
            /*
            if (context.Races.Any())
            {
                return; //Db has already been initialized
            }
            */

            var races = new Race[]
            {
                new Race{Name="Dwarf", MaturityAge=50, Lifespan=350, Size="Medium", Alignment="Lawful", Speed=25 }
            };
            context.Races.AddRange(races);
            context.SaveChanges();

            /*
            var abilities = new Ability[]
            {
                new Ability{Name="Constitution", Description="" }
            };
            context.Abilities.AddRange(abilities);
            context.SaveChanges();

            var abilityScoreIncreases = new AbilityScoreIncrease[]
            {
                new AbilityScoreIncrease{RaceID=5, AbilityID=2, Increase=2 }
            };
            context.AbilityScoreIncreases.AddRange(abilityScoreIncreases);
            context.SaveChanges();
            */
        }
    }
}
