namespace FacadePattern.Publishing;

/// <summary>A subsystem. Must run after the images exist, or results show broken thumbnails.</summary>
public sealed class SearchIndex(List<string> journal)
{
    public void Add(string slug)
    {
        journal.Add("index");
    }
}
