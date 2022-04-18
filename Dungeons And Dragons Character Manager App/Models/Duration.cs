namespace Dungeons_And_Dragons_Character_Manager_App.Models;

public class Duration{
    public int Id { get; }
    string DurationType { get; set; } = "ACTION";
    int Magnitude { get; set; } = 1;

    public Duration(int magnitude, string type){
        if (this.setDurationType(type))
            this.Magnitude = magnitude;
        else
            throw new InvalidDataException(
                String.Format("Invalid duration type. Select from {0} or {1}.", 
                string.Join(", ", timeDurations), 
                string.Join(", ", constantDurations))
            );
    }

    List<string> timeDurations = new List<string>(){
        "ACTION","ROUND","BONUS ACTION","HOUR","MINUTE"
    };

    List<string> constantDurations = new List<string>(){
        "INSTANTANEOUS","REACTION","UNTIL DISPELLED","UNTIL TRIGGERED"
    };

    private bool constantDuration(string durationType){
        return constantDurations.Contains(durationType);
    }

    private bool timeDuration(string durationType){
        return timeDurations.Contains(durationType);
    }

    private bool setDurationType(string durationType){
        durationType = durationType.ToUpper();
        if (timeDuration(durationType) || constantDuration(durationType))
            this.DurationType = durationType;
        return this.DurationType == durationType;
    }

    public override string ToString(){
        if (timeDuration(this.DurationType))
            return String.Format("{0} {1}(S)", this.Magnitude, this.DurationType);
        return this.DurationType;
    }
}