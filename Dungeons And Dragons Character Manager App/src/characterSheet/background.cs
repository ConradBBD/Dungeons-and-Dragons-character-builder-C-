using System;

public class Background {

    private string personalityTraits;
    private string ideals;
    private string bonds;
    private string flaws;
    private string characterBackground;
    private string characterClass;
    private int level;
    private string alignment;
    private string race;
    private string playerName;
    private int age;
    private int height;
    private int weight;
    private string eyes;
    private string skin;
    private string hair;
    private string characterBackstory;

    public Background(
        string newPersonalityTraits,
        string newIdeals,
        string newBonds,
        string newFlaws,
        string newCharacterBackground,
        string newCharacterClass,
        int newLevel,
        string newAlignment,
        string newRace,
        string newPlayerName,
        int newAge,
        int newHeight,
        string newEyes,
        string newSkin,
        string newHair,
        string newCharacterBackstory
    ) {

        personalityTraits = newPersonalityTraits;
        ideals = newIdeals;
        bonds = newBonds;
        flaws = newFlaws;
        characterBackground = newCharacterBackground;
        characterClass = newCharacterClass;
        level = newLevel;
        alignment = newAlignment;
        race = newRace;
        playerName = newPlayerName;
        age = newAge;
        height = newHeight;
        eyes = newEyes;
        skin = newSkin;
        hair = newHair;
        characterBackstory = newCharacterBackstory;
    }
    public string getPersonalityTraits (){

        return personalityTraits;
    }
    public void updatePersonalityTraits (string newPersonalityTraits){

        try{

            personalityTraits = newPersonalityTraits;
        } catch {

            Console.WriteLine("Could not update Personality traits");
        }
    }
    public string getIdeals (){

        return ideals;
    }
    public void updateIdeals (string newIdeals){

        try{

            ideals = newIdeals;
        } catch {

            Console.WriteLine("Could not update Ideals");
        }
    }
    public string getBonds (){

        return bonds;
    }
    public void updateBonds (string newBonds){

        try{

            bonds = newBonds;
        } catch {

            Console.WriteLine("Could not update Bonds");
        }
    }
    public string getFlaws (){

        return flaws;
    }
    public void updateFlaws (string newFlaws){

        try{

            flaws = newFlaws;
        } catch {

            Console.WriteLine("Could not update Flaws");
        }
    }
    public string getBackground (){

        return characterBackground;
    }
    public void updateBackground (string newCharacterBackground){

        try{

            characterBackground = newCharacterBackground;
        } catch {

            Console.WriteLine("Could not update Character Background");
        }
    }
    public string getCharacterClass (){

        return characterClass;
    }
    public void updateCharacterClass (string newCharacterClass){

        try{

            characterClass = newCharacterClass;
        } catch {

            Console.WriteLine("Could not update Character Class");
        }
    }
    public int getLevel (){

        return level;
    }
    public void updateLevel (string newLevel){

        try{

            level = newLevel;
        } catch {

            Console.WriteLine("Could not update Character Level");
        }
    }
    public string getLevel (){

        return level;
    }
    public void updateLevel (int newLevel){

        try{

            level = newLevel;
        } catch {

            Console.WriteLine("Could not update Character Level");
        }
    }
    public string getAlignment (){

        return alignment;
    }
    public void updateAlignment (string newAlignment){

        try{

            alignment = newAlignment;
        } catch {

            Console.WriteLine("Could not update Character Alignment");
        }
    }
    public string getRace (){

        return race;
    }
    public void updateRace (string newRace){

        try{

            race = newRace;
        } catch {

            Console.WriteLine("Could not update Character Race");
        }
    }
    public string getPlayerName (){

        return playerName;
    }
    public void updatePlayerName (string newPlayerName){

        try{

            playerName = newPlayerName;
        } catch {

            Console.WriteLine("Could not update Player Name");
        }
    }
    public int getAge (){

        return age;
    }
    public void updateAge (int newAge){

        try{

            age = newAge;
        } catch {

            Console.WriteLine("Could not update Character Age");
        }
    }
    public int getHeight (){

        return height;
    }
    public void updateHeight (int newHeight){

        try{

            height = newHeight;
        } catch {

            Console.WriteLine("Could not update Character Height");
        }
    }
    public int getWeight (){

        return weight;
    }
    public void updateWeight (int newWeight){

        try{

            weight = newWeight;
        } catch {

            Console.WriteLine("Could not update Character Weight");
        }
    }
    public string getEyes (){

        return eyes;
    }
    public void updateEyes (string newEyes){

        try{

            eyes = newEyes;
        } catch {

            Console.WriteLine("Could not update Character Eyes");
        }
    }
    public string getSkin (){

        return skin;
    }
    public void updateSkin (string newSkin){

        try{

            skin = newSkin;
        } catch {

            Console.WriteLine("Could not update Character Skin");
        }
    }
    public string getHair (){

        return hair;
    }
    public void updateHair (string newHair){

        try{

            hair = newHair;
        } catch {

            Console.WriteLine("Could not update Character Hair");
        }
    }
    public string getBackstory (){

        return characterBackstory;
    }
    public void updateBackstory (string newBackstory){

        try{

            characterBackstory = newBackstory;
        } catch {

            Console.WriteLine("Could not update Character Backstory");
        }
    }
}