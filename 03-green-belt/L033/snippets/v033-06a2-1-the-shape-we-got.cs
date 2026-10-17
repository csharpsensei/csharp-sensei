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
