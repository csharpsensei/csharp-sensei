public sealed class WideEvent
{
    private readonly Dictionary<string, object?> _fields = new();

    public void Set(string key, object? value) => _fields[key] = value;

    public IReadOnlyDictionary<string, object?> Fields => _fields;
}
