namespace FacadePattern.Publishing;

/// <summary>A subsystem. Queues the article for the subscribers' email.</summary>
public sealed class Newsletter(List<string> journal)
{
    public void Queue(string slug)
    {
        journal.Add("newsletter");
    }
}
