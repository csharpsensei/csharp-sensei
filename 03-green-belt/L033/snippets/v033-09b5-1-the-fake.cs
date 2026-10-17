public sealed class FakeThermostat(double currentCelsius) : IThermostat
{
    public List<double> Targets { get; } = new List<double>();
    public double CurrentCelsius() => currentCelsius;
    public void SetTargetCelsius(double celsius) => Targets.Add(celsius);
    public double TargetCelsius() => Targets.Count == 0 ? 0 : Targets[^1];
}
