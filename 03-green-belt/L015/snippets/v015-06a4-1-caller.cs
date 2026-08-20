public sealed class LegacyThumbnailMaker
{
    private readonly IFileStore _files;

    public LegacyThumbnailMaker(IFileStore files) => _files = files;

    public string Shrink(string name)
    {
        byte[] source = _files.Read(name);
        byte[] small = new byte[source.Length / 4];
        return $"{name} {source.Length} bytes -> {small.Length} bytes";
    }
}
