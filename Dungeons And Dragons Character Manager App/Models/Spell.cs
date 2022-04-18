namespace Dungeons_And_Dragons_Character_Manager_App.Models;

public class Spell{
    public int Id { get; }
    int Range { get; set; } = 0;
    int Level { get; set; } = 0;
    string? HigherLevel { get; set; }
    bool Ritual { get; set; } = false;
    string Name { get; set; } = "Unnamed";
    string School { get; set; } = "Illusion";
    string MaterialComponent { get; set; } = "A sock.";
    bool MaterialComponentConsumed { get; set; } = false;
    string VerbalComponent { get; set; } = "Scream a little.";
    string SomaticComponent { get; set; } = "Beat your chest.";
    AreaOfEffect AreaOfEffect { get; set; } = AreaOfEffect.LINE;
    Duration CastingTime { get; set; } = new Duration(1, "Action");
    string Description { get; set; } = "Removes a person's name forever.";

    public Spell(
        int range,
        int level,
        bool ritual, 
        string name, 
        string school,
        string description, 
        string higherLevel,
        Duration castingTime, 
        AreaOfEffect areaOfEffect, 
        string verbalComponent,
        string somaticComponent, 
        string materialComponent,
        bool materialComponentConsumed
    ){
        this.Name = name; 
        this.Range = range;
        this.Level = level;
        this.Ritual = ritual; 
        this.School = school;
        this.HigherLevel = higherLevel;
        this.Description = description; 
        this.CastingTime = castingTime; 
        this.AreaOfEffect = areaOfEffect; 
        this.VerbalComponent = verbalComponent;
        this.SomaticComponent = somaticComponent; 
        this.MaterialComponent = materialComponent;
        this.MaterialComponentConsumed = materialComponentConsumed; 
    }

    public Tuple<List<SpellSlot>, bool, string> castSpell(List<SpellSlot> characterSlots, int desiredLevel){
        if (this.Level == 0)
            return Tuple.Create(characterSlots, true, "Cantrip spell. No slot used.");

        SpellSlot? chosen;
        List<SpellSlot> castable = characterSlots.Where((slot) => (slot.level >= this.Level && !slot.usedUp)).ToList();
        
        if (!castable.Any()){
            return Tuple.Create(characterSlots, false, "No available slots can cast that spell.");
        }
             
        // Find a slot of the desired level. If there is none, pick the first castable one
        chosen = castable.Find((spell) => spell.level == desiredLevel);
        chosen = chosen ?? castable.First();

        // Use up the chosen slot. CONFIRM IF REFERENCE WILL AFFECT THE CHARACTER SLOTS LIST
        chosen.usedUp = true;
        
        string castingLevel = String.Format("The spell was cast at level {0}\n", chosen.level);

        return Tuple.Create(characterSlots, true, castingLevel + this.ToString());
    }

    public override string ToString()
    {
        return String.Format(
            "Name: {0} / Casting Time As Ritual {1} / Range: {2} / Area Of Effect: {3} /\n" +
            "Description: {4} /\n" +
            "Verbal Component: {5} /\n Somatic Component: {6} /\n Material Component: {7} /\n" +
            "At A Higher Level: {8} \n" +
            "Can Be A Ritual: {9} / School: {10} / Original Level: {11} /",
            new object[] {this.Name, this.CastingTime, this.Range, this.AreaOfEffect, this.Description,
            this.VerbalComponent, this.SomaticComponent, this.MaterialComponent,
            this.HigherLevel ?? "None", this.Ritual, this.School, this.Level}
        );
    }

}