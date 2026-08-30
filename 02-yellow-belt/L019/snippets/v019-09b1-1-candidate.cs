public sealed record Candidate(
    string Name,
    string Phone,
    IReadOnlyList<string> Skills)
{
    public bool Has(string skill) => Skills.Contains(skill);
}
