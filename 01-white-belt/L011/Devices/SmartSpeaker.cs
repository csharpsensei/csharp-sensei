namespace LockingAndPolymorphism.Devices;

// Added mid-lesson (block 08a2) to prove the payoff: nothing in Program.cs's
// calling code, or in Device, Tv or Soundbar, changes when this file is added.
public class SmartSpeaker : Device
{
    public SmartSpeaker(string name) : base(name) { }

    public override void Power() =>
        Console.WriteLine($"{Name}: powering on, listening for the wake word.");
}
</content>
