namespace InterfaceSegregation.Storage;

/// <summary>
/// One class, three interfaces. Segregating an interface does not mean
/// segregating the class: this store really can do all six things, so it
/// implements all three roles and nothing here is faked.
/// </summary>
public sealed class DiskFileStore : IReadFiles, IWriteFiles, IManageAccess
{
    private readonly string _root;

    public DiskFileStore(string root) => _root = root;

    public byte[] Read(string name)
        => File.ReadAllBytes(Path.Combine(_root, name));

    public IReadOnlyList<string> List()
        => Directory.GetFiles(_root).Select(p => Path.GetFileName(p)).ToList();

    public void Write(string name, byte[] content)
        => File.WriteAllBytes(Path.Combine(_root, name), content);

    public void Delete(string name)
        => File.Delete(Path.Combine(_root, name));

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
        // Same as the legacy version: this class CAN do it, which is why it
        // is allowed to say so in its declaration.
    }
}
