namespace InterfaceSegregation.Legacy;

/// <summary>
/// DO NOT COPY. This class reads. That is the whole job. Its constructor
/// makes it depend on writing, deleting, listing, snapshotting and
/// permissions, none of which it ever calls.
/// </summary>
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
