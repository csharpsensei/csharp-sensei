using AdapterPattern.Vendor;

namespace AdapterPattern.Heating;

/// <summary>
/// The adapter. It implements OUR interface, holds THEIR controller, and
/// translates: names, units, and the status code. It decides nothing about
/// heating. The one decision it does make, rounding to a whole Fahrenheit
/// degree because the box takes nothing finer, is a translation decision,
/// and it is written down here rather than hidden.
/// </summary>
public sealed class HeatwiseThermostat(HeatwiseController box)
    : IThermostat
{
    public double CurrentCelsius() =>
        ToCelsius(box.ReadTemperatureF());

    public void SetTargetCelsius(double celsius)
    {
        int fahrenheit = (int)Math.Round(celsius * 9 / 5 + 32);
        int status = box.SetPointF(fahrenheit);

        if (status == HeatwiseController.OutOfRange)
            throw new TargetRejectedException("Heatwise takes 10 to 30 C");
    }

    public double TargetCelsius() =>
        ToCelsius(box.SetPoint);

    private static double ToCelsius(int fahrenheit) =>
        (fahrenheit - 32) * 5 / 9.0;
}
