public sealed class PackageStore : IReadFiles
{
    private static readonly Dictionary<string, byte[]> Packaged = new()
    {
        ["logo.png"] = new byte[128],
    };

    public byte[] Read(string name) => Packaged[name];

    public IReadOnlyList<string> List() => Packaged.Keys.ToList();
}
