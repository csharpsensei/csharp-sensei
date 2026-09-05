using SingletonPattern.Reporting;

namespace SingletonPattern.Safe;

/// <summary>
/// The same thing with the race taken out, and it is one line rather than a
/// lock. A static field initialiser runs once, and the runtime is the thing
/// that guarantees it, so there is nothing left to get wrong.
///
/// Note what this fixes and what it does not. It fixes "built more than once".
/// It does not fix the hidden dependency, and it does not make the type
/// substitutable in a test.
/// </summary>
public sealed class RateTableOnce
{
    private static readonly RateTableOnce _instance = new RateTableOnce();
    private static int _constructions;

    // An explicit, empty static constructor. Without one the type is marked
    // beforefieldinit and the runtime is allowed to run the field initialiser
    // earlier than the first access to it, which would put this class's one
    // line of output somewhere else in the run. It has no effect on how
    // many times the initialiser runs, only on when.
    static RateTableOnce()
    {
    }

    private RateTableOnce()
    {
        Interlocked.Increment(ref _constructions);
        Log.Line("  building the rate table (expensive, meant to be once)");
    }

    public static int Constructions => Volatile.Read(ref _constructions);

    public static RateTableOnce Instance => _instance;
}
