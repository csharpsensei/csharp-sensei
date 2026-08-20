public interface IReadFiles
{
    byte[] Read(string name);

    IReadOnlyList<string> List();
}

public interface IWriteFiles
{
    void Write(string name, byte[] content);

    void Delete(string name);
}

public interface IManageAccess
{
    void Snapshot(string destination);

    void SetAccess(string user, bool canWrite);
}
