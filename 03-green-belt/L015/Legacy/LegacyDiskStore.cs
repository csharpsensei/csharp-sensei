namespace InterfaceSegregation.Legacy;

/// <summary>
/// DO NOT COPY (the interface, not this class). A folder on disk really can
/// do all six, so nothing here is faked and nothing here throws. A wide
/// interface with one implementation looks fine right up until the second
/// implementation turns up.
/// </summary>
public sealed class LegacyDiskStore : IFileStore
{
    private readonly string _root;

    public LegacyDiskStore(string root) => _root = root;

    public byte[] Read(string name)
        => File.ReadAllBytes(Path.Combine(_root, name));

    public void Write(string name, byte[] content)
        => File.WriteAllBytes(Path.Combine(_root, name), content);

    public void Delete(string name)
        => File.Delete(Path.Combine(_root, name));

    public IReadOnlyList<string> List()
        => Directory.GetFiles(_root).Select(p => Path.GetFileName(p)).ToList();

    public void Snapshot(string destination)
    {
        Directory.CreateDirectory(destination);
        foreach (string path in Directory.GetFiles(_root))
        {
            File.Copy(path, Path.Combine(destination, Path.GetFileName(path)), true);
        }
    }

    public void SetAccess(string user, bool canWrite)
    {
        // A real implementation would edit an access control list here. The
        // demo does not need one and inventing one would not change the
        // lesson: this class CAN do it, which is the only point being made.
    }
}
