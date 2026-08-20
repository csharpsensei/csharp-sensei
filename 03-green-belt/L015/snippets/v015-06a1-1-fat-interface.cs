public interface IFileStore
{
    byte[] Read(string name);

    void Write(string name, byte[] content);

    void Delete(string name);

    IReadOnlyList<string> List();

    void Snapshot(string destination);

    void SetAccess(string user, bool canWrite);
}
