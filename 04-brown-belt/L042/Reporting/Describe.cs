using System.Diagnostics;
using CoordinatingTasks.Taxis;

namespace CoordinatingTasks.Reporting;

/// <summary>Printing helpers. Times rounded down to 100 ms so runs compare.</summary>
public static class Describe
{
    public static long Millis(Stopwatch clock) =>
        clock.ElapsedMilliseconds / 100 * 100;

    public static async Task<string> Outcome(Task<Quote> task)
    {
        try
        {
            await task;
            return "answered anyway";
        }
        catch (OperationCanceledException)
        {
            return "cancelled";
        }
    }
}
