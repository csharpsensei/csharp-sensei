namespace AdapterPattern.Vendor;

/// <summary>
/// Stands in for a supplier's SDK: a class we did not write and cannot edit.
/// Fahrenheit, whole degrees only, and a status code instead of an exception.
/// Sealed, as supplier types often are. A simplification named in the README:
/// a real SDK would talk to hardware; this one keeps the numbers in memory.
/// </summary>
public sealed class HeatwiseController(int currentFahrenheit)
{
    public const int Ok = 0;
    public const int OutOfRange = 3;

    public int SetPoint { get; private set; } = 60;

    public int ReadTemperatureF() => currentFahrenheit;

    public int SetPointF(int fahrenheit)
    {
        if (fahrenheit < 50 || fahrenheit > 86)
            return OutOfRange;

        SetPoint = fahrenheit;
        return Ok;
    }
}
