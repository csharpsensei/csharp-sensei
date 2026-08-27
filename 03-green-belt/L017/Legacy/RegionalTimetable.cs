namespace DesignPatterns.Legacy;

/// <summary>
/// Stands in for a third party feed. Assume we cannot change this file: it
/// ships in somebody else's package and it returns rows as one packed string
/// each, "HH:mm|DESTINATION|CODE|DELAY".
/// </summary>
public sealed class RegionalTimetable
{
    public string[] Fetch() => new string[]
    {
        "09:12|MANCHESTER|TRN|0",
        "09:20|LEEDS|BUS|6",
        "09:35|YORK|TRN|2"
    };
}
