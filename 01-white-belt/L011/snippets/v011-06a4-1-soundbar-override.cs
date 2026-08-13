public class Soundbar : Device
{
    public Soundbar(string name) : base(name) { }

    public override void Power() =>
        Console.WriteLine($"{Name}: powering on, restoring last night's volume.");
}
