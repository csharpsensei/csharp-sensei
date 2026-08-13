// Added mid-lesson. Nothing above this file changes.
public class SmartSpeaker : Device
{
    public SmartSpeaker(string name) : base(name) { }

    public override void Power() =>
        Console.WriteLine($"{Name}: powering on, listening for the wake word.");
}
</content>
