public interface IThermostat
{
    double CurrentCelsius();

    void SetTargetCelsius(double celsius);

    double TargetCelsius();
}
