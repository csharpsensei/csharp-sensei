namespace InterfaceSegregation.Storage;

/// <summary>
/// Named for what the caller does, not for what the store is.
/// </summary>
public interface IReadFiles
{
    byte[] Read(string name);

    IReadOnlyList<string> List();
}
