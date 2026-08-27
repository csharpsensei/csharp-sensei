namespace DesignPatterns.Legacy;

/// <summary>
/// The board before any of the three families. One method that decides what to
/// build, speaks the feed's packed format, and picks the wording. It works, and
/// every one of its three problems has a name. DO NOT COPY.
/// </summary>
public sealed class HandBuiltBoard
{
    private readonly RegionalTimetable _timetable = new RegionalTimetable();

    public IEnumerable<string> Rows(bool quietHours)
    {
        foreach (string row in _timetable.Fetch())
        {
            string[] parts = row.Split('|');

            // Problem one: deciding what to build, written out here.
            string label = parts[2] == "TRN" ? "Train" : "Bus replacement";

            // Problem two: the feed's own format, in the middle of the rule.
            string due = parts[0];
            string destination = parts[1];
            int delay = int.Parse(parts[3]);

            // Problem three: the wording rule, growing one branch at a time.
            string note = string.Empty;
            if (delay > 0 && !quietHours) note = "delayed " + delay + " min";
            else if (delay >= 5) note = "delayed " + delay + " min";
            else if (!quietHours) note = "on time";

            yield return (due + "  " + destination.PadRight(12)
                          + label.PadRight(16) + note).TrimEnd();
        }
    }
}
