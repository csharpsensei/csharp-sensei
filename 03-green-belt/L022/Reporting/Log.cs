namespace SingletonPattern.Reporting;

/// <summary>
/// Every line this program prints goes through here. Console.WriteLine is
/// already synchronised, so the four threads in pass two cannot interleave
/// halfway through a line; what they can do is arrive in any order, which is
/// why pass two prints identical lines and a count rather than per-thread
/// detail.
/// </summary>
public static class Log
{
    public static void Line(string text) => Console.WriteLine(text);

    public static void Blank() => Console.WriteLine();
}
