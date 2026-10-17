using AdapterPattern.Heating;
using AdapterPattern.Vendor;

namespace AdapterPattern.Legacy;

/// <summary>
/// DO NOT COPY THIS SHAPE. An adapter that has started making decisions:
/// a heating rule, "never above 24 C", living inside the translation.
/// Shown on screen as mistake one; no pass runs it.
/// </summary>
public sealed class OpinionatedThermostat(HeatwiseController box) : IThermostat
{
    public double CurrentCelsius() =>
        (box.ReadTemperatureF() - 32) * 5 / 9.0;

    public void SetTargetCelsius(double celsius)
    {
        double capped = Math.Min(celsius, 24.0);
        box.SetPointF((int)Math.Round(capped * 9 / 5 + 32));
    }

    public double TargetCelsius() => (box.SetPoint - 32) * 5 / 9.0;
}
