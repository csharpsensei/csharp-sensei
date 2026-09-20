namespace NamingAndComments.Reporting;

public static class Log
{
    public static void Line(string text)
    {
        Console.WriteLine(text);
    }

    public static void Blank()
    {
        Console.WriteLine();
    }
}
