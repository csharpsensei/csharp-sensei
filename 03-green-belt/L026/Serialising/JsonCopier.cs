using System.Text.Json;

namespace PrototypePattern.Serialising;

/// <summary>
/// A deep copy by writing the object out and reading it back in.
///
/// It works, and the price is named in the README and in the lesson: every
/// type in the graph has to be serialisable, anything the serialiser cannot
/// see is quietly lost, and it is far slower than the hand written copy. It
/// is a tool for a shape you do not control, not a default.
/// </summary>
public static class JsonCopier
{
    public static T RoundTrip<T>(T value)
    {
        string json = JsonSerializer.Serialize(value);
        T? copy = JsonSerializer.Deserialize<T>(json);

        if (copy is null)
        {
            throw new InvalidOperationException("nothing came back");
        }

        return copy;
    }
}
