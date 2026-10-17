namespace AdapterPattern.Heating;

/// <summary>
/// The shape OUR code talks to. Celsius, doubles, and one exception type
/// when a target is refused. Written for the heating plan, not for any box.
/// </summary>
public interface IThermostat
{
    double CurrentCelsius();

    void SetTargetCelsius(double celsius);

    double TargetCelsius();
}
