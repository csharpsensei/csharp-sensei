using System.Globalization;

namespace AdapterPattern.Reporting;

/// <summary>One decimal place, invariant culture, so every machine prints the same.</summary>
public static class Describe
{
    public static string Celsius(double value) =>
        value.ToString("0.0", CultureInfo.InvariantCulture) + " C";
}
