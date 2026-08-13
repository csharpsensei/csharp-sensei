namespace LockingAndPolymorphism.Devices;

// sealed: this type can still be used and instantiated exactly as before.
// What it can no longer do is act as a base class for anything else — see
// snippets/v011-12b2-1-sealed-error.cs for what happens if something tries.
public sealed class BluRayPlayer : Device
{
    public BluRayPlayer(string name) : base(name) { }

    public override void Power() =>
        Console.WriteLine($"{Name}: spinning up the drive at the standard speed.");
}
</content>
