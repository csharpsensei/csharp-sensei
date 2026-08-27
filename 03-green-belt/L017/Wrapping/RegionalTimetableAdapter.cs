using DesignPatterns.Board;
using DesignPatterns.Creating;
using DesignPatterns.Legacy;

namespace DesignPatterns.Wrapping;

/// <summary>
/// Structural family, light touch. One class whose whole job is to make a shape
/// we do not own fit a shape we do. Nothing else in the program ever sees a pipe.
/// </summary>
public sealed class RegionalTimetableAdapter : IDepartureSource
{
    private readonly RegionalTimetable _timetable;

    public RegionalTimetableAdapter(RegionalTimetable timetable)
    {
        _timetable = timetable;
    }

    public IReadOnlyList<Departure> Next()
    {
        List<Departure> departures = new List<Departure>();

        foreach (string row in _timetable.Fetch())
        {
            string[] parts = row.Split('|');

            departures.Add(new Departure(
                Service: ServiceFactory.For(parts[2]),
                Destination: parts[1],
                Due: TimeOnly.Parse(parts[0]),
                DelayMinutes: int.Parse(parts[3])));
        }

        return departures;
    }
}
