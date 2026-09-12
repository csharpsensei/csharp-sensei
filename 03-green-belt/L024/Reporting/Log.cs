namespace BuilderPattern.Reporting;

/// <summary>
/// Every line this program prints goes through here, so the output the video
/// shows and the output you get are produced by the same two methods.
/// </summary>
public static class Log
{
    public static void Line(string text) => Console.WriteLine(text);

    public static void Blank() => Console.WriteLine();
}
