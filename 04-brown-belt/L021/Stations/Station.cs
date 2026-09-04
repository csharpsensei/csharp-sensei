namespace InsideAsyncAwait.Stations;

/// <summary>
/// Stands in for something slow that is not our code: a sensor, a web call, a
/// disk. It awaits a timer rather than a network, so the sample runs offline
/// and still does real asynchronous waiting.
/// </summary>
public static class Station
{
    /// <summary>
    /// The readings are fixed so the arithmetic is the same on every run, and
    /// both of them are exact in binary, so the average prints as 12.5 rather
    /// than as a long tail of nines.
    /// </summary>
    public static double Fixed(string name) => name switch
    {
        "north" => 11.25,
        "south" => 13.75,
        _ => 0.0
    };

    public static async Task<double> ReadAsync(string name)
    {
        await Task.Delay(50);
        return Fixed(name);
    }
}
