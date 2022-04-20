namespace Dungeons_And_Dragons_Character_Manager_App.Models;

public class Spell{
    public int Id { get; }
    int Range { get; set; }
    int Level { get; set; }
    string? HigherLevel { get; set; }
    bool Ritual { get; set; }
    public string Name { get; private set; }
    string School { get; set; }
    string? MaterialComponent { get; set; }
    bool MaterialComponentConsumed { get; set; }
    string? VerbalComponent { get; set; }
    string? SomaticComponent { get; set; }
    AreaOfEffect AreaOfEffect { get; set; }
    Duration CastingTime { get; set; }
    string Description { get; set; }
    Duration SpellDuration { get; set; }

    public Spell(
        Duration castingTime,
        Duration spellDuration,
        AreaOfEffect areaOfEffect, 
        int range=0,
        int level=0,
        bool ritual=false, 
        string name="Unnamed", 
        string school="Illusion",
        string description="Removes a person's name forever.", 
        string? higherLevel=null,
        string? verbalComponent="Scream a little.",
        string? somaticComponent="Beat your chest.", 
        string? materialComponent="A sock.",
        bool materialComponentConsumed=false
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
        this.SpellDuration = spellDuration;
        this.VerbalComponent = verbalComponent;
        this.SomaticComponent = somaticComponent; 
        this.MaterialComponent = materialComponent;
        this.MaterialComponentConsumed = materialComponentConsumed; 
    }

    public Tuple<List<SpellSlot>, string> castSpell(List<SpellSlot> characterSlots, int desiredLevel){
        if (this.Level == 0)
            return Tuple.Create(characterSlots, "Cantrip. No slot used.");
        
        int slotIndex = characterSlots.FindIndex((slot) => (
            !slot.usedUp && 
            slot.level == desiredLevel && 
            desiredLevel >= this.Level
        ));
        
        if (slotIndex == -1)
            return Tuple.Create(characterSlots, "No available slots can cast that spell.");

        characterSlots[slotIndex].usedUp = true;

        string castingLevel = String.Format("The spell was cast at level {0}\n", desiredLevel);
        return Tuple.Create(characterSlots, castingLevel + this.ToString());
    }

    public override string ToString()
    {
        return String.Format(
            "Name: {0} / Casting Time: {1} / Range: {2} / Area Of Effect: {3} /\n" +
            "Description: {4} /\n" +
            "Verbal Component: {5} /\n Somatic Component: {6} /\n Material Component: {7} /\n" +
            "At A Higher Level: {8} \n" +
            "Can Be A Ritual: {9} / School: {10} / Original Level: {11} /",
            new object[] {this.Name, this.CastingTime, this.Range, this.AreaOfEffect, this.Description,
            this.VerbalComponent ?? "Not Required", this.SomaticComponent ?? "Not Required", this.MaterialComponent ?? "Not Required",
            this.HigherLevel ?? "None", this.Ritual, this.School, this.Level}
        );
    }

}