namespace ProxyPattern.Archive;

/// <summary>Counts how many times an archive was really opened.</summary>
public sealed class OpenCounter
{
    public int Count { get; private set; }

    public void Record() => Count++;
}
