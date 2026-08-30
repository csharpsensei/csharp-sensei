namespace LinqBasics.Model;

/// <summary>
/// One job application. Skills is exposed as a read-only list so a candidate
/// cannot be edited by whoever is reading it.
/// </summary>
public sealed record Candidate(
    string Name,
    string Phone,
    IReadOnlyList<string> Skills)
{
    public bool Has(string skill) => Skills.Contains(skill);
}
