public sealed class DiskFileStore : IReadFiles, IWriteFiles, IManageAccess
{
    public byte[] Read(string name)
        => File.ReadAllBytes(Path.Combine(_root, name));

    public IReadOnlyList<string> List()
        => Directory.GetFiles(_root).Select(p => Path.GetFileName(p)).ToList();

    public void Write(string name, byte[] content)
        => File.WriteAllBytes(Path.Combine(_root, name), content);

    public void Delete(string name)
        => File.Delete(Path.Combine(_root, name));
}
