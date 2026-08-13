public class Tv : Device
{
    public Tv(string name) : base(name) { }

    public override void Power() =>
        Console.WriteLine($"{Name}: warming up the panel, switching to the last input.");
}
</content>
