using System.Diagnostics;

namespace WideEvents.Events;

/// <summary>
/// One request's worth of facts, accumulated as the request runs and written
/// out exactly once at the end.
///
/// This is the whole pattern. There is no interface and no package, because
/// there is nothing here worth abstracting — a dictionary and a Set method.
/// </summary>
public sealed class WideEvent
{
    private readonly Dictionary<string, object?> _fields = new();

    /// <summary>Add or overwrite one field. Last writer wins.</summary>
    public void Set(string key, object? value) => _fields[key] = value;

    /// <summary>Read-only view, for serialising or asserting in tests.</summary>
    public IReadOnlyDictionary<string, object?> Fields => _fields;

    /// <summary>
    /// Copy every accumulated field onto the current trace span.
    ///
    /// This is the step that stops the wide event being a log line sitting
    /// next to the trace, and makes it the trace. In Azure Monitor every tag
    /// set here is exported as a custom dimension, landing in the
    /// customDimensions column of the requests table — which is what makes the
    /// KQL in L008.http possible.
    /// </summary>
    public void CopyToActivity()
    {
        var activity = Activity.Current;
        if (activity is null) return;

        foreach (var (key, value) in _fields)
            activity.SetTag(key, value);
    }
}
