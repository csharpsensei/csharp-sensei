namespace InterfaceSegregation.Legacy;

/// <summary>
/// DO NOT COPY. Four of the six members have no honest body, so they throw.
/// That is not laziness and it is not an unfinished job: there is no correct
/// implementation to write, because the thing the member describes cannot
/// happen for this class.
/// </summary>
public sealed class LegacyPackageStore : IFileStore
{
    private static readonly Dictionary<string, byte[]> Packaged = new()
    {
        ["logo.png"] = new byte[128],
    };

    public byte[] Read(string name) => Packaged[name];

    public IReadOnlyList<string> List() => Packaged.Keys.ToList();

    // The package sits on a read only medium. There is no write to
    // perform, and nothing this method could return would be true.
    public void Write(string name, byte[] content)
        => throw new NotImplementedException("PackageStore is read only");

    public void Delete(string name)
        => throw new NotImplementedException("PackageStore is read only");

    public void Snapshot(string destination)
        => throw new NotImplementedException("PackageStore cannot snapshot");

    public void SetAccess(string user, bool canWrite)
        => throw new NotImplementedException("PackageStore has no permissions");
}
