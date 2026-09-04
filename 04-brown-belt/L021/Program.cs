using InsideAsyncAwait.ByHand;
using InsideAsyncAwait.Compiled;
using InsideAsyncAwait.Inspect;
using InsideAsyncAwait.Reporting;
using InsideAsyncAwait.Stations;

namespace InsideAsyncAwait;

public static class Program
{
    public static async Task Main()
    {
        Log.RememberMainThread();

        await WhatAwaitDoesAsync();
        Log.Blank();
        TheDocketTheCompilerWrote();
        Log.Blank();
        await TheSameThingByHandAsync();
    }

    /// <summary>
    /// Pass one. The method returns at its first await, the caller carries on,
    /// and the rest of the method runs later on whatever thread is free.
    /// </summary>
    private static async Task WhatAwaitDoesAsync()
    {
        Log.Line("Pass 1: what await really does");

        Task<double> pending = AverageReading.ReadAverageAsync("north", "south");

        Log.Line("  [main]   the call came back, and the answer is not here yet");
        Log.Line("  [main]   nothing is blocked: we are on " + Log.Where);

        double average = await pending;

        Log.Line("  [main]   the answer arrived: " + average);
        Log.Line("  [main]   and we came back on " + Log.Where);
    }

    /// <summary>
    /// Pass two. Ask the runtime what the compiler built. Three methods: one
    /// that awaits twice, one marked async that awaits nothing, and one that
    /// is not async at all.
    /// </summary>
    private static void TheDocketTheCompilerWrote()
    {
        Log.Line("Pass 2: the docket the compiler wrote");

        DocketPrinter.Print(typeof(AverageReading), nameof(AverageReading.ReadAverageAsync));
        DocketPrinter.Print(typeof(AverageReading), nameof(AverageReading.ReadNothingAsync));
        DocketPrinter.Print(typeof(Station), nameof(Station.Fixed));
    }

    /// <summary>
    /// Pass three. The same method with the async keyword taken away and the
    /// machine written out by hand, run beside the compiler's version.
    /// </summary>
    private static async Task TheSameThingByHandAsync()
    {
        Log.Line("Pass 3: the same method, written out by hand");

        double byCompiler = await Quietly("north", "south");
        double byHand = await AverageReadingByHand.ReadAverageAsync("north", "south");

        Log.Line("  the compiler wrote it: " + byCompiler);
        Log.Line("  we wrote it:           " + byHand);
        Log.Line("  same answer:           " + (byCompiler == byHand));
    }

    /// <summary>
    /// The same arithmetic as ReadAverageAsync without its logging, so pass
    /// three's output is about the hand-written machine and nothing else.
    /// </summary>
    private static async Task<double> Quietly(string a, string b)
    {
        double first = await Station.ReadAsync(a);
        double second = await Station.ReadAsync(b);
        return (first + second) / 2;
    }
}
