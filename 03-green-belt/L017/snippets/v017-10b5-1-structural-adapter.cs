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
