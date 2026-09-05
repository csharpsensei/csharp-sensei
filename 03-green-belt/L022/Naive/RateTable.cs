using SingletonPattern.Reporting;

namespace SingletonPattern.Naive;

/// <summary>
/// The other classic reason people reach for a singleton: something expensive
/// that should only be built once. The constructor announces itself, so the
/// program can show how many times it actually ran.
///
/// The null check in <see cref="Instance"/> is the naive one. Two threads can
/// both find the field empty before either of them fills it, and the pause is
/// there so that outcome is reliable rather than occasional.
/// </summary>
public sealed class RateTable
{
    private static RateTable? _instance;
    private static int _constructions;

    private RateTable()
    {
        Interlocked.Increment(ref _constructions);
        Log.Line("  building the rate table (expensive, meant to be once)");
    }

    public static int Constructions => Volatile.Read(ref _constructions);

    public static RateTable Instance
    {
        get
        {
            if (_instance is null)
            {
                // Only here to make the race reliable. Take it out and the
                // same thing still happens, just not on every run.
                Thread.Sleep(60);
                _instance = new RateTable();
            }

            return _instance;
        }
    }
}
