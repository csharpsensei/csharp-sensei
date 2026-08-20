namespace InterfaceSegregation.Legacy;

/// <summary>
/// DO NOT COPY. The stand in you have to write to test a class that only
/// reads. Six members, because the interface has six. Five of them exist to
/// satisfy the compiler and are never called by any test.
/// </summary>
public sealed class StubFileStore : IFileStore
{
    public byte[] Read(string name) => new byte[256];

    public void Write(string name, byte[] content) { }

    public void Delete(string name) { }

    public IReadOnlyList<string> List() => Array.Empty<string>();

    public void Snapshot(string destination) { }

    public void SetAccess(string user, bool canWrite) { }
}
