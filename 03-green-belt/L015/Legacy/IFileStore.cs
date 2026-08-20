namespace InterfaceSegregation.Legacy;

/// <summary>
/// DO NOT COPY. This is the shape the lesson is about.
///
/// Six members. Every one of them is a real thing a file store does, and
/// every one of them was justified on the day it was added. Nothing here
/// was designed in one sitting, which is exactly how interfaces get this
/// wide without anybody deciding to make them wide.
/// </summary>
public interface IFileStore
{
    byte[] Read(string name);

    void Write(string name, byte[] content);

    void Delete(string name);

    IReadOnlyList<string> List();

    void Snapshot(string destination);

    void SetAccess(string user, bool canWrite);
}
