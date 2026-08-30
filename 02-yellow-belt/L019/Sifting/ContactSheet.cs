using LinqBasics.Model;

namespace LinqBasics.Sifting;

/// <summary>
/// Select keeps the count and changes what each item is, so what comes back is
/// contacts and there is no way to ask one of them for a skill.
/// </summary>
public static class ContactSheet
{
    /// <summary>Select on its own. Twelve in, twelve out, and every one of them changed.</summary>
    public static IEnumerable<Contact> All(IEnumerable<Candidate> pile) =>
        pile.Select(candidate => new Contact(candidate.Name, candidate.Phone));

    /// <summary>Sift first, summarise second.</summary>
    public static IEnumerable<Contact> For(IEnumerable<Candidate> pile) =>
        pile
            .Where(candidate => candidate.Has("C#") && candidate.Has("Azure"))
            .Select(candidate => new Contact(candidate.Name, candidate.Phone));
}
