namespace LockingAndPolymorphism.Devices;

/// <summary>
/// The base class every device inherits from. Power is virtual: a derived
/// class is allowed, but not required, to supply its own version.
/// </summary>
public class Device
{
    public string Name { get; }

    public Device(string name) => Name = name;

    public virtual void Power() =>
        Console.WriteLine($"{Name}: toggling power (no device-specific behaviour defined).");
}
