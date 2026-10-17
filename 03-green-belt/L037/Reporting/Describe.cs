namespace FacadePattern.Reporting;

/// <summary>Prints the journal of steps a caller actually ran.</summary>
public static class Describe
{
    public static string Steps(IEnumerable<string> steps) =>
        string.Join(", ", steps);
}
