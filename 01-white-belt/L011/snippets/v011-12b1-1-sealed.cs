public sealed class BluRayPlayer : Device
{
    public BluRayPlayer(string name) : base(name) { }

    public override void Power() =>
        Console.WriteLine($"{Name}: spinning up the drive at the standard speed.");
}
