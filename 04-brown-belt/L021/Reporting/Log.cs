namespace InsideAsyncAwait.Reporting;

/// <summary>
/// Every line this program prints goes through here, and every line says which
/// thread wrote it. The label is deliberately not a thread id: ids change from
/// run to run, and the only fact this lesson needs is whether we are still on
/// the thread the program started on.
/// </summary>
public static class Log
{
    private static int _mainThreadId;

    /// <summary>Called once, from Main, before anything is awaited.</summary>
    public static void RememberMainThread() =>
        _mainThreadId = Environment.CurrentManagedThreadId;

    /// <summary>"the main thread", or "a pool thread". Never an id.</summary>
    public static string Where =>
        Environment.CurrentManagedThreadId == _mainThreadId
            ? "the main thread"
            : "a pool thread";

    public static void Line(string text) => Console.WriteLine(text);

    public static void Blank() => Console.WriteLine();
}
