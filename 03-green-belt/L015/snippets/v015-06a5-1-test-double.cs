public sealed class StubFileStore : IFileStore
{
    public byte[] Read(string name) => new byte[256];

    public void Write(string name, byte[] content) { }

    public void Delete(string name) { }

    public IReadOnlyList<string> List() => Array.Empty<string>();

    public void Snapshot(string destination) { }

    public void SetAccess(string user, bool canWrite) { }
}
