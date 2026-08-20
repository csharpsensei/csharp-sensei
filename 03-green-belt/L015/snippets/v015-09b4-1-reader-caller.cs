public sealed class ThumbnailMaker
{
    private readonly IReadFiles _files;

    public ThumbnailMaker(IReadFiles files) => _files = files;

    public string Shrink(string name)
    {
        byte[] source = _files.Read(name);
        byte[] small = new byte[source.Length / 4];
        return $"{name} {source.Length} bytes -> {small.Length} bytes";
    }
}
