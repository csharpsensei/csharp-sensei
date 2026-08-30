using LinqBasics.Model;

namespace LinqBasics.Sifting;

/// <summary>
/// The same shortlist as the loop, written as a query. Where keeps applications
/// and changes nothing about the ones it keeps, so what comes back is still
/// candidates.
/// </summary>
public static class Shortlist
{
    /// <summary>One condition. Kept so the program can show what the second one does.</summary>
    public static IEnumerable<Candidate> WithCSharp(IEnumerable<Candidate> pile) =>
        pile.Where(candidate => candidate.Has("C#"));

    /// <summary>Both conditions. This is the shortlist the loop was producing.</summary>
    public static IEnumerable<Candidate> For(IEnumerable<Candidate> pile) =>
        pile.Where(candidate => candidate.Has("C#") && candidate.Has("Azure"));
}
