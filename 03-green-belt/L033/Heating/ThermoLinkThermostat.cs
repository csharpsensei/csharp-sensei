using AdapterPattern.Vendor;

namespace AdapterPattern.Heating;

/// <summary>
/// The second adapter. Different supplier, different shape: tenths of a
/// degree and a bool for "refused". Same interface out the other side.
/// </summary>
public sealed class ThermoLinkThermostat(ThermoLinkDevice device)
    : IThermostat
{
    public double CurrentCelsius() => device.ReadTenths() / 10.0;

    public void SetTargetCelsius(double celsius)
    {
        int tenths = (int)Math.Round(celsius * 10);

        if (!device.TrySetTarget(tenths))
            throw new TargetRejectedException("ThermoLink takes 5 to 35 C");
    }

    public double TargetCelsius() => device.Target / 10.0;
}
