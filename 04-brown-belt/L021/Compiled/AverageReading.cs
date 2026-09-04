using InsideAsyncAwait.Reporting;
using InsideAsyncAwait.Stations;

namespace InsideAsyncAwait.Compiled;

/// <summary>
/// The method the whole lesson is about. Nothing in here is unusual, and that
/// is the point: it is the plainest async method you could write, and the
/// compiler still rewrites it into a type that does not appear in this file.
/// </summary>
public static class AverageReading
{
    /// <summary>
    /// Two awaits, so the generated machine has two places it can resume.
    /// <para>
    /// Watch the two locals. <c>first</c> is read before the second wait and
    /// used after it, so it has to survive the wait. <c>second</c> is read and
    /// used without a wait in between, so it does not.
    /// </para>
    /// </summary>
    public static async Task<double> ReadAverageAsync(string a, string b)
    {
        Log.Line("  [method] started on " + Log.Where + ", nothing awaited yet");

        double first = await Station.ReadAsync(a);
        Log.Line("  [method] first reading back, on " + Log.Where);

        double second = await Station.ReadAsync(b);
        Log.Line("  [method] second reading back, on " + Log.Where);

        return (first + second) / 2;
    }

    // CS1998 is suppressed deliberately, and the warning is the lesson: an
    // async method with no await has nothing to wait for, so the compiler
    // builds no state machine for it at all. Pass 2 asks the runtime and
    // gets that answer out loud.
#pragma warning disable CS1998
    /// <summary>Marked async, awaits nothing. There is no machine behind it.</summary>
    public static async Task<double> ReadNothingAsync(string name)
    {
        return Station.Fixed(name);
    }
#pragma warning restore CS1998
}
