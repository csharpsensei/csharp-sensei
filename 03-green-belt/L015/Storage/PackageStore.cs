namespace InterfaceSegregation.Storage;

/// <summary>
/// The same class as LegacyPackageStore, with one difference: it implements
/// IReadFiles and nothing else. There is no throw anywhere in it, because
/// there is nothing left in it to throw from.
/// </summary>
public sealed class PackageStore : IReadFiles
{
    private static readonly Dictionary<string, byte[]> Packaged = new()
    {
        ["logo.png"] = new byte[128],
    };

    public byte[] Read(string name) => Packaged[name];

    public IReadOnlyList<string> List() => Packaged.Keys.ToList();
}
