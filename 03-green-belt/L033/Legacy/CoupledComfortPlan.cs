using AdapterPattern.Reporting;
using AdapterPattern.Vendor;

namespace AdapterPattern.Legacy;

/// <summary>
/// DO NOT COPY THIS SHAPE. The plan reaching straight into the supplier's
/// controller: Fahrenheit sums and status codes inside our own logic.
/// It works, which is why it survives, and it is the hook of the lesson.
/// </summary>
public sealed class CoupledComfortPlan(HeatwiseController box)
{
    public string Warm(double celsius)
    {
        int now = box.ReadTemperatureF();
        int fahrenheit = (int)Math.Round(celsius * 9 / 5 + 32);
        int status = box.SetPointF(fahrenheit);

        return $"reads {now} F, asked {Describe.Celsius(celsius)}, "
            + $"sent {fahrenheit} F, status {status}";
    }
}
