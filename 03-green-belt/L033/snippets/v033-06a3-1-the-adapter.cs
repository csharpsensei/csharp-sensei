public sealed class HeatwiseThermostat(HeatwiseController box)
    : IThermostat
{
    public double CurrentCelsius() =>
        ToCelsius(box.ReadTemperatureF());
    public double TargetCelsius() =>
        ToCelsius(box.SetPoint);

    private static double ToCelsius(int fahrenheit) =>
        (fahrenheit - 32) * 5 / 9.0;
}
