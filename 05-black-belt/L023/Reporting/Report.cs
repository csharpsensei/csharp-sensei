namespace TailSampling.Reporting;

/// <summary>
/// Console formatting, kept out of the passes so they read as the argument
/// rather than as string handling.
/// </summary>
public static class Report
{
    private const int LabelWidth = 30;
    private const int ValueWidth = 4;

    public static void Line(string text) => Console.WriteLine(text);

    public static void Blank() => Console.WriteLine();

    public static void Row(string label, int value, string tail = "")
        => Console.WriteLine("  "
                             + (label + " ").PadRight(LabelWidth, '.')
                             + " "
                             + value.ToString().PadLeft(ValueWidth)
                             + tail);
}
