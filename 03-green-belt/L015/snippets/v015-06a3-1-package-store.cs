public sealed class LegacyPackageStore : IFileStore
{
    public byte[] Read(string name) => Packaged[name];

    public IReadOnlyList<string> List() => Packaged.Keys.ToList();

    public void Write(string name, byte[] content)
        => throw new NotImplementedException("PackageStore is read only");

    public void Delete(string name)
        => throw new NotImplementedException("PackageStore is read only");

    public void Snapshot(string destination)
        => throw new NotImplementedException("PackageStore cannot snapshot");

    public void SetAccess(string user, bool canWrite)
        => throw new NotImplementedException("PackageStore has no permissions");
}
