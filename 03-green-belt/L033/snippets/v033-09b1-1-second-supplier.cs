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
