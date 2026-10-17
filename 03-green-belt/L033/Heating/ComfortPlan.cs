using AdapterPattern.Reporting;

namespace AdapterPattern.Heating;

/// <summary>Our application code. It knows Celsius and IThermostat, nothing else.</summary>
public sealed class ComfortPlan(IThermostat thermostat)
{
    public string Request(double celsius)
    {
        try
        {
            thermostat.SetTargetCelsius(celsius);
        }
        catch (TargetRejectedException ex)
        {
            return "refused, " + ex.Message;
        }

        return "now " + Describe.Celsius(thermostat.CurrentCelsius())
            + "  target " + Describe.Celsius(thermostat.TargetCelsius());
    }
}
