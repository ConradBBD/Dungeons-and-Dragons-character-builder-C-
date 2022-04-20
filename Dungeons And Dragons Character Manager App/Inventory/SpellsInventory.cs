namespace Dungeons_And_Dragons_Character_Manager_App.DefaultData;

using Dungeons_And_Dragons_Character_Manager_App.Models;

public static class SpellsInventory{

    private static List<Spell> ListOfSpells { get; set; } = new List<Spell>();

    public static void Generate(){
        generateCantrips();
    }

    public static List<Spell> getAllSpells(){
        if (ListOfSpells.Count() == 0)
            Generate();
        
        return ListOfSpells;
    }

    public static List<Spell> getSpecifiedSpells(List<string> spellsToFind){
        if (ListOfSpells.Count() == 0)
            Generate();

        spellsToFind.ForEach((spellName) => spellName.ToLower().Trim());
        return ListOfSpells.FindAll((spell) =>
            spellsToFind.Contains(spell.Name.ToLower())
        );
    }

    private static void generateCantrips(){
        ListOfSpells.Add(new Spell(
            spellDuration: new Duration(0, "Instantaneous"),
            castingTime: new Duration(0, "Instantaneous"),
            areaOfEffect: AreaOfEffect.LINE,
            range: 60,
            level: 0,
            ritual: false,
            name: "Acid Splash",
            school: "Conjuration",
            description: @"You hurl a bubble of acid. Choose one creature you can see within range,
            or choose two creatures you can see within range that are within 5 feet of each other. 
            A target must succeed on a Dexterity saving throw or take 1d6 acid damage.",
            higherLevel: "This spell's damage increases by 1d6 when you reach 5th level (2d6), 11th level (3d6), and 17th level (4d6).",
            verbalComponent: "Eructo di Toxicum",
            somaticComponent: @"Wave your palm in a circular motion, at the end of which you will slightly retract your fingers.
            Pull back your wrist, and then thrust your arm forward with an open palm.",
            materialComponent: null,
            materialComponentConsumed: false
          )
        );

        ListOfSpells.Add(new Spell(
            spellDuration: new Duration(1, "Hour"),
            castingTime: new Duration(1, "Action"),
            areaOfEffect: AreaOfEffect.SELF,
            range: 20,
            level: 0,
            ritual: false,
            name: "Light",
            school: "Evocation",
            description: @"You touch one object that is no larger than 10 feet in any dimension.
            Until the spell ends, the object sheds bright light in a 20-foot radius and dim light for an additional 20 feet.
            The light can be colored as you like. Completely covering the object with something opaque blocks the light. 
            The spell ends if you cast it again or dismiss it as an action.
            If you target an object held or worn by a hostile creature, that creature must succeed on a Dexterity saving throw to avoid the spell.",
            higherLevel: null,
            verbalComponent: "Lux!",
            somaticComponent: null,
            materialComponent: "Firefly or phosphorescent moss",
            materialComponentConsumed: false
          )
        );

        ListOfSpells.Add(new Spell(
            spellDuration: new Duration(1, "Minute"),
            castingTime: new Duration(1, "Action"),
            areaOfEffect: AreaOfEffect.CUBE,
            range: 30,
            level: 0,
            ritual: false,
            name: "Minor Illusion",
            school: "Illusion",
            description: @"You create a sound or an image of an object within range that lasts for the duration.
            The illusion also ends if you dismiss it as an action or cast this spell again.
            If you create a sound, its volume can range from a whisper to a scream. It can be your voice, someone else's voice,
            a lion's roar, a beating of drums, or any other sound you choose. The sound continues unabated throughout the duration,
            or you can make discrete sounds at different times before the spell ends.
            
            If you create an image of an object—such as a chair, muddy footprints, or a small chest—it must be no larger than a 5-foot cube.
            The image can't create sound, light, smell, or any other sensory effect. Physical interaction with the image reveals it to be an illusion,
            because things can pass through it. 
            
            If a creature uses its action to examine the sound or image, the creature can determine that it is an illusion
            with a successful Intelligence (Investigation) check against your spell save DC. 
            If a creature discerns the illusion for what it is, the illusion becomes faint to the creature.",
            higherLevel: null,
            verbalComponent: null,
            somaticComponent: "Pinger Me Picturam",
            materialComponent: "A bit of fleece",
            materialComponentConsumed: false
          )
        );
    }
}  