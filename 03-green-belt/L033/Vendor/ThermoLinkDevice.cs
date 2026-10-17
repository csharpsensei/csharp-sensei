namespace AdapterPattern.Vendor;

/// <summary>
/// A second supplier's SDK, also not ours. Tenths of a degree Celsius, and a
/// bool rather than a status code. Simulated in memory, as with Heatwise.
/// </summary>
public sealed class ThermoLinkDevice(int currentTenths)
{
    public int Target { get; private set; } = 160;

    public int ReadTenths() => currentTenths;

    public bool TrySetTarget(int tenths)
    {
        if (tenths < 50 || tenths > 350)
            return false;

        Target = tenths;
        return true;
    }
}
