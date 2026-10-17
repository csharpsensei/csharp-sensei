using FacadePattern.Publishing;

namespace FacadePattern.Callers;

/// <summary>
/// An admin tool that needs ONE subsystem and nothing else, so it takes the
/// search index directly. A facade simplifies; it does not wall anything off.
/// </summary>
public sealed class ReindexTool(SearchIndex index)
{
    public int ReindexAll(IEnumerable<string> slugs)
    {
        int count = 0;
        foreach (string slug in slugs)
        {
            index.Add(slug);
            count++;
        }

        return count;
    }
}
