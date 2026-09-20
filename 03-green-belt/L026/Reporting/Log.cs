namespace PrototypePattern.Reporting;

/// <summary>Console formatting, kept out of Program so the passes read as passes.</summary>
public static class Log
{
    public static void Pass(string heading)
    {
        Console.WriteLine();
        Console.WriteLine(heading);
    }

    public static void Item(string text)
    {
        Console.WriteLine("  " + text);
    }
}
