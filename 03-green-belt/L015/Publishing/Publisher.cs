using InterfaceSegregation.Storage;

namespace InterfaceSegregation.Publishing;

/// <summary>
/// This one writes, so it asks for the one interface that writes. A store
/// that cannot write can no longer be handed to it, and that is now a
/// compiler error rather than a customer's bug report.
/// </summary>
public sealed class Publisher
{
    private readonly IWriteFiles _files;

    public Publisher(IWriteFiles files) => _files = files;

    public string Publish(string name)
    {
        _files.Write(name, new byte[64]);
        return $"published {name}";
    }
}
