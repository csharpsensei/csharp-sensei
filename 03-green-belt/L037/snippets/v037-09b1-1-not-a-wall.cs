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
