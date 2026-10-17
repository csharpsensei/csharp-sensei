namespace FacadePattern.Publishing;

/// <summary>A subsystem. Counts known misspellings in the body.</summary>
public sealed class Proofreader(List<string> journal)
{
    private static readonly string[] Misspellings = { "teh", "recieve" };

    public int Check(Draft draft)
    {
        journal.Add("proofread");
        return draft.Body.Split(' ').Count(word => Misspellings.Contains(word));
    }
}
