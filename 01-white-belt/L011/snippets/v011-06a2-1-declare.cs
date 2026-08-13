public class Device
{
    public string Name { get; }

    public Device(string name) => Name = name;

    public virtual void Power() =>
        Console.WriteLine($"{Name}: toggling power (no device-specific behaviour defined).");
}
</content>
